namespace ProjectFirma.Web.Models
{
    public partial class IndicatorSubcategoryOption : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return IndicatorSubcategoryOptionName; }
        }

        public string ChartName
        {
            get { return ShortName ?? IndicatorSubcategoryOptionName; }
        }
    }
}