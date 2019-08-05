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
    public class ProjectFundingSourceBudgetBulk
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
        public ProjectFundingSourceBudgetBulk()
        {
        }

        public ProjectFundingSourceBudgetBulk(ProjectFundingSourceBudget projectFundingSourceBudget,
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

        private ProjectFundingSourceBudgetBulk(ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate,
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

        private ProjectFundingSourceBudgetBulk(int projectID, int fundingSourceID, int costTypeID,
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

        private ProjectFundingSourceBudgetBulk(int projectID, int fundingSourceID, int costTypeID,
            ProjectFundingSourceBudget projectFundingSourceBudget)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeID;
            SecuredAmount = projectFundingSourceBudget.SecuredAmount;
            TargetedAmount = projectFundingSourceBudget.TargetedAmount;
            CalendarYearBudgets = new List<CalendarYearBudgetAmounts>();
        }

        private ProjectFundingSourceBudgetBulk(int projectID, int fundingSourceID, int costTypeID, 
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

        public static List<ProjectFundingSourceBudgetBulk> MakeFromList(List<ProjectFundingSourceBudget> projectFundingSourceBudgets, List<int> calendarYears)
        {
            var groupedByProjectFundingSource = projectFundingSourceBudgets.GroupBy(x => new {x.ProjectID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceBudgetBulk(grouping.First(), grouping.ToList(), calendarYears)).ToList();
        }

        public static List<ProjectFundingSourceBudgetBulk> MakeFromList(List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates, List<int> calendarYearsToPopulate)
        {
            var groupedByProjectFundingSource = projectFundingSourceBudgetUpdates.GroupBy(x => new {x.ProjectUpdateBatchID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceBudgetBulk(grouping.First(), grouping.ToList(), calendarYearsToPopulate)).ToList();
        }

        public static List<ProjectFundingSourceBudgetBulk> MakeFromListByCostType(Project project, List<int> calendarYearsToPopulate)
        {
            var projectID = project.ProjectID;
            var projectFundingSourceBudgetUpdates = project.ProjectFundingSourceBudgets.ToList();
            var distinctFundingSources = projectFundingSourceBudgetUpdates.Select(x => x.FundingSourceID).Distinct().ToList();
            var allCostTypeIDs = HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeID).ToList();
            var projectFundingSourceBudgetBulks = new List<ProjectFundingSourceBudgetBulk>();
            foreach (var fundingSourceID in distinctFundingSources)
            {
                foreach (var costTypeID in allCostTypeIDs)
                {
                    var budgetsForThisFundingSourceAndCostType = projectFundingSourceBudgetUpdates.Where(x => x.FundingSourceID == fundingSourceID && x.CostTypeID == costTypeID).ToList();
                    projectFundingSourceBudgetBulks.Add(new ProjectFundingSourceBudgetBulk(projectID, fundingSourceID, costTypeID, budgetsForThisFundingSourceAndCostType, calendarYearsToPopulate));
                }
            }
            return projectFundingSourceBudgetBulks;
        }

        public static List<ProjectFundingSourceBudgetBulk> MakeFromListByCostType(Project project)
        {
            var projectID = project.ProjectID;
            var projectFundingSourceBudgetUpdates = project.ProjectFundingSourceBudgets.ToList();
            var distinctFundingSources = projectFundingSourceBudgetUpdates.Select(x => x.FundingSourceID).Distinct().ToList();
            var allCostTypeIDs = HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeID).ToList();
            var projectFundingSourceBudgetBulks = new List<ProjectFundingSourceBudgetBulk>();
            foreach (var fundingSourceID in distinctFundingSources)
            {
                foreach (var costTypeID in allCostTypeIDs)
                {
                    var budgetsForThisFundingSourceAndCostType = projectFundingSourceBudgetUpdates.Where(x => x.FundingSourceID == fundingSourceID && x.CostTypeID == costTypeID).ToList();
                    if (budgetsForThisFundingSourceAndCostType.Count > 0)
                    {
                        projectFundingSourceBudgetBulks.Add(new ProjectFundingSourceBudgetBulk(projectID,
                            fundingSourceID, costTypeID, budgetsForThisFundingSourceAndCostType[0]));
                    }
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
                    CalendarYearBudgets
                        .Select(x => new ProjectFundingSourceBudget(ProjectID, FundingSourceID, x.CalendarYear, x.SecuredAmount ?? 0, x.TargetedAmount ?? 0, CostTypeID))
                        .ToList();
            }
            
            return new List<ProjectFundingSourceBudget>() {new ProjectFundingSourceBudget(ProjectID, FundingSourceID, null, SecuredAmount.Value, TargetedAmount.Value, CostTypeID) };
            
            // ReSharper restore PossibleInvalidOperationException
        }

        public List<ProjectFundingSourceBudgetUpdate> ToProjectFundingSourceBudgetUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearBudgets.Where(x => x.SecuredAmount.HasValue || x.TargetedAmount.HasValue)
                    .Select(x => new ProjectFundingSourceBudgetUpdate(projectUpdateBatch.ProjectUpdateBatchID, FundingSourceID, x.CalendarYear, x.SecuredAmount.Value, x.TargetedAmount.Value, CostTypeID))
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }
    }
}
