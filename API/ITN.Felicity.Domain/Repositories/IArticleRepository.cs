using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain.Repositories
{
    public interface IArticleRepository
    {
        Task<Article> FindByIdAsync(Guid id);

        Task<Article> FindByUrlAsync(string url);

        void Add(Article article);

        Task<List<Article>> Get();
    }
}
