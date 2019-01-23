using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public abstract partial class PerformanceMeasureDataSourceType
    {
        public const int TechnicalAssistanceProvidedPMID = 2147;
        public const int ProvidedSubcategoryOptionID = 2935;
        public const int EngineeringAssistanceSubcategoryOptionID = 2938;
        public const int ProvidedToConservationDistrictionsSubcategoryOptionID = 2994;

        public virtual List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(DatabaseEntities databaseEntities, PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            List<PerformanceMeasureActual> performanceMeasureActualsFiltered;
            if (projects == null || !projects.Any())
            {
                performanceMeasureActualsFiltered = databaseEntities.PerformanceMeasureActuals.Where(pmav => pmav.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList();
            }
            else
            {
                var projectIDs = projects.Select(x => x.ProjectID).ToList();
                performanceMeasureActualsFiltered =
                    databaseEntities.PerformanceMeasureActuals.Where(
                        pmav => pmav.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID && projectIDs.Contains(pmav.Project.ProjectID)).ToList();
            }
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActualsFiltered);
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.ProjectName).ToList();
        }
    }
}
