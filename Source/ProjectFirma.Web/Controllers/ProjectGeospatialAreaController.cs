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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Map;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectGeospatialAreaController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectGeospatialAreas(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditProjectGeospatialAreasViewModel(project.ProjectGeospatialAreas.Select(x => x.GeospatialAreaID).ToList(), project.ProjectGeospatialAreaNotes);
            return ViewEditProjectGeospatialAreas(viewModel, project);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectGeospatialAreas(ProjectPrimaryKey projectPrimaryKey, EditProjectGeospatialAreasViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectGeospatialAreas(viewModel, project);
            }

            var currentProjectGeospatialAreas = project.ProjectGeospatialAreas.ToList();
            var allProjectGeospatialAreas = HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.Local;
            viewModel.UpdateModel(project, currentProjectGeospatialAreas, allProjectGeospatialAreas);

            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {currentProjectGeospatialAreas.First().GeospatialArea.GeospatialAreaType.GeospatialAreaTypeNamePluralized} were successfully saved.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectGeospatialAreas(EditProjectGeospatialAreasViewModel viewModel, Project project)
        {
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var layers = MapInitJson.GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(project));
            var mapInitJson = new MapInitJson("projectGeospatialAreaMap", 0, layers, boundingBox) { AllowFullScreen = false, DisablePopups = true};
            var geospatialAreaIDs = viewModel.GeospatialAreaIDs ?? new List<int>();
            var geospatialAreasInViewModel = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => geospatialAreaIDs.Contains(x.GeospatialAreaID)).ToList();
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var editProjectGeospatialAreasPostUrl = SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(c => c.EditProjectGeospatialAreas(project, null));
            var editProjectGeospatialAreasFormID = GetEditProjectGeospatialAreasFormID();

            var viewData = new EditProjectGeospatialAreasViewData(CurrentPerson, mapInitJson, geospatialAreasInViewModel, tenantAttribute, editProjectGeospatialAreasPostUrl, editProjectGeospatialAreasFormID, project.HasProjectLocationPoint, project.HasProjectLocationDetail);
            return RazorPartialView<EditProjectGeospatialAreas, EditProjectGeospatialAreasViewData, EditProjectGeospatialAreasViewModel>(viewData, viewModel);
        }

        [AnonymousUnclassifiedFeature]
        public JsonResult FindGeospatialAreaByName(string term)
        {
            var searchString = term.Trim();
            return Json(HttpRequestStorage.DatabaseEntities.GeospatialAreas
                .Where(x => x.GeospatialAreaName.Contains(searchString)).OrderBy(x => x.GeospatialAreaName).Take(20).ToList()
                .Select(x => new {x.GeospatialAreaName, x.GeospatialAreaID}).ToList(), JsonRequestBehavior.AllowGet);
        }

        public static string GetEditProjectGeospatialAreasFormID()
        {
            return "editProjectGeospatialAreasForm";
        }
    }
}
