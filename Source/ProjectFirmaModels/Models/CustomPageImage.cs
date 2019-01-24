namespace ProjectFirmaModels.Models
{
    public partial class CustomPageImage : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var customPage = CustomPage;
            var customPageDisplayName = customPage?.CustomPageDisplayName ?? "Unknown";
            return $"Custom About Page Image: {customPageDisplayName}";
        }
    }
}