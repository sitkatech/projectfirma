using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplatePerformanceMeasureActualModel : ReportTemplateBaseModel
    {
        private PerformanceMeasureActual PerformanceMeasureActual { get; set; }
        private Project Project { get; }
        public double Value { get; set; }
        public string UnitType { get; set; }
        public int Year { get; set; }
        public string PerformanceMeasureName { get; set; }
        public string PerformanceMeasureSubcategoryName { get; set; }
        public string PerformanceMeasureSubcategoryOptionName { get; set; }


        public ReportTemplatePerformanceMeasureActualModel(PerformanceMeasureActual performanceMeasureActual)
        {
            PerformanceMeasureActual = performanceMeasureActual;
            Project = performanceMeasureActual.Project;
            Value = performanceMeasureActual.ActualValue;
            UnitType = performanceMeasureActual.PerformanceMeasure.MeasurementUnitType.LegendDisplayName;
            Year = performanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
            PerformanceMeasureName = performanceMeasureActual.PerformanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureSubcategoryName = performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions?.FirstOrDefault(x => x.PerformanceMeasureActualID == performanceMeasureActual.PerformanceMeasureActualID)?.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName ?? String.Empty;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions?.FirstOrDefault(x => x.PerformanceMeasureActualID == performanceMeasureActual.PerformanceMeasureActualID)?.GetPerformanceMeasureSubcategoryOptionName() ?? String.Empty;
        }
    }
}