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
    [RoutePrefix("article/{articleId:guid}")]
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
        [Route("feedback")]
        public async Task<IHttpActionResult> Post([FromUri]Guid articleId, [FromBody]FeedbackModel fm)
        {
            var article = await _repo.FindByIdAsync(articleId);

            if (article == null)
            {
                return NotFound();
            }

            article.AddFeedback(fm.InstallationId, fm.HighlightedText, fm.Comment);
            await this._unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
