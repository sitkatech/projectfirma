namespace ProjectFirmaModels.Models
{
    public partial class EvaluationCriterion : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationCriterionName;

    }
}