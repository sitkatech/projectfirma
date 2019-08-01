/*-----------------------------------------------------------------------
<copyright file="ExpendituresByCostTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpectedFundingByCostTypeViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        public int FundingTypeID { get; set; }

        public List<ProjectFundingSourceBudgetBulk> ProjectFundingSourceBudgets { get; set; }

        public List<CalendarYearMonetaryAmount> NoFundingSourceAmounts { get; set; }

        public decimal? NoFundingSourceIdentifiedYet { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedFundingByCostTypeViewModel()
        {
        }

        public ExpectedFundingByCostTypeViewModel(ProjectFirmaModels.Models.Project project, List<int> calendarYearsToPopulate)
        {
            ProjectID = project.ProjectID;
            FundingTypeID = project.FundingTypeID ?? 0;
            if (FundingTypeID == 0 || FundingTypeID == 1)
            {
                ProjectFundingSourceBudgets = ProjectFundingSourceBudgetBulk.MakeFromListByCostType(project, calendarYearsToPopulate);

                NoFundingSourceAmounts = new List<CalendarYearMonetaryAmount>();
                List<ProjectNoFundingSourceIdentified> projectNoFundingSourceIdentifieds = project.ProjectNoFundingSourceIdentifieds.ToList();
                projectNoFundingSourceIdentifieds.ForEach(x => NoFundingSourceAmounts.Add(new CalendarYearMonetaryAmount(x.CalendarYear, x.NoFundingSourceIdentifiedYet)));
                var usedCalendarYears = projectNoFundingSourceIdentifieds.Select(x => x.CalendarYear).ToList();
                NoFundingSourceAmounts.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
            }
            else
            {
                ProjectFundingSourceBudgets = ProjectFundingSourceBudgetBulk.MakeFromListByCostType(project);
                NoFundingSourceIdentifiedYet = project.NoFundingSourceIdentifiedYet;
                // instantiating to prevent NPE
//                NoFundingSourceAmounts = new List<CalendarYearMonetaryAmount>();
            }
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> currentProjectFundingSourceBudgets,
            IList<ProjectFirmaModels.Models.ProjectFundingSourceBudget> allProjectFundingSourceBudgets,
            List<ProjectNoFundingSourceIdentified> currentProjectNoFundingSourceIdentifieds,
            IList<ProjectNoFundingSourceIdentified> allProjectNoFundingSourceIdentifieds)
        {
            if (FundingTypeID > 0)
            {
                project.FundingTypeID = FundingTypeID;
            }


            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            databaseEntities.ProjectExemptReportingYearUpdates.Load();
            var projectFundingSourceBudgetsUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceBudget>();
            if (ProjectFundingSourceBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceBudgetsUpdated = ProjectFundingSourceBudgets.SelectMany(x => x.ToProjectFundingSourceBudgets()).ToList();
            }


            //            currentProjectFundingSourceBudgets.Merge(projectFundingSourceBudgetsUpdated,
            //                allProjectFundingSourceBudgets,
            //                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
            //                (x, y) => x.SecuredAmount = y.SecuredAmount, databaseEntities);
            //            currentProjectFundingSourceBudgets.Merge(projectFundingSourceBudgetsUpdated,
            //                allProjectFundingSourceBudgets,
            //                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
            //                (x, y) => x.TargetedAmount = y.TargetedAmount, databaseEntities);
            currentProjectFundingSourceBudgets.Merge(projectFundingSourceBudgetsUpdated,
                allProjectFundingSourceBudgets,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.SetSecuredAndTargetedAmounts(y.SecuredAmount, y.TargetedAmount), databaseEntities);


            if (FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID)
            {
                project.NoFundingSourceIdentifiedYet = NoFundingSourceIdentifiedYet;
            }
            else
            {
                var projectNoFundingSourceAmountsUpdated = new List<ProjectNoFundingSourceIdentified>();
                if (NoFundingSourceAmounts != null)
                {
                    // Completely rebuild the list
                    projectNoFundingSourceAmountsUpdated = NoFundingSourceAmounts.Where(x => x.MonetaryAmount.HasValue)
                        .Select(x =>
                            new ProjectNoFundingSourceIdentified(ProjectID, x.CalendarYear, x.MonetaryAmount.Value))
                        .ToList();
                }
                currentProjectNoFundingSourceIdentifieds.Merge(projectNoFundingSourceAmountsUpdated,
                    allProjectNoFundingSourceIdentifieds,
                    (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear,
                    (x, y) => x.NoFundingSourceIdentifiedYet = y.NoFundingSourceIdentifiedYet, databaseEntities);
            }

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var partialRows = ProjectFundingSourceBudgets?.Where(x =>
                x.CalendarYearBudgets.Any(y => y.SecuredAmount.HasValue || y.TargetedAmount.HasValue));
            if (FundingTypeID == 0 && (NoFundingSourceAmounts.Any(x => x.MonetaryAmount != null) || (partialRows?.Any() ?? false)))
            {
                errors.Add(new ValidationResult($"You must answer the question \"Does the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} budget vary by year or is it the same?\" when entering any funding values."));
            }

            if (FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID)
            {
                var emptyRows = ProjectFundingSourceBudgets?.Where(x =>
                    x.CalendarYearBudgets.Any(y => !y.SecuredAmount.HasValue || !y.TargetedAmount.HasValue));

                if (emptyRows?.Any() ?? false)
                {
                    errors.Add(new ValidationResult(
                        $"{FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel()} and {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} cannot be blank for any year. " +
                        $"If the amount is unknown, you can enter zero ($0), or delete {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()} for which there is no budget data to report."));
                }
            }

            if (FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID && NoFundingSourceAmounts.Any(x => x.MonetaryAmount == null))
            {
                errors.Add(new ValidationResult($"{FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel()} cannot be blank for any year. If the amount is unknown, you can enter zero ($0)."));
            }

            if (FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID && (ProjectFundingSourceBudgets?.Any(x => !x.SecuredAmount.HasValue || !x.TargetedAmount.HasValue)?? false))
            {
                errors.Add(new ValidationResult(
                    $"{FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel()} and {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} cannot be blank for any {FieldDefinitionEnum.CostType.ToType().GetFieldDefinitionLabel()}. " +
                    $"If the amount is unknown, you can enter zero ($0), or delete {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()} for which there is no budget data to report."));
            }

            if (FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID && NoFundingSourceIdentifiedYet == null)
            {
                errors.Add(new ValidationResult($"{FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel()} cannot be blank. If the amount is unknown, you can enter zero ($0)."));
            }

            return errors;
        }
    }
}