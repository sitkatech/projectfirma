//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureTarget]
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
    // Table [dbo].[PerformanceMeasureTarget] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PerformanceMeasureTarget]")]
    public partial class PerformanceMeasureTarget : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureTarget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureTarget(int performanceMeasureTargetID, int performanceMeasureID, int performanceMeasureReportingPeriodID, double? performanceMeasureTargetValue, string performanceMeasureTargetValueLabel) : this()
        {
            this.PerformanceMeasureTargetID = performanceMeasureTargetID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
            this.PerformanceMeasureTargetValue = performanceMeasureTargetValue;
            this.PerformanceMeasureTargetValueLabel = performanceMeasureTargetValueLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureTarget(int performanceMeasureID, int performanceMeasureReportingPeriodID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureTarget(PerformanceMeasure performanceMeasure, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureTargets.Add(this);
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID;
            this.PerformanceMeasureReportingPeriod = performanceMeasureReportingPeriod;
            performanceMeasureReportingPeriod.PerformanceMeasureTargets.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureTarget CreateNewBlank(PerformanceMeasure performanceMeasure, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod)
        {
            return new PerformanceMeasureTarget(performanceMeasure, performanceMeasureReportingPeriod);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureTarget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPerformanceMeasureTargets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PerformanceMeasureTargetID { get; set; }
        public int TenantID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureReportingPeriodID { get; set; }
        public double? PerformanceMeasureTargetValue { get; set; }
        public string PerformanceMeasureTargetValueLabel { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureTargetID; } set { PerformanceMeasureTargetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureTargetValueLabel = 100;
        }
    }
}