/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureBulk.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public class ProjectFundingSourceExpenditureBulk
    {
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }

        // Only used by ExpendituredByCostType pages
        public bool? IsRelevant { get; set; }
        // Only used by ExpendituredByCostType pages
        public int? CostTypeID { get; set; }

        public List<CalendarYearMonetaryAmount> CalendarYearExpenditures { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectFundingSourceExpenditureBulk()
        {
        }

        public ProjectFundingSourceExpenditureBulk(ProjectFundingSourceExpenditure projectFundingSourceExpenditure,
            List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectFundingSourceExpenditure.ProjectID;
            FundingSourceID = projectFundingSourceExpenditure.FundingSourceID;
            CalendarYearExpenditures = new List<CalendarYearMonetaryAmount>();
            AddProjectFundingSourceExpenditures(projectFundingSourceExpenditures);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceExpenditures.Select(x => x.CalendarYear).ToList();
            CalendarYearExpenditures.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
        }

        private ProjectFundingSourceExpenditureBulk(ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdate,
            List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectFundingSourceExpenditureUpdate.ProjectUpdateBatch.ProjectID;
            FundingSourceID = projectFundingSourceExpenditureUpdate.FundingSourceID;
            CalendarYearExpenditures = new List<CalendarYearMonetaryAmount>();
            AddProjectFundingSourceExpenditureUpdates(projectFundingSourceExpenditureUpdates);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceExpenditureUpdates.Select(x => x.CalendarYear).ToList();
            CalendarYearExpenditures.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
        }

        private ProjectFundingSourceExpenditureBulk(int projectID, int fundingSourceID, int costTypeID,
            List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeID;
            IsRelevant = true;
            var calendarYearMonetaryAmounts = projectFundingSourceExpenditures.Select(x =>
            {
                Check.Require(x.ProjectID == ProjectID && x.FundingSourceID == FundingSourceID,
                    "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
                return new CalendarYearMonetaryAmount(x.CalendarYear, x.ExpenditureAmount, true);
            }).ToList();
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceExpenditures.Select(x => x.CalendarYear).ToList();
            calendarYearMonetaryAmounts.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, 0, true)));
            CalendarYearExpenditures = calendarYearMonetaryAmounts;
        }

        private ProjectFundingSourceExpenditureBulk(int projectID, int fundingSourceID, int costTypeID,
            List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeID;
            IsRelevant = true;
            var calendarYearMonetaryAmounts =
                projectFundingSourceExpenditureUpdates.Select(projectFundingSourceExpenditureUpdate =>
                {
                    Check.Require(projectFundingSourceExpenditureUpdate.ProjectUpdateBatch.ProjectID == ProjectID && projectFundingSourceExpenditureUpdate.FundingSourceID == FundingSourceID,
                        "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
                    return new CalendarYearMonetaryAmount(projectFundingSourceExpenditureUpdate.CalendarYear, projectFundingSourceExpenditureUpdate.ExpenditureAmount, true);
                }).ToList();
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceExpenditureUpdates.Select(x => x.CalendarYear).ToList();
            calendarYearMonetaryAmounts.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, 0, true)));
            CalendarYearExpenditures = calendarYearMonetaryAmounts;
        }

        public static List<ProjectFundingSourceExpenditureBulk> MakeFromList(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, List<int> calendarYears)
        {
            var groupedByProjectFundingSource = projectFundingSourceExpenditures.GroupBy(x => new {x.ProjectID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceExpenditureBulk(grouping.First(), grouping.ToList(), calendarYears)).ToList();
        }

        public static List<ProjectFundingSourceExpenditureBulk> MakeFromList(List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, List<int> calendarYearsToPopulate)
        {
            var groupedByProjectFundingSource = projectFundingSourceExpenditureUpdates.GroupBy(x => new {x.ProjectUpdateBatchID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceExpenditureBulk(grouping.First(), grouping.ToList(), calendarYearsToPopulate)).ToList();
        }

        public static List<ProjectFundingSourceExpenditureBulk> MakeFromListByCostType(Project project, List<int> calendarYearsToPopulate)
        {
            var projectID = project.ProjectID;
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var distinctFundingSources = projectFundingSourceExpenditures.Select(x => x.FundingSourceID).Distinct().ToList();
            var allCostTypeIDs = HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeID).ToList();
            var projectFundingSourceExpenditureBulks = new List<ProjectFundingSourceExpenditureBulk>();
            foreach (var fundingSourceID in distinctFundingSources)
            {
                foreach (var costTypeID in allCostTypeIDs)
                {
                    var expendituresForThisFundingSourceAndCostType = projectFundingSourceExpenditures.Where(x => x.FundingSourceID == fundingSourceID && x.CostTypeID == costTypeID).ToList();
                    projectFundingSourceExpenditureBulks.Add(new ProjectFundingSourceExpenditureBulk(projectID, fundingSourceID, costTypeID, expendituresForThisFundingSourceAndCostType, calendarYearsToPopulate));
                }
            }
            return projectFundingSourceExpenditureBulks;
        }

        public static List<ProjectFundingSourceExpenditureBulk> MakeFromListByCostType(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearsToPopulate)
        {
            var projectID = projectUpdateBatch.ProjectID;
            var projectFundingSourceExpenditureUpdates = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var distinctFundingSources = projectFundingSourceExpenditureUpdates.Select(x => x.FundingSourceID).Distinct().ToList();
            var allCostTypeIDs = HttpRequestStorage.DatabaseEntities.CostTypes.Select(x => x.CostTypeID).ToList();
            var projectFundingSourceExpenditureBulks = new List<ProjectFundingSourceExpenditureBulk>();
            foreach (var fundingSourceID in distinctFundingSources)
            {
                foreach (var costTypeID in allCostTypeIDs)
                {
                    var expendituresForThisFundingSourceAndCostType = projectFundingSourceExpenditureUpdates.Where(x => x.FundingSourceID == fundingSourceID && x.CostTypeID == costTypeID).ToList();
                    projectFundingSourceExpenditureBulks.Add(new ProjectFundingSourceExpenditureBulk(projectID, fundingSourceID, costTypeID, expendituresForThisFundingSourceAndCostType, calendarYearsToPopulate));
                }
            }
            return projectFundingSourceExpenditureBulks;
        }

        public void AddProjectFundingSourceExpenditures(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            projectFundingSourceExpenditures.ForEach(AddProjectFundingSourceExpenditure);
        }

        public void AddProjectFundingSourceExpenditureUpdates(List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates)
        {
            projectFundingSourceExpenditureUpdates.ForEach(AddProjectFundingSourceExpenditureUpdate);
        }

        public void AddProjectFundingSourceExpenditure(ProjectFundingSourceExpenditure projectFundingSourceExpenditure)
        {
            Check.Require(projectFundingSourceExpenditure.ProjectID == ProjectID && projectFundingSourceExpenditure.FundingSourceID == FundingSourceID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
            CalendarYearExpenditures.Add(new CalendarYearMonetaryAmount(projectFundingSourceExpenditure.CalendarYear, projectFundingSourceExpenditure.ExpenditureAmount));
        }

        public void AddProjectFundingSourceExpenditureUpdate(ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdate)
        {
            Check.Require(projectFundingSourceExpenditureUpdate.ProjectUpdateBatch.ProjectID == ProjectID && projectFundingSourceExpenditureUpdate.FundingSourceID == FundingSourceID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
            CalendarYearExpenditures.Add(new CalendarYearMonetaryAmount(projectFundingSourceExpenditureUpdate.CalendarYear, projectFundingSourceExpenditureUpdate.ExpenditureAmount));
        }

        public List<ProjectFundingSourceExpenditure> ToProjectFundingSourceExpenditures()
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearExpenditures.Where(x => x.MonetaryAmount.HasValue)
                    .Select(x => new ProjectFundingSourceExpenditure(ProjectID, FundingSourceID, x.CalendarYear, x.MonetaryAmount.Value, CostTypeID))
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }

        /// <summary>
        /// Used by Expenditures by cost type
        /// </summary>
        /// <returns></returns>
        public List<ProjectFundingSourceExpenditure> ToProjectFundingSourceExpendituresSetNullToZero()
        {
            return
                CalendarYearExpenditures.Where(x => x.IsRelevant ?? false)
                    .Select(x => new ProjectFundingSourceExpenditure(ProjectID, FundingSourceID, x.CalendarYear, x.MonetaryAmount ?? 0, CostTypeID))
                    .ToList();
        }

        public List<ProjectFundingSourceExpenditureUpdate> ToProjectFundingSourceExpenditureUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearExpenditures.Where(x => x.MonetaryAmount.HasValue)
                    .Select(x => new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch.ProjectUpdateBatchID, FundingSourceID, x.CalendarYear, x.MonetaryAmount.Value, CostTypeID))
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }

        /// <summary>
        /// Used by Expenditures by cost type
        /// </summary>
        /// <returns></returns>
        public List<ProjectFundingSourceExpenditureUpdate> ToProjectFundingSourceExpenditureUpdatesSetNullToZero(ProjectUpdateBatch projectUpdateBatch)
        {
            return
                CalendarYearExpenditures.Where(x => x.IsRelevant ?? false)
                    .Select(x => new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch.ProjectUpdateBatchID, FundingSourceID, x.CalendarYear, x.MonetaryAmount ?? 0, CostTypeID))
                    .ToList();
        }
    }
}
