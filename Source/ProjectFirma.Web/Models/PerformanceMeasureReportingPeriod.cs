using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureReportingPeriod : IHavePrimaryKey
    {
        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureReportingPeriod(int performanceMeasureID, DateTime performanceMeasureReportingPeriodBeginDate, string performanceMeasureReportingPeriodLabel)
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();

            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureReportingPeriodBeginDate = performanceMeasureReportingPeriodBeginDate;
            this.PerformanceMeasureReportingPeriodLabel = performanceMeasureReportingPeriodLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureReportingPeriod(PerformanceMeasure performanceMeasure, DateTime performanceMeasureReportingPeriodBeginDate, string performanceMeasureReportingPeriodLabel)
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            this.PerformanceMeasureReportingPeriodBeginDate = performanceMeasureReportingPeriodBeginDate;
            this.PerformanceMeasureReportingPeriodLabel = performanceMeasureReportingPeriodLabel;
        }

        [Key]
        public int PerformanceMeasureReportingPeriodID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public DateTime PerformanceMeasureReportingPeriodBeginDate { get; set; }
        public DateTime? PerformanceMeasureReportingPeriodEndDate { get; set; }
        public string PerformanceMeasureReportingPeriodLabel { get; set; }
        public double? TargetValue { get; set; }
        public string TargetValueDescription { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureReportingPeriodID; } set { PerformanceMeasureReportingPeriodID = value; } }

        public virtual ICollection<PerformanceMeasureReportedValue> PerformanceMeasureReportedValues { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
    }
}