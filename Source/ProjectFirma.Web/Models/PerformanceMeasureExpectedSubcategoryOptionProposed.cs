using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureExpectedSubcategoryOptionProposed : IAuditableEntity, IPerformanceMeasureValueSubcategoryOption
    {
        public string AuditDescriptionString
        {
            get
            {
                var performanceMeasureSubcategoryOption = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategoryOptions.Find(PerformanceMeasureSubcategoryOptionID);
                var performanceMeasureSubcategory = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategories.Find(PerformanceMeasureSubcategoryID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Find(PerformanceMeasureID);
                var performanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOption != null ? performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : ViewUtilities.NotFoundString;
                var performanceMeasureSubcategoryName = performanceMeasureSubcategory != null ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.PerformanceMeasureDisplayName : ViewUtilities.NotFoundString;
                return string.Format("Performance Measure: {0}, Subcategory: {1}, Subcategory Option: {2}", performanceMeasureName, performanceMeasureSubcategoryName, performanceMeasureSubcategoryOptionName);
            }
        }
    }
}