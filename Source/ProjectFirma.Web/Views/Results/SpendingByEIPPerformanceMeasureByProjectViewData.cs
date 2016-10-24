using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByEIPPerformanceMeasureByProjectViewData : EIPViewData
    {        
        public readonly Models.EIPPerformanceMeasure SelectedEIPPerformanceMeasure;
        public readonly List<Models.EIPPerformanceMeasure> EIPPerformanceMeasures;
        public readonly string SpendingByEIPPerformanceMeasureByProjectUrl;

        public readonly IndicatorChartViewData IndicatorChartViewData;
        
        public readonly SpendingByEIPPerformanceMeasureByProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public SpendingByEIPPerformanceMeasureByProjectViewData(Person currentPerson,
            Models.ProjectFirmaPage projectFirmaPage,
            List<Models.EIPPerformanceMeasure> eipPerformanceMeasures,
            Models.EIPPerformanceMeasure selectedEIPPerformanceMeasure,
            IndicatorChartViewData indicatorChartViewData) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Spending by Project for Selected Performance Measure";

            EIPPerformanceMeasures = eipPerformanceMeasures;
            SelectedEIPPerformanceMeasure = selectedEIPPerformanceMeasure;
            IndicatorChartViewData = indicatorChartViewData;

            SpendingByEIPPerformanceMeasureByProjectUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByEIPPerformanceMeasureByProject(UrlTemplate.Parameter1Int));

            GridSpec = new SpendingByEIPPerformanceMeasureByProjectGridSpec(SelectedEIPPerformanceMeasure)
            {
                ObjectNameSingular = string.Format("record by PM {0}: {1}", SelectedEIPPerformanceMeasure.EIPPerformanceMeasureTypeID, SelectedEIPPerformanceMeasure.DisplayNameNoNumber),
                ObjectNamePlural = string.Format("records by PM {0}: {1}", SelectedEIPPerformanceMeasure.EIPPerformanceMeasureID, SelectedEIPPerformanceMeasure.DisplayNameNoNumber),
                SaveFiltersInCookie = true
            };

            GridName = "projectFundingSourceExpendituresBySectorGrid";
            GridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByEIPPerformanceMeasureByProjectGridJsonData(selectedEIPPerformanceMeasure.EIPPerformanceMeasureID));
        }
    }
}