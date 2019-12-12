/*-----------------------------------------------------------------------
<copyright file="GeospatialAreaController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.GeospatialAreaPerformanceMeasureTarget;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class GeospatialAreaPerformanceMeasureTargetController : FirmaBaseController
    {
        [HttpGet]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        public PartialViewResult AddGeospatialAreaToPerformanceMeasure(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;

            var viewModel = new AddGeospatialAreaToPerformanceMeasureViewModel(performanceMeasure);
            return ViewAddGeospatialAreaToPerformanceMeasure(performanceMeasure, viewModel);
        }

        [HttpPost]
        [AttachmentRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult AddGeospatialAreaToPerformanceMeasure(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, AddGeospatialAreaToPerformanceMeasureViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewAddGeospatialAreaToPerformanceMeasure(performanceMeasure, viewModel);
            }

            viewModel.UpdateModel(CurrentFirmaSession, performanceMeasure);

            return new ModalDialogFormJsonResult();
        }

        private List<int> GetSelectedGeospatialAreasFromPerformanceMeasure(PerformanceMeasure performanceMeasure)
        {
            var geospatialAreaIDs = new List<int>();
            geospatialAreaIDs.AddRange(HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).Select(x => x.GeospatialAreaID).ToList());
            geospatialAreaIDs.AddRange(HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureNoTargets.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).Select(x => x.GeospatialAreaID).ToList());
            geospatialAreaIDs.AddRange(HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureOverallTargets.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).Select(x => x.GeospatialAreaID).ToList());
            return geospatialAreaIDs;
        }

        private PartialViewResult ViewAddGeospatialAreaToPerformanceMeasure(PerformanceMeasure performanceMeasure, AddGeospatialAreaToPerformanceMeasureViewModel viewModel)
        {
            var geospatialAreaTypeSimples = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList().Select(x => new GeospatialAreaTypeSimple(x)).ToList();

            //build list of geospatial areas and remove any we have already setup a connection to this performance measure
            var geospatialAreaSimples = HttpRequestStorage.DatabaseEntities.GeospatialAreas.ToList().Select(x => new GeospatialAreaSimple(x)).ToList();//todo: probably want this data coming from an AJAX call
            var selectedGeospatialAreas = GetSelectedGeospatialAreasFromPerformanceMeasure(performanceMeasure);
            var selectedGeospatialAreaSimples = geospatialAreaSimples.Where(x => selectedGeospatialAreas.Contains(x.GeospatialAreaID)).ToList();
            var setToRemove = new HashSet<GeospatialAreaSimple>(selectedGeospatialAreaSimples);
            geospatialAreaSimples.RemoveAll(x => setToRemove.Contains(x));

            var viewDataForAngular = new AddGeospatialAreaToPerformanceMeasureViewDataForAngular(performanceMeasure, geospatialAreaTypeSimples, geospatialAreaSimples);
            var viewData = new AddGeospatialAreaToPerformanceMeasureViewData(performanceMeasure, viewDataForAngular);
            return RazorPartialView<AddGeospatialAreaToPerformanceMeasure, AddGeospatialAreaToPerformanceMeasureViewData, AddGeospatialAreaToPerformanceMeasureViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        public PartialViewResult Delete(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey, PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            //throw new NotImplementedException("Delete is not implemented");
            var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(geospatialArea.GeospatialAreaID);
            return ViewDelete(geospatialArea, performanceMeasure, viewModel);
        }

        private PartialViewResult ViewDelete(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure, ConfirmDialogFormViewModel viewModel)
        {
            var geospatialAreaPerformanceMeasureTargets =
                HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x =>
                    x.GeospatialAreaID == geospatialArea.GeospatialAreaID &&
                    x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID);


            var confirmMessage =
                $"Are you sure you want to delete all targets associated with this {FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabel()} '{geospatialArea.GeospatialAreaName}'?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey, PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(geospatialArea, performanceMeasure, viewModel);
            }

            // no target
            var geospatialAreaPerformanceMeasureNoTargets =
                HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureNoTargets.Where(x =>
                    x.GeospatialAreaID == geospatialArea.GeospatialAreaID &&
                    x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID);
            foreach (var noTarget in geospatialAreaPerformanceMeasureNoTargets)
            {
                noTarget.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }

            // overall target
            var geospatialAreaPerformanceMeasureOverallTargets =
                HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureOverallTargets.Where(x =>
                    x.GeospatialAreaID == geospatialArea.GeospatialAreaID &&
                    x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID);
            foreach (var overallTarget in geospatialAreaPerformanceMeasureOverallTargets)
            {
                overallTarget.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }

            // target per year
            var geospatialAreaPerformanceMeasureTargets =
                HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x =>
                    x.GeospatialAreaID == geospatialArea.GeospatialAreaID &&
                    x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID);
            foreach (var geoTarget in geospatialAreaPerformanceMeasureTargets)
            {
                geoTarget.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }

            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        public ActionResult Edit(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey, PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            //throw new NotImplementedException("Edit has not been implemented");
            var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewModel = new EditPerformanceMeasureTargetsViewModel(geospatialArea, performanceMeasure);
            return ViewEdit(geospatialArea, performanceMeasure, viewModel);
        }

        [HttpPost]
        [GeospatialAreaPerformanceMeasureTargetManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey, PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditPerformanceMeasureTargetsViewModel viewModel)
        {
            var geospatialArea = geospatialAreaPrimaryKey.EntityObject;
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(geospatialArea, performanceMeasure, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.Load();
            HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureNoTargets.Load();
            HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureOverallTargets.Load();
            HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Load();

            viewModel.UpdateModel(
                geospatialArea, 
                performanceMeasure, 
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Local, 
                HttpRequestStorage.DatabaseEntities.AllGeospatialAreaPerformanceMeasureNoTargets.Local,
                HttpRequestStorage.DatabaseEntities.AllGeospatialAreaPerformanceMeasureOverallTargets.Local,
                HttpRequestStorage.DatabaseEntities.AllGeospatialAreaPerformanceMeasureReportingPeriodTargets.Local
                );

            SetMessageForDisplay($"Successfully saved {FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel()} Targets");
            return new ModalDialogFormJsonResult();
        }

        private ActionResult ViewEdit(GeospatialArea geospatialArea,
                                      PerformanceMeasure performanceMeasure,
                                      EditPerformanceMeasureTargetsViewModel viewModel)
        {
            var performanceMeasureTargetValueTypes = PerformanceMeasureTargetValueType.All.ToList();
            var reportingPeriods = performanceMeasure.GetPerformanceMeasureReportingPeriodsFromTargetsAndActualsAndGeospatialAreaTargets(geospatialArea);
            var defaultReportingPeriodYear = reportingPeriods.Any()
                ? reportingPeriods.Max(x => x.PerformanceMeasureReportingPeriodCalendarYear) + 1
                : DateTime.Now.Year;
            var viewDataForAngular = new EditPerformanceMeasureTargetsViewDataForAngular(performanceMeasure,
                defaultReportingPeriodYear,
                performanceMeasureTargetValueTypes);
            var viewData = new EditPerformanceMeasureTargetsViewData(performanceMeasure, viewDataForAngular, EditPerformanceMeasureTargetsViewData.PerformanceMeasureTargetType.TargetByGeospatialArea);
            return RazorPartialView<EditPerformanceMeasureTargets, EditPerformanceMeasureTargetsViewData, EditPerformanceMeasureTargetsViewModel>(viewData, viewModel);
        }


    }
}
