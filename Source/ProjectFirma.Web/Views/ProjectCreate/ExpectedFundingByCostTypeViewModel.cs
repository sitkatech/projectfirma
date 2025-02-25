﻿/*-----------------------------------------------------------------------
<copyright file="ExpectedFundingByCostTypeViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpectedFundingByCostTypeViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        public int? FundingTypeID { get; set; }

        public List<ProjectFundingSourceBudgetsByCostTypeBulk> ProjectFundingSourceBudgets { get; set; }

        public List<ProjectRelevantCostTypeSimple> ProjectRelevantCostTypes { get; set; }

        public List<CalendarYearMonetaryAmount> NoFundingSourceAmounts { get; set; }

        public decimal? NoFundingSourceIdentifiedYet { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedFundingByCostTypeViewModel()
        {
        }

        public ExpectedFundingByCostTypeViewModel(ProjectFirmaModels.Models.Project project, List<int> calendarYearsToPopulate, List<ProjectRelevantCostTypeSimple> projectRelevantCostTypes)
        {
            FundingTypeID = project.FundingTypeID;
            ProjectRelevantCostTypes = projectRelevantCostTypes;
            var calendarYearMonetaryAmounts = new List<CalendarYearMonetaryAmount>();
            if (project.FundingTypeID.HasValue)
            {
                switch (project.FundingType.ToEnum)
                {
                    case FundingTypeEnum.BudgetVariesByYear:
                    {
                        ProjectFundingSourceBudgets = ProjectFundingSourceBudgetsByCostTypeBulk.MakeFromListByCostType(project, calendarYearsToPopulate);

                        var projectNoFundingSourceIdentifieds =
                            project.ProjectNoFundingSourceIdentifieds.ToList();
                        projectNoFundingSourceIdentifieds.ForEach(x =>
                            calendarYearMonetaryAmounts.Add(new CalendarYearMonetaryAmount(x.CalendarYear.Value,
                                x.NoFundingSourceIdentifiedYet)));
                        var usedCalendarYears = projectNoFundingSourceIdentifieds.Select(x => x.CalendarYear).ToList();
                        calendarYearMonetaryAmounts.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x))
                            .ToList().Select(x => new CalendarYearMonetaryAmount(x, 0)));
                        break;
                    }

                    case FundingTypeEnum.BudgetSameEachYear:
                        ProjectFundingSourceBudgets = ProjectFundingSourceBudgetsByCostTypeBulk.MakeFromListByCostType(project, new List<int>());
                        NoFundingSourceIdentifiedYet = project.ProjectNoFundingSourceIdentifieds.FirstOrDefault()?.NoFundingSourceIdentifiedYet;  
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            NoFundingSourceAmounts = calendarYearMonetaryAmounts;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, DatabaseEntities databaseEntities)
        {
            var currentProjectFundingSourceBudgets = project.ProjectFundingSourceBudgets.ToList();
            databaseEntities.ProjectFundingSourceBudgets.Load();
            var allProjectFundingSourceBudgets = databaseEntities.AllProjectFundingSourceBudgets.Local;
            var currentProjectNoFundingSourceIdentifieds = project.ProjectNoFundingSourceIdentifieds.ToList();
            databaseEntities.ProjectNoFundingSourceIdentifieds.Load();
            var allProjectNoFundingSourceIdentifieds = HttpRequestStorage.DatabaseEntities.AllProjectNoFundingSourceIdentifieds.Local;

            project.FundingTypeID = FundingTypeID;

            var projectFundingSourceBudgetsUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceBudget>();
            if (ProjectFundingSourceBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceBudgetsUpdated = ProjectFundingSourceBudgets.Where(x => x.IsRelevant ?? false).SelectMany(x => x.ToProjectFundingSourceBudgets()).ToList();
            }
            currentProjectFundingSourceBudgets.Merge(projectFundingSourceBudgetsUpdated,
                allProjectFundingSourceBudgets,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.SetSecuredAndTargetedAmounts(y.SecuredAmount, y.TargetedAmount), databaseEntities);

            var projectNoFundingSourceAmountsUpdated = new List<ProjectNoFundingSourceIdentified>();
            if (FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID && NoFundingSourceIdentifiedYet != null)
            {
                // Completely rebuild the list
                projectNoFundingSourceAmountsUpdated.Add(new ProjectNoFundingSourceIdentified(project.ProjectID) { NoFundingSourceIdentifiedYet = NoFundingSourceIdentifiedYet });
            }
            else if (FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID && NoFundingSourceAmounts != null)
            {
                // Completely rebuild the list
                projectNoFundingSourceAmountsUpdated = NoFundingSourceAmounts.Where(x => x.MonetaryAmount.HasValue)
                    .Select(x =>
                        new ProjectNoFundingSourceIdentified(project.ProjectID) { CalendarYear = x.CalendarYear, NoFundingSourceIdentifiedYet = x.MonetaryAmount.Value })
                    .ToList();
            }
            currentProjectNoFundingSourceIdentifieds.Merge(projectNoFundingSourceAmountsUpdated,
                allProjectNoFundingSourceIdentifieds,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.NoFundingSourceIdentifiedYet = y.NoFundingSourceIdentifiedYet, databaseEntities);

            var currentProjectRelevantCostTypes = project.GetBudgetsRelevantCostTypes();
            var allProjectRelevantCostTypes = databaseEntities.AllProjectRelevantCostTypes.Local;
            var projectRelevantCostTypes = new List<ProjectRelevantCostType>();
            if (ProjectRelevantCostTypes != null)
            {
                // Completely rebuild the list
                projectRelevantCostTypes =
                    ProjectRelevantCostTypes.Where(x => x.IsRelevant)
                        .Select(x => new ProjectRelevantCostType(x.ProjectRelevantCostTypeID, x.ProjectID, x.CostTypeID, ProjectRelevantCostTypeGroup.Budgets.ProjectRelevantCostTypeGroupID))
                        .ToList();
            }
            currentProjectRelevantCostTypes.Merge(projectRelevantCostTypes,
                allProjectRelevantCostTypes,
                (x, y) => x.ProjectID == y.ProjectID && x.CostTypeID == y.CostTypeID && x.ProjectRelevantCostTypeGroupID == y.ProjectRelevantCostTypeGroupID, databaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (ProjectFundingSourceBudgets == null)
            {
                ProjectFundingSourceBudgets = new List<ProjectFundingSourceBudgetsByCostTypeBulk>();
            }
            if (FundingTypeID.HasValue && ProjectFundingSourceBudgets.Any())
            {
                // need to make sure there is at least one relevant cost type selected
                var projectFundingSourceBudgetBulks = ProjectFundingSourceBudgets.Where(x => x.IsRelevant ?? false).ToList();
                if (!projectFundingSourceBudgetBulks.Any())
                {
                    errors.Add(new ValidationResult($"Select a {FieldDefinitionEnum.CostType.ToType().GetFieldDefinitionLabel()} or remove the {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}"));
                }
            }
            return errors;
        }
    }
}