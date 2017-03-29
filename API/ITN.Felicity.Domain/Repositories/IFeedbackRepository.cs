using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> FindFeedbackByArticleId(Guid articleId);

        Task<Feedback> FindFeedbackByIdAsync(Guid articleId, Guid feedbackId);

        void Add(Feedback feedback);
    }
}
