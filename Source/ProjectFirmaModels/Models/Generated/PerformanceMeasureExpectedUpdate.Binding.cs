//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedUpdate]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[PerformanceMeasureExpectedUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PerformanceMeasureExpectedUpdate]")]
    public partial class PerformanceMeasureExpectedUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureExpectedUpdate()
        {
            this.PerformanceMeasureExpectedSubcategoryOptionUpdates = new HashSet<PerformanceMeasureExpectedSubcategoryOptionUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedUpdate(int performanceMeasureExpectedUpdateID, int projectUpdateBatchID, int performanceMeasureID, double? expectedValue) : this()
        {
            this.PerformanceMeasureExpectedUpdateID = performanceMeasureExpectedUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedUpdate(int projectUpdateBatchID, int performanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureExpectedUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureExpectedUpdate(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasure performanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureExpectedUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.PerformanceMeasureExpectedUpdates.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureExpectedUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureExpectedUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasure performanceMeasure)
        {
            return new PerformanceMeasureExpectedUpdate(projectUpdateBatch, performanceMeasure);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureExpectedSubcategoryOptionUpdates.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(PerformanceMeasureExpectedSubcategoryOptionUpdates.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureExpectedSubcategoryOptionUpdate).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureExpectedUpdate).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPerformanceMeasureExpectedUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in PerformanceMeasureExpectedSubcategoryOptionUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PerformanceMeasureExpectedUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureExpectedUpdateID; } set { PerformanceMeasureExpectedUpdateID = value; } }

        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionUpdate> PerformanceMeasureExpectedSubcategoryOptionUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}