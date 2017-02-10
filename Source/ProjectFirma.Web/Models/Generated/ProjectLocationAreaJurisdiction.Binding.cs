//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaJurisdiction]
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
    [Table("[dbo].[ProjectLocationAreaJurisdiction]")]
    public partial class ProjectLocationAreaJurisdiction : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationAreaJurisdiction()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaJurisdiction(int projectLocationAreaJurisdictionID, int projectLocationAreaID, int jurisdictionID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProjectLocationAreaJurisdictionID = projectLocationAreaJurisdictionID;
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.JurisdictionID = jurisdictionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaJurisdiction(int projectLocationAreaID, int jurisdictionID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationAreaJurisdictionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.JurisdictionID = jurisdictionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocationAreaJurisdiction(ProjectLocationArea projectLocationArea, Jurisdiction jurisdiction) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationAreaJurisdictionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.ProjectLocationAreaID = projectLocationArea.ProjectLocationAreaID;
            this.ProjectLocationArea = projectLocationArea;
            projectLocationArea.ProjectLocationAreaJurisdictions.Add(this);
            this.JurisdictionID = jurisdiction.JurisdictionID;
            this.Jurisdiction = jurisdiction;
            jurisdiction.ProjectLocationAreaJurisdictions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationAreaJurisdiction CreateNewBlank(ProjectLocationArea projectLocationArea, Jurisdiction jurisdiction)
        {
            return new ProjectLocationAreaJurisdiction(projectLocationArea, jurisdiction);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationAreaJurisdiction).Name};

        [Key]
        public int ProjectLocationAreaJurisdictionID { get; set; }
        public int ProjectLocationAreaID { get; set; }
        public int JurisdictionID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectLocationAreaJurisdictionID; } set { ProjectLocationAreaJurisdictionID = value; } }

        public virtual ProjectLocationArea ProjectLocationArea { get; set; }
        public virtual Jurisdiction Jurisdiction { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}