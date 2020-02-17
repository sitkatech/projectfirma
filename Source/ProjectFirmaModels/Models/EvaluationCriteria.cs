using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class EvaluationCriteria : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationCriteriaName;

        public bool CanDelete()
        {
            return !EvaluationCriteriaValues.Any(x => x.ProjectEvaluationSelectedValues.Any());
        }

    }
}