/*-----------------------------------------------------------------------
<copyright file="ProjectStageController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.ProjectStageCustomLabel;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectStageCustomLabelController : FirmaBaseController
    {

        [FirmaAdminFeature]
        [CrossAreaRoute]
        public GridJsonNetJObjectResult<ProjectStage> IndexGridJsonData()
        {
            var gridSpec = new ProjectStageGridSpec(new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession));
            var projectStages = ProjectStage.All.OrderBy(x => x.SortOrder).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectStage>(projectStages, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaAdminFeature]
        [CrossAreaRoute]
        public PartialViewResult Edit(ProjectStagePrimaryKey projectStagePrimaryKey)
        {
            var projectStageCustomLabel = HttpRequestStorage.DatabaseEntities.ProjectStageCustomLabels.GetProjectStageCustomLabelByProjectStage(projectStagePrimaryKey);
            var viewModel = new EditViewModel(projectStagePrimaryKey.PrimaryKeyValue, projectStageCustomLabel);
            return ViewEdit(projectStagePrimaryKey, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [CrossAreaRoute]
        public ActionResult Edit(ProjectStagePrimaryKey projectStagePrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(projectStagePrimaryKey, viewModel);
            }
            var projectStageCustomLabel = HttpRequestStorage.DatabaseEntities.ProjectStageCustomLabels.GetProjectStageCustomLabelByProjectStage(projectStagePrimaryKey);
            if (projectStageCustomLabel == null)
            {
                projectStageCustomLabel = new ProjectStageCustomLabel(projectStagePrimaryKey.EntityObject);
                HttpRequestStorage.DatabaseEntities.AllProjectStageCustomLabels.Add(projectStageCustomLabel);
            }

            viewModel.UpdateModel(projectStageCustomLabel);
            SetMessageForDisplay("Project Stage Label successfully saved.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(ProjectStagePrimaryKey projectStagePrimaryKey, EditViewModel viewModel)
        {
            var viewData = new EditViewData(CurrentFirmaSession, projectStagePrimaryKey.EntityObject);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

    }
}
