using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.ProjectFundingSourceExpenditure;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class ProjectFundingSourceExpenditureController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [ProjectFundingSourceExpenditureFromProjectManageFeature]
        public PartialViewResult EditProjectFundingSourceExpendituresForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRangeForExpenditures = currentProjectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var viewModel = new EditProjectFundingSourceExpendituresViewModel(currentProjectFundingSourceExpenditures, calendarYearRangeForExpenditures);
            return ViewEditProjectFundingSourceExpenditures(project, viewModel, calendarYearRangeForExpenditures);
        }

        [HttpPost]
        [ProjectFundingSourceExpenditureFromProjectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectFundingSourceExpendituresForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectFundingSourceExpendituresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            if (!ModelState.IsValid)
            {
                var calendarYearRangeForExpenditures = currentProjectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
                return ViewEditProjectFundingSourceExpenditures(project, viewModel, calendarYearRangeForExpenditures);
            }
            var currentProjectFundingOrganizations = project.ProjectFundingOrganizations.ToList();
            return UpdateProjectFundingSourceExpenditures(viewModel, currentProjectFundingSourceExpenditures, currentProjectFundingOrganizations);
        }

        [HttpGet]
        [ProjectFundingSourceExpenditureFromFundingSourceManageFeature]
        public PartialViewResult EditProjectFundingSourceExpendituresForFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var currentProjectFundingSourceExpenditures = fundingSource.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRangeForExpenditures = currentProjectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(fundingSource);
            var viewModel = new EditProjectFundingSourceExpendituresViewModel(currentProjectFundingSourceExpenditures, calendarYearRangeForExpenditures);
            return ViewEditProjectFundingSourceExpenditures(fundingSource, viewModel, calendarYearRangeForExpenditures);
        }

        [HttpPost]
        [ProjectFundingSourceExpenditureFromFundingSourceManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectFundingSourceExpendituresForFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey, EditProjectFundingSourceExpendituresViewModel viewModel)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var currentProjectFundingSourceExpenditures = fundingSource.ProjectFundingSourceExpenditures.ToList();
            if (!ModelState.IsValid)
            {
                var calendarYearRangeForExpenditures = currentProjectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(fundingSource);
                return ViewEditProjectFundingSourceExpenditures(fundingSource, viewModel, calendarYearRangeForExpenditures);
            }
            var currentProjectFundingOrganizations = fundingSource.Organization.ProjectFundingOrganizations.ToList();
            return UpdateProjectFundingSourceExpenditures(viewModel, currentProjectFundingSourceExpenditures, currentProjectFundingOrganizations);
        }

        private static ActionResult UpdateProjectFundingSourceExpenditures(EditProjectFundingSourceExpendituresViewModel viewModel,
            List<ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures,
            List<ProjectFundingOrganization> currentProjectFundingOrganizations)
        {
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Local;
            viewModel.UpdateModel(currentProjectFundingSourceExpenditures, allProjectFundingSourceExpenditures);

            var distinctProjectIDs = currentProjectFundingSourceExpenditures.Select(x => x.ProjectID).Distinct().ToList();
            ProjectFundingOrganization.SyncProjectFundingOrganizationsWithProjectFundingSourceExpenditures(distinctProjectIDs,
                currentProjectFundingSourceExpenditures,
                currentProjectFundingOrganizations);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectFundingSourceExpenditures(FundingSource fundingSource,
            EditProjectFundingSourceExpendituresViewModel viewModel,
            List<int> calendarYearRangeForExpenditures)
        {
            var allProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().Select(x => new ProjectSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var viewData = new EditProjectFundingSourceExpendituresViewData(new FundingSourceSimple(fundingSource), allProjects, calendarYearRangeForExpenditures);
            return RazorPartialView<EditProjectFundingSourceExpenditures, EditProjectFundingSourceExpendituresViewData, EditProjectFundingSourceExpendituresViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewEditProjectFundingSourceExpenditures(Project project, EditProjectFundingSourceExpendituresViewModel viewModel, List<int> calendarYearRangeForExpenditures)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var projectFundingOrganizationFundingSourceIDs = project.ProjectFundingOrganizations.SelectMany(x => x.Organization.FundingSources.Select(y => y.FundingSourceID));
            var viewData = new EditProjectFundingSourceExpendituresViewData(new ProjectSimple(project), allFundingSources, projectFundingOrganizationFundingSourceIDs, calendarYearRangeForExpenditures);
            return RazorPartialView<EditProjectFundingSourceExpenditures, EditProjectFundingSourceExpendituresViewData, EditProjectFundingSourceExpendituresViewModel>(viewData, viewModel);
        }
    }
}