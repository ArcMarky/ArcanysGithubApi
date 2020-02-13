using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.ViewModel
{
    public class GitHubUsersDto
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Name { get; set; }
        public string Login { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Company { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public long Followers { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public long PublicRepos { get; set; }
    }
}
