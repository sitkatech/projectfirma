namespace ProjectFirmaModels.Models
{
    public partial class ProjectExemptReportingYearUpdate : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectUpdateBatch: {ProjectUpdateBatchID}, Calendar Year: {CalendarYear}";
        }
    }
}