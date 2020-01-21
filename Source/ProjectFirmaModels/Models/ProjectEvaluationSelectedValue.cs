namespace ProjectFirmaModels.Models
{
    public partial class ProjectEvaluationSelectedValue : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"ProjectEvaluationSelectedValueID: {ProjectEvaluationSelectedValueID}, ProjectEvaluationID: {ProjectEvaluationID}, EvaluationCriterionValueID: {EvaluationCriterionValueID}";

    }
}