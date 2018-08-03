using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class PerformanceMeasureDataSourceType
    {
        public virtual List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(PerformanceMeasure performanceMeasure,
            List<int> projectIDs)
        {
            List<PerformanceMeasureActual> performanceMeasureActuals;
            if (projectIDs == null || !projectIDs.Any())
            {
                performanceMeasureActuals = HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Where(pmav => pmav.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList();
            }
            else
            {
                performanceMeasureActuals =
                    HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Where(
                        pmav => pmav.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID && projectIDs.Contains(pmav.ProjectID)).ToList();
            }
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActuals);
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.ProjectName).ToList();
        }
    }

    public partial class PerformanceMeasureDataSourceTypeTechnicalAssistanceValue
    {
        public override List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(
            PerformanceMeasure performanceMeasure, List<int> projectIDs)
        {
            var technicalAssistanceParameters = HttpRequestStorage.DatabaseEntities.TechnicalAssistanceParameters.ToList();
            var technicalAssistanceHours = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.SingleOrDefault(x=>x.PerformanceMeasureID == 2147);
            if (technicalAssistanceHours == null)
            {
                return new List<PerformanceMeasureReportedValue>();
            }

            var technicalAssistanceHoursProvidedGroupedByYearAndProject = Project.GetReportedPerformanceMeasureValues(technicalAssistanceHours,
                projectIDs).Where(x =>
                x.PerformanceMeasureActualSubcategoryOptions.Select(y => y.PerformanceMeasureSubcategoryOptionID)
                    .Contains(2935)).GroupBy(x=> new {x.CalendarYear, x.Project});

            return technicalAssistanceHoursProvidedGroupedByYearAndProject.SelectMany(x =>
            {
                var year = x.Key.CalendarYear;
                var project = x.Key.Project;
                var technicalAssistanceParameter = technicalAssistanceParameters.SingleOrDefault(y=>y.Year == year);
                var engineeringHourlyCost = technicalAssistanceParameter?.EngineeringHourlyCost;
                var otherAssistanceHourlyCost = technicalAssistanceParameter?.OtherAssistanceHourlyCost;
                var technicalAssistanceValueInYear = 0d;
                //foreach (var performanceMeasureReportedValue in x)
                return x.Select(performanceMeasureReportedValue =>
                {
                    if (performanceMeasureReportedValue.PerformanceMeasureActualSubcategoryOptions
                        .Select(y => y.PerformanceMeasureSubcategoryOptionID).Contains(2938))
                    {
                        technicalAssistanceValueInYear +=
                            performanceMeasureReportedValue.ReportedValue.GetValueOrDefault() *
                            (double) engineeringHourlyCost.GetValueOrDefault();
                    }
                    else
                    {
                        technicalAssistanceValueInYear +=
                            performanceMeasureReportedValue.ReportedValue.GetValueOrDefault() *
                            (double) otherAssistanceHourlyCost.GetValueOrDefault();
                    }

                    return new PerformanceMeasureReportedValue(performanceMeasure, project, year,
                        technicalAssistanceValueInYear);
                });
            }).ToList();
        }
    }
}
