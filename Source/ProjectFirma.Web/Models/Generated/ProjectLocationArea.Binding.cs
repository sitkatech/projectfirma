//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationArea]
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
    [Table("[dbo].[ProjectLocationArea]")]
    public partial class ProjectLocationArea : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationArea()
        {
            this.Projects = new HashSet<Project>();
            this.ProjectLocationAreaJurisdictions = new HashSet<ProjectLocationAreaJurisdiction>();
            this.ProjectLocationAreaStateProvinces = new HashSet<ProjectLocationAreaStateProvince>();
            this.ProjectLocationAreaWatersheds = new HashSet<ProjectLocationAreaWatershed>();
            this.ProjectUpdates = new HashSet<ProjectUpdate>();
            this.ProposedProjects = new HashSet<ProposedProject>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationArea(int projectLocationAreaID, int? stateProvinceID, int? projectLocationAreaGroupID, int? mappedRegionID, int? jurisdictionID, int? watershedID) : this()
        {
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.StateProvinceID = stateProvinceID;
            this.ProjectLocationAreaGroupID = projectLocationAreaGroupID;
            this.MappedRegionID = mappedRegionID;
            this.JurisdictionID = jurisdictionID;
            this.WatershedID = watershedID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationArea CreateNewBlank()
        {
            return new ProjectLocationArea();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Projects.Any() || ProjectLocationAreaJurisdictions.Any() || ProjectLocationAreaStateProvinces.Any() || ProjectLocationAreaWatersheds.Any() || ProjectUpdates.Any() || ProposedProjects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationArea).Name, typeof(Project).Name, typeof(ProjectLocationAreaJurisdiction).Name, typeof(ProjectLocationAreaStateProvince).Name, typeof(ProjectLocationAreaWatershed).Name, typeof(ProjectUpdate).Name, typeof(ProposedProject).Name};

        [Key]
        public int ProjectLocationAreaID { get; set; }
        public int? StateProvinceID { get; set; }
        public int? ProjectLocationAreaGroupID { get; set; }
        public int? MappedRegionID { get; set; }
        public int? JurisdictionID { get; set; }
        public int? WatershedID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectLocationAreaID; } set { ProjectLocationAreaID = value; } }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProjectLocationAreaJurisdiction> ProjectLocationAreaJurisdictions { get; set; }
        public virtual ICollection<ProjectLocationAreaStateProvince> ProjectLocationAreaStateProvinces { get; set; }
        public virtual ICollection<ProjectLocationAreaWatershed> ProjectLocationAreaWatersheds { get; set; }
        public virtual ICollection<ProjectUpdate> ProjectUpdates { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjects { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public virtual ProjectLocationAreaGroup ProjectLocationAreaGroup { get; set; }
        public virtual MappedRegion MappedRegion { get; set; }
        public virtual Jurisdiction Jurisdiction { get; set; }
        public virtual Watershed Watershed { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}