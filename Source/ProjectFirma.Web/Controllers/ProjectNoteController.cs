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
    public class ProjectNoteController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [ProjectNoteCreateFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectNoteCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            var projectNote = ProjectNote.CreateNewBlank(project);
            viewModel.UpdateModel(projectNote, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.ProjectNotes.Add(projectNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectNoteManageFeature]
        public PartialViewResult Edit(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(projectNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectNotePrimaryKey projectNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectNote = projectNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectNote, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectNoteManageFeature]
        public PartialViewResult DeleteProjectNote(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectNote.ProjectNoteID);
            return ViewDeleteProjectNote(projectNote, viewModel);
        }

        private PartialViewResult ViewDeleteProjectNote(ProjectNote projectNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this note for project '{0}'?", projectNote.Project.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Project Note");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectNote(ProjectNotePrimaryKey projectNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectNote(projectNote, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectNotes.Remove(projectNote);
            return new ModalDialogFormJsonResult();
        }
    }
}