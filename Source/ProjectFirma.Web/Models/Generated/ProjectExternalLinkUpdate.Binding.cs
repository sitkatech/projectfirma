//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLinkUpdate]
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
    [Table("[dbo].[ProjectExternalLinkUpdate]")]
    public partial class ProjectExternalLinkUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectExternalLinkUpdate()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExternalLinkUpdate(int projectExternalLinkUpdateID, int projectUpdateBatchID, string externalLinkLabel, string externalLinkUrl) : this()
        {
            this.ProjectExternalLinkUpdateID = projectExternalLinkUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ExternalLinkLabel = externalLinkLabel;
            this.ExternalLinkUrl = externalLinkUrl;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExternalLinkUpdate(int projectUpdateBatchID, string externalLinkLabel, string externalLinkUrl) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectExternalLinkUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ExternalLinkLabel = externalLinkLabel;
            this.ExternalLinkUrl = externalLinkUrl;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectExternalLinkUpdate(ProjectUpdateBatch projectUpdateBatch, string externalLinkLabel, string externalLinkUrl) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectExternalLinkUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectExternalLinkUpdates.Add(this);
            this.ExternalLinkLabel = externalLinkLabel;
            this.ExternalLinkUrl = externalLinkUrl;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectExternalLinkUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectExternalLinkUpdate(projectUpdateBatch, default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectExternalLinkUpdate).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(HttpRequestStorage.DatabaseEntities);
            dbContext.AllProjectExternalLinkUpdates.Remove(this);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

        }

        [Key]
        public int ProjectExternalLinkUpdateID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectUpdateBatchID { get; set; }
        public string ExternalLinkLabel { get; set; }
        public string ExternalLinkUrl { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectExternalLinkUpdateID; } set { ProjectExternalLinkUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }

        public static class FieldLengths
        {
            public const int ExternalLinkLabel = 300;
            public const int ExternalLinkUrl = 300;
        }
    }
}