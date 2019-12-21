namespace ProjectFirmaModels.Models
{
    public partial class Evaluation : IAuditableEntity
    {
        public string GetAuditDescriptionString() => EvaluationName;

    }
}