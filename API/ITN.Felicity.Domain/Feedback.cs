using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain
{
    public class Feedback
    {
        protected Feedback() { }

        private Feedback(Guid id, Guid articleId, Guid installationId, string highlightedText, string comment)
        {
            this.Id = id;
            this.ArticleId = articleId;
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

        internal static Feedback CreateForArticle(Guid articleId, Guid installationId, string highlightedText, string comment)
        {
            if (highlightedText == null)
            {
                throw new ArgumentNullException(nameof(highlightedText));
            }

            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            return new Feedback(Guid.NewGuid(), articleId, installationId, highlightedText, comment);
        }
    }
}
