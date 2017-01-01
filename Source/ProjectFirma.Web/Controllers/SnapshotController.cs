using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Snapshot;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using Detail = ProjectFirma.Web.Views.Snapshot.Detail;
using DetailViewData = ProjectFirma.Web.Views.Snapshot.DetailViewData;
using Index = ProjectFirma.Web.Views.Snapshot.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Snapshot.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Snapshot.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class SnapshotController : FirmaBaseController
    {
        [AdminFeature]
        public ActionResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AdminFeature]
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

        [AdminFeature]
        public ActionResult Detail(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            var snapshot = snapshotPrimaryKey.EntityObject;

            var performanceMeasureReportedValues = snapshot.SnapshotPerformanceMeasures;
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(performanceMeasureReportedValues));
            var performanceMeasureReportedValuesGroupedViewData = new PerformanceMeasureReportedValuesGroupedViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                new List<int> (),
                null,
                performanceMeasureReportedValues.Select(x => x.CalendarYear).Distinct().ToList(),
                true);

            var viewData = new DetailViewData(CurrentPerson, snapshot, new SnapshotProjectGridSpec(), performanceMeasureReportedValuesGroupedViewData);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [AdminFeature]
        public PartialViewResult Edit(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            var snapshot = snapshotPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(snapshot);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [AdminFeature]
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

        [AdminFeature]
        public GridJsonNetJObjectResult<SnapshotProject> SnapshotProjectGridJsonData(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            SnapshotProjectGridSpec gridSpec = new SnapshotProjectGridSpec();
            var snapshotProjects = snapshotPrimaryKey.EntityObject.SnapshotProjects.ToList();
            var gridJsonNetObjectResult = new GridJsonNetJObjectResult<SnapshotProject>(snapshotProjects, gridSpec);
            return gridJsonNetObjectResult;
        }
    }
}