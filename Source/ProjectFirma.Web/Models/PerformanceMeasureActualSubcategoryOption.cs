using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureActualSubcategoryOption : IAuditableEntity, IPerformanceMeasureValueSubcategoryOption
    {
        public string AuditDescriptionString
        {
            get
            {
                var indicatorSubcategoryOption = HttpRequestStorage.DatabaseEntities.IndicatorSubcategoryOptions.Find(IndicatorSubcategoryOptionID);
                var indicatorSubcategory = HttpRequestStorage.DatabaseEntities.IndicatorSubcategories.Find(IndicatorSubcategoryID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Find(PerformanceMeasureID);
                var indicatorSubcategoryOptionName = indicatorSubcategoryOption != null ? indicatorSubcategoryOption.IndicatorSubcategoryOptionName : ViewUtilities.NotFoundString;
                var indicatorSubcategoryName = indicatorSubcategory != null ? indicatorSubcategory.IndicatorSubcategoryDisplayName : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.DisplayName : ViewUtilities.NotFoundString;
                return string.Format("Performance Measure: {0}, IndicatorSubcategory: {1}, IndicatorSubcategory Option: {2}", performanceMeasureName, indicatorSubcategoryName, indicatorSubcategoryOptionName);
            }
        }
    }
}