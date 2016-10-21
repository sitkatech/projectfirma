using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Sustainability.Views
{
    public abstract class SustainabilityDashboardViewData : LakeTahoeInfoBaseViewData
    {
        public readonly SustainabilityCommonPageData SustainabilityCommonPageData;
        public readonly string HeaderClass;
        public readonly string FooterAdditionalClass;
        public readonly int SustainabilityIndicatorCount;

        public bool IsEditButtonVisible;
        public string EditUrl;

        protected SustainabilityDashboardViewData(Person currentPerson, SustainabilityCommonPageData sustainabilityCommonPageData) : this(currentPerson, sustainabilityCommonPageData, null, null)
        {
        }

        protected SustainabilityDashboardViewData(Person currentPerson, SustainabilityCommonPageData sustainabilityCommonPageData, string headerClass)
            : this(currentPerson, sustainabilityCommonPageData, headerClass, "secondary-footer")
        {
        }

        /// <summary>
        /// This should only be used by login page to hide the Login link
        /// </summary>
        protected SustainabilityDashboardViewData(Person currentPerson, SustainabilityCommonPageData sustainabilityCommonPageData, string headerClass, string footerAdditionalClass)
            : base(currentPerson, LTInfoArea.Sustainability)
        {
            SustainabilityCommonPageData = sustainabilityCommonPageData;
            SustainabilityIndicatorCount = SustainabilityCommonPageData.SustainabilityPillars.Sum(x => x.SustainabilityAspects.Sum(y => y.SustainabilityIndicators.Count));
            HeaderClass = headerClass;
            FooterAdditionalClass = footerAdditionalClass;
        }
    }
}