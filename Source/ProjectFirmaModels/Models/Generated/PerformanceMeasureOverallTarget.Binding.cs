//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureOverallTarget]
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
    // Table [dbo].[PerformanceMeasureOverallTarget] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PerformanceMeasureOverallTarget]")]
    public partial class PerformanceMeasureOverallTarget : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureOverallTarget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureOverallTarget(int performanceMeasureOverallTargetID, int performanceMeasureID, double? performanceMeasureTargetValue, string performanceMeasureTargetValueLabel) : this()
        {
            this.PerformanceMeasureOverallTargetID = performanceMeasureOverallTargetID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureTargetValue = performanceMeasureTargetValue;
            this.PerformanceMeasureTargetValueLabel = performanceMeasureTargetValueLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureOverallTarget(int performanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureOverallTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureOverallTarget(PerformanceMeasure performanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureOverallTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureOverallTargets.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureOverallTarget CreateNewBlank(PerformanceMeasure performanceMeasure)
        {
            return new PerformanceMeasureOverallTarget(performanceMeasure);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureOverallTarget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPerformanceMeasureOverallTargets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PerformanceMeasureOverallTargetID { get; set; }
        public int TenantID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double? PerformanceMeasureTargetValue { get; set; }
        public string PerformanceMeasureTargetValueLabel { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureOverallTargetID; } set { PerformanceMeasureOverallTargetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureTargetValueLabel = 100;
        }
    }
}