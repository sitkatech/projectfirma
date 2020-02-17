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
using ProjectFirma.Web.Views.Shared.ProjectTimeline;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectProjectStatusController : FirmaBaseController
    {
        [HttpGet]
        [ProjectStatusUpdateFeature]
        public PartialViewResult NewFromGrid(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditProjectProjectStatusViewModel(DateTime.Now);
            var allowEditFinal = AllowUserToSetNewStatusReportToFinal(projectPrimaryKey.EntityObject, CurrentFirmaSession);
            viewModel.IsFinalStatusUpdate = allowEditFinal;


            var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromGridDialog.GetFirmaPage();
            return ViewEdit( viewModel, false, null, null, projectStatusFirmaPage, projectPrimaryKey.EntityObject, false);
        }

        public static bool AllowUserToSetNewStatusReportToFinal(Project project, FirmaSession currentFirmaSession)
        {
            var allowEditFinal = false;
            var userHasPermissionToEditTimeline = new ProjectTimelineFeature().HasPermission(currentFirmaSession, project).HasPermission;
            if (project.HasSubmittedOrApprovedUpdateBatchChangingProjectToCompleted() || project.ProjectStage == ProjectStage.Completed)
            {
                var finalStatusReport = project.ProjectProjectStatuses.Where(x => x.IsFinalStatusUpdate);

                if (!finalStatusReport.Any())
                {
                    if (userHasPermissionToEditTimeline)
                    {
                        allowEditFinal = true;
                    }
                }
            }

            return allowEditFinal;
        }

        [HttpPost]
        [ProjectStatusUpdateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewFromGrid(ProjectPrimaryKey projectPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromGridDialog.GetFirmaPage();
                return ViewEdit(viewModel, false, null, null, projectStatusFirmaPage, projectPrimaryKey.EntityObject, false);
            }
            return MakeTheNewProjectProjectStatus(projectPrimaryKey, viewModel);
        }


        [HttpGet]
        [ProjectStatusUpdateFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditProjectProjectStatusViewModel();
            var allowEditFinal = AllowUserToSetNewStatusReportToFinal(projectPrimaryKey.EntityObject, CurrentFirmaSession);
            viewModel.IsFinalStatusUpdate = allowEditFinal;
            var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
            return ViewEdit(viewModel, true, null, null, projectStatusFirmaPage, projectPrimaryKey.EntityObject, false);
        }

        [HttpPost]
        [ProjectStatusUpdateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
                return ViewEdit(viewModel, true, null, null, projectStatusFirmaPage, projectPrimaryKey.EntityObject, false);
            }
            return MakeTheNewProjectProjectStatus(projectPrimaryKey, viewModel);
        }

        private ActionResult MakeTheNewProjectProjectStatus(ProjectPrimaryKey projectPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectStatusFromViewModel = new ProjectStatusPrimaryKey(viewModel.ProjectStatusID).EntityObject;
            var projectProjectStatus =
                ProjectProjectStatus.CreateNewBlank(project, projectStatusFromViewModel, CurrentFirmaSession.Person);
            viewModel.UpdateModel(projectProjectStatus, CurrentFirmaSession);
            project.ProjectProjectStatuses.Add(projectProjectStatus);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectStatusUpdateFeature]
        public PartialViewResult Edit(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            var viewModel = new EditProjectProjectStatusViewModel(projectProjectStatus);
            var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
            return ViewEdit(viewModel, true, projectProjectStatus.ProjectProjectStatusCreatePerson.GetFullNameFirstLast(), projectProjectStatus.GetDeleteProjectProjectStatusUrl(), projectStatusFirmaPage, projectPrimaryKey.EntityObject, projectProjectStatus.IsFinalStatusUpdate);
        }

        [HttpPost]
        [ProjectStatusUpdateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
                return ViewEdit(viewModel, true, projectProjectStatus.ProjectProjectStatusCreatePerson.GetFullNameFirstLast(), projectProjectStatus.GetDeleteProjectProjectStatusUrl(), projectStatusFirmaPage, project, projectProjectStatus.IsFinalStatusUpdate);
            }
            viewModel.UpdateModel(projectProjectStatus, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditProjectProjectStatusViewModel viewModel, bool allowEditUpdateDate, string personCreatedDisplay, string deleteUrl, FirmaPage firmaPage, ProjectFirmaModels.Models.Project project, bool isFinalStatusReport)
        {
            var projectStatusFirmaPage = firmaPage;
            var allProjectStatuses = HttpRequestStorage.DatabaseEntities.ProjectStatuses.ToList();
            var projectStatusesForLegend = HttpRequestStorage.DatabaseEntities.ProjectStatuses.OrderBy(ps => ps.ProjectStatusSortOrder).ToList();
            var projectStatusLegendDisplayViewData = new ProjectStatusLegendDisplayViewData(projectStatusesForLegend);
            var viewData = new EditProjectProjectStatusViewData(project,allowEditUpdateDate, personCreatedDisplay, deleteUrl, projectStatusFirmaPage, CurrentFirmaSession, allProjectStatuses, projectStatusLegendDisplayViewData, isFinalStatusReport);
            return RazorPartialView<EditProjectProjectStatus, EditProjectProjectStatusViewData, EditProjectProjectStatusViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectStatusUpdateFeature]
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
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectProjectStatus.Project.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()}");
            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectStatusUpdateFeature]
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
