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

        public ICollection<Feedback> Feedback { get; private set; } = new HashSet<Feedback>(FeedbackComparer.Instance);

        public void UpdateLastUpdated(DateTime lastUpdated)
        {
            if (lastUpdated > this.LastUpdated)
            {
                this.LastUpdated = lastUpdated;
            }
        }

        public void AddFeedback(Guid installationId, string highlightedText, string comment)
        {
            if (highlightedText == null)
            {
                throw new ArgumentNullException(nameof(highlightedText));
            }

            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            this.Feedback.Add(new Domain.Feedback(Guid.NewGuid(), this, installationId, highlightedText, comment));
        }

        public static class Mapping
        {
            public static Expression<Func<Article, ICollection<Feedback>>> Feedback { get; } = a => a.Feedback;
        }
    }
}
