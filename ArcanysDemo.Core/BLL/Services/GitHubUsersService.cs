using ArcanysDemo.Core.BLL.Interfaces;
using ArcanysDemo.Core.Configurations;
using ArcanysDemo.Core.Helpers;
using ArcanysDemo.Core.Models;
using ArcanysDemo.Core.Utilities;
using ArcanysDemo.Core.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;
namespace ArcanysDemo.Core.BLL.Services
{
    public class GitHubUsersService : IGitHubUsersService
    {

        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IInMemoryWorkerService _inMemoryWorkerService;
        private readonly IHttpClientFactory _httpClientFactory;

        public GitHubUsersService(Microsoft.Extensions.Options.IOptions<AppSettings> appSettingsOption, IMapper mapper, IInMemoryWorkerService inMemoryWorkerService, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettingsOption.Value;
            _mapper = mapper;
            _inMemoryWorkerService = inMemoryWorkerService;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Fetches a list of github users from either the api or in the memory cache
        /// </summary>
        /// <param name="model">list of string username</param>
        /// <returns>response object</returns>
        public async Task<ResponseObject> GetGitHubUsers(string model)
        {
            var response = new ResponseObject(ResponseType.Success, string.Empty);
            List<string> stringListModel = DataTypeConverter.ConvertStringToList(model);
            var gitHubUserList = new List<GitHubUsersDto>();
            stringListModel = StringSanitizer.SanitizeStringListByGitHubPolicy(stringListModel);
            var modelValuesCount = ValidateArrayString(stringListModel);
            if (!modelValuesCount.IsSuccess)
            {
                return modelValuesCount;
            }
            int numberOfCachedRecords = 0;
            int numberOfRecordsNotFound = 0;
            foreach (var item in stringListModel)
            {
                if (stringListModel.Any())
                {
                    var sanitizedString = StringSanitizer.ToLowerAndTrim(item);
                    var gitHubUserDto = new GitHubUsersDto();
                    var fetchDataFromGithub = await FetchDataByUserName(sanitizedString);
                    if (fetchDataFromGithub.IsSuccess)
                    {
                        gitHubUserDto = _mapper.Map<GitHubUsersDto>(fetchDataFromGithub.Data);
                        _inMemoryWorkerService.StoreDataInMemory(gitHubUserDto, StringSanitizer.ToLowerAndTrim(gitHubUserDto.Login));
                        gitHubUserList.Add(gitHubUserDto);
                    }
                    else if (fetchDataFromGithub.IsCached)
                    {
                        gitHubUserDto = _mapper.Map<GitHubUsersDto>(fetchDataFromGithub.Data);
                        numberOfCachedRecords++;
                        gitHubUserList.Add(gitHubUserDto);
                    }
                    else
                    {
                        numberOfRecordsNotFound++;
                    }
                }
            }
            response.Data = gitHubUserList.OrderBy(x => x.Name);
            response.Message = numberOfCachedRecords + " out of " + modelValuesCount.Data + " is cached and " + numberOfRecordsNotFound + " record(s) were not found. Username that violates github policy were removed.";
            return response;
        }



        /// <summary>
        /// Gets the data by username
        /// </summary>
        /// <param name="username">username to be fetched</param>
        /// <returns>response object</returns>
        public async Task<ResponseObject> FetchDataByUserName(string username)
        {
            var response = new ResponseObject(ResponseType.Success, string.Empty);

            var inMemoryData = GetUserFromMemory(username);
            if (inMemoryData.IsSuccess)
            {
                return new ResponseObject(ResponseType.IsCached, string.Empty, inMemoryData.Data);
            }
            else
            {
                var getDataFromGitHub = await FetchDataFromGitHub(username);
                if (getDataFromGitHub.IsSuccess)
                {
                    response.Data = getDataFromGitHub.Data;
                }
                else
                {
                    response = getDataFromGitHub;
                }
            }
            return response;
        }
        public async Task<ResponseObject> FetchDataFromGitHub(string username)
        {
            var response = new ResponseObject(ResponseType.Success, string.Empty);
            Uri uri = new Uri(UrlWorker.GitHubUrlConstructor(_appSettings.GitHubUsersUrl, _appSettings.GitHubClientId, _appSettings.GitHubClientSecret, username));
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Headers.Add("User-Agent", "ArcanysDemo");
            httpRequest.Headers.Add("Accept", "*/*");
            httpRequest.Headers.Add("Host", "api.github.com");
            httpRequest.RequestUri = uri;
            httpRequest.Method = HttpMethod.Get;
            var client = _httpClientFactory.CreateClient();
            var httpResponse = await client.SendAsync(httpRequest);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseFromGithub = await httpResponse.Content.ReadAsStringAsync();
                response.Data = JsonConvert.DeserializeObject<GitHubUsers>(responseFromGithub);
            }
            else
            {
                response = new ResponseObject(ResponseType.Warning, string.Empty);
                ErrorHandling.LogCustomError("Username not found.", Enums.Severity.Information);
            }

            return response;
        }


        //public async Task<ResponseObject> FetchDataFromGitHub(string username)
        //{
        //    var response = new ResponseObject(ResponseType.Success, string.Empty);
        //    Uri uri = new Uri(UrlWorker.GitHubUrlConstructor(_appSettings.GitHubUsersUrl, _appSettings.GitHubClientId, _appSettings.GitHubClientSecret, username));
        //    using (HttpResponseMessage httpResponse = await ApiHelper.ApiClient.GetAsync(uri))
        //    {

        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            var responseFromGithub = await httpResponse.Content.ReadAsStringAsync();
        //            response.Data = JsonConvert.DeserializeObject<GitHubUsers>(responseFromGithub);
        //        }
        //        else
        //        {
        //            response = new ResponseObject(ResponseType.Warning, string.Empty);
        //            ErrorHandling.LogCustomError("Username not found.", Enums.Severity.Information);
        //        }
        //    }
        //    return response;
        //}

        /// <summary>
        /// Fetches user from memory
        /// </summary>
        /// <param name="userName">username to be fetched</param>
        /// <returns>response object</returns>
        public ResponseObject GetUserFromMemory(string userName)
        {
            var response = new ResponseObject(ResponseType.Success, string.Empty);

            var inMemoryResult = _inMemoryWorkerService.GetDataInMemory(userName);
            if (inMemoryResult.IsSuccess)
            {
                response.Data = inMemoryResult.Data;
            }
            else
            {
                response = new ResponseObject(ResponseType.Undefined, string.Empty);
            }

            return response;
        }

        /// <summary>
        /// validates the array that it would not exceed to the limit
        /// </summary>
        /// <param name="model">list of strings</param>
        /// <returns>response object</returns>
        public ResponseObject ValidateArrayString(List<string> model)
        {
            var response = new ResponseObject(ResponseType.Success, string.Empty);

            int numberOfArray = model.Count();
            if (numberOfArray > 10)
            {
                return new ResponseObject(ResponseType.Error, "Only a max of 10 users per request is allowed.");
            }
            else
            {
                response.Data = numberOfArray;
            }
            return response;
        }
    }
}
