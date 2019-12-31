using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class EvaluationCriterion : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationCriterionName;

        public bool CanDelete()
        {
            //todo: TK 12/30/2019 This needs to check for ProjectEvaluations(object not created yet). Temporarily checking for EvaluationCriterionValues
            return !EvaluationCriterionValues.Any();
        }

    }
}