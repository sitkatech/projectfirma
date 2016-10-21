using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Aspect
{
    public class EditViewData : SustainabilityDashboardViewData
    {
        public readonly SustainabilityAspect SustainabilityAspect;        
        public readonly Dictionary<int, IndicatorChartViewData> IndicatorChartViewDataDictionary;

        public readonly string CancelUrl;

        public EditViewData(Person currentPerson, SustainabilityAspect sustainabilityAspect, SustainabilityCommonPageData sustainabilityCommonPageData, string cancelUrl)
            : base(currentPerson, sustainabilityCommonPageData, "detail-header")
        {
            PageTitle = sustainabilityAspect.DisplayName;
            SustainabilityAspect = sustainabilityAspect;
            CancelUrl = cancelUrl;            

            const int width = 600;
            const int height = 350;

            IndicatorChartViewDataDictionary = sustainabilityAspect.SustainabilityIndicators.Select(x => x.Indicator)
                .ToDictionary(x => x.IndicatorID, x => new IndicatorChartViewData(x, width, height, false, ChartViewMode.Small, null));
        }       
    }
}