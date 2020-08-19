namespace ProjectFirmaModels.Models
{
    public partial class CustomPageRole : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Custom Page ID: {CustomPageID}, Role ID: {RoleID}";
    }
}