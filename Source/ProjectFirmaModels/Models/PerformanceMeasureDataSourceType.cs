using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public abstract partial class PerformanceMeasureDataSourceType
    {
        public virtual List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(PerformanceMeasure performanceMeasure, List<Project> projects, bool projectsIntentionallyEmpty)
        {
            List<PerformanceMeasureActual> performanceMeasureActualsFiltered;
            // this can get called with an empty list from the Performance Measure detail page not just when there are no projects,
            // but also when there are no projects that should be visible to the user (e.g. proposal/pending projects). In that case we should not show all Performance Measure Actuals
            if (projects == null || (!projects.Any() && projectsIntentionallyEmpty))
            {
                performanceMeasureActualsFiltered = performanceMeasure.PerformanceMeasureActuals.ToList();
            }
            else
            {
                var projectIDs = projects.Select(x => x.ProjectID).ToList();
                performanceMeasureActualsFiltered =
                    performanceMeasure.PerformanceMeasureActuals.Where(x => projectIDs.Contains(x.Project.ProjectID)).ToList();
            }
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActualsFiltered);
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ToList();
        }


        public virtual List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(PerformanceMeasure performanceMeasure, List<ProjectUpdateBatch> projectUpdateBatches)
        {
            List<PerformanceMeasureActualUpdate> performanceMeasureActualsFiltered;
            if (projectUpdateBatches == null || !projectUpdateBatches.Any())
            {
                performanceMeasureActualsFiltered = performanceMeasure.PerformanceMeasureActualUpdates.ToList();
            }
            else
            {
                var projectUpdateBatchIDs = projectUpdateBatches.Select(x => x.ProjectUpdateBatchID).ToList();
                performanceMeasureActualsFiltered = performanceMeasure.PerformanceMeasureActualUpdates.Where(x => projectUpdateBatchIDs.Contains(x.ProjectUpdateBatchID)).ToList();
            }
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActualsFiltered);
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ToList();
        }


    }
}
