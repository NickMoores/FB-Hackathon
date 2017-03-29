using ITN.Felicity.Api.Models;
using ITN.Felicity.Domain.Repositories;
using ITN.Felicity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ITN.Felicity.Api.Controllers
{
    public class FeedbackController : ApiController
    {
        private readonly IArticleRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        public FeedbackController(IArticleRepository repo, IUnitOfWork unitOfWork)
        {
            this._repo = repo;
            this._unitOfWork = unitOfWork;
        }

        // POST: api/Feedback
        public async Task Post([FromBody] FeedbackModel fm)
        {
            var article = await _repo.FindByUrlAsync(fm.ArticleURL);
            if (article == null)
            {
                article = new Domain.Article(Guid.NewGuid(), fm.ArticleURL);
                this._repo.Add(article);
            }
            
            article.AddFeedback(fm.Feedback);
            await this._unitOfWork.SaveChangesAsync();
        }

    }
}
