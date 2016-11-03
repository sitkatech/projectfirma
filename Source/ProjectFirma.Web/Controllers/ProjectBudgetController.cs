using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectBudget;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectBudgetController : FirmaBaseController
    {
        [HttpGet]
        [ProjectBudgetManageFeature]
        public PartialViewResult EditBudgetsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectBudgets = project.ProjectBudgets.ToList();
            var calendarYearRangeForExpenditures = currentProjectBudgets.CalculateCalendarYearRangeForBudgets(project);
            var viewModel = new EditProjectBudgetsViewModel(currentProjectBudgets, calendarYearRangeForExpenditures);
            return ViewEditProjectBudgets(project, viewModel, calendarYearRangeForExpenditures);
        }

        [HttpPost]
        [ProjectBudgetManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBudgetsForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectBudgetsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectBudgets = project.ProjectBudgets.ToList();
            if (!ModelState.IsValid)
            {
                var calendarYearRangeForExpenditures = currentProjectBudgets.CalculateCalendarYearRangeForBudgets(project);
                return ViewEditProjectBudgets(project, viewModel, calendarYearRangeForExpenditures);
            }
            var currentProjectFundingOrganizations = project.ProjectFundingOrganizations.ToList();
            return UpdateProjectBudgets(viewModel, currentProjectBudgets, currentProjectFundingOrganizations);
        }

        private static ActionResult UpdateProjectBudgets(EditProjectBudgetsViewModel viewModel,
            List<ProjectBudget> currentProjectBudgets,
            List<ProjectFundingOrganization> currentProjectFundingOrganizations)
        {
            HttpRequestStorage.DatabaseEntities.ProjectBudgets.Load();
            var allProjectBudgets = HttpRequestStorage.DatabaseEntities.ProjectBudgets.Local;
            viewModel.UpdateModel(currentProjectBudgets, allProjectBudgets);

            var distinctProjectIDs = currentProjectBudgets.Select(x => x.ProjectID).Distinct().ToList();
            ProjectFundingOrganization.SyncProjectFundingOrganizationsWithProjectFundingSourceExpenditures(distinctProjectIDs, currentProjectBudgets, currentProjectFundingOrganizations);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectBudgets(Project project, EditProjectBudgetsViewModel viewModel, List<int> calendarYearRangeForExpenditures)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var projectFundingOrganizationFundingSourceIDs = project.ProjectFundingOrganizations.SelectMany(x => x.Organization.FundingSources.Select(y => y.FundingSourceID));
            var ProjectCostTypeSimples = ProjectCostType.All.Select(x => new ProjectCostTypeSimple(x)).ToList();
            var viewData = new EditProjectBudgetsViewData(project, allFundingSources, ProjectCostTypeSimples, projectFundingOrganizationFundingSourceIDs, calendarYearRangeForExpenditures);
            return RazorPartialView<EditProjectBudgets, EditProjectBudgetsViewData, EditProjectBudgetsViewModel>(viewData, viewModel);
        }
    }
}