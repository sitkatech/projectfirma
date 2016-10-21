using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Areas.EIP.Views.Snapshot;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Areas.EIP.Views.Snapshot.Index;
using IndexGridSpec = ProjectFirma.Web.Areas.EIP.Views.Snapshot.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Areas.EIP.Views.Snapshot.IndexViewData;
using Summary = ProjectFirma.Web.Areas.EIP.Views.Snapshot.Summary;
using SummaryViewData = ProjectFirma.Web.Areas.EIP.Views.Snapshot.SummaryViewData;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class SnapshotController : LakeTahoeInfoBaseController
    {
        [AdminReadOnlyViewEverythingFeature]
        public ActionResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AdminReadOnlyViewEverythingFeature]
        public GridJsonNetJObjectResult<Snapshot> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var snapshots = GetSnapshotAndGridSpec(out gridSpec);
            var gridJsonNetObjectResult = new GridJsonNetJObjectResult<Snapshot>(snapshots, gridSpec);
            return gridJsonNetObjectResult;
        }

        private static List<Snapshot> GetSnapshotAndGridSpec(out IndexGridSpec gridSpec)
        {
            gridSpec = new IndexGridSpec();
            return HttpRequestStorage.DatabaseEntities.Snapshots.ToList().OrderByDescending(snapshot => snapshot.SnapshotDate).ToList();
        }

        [AdminReadOnlyViewEverythingFeature]
        public ActionResult Summary(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            var snapshot = snapshotPrimaryKey.EntityObject;

            var eipPerformanceMeasureReportedValues = snapshot.SnapshotEIPPerformanceMeasures;
            var eipPerformanceMeasureSubcategoriesCalendarYearReportedValues =
                EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromEIPPerformanceMeasuresAndCalendarYears(new List<IEIPPerformanceMeasureReportedValue>(eipPerformanceMeasureReportedValues));
            var eipPerformanceMeasureReportedValuesGroupedViewData = new EIPPerformanceMeasureReportedValuesGroupedViewData(eipPerformanceMeasureSubcategoriesCalendarYearReportedValues,
                new List<int> (),
                null,
                eipPerformanceMeasureReportedValues.Select(x => x.CalendarYear).Distinct().ToList(),
                true);

            var viewData = new SummaryViewData(CurrentPerson, snapshot, new SnapshotProjectGridSpec(), eipPerformanceMeasureReportedValuesGroupedViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [AdminReadOnlyViewEverythingFeature]
        public PartialViewResult Edit(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            var snapshot = snapshotPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(snapshot);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [AdminReadOnlyViewEverythingFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(SnapshotPrimaryKey snapshotPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return ViewEdit(viewModel);
            var snapshot = snapshotPrimaryKey.EntityObject;
            viewModel.UpdateModel(snapshot, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [AdminReadOnlyViewEverythingFeature]
        public GridJsonNetJObjectResult<SnapshotProject> SnapshotProjectGridJsonData(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            SnapshotProjectGridSpec gridSpec = new SnapshotProjectGridSpec();
            var snapshotProjects = snapshotPrimaryKey.EntityObject.SnapshotProjects.ToList();
            var gridJsonNetObjectResult = new GridJsonNetJObjectResult<SnapshotProject>(snapshotProjects, gridSpec);
            return gridJsonNetObjectResult;
        }
    }
}