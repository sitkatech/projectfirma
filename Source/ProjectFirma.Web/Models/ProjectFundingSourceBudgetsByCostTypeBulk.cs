/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceBudgetBulk.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceBudgetsByCostTypeBulk
    {
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        // Only used by ExpectedFundingByCostType pages
        public bool? IsRelevant { get; set; }
        // Only used by ExpectedFundingByCostType pages
        public int? CostTypeID { get; set; }

        public List<CalendarYearBudgetAmounts> CalendarYearBudgets { get; set; }
        // if the Funding Type is "the same each year" there will not be a calendar year dimension
        public decimal? SecuredAmount { get; set; }
        public decimal? TargetedAmount { get; set; }


        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectFundingSourceBudgetsByCostTypeBulk()
        {
        }

        public ProjectFundingSourceBudgetsByCostTypeBulk(ProjectFundingSourceBudget projectFundingSourceBudget,
            List<ProjectFundingSourceBudget> projectFundingSourceBudgets,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectFundingSourceBudget.ProjectID;
            FundingSourceID = projectFundingSourceBudget.FundingSourceID;
            CalendarYearBudgets = new List<CalendarYearBudgetAmounts>();
            AddProjectFundingSourceBudgets(projectFundingSourceBudgets);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceBudgets.Select(x => x.CalendarYear).ToList();
            CalendarYearBudgets.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearBudgetAmounts(x, null, null)));
        }

        private ProjectFundingSourceBudgetsByCostTypeBulk(ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate,
            List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectFundingSourceBudgetUpdate.ProjectUpdateBatch.ProjectID;
            FundingSourceID = projectFundingSourceBudgetUpdate.FundingSourceID;
            CalendarYearBudgets = new List<CalendarYearBudgetAmounts>();
            AddProjectFundingSourceBudgetUpdates(projectFundingSourceBudgetUpdates);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceBudgetUpdates.Select(x => x.CalendarYear).ToList();
            CalendarYearBudgets.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearBudgetAmounts(x, null, null)));
        }

        private ProjectFundingSourceBudgetsByCostTypeBulk(int projectID, int fundingSourceID, int costTypeID,
            List<ProjectFundingSourceBudget> projectFundingSourceBudgets,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeID;
            CalendarYearBudgets = new List<CalendarYearBudgetAmounts>();
            IsRelevant = true;
            var calendarYearBudgetAmounts =
                projectFundingSourceBudgets.Select(projectFundingSourceBudget =>
                {
                    Check.Require(projectFundingSourceBudget.ProjectID == ProjectID && projectFundingSourceBudget.FundingSourceID == FundingSourceID,
                        "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
                    return new CalendarYearBudgetAmounts(projectFundingSourceBudget.CalendarYear ?? 0, projectFundingSourceBudget.SecuredAmount, projectFundingSourceBudget.TargetedAmount, true);
                }).ToList();
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceBudgets.Select(x => x.CalendarYear).ToList();
            calendarYearBudgetAmounts.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearBudgetAmounts(x, 0, 0, true)));
            CalendarYearBudgets = calendarYearBudgetAmounts;
        }

        private ProjectFundingSourceBudgetsByCostTypeBulk(int projectID, int fundingSourceID, int costTypeID,
            ProjectFundingSourceBudget projectFundingSourceBudget)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeID;
            IsRelevant = true;
            SecuredAmount = projectFundingSourceBudget.SecuredAmount;
            TargetedAmount = projectFundingSourceBudget.TargetedAmount;
            CalendarYearBudgets = new List<CalendarYearBudgetAmounts>();
        }
        private ProjectFundingSourceBudgetsByCostTypeBulk(int projectID, int fundingSourceID, int costTypeID,
            ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeID;
            IsRelevant = true;
            SecuredAmount = projectFundingSourceBudgetUpdate?.SecuredAmount;
            TargetedAmount = projectFundingSourceBudgetUpdate?.TargetedAmount;
            CalendarYearBudgets = new List<CalendarYearBudgetAmounts>();
        }
        private ProjectFundingSourceBudgetsByCostTypeBulk(int projectID, int fundingSourceID, int costTypeID, 
            List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeID;
            IsRelevant = true;
            var calendarYearMonetaryAmounts =
                projectFundingSourceBudgetUpdates.Select(projectFundingSourceBudgetUpdate =>
                {
                    Check.Require(projectFundingSourceBudgetUpdate.ProjectUpdateBatch.ProjectID == ProjectID && projectFundingSourceBudgetUpdate.FundingSourceID == FundingSourceID,
                        "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
                    return new CalendarYearBudgetAmounts(projectFundingSourceBudgetUpdate.CalendarYear ?? 0, projectFundingSourceBudgetUpdate.SecuredAmount, projectFundingSourceBudgetUpdate.TargetedAmount, true);
                }).ToList();
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceBudgetUpdates.Select(x => x.CalendarYear).ToList();
            calendarYearMonetaryAmounts.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearBudgetAmounts(x, 0, 0, true)));
            CalendarYearBudgets = calendarYearMonetaryAmounts;
        }

        public static List<ProjectFundingSourceBudgetsByCostTypeBulk> MakeFromList(List<ProjectFundingSourceBudget> projectFundingSourceBudgets, List<int> calendarYears)
        {
            var groupedByProjectFundingSource = projectFundingSourceBudgets.GroupBy(x => new {x.ProjectID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceBudgetsByCostTypeBulk(grouping.First(), grouping.ToList(), calendarYears)).ToList();
        }

        public static List<ProjectFundingSourceBudgetsByCostTypeBulk> MakeFromList(List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates, List<int> calendarYearsToPopulate)
        {
            var groupedByProjectFundingSource = projectFundingSourceBudgetUpdates.GroupBy(x => new {x.ProjectUpdateBatchID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceBudgetsByCostTypeBulk(grouping.First(), grouping.ToList(), calendarYearsToPopulate)).ToList();
        }

        public static List<ProjectFundingSourceBudgetsByCostTypeBulk> MakeFromListByCostType(Project project, List<int> calendarYearsToPopulate)
        {
            var projectID = project.ProjectID;
            var projectFundingSourceBudgetUpdates = project.ProjectFundingSourceBudgets.ToList();
            var distinctFundingSources = projectFundingSourceBudgetUpdates.Select(x => x.FundingSourceID).Distinct().ToList();
            var allCostTypeIDs = HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeID).ToList();
            var projectFundingSourceBudgetBulks = new List<ProjectFundingSourceBudgetsByCostTypeBulk>();
            foreach (var fundingSourceID in distinctFundingSources)
            {
                foreach (var costTypeID in allCostTypeIDs)
                {
                    var budgetsForThisFundingSourceAndCostType = projectFundingSourceBudgetUpdates.Where(x => x.FundingSourceID == fundingSourceID && x.CostTypeID == costTypeID).ToList();
                    if (budgetsForThisFundingSourceAndCostType.Count > 0)
                    {
                        projectFundingSourceBudgetBulks.Add(calendarYearsToPopulate.Any() 
                            ? new ProjectFundingSourceBudgetsByCostTypeBulk(projectID, fundingSourceID, costTypeID, budgetsForThisFundingSourceAndCostType, calendarYearsToPopulate)
                            : new ProjectFundingSourceBudgetsByCostTypeBulk(projectID, fundingSourceID, costTypeID, budgetsForThisFundingSourceAndCostType[0]));
                    }
                }
            }
            return projectFundingSourceBudgetBulks;
        }

        public static List<ProjectFundingSourceBudgetsByCostTypeBulk> MakeFromListByCostType(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearsToPopulate)
        {
            var projectID = projectUpdateBatch.ProjectID;
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList();
            var distinctFundingSources = projectFundingSourceBudgetUpdates.Select(x => x.FundingSourceID).Distinct().ToList();
            var allCostTypeIDs = HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeID).ToList();
            var projectFundingSourceBudgetBulks = new List<ProjectFundingSourceBudgetsByCostTypeBulk>();
            foreach (var fundingSourceID in distinctFundingSources)
            {
                foreach (var costTypeID in allCostTypeIDs)
                {
                    var budgetsForThisFundingSourceAndCostType = projectFundingSourceBudgetUpdates.Where(x => x.FundingSourceID == fundingSourceID && x.CostTypeID == costTypeID).ToList();
                    projectFundingSourceBudgetBulks.Add(calendarYearsToPopulate.Any()
                        ? new ProjectFundingSourceBudgetsByCostTypeBulk(projectID, fundingSourceID, costTypeID,
                            budgetsForThisFundingSourceAndCostType, calendarYearsToPopulate)
                        : new ProjectFundingSourceBudgetsByCostTypeBulk(projectID, fundingSourceID, costTypeID,
                            budgetsForThisFundingSourceAndCostType.Count > 0 ? budgetsForThisFundingSourceAndCostType[0] : null));
                }
            }
            return projectFundingSourceBudgetBulks;
        }

        public void AddProjectFundingSourceBudgets(List<ProjectFundingSourceBudget> projectFundingSourceBudgets)
        {
            projectFundingSourceBudgets.ForEach(AddProjectFundingSourceBudget);
        }

        public void AddProjectFundingSourceBudgetUpdates(List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates)
        {
            projectFundingSourceBudgetUpdates.ForEach(AddProjectFundingSourceBudgetUpdate);
        }

        public void AddProjectFundingSourceBudget(ProjectFundingSourceBudget projectFundingSourceBudget)
        {
            Check.Require(projectFundingSourceBudget.ProjectID == ProjectID && projectFundingSourceBudget.FundingSourceID == FundingSourceID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
            CalendarYearBudgets.Add(new CalendarYearBudgetAmounts(projectFundingSourceBudget.CalendarYear??0, projectFundingSourceBudget.SecuredAmount, projectFundingSourceBudget.TargetedAmount));
        }

        public void AddProjectFundingSourceBudgetUpdate(ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate)
        {
            Check.Require(projectFundingSourceBudgetUpdate.ProjectUpdateBatch.ProjectID == ProjectID && projectFundingSourceBudgetUpdate.FundingSourceID == FundingSourceID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
            CalendarYearBudgets.Add(new CalendarYearBudgetAmounts(projectFundingSourceBudgetUpdate.CalendarYear??0, projectFundingSourceBudgetUpdate.SecuredAmount, projectFundingSourceBudgetUpdate.TargetedAmount));
        }

        public List<ProjectFundingSourceBudget> ToProjectFundingSourceBudgets()
        {
            // ReSharper disable PossibleInvalidOperationException
            if (CalendarYearBudgets != null)
            {
                return
                    CalendarYearBudgets.Where(x => x.IsRelevant ?? false)
                        .Select(x => new ProjectFundingSourceBudget(ProjectID, FundingSourceID, x.CalendarYear, x.SecuredAmount ?? 0, x.TargetedAmount ?? 0, CostTypeID))
                        .ToList();
            }
            
            return new List<ProjectFundingSourceBudget>() {new ProjectFundingSourceBudget(ProjectID, FundingSourceID, null, SecuredAmount?? 0, TargetedAmount?? 0, CostTypeID) };
            
            // ReSharper restore PossibleInvalidOperationException
        }

        public List<ProjectFundingSourceBudgetUpdate> ToProjectFundingSourceBudgetUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            var fundingSource = HttpRequestStorage.DatabaseEntities.FundingSources.Single(x => x.FundingSourceID == FundingSourceID);
            if (projectUpdateBatch.ProjectUpdate.FundingType == FundingType.BudgetVariesByYear)
            {
                // ReSharper disable PossibleInvalidOperationException
                return
                    CalendarYearBudgets.Where(x => x.SecuredAmount.HasValue || x.TargetedAmount.HasValue)
                        .Select(x => new ProjectFundingSourceBudgetUpdate(projectUpdateBatch, fundingSource, x.CalendarYear, x.SecuredAmount ?? 0, x.TargetedAmount ?? 0, CostTypeID))
                        .ToList();
                // ReSharper restore PossibleInvalidOperationException
            }
            else
            {
                var projectFundingSourceBudgetUpdate =  new List<ProjectFundingSourceBudgetUpdate>(  );
                projectFundingSourceBudgetUpdate.Add(new ProjectFundingSourceBudgetUpdate(projectUpdateBatch, fundingSource, null, SecuredAmount ?? 0, TargetedAmount ?? 0, CostTypeID));
                return projectFundingSourceBudgetUpdate;
            }

        }
    }
}
