using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureReportingPeriod : IHavePrimaryKey
    {
        public PerformanceMeasureReportingPeriod(PerformanceMeasure performanceMeasure, DateTime performanceMeasureReportingPeriodBeginDate, string performanceMeasureReportingPeriodLabel)
        {
            // Mark this as a new object by setting primary key with special value
            PerformanceMeasureReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            PerformanceMeasure = performanceMeasure;
            PerformanceMeasureReportingPeriodBeginDate = performanceMeasureReportingPeriodBeginDate;
            PerformanceMeasureReportingPeriodLabel = performanceMeasureReportingPeriodLabel;
        }

        [Key]
        public int PerformanceMeasureReportingPeriodID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public DateTime PerformanceMeasureReportingPeriodBeginDate { get; set; }
        public string PerformanceMeasureReportingPeriodLabel { get; set; }
        public double? TargetValue { get; set; }
        public string TargetValueDescription { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureReportingPeriodID; } set { PerformanceMeasureReportingPeriodID = value; } }

        public virtual ICollection<PerformanceMeasureReportedValue> PerformanceMeasureReportedValues { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
    }
}