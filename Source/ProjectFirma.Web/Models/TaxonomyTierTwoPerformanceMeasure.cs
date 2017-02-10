using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyTierTwoPerformanceMeasure : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var program = HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwos.Find(TaxonomyTierTwoID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Find(PerformanceMeasureID);
                var projectName = program != null ? program.AuditDescriptionString : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("TaxonomyTierTwo: {0}, Performance Measure: {1}", projectName, performanceMeasureName);
            }
        }
    }
}