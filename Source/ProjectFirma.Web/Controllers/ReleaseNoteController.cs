/*-----------------------------------------------------------------------
<copyright file="ReleaseNoteController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public class ReleaseNoteController : FirmaBaseController
    {
        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var releaseNote = new ReleaseNote(String.Empty, CurrentPerson.PersonID, default(DateTime));
            viewModel.UpdateModel(releaseNote, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.ReleaseNotes.Add(releaseNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult Edit(ReleaseNotePrimaryKey releaseNotePrimaryKey)
        {
            var releaseNote = releaseNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(releaseNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ReleaseNotePrimaryKey releaseNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var releaseNote = releaseNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(releaseNote, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult DeleteReleaseNote(ReleaseNotePrimaryKey releaseNotePrimaryKey)
        {
            var releaseNote = releaseNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(releaseNote.ReleaseNoteID);
            return ViewDeleteReleaseNote(releaseNote, viewModel);
        }

        private PartialViewResult ViewDeleteReleaseNote(ReleaseNote releaseNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !releaseNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? "Are you sure you want to delete this Release Note?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Release Note");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteReleaseNote(ReleaseNotePrimaryKey releaseNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var releaseNote = releaseNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteReleaseNote(releaseNote, viewModel);
            }
            releaseNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}
