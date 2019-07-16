namespace ProjectFirmaModels.Models
{
    public partial class CostType : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Cost Type: {CostTypeName}";
    }
}