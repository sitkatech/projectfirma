/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualUpdate.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureActualUpdate : IPerformanceMeasureValue, IPerformanceMeasureReportedValue
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var performanceMeasureActualUpdates = new List<PerformanceMeasureActualUpdate>();
            var currentPerformanceMeasureActuals = project.PerformanceMeasureActuals.ToList();
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var completionYear = projectUpdateBatch.ProjectUpdate != null ? projectUpdateBatch.ProjectUpdate.CompletionYear : project.CompletionYear;
            var currentStage = projectUpdateBatch.ProjectUpdate != null ? projectUpdateBatch.ProjectUpdate.ProjectStage : project.ProjectStage;
            var endYearToFill = Math.Min(completionYear ?? currentYear, currentYear);
            // if we have a project completion year, we only fill up to that unless current year is earlier; no completion year set we use current year
            if (currentPerformanceMeasureActuals.Any())
            {
                performanceMeasureActualUpdates.AddRange(
                    currentPerformanceMeasureActuals.Select(
                        performanceMeasureActual =>
                            ClonePerformanceMeasureValue(projectUpdateBatch, performanceMeasureActual, performanceMeasureActual.CalendarYear, performanceMeasureActual.ActualValue)));
                // now fill in the gaps up to the current year, if the max entered year is less than current year and we are not in Planning/Design
                if (currentStage != ProjectStage.PlanningDesign)
                {
                    var maxEnteredYear = currentPerformanceMeasureActuals.Max(x => x.CalendarYear);
                    if (maxEnteredYear < currentYear)
                    {
                        // go back to the most recent year there were values and fill in the gaps from that year to the current year using the PM values they entered from that year
                        var performanceMeasureActualsToClone = new List<IPerformanceMeasureValue>(currentPerformanceMeasureActuals.Where(x => x.CalendarYear == maxEnteredYear).ToList());
                        var initialYearToFill = maxEnteredYear + 1;
                        performanceMeasureActualUpdates.AddRange(CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                            performanceMeasureActualsToClone,
                            initialYearToFill,
                            endYearToFill));
                    }
                }
            }
            // use expected values if any only if we are not in Planning/Design
            else if (currentStage != ProjectStage.PlanningDesign)
            {
                var currentPerformanceMeasureExpecteds = new List<IPerformanceMeasureValue>(project.PerformanceMeasureExpecteds.ToList());
                if (currentPerformanceMeasureExpecteds.Any())
                {
                    // we want to pre-create records from project Start Year to current year; if no start year then we just create for current year
                    var initialYearToFill = project.ImplementationStartYear ?? currentYear;
                    performanceMeasureActualUpdates.AddRange(CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                        currentPerformanceMeasureExpecteds,
                        initialYearToFill,
                        endYearToFill));
                }
            }
            projectUpdateBatch.PerformanceMeasureActualUpdates = performanceMeasureActualUpdates;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static List<PerformanceMeasureActualUpdate> CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(ProjectUpdateBatch projectUpdateBatch,
            List<IPerformanceMeasureValue> performanceMeasureValuesToClone,
            int initialYearToFill,
            int endYearToFill)
        {
            var exemptYears = projectUpdateBatch.Project.ProjectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            var yearsToFill = FirmaDateUtilities.GetRangeOfYears(initialYearToFill, endYearToFill).Where(x => !exemptYears.Contains(x)).ToList();

            var performanceMeasureActualUpdates = new List<PerformanceMeasureActualUpdate>();
            foreach (var year in yearsToFill)
            {
                // when pre-filling, we intentionally set the reported value to null to prompt the user to fill that in
                performanceMeasureActualUpdates.AddRange(
                    performanceMeasureValuesToClone.Select(performanceMeasureActual => ClonePerformanceMeasureValue(projectUpdateBatch, performanceMeasureActual, year, null)));
            }
            return performanceMeasureActualUpdates;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static PerformanceMeasureActualUpdate ClonePerformanceMeasureValue(ProjectUpdateBatch projectUpdateBatch,
            IPerformanceMeasureValue performanceMeasureValueToClone,
            int newCalendarYear,
            double? actualValue)
        {
            var performanceMeasureActualUpdate = new PerformanceMeasureActualUpdate(projectUpdateBatch, performanceMeasureValueToClone.PerformanceMeasure, newCalendarYear)
            {
                ActualValue = actualValue
            };
            performanceMeasureActualUpdate.PerformanceMeasureActualSubcategoryOptionUpdates =
                performanceMeasureValueToClone.PerformanceMeasureSubcategoryOptions.Select(
                    performanceMeasureActualSubcategoryOption =>
                        new PerformanceMeasureActualSubcategoryOptionUpdate(performanceMeasureActualUpdate,
                            performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOption,
                            performanceMeasureActualSubcategoryOption.PerformanceMeasure,
                            performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategory)).ToList();
            return performanceMeasureActualUpdate;
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureActualSubcategoryOptionUpdates); }
        }

        public double? ReportedValue
        {
            get { return ActualValue; }
        }

        public string PerformanceMeasureName
        {
            get { return PerformanceMeasure.PerformanceMeasureDisplayName; }
        }

        public string PerformanceMeasureUrl
        {
            get { return PerformanceMeasure.GetSummaryUrl(); }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return PerformanceMeasure.MeasurementUnitType; }
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                return PerformanceMeasureActualSubcategoryOptionUpdates.Any()
                    ? string.Join("\r\n",
                        PerformanceMeasureActualSubcategoryOptionUpdates.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x => string.Format("{0}: {1}", x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName, x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public string ReportedValueDisplay
        {
            get { return MeasurementUnitType.DisplayValue(ReportedValue); }
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            IList<PerformanceMeasureActual> allPerformanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions)
        {
            var project = projectUpdateBatch.Project;
            var currentPerformanceMeasureActuals = project.PerformanceMeasureActuals.ToList();
            currentPerformanceMeasureActuals.ForEach(pmav =>
            {
                pmav.PerformanceMeasureActualSubcategoryOptions.ToList().ForEach(pmavso => allPerformanceMeasureActualSubcategoryOptions.Remove(pmavso));
                allPerformanceMeasureActuals.Remove(pmav);
            });
            currentPerformanceMeasureActuals.Clear();

            if (projectUpdateBatch.PerformanceMeasureActualUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.PerformanceMeasureActualUpdates.ToList().ForEach(x =>
                {
                    var performanceMeasureActual = new PerformanceMeasureActual(project, x.PerformanceMeasure, x.CalendarYear, x.ActualValue ?? 0);
                    allPerformanceMeasureActuals.Add(performanceMeasureActual);
                    var performanceMeasureActualSubcategoryOptionUpdates = x.PerformanceMeasureActualSubcategoryOptionUpdates.ToList();
                    if (performanceMeasureActualSubcategoryOptionUpdates.Any())
                    {
                        performanceMeasureActualSubcategoryOptionUpdates.ForEach(
                            y =>
                                allPerformanceMeasureActualSubcategoryOptions.Add(new PerformanceMeasureActualSubcategoryOption(performanceMeasureActual,
                                    y.PerformanceMeasureSubcategoryOption,
                                    y.PerformanceMeasure,
                                    y.PerformanceMeasureSubcategory)));
                    }
                });
            }
        }
    }
}
