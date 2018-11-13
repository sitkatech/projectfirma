//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocumentUpdate]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ProjectDocumentUpdate]")]
    public partial class ProjectDocumentUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectDocumentUpdate()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectDocumentUpdate(int projectDocumentUpdateID, int projectUpdateBatchID, int fileResourceID, string displayName, string description) : this()
        {
            this.ProjectDocumentUpdateID = projectDocumentUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FileResourceID = fileResourceID;
            this.DisplayName = displayName;
            this.Description = description;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectDocumentUpdate(int projectUpdateBatchID, int fileResourceID, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectDocumentUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FileResourceID = fileResourceID;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectDocumentUpdate(ProjectUpdateBatch projectUpdateBatch, FileResource fileResource, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectDocumentUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectDocumentUpdates.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ProjectDocumentUpdates.Add(this);
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectDocumentUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, FileResource fileResource)
        {
            return new ProjectDocumentUpdate(projectUpdateBatch, fileResource, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectDocumentUpdate).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            DeleteFull(HttpRequestStorage.DatabaseEntities);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            dbContext.AllProjectDocumentUpdates.Remove(this);
        }

        [Key]
        public int ProjectDocumentUpdateID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FileResourceID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectDocumentUpdateID; } set { ProjectDocumentUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {
            public const int DisplayName = 200;
            public const int Description = 1000;
        }
    }
}