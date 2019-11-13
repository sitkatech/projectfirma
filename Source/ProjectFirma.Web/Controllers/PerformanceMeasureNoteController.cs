/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureNoteController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureNoteController : FirmaBaseController
    {
        [HttpGet]
        [PerformanceMeasureNoteManageFeature]
        public PartialViewResult New(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var performanceMeasureNote = PerformanceMeasureNote.CreateNewBlank(performanceMeasure);
            viewModel.UpdateModel(performanceMeasureNote, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureNotes.Add(performanceMeasureNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [PerformanceMeasureNoteManageFeature]
        public PartialViewResult Edit(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey)
        {
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(performanceMeasureNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(performanceMeasureNote, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureNoteManageFeature]
        public PartialViewResult DeletePerformanceMeasureNote(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey)
        {
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(performanceMeasureNote.PerformanceMeasureNoteID);
            return ViewDeletePerformanceMeasureNote(performanceMeasureNote, viewModel);
        }

        private PartialViewResult ViewDeletePerformanceMeasureNote(PerformanceMeasureNote performanceMeasureNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !performanceMeasureNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this note for PerformanceMeasure '{0}'?", performanceMeasureNote.PerformanceMeasure.PerformanceMeasureDisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("PerformanceMeasure Note");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeletePerformanceMeasureNote(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeletePerformanceMeasureNote(performanceMeasureNote, viewModel);
            }
            performanceMeasureNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}
