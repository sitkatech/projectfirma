/*-----------------------------------------------------------------------
<copyright file="ProjectCustomAttributesController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCustomAttributesController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectCustomAttributesForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditProjectCustomAttributesViewModel(project);
            return ViewEditProjectCustomAttributes(project, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectCustomAttributesForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectCustomAttributesViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectCustomAttributes(project, viewModel);
            }

            return UpdateProjectCustomAttributes(viewModel, project);
        }

        private ActionResult UpdateProjectCustomAttributes(EditProjectCustomAttributesViewModel viewModel, Project project)
        {
            viewModel.UpdateModel(project, CurrentPerson);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectCustomAttributes(Project project, EditProjectCustomAttributesViewModel viewModel)
        {

            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().Where(x => x.HasEditPermission(CurrentPerson));

            var viewData = new EditProjectCustomAttributesViewData(
                projectCustomAttributeTypes.ToList(),
                new List<IProjectCustomAttribute>(project.ProjectCustomAttributes.ToList()));

            return RazorPartialView<EditProjectCustomAttributes, EditProjectCustomAttributesViewData, EditProjectCustomAttributesViewModel>(viewData, viewModel);
        }
    }
}