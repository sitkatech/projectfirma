//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImage]
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
    [Table("[dbo].[ProjectImage]")]
    public partial class ProjectImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectImage()
        {
            this.ProjectImageUpdates = new HashSet<ProjectImageUpdate>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectImage(int projectImageID, int fileResourceID, int projectID, int projectImageTimingID, string caption, string credit, bool isKeyPhoto, bool excludeFromFactSheet) : this()
        {
            this.ProjectImageID = projectImageID;
            this.FileResourceID = fileResourceID;
            this.ProjectID = projectID;
            this.ProjectImageTimingID = projectImageTimingID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
            this.ExcludeFromFactSheet = excludeFromFactSheet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectImage(int fileResourceID, int projectID, int projectImageTimingID, string caption, string credit, bool isKeyPhoto, bool excludeFromFactSheet) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceID = fileResourceID;
            this.ProjectID = projectID;
            this.ProjectImageTimingID = projectImageTimingID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
            this.ExcludeFromFactSheet = excludeFromFactSheet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectImage(FileResource fileResource, Project project, ProjectImageTiming projectImageTiming, string caption, string credit, bool isKeyPhoto, bool excludeFromFactSheet) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ProjectImages.Add(this);
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectImages.Add(this);
            this.ProjectImageTimingID = projectImageTiming.ProjectImageTimingID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
            this.ExcludeFromFactSheet = excludeFromFactSheet;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectImage CreateNewBlank(FileResource fileResource, Project project, ProjectImageTiming projectImageTiming)
        {
            return new ProjectImage(fileResource, project, projectImageTiming, default(string), default(string), default(bool), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectImageUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectImage).Name, typeof(ProjectImageUpdate).Name};

        [Key]
        public int ProjectImageID { get; set; }
        public int TenantID { get; private set; }
        public int FileResourceID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectImageTimingID { get; set; }
        public string Caption { get; set; }
        public string Credit { get; set; }
        public bool IsKeyPhoto { get; set; }
        public bool ExcludeFromFactSheet { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectImageID; } set { ProjectImageID = value; } }

        public virtual ICollection<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FileResource FileResource { get; set; }
        public virtual Project Project { get; set; }
        public ProjectImageTiming ProjectImageTiming { get { return ProjectImageTiming.AllLookupDictionary[ProjectImageTimingID]; } }

        public static class FieldLengths
        {
            public const int Caption = 200;
            public const int Credit = 200;
        }
    }
}