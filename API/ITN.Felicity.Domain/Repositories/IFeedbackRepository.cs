using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain.Repositories
{
    public interface IFeedbackRepository
    {
        Task<Feedback> FindFeedbackByIdAsync(Guid articleId, Guid feedbackId);

        void Add(Feedback feedback);
    }
}
