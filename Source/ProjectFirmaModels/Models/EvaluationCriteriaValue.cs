namespace ProjectFirmaModels.Models
{
    public partial class EvaluationCriteriaValue : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"{EvaluationCriteriaValueRating} - {EvaluationCriteriaValueDescription}";


    }
}