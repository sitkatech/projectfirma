//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroupProjectCategory]
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
    // Table [dbo].[ProjectCustomAttributeGroupProjectCategory] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomAttributeGroupProjectCategory]")]
    public partial class ProjectCustomAttributeGroupProjectCategory : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeGroupProjectCategory()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeGroupProjectCategory(int projectCustomAttributeGroupProjectCategoryID, int projectCustomAttributeGroupID, int projectCategoryID) : this()
        {
            this.ProjectCustomAttributeGroupProjectCategoryID = projectCustomAttributeGroupProjectCategoryID;
            this.ProjectCustomAttributeGroupID = projectCustomAttributeGroupID;
            this.ProjectCategoryID = projectCategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeGroupProjectCategory(int projectCustomAttributeGroupID, int projectCategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeGroupProjectCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectCustomAttributeGroupID = projectCustomAttributeGroupID;
            this.ProjectCategoryID = projectCategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttributeGroupProjectCategory(ProjectCustomAttributeGroup projectCustomAttributeGroup, ProjectCategory projectCategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeGroupProjectCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectCustomAttributeGroupID = projectCustomAttributeGroup.ProjectCustomAttributeGroupID;
            this.ProjectCustomAttributeGroup = projectCustomAttributeGroup;
            projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.Add(this);
            this.ProjectCategoryID = projectCategory.ProjectCategoryID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeGroupProjectCategory CreateNewBlank(ProjectCustomAttributeGroup projectCustomAttributeGroup, ProjectCategory projectCategory)
        {
            return new ProjectCustomAttributeGroupProjectCategory(projectCustomAttributeGroup, projectCategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeGroupProjectCategory).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomAttributeGroupProjectCategories.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectCustomAttributeGroupProjectCategoryID { get; set; }
        public int TenantID { get; set; }
        public int ProjectCustomAttributeGroupID { get; set; }
        public int ProjectCategoryID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeGroupProjectCategoryID; } set { ProjectCustomAttributeGroupProjectCategoryID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectCustomAttributeGroup ProjectCustomAttributeGroup { get; set; }
        public ProjectCategory ProjectCategory { get { return ProjectCategory.AllLookupDictionary[ProjectCategoryID]; } }

        public static class FieldLengths
        {

        }
    }
}