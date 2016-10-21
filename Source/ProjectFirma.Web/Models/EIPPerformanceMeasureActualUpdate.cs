using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class EIPPerformanceMeasureActualUpdate : IEIPPerformanceMeasureValue, IEIPPerformanceMeasureReportedValue
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var eipPerformanceMeasureActualUpdates = new List<EIPPerformanceMeasureActualUpdate>();
            var currentEIPPerformanceMeasureActuals = project.EIPPerformanceMeasureActuals.ToList();
            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var completionYear = projectUpdateBatch.ProjectUpdate != null ? projectUpdateBatch.ProjectUpdate.CompletionYear : project.CompletionYear;
            var currentStage = projectUpdateBatch.ProjectUpdate != null ? projectUpdateBatch.ProjectUpdate.ProjectStage : project.ProjectStage;
            var endYearToFill = Math.Min(completionYear ?? currentYear, currentYear);
            // if we have a project completion year, we only fill up to that unless current year is earlier; no completion year set we use current year
            if (currentEIPPerformanceMeasureActuals.Any())
            {
                eipPerformanceMeasureActualUpdates.AddRange(
                    currentEIPPerformanceMeasureActuals.Select(
                        eipPerformanceMeasureActual =>
                            CloneEIPPerformanceMeasureValue(projectUpdateBatch, eipPerformanceMeasureActual, eipPerformanceMeasureActual.CalendarYear, eipPerformanceMeasureActual.ActualValue)));
                // now fill in the gaps up to the current year, if the max entered year is less than current year and we are not in Planning/Design
                if (currentStage != ProjectStage.PlanningDesign)
                {
                    var maxEnteredYear = currentEIPPerformanceMeasureActuals.Max(x => x.CalendarYear);
                    if (maxEnteredYear < currentYear)
                    {
                        // go back to the most recent year there were values and fill in the gaps from that year to the current year using the PM values they entered from that year
                        var eipPerformanceMeasureActualsToClone = new List<IEIPPerformanceMeasureValue>(currentEIPPerformanceMeasureActuals.Where(x => x.CalendarYear == maxEnteredYear).ToList());
                        var initialYearToFill = maxEnteredYear + 1;
                        eipPerformanceMeasureActualUpdates.AddRange(CreateEIPPerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                            eipPerformanceMeasureActualsToClone,
                            initialYearToFill,
                            endYearToFill));
                    }
                }
            }
            // use expected values if any only if we are not in Planning/Design
            else if (currentStage != ProjectStage.PlanningDesign)
            {
                var currentEIPPerformanceMeasureExpecteds = new List<IEIPPerformanceMeasureValue>(project.EIPPerformanceMeasureExpecteds.ToList());
                if (currentEIPPerformanceMeasureExpecteds.Any())
                {
                    // we want to pre-create records from project Start Year to current year; if no start year then we just create for current year
                    var initialYearToFill = project.ImplementationStartYear ?? currentYear;
                    eipPerformanceMeasureActualUpdates.AddRange(CreateEIPPerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                        currentEIPPerformanceMeasureExpecteds,
                        initialYearToFill,
                        endYearToFill));
                }
            }
            projectUpdateBatch.EIPPerformanceMeasureActualUpdates = eipPerformanceMeasureActualUpdates;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static List<EIPPerformanceMeasureActualUpdate> CreateEIPPerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(ProjectUpdateBatch projectUpdateBatch,
            List<IEIPPerformanceMeasureValue> eipPerformanceMeasureValuesToClone,
            int initialYearToFill,
            int endYearToFill)
        {
            var exemptYears = projectUpdateBatch.Project.ProjectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            var yearsToFill = ProjectFirmaDateUtilities.GetRangeOfYears(initialYearToFill, endYearToFill).Where(x => !exemptYears.Contains(x)).ToList();

            var eipPerformanceMeasureActualUpdates = new List<EIPPerformanceMeasureActualUpdate>();
            foreach (var year in yearsToFill)
            {
                // when pre-filling, we intentionally set the reported value to null to prompt the user to fill that in
                eipPerformanceMeasureActualUpdates.AddRange(
                    eipPerformanceMeasureValuesToClone.Select(eipPerformanceMeasureActual => CloneEIPPerformanceMeasureValue(projectUpdateBatch, eipPerformanceMeasureActual, year, null)));
            }
            return eipPerformanceMeasureActualUpdates;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static EIPPerformanceMeasureActualUpdate CloneEIPPerformanceMeasureValue(ProjectUpdateBatch projectUpdateBatch,
            IEIPPerformanceMeasureValue eipPerformanceMeasureValueToClone,
            int newCalendarYear,
            double? actualValue)
        {
            var eipPerformanceMeasureActualUpdate = new EIPPerformanceMeasureActualUpdate(projectUpdateBatch, eipPerformanceMeasureValueToClone.EIPPerformanceMeasure, newCalendarYear)
            {
                ActualValue = actualValue
            };
            eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualSubcategoryOptionUpdates =
                eipPerformanceMeasureValueToClone.IndicatorSubcategoryOptions.Select(
                    eipPerformanceMeasureActualSubcategoryOption =>
                        new EIPPerformanceMeasureActualSubcategoryOptionUpdate(eipPerformanceMeasureActualUpdate,
                            eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryOption,
                            eipPerformanceMeasureActualSubcategoryOption.EIPPerformanceMeasure,
                            eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategory)).ToList();
            return eipPerformanceMeasureActualUpdate;
        }

        public List<IEIPPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions
        {
            get { return new List<IEIPPerformanceMeasureValueSubcategoryOption>(EIPPerformanceMeasureActualSubcategoryOptionUpdates); }
        }

        public double? ReportedValue
        {
            get { return ActualValue; }
        }

        public string EIPPerformanceMeasureName
        {
            get { return EIPPerformanceMeasure.DisplayName; }
        }

        public string EIPPerformanceMeasureUrl
        {
            get { return EIPPerformanceMeasure.GetSummaryUrl(); }
        }

        public EIPPerformanceMeasureType EIPPerformanceMeasureType
        {
            get { return EIPPerformanceMeasure.EIPPerformanceMeasureType; }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return EIPPerformanceMeasure.Indicator.MeasurementUnitType; }
        }

        public string IndicatorSubcategoriesAsString
        {
            get
            {
                return EIPPerformanceMeasureActualSubcategoryOptionUpdates.Any()
                    ? string.Join("\r\n",
                        EIPPerformanceMeasureActualSubcategoryOptionUpdates.OrderBy(x => x.IndicatorSubcategory.IndicatorSubcategoryDisplayName)
                            .Select(x => string.Format("{0}: {1}", x.IndicatorSubcategory.IndicatorSubcategoryDisplayName, x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public string ReportedValueDisplay
        {
            get { return MeasurementUnitType.DisplayValue(ReportedValue); }
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            IList<EIPPerformanceMeasureActual> allEIPPerformanceMeasureActuals,
            IList<EIPPerformanceMeasureActualSubcategoryOption> allEIPPerformanceMeasureActualSubcategoryOptions)
        {
            var project = projectUpdateBatch.Project;
            var currentEIPPerformanceMeasureActuals = project.EIPPerformanceMeasureActuals.ToList();
            currentEIPPerformanceMeasureActuals.ForEach(pmav =>
            {
                pmav.EIPPerformanceMeasureActualSubcategoryOptions.ToList().ForEach(pmavso => allEIPPerformanceMeasureActualSubcategoryOptions.Remove(pmavso));
                allEIPPerformanceMeasureActuals.Remove(pmav);
            });
            currentEIPPerformanceMeasureActuals.Clear();

            if (projectUpdateBatch.EIPPerformanceMeasureActualUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList().ForEach(x =>
                {
                    var eipPerformanceMeasureActual = new EIPPerformanceMeasureActual(project, x.EIPPerformanceMeasure, x.CalendarYear, x.ActualValue ?? 0);
                    allEIPPerformanceMeasureActuals.Add(eipPerformanceMeasureActual);
                    var eipPerformanceMeasureActualSubcategoryOptionUpdates = x.EIPPerformanceMeasureActualSubcategoryOptionUpdates.ToList();
                    if (eipPerformanceMeasureActualSubcategoryOptionUpdates.Any())
                    {
                        eipPerformanceMeasureActualSubcategoryOptionUpdates.ForEach(
                            y =>
                                allEIPPerformanceMeasureActualSubcategoryOptions.Add(new EIPPerformanceMeasureActualSubcategoryOption(eipPerformanceMeasureActual,
                                    y.IndicatorSubcategoryOption,
                                    y.EIPPerformanceMeasure,
                                    y.IndicatorSubcategory)));
                    }
                });
            }
        }
    }
}