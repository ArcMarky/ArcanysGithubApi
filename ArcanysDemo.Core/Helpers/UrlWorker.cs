using ArcanysDemo.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.Helpers
{
    public class UrlWorker
    {
        /// <summary>
        /// Constructs the url to be accessed.
        /// </summary>
        /// <param name="url">Base url</param>
        /// <param name="clientId">client id of the app</param>
        /// <param name="ClientSecretKey">secret key of the app</param>
        /// <param name="parameter">endpoint to be accessed</param>
        /// <returns>constructed github url</returns>
        public static string GitHubUrlConstructor(string url,string clientId,string ClientSecretKey,string parameter)
        {
            try
            {
                return url + parameter + "?client_id=" + clientId + "&client_secret=" + ClientSecretKey;
            }
            catch (Exception e)
            {
                ErrorHandling.LogError(e, Enums.Severity.Error);
            }
            return "";
        }
    }
}
