namespace ProjectFirmaModels.Models
{
    public partial class OrganizationType : IAuditableEntity
    {
        public string GetAuditDescriptionString() => OrganizationTypeName;
    }
}