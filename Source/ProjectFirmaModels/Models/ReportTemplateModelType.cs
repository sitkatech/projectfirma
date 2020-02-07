namespace ProjectFirmaModels.Models
{
    public partial class ReportTemplateModelType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReportTemplateModelTypeID: {ReportTemplateModelTypeID}, ReportTemplateModelTypeName: {ReportTemplateModelTypeName}";
        }
    }
}