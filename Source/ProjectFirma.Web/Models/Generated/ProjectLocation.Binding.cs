//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocation]
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
    [Table("[dbo].[ProjectLocation]")]
    public partial class ProjectLocation : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocation()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocation(int projectLocationID, int projectID, DbGeometry projectLocationGeometry, string annotation) : this()
        {
            this.ProjectLocationID = projectLocationID;
            this.ProjectID = projectID;
            this.ProjectLocationGeometry = projectLocationGeometry;
            this.Annotation = annotation;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocation(int projectID, DbGeometry projectLocationGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.ProjectLocationGeometry = projectLocationGeometry;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocation(Project project, DbGeometry projectLocationGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectLocations.Add(this);
            this.ProjectLocationGeometry = projectLocationGeometry;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocation CreateNewBlank(Project project)
        {
            return new ProjectLocation(project, default(DbGeometry));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocation).Name};

        [Key]
        public int ProjectLocationID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public DbGeometry ProjectLocationGeometry { get; set; }
        public string Annotation { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectLocationID; } set { ProjectLocationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {
            public const int Annotation = 255;
        }
    }
}