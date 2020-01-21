using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectEvaluation : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"ProjectEvaluationID: {ProjectEvaluationID}, ProjectID: {ProjectID}, EvaluationID: {EvaluationID}";

        public bool CanDelete()
        {
            return !ProjectEvaluationSelectedValues.Any();
        }
    }
}