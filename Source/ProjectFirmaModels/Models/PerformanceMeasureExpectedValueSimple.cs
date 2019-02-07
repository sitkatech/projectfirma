using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedValueSimple
    {
        public double? ExpectedValue { get; set; }

        public int PerformanceMeasureID { get; set; }

        public string PerformanceMeasureName { get; set; }
        public string ProjectStage { get; set; }

        public string ProjectName { get; set; }
        public string LeadImplementer { get; set; }
        public string MeasurementUnitType { get; set; }

        public List<PerformanceMeasureSubcategoryOptionFromProjectFirma> PerformanceMeasureSubcategoryOptions { get; set; }

        public PerformanceMeasureExpectedValueSimple()
        {
        }

        public PerformanceMeasureExpectedValueSimple(PerformanceMeasureExpected performanceMeasureExpected)
        {
            PerformanceMeasureID = performanceMeasureExpected.PerformanceMeasureID;
            PerformanceMeasureName = performanceMeasureExpected.PerformanceMeasure.PerformanceMeasureDisplayName;
            ExpectedValue = performanceMeasureExpected.GetReportedValue();
            MeasurementUnitType = performanceMeasureExpected.PerformanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName;
            ProjectStage = performanceMeasureExpected.Project.ProjectStage.ProjectStageDisplayName;
            LeadImplementer = performanceMeasureExpected.Project.GetPrimaryContactOrganization().OrganizationShortName;
            ProjectName = performanceMeasureExpected.Project.GetDisplayName();
            PerformanceMeasureSubcategoryOptions = performanceMeasureExpected
                .PerformanceMeasureExpectedSubcategoryOptions.Select(x => new PerformanceMeasureSubcategoryOptionFromProjectFirma(x))
                .ToList();
        }
    }
}