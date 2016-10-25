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
    public class ProjectThresholdCategoryController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditFeature]
        public PartialViewResult EditProjectThresholdCategoriesForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectThresholdCategorySimples = GetProjectThresholdCategorySimples(project);

            var viewModel = new EditProjectThresholdCategoriesForProjectViewModel(projectThresholdCategorySimples);
            return ViewEditProjectThresholdCategoriesForProject(project, viewModel);
        }

        public static List<ProjectThresholdCategorySimple> GetProjectThresholdCategorySimples(Project project)
        {
            var selectedProjectThresholdCategories = project.ProjectThresholdCategories;

            var projectThresholdCategorySimples =
                HttpRequestStorage.DatabaseEntities.ThresholdCategories.Select(x => new ProjectThresholdCategorySimple { ThresholdCategoryID = x.ThresholdCategoryID }).ToList();

            foreach (var selectedThresholdCategory in selectedProjectThresholdCategories)
            {
                var selectedSimple = projectThresholdCategorySimples.Single(x => x.ThresholdCategoryID == selectedThresholdCategory.ThresholdCategoryID);
                selectedSimple.Selected = true;
                selectedSimple.ProjectThresholdCategoryNotes = selectedThresholdCategory.ProjectThresholdCategoryNotes;
            }

            return projectThresholdCategorySimples;
        }


        [HttpPost]
        [ProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectThresholdCategoriesForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectThresholdCategoriesForProjectViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectThresholdCategoriesForProject(project, viewModel);
            }
            var currentProjectThresholdCategories = viewModel.ProjectThresholdCategorySimples;
            HttpRequestStorage.DatabaseEntities.ProjectThresholdCategories.Load();
            viewModel.UpdateModel(project, currentProjectThresholdCategories);
            return new ModalDialogFormJsonResult();
        }


        private PartialViewResult ViewEditProjectThresholdCategoriesForProject(Project project, EditProjectThresholdCategoriesForProjectViewModel viewModel)
        {
            var allThresholdCategories = HttpRequestStorage.DatabaseEntities.ThresholdCategories.OrderBy(p => p.DisplayName).ToList();            
            var viewData = new EditProjectThresholdCategoriesForProjectViewData(project, allThresholdCategories);
            return RazorPartialView<EditProjectThresholdCategoriesForProject, EditProjectThresholdCategoriesForProjectViewData, EditProjectThresholdCategoriesForProjectViewModel>(viewData, viewModel);}

    }
}