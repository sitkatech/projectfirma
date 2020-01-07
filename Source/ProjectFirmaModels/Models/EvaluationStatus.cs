namespace ProjectFirmaModels.Models
{
    public partial class EvaluationStatus : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationStatusDisplayName;

    }
}