using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

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
            viewModel.UpdateModel(projectNoteUpdate, CurrentPerson);
            projectNoteUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            HttpRequestStorage.DatabaseEntities.ProjectNoteUpdates.Add(projectNoteUpdate);
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
            viewModel.UpdateModel(projectNoteUpdate, CurrentPerson);
            projectNoteUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
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
                ? string.Format("Are you sure you want to delete this note for project '{0}'?", projectNoteUpdate.ProjectUpdateBatch.Project.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Project Note");

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
            projectNoteUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            HttpRequestStorage.DatabaseEntities.ProjectNoteUpdates.Remove(projectNoteUpdate);
            return new ModalDialogFormJsonResult();
        }
    }
}