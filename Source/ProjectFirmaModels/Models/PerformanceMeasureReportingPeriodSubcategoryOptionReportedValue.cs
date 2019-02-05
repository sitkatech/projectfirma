using System;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue
    {
        private PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(int calendarYear, double? reportedValue, int sortOrder, int performanceMeasureSubcategoryOptionID, PerformanceMeasureSubcategory performanceMeasureSubcategory, string performanceMeasureSubcategoryOptionName, string chartName)
        {
            PerformanceMeasureReportingPeriod =
                new PerformanceMeasureReportingPeriod(performanceMeasureSubcategory.PerformanceMeasure, new DateTime(calendarYear, 1, 1), calendarYear.ToString()) { PerformanceMeasureReportingPeriodID = calendarYear };
            ReportedValue = reportedValue;
            SortOrder = sortOrder;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOptionName;
            ChartName = chartName;
        }

        public PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod { get; set; }
        public double? ReportedValue { get; set; }
        public int SortOrder { get; }

        public PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(int calendarYear,
            PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, double? reportedValue) :
            this(calendarYear, reportedValue, performanceMeasureSubcategoryOption.SortOrder ?? 0,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategory,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)
        {
        }

        public PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(int calendarYear, double reportedValue,
            PerformanceMeasureSubcategory performanceMeasureSubcategory,
            string performanceMeasureSubcategoryOptionName) : 
            this(calendarYear, reportedValue, ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, performanceMeasureSubcategory, performanceMeasureSubcategoryOptionName, performanceMeasureSubcategoryOptionName)
        {
        }

        public int PerformanceMeasureSubcategoryID => PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
        public int PerformanceMeasureSubcategoryOptionID { get; }
        public PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        public string PerformanceMeasureSubcategoryOptionName { get; }
        public string ChartName { get; }
    }
}