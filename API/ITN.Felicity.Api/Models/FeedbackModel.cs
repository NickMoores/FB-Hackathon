using ITN.Felicity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITN.Felicity.Api.Models
{
    public class FeedbackModel
    {
        public Guid InstallationId { get; set; }

        public string HighlightedText { get; set; }

        public string Comment { get; set; }
    }
}