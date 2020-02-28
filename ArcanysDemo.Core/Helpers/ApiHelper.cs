using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ArcanysDemo.Core.Helpers
{
    public static class ApiHelper
    {
        public static HttpRequestMessage ApiClient { get; set; }
        public static void InitializeClient()
        {
            ApiClient = new HttpRequestMessage();
            ApiClient.Headers.Add("User-Agent", "ArcanysDemo");
            ApiClient.Headers.Add("Accept", "*/*");
            ApiClient.Headers.Add("Host", "api.github.com");
        }
    }
    //public static class ApiHelper
    //{
    //    public static HttpClient ApiClient { get; set; }
    //    public static void InitializeClient()
    //    {
    //        ApiClient = new HttpClient();
    //        ApiClient.DefaultRequestHeaders.Accept.Clear();
    //        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        ApiClient.DefaultRequestHeaders.Add("User-Agent", "ArcanysDemo");
    //        ApiClient.DefaultRequestHeaders.Add("Accept", "*/*");
    //        ApiClient.DefaultRequestHeaders.Add("Host", "api.github.com");
    //    }
    //}
}
