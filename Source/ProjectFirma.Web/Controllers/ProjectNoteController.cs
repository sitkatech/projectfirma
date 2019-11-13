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
using System.Web.Mvc;
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
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditProjectProjectStatusViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            var projectProjectStatus = ProjectProjectStatus.CreateNewBlank(project, ProjectStatus.Green, CurrentFirmaSession.Person);
            viewModel.UpdateModel(projectProjectStatus, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.ProjectProjectStatuses.Add(projectProjectStatus);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectNoteManageAsAdminFeature]
        public PartialViewResult Edit(ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey)
        {
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            var viewModel = new EditProjectProjectStatusViewModel(projectProjectStatus);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectNoteManageAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey, EditProjectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;
            viewModel.UpdateModel(projectProjectStatus, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditProjectProjectStatusViewModel viewModel)
        {
            var viewData = new EditProjectProjectStatusViewData();
            return RazorPartialView<EditProjectProjectStatus, EditProjectProjectStatusViewData, EditProjectProjectStatusViewModel>(viewData, viewModel);
        }

        //[HttpGet]
        //[ProjectNoteManageAsAdminFeature]
        //public PartialViewResult DeleteProjectNote(ProjectNotePrimaryKey projectNotePrimaryKey)
        //{
        //    var projectNote = projectNotePrimaryKey.EntityObject;
        //    var viewModel = new ConfirmDialogFormViewModel(projectNote.ProjectNoteID);
        //    return ViewDeleteProjectNote(projectNote, viewModel);
        //}

        //private PartialViewResult ViewDeleteProjectNote(ProjectNote projectNote, ConfirmDialogFormViewModel viewModel)
        //{
        //    var canDelete = !projectNote.HasDependentObjects();
        //    var confirmMessage = canDelete
        //        ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectNote.Project.GetDisplayName()}'?"
        //        : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.ProjectNote.ToType().GetFieldDefinitionLabel()}");

        //    var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

        //    return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        //}

        //[HttpPost]
        //[ProjectNoteManageAsAdminFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult DeleteProjectNote(ProjectNotePrimaryKey projectNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        //{
        //    var projectNote = projectNotePrimaryKey.EntityObject;
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewDeleteProjectNote(projectNote, viewModel);
        //    }
        //    projectNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
        //    return new ModalDialogFormJsonResult();
        //}
    }
}
