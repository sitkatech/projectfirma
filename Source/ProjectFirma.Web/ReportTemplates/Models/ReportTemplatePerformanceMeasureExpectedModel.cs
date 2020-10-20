using System;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplatePerformanceMeasureExpectedModel : ReportTemplateBaseModel
    {
        private PerformanceMeasureExpected PerformanceMeasureExpected { get; set; }
        private Project Project { get; }
        public double? Value { get; set; }
        public string UnitType { get; set; }
        public string PerformanceMeasureName { get; set; }
        public string PerformanceMeasureSubcategoryName { get; set; }
        public string PerformanceMeasureSubcategoryOptionName { get; set; }


        public ReportTemplatePerformanceMeasureExpectedModel(PerformanceMeasureExpected performanceMeasureExpected)
        {
            PerformanceMeasureExpected = performanceMeasureExpected;
            Project = performanceMeasureExpected.Project;
            Value = performanceMeasureExpected.ExpectedValue;
            UnitType = performanceMeasureExpected.PerformanceMeasure.MeasurementUnitType.LegendDisplayName;
            PerformanceMeasureName = performanceMeasureExpected.PerformanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureSubcategoryName = performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions?.FirstOrDefault(x => x.PerformanceMeasureExpectedID == performanceMeasureExpected.PerformanceMeasureExpectedID)?.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName ?? String.Empty;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions?.FirstOrDefault(x => x.PerformanceMeasureExpectedID == performanceMeasureExpected.PerformanceMeasureExpectedID)?.GetPerformanceMeasureSubcategoryOptionName() ?? String.Empty;
        }
    }
}