namespace ProjectFirmaModels.Models
{
    public partial class FirmaHomePageImage : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Image: {Caption}";
    }
}