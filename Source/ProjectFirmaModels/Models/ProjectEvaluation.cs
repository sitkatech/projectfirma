using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectEvaluation : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"ProjectEvaluationID: {ProjectEvaluationID}, ProjectID: {ProjectID}, EvaluationID: {EvaluationID}";

        public bool CanDelete()
        {
            //todo: TK 12/30/2019 This needs to check for ProjectEvaluations(object not created yet). Temporarily checking for EvaluationCriterionValues
            return !ProjectEvaluationSelectedValues.Any();
        }
    }
    public partial class ProjectEvaluationSelectedValue : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"ProjectEvaluationSelectedValueID: {ProjectEvaluationSelectedValueID}, ProjectEvaluationID: {ProjectEvaluationID}, EvaluationCriterionValueID: {EvaluationCriterionValueID}";

    }
}