//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdate]
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
    // Table [dbo].[ProjectCustomAttributeUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomAttributeUpdate]")]
    public partial class ProjectCustomAttributeUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeUpdate()
        {
            this.ProjectCustomAttributeUpdateValues = new HashSet<ProjectCustomAttributeUpdateValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeUpdate(int projectCustomAttributeUpdateID, int projectUpdateBatchID, int projectCustomAttributeTypeID) : this()
        {
            this.ProjectCustomAttributeUpdateID = projectCustomAttributeUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeUpdate(int projectUpdateBatchID, int projectCustomAttributeTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttributeUpdate(ProjectUpdateBatch projectUpdateBatch, ProjectCustomAttributeType projectCustomAttributeType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectCustomAttributeUpdates.Add(this);
            this.ProjectCustomAttributeTypeID = projectCustomAttributeType.ProjectCustomAttributeTypeID;
            this.ProjectCustomAttributeType = projectCustomAttributeType;
            projectCustomAttributeType.ProjectCustomAttributeUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, ProjectCustomAttributeType projectCustomAttributeType)
        {
            return new ProjectCustomAttributeUpdate(projectUpdateBatch, projectCustomAttributeType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectCustomAttributeUpdateValues.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ProjectCustomAttributeUpdateValues.Any())
            {
                dependentObjects.Add(typeof(ProjectCustomAttributeUpdateValue).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeUpdate).Name, typeof(ProjectCustomAttributeUpdateValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomAttributeUpdates.Remove(this);
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

            foreach(var x in ProjectCustomAttributeUpdateValues.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectCustomAttributeUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int ProjectCustomAttributeTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeUpdateID; } set { ProjectCustomAttributeUpdateID = value; } }

        public virtual ICollection<ProjectCustomAttributeUpdateValue> ProjectCustomAttributeUpdateValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }

        public static class FieldLengths
        {

        }
    }
}