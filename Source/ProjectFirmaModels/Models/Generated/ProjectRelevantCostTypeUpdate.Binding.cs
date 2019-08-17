//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostTypeUpdate]
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
    // Table [dbo].[ProjectRelevantCostTypeUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectRelevantCostTypeUpdate]")]
    public partial class ProjectRelevantCostTypeUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectRelevantCostTypeUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectRelevantCostTypeUpdate(int projectRelevantCostTypeUpdateID, int projectUpdateBatchID, int costTypeID, int projectRelevantCostTypeGroupID) : this()
        {
            this.ProjectRelevantCostTypeUpdateID = projectRelevantCostTypeUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.CostTypeID = costTypeID;
            this.ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroupID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectRelevantCostTypeUpdate(int projectUpdateBatchID, int costTypeID, int projectRelevantCostTypeGroupID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectRelevantCostTypeUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.CostTypeID = costTypeID;
            this.ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroupID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectRelevantCostTypeUpdate(ProjectUpdateBatch projectUpdateBatch, CostType costType, ProjectRelevantCostTypeGroup projectRelevantCostTypeGroup) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectRelevantCostTypeUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectRelevantCostTypeUpdates.Add(this);
            this.CostTypeID = costType.CostTypeID;
            this.CostType = costType;
            costType.ProjectRelevantCostTypeUpdates.Add(this);
            this.ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroup.ProjectRelevantCostTypeGroupID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectRelevantCostTypeUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, CostType costType, ProjectRelevantCostTypeGroup projectRelevantCostTypeGroup)
        {
            return new ProjectRelevantCostTypeUpdate(projectUpdateBatch, costType, projectRelevantCostTypeGroup);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectRelevantCostTypeUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectRelevantCostTypeUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectRelevantCostTypeUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int CostTypeID { get; set; }
        public int ProjectRelevantCostTypeGroupID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectRelevantCostTypeUpdateID; } set { ProjectRelevantCostTypeUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual CostType CostType { get; set; }
        public ProjectRelevantCostTypeGroup ProjectRelevantCostTypeGroup { get { return ProjectRelevantCostTypeGroup.AllLookupDictionary[ProjectRelevantCostTypeGroupID]; } }

        public static class FieldLengths
        {

        }
    }
}