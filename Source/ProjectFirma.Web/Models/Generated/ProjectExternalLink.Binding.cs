//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLink]
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
    [Table("[dbo].[ProjectExternalLink]")]
    public partial class ProjectExternalLink : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectExternalLink()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExternalLink(int projectExternalLinkID, int projectID, string externalLinkLabel, string externalLinkUrl) : this()
        {
            this.ProjectExternalLinkID = projectExternalLinkID;
            this.ProjectID = projectID;
            this.ExternalLinkLabel = externalLinkLabel;
            this.ExternalLinkUrl = externalLinkUrl;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExternalLink(int projectID, string externalLinkLabel, string externalLinkUrl) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectExternalLinkID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.ExternalLinkLabel = externalLinkLabel;
            this.ExternalLinkUrl = externalLinkUrl;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectExternalLink(Project project, string externalLinkLabel, string externalLinkUrl) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectExternalLinkID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectExternalLinks.Add(this);
            this.ExternalLinkLabel = externalLinkLabel;
            this.ExternalLinkUrl = externalLinkUrl;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectExternalLink CreateNewBlank(Project project)
        {
            return new ProjectExternalLink(project, default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectExternalLink).Name};

        [Key]
        public int ProjectExternalLinkID { get; set; }
        public int ProjectID { get; set; }
        public string ExternalLinkLabel { get; set; }
        public string ExternalLinkUrl { get; set; }
        public int PrimaryKey { get { return ProjectExternalLinkID; } set { ProjectExternalLinkID = value; } }

        public virtual Project Project { get; set; }

        public static class FieldLengths
        {
            public const int ExternalLinkLabel = 300;
            public const int ExternalLinkUrl = 300;
        }
    }
}