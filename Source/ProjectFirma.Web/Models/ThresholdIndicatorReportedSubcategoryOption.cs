namespace ProjectFirma.Web.Models
{
    public partial class ThresholdIndicatorReportedSubcategoryOption : IAuditableEntity, IIndicatorReportedSubcategoryOption
    {
        public string AuditDescriptionString
        {
            get { return ThresholdIndicatorReportedSubcategoryOptionID.ToString(); }
        }
    }
}