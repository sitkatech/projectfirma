using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class Evaluation : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationName;

        public bool CanDelete()
        {
            return !ProjectEvaluations.Any(x => x.ProjectEvaluationSelectedValues.Any());
        }

    }
}