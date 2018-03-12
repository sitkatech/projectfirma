namespace ProjectFirma.Web.Models
{
    public partial class CustomPageImage : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var customPage = CustomPage;
                var customPageDisplayName = customPage?.CustomPageDisplayName ?? "Unknown";
                return $"Custom About Page Image: {customPageDisplayName}";
            }
        }
    }
}