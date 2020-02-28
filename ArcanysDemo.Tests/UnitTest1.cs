using ArcanysDemo.Core.BLL.Interfaces;
using ArcanysDemo.Core.BLL.Services;
using ArcanysDemo.Core.Configurations;
using ArcanysDemo.Core.Helpers;
using ArcanysDemo.Core.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace ArcanysDemo.Tests
{
    public class UnitTest1
    {

        [Theory(DisplayName = "Validate Count Of Array String")]
        [InlineData("test1", "test2", "test3", "test4", "test5")]
        public void TestCountValidationOfArrayString(params string[] model)
        {
            var appSettingsMock = Options.Create<AppSettings>(new AppSettings());
            var mappingMock = new Mock<IMapper>();
            var inMemoryServiceMock = new Mock<IInMemoryWorkerService>();
            var gitHubUsersService = new GitHubUsersService(appSettingsMock, mappingMock.Object, inMemoryServiceMock.Object);
            var castStringArrayToList = new List<string>(model);
            var result = gitHubUsersService.ValidateArrayString(castStringArrayToList).Data;
            Assert.Equal(result, 5);
        }

        [Theory(DisplayName = "Validate Error Message Of Array String")]
        [InlineData("test1", "test2", "test3", "test4", "test5", "test6", "test7", "test8", "test9", "test10", "test11")]
        public void TestValidationMessageOfArrayString(params string[] model)
        {
            var appSettingsMock = Options.Create<AppSettings>(new AppSettings());
            var mappingMock = new Mock<IMapper>();
            var inMemoryServiceMock = new Mock<IInMemoryWorkerService>();
            var gitHubUsersService = new GitHubUsersService(appSettingsMock, mappingMock.Object, inMemoryServiceMock.Object);
            var castStringArrayToList = new List<string>(model);
            var result = gitHubUsersService.ValidateArrayString(castStringArrayToList).IsSuccess;
            Assert.False(result);
        }

        [Theory(DisplayName = "Get Data By User Name")]
        [InlineData("quiters89")]
        public void TestGetDataByUserName(string userName)
        {
            var mockedAppSettings = new AppSettings
            {
                ErrorLogLocation = "D:\\ErrorLog",
                GitHubClientId = "e67b62c814d7d3bd188c",
                GitHubClientSecret = "113c070c1a13688d07067dedef916bfbfe4be07b",
                GitHubUsersUrl = "https://api.github.com/users/"
            };
            ApiHelper.InitializeClient();
            var appSettingsMock = Options.Create<AppSettings>(mockedAppSettings);
            var mappingMock = new Mock<IMapper>();
            var inMemoryServiceMock = new Mock<IInMemoryWorkerService>();
            var gitHubUsersService = new GitHubUsersService(appSettingsMock, mappingMock.Object, inMemoryServiceMock.Object);
            var result = gitHubUsersService.FetchDataFromGitHub(userName).GetAwaiter().GetResult().IsSuccess;
            Assert.True(result);
        }
        

    }
}
