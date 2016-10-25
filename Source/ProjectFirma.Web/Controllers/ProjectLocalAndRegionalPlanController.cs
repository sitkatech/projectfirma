using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectLocalAndRegionalPlan;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectLocalAndRegionalPlanController : FirmaBaseController
    {
        [HttpGet]
        [ProjectLocalAndRegionalPlanManageFromProjectFeature]
        public PartialViewResult EditLocalAndRegionalPlans(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var localAndRegionalPlanIDs = project.ProjectLocalAndRegionalPlans.Select(x => new ProjectLocalAndRegionalPlanSimple(x)).ToList();
            var viewModel = new EditProjectLocalAndRegionalPlansViewModel(localAndRegionalPlanIDs);
            return ViewEditProjectLocalAndRegionalPlans(project, viewModel);
        }

        [HttpPost]
        [ProjectLocalAndRegionalPlanManageFromProjectFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditLocalAndRegionalPlans(ProjectPrimaryKey projectPrimaryKey, EditProjectLocalAndRegionalPlansViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectLocalAndRegionalPlans(project, viewModel);
            }
            var currentProjectLocalAndRegionalPlans = project.ProjectLocalAndRegionalPlans.ToList();
            return UpdateProjectLocalAndRegionalPlans(viewModel, currentProjectLocalAndRegionalPlans);
        }

        private static ActionResult UpdateProjectLocalAndRegionalPlans(EditProjectLocalAndRegionalPlansViewModel viewModel, List<ProjectLocalAndRegionalPlan> currentProjectLocalAndRegionalPlans)
        {
            HttpRequestStorage.DatabaseEntities.ProjectLocalAndRegionalPlans.Load();
            var allProjectLocalAndRegionalPlans = HttpRequestStorage.DatabaseEntities.ProjectLocalAndRegionalPlans.Local;
            viewModel.UpdateModel(currentProjectLocalAndRegionalPlans, allProjectLocalAndRegionalPlans);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectLocalAndRegionalPlans(Project project, EditProjectLocalAndRegionalPlansViewModel viewModel)
        {
            var relevantLocalAndRegionalPlans = GetRelevantLocalAndRegionalPlans(project);
            var viewData = new EditProjectLocalAndRegionalPlansViewData(project, relevantLocalAndRegionalPlans);
            return RazorPartialView<EditProjectLocalAndRegionalPlans, EditProjectLocalAndRegionalPlansViewData, EditProjectLocalAndRegionalPlansViewModel>(viewData, viewModel);
        }

        private static List<LocalAndRegionalPlanSimple> GetRelevantLocalAndRegionalPlans(Project project)
        {
            var allLocalAndRegionalPlans = HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.ToList().Select(x => new LocalAndRegionalPlanSimple(x)).ToList();
            var relevantLocalAndRegionalPlans =
                allLocalAndRegionalPlans.Where(
                    x => (
                        project.IsTransportationProject ||
                        !x.IsTransportationPlan ||
                        project.ProjectLocalAndRegionalPlans.Select(y => y.LocalAndRegionalPlanID).Contains(x.LocalAndRegionalPlanID)));
            return relevantLocalAndRegionalPlans.OrderBy(p => p.DisplayName).ToList();
        }
    }
}