/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceBudgetController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectFundingSourceBudget;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFundingSourceBudgetController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectFundingSourceBudgetsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectFundingSourceBudgets = project.ProjectFundingSourceBudgets.ToList();
            var viewModel = new EditProjectFundingSourceBudgetViewModel(project, currentProjectFundingSourceBudgets);
            return ViewEditProjectFundingSourceBudgets(project, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectFundingSourceBudgetsForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectFundingSourceBudgetViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectFundingSourceBudgets = project.ProjectFundingSourceBudgets.ToList();
            if (!ModelState.IsValid)
            {
                return ViewEditProjectFundingSourceBudgets(project, viewModel);
            }
            return UpdateProjectFundingSourceBudgets(viewModel, project, currentProjectFundingSourceBudgets);
        }

        private static ActionResult UpdateProjectFundingSourceBudgets(EditProjectFundingSourceBudgetViewModel viewModel,
            Project project,
             List<ProjectFundingSourceBudget> currentProjectFundingSourceBudgets)
        {
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceBudgets.Load();
            var allProjectFundingSourceBudgets = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceBudgets.Local;
            viewModel.UpdateModel(project, currentProjectFundingSourceBudgets, allProjectFundingSourceBudgets);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectFundingSourceBudgets(Project project, EditProjectFundingSourceBudgetViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var fundingTypes = FundingType.All.ToList();
            var viewData = new EditProjectFundingSourceBudgetViewData(new ProjectSimple(project), fundingTypes, allFundingSources, project.PlanningDesignStartYear, project.CompletionYear);
            return RazorPartialView<EditProjectFundingSourceBudget, EditProjectFundingSourceBudgetViewData, EditProjectFundingSourceBudgetViewModel>(viewData, viewModel);
        }
    }
}