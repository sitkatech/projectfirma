using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public abstract partial class PerformanceMeasureDataSourceType
    {
        public virtual List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            List<PerformanceMeasureActual> performanceMeasureActualsFiltered;
            if (projects == null || !projects.Any())
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
            //.ThenBy(pma => pma.ProjectName)
            //todo: 11/4/2019 TK - try to sort by project name
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
                var projectIDs = projectUpdateBatches.Select(x => x.ProjectID).ToList();
                performanceMeasureActualsFiltered = performanceMeasure.PerformanceMeasureActualUpdates.Where(x => projectIDs.Contains(x.ProjectUpdateBatch.ProjectID)).ToList();
            }
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActualsFiltered);
            //.ThenBy(pma => pma.ProjectName)
            //todo: 11/4/2019 TK - try to sort by project name
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ToList();
        }


    }
}
