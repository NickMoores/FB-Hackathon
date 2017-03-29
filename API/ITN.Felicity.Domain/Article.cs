using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain
{
    public class Article
    {
        protected Article() { }

        public Article(Guid id, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            this.Id = id;
            this.Url = url;
            this.LastUpdated = DateTime.Now;
        }

        public Guid Id { get; private set; }
        
        public string Url { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public void UpdateLastUpdated(DateTime lastUpdated)
        {
            if (lastUpdated > this.LastUpdated)
            {
                this.LastUpdated = lastUpdated;
            }
        }

        public Feedback CreateFeedback(Guid installationId, string highlightedText, string comment)
            => Feedback.CreateForArticle(this.Id, installationId, highlightedText, comment);
    }
}
