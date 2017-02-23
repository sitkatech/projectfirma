/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetController.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectBudget;
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
            var allProjectBudgets = HttpRequestStorage.DatabaseEntities.AllProjectBudgets.Local;
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
