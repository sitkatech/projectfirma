using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectDocument;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectDocumentUpdateController : FirmaBaseController
    {
        [HttpGet]
        [ProjectDocumentUpdateNewFeature]
        public PartialViewResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var viewModel = new NewProjectDocumentUpdateViewModel(projectUpdateBatchPrimaryKey.EntityObject);
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ProjectDocumentUpdateNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey, NewProjectDocumentUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            viewModel.UpdateModel(projectUpdateBatch, CurrentPerson);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectDocumentUpdateEditFeature]
        public PartialViewResult Edit(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey)
        {
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            var viewModel = new EditProjectDocumentUpdatesViewModel(projectDocumentUpdate);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectDocumentUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey, EditProjectDocumentUpdatesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectDocumentUpdate);
            projectDocumentUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewProjectDocumentViewModel viewModel)
        {
            var viewData = new NewProjectDocumentViewData();
            return RazorPartialView<NewProjectDocument, NewProjectDocumentViewData, NewProjectDocumentViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewEdit(EditProjectDocumentsViewModel viewModel)
        {
            var viewData = new EditProjectDocumentsViewData();
            return RazorPartialView<EditProjectDocuments, EditProjectDocumentsViewData, EditProjectDocumentsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectDocumentUpdateEditFeature]
        public PartialViewResult Delete(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey)
        {
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectDocumentUpdate.ProjectDocumentUpdateID);
            return ViewDelete(projectDocumentUpdate, viewModel);
        }

        private PartialViewResult ViewDelete(ProjectDocumentUpdate projectDocumentUpdate, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectDocumentUpdate.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete \"{projectDocumentUpdate.DisplayName}\" from this {FieldDefinition.Project.GetFieldDefinitionLabel()}?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Document");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectDocumentUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(projectDocumentUpdate, viewModel);
            }
            projectDocumentUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            projectDocumentUpdate.DeleteProjectDocumentUpdate();
            return new ModalDialogFormJsonResult();
        }
    }
}