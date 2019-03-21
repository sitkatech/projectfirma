//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttribute]
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
    // Table [dbo].[ProjectCustomAttribute] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomAttribute]")]
    public partial class ProjectCustomAttribute : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttribute()
        {
            this.ProjectCustomAttributeValues = new HashSet<ProjectCustomAttributeValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttribute(int projectCustomAttributeID, int projectID, int projectCustomAttributeTypeID) : this()
        {
            this.ProjectCustomAttributeID = projectCustomAttributeID;
            this.ProjectID = projectID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttribute(int projectID, int projectCustomAttributeTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttribute(Project project, ProjectCustomAttributeType projectCustomAttributeType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectCustomAttributes.Add(this);
            this.ProjectCustomAttributeTypeID = projectCustomAttributeType.ProjectCustomAttributeTypeID;
            this.ProjectCustomAttributeType = projectCustomAttributeType;
            projectCustomAttributeType.ProjectCustomAttributes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttribute CreateNewBlank(Project project, ProjectCustomAttributeType projectCustomAttributeType)
        {
            return new ProjectCustomAttribute(project, projectCustomAttributeType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectCustomAttributeValues.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttribute).Name, typeof(ProjectCustomAttributeValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomAttributes.Remove(this);
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

            foreach(var x in ProjectCustomAttributeValues.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectCustomAttributeID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectCustomAttributeTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeID; } set { ProjectCustomAttributeID = value; } }

        public virtual ICollection<ProjectCustomAttributeValue> ProjectCustomAttributeValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }

        public static class FieldLengths
        {

        }
    }
}