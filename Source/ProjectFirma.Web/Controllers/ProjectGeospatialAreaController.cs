﻿/*-----------------------------------------------------------------------
<copyright file="ProjectGeospatialAreaController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectGeospatialAreaController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectGeospatialAreas(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var geospatialAreaIDs = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaType == geospatialAreaType).Select(x => x.GeospatialAreaID).ToList();
            var geospatialAreaNotes = project.ProjectGeospatialAreaTypeNotes.SingleOrDefault(x=> x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID)?.Notes;
            var viewModel = new EditProjectGeospatialAreasViewModel(geospatialAreaIDs, geospatialAreaNotes);
            return ViewEditProjectGeospatialAreas(viewModel, project, geospatialAreaType);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectGeospatialAreas(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey, EditProjectGeospatialAreasViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectGeospatialAreas(viewModel, project, geospatialAreaType);
            }

            var currentProjectGeospatialAreas = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList();
            var allProjectGeospatialAreas = HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.Local;
            viewModel.UpdateModel(project, currentProjectGeospatialAreas, allProjectGeospatialAreas);
            var projectGeospatialAreaTypeNote = project.ProjectGeospatialAreaTypeNotes.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);
            if (!string.IsNullOrWhiteSpace(viewModel.ProjectGeospatialAreaNotes))
            {
                if (projectGeospatialAreaTypeNote == null)
                {
                    projectGeospatialAreaTypeNote = new ProjectGeospatialAreaTypeNote(project, geospatialAreaType, viewModel.ProjectGeospatialAreaNotes);
                }
                projectGeospatialAreaTypeNote.Notes = viewModel.ProjectGeospatialAreaNotes;
            }
            else
            {
                projectGeospatialAreaTypeNote?.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {geospatialAreaType.GeospatialAreaTypeNamePluralized} were successfully saved.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectGeospatialAreas(EditProjectGeospatialAreasViewModel viewModel,
            Project project, GeospatialAreaType geospatialAreaType)
        {
            var userCanViewPrivateLocations = CurrentFirmaSession.UserCanViewPrivateLocations(project);
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project, userCanViewPrivateLocations);
            var layers = MapInitJson.GetGeospatialAreaMapLayersForGeospatialAreaType(geospatialAreaType);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(project, CurrentFirmaSession));
            var mapInitJson = new MapInitJson("projectGeospatialAreaMap", 0, layers, MapInitJson.GetExternalMapLayerSimples(), boundingBox) { AllowFullScreen = false, DisablePopups = true};
            var geospatialAreaIDs = viewModel.GeospatialAreaIDs ?? new List<int>();
            var geospatialAreasInViewModel = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => geospatialAreaIDs.Contains(x.GeospatialAreaID)).ToList();
            var editProjectGeospatialAreasPostUrl = SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(c => c.EditProjectGeospatialAreas(project, geospatialAreaType, null));
            var editProjectGeospatialAreasFormID = GetEditProjectGeospatialAreasFormID();

            var geospatialAreasContainingProjectSimpleLocation = GeospatialAreaModelExtensions.GetGeospatialAreasContainingProjectLocation(project, geospatialAreaType.GeospatialAreaTypeID).ToList();

            var viewData = new EditProjectGeospatialAreasViewData(CurrentFirmaSession, mapInitJson,
                geospatialAreasInViewModel, editProjectGeospatialAreasPostUrl, editProjectGeospatialAreasFormID,
                project.HasProjectLocationPoint(userCanViewPrivateLocations), project.HasProjectLocationDetailed(userCanViewPrivateLocations), geospatialAreaType, 
                geospatialAreasContainingProjectSimpleLocation, null);
            return RazorPartialView<EditProjectGeospatialAreas, EditProjectGeospatialAreasViewData, EditProjectGeospatialAreasViewModel>(viewData, viewModel);
        }

        [AnonymousUnclassifiedFeature]
        public JsonResult FindGeospatialAreaByName(GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey, string term)
        {
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var searchString = term.Trim();
            return Json(HttpRequestStorage.DatabaseEntities.GeospatialAreas
                .Where(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID && x.GeospatialAreaShortName.Contains(searchString)).OrderBy(x => x.GeospatialAreaShortName).Take(20).ToList()
                .Select(x => new {x.GeospatialAreaShortName, x.GeospatialAreaID}).ToList(), JsonRequestBehavior.AllowGet);
        }

        public static string GetEditProjectGeospatialAreasFormID()
        {
            return "editProjectGeospatialAreasForm";
        }
    }
}
