//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorReportingPeriod]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ThresholdIndicatorReportingPeriod]")]
    public partial class ThresholdIndicatorReportingPeriod : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdIndicatorReportingPeriod()
        {
            this.ThresholdIndicatorReporteds = new HashSet<ThresholdIndicatorReported>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorReportingPeriod(int thresholdIndicatorReportingPeriodID, int thresholdIndicatorID, DateTime thresholdIndicatorReportingPeriodBeginDate, DateTime? thresholdIndicatorReportingPeriodEndDate, string thresholdIndicatorReportingPeriodLabel, double? targetValue, string targetValueDescription) : this()
        {
            this.ThresholdIndicatorReportingPeriodID = thresholdIndicatorReportingPeriodID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.ThresholdIndicatorReportingPeriodBeginDate = thresholdIndicatorReportingPeriodBeginDate;
            this.ThresholdIndicatorReportingPeriodEndDate = thresholdIndicatorReportingPeriodEndDate;
            this.ThresholdIndicatorReportingPeriodLabel = thresholdIndicatorReportingPeriodLabel;
            this.TargetValue = targetValue;
            this.TargetValueDescription = targetValueDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorReportingPeriod(int thresholdIndicatorID, DateTime thresholdIndicatorReportingPeriodBeginDate, string thresholdIndicatorReportingPeriodLabel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdIndicatorReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.ThresholdIndicatorReportingPeriodBeginDate = thresholdIndicatorReportingPeriodBeginDate;
            this.ThresholdIndicatorReportingPeriodLabel = thresholdIndicatorReportingPeriodLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdIndicatorReportingPeriod(ThresholdIndicator thresholdIndicator, DateTime thresholdIndicatorReportingPeriodBeginDate, string thresholdIndicatorReportingPeriodLabel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdIndicatorReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdIndicatorID = thresholdIndicator.ThresholdIndicatorID;
            this.ThresholdIndicator = thresholdIndicator;
            thresholdIndicator.ThresholdIndicatorReportingPeriods.Add(this);
            this.ThresholdIndicatorReportingPeriodBeginDate = thresholdIndicatorReportingPeriodBeginDate;
            this.ThresholdIndicatorReportingPeriodLabel = thresholdIndicatorReportingPeriodLabel;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdIndicatorReportingPeriod CreateNewBlank(ThresholdIndicator thresholdIndicator)
        {
            return new ThresholdIndicatorReportingPeriod(thresholdIndicator, default(DateTime), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ThresholdIndicatorReporteds.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdIndicatorReportingPeriod).Name, typeof(ThresholdIndicatorReported).Name};

        [Key]
        public int ThresholdIndicatorReportingPeriodID { get; set; }
        public int ThresholdIndicatorID { get; set; }
        public DateTime ThresholdIndicatorReportingPeriodBeginDate { get; set; }
        public DateTime? ThresholdIndicatorReportingPeriodEndDate { get; set; }
        public string ThresholdIndicatorReportingPeriodLabel { get; set; }
        public double? TargetValue { get; set; }
        public string TargetValueDescription { get; set; }
        public int PrimaryKey { get { return ThresholdIndicatorReportingPeriodID; } set { ThresholdIndicatorReportingPeriodID = value; } }

        public virtual ICollection<ThresholdIndicatorReported> ThresholdIndicatorReporteds { get; set; }
        public virtual ThresholdIndicator ThresholdIndicator { get; set; }

        public static class FieldLengths
        {
            public const int ThresholdIndicatorReportingPeriodLabel = 100;
            public const int TargetValueDescription = 100;
        }
    }
}