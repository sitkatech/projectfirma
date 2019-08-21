using System.Collections.Generic;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectAttachment;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectAttachmentUpdateController : FirmaBaseController
    {
        [HttpGet]
        [ProjectAttachmentUpdateNewFeature]
        public PartialViewResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var viewModel = new NewProjectAttachmentUpdateViewModel(projectUpdateBatchPrimaryKey.EntityObject);
            return ViewNew(viewModel, projectUpdateBatchPrimaryKey.EntityObject);
        }

        [HttpPost]
        [ProjectAttachmentUpdateNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey, NewProjectAttachmentUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel, projectUpdateBatchPrimaryKey.EntityObject);
            }
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            viewModel.UpdateModel(projectUpdateBatch, CurrentPerson);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectAttachmentUpdateEditFeature]
        public PartialViewResult Edit(ProjectAttachmentUpdatePrimaryKey projectAttachmentUpdatePrimaryKey)
        {
            var projectAttachmentUpdate = projectAttachmentUpdatePrimaryKey.EntityObject;
            var viewModel = new EditProjectAttachmentUpdatesViewModel(projectAttachmentUpdate);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectAttachmentUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectAttachmentUpdatePrimaryKey projectAttachmentUpdatePrimaryKey, EditProjectAttachmentUpdatesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectAttachmentUpdate = projectAttachmentUpdatePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectAttachmentUpdate);
            projectAttachmentUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewProjectAttachmentUpdateViewModel viewModel, ProjectUpdateBatch projectUpdateBatch)
        {
            IEnumerable<AttachmentRelationshipType> attachmentRelationshipTypes = projectUpdateBatch.GetValidAttachmentRelationshipTypesForForms();

            Check.Assert(attachmentRelationshipTypes != null, "Cannot find any valid attachment relationship types for this project.");
            var viewData = new NewProjectAttachmentViewData(attachmentRelationshipTypes);
            return RazorPartialView<NewProjectAttachment, NewProjectAttachmentViewData, NewProjectAttachmentViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewEdit(EditProjectAttachmentsViewModel viewModel)
        {
            var viewData = new EditProjectAttachmentsViewData();
            return RazorPartialView<EditProjectAttachments, EditProjectAttachmentsViewData, EditProjectAttachmentsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectAttachmentUpdateEditFeature]
        public PartialViewResult Delete(ProjectAttachmentUpdatePrimaryKey projectAttachmentUpdatePrimaryKey)
        {
            var projectAttachmentUpdate = projectAttachmentUpdatePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectAttachmentUpdate.ProjectAttachmentUpdateID);
            return ViewDelete(projectAttachmentUpdate, viewModel);
        }

        private PartialViewResult ViewDelete(ProjectAttachmentUpdate projectAttachmentUpdate, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectAttachmentUpdate.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete \"{projectAttachmentUpdate.DisplayName}\" from this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Attachment");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectAttachmentUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProjectAttachmentUpdatePrimaryKey projectAttachmentUpdatePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectAttachmentUpdate = projectAttachmentUpdatePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(projectAttachmentUpdate, viewModel);
            }
            projectAttachmentUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            projectAttachmentUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}