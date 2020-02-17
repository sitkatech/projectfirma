//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroupProjectType]
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
    // Table [dbo].[ProjectCustomAttributeGroupProjectType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomAttributeGroupProjectType]")]
    public partial class ProjectCustomAttributeGroupProjectType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeGroupProjectType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeGroupProjectType(int projectCustomAttributeGroupProjectTypeID, int projectCustomAttributeGroupID, int projectTypeID) : this()
        {
            this.ProjectCustomAttributeGroupProjectTypeID = projectCustomAttributeGroupProjectTypeID;
            this.ProjectCustomAttributeGroupID = projectCustomAttributeGroupID;
            this.ProjectTypeID = projectTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeGroupProjectType(int projectCustomAttributeGroupID, int projectTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeGroupProjectTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectCustomAttributeGroupID = projectCustomAttributeGroupID;
            this.ProjectTypeID = projectTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttributeGroupProjectType(ProjectCustomAttributeGroup projectCustomAttributeGroup, ProjectType projectType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeGroupProjectTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectCustomAttributeGroupID = projectCustomAttributeGroup.ProjectCustomAttributeGroupID;
            this.ProjectCustomAttributeGroup = projectCustomAttributeGroup;
            projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectTypes.Add(this);
            this.ProjectTypeID = projectType.ProjectTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeGroupProjectType CreateNewBlank(ProjectCustomAttributeGroup projectCustomAttributeGroup, ProjectType projectType)
        {
            return new ProjectCustomAttributeGroupProjectType(projectCustomAttributeGroup, projectType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeGroupProjectType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomAttributeGroupProjectTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectCustomAttributeGroupProjectTypeID { get; set; }
        public int TenantID { get; set; }
        public int ProjectCustomAttributeGroupID { get; set; }
        public int ProjectTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeGroupProjectTypeID; } set { ProjectCustomAttributeGroupProjectTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectCustomAttributeGroup ProjectCustomAttributeGroup { get; set; }
        public ProjectType ProjectType { get { return ProjectType.AllLookupDictionary[ProjectTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}