//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectTag]
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
    // Table [dbo].[ProjectTag] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectTag]")]
    public partial class ProjectTag : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectTag()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectTag(int projectTagID, int projectID, int tagID) : this()
        {
            this.ProjectTagID = projectTagID;
            this.ProjectID = projectID;
            this.TagID = tagID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectTag(int projectID, int tagID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectTagID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.TagID = tagID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectTag(Project project, Tag tag) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectTagID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectTags.Add(this);
            this.TagID = tag.TagID;
            this.Tag = tag;
            tag.ProjectTags.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectTag CreateNewBlank(Project project, Tag tag)
        {
            return new ProjectTag(project, tag);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectTag).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllProjectTags.Remove(this);
        }

        [Key]
        public int ProjectTagID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int TagID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectTagID; } set { ProjectTagID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Tag Tag { get; set; }

        public static class FieldLengths
        {

        }
    }
}