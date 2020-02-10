namespace ProjectFirmaModels.Models
{
    public partial class ProjectEvaluationSelectedValue : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"ProjectEvaluationSelectedValueID: {ProjectEvaluationSelectedValueID}, ProjectEvaluationID: {ProjectEvaluationID}, EvaluationCriteriaValueID: {EvaluationCriteriaValueID}";

    }
}