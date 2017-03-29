using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain
{
    public class Article
    {
        public Article(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            this.Url = url;
        }
        
        public string Url { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public ICollection<Feedback> Feedback { get; private set; } = new List<Feedback>();

        public void UpdateLastUpdated(DateTime lastUpdated)
        {
            if (lastUpdated > this.LastUpdated)
            {
                this.LastUpdated = lastUpdated;
            }
        }
    }
}
