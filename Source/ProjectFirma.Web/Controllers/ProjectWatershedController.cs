/*-----------------------------------------------------------------------
<copyright file="ProjectWatershedController.cs" company="Tahoe Regional Planning Agency">
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
using GeoJSON.Net.Feature;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectWatershedControls;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.MvcResults;
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Map;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectWatershedController : FirmaBaseController
    {
        [HttpGet]
        [ProjectWatershedManageFromProjectFeature]
        public PartialViewResult EditProjectWatersheds(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditProjectWatershedsViewModel(project.ProjectWatersheds.Select(x => x.WatershedID).ToList(), project.ProjectWatershedNotes);
            return ViewEditProjectWatersheds(viewModel, project);
        }

        [HttpPost]
        [ProjectWatershedManageFromProjectFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectWatersheds(ProjectPrimaryKey projectPrimaryKey, EditProjectWatershedsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectWatersheds(viewModel, project);
            }

            var currentProjectWatersheds = project.ProjectWatersheds.ToList();
            var allProjectWatersheds = HttpRequestStorage.DatabaseEntities.AllProjectWatersheds.Local;
            viewModel.UpdateModel(project, currentProjectWatersheds, allProjectWatersheds);

            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {FieldDefinition.Watershed.GetFieldDefinitionLabelPluralized()} were successfully saved.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectWatersheds(EditProjectWatershedsViewModel viewModel, Project project)
        {
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var layers = MapInitJson.GetAllWatershedMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(project));
            var mapInitJson = new MapInitJson("projectWatershedMap", 0, layers, boundingBox) { AllowFullScreen = false };
            var watershedIDs = viewModel.WatershedIDs ?? new List<int>();
            var watershedsInViewModel = HttpRequestStorage.DatabaseEntities.Watersheds.Where(x => watershedIDs.Contains(x.WatershedID)).ToList();
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var editProjectWatershedsPostUrl = SitkaRoute<ProjectWatershedController>.BuildUrlFromExpression(c => c.EditProjectWatersheds(project, null));
            var editProjectWatershedsFormID = GetEditProjectWatershedsFormID();

            var viewData = new EditProjectWatershedsViewData(CurrentPerson, mapInitJson, watershedsInViewModel, tenantAttribute, editProjectWatershedsPostUrl, editProjectWatershedsFormID, project.HasProjectLocationPoint, project.HasProjectLocationDetail);
            return RazorPartialView<EditProjectWatersheds, EditProjectWatershedsViewData, EditProjectWatershedsViewModel>(viewData, viewModel);
        }

        [AnonymousUnclassifiedFeature]
        public JsonResult FindWatershedByName(string term)
        {
            var searchString = term.Trim();
            return Json(HttpRequestStorage.DatabaseEntities.Watersheds
                .Where(x => x.WatershedName.Contains(searchString)).OrderBy(x => x.WatershedName).Take(20).ToList()
                .Select(x => new {x.WatershedName, x.WatershedID}).ToList(), JsonRequestBehavior.AllowGet);
        }

        public static string GetEditProjectWatershedsFormID()
        {
            return "editProjectWatershedsForm";
        }
    }
}
