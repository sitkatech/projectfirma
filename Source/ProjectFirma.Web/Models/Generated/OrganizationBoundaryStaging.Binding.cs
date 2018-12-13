//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationBoundaryStaging]
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
    [Table("[dbo].[OrganizationBoundaryStaging]")]
    public partial class OrganizationBoundaryStaging : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected OrganizationBoundaryStaging()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationBoundaryStaging(int organizationBoundaryStagingID, int organizationID, string featureClassName, string geoJson) : this()
        {
            this.OrganizationBoundaryStagingID = organizationBoundaryStagingID;
            this.OrganizationID = organizationID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationBoundaryStaging(int organizationID, string featureClassName, string geoJson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationBoundaryStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public OrganizationBoundaryStaging(Organization organization, string featureClassName, string geoJson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationBoundaryStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.OrganizationBoundaryStagings.Add(this);
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static OrganizationBoundaryStaging CreateNewBlank(Organization organization)
        {
            return new OrganizationBoundaryStaging(organization, default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(OrganizationBoundaryStaging).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllOrganizationBoundaryStagings.Remove(this);
        }

        [Key]
        public int OrganizationBoundaryStagingID { get; set; }
        public int TenantID { get; private set; }
        public int OrganizationID { get; set; }
        public string FeatureClassName { get; set; }
        public string GeoJson { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationBoundaryStagingID; } set { OrganizationBoundaryStagingID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int FeatureClassName = 255;
        }
    }
}