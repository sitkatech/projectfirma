using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectDocument;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectDocumentController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminRegardlessOfStageFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new NewProjectDocumentViewModel(projectPrimaryKey.EntityObject);
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminRegardlessOfStageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, NewProjectDocumentViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            
            viewModel.UpdateModel(project, CurrentPerson);

            SetMessageForDisplay($"Successfully created new document \"{viewModel.DisplayName}\" for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.ProjectName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewProjectDocumentViewModel viewModel)
        {
            var viewData = new NewProjectDocumentViewData();
            return RazorPartialView<NewProjectDocument, NewProjectDocumentViewData, NewProjectDocumentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectDocumentEditAsAdminFeature]
        public PartialViewResult Edit(ProjectDocumentPrimaryKey projectDocumentPrimaryKey)
        {
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            var viewModel = new EditProjectDocumentsViewModel(projectDocument);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectDocumentEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectDocumentPrimaryKey projectDocumentPrimaryKey, EditProjectDocumentsViewModel viewModel)
        {
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            
            viewModel.UpdateModel(projectDocument);

            SetMessageForDisplay($"Successfully update document \"{projectDocument.DisplayName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditProjectDocumentsViewModel viewModel)
        {
            var viewData = new EditProjectDocumentsViewData();
            return RazorPartialView<EditProjectDocuments, EditProjectDocumentsViewData, EditProjectDocumentsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectDocumentEditAsAdminFeature]
        public PartialViewResult Delete(ProjectDocumentPrimaryKey projectDocumentPrimaryKey)
        {
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectDocument.ProjectDocumentID);
            return ViewDelete(projectDocument, viewModel);
        }

        [HttpPost]
        [ProjectDocumentEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProjectDocumentPrimaryKey projectDocumentPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            var project = projectDocument.Project;
            var displayName = projectDocument.DisplayName;
            if (!ModelState.IsValid)
            {
                return ViewDelete(projectDocument, viewModel);
            }

            projectDocument.FileResource.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Successfully deleted document \"{displayName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDelete(ProjectDocument projectDocument, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{projectDocument.DisplayName}\" from this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }
    }
}
