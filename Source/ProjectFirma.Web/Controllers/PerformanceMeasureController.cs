using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Views.PerformanceMeasure.Index;
using IndexGridSpec = ProjectFirma.Web.Views.PerformanceMeasure.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.PerformanceMeasure.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureController : FirmaBaseController
    {
        [PerformanceMeasureViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [AdminReadOnlyViewEverythingFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.PerformanceMeasuresList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasure> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var performanceMeasures = GetPerformanceMeasuresAndGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasure>(performanceMeasures, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasure> GetPerformanceMeasuresAndGridSpec(out IndexGridSpec gridSpec)
        {
            gridSpec = new IndexGridSpec();
            return HttpRequestStorage.DatabaseEntities.PerformanceMeasures.OrderBy(x => x.PerformanceMeasureID).ToList();
        }

        [PerformanceMeasureViewFeature]
        public RedirectResult Summary(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            return
                RedirectToAction(
                    new SitkaRoute<IndicatorController>(
                        x => x.Summary(performanceMeasurePrimaryKey.EntityObject.Indicator.IndicatorName, SummaryViewData.IndicatorSummaryTab.PerformanceMeasure)));
        }

        [PerformanceMeasureViewFeature]
        public ViewResult InfoSheet(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var indicatorChartViewData = new IndicatorChartViewData(performanceMeasure.Indicator, 500, 400, false, ChartViewMode.InfoSheet, null);
            var viewData = new InfoSheetViewData(CurrentPerson, performanceMeasure, indicatorChartViewData);
            return RazorView<InfoSheet, InfoSheetViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        [CrossAreaRoute]
        public GridJsonNetJObjectResult<PerformanceMeasureReportedValue> PerformanceMeasureReportedValuesGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            PerformanceMeasureReportedValuesGridSpec gridSpec;
            var performanceMeasureActuals = GetPerformanceMeasureReportedValuesAndGridSpec(out gridSpec, performanceMeasurePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasureReportedValue>(performanceMeasureActuals, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureReportedValue> GetPerformanceMeasureReportedValuesAndGridSpec(out PerformanceMeasureReportedValuesGridSpec gridSpec, PerformanceMeasure performanceMeasure)
        {
            gridSpec = new PerformanceMeasureReportedValuesGridSpec(performanceMeasure);
            return performanceMeasure.GetReportedPerformanceMeasureValues();
        }

        [PerformanceMeasureViewFeature]
        [CrossAreaRoute]
        public GridJsonNetJObjectResult<PerformanceMeasureExpected> PerformanceMeasureExpectedsGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            PerformanceMeasureExpectedGridSpec gridSpec;
            var performanceMeasureExpecteds = GetPerformanceMeasureExpectedsAndGridSpec(out gridSpec, performanceMeasurePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasureExpected>(performanceMeasureExpecteds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureExpected> GetPerformanceMeasureExpectedsAndGridSpec(out PerformanceMeasureExpectedGridSpec gridSpec,
            PerformanceMeasure performanceMeasure)
        {
            gridSpec = new PerformanceMeasureExpectedGridSpec(performanceMeasure);
            return performanceMeasure.PerformanceMeasureExpecteds.ToList();
        }
    }
}