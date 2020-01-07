namespace ProjectFirmaModels.Models
{
    public partial class EvaluationCriterionValue : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"{EvaluationCriterionValueRating} - {EvaluationCriterionValueDescription}";


    }
}