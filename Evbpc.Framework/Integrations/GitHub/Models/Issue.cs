﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.GitHub.Models
{
    [DataContract]
    public class Issue
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "labels_url")]
        public string LabelsUrl { get; set; }

        [DataMember(Name = "comments_url")]
        public string CommentsUrl { get; set; }

        [DataMember(Name = "events_url")]
        public string EventsUrl { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "user")]
        public Sender User { get; set; }

        [DataMember(Name = "labels")]
        public List<Label> Labels { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "locked")]
        public bool Locked { get; set; }

        [DataMember(Name = "assignee")]
        public object Assignee { get; set; }

        [DataMember(Name = "milestone")]
        public object Milestone { get; set; }

        [DataMember(Name = "comments")]
        public int Comments { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "closed_at")]
        public string ClosedAt { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
}
