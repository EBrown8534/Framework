﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Sender
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        [DataMember(Name = "gravatar_id")]
        public string GravatarId { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }

        [DataMember(Name = "followers_url")]
        public string FollowersUrl { get; set; }

        [DataMember(Name = "following_url")]
        public string FollowingUrl { get; set; }

        [DataMember(Name = "gists_url")]
        public string GistsUrl { get; set; }

        [DataMember(Name = "starred_url")]
        public string StarredUrl { get; set; }

        [DataMember(Name = "subscriptions_url")]
        public string SubscriptionsUrl { get; set; }

        [DataMember(Name = "organizations_url")]
        public string OrganizationsUrl { get; set; }

        [DataMember(Name = "repos_url")]
        public string ReposUrl { get; set; }

        [DataMember(Name = "events_url")]
        public string EventsUrl { get; set; }

        [DataMember(Name = "receive_events_url")]
        public string ReceiveEventsUrl { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "site_admin")]
        public bool SiteAdmin { get; set; }
    }
}
