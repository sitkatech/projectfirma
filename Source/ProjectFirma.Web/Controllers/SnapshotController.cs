/*-----------------------------------------------------------------------
<copyright file="SnapshotController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Snapshot;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
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
        [FirmaAdminFeature]
        public ActionResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Snapshot> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var snapshots = HttpRequestStorage.DatabaseEntities.Snapshots.ToList().OrderByDescending(snapshot => snapshot.SnapshotDate).ToList();
            var gridJsonNetObjectResult = new GridJsonNetJObjectResult<Snapshot>(snapshots, gridSpec);
            return gridJsonNetObjectResult;
        }

        [FirmaAdminFeature]
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
        [FirmaAdminFeature]
        public PartialViewResult Edit(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            var snapshot = snapshotPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(snapshot);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
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

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<SnapshotProject> SnapshotProjectGridJsonData(SnapshotPrimaryKey snapshotPrimaryKey)
        {
            SnapshotProjectGridSpec gridSpec = new SnapshotProjectGridSpec();
            var snapshotProjects = snapshotPrimaryKey.EntityObject.SnapshotProjects.ToList();
            var gridJsonNetObjectResult = new GridJsonNetJObjectResult<SnapshotProject>(snapshotProjects, gridSpec);
            return gridJsonNetObjectResult;
        }
    }
}
