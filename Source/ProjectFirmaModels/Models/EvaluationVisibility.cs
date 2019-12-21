namespace ProjectFirmaModels.Models
{
    public partial class EvaluationVisibility : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationVisibilityDisplayName;

    }
}