using ITN.Felicity.Api.Models;
using ITN.Felicity.Domain;
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
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackController(IArticleRepository repo, IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            this._repo = repo;
            this.feedbackRepository = feedbackRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet, Route("feedback/{feedbackId:Guid}", Name = "GetFeedback")]
        public async Task<IHttpActionResult> Get(Guid articleId, Guid feedbackId)
        {
            Feedback feedback = await this.feedbackRepository.FindFeedbackByIdAsync(articleId, feedbackId);
            
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // POST: api/Feedback
        [HttpPost, Route("feedback")]
        public async Task<IHttpActionResult> Post([FromUri]Guid articleId, [FromBody]FeedbackModel fm)
        {
            var article = await _repo.FindByIdAsync(articleId);

            if (article == null)
            {
                return NotFound();
            }

            Feedback feedback = article.CreateFeedback(fm.InstallationId, fm.HighlightedText, fm.Comment);
            this.feedbackRepository.Add(feedback);

            await this._unitOfWork.SaveChangesAsync();

            return CreatedAtRoute("GetFeedback", new { articleId = articleId, feedbackId = feedback.Id }, feedback);
        }

        // PUT: api/Feedback
        [HttpPut, Route("feedback/")]
        public async Task<IHttpActionResult> Put([FromUri]Guid articleId, [FromUri]Guid feedbackId, [FromBody]FeedbackModel fm)
        {
            Feedback feedback = await this.feedbackRepository.FindFeedbackByIdAsync(articleId, feedbackId);

            if (feedback == null)
            {
                return NotFound();
            }

            feedback.UpdateComment(fm.Comment);
            await this._unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
