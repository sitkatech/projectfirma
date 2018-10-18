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
        private readonly PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue _performanceMeasureReportingPeriodSubcategoryOptionReportedValue;
        public Project Project { get; set; }

        public PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod => _performanceMeasureReportingPeriodSubcategoryOptionReportedValue?.PerformanceMeasureReportingPeriod;

        public List<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue> PerformanceMeasureSubcategoryOptionReportedValues { get; set; }

        public int? CalendarYear => PerformanceMeasureReportingPeriod != null ? Convert.ToInt32(PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel) : (int?) null;

        public ProjectPerformanceMeasureReportingPeriodValue(Project project, List<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue> performanceMeasureSubcategoryOptionReportedValues)
        {
            Project = project;
            PerformanceMeasureSubcategoryOptionReportedValues = performanceMeasureSubcategoryOptionReportedValues;
            _performanceMeasureReportingPeriodSubcategoryOptionReportedValue = PerformanceMeasureSubcategoryOptionReportedValues.FirstOrDefault();
        }
    }
}