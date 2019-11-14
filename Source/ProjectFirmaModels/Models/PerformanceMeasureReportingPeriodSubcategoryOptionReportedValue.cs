using System;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue
    {
        private PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, double? reportedValue, int sortOrder, int performanceMeasureSubcategoryOptionID, PerformanceMeasureSubcategory performanceMeasureSubcategory, string performanceMeasureSubcategoryOptionName, string chartName)
        {
            PerformanceMeasureReportingPeriod = performanceMeasureReportingPeriod;
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

        public PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod,
            PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, double? reportedValue) :
            this(performanceMeasureReportingPeriod, reportedValue, performanceMeasureSubcategoryOption.SortOrder ?? 0,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategory,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName,
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)
        {
        }

        public PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, double reportedValue,
            PerformanceMeasureSubcategory performanceMeasureSubcategory,
            string performanceMeasureSubcategoryOptionName) : 
            this(performanceMeasureReportingPeriod, reportedValue, ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, performanceMeasureSubcategory, performanceMeasureSubcategoryOptionName, performanceMeasureSubcategoryOptionName)
        {
        }

        public int PerformanceMeasureSubcategoryID => PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
        public int PerformanceMeasureSubcategoryOptionID { get; }
        public PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        public string PerformanceMeasureSubcategoryOptionName { get; }
        public string ChartName { get; }
    }
}