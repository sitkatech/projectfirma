using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditIndicatorReportedsViewData : LakeTahoeInfoUserControlViewData
    {        
        public readonly Models.Indicator Indicator;
        public readonly List<IndicatorTargetValueType> IndicatorTargetValueTypes;
        public readonly EditIndicatorReportedsViewDataForAngular ViewDataForAngular;

        public EditIndicatorReportedsViewData(Models.Indicator indicator, EditIndicatorReportedsViewDataForAngular viewDataForAngular, List<IndicatorTargetValueType> indicatorTargetValueTypes)
        {
            Indicator = indicator;
            ViewDataForAngular = viewDataForAngular;
            IndicatorTargetValueTypes = indicatorTargetValueTypes;
        }
    }

    public class EditIndicatorReportedsViewDataForAngular
    {
        public readonly int? IndicatorSubcategoryID;
        public readonly int DefaultReportingPeriodYear;
        public readonly Dictionary<string, int> IndicatorTargetValueTypes;
        public List<ReportingCategoryForDisplay> ReportingCategoriesForDisplay;

        public EditIndicatorReportedsViewDataForAngular(Models.Indicator indicator, int defaultReportingPeriodYear, Dictionary<string, int> indicatorTargetValueTypes)
        {
            IndicatorTargetValueTypes = indicatorTargetValueTypes;
            DefaultReportingPeriodYear = defaultReportingPeriodYear;
            if (indicator.IndicatorSubcategories.Any())
            {
                var indicatorSubcategory = indicator.IndicatorSubcategories.Single();
                ReportingCategoriesForDisplay = indicatorSubcategory.IndicatorSubcategoryOptions.Select(x => new ReportingCategoryForDisplay(x)).ToList();
                IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            }
            else
            {
                ReportingCategoriesForDisplay = new List<ReportingCategoryForDisplay>() {new ReportingCategoryForDisplay(indicator)};
            }
        }
    }
}