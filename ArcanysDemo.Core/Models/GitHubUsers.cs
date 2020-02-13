using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.Models
{
    public class GitHubUsers
    {
        public string Login { get; set; }
        public long Id { get; set; }
        [JsonProperty("node_id", NullValueHandling = NullValueHandling.Ignore)]
        public string NodeId { get; set; }
        [JsonProperty("avatar_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUrl { get; set; }
        [JsonProperty("gravatar_id", NullValueHandling = NullValueHandling.Ignore)]
        public string GravatarId { get; set; }
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
        [JsonProperty("html_url", NullValueHandling = NullValueHandling.Ignore)]
        public string HtmlUrl { get; set; }
        [JsonProperty("followers_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FollowersUrl { get; set; }
        [JsonProperty("following_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FollowingUrl { get; set; }
        [JsonProperty("gists_url", NullValueHandling = NullValueHandling.Ignore)]
        public string GistsUrl { get; set; }
        [JsonProperty("starred_url", NullValueHandling = NullValueHandling.Ignore)]
        public string StarredUrl { get; set; }
        [JsonProperty("subscriptions_url", NullValueHandling = NullValueHandling.Ignore)]
        public string SubscriptionsUrl { get; set; }
        [JsonProperty("organizations_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OrganizationsUrl { get; set; }
        [JsonProperty("repos_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ReposUrl { get; set; }
        [JsonProperty("events_url", NullValueHandling = NullValueHandling.Ignore)]
        public string EventsUrl { get; set; }
        [JsonProperty("received_events_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceivedEventsUrl { get; set; }
        public string Type { get; set; }
        [JsonProperty("site_admin", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteAdmin { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Blog { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public bool? Hireable { get; set; }
        public string Bio { get; set; }
        [JsonProperty("public_repos", NullValueHandling = NullValueHandling.Ignore)]
        public int PublicRepos { get; set; }
        [JsonProperty("public_gists", NullValueHandling = NullValueHandling.Ignore)]
        public int PublicGists { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }

    }
}
