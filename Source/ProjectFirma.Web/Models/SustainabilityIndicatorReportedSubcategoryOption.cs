namespace ProjectFirma.Web.Models
{
    public partial class SustainabilityIndicatorReportedSubcategoryOption : IAuditableEntity, IIndicatorReportedSubcategoryOption
    {
        public string AuditDescriptionString
        {
            get { return SustainabilityIndicatorReportedSubcategoryOptionID.ToString(); }
        }
    }
}