using ITN.Felicity.Api.Models;
using ITN.Felicity.Domain.Repositories;
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
        public FeedbackController(IArticleRepository repo)
        {
            this._repo = repo;
        }

        // POST: api/Feedback
        public async Task Post([FromBody] FeedbackModel fm)
        {
            var article = await _repo.FindByUrlAsync(fm.ArticleURL);
            if (article == null)
                article = new Domain.Article(Guid.NewGuid(), fm.ArticleURL);
            article.AddFeedback(fm.Feedback);
        }

    }
}
