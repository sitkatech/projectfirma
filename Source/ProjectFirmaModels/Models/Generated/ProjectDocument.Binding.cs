//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocument]
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
    // Table [dbo].[ProjectDocument] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectDocument]")]
    public partial class ProjectDocument : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectDocument()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectDocument(int projectDocumentID, int projectID, int fileResourceID, string displayName, string description) : this()
        {
            this.ProjectDocumentID = projectDocumentID;
            this.ProjectID = projectID;
            this.FileResourceID = fileResourceID;
            this.DisplayName = displayName;
            this.Description = description;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectDocument(int projectID, int fileResourceID, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectDocumentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.FileResourceID = fileResourceID;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectDocument(Project project, FileResource fileResource, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectDocumentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectDocuments.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ProjectDocuments.Add(this);
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectDocument CreateNewBlank(Project project, FileResource fileResource)
        {
            return new ProjectDocument(project, fileResource, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectDocument).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectDocuments.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectDocumentID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int FileResourceID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectDocumentID; } set { ProjectDocumentID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {
            public const int DisplayName = 200;
            public const int Description = 1000;
        }
    }
}