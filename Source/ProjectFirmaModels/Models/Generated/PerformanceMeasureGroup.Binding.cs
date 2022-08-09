//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureGroup]
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
    // Table [dbo].[PerformanceMeasureGroup] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PerformanceMeasureGroup]")]
    public partial class PerformanceMeasureGroup : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureGroup()
        {
            this.PerformanceMeasures = new HashSet<PerformanceMeasure>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureGroup(int performanceMeasureGroupID, string performanceMeasureGroupName, int? iconFileResourceInfoID) : this()
        {
            this.PerformanceMeasureGroupID = performanceMeasureGroupID;
            this.PerformanceMeasureGroupName = performanceMeasureGroupName;
            this.IconFileResourceInfoID = iconFileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureGroup(string performanceMeasureGroupName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureGroupID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureGroupName = performanceMeasureGroupName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureGroup CreateNewBlank()
        {
            return new PerformanceMeasureGroup(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasures.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(PerformanceMeasures.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasure).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureGroup).Name, typeof(PerformanceMeasure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPerformanceMeasureGroups.Remove(this);
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

            foreach(var x in PerformanceMeasures.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PerformanceMeasureGroupID { get; set; }
        public int TenantID { get; set; }
        public string PerformanceMeasureGroupName { get; set; }
        public int? IconFileResourceInfoID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureGroupID; } set { PerformanceMeasureGroupID = value; } }

        public virtual ICollection<PerformanceMeasure> PerformanceMeasures { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FileResourceInfo IconFileResourceInfo { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureGroupName = 200;
        }
    }
}