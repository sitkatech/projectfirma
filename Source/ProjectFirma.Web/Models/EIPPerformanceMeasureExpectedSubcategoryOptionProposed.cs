using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class EIPPerformanceMeasureExpectedSubcategoryOptionProposed : IAuditableEntity, IEIPPerformanceMeasureValueSubcategoryOption
    {
        public string AuditDescriptionString
        {
            get
            {
                var indicatorSubcategoryOption = HttpRequestStorage.DatabaseEntities.IndicatorSubcategoryOptions.Find(IndicatorSubcategoryOptionID);
                var indicatorSubcategory = HttpRequestStorage.DatabaseEntities.IndicatorSubcategories.Find(IndicatorSubcategoryID);
                var eipPerformanceMeasure = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.Find(EIPPerformanceMeasureID);
                var indicatorSubcategoryOptionName = indicatorSubcategoryOption != null ? indicatorSubcategoryOption.IndicatorSubcategoryOptionName : ViewUtilities.NotFoundString;
                var indicatorSubcategoryName = indicatorSubcategory != null ? indicatorSubcategory.IndicatorSubcategoryDisplayName : ViewUtilities.NotFoundString;
                var eipPerformanceMeasureName = eipPerformanceMeasure != null ? eipPerformanceMeasure.DisplayName : ViewUtilities.NotFoundString;
                return string.Format("Performance Measure: {0}, Subcategory: {1}, Subcategory Option: {2}", eipPerformanceMeasureName, indicatorSubcategoryName, indicatorSubcategoryOptionName);
            }
        }
    }
}