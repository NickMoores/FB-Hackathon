using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain
{
    public class Feedback
    {
        public Feedback(Guid id, Article article, Guid installationId, string highlightedText, string comment)
        {
            this.InstallationId = installationId;
            this.HighlightedText = highlightedText;
            this.Comment = comment;
        }

        public Guid Id { get; private set; }

        public Guid ArticleId { get; private set; }

        public Guid InstallationId { get; private set; }

        public string HighlightedText { get; private set; }

        public string Comment { get; private set; }

        public void UpdateComment(string comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            this.Comment = comment;
        }
    }
}
