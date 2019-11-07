/*-----------------------------------------------------------------------
<copyright file="ProjectNoteUpdateController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Controllers
{
    public class ProjectNoteUpdateController : FirmaBaseController
    {
        [HttpGet]
        [ProjectNoteUpdateNewFeature]
        public PartialViewResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectNoteUpdateNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            var projectNoteUpdate = ProjectNoteUpdate.CreateNewBlank(projectUpdateBatch);
            viewModel.UpdateModel(projectNoteUpdate, CurrentFirmaSession);
            projectNoteUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllProjectNoteUpdates.Add(projectNoteUpdate);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectNoteUpdateEditFeature]
        public PartialViewResult Edit(ProjectNoteUpdatePrimaryKey projectNoteUpdatePrimaryKey)
        {
            var projectNoteUpdate = projectNoteUpdatePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(projectNoteUpdate.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectNoteUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectNoteUpdatePrimaryKey projectNoteUpdatePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectNoteUpdate = projectNoteUpdatePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectNoteUpdate, CurrentFirmaSession);
            projectNoteUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectNoteUpdateEditFeature]
        public PartialViewResult Delete(ProjectNoteUpdatePrimaryKey projectNoteUpdatePrimaryKey)
        {
            var projectNoteUpdate = projectNoteUpdatePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectNoteUpdate.ProjectNoteUpdateID);
            return ViewDelete(projectNoteUpdate, viewModel);
        }

        private PartialViewResult ViewDelete(ProjectNoteUpdate projectNoteUpdate, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectNoteUpdate.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectNoteUpdate.ProjectUpdateBatch.Project.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.ProjectNote.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectNoteUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProjectNoteUpdatePrimaryKey projectNoteUpdatePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectNoteUpdate = projectNoteUpdatePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(projectNoteUpdate, viewModel);
            }
            projectNoteUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentFirmaSession);
            projectNoteUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}
