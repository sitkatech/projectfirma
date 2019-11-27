using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectInternalNoteController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            var projectInternalNote = ProjectInternalNote.CreateNewBlank(project);
            viewModel.UpdateModel(projectInternalNote, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllProjectInternalNotes.Add(projectInternalNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectInternalNoteManageAsAdminFeature]
        public PartialViewResult Edit(ProjectInternalNotePrimaryKey projectInternalNotePrimaryKey)
        {
            var projectInternalNote = projectInternalNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(projectInternalNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectInternalNoteManageAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectInternalNotePrimaryKey projectInternalNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectInternalNote = projectInternalNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectInternalNote, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectInternalNoteManageAsAdminFeature]
        public PartialViewResult DeleteProjectInternalNote(ProjectInternalNotePrimaryKey projectInternalNotePrimaryKey)
        {
            var projectInternalNote = projectInternalNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectInternalNote.ProjectInternalNoteID);
            return ViewDeleteProjectInternalNote(projectInternalNote, viewModel);
        }

        private PartialViewResult ViewDeleteProjectInternalNote(ProjectInternalNote projectInternalNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectInternalNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectInternalNote.Project.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.ProjectInternalNote.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectInternalNoteManageAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectInternalNote(ProjectInternalNotePrimaryKey projectInternalNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectInternalNote = projectInternalNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectInternalNote(projectInternalNote, viewModel);
            }
            projectInternalNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}