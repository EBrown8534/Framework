using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Integrations.StackExchange.API.Models
{
    [DataContract]
    public class OriginalQuestion : IBaseModel
    {
        [DataMember(Name = "accepted_answer_id")]
        public int? AcceptedAnswerId { get; set; }

        [DataMember(Name = "answer_count")]
        public int? AnswerCount { get; set; }

        [DataMember(Name = "question_id")]
        public int? QuestionId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}
