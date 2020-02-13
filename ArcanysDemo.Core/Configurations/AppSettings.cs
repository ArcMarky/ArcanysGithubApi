using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.Configurations
{
    public class AppSettings
    {
        /// <summary>
        /// The configration for the github client
        /// </summary>
        public string GitHubClientId { get; set; }
        public string GitHubClientSecret { get; set; }
        public string GitHubUsersUrl { get; set; }

        /// <summary>
        /// The location of the log file to be generated
        /// </summary>
        public string ErrorLogLocation { get; set; }

    }
}
