/*-----------------------------------------------------------------------
<copyright file="ProjectNoteController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectProjectStatus;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectProjectStatusController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult NewFromGrid(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditProjectProjectStatusViewModel(DateTime.Now);
            return ViewEdit(viewModel, false, false, null, null);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewFromGrid(ProjectPrimaryKey projectPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, false, false, null, null);
            }
            return MakeTheNewProjectProjectStatus(projectPrimaryKey, viewModel);
        }


        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditProjectProjectStatusViewModel();
            return ViewEdit(viewModel, true, false, null, null);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, true, false, null, null);
            }
            return MakeTheNewProjectProjectStatus(projectPrimaryKey, viewModel);
        }

        private ActionResult MakeTheNewProjectProjectStatus(ProjectPrimaryKey projectPrimaryKey,
            EditProjectProjectStatusViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectStatusFromViewModel = ProjectStatus.AllLookupDictionary[viewModel.ProjectStatusID.Value];
            var projectProjectStatus =
                ProjectProjectStatus.CreateNewBlank(project, projectStatusFromViewModel, CurrentFirmaSession.Person);
            viewModel.UpdateModel(projectProjectStatus, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.ProjectProjectStatuses.Add(projectProjectStatus);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult Edit(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            var viewModel = new EditProjectProjectStatusViewModel(projectProjectStatus);
            return ViewEdit(viewModel, true, true, projectProjectStatus.ProjectProjectStatusCreatePerson.GetFullNameFirstLast(), projectProjectStatus.GetDeleteProjectProjectStatusUrl());
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, true, true, projectProjectStatus.ProjectProjectStatusCreatePerson.GetFullNameFirstLast(), projectProjectStatus.GetDeleteProjectProjectStatusUrl());
            }
            viewModel.UpdateModel(projectProjectStatus, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditProjectProjectStatusViewModel viewModel, bool allowEditUpdateDate, bool showCreatedBy, string personCreatedDisplay, string deleteUrl)
        {
            var viewData = new EditProjectProjectStatusViewData(allowEditUpdateDate, showCreatedBy, personCreatedDisplay, deleteUrl);
            return RazorPartialView<EditProjectProjectStatus, EditProjectProjectStatusViewData, EditProjectProjectStatusViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult DeleteProjectProjectStatus(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectProjectStatus.ProjectProjectStatusID);
            return ViewDeleteProjectProjectStatus(projectProjectStatus, viewModel);
        }

        private PartialViewResult ViewDeleteProjectProjectStatus(ProjectProjectStatus projectProjectStatus, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectProjectStatus.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.ProjectStatusUpdate.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectProjectStatus.Project.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.ProjectStatusUpdate.ToType().GetFieldDefinitionLabel()}");
            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectProjectStatus(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectProjectStatus(projectProjectStatus, viewModel);
            }
            projectProjectStatus.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [ProjectViewFeature]
        public PartialViewResult Details(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            var viewData = new ProjectProjectStatusDetailsViewData(projectProjectStatus);
           return RazorPartialView<ProjectProjectStatusDetails, ProjectProjectStatusDetailsViewData>(viewData);
        }
    }
}
