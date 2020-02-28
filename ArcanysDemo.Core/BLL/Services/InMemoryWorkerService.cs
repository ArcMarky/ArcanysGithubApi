using ArcanysDemo.Core.BLL.Interfaces;
using ArcanysDemo.Core.Helpers;
using ArcanysDemo.Core.ViewModel;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.BLL.Services
{
    public class InMemoryWorkerService : IInMemoryWorkerService
    {
        private readonly IMemoryCache _memoryCache;
        public InMemoryWorkerService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Stored the data in memory
        /// </summary>
        /// <param name="model">model to be stored</param>
        /// <param name="cacheName">name of the cache</param>
        /// <returns>response object</returns>
        public ResponseObject StoreDataInMemory(dynamic model, string cacheName)
        {
            var response = new ResponseObject(ResponseType.Success, string.Empty);
            string modelToCache = JsonConvert.SerializeObject(model);
            _memoryCache.Set<string>(cacheName, modelToCache, TimeSpan.FromMinutes(2));
            return response;
        }

        /// <summary>
        /// Fetches data from memory
        /// </summary>
        /// <param name="cacheName">name of the cache</param>
        /// <returns>response object</returns>
        public ResponseObject GetDataInMemory(string cacheName)
        {
            var response = new ResponseObject(ResponseType.Success, string.Empty);
            if (_memoryCache.TryGetValue<string>(cacheName, out string cacheValue))
            {
                response.Data = JsonConvert.DeserializeObject<GitHubUsersDto>(cacheValue);
            }
            else
            {
                response = new ResponseObject(ResponseType.Undefined, string.Empty);
            }
            return response;
        }

    }
}
