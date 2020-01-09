namespace ProjectFirmaModels.Models
{
    public partial class ReportTemplateModel : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReportTemplateModelID: {ReportTemplateModelID}, ReportTemplateModelName: {ReportTemplateModelName}";
        }
    }
}