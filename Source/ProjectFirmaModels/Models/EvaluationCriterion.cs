using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class EvaluationCriterion : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationCriterionName;

        public bool CanDelete()
        {
            return !EvaluationCriterionValues.Any(x => x.ProjectEvaluationSelectedValues.Any());
        }

    }
}