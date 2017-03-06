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
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectWatershed;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectWatershedController : FirmaBaseController
    {
        [HttpGet]
        [ProjectWatershedManageFromProjectFeature]
        public PartialViewResult EditProjectWatershedsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectWatershedSimples = project.ProjectWatersheds.Select(x => new ProjectWatershedSimple(x)).ToList();
            var viewModel = new EditProjectWatershedsViewModel(projectWatershedSimples);
            return ViewEditProjectWatershedsForProject(project, viewModel);
        }

        [HttpPost]
        [ProjectWatershedManageFromProjectFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectWatershedsForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectWatershedsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectWatershedsForProject(project, viewModel);
            }
            var currentProjectWatersheds = project.ProjectWatersheds.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectWatersheds.Load();
            var allProjectWatersheds = HttpRequestStorage.DatabaseEntities.AllProjectWatersheds.Local;
            viewModel.UpdateModel(currentProjectWatersheds, allProjectWatersheds);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectWatershedsForProject(Project project, EditProjectWatershedsViewModel viewModel)
        {
            var allWatersheds = HttpRequestStorage.DatabaseEntities.Watersheds.ToList().Select(x => new WatershedSimple(x)).OrderBy(p => p.WatershedName).ToList();
            var viewData = new EditProjectWatershedsViewData(project, allWatersheds);
            return RazorPartialView<EditProjectWatersheds, EditProjectWatershedsViewData, EditProjectWatershedsViewModel>(viewData, viewModel);
        }
    }
}
