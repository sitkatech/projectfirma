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
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.ProjectName).ToList();
        }
    }
}
