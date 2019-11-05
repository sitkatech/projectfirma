/*-----------------------------------------------------------------------
<copyright file="ProjectGeospatialAreaController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Map;

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
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var layers = MapInitJson.GetGeospatialAreaMapLayersForGeospatialAreaType(geospatialAreaType, LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(project));
            var mapInitJson = new MapInitJson("projectGeospatialAreaMap", 0, layers, boundingBox) { AllowFullScreen = false, DisablePopups = true};
            var geospatialAreaIDs = viewModel.GeospatialAreaIDs ?? new List<int>();
            var geospatialAreasInViewModel = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => geospatialAreaIDs.Contains(x.GeospatialAreaID)).ToList();
            var editProjectGeospatialAreasPostUrl = SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(c => c.EditProjectGeospatialAreas(project, geospatialAreaType, null));
            var editProjectGeospatialAreasFormID = GetEditProjectGeospatialAreasFormID();


            var geospatialAreasContainingProjectSimpleLocation =
                HttpRequestStorage.DatabaseEntities.GeospatialAreas
                    .Where(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList()
                    .GetGeospatialAreasContainingProjectLocation(project).ToList();

            var viewData = new EditProjectGeospatialAreasViewData(CurrentPerson, mapInitJson,
                geospatialAreasInViewModel, editProjectGeospatialAreasPostUrl, editProjectGeospatialAreasFormID,
                project.HasProjectLocationPoint, project.HasProjectLocationDetail, geospatialAreaType, geospatialAreasContainingProjectSimpleLocation, null);
            return RazorPartialView<EditProjectGeospatialAreas, EditProjectGeospatialAreasViewData, EditProjectGeospatialAreasViewModel>(viewData, viewModel);
        }

        [AnonymousUnclassifiedFeature]
        public JsonResult FindGeospatialAreaByName(GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey, string term)
        {
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var searchString = term.Trim();
            return Json(HttpRequestStorage.DatabaseEntities.GeospatialAreas
                .Where(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID && x.GeospatialAreaName.Contains(searchString)).OrderBy(x => x.GeospatialAreaName).Take(20).ToList()
                .Select(x => new {x.GeospatialAreaName, x.GeospatialAreaID}).ToList(), JsonRequestBehavior.AllowGet);
        }

        public static string GetEditProjectGeospatialAreasFormID()
        {
            return "editProjectGeospatialAreasForm";
        }
    }
}
