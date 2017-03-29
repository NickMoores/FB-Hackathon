using ITN.Felicity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITN.Felicity.Domain;

namespace ITN.Felicity.EntityFramework.Repositories
{
    public sealed class ArticleRepository : IArticleRepository
    {
        private readonly FelicityContext dbContext;

        public ArticleRepository(FelicityContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public Task<Article> FindByIdAsync(Guid id) => this.dbContext.Articles.SingleOrDefaultAsync(a => a.Id == id);

        public Task<Article> FindByUrlAsync(string url) => this.dbContext.Articles.SingleOrDefaultAsync(a => a.Url == url);

        public void Add(Article article) => this.dbContext.Articles.Add(article);
    }
}
