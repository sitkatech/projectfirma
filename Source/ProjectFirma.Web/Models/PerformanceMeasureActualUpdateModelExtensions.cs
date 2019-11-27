using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureActualUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            if (projectUpdateBatch.AreAccomplishmentsRelevant())
            {
                var project = projectUpdateBatch.Project;
                var performanceMeasureActualUpdates = new List<PerformanceMeasureActualUpdate>();
                var currentPerformanceMeasureActuals = project.PerformanceMeasureActuals.ToList();
                var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
                var completionYear = projectUpdateBatch.ProjectUpdate != null
                    ? projectUpdateBatch.ProjectUpdate.CompletionYear
                    : project.CompletionYear;
                var currentStage = projectUpdateBatch.ProjectUpdate != null
                    ? projectUpdateBatch.ProjectUpdate.ProjectStage
                    : project.ProjectStage;
                var endYearToFill = Math.Min(completionYear ?? currentYear, currentYear);
                // if we have a project completion year, we only fill up to that unless current year is earlier; no completion year set we use current year
                if (currentPerformanceMeasureActuals.Any())
                {
                    performanceMeasureActualUpdates.AddRange(
                        currentPerformanceMeasureActuals.Select<PerformanceMeasureActual, PerformanceMeasureActualUpdate>(
                            performanceMeasureActual => ClonePerformanceMeasureValue(projectUpdateBatch, performanceMeasureActual,
                                performanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear, performanceMeasureActual.ActualValue)));
                }
                // use expected values if any only if we are not in Planning/Design
                else if (currentStage != ProjectStage.PlanningDesign)
                {
                    var currentPerformanceMeasureExpecteds =
                        new List<IPerformanceMeasureValue>(project.PerformanceMeasureExpecteds.ToList());
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
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static List<PerformanceMeasureActualUpdate> CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(ProjectUpdateBatch projectUpdateBatch,
            List<IPerformanceMeasureValue> performanceMeasureValuesToClone,
            int initialYearToFill,
            int endYearToFill)
        {
            var exemptYears = projectUpdateBatch.Project.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();
            var yearsToFill = FirmaDateUtilities.GetRangeOfYears(initialYearToFill, endYearToFill).Where(x => !exemptYears.Contains(x)).ToList();

            var performanceMeasureActualUpdates = new List<PerformanceMeasureActualUpdate>();
            foreach (var year in yearsToFill)
            {
                // when pre-filling, we intentionally set the reported value to null to prompt the user to fill that in
                performanceMeasureActualUpdates.AddRange(
                    performanceMeasureValuesToClone.Select(performanceMeasureValue => ClonePerformanceMeasureValue(projectUpdateBatch, performanceMeasureValue, year, null)));
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
            var performanceMeasureReportingPeriod = performanceMeasureValueToClone.PerformanceMeasure.PerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == newCalendarYear);
            if (performanceMeasureReportingPeriod == null)
            {
                performanceMeasureReportingPeriod = HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.GetOrCreatePerformanceMeasureReportingPeriod(performanceMeasureValueToClone.PerformanceMeasure, newCalendarYear);
            }
            var performanceMeasureActualUpdate = new PerformanceMeasureActualUpdate(projectUpdateBatch, performanceMeasureValueToClone.PerformanceMeasure, performanceMeasureReportingPeriod)
            {
                ActualValue = actualValue
            };
            performanceMeasureActualUpdate.PerformanceMeasureActualSubcategoryOptionUpdates =
                performanceMeasureValueToClone.GetPerformanceMeasureSubcategoryOptions().Select(
                    performanceMeasureActualSubcategoryOption =>
                        new PerformanceMeasureActualSubcategoryOptionUpdate(performanceMeasureActualUpdate,
                            performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOption,
                            performanceMeasureActualSubcategoryOption.PerformanceMeasure,
                            performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategory)).ToList();
            return performanceMeasureActualUpdate;
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

            if (projectUpdateBatch.AreAccomplishmentsRelevant() && projectUpdateBatch.PerformanceMeasureActualUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.PerformanceMeasureActualUpdates.ToList().ForEach(x =>
                {
                    var performanceMeasureActual = new PerformanceMeasureActual(project, x.PerformanceMeasure, x.ActualValue ?? 0, x.PerformanceMeasureReportingPeriod);
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