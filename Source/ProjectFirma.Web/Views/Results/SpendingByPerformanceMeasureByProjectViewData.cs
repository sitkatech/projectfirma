using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectViewData : FirmaViewData
    {        
        public readonly Models.PerformanceMeasure SelectedPerformanceMeasure;
        public readonly List<Models.PerformanceMeasure> PerformanceMeasures;
        public readonly string SpendingByPerformanceMeasureByProjectUrl;

        public readonly PerformanceMeasureChartViewData PerformanceMeasureChartViewData;
        
        public readonly SpendingByPerformanceMeasureByProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public SpendingByPerformanceMeasureByProjectViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<Models.PerformanceMeasure> performanceMeasures,
            Models.PerformanceMeasure selectedPerformanceMeasure,
            PerformanceMeasureChartViewData performanceMeasureChartViewData) : base(currentPerson, firmaPage, false)
        {
            PageTitle = string.Format("Spending by Project for Selected {0}", MultiTenantHelpers.GetPerformanceMeasureNamePluralized());

            PerformanceMeasures = performanceMeasures;
            SelectedPerformanceMeasure = selectedPerformanceMeasure;
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;

            SpendingByPerformanceMeasureByProjectUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProject(UrlTemplate.Parameter1Int));

            GridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(SelectedPerformanceMeasure)
            {
                ObjectNameSingular = string.Format("record by {0} {1}: {2}", MultiTenantHelpers.GetPerformanceMeasureName(), SelectedPerformanceMeasure.PerformanceMeasureID, SelectedPerformanceMeasure.PerformanceMeasureDisplayName),
                ObjectNamePlural = string.Format("records by {0} {1}: {2}", MultiTenantHelpers.GetPerformanceMeasureName(), SelectedPerformanceMeasure.PerformanceMeasureID, SelectedPerformanceMeasure.PerformanceMeasureDisplayName),
                SaveFiltersInCookie = true
            };

            GridName = "projectFundingSourceExpendituresBySectorGrid";
            GridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProjectGridJsonData(selectedPerformanceMeasure.PerformanceMeasureID));
        }
    }
}