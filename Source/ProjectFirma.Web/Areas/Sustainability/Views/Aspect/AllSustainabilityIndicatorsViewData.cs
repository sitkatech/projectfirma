using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Aspect
{
    public class AllSustainabilityIndicatorsViewData : SustainabilityDashboardViewData
    {
        public AllSustainabilityIndicatorsViewData(Person currentPerson, SustainabilityCommonPageData sustainabilityCommonPageData)
            : base(currentPerson, sustainabilityCommonPageData, "all-indicators-header", null)
        {
            PageTitle = "Indicators";
        }
    }
}