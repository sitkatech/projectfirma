using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class Evaluation : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationName;

        public bool CanDelete()
        {
            //todo: TK 12/30/2019 This needs to check for ProjectEvaluations(object not created yet). Temporarily checking for EvaluationCriterion
            return !EvaluationCriterions.Any();
        }

    }
}