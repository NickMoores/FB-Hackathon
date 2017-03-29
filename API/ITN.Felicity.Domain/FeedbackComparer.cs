using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain
{
    /// <summary>
    /// Compares a Feedback's installationID and highlightedText for equality.
    /// </summary>
    internal sealed class FeedbackComparer : EqualityComparer<Feedback>
    {
        private FeedbackComparer() { }

        public override bool Equals(Feedback x, Feedback y) => x.InstallationId == y.InstallationId && x.HighlightedText.Equals(y.HighlightedText);

        public override int GetHashCode(Feedback obj)
        {
            int hashCode = obj.InstallationId.GetHashCode();

            return (hashCode * 23) + obj.HighlightedText.GetHashCode();
        }

        public static FeedbackComparer Instance { get; } = new FeedbackComparer();
    }
}
