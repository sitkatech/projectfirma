using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectClassificationController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditFeature]
        public PartialViewResult EditProjectClassificationsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectClassificationSimples = GetProjectClassificationSimples(project);

            var viewModel = new EditProjectClassificationsForProjectViewModel(projectClassificationSimples);
            return ViewEditProjectClassificationsForProject(project, viewModel);
        }

        public static List<ProjectClassificationSimple> GetProjectClassificationSimples(Project project)
        {
            var selectedProjectClassifications = project.ProjectClassifications;

            var projectClassificationSimples =
                HttpRequestStorage.DatabaseEntities.Classifications.Select(x => new ProjectClassificationSimple { ClassificationID = x.ClassificationID }).ToList();

            foreach (var selectedClassification in selectedProjectClassifications)
            {
                var selectedSimple = projectClassificationSimples.Single(x => x.ClassificationID == selectedClassification.ClassificationID);
                selectedSimple.Selected = true;
                selectedSimple.ProjectClassificationNotes = selectedClassification.ProjectClassificationNotes;
            }

            return projectClassificationSimples;
        }


        [HttpPost]
        [ProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectClassificationsForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectClassificationsForProjectViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectClassificationsForProject(project, viewModel);
            }
            var currentProjectClassifications = viewModel.ProjectClassificationSimples;
            HttpRequestStorage.DatabaseEntities.ProjectClassifications.Load();
            viewModel.UpdateModel(project, currentProjectClassifications);
            return new ModalDialogFormJsonResult();
        }


        private PartialViewResult ViewEditProjectClassificationsForProject(Project project, EditProjectClassificationsForProjectViewModel viewModel)
        {
            var allClassifications = HttpRequestStorage.DatabaseEntities.Classifications.OrderBy(p => p.DisplayName).ToList();            
            var viewData = new EditProjectClassificationsForProjectViewData(project, allClassifications);
            return RazorPartialView<EditProjectClassificationsForProject, EditProjectClassificationsForProjectViewData, EditProjectClassificationsForProjectViewModel>(viewData, viewModel);}

    }
}