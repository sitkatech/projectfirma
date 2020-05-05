namespace ProjectFirmaModels.Models
{
    public partial class TenantAttribute : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return "Tenant Attribute updated";
        }

    }
}