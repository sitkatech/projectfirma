//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportingPeriod]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[PerformanceMeasureReportingPeriod] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[PerformanceMeasureReportingPeriod]")]
    public partial class PerformanceMeasureReportingPeriod : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureReportingPeriod()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureReportingPeriod(int performanceMeasureReportingPeriodID, int performanceMeasureID, DateTime performanceMeasureReportingPeriodBeginDate, DateTime? performanceMeasureReportingPeriodEndDate, string performanceMeasureReportingPeriodLabel, double? targetValue, string targetValueDescription) : this()
        {
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureReportingPeriodBeginDate = performanceMeasureReportingPeriodBeginDate;
            this.PerformanceMeasureReportingPeriodEndDate = performanceMeasureReportingPeriodEndDate;
            this.PerformanceMeasureReportingPeriodLabel = performanceMeasureReportingPeriodLabel;
            this.TargetValue = targetValue;
            this.TargetValueDescription = targetValueDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureReportingPeriod(int performanceMeasureID, DateTime performanceMeasureReportingPeriodBeginDate, string performanceMeasureReportingPeriodLabel) : this()
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
        public PerformanceMeasureReportingPeriod(PerformanceMeasure performanceMeasure, DateTime performanceMeasureReportingPeriodBeginDate, string performanceMeasureReportingPeriodLabel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureReportingPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureReportingPeriods.Add(this);
            this.PerformanceMeasureReportingPeriodBeginDate = performanceMeasureReportingPeriodBeginDate;
            this.PerformanceMeasureReportingPeriodLabel = performanceMeasureReportingPeriodLabel;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureReportingPeriod CreateNewBlank(PerformanceMeasure performanceMeasure)
        {
            return new PerformanceMeasureReportingPeriod(performanceMeasure, default(DateTime), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureReportingPeriod).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PerformanceMeasureReportingPeriods.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PerformanceMeasureReportingPeriodID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public DateTime PerformanceMeasureReportingPeriodBeginDate { get; set; }
        public DateTime? PerformanceMeasureReportingPeriodEndDate { get; set; }
        public string PerformanceMeasureReportingPeriodLabel { get; set; }
        public double? TargetValue { get; set; }
        public string TargetValueDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureReportingPeriodID; } set { PerformanceMeasureReportingPeriodID = value; } }

        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureReportingPeriodLabel = 100;
            public const int TargetValueDescription = 100;
        }
    }
}