//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectWatershed]
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
    [Table("[dbo].[ProjectWatershed]")]
    public partial class ProjectWatershed : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectWatershed()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectWatershed(int projectWatershedID, int projectID, int watershedID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProjectWatershedID = projectWatershedID;
            this.ProjectID = projectID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectWatershed(int projectID, int watershedID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectWatershedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectID = projectID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectWatershed(Project project, Watershed watershed) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectWatershedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectWatersheds.Add(this);
            this.WatershedID = watershed.WatershedID;
            this.Watershed = watershed;
            watershed.ProjectWatersheds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectWatershed CreateNewBlank(Project project, Watershed watershed)
        {
            return new ProjectWatershed(project, watershed);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectWatershed).Name};

        [Key]
        public int ProjectWatershedID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int WatershedID { get; set; }
        public int PrimaryKey { get { return ProjectWatershedID; } set { ProjectWatershedID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Watershed Watershed { get; set; }

        public static class FieldLengths
        {

        }
    }
}