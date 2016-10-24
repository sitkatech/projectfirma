using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.TransportationProjectBudget;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class TransportationProjectBudgetController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [TransportationProjectBudgetManageFeature]
        public PartialViewResult EditBudgetsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentTransportationProjectBudgets = project.TransportationProjectBudgets.ToList();
            var calendarYearRangeForExpenditures = currentTransportationProjectBudgets.CalculateCalendarYearRangeForBudgets(project);
            var viewModel = new EditTransportationProjectBudgetsViewModel(currentTransportationProjectBudgets, calendarYearRangeForExpenditures);
            return ViewEditTransportationProjectBudgets(project, viewModel, calendarYearRangeForExpenditures);
        }

        [HttpPost]
        [TransportationProjectBudgetManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBudgetsForProject(ProjectPrimaryKey projectPrimaryKey, EditTransportationProjectBudgetsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentTransportationProjectBudgets = project.TransportationProjectBudgets.ToList();
            if (!ModelState.IsValid)
            {
                var calendarYearRangeForExpenditures = currentTransportationProjectBudgets.CalculateCalendarYearRangeForBudgets(project);
                return ViewEditTransportationProjectBudgets(project, viewModel, calendarYearRangeForExpenditures);
            }
            var currentProjectFundingOrganizations = project.ProjectFundingOrganizations.ToList();
            return UpdateTransportationProjectBudgets(viewModel, currentTransportationProjectBudgets, currentProjectFundingOrganizations);
        }

        private static ActionResult UpdateTransportationProjectBudgets(EditTransportationProjectBudgetsViewModel viewModel,
            List<TransportationProjectBudget> currentTransportationProjectBudgets,
            List<ProjectFundingOrganization> currentProjectFundingOrganizations)
        {
            HttpRequestStorage.DatabaseEntities.TransportationProjectBudgets.Load();
            var allTransportationProjectBudgets = HttpRequestStorage.DatabaseEntities.TransportationProjectBudgets.Local;
            viewModel.UpdateModel(currentTransportationProjectBudgets, allTransportationProjectBudgets);

            var distinctProjectIDs = currentTransportationProjectBudgets.Select(x => x.ProjectID).Distinct().ToList();
            ProjectFundingOrganization.SyncProjectFundingOrganizationsWithProjectFundingSourceExpenditures(distinctProjectIDs, currentTransportationProjectBudgets, currentProjectFundingOrganizations);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditTransportationProjectBudgets(Project project, EditTransportationProjectBudgetsViewModel viewModel, List<int> calendarYearRangeForExpenditures)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var projectFundingOrganizationFundingSourceIDs = project.ProjectFundingOrganizations.SelectMany(x => x.Organization.FundingSources.Select(y => y.FundingSourceID));
            var transportationProjectCostTypeSimples = TransportationProjectCostType.All.Select(x => new TransportationProjectCostTypeSimple(x)).ToList();
            var viewData = new EditTransportationProjectBudgetsViewData(project, allFundingSources, transportationProjectCostTypeSimples, projectFundingOrganizationFundingSourceIDs, calendarYearRangeForExpenditures);
            return RazorPartialView<EditTransportationProjectBudgets, EditTransportationProjectBudgetsViewData, EditTransportationProjectBudgetsViewModel>(viewData, viewModel);
        }
    }
}