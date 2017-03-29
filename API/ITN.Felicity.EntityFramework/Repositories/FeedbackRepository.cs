using ITN.Felicity.Domain.Repositories;
using ITN.Felicity.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITN.Felicity.Domain;
using System.Data.Entity;

namespace ITN.Felicity.EntityFramework.Repositories
{
    public sealed class FeedbackRepository : IFeedbackRepository
    {
        private readonly FelicityContext dbContext;

        public FeedbackRepository(FelicityContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Feedback>> FindFeedbackByArticleId(Guid articleId)
            => await this.dbContext.Feedback.Where(f => f.ArticleId == articleId).ToListAsync();

        public Task<Feedback> FindFeedbackByIdAsync(Guid articleId, Guid feedbackId)
            => this.dbContext.Feedback.SingleOrDefaultAsync(f => f.ArticleId == articleId && f.Id == feedbackId);

        public void Add(Feedback feedback) => this.dbContext.Feedback.Add(feedback);
    }
}
