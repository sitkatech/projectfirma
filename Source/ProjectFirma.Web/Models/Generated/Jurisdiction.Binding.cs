//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Jurisdiction]
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
    [Table("[dbo].[Jurisdiction]")]
    public partial class Jurisdiction : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Jurisdiction()
        {
            this.ProjectLocationAreas = new HashSet<ProjectLocationArea>();
            this.ProjectLocationAreaJurisdictions = new HashSet<ProjectLocationAreaJurisdiction>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Jurisdiction(int jurisdictionID, int organizationID, DbGeometry jurisdictionFeature, int? stateProvinceID) : this()
        {
            this.JurisdictionID = jurisdictionID;
            this.OrganizationID = organizationID;
            this.JurisdictionFeature = jurisdictionFeature;
            this.StateProvinceID = stateProvinceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Jurisdiction(int organizationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            JurisdictionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Jurisdiction(Organization organization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.JurisdictionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Jurisdiction CreateNewBlank(Organization organization)
        {
            return new Jurisdiction(organization);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectLocationAreas.Any() || ProjectLocationAreaJurisdictions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Jurisdiction).Name, typeof(ProjectLocationArea).Name, typeof(ProjectLocationAreaJurisdiction).Name};

        [Key]
        public int JurisdictionID { get; set; }
        public int OrganizationID { get; set; }
        public DbGeometry JurisdictionFeature { get; set; }
        public int? StateProvinceID { get; set; }
        public int PrimaryKey { get { return JurisdictionID; } set { JurisdictionID = value; } }

        public virtual ICollection<ProjectLocationArea> ProjectLocationAreas { get; set; }
        public virtual ICollection<ProjectLocationAreaJurisdiction> ProjectLocationAreaJurisdictions { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual StateProvince StateProvince { get; set; }

        public static class FieldLengths
        {

        }
    }
}