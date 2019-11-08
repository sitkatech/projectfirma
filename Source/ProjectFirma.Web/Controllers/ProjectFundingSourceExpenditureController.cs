/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectFundingSourceExpenditure;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFundingSourceExpenditureController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectFundingSourceExpenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRangeForExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var projectFundingSourceExpenditureBulks = ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditures, calendarYearRangeForExpenditures);
            var viewModel = new EditProjectFundingSourceExpendituresViewModel(project, projectFundingSourceExpenditureBulks);
            return ViewEditProjectFundingSourceExpenditures(project, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectFundingSourceExpenditures(ProjectPrimaryKey projectPrimaryKey, EditProjectFundingSourceExpendituresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            if (!ModelState.IsValid)
            {
                return ViewEditProjectFundingSourceExpenditures(project, viewModel);
            }

            return UpdateProjectFundingSourceExpenditures(viewModel, currentProjectFundingSourceExpenditures, project);
        }

        private static ActionResult UpdateProjectFundingSourceExpenditures(
            EditProjectFundingSourceExpendituresViewModel viewModel,
            List<ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures, Project project)
        {
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            viewModel.UpdateModel(currentProjectFundingSourceExpenditures, allProjectFundingSourceExpenditures, project);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectFundingSourceExpenditures(Project project, EditProjectFundingSourceExpendituresViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var requiredCalendarYearRange = project.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();

            var viewDataForAngularClass = new ViewDataForAngularClass(project, allFundingSources, requiredCalendarYearRange);

            var viewData = new EditProjectFundingSourceExpendituresViewData(viewDataForAngularClass);
            return RazorPartialView<EditProjectFundingSourceExpenditures, EditProjectFundingSourceExpendituresViewData, EditProjectFundingSourceExpendituresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectFundingSourceExpendituresByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var calendarYearRange = project.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
            var costTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList();
            var projectRelevantCostTypes = project.GetExpendituresRelevantCostTypes().Select(x => new ProjectRelevantCostTypeSimple(x)).ToList();
            var currentRelevantCostTypeIDs = projectRelevantCostTypes.Select(x => x.CostTypeID).ToList();
            projectRelevantCostTypes.AddRange(
                costTypes.Where(x => !currentRelevantCostTypeIDs.Contains(x.CostTypeID))
                    .Select((x, index) => new ProjectRelevantCostTypeSimple(-(index + 1), project.ProjectID, x.CostTypeID, x.CostTypeName)));
            var viewModel = new EditProjectFundingSourceExpendituresByCostTypeViewModel(project, calendarYearRange, projectRelevantCostTypes);
            return ViewEditProjectFundingSourceExpendituresByCostType(project, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectFundingSourceExpendituresByCostType(ProjectPrimaryKey projectPrimaryKey, EditProjectFundingSourceExpendituresByCostTypeViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var calendarYearRange = project.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
            if (!ModelState.IsValid)
            {
                return ViewEditProjectFundingSourceExpendituresByCostType(project, calendarYearRange, viewModel);
            }
            viewModel.UpdateModel(project, HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectFundingSourceExpendituresByCostType(Project project, List<int> calendarYearRange, EditProjectFundingSourceExpendituresByCostTypeViewModel viewModel)
        {
            var showNoExpendituresExplanation = !string.IsNullOrWhiteSpace(project.ExpendituresNote);
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var allCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList().Select(x => new CostTypeSimple(x)).OrderBy(p => p.CostTypeName).ToList();
            var viewDataForAngularEditor = new EditProjectFundingSourceExpendituresByCostTypeViewData.ViewDataForAngularClass(project, allFundingSources, allCostTypes, calendarYearRange, showNoExpendituresExplanation);
            var viewData = new EditProjectFundingSourceExpendituresByCostTypeViewData(viewDataForAngularEditor);
            return RazorPartialView<EditProjectFundingSourceExpendituresByCostType, EditProjectFundingSourceExpendituresByCostTypeViewData, EditProjectFundingSourceExpendituresByCostTypeViewModel>(viewData, viewModel);
        }
    }
}
