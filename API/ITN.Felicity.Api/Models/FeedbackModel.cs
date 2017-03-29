using ITN.Felicity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITN.Felicity.Api.Models
{
    public class FeedbackModel
    {
        public string ArticleURL { get; set; }
        public Feedback Feedback { get; set; }
    }
}