namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureSubcategoryOption : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return PerformanceMeasureSubcategoryOptionName; }
        }

        public string ChartName
        {
            get { return ShortName ?? PerformanceMeasureSubcategoryOptionName; }
        }
    }
}