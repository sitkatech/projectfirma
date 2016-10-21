//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicatorReportingPeriod]
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
    [Table("[dbo].[SustainabilityIndicatorReportingPeriod]")]
    public partial class SustainabilityIndicatorReportingPeriod : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SustainabilityIndicatorReportingPeriod()
        {
            this.SustainabilityIndicatorReporteds = new HashSet<SustainabilityIndicatorReported>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicatorReportingPeriod(int sustainabilityIndicatorReportingPeriodID, int sustainabilityIndicatorID, DateTime sustainabilityIndicatorReportingPeriodBeginDate, DateTime? sustainabilityIndicatorReportingPeriodEndDate, string sustainabilityIndicatorReportingPeriodLabel, double? targetValue, string targetValueDescription) : this()
        {
            this.SustainabilityIndicatorReportingPeriodID = sustainabilityIndicatorReportingPeriodID;
            this.SustainabilityIndicatorID = sustainabilityIndicatorID;
            this.SustainabilityIndicatorReportingPeriodBeginDate = sustainabilityIndicatorReportingPeriodBeginDate;
            this.SustainabilityIndicatorReportingPeriodEndDate = sustainabilityIndicatorReportingPeriodEndDate;
            this.SustainabilityIndicatorReportingPeriodLabel = sustainabilityIndicatorReportingPeriodLabel;
            this.TargetValue = targetValue;
            this.TargetValueDescription = targetValueDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicatorReportingPeriod(int sustainabilityIndicatorID, DateTime sustainabilityIndicatorReportingPeriodBeginDate, string sustainabilityIndicatorReportingPeriodLabel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SustainabilityIndicatorReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SustainabilityIndicatorID = sustainabilityIndicatorID;
            this.SustainabilityIndicatorReportingPeriodBeginDate = sustainabilityIndicatorReportingPeriodBeginDate;
            this.SustainabilityIndicatorReportingPeriodLabel = sustainabilityIndicatorReportingPeriodLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SustainabilityIndicatorReportingPeriod(SustainabilityIndicator sustainabilityIndicator, DateTime sustainabilityIndicatorReportingPeriodBeginDate, string sustainabilityIndicatorReportingPeriodLabel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SustainabilityIndicatorReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SustainabilityIndicatorID = sustainabilityIndicator.SustainabilityIndicatorID;
            this.SustainabilityIndicator = sustainabilityIndicator;
            sustainabilityIndicator.SustainabilityIndicatorReportingPeriods.Add(this);
            this.SustainabilityIndicatorReportingPeriodBeginDate = sustainabilityIndicatorReportingPeriodBeginDate;
            this.SustainabilityIndicatorReportingPeriodLabel = sustainabilityIndicatorReportingPeriodLabel;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SustainabilityIndicatorReportingPeriod CreateNewBlank(SustainabilityIndicator sustainabilityIndicator)
        {
            return new SustainabilityIndicatorReportingPeriod(sustainabilityIndicator, default(DateTime), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SustainabilityIndicatorReporteds.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SustainabilityIndicatorReportingPeriod).Name, typeof(SustainabilityIndicatorReported).Name};

        [Key]
        public int SustainabilityIndicatorReportingPeriodID { get; set; }
        public int SustainabilityIndicatorID { get; set; }
        public DateTime SustainabilityIndicatorReportingPeriodBeginDate { get; set; }
        public DateTime? SustainabilityIndicatorReportingPeriodEndDate { get; set; }
        public string SustainabilityIndicatorReportingPeriodLabel { get; set; }
        public double? TargetValue { get; set; }
        public string TargetValueDescription { get; set; }
        public int PrimaryKey { get { return SustainabilityIndicatorReportingPeriodID; } set { SustainabilityIndicatorReportingPeriodID = value; } }

        public virtual ICollection<SustainabilityIndicatorReported> SustainabilityIndicatorReporteds { get; set; }
        public virtual SustainabilityIndicator SustainabilityIndicator { get; set; }

        public static class FieldLengths
        {
            public const int SustainabilityIndicatorReportingPeriodLabel = 100;
            public const int TargetValueDescription = 100;
        }
    }
}