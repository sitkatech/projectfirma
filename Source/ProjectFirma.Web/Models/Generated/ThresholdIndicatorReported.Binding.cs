//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorReported]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ThresholdIndicatorReported]")]
    public partial class ThresholdIndicatorReported : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdIndicatorReported()
        {
            this.ThresholdIndicatorReportedSubcategoryOptions = new HashSet<ThresholdIndicatorReportedSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorReported(int thresholdIndicatorReportedID, int thresholdIndicatorID, int thresholdIndicatorReportingPeriodID, double reportedValue) : this()
        {
            this.ThresholdIndicatorReportedID = thresholdIndicatorReportedID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.ThresholdIndicatorReportingPeriodID = thresholdIndicatorReportingPeriodID;
            this.ReportedValue = reportedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorReported(int thresholdIndicatorID, int thresholdIndicatorReportingPeriodID, double reportedValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdIndicatorReportedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.ThresholdIndicatorReportingPeriodID = thresholdIndicatorReportingPeriodID;
            this.ReportedValue = reportedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdIndicatorReported(ThresholdIndicator thresholdIndicator, ThresholdIndicatorReportingPeriod thresholdIndicatorReportingPeriod, double reportedValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdIndicatorReportedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdIndicatorID = thresholdIndicator.ThresholdIndicatorID;
            this.ThresholdIndicator = thresholdIndicator;
            thresholdIndicator.ThresholdIndicatorReporteds.Add(this);
            this.ThresholdIndicatorReportingPeriodID = thresholdIndicatorReportingPeriod.ThresholdIndicatorReportingPeriodID;
            this.ThresholdIndicatorReportingPeriod = thresholdIndicatorReportingPeriod;
            thresholdIndicatorReportingPeriod.ThresholdIndicatorReporteds.Add(this);
            this.ReportedValue = reportedValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdIndicatorReported CreateNewBlank(ThresholdIndicator thresholdIndicator, ThresholdIndicatorReportingPeriod thresholdIndicatorReportingPeriod)
        {
            return new ThresholdIndicatorReported(thresholdIndicator, thresholdIndicatorReportingPeriod, default(double));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ThresholdIndicatorReportedSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdIndicatorReported).Name, typeof(ThresholdIndicatorReportedSubcategoryOption).Name};

        [Key]
        public int ThresholdIndicatorReportedID { get; set; }
        public int ThresholdIndicatorID { get; set; }
        public int ThresholdIndicatorReportingPeriodID { get; set; }
        public double ReportedValue { get; set; }
        public int PrimaryKey { get { return ThresholdIndicatorReportedID; } set { ThresholdIndicatorReportedID = value; } }

        public virtual ICollection<ThresholdIndicatorReportedSubcategoryOption> ThresholdIndicatorReportedSubcategoryOptions { get; set; }
        public virtual ThresholdIndicator ThresholdIndicator { get; set; }
        public virtual ThresholdIndicatorReportingPeriod ThresholdIndicatorReportingPeriod { get; set; }

        public static class FieldLengths
        {

        }
    }
}