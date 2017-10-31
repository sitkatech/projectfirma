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
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectFundingSourceExpenditure;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFundingSourceExpenditureController : FirmaBaseController
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

            return UpdateProjectFundingSourceExpenditures(viewModel, currentProjectFundingSourceExpenditures);
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

            return UpdateProjectFundingSourceExpenditures(viewModel, currentProjectFundingSourceExpenditures);
        }

        private static ActionResult UpdateProjectFundingSourceExpenditures(EditProjectFundingSourceExpendituresViewModel viewModel,
            List<ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures)
        {
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            viewModel.UpdateModel(currentProjectFundingSourceExpenditures, allProjectFundingSourceExpenditures);

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
            var viewData = new EditProjectFundingSourceExpendituresViewData(new ProjectSimple(project), allFundingSources, calendarYearRangeForExpenditures);
            return RazorPartialView<EditProjectFundingSourceExpenditures, EditProjectFundingSourceExpendituresViewData, EditProjectFundingSourceExpendituresViewModel>(viewData, viewModel);
        }
    }
}
