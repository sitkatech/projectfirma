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

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExternalLinkUpdate(int projectExternalLinkUpdateID, int projectUpdateBatchID, string externalLinkLabel, string externalLinkUrl) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
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
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
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
            this.Tenant = HttpRequestStorage.Tenant;
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

        [Key]
        public int ProjectExternalLinkUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public string ExternalLinkLabel { get; set; }
        public string ExternalLinkUrl { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectExternalLinkUpdateID; } set { ProjectExternalLinkUpdateID = value; } }

        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int ExternalLinkLabel = 300;
            public const int ExternalLinkUrl = 300;
        }
    }
}