using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// Meant to represent a Project row with the PerformanceMeasure Subcategory Option values as a list with the Reported Value and Reporting Period being the same for each 
    /// PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue row
    /// Not intended to sum the ReportedValues across all PerformanceMeasureReportingPeriodSubcategoryOptionReportedValues since it is the same value for each one
    /// </summary>
    public class ProjectPerformanceMeasureReportingPeriodValue
    {
        public Project Project { get; set; }

        public PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod => PerformanceMeasureSubcategoryOptionReportedValues.First().PerformanceMeasureReportingPeriod;

        public List<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue> PerformanceMeasureSubcategoryOptionReportedValues { get; set; }
        public string PerformanceMeasureSubcategoriesAsString => string.Join("\r\n",
            PerformanceMeasureSubcategoryOptionReportedValues.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName).Select(x =>
                $"{x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName}: {x.PerformanceMeasureSubcategoryOptionName}"));

        public double? ReportedValue => PerformanceMeasureSubcategoryOptionReportedValues.First().ReportedValue;
        public int CalendarYear => Convert.ToInt32(PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel);
        public PerformanceMeasure PerformanceMeasure => PerformanceMeasureReportingPeriod.PerformanceMeasure;

        public ProjectPerformanceMeasureReportingPeriodValue(Project project, List<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue> performanceMeasureSubcategoryOptionReportedValues)
        {
            Project = project;
            PerformanceMeasureSubcategoryOptionReportedValues = performanceMeasureSubcategoryOptionReportedValues;
        }
    }
}