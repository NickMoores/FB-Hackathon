using ITN.Felicity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITN.Felicity.Domain;
using System.Threading.Tasks;

namespace ITN.Felicity.Api.Repository
{
    public class ArticleRepository_Mock : IArticleRepository
    {
        public void Add(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<Article> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> FindByUrlAsync(string url)
        {
            throw new NotImplementedException();
        }
    }
}