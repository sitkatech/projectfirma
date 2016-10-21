using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Aspect
{
    public class SummaryViewData : SustainabilityDashboardViewData
    {
        public readonly SustainabilityAspect SustainabilityAspect;
        public readonly Dictionary<int, IndicatorChartViewData> IndicatorChartViewDataDictionary;

        public SummaryViewData(Person currentPerson,
            SustainabilityAspect sustainabilityAspect,
            SustainabilityCommonPageData sustainabilityCommonPageData,
            string editUrl,
            bool isEditButtonVisible) : base(currentPerson, sustainabilityCommonPageData, "detail-header")
        {
            SustainabilityAspect = sustainabilityAspect;
            EditUrl = editUrl;
            IsEditButtonVisible = isEditButtonVisible;
            PageTitle = sustainabilityAspect.DisplayName;

            const int width = 600;
            const int height = 350;

            IndicatorChartViewDataDictionary = sustainabilityAspect.SustainabilityIndicators.Select(x => x.Indicator)
                .ToDictionary(x => x.IndicatorID, x => new IndicatorChartViewData(x, width, height, false, ChartViewMode.Small, null));
        }
    }
}