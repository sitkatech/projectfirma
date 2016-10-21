using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasure;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasure.Index;
using IndexGridSpec = ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasure.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasure.IndexViewData;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class EIPPerformanceMeasureController : LakeTahoeInfoBaseController
    {
        [EIPPerformanceMeasureViewFeature]
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
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.EIPPerformanceMeasuresList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [EIPPerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<EIPPerformanceMeasure> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var eipPerformanceMeasures = GetEIPPerformanceMeasuresAndGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<EIPPerformanceMeasure>(eipPerformanceMeasures, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<EIPPerformanceMeasure> GetEIPPerformanceMeasuresAndGridSpec(out IndexGridSpec gridSpec)
        {
            gridSpec = new IndexGridSpec();
            return HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.OrderBy(x => x.EIPPerformanceMeasureID).ToList();
        }

        [EIPPerformanceMeasureViewFeature]
        public RedirectResult Summary(EIPPerformanceMeasurePrimaryKey eipPerformanceMeasurePrimaryKey)
        {
            return
                RedirectToAction(
                    new SitkaRoute<IndicatorController>(
                        x => x.Summary(eipPerformanceMeasurePrimaryKey.EntityObject.Indicator.IndicatorName, Web.Views.Indicator.SummaryViewData.IndicatorSummaryTab.EIP)));
        }

        [EIPPerformanceMeasureViewFeature]
        public ViewResult InfoSheet(EIPPerformanceMeasurePrimaryKey eipPerformanceMeasurePrimaryKey)
        {
            var eipPerformanceMeasure = eipPerformanceMeasurePrimaryKey.EntityObject;
            var indicatorChartViewData = new IndicatorChartViewData(eipPerformanceMeasure.Indicator, 500, 400, false, ChartViewMode.InfoSheet, null);
            var viewData = new InfoSheetViewData(CurrentPerson, eipPerformanceMeasure, indicatorChartViewData);
            return RazorView<InfoSheet, InfoSheetViewData>(viewData);
        }

        [EIPPerformanceMeasureViewFeature]
        [CrossAreaRoute]
        public GridJsonNetJObjectResult<EIPPerformanceMeasureReportedValue> EIPPerformanceMeasureReportedValuesGridJsonData(EIPPerformanceMeasurePrimaryKey eipPerformanceMeasurePrimaryKey)
        {
            EIPPerformanceMeasureReportedValuesGridSpec gridSpec;
            var eipPerformanceMeasureActuals = GetEIPPerformanceMeasureReportedValuesAndGridSpec(out gridSpec, eipPerformanceMeasurePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<EIPPerformanceMeasureReportedValue>(eipPerformanceMeasureActuals, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<EIPPerformanceMeasureReportedValue> GetEIPPerformanceMeasureReportedValuesAndGridSpec(out EIPPerformanceMeasureReportedValuesGridSpec gridSpec, EIPPerformanceMeasure eipPerformanceMeasure)
        {
            gridSpec = new EIPPerformanceMeasureReportedValuesGridSpec(eipPerformanceMeasure);
            return eipPerformanceMeasure.GetReportedEIPPerformanceMeasureValues();
        }

        [EIPPerformanceMeasureViewFeature]
        [CrossAreaRoute]
        public GridJsonNetJObjectResult<EIPPerformanceMeasureExpected> EIPPerformanceMeasureExpectedsGridJsonData(EIPPerformanceMeasurePrimaryKey eipPerformanceMeasurePrimaryKey)
        {
            EIPPerformanceMeasureExpectedGridSpec gridSpec;
            var eipPerformanceMeasureExpecteds = GetEIPPerformanceMeasureExpectedsAndGridSpec(out gridSpec, eipPerformanceMeasurePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<EIPPerformanceMeasureExpected>(eipPerformanceMeasureExpecteds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<EIPPerformanceMeasureExpected> GetEIPPerformanceMeasureExpectedsAndGridSpec(out EIPPerformanceMeasureExpectedGridSpec gridSpec,
            EIPPerformanceMeasure eipPerformanceMeasure)
        {
            gridSpec = new EIPPerformanceMeasureExpectedGridSpec(eipPerformanceMeasure);
            return eipPerformanceMeasure.EIPPerformanceMeasureExpecteds.ToList();
        }
    }
}