//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchMakerAreaOfInterestLocation]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[MatchMakerAreaOfInterestLocation] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[MatchMakerAreaOfInterestLocation]")]
    public partial class MatchMakerAreaOfInterestLocation : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchMakerAreaOfInterestLocation()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchMakerAreaOfInterestLocation(int matchMakerAreaOfInterestLocationID, int organizationID, DbGeometry matchMakerAreaOfInterestLocationGeometry, string annotation) : this()
        {
            this.MatchMakerAreaOfInterestLocationID = matchMakerAreaOfInterestLocationID;
            this.OrganizationID = organizationID;
            this.MatchMakerAreaOfInterestLocationGeometry = matchMakerAreaOfInterestLocationGeometry;
            this.Annotation = annotation;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchMakerAreaOfInterestLocation(int organizationID, DbGeometry matchMakerAreaOfInterestLocationGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchMakerAreaOfInterestLocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.MatchMakerAreaOfInterestLocationGeometry = matchMakerAreaOfInterestLocationGeometry;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MatchMakerAreaOfInterestLocation(Organization organization, DbGeometry matchMakerAreaOfInterestLocationGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchMakerAreaOfInterestLocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.MatchMakerAreaOfInterestLocations.Add(this);
            this.MatchMakerAreaOfInterestLocationGeometry = matchMakerAreaOfInterestLocationGeometry;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchMakerAreaOfInterestLocation CreateNewBlank(Organization organization)
        {
            return new MatchMakerAreaOfInterestLocation(organization, default(DbGeometry));
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchMakerAreaOfInterestLocation).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllMatchMakerAreaOfInterestLocations.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int MatchMakerAreaOfInterestLocationID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public DbGeometry MatchMakerAreaOfInterestLocationGeometry { get; set; }
        public string Annotation { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchMakerAreaOfInterestLocationID; } set { MatchMakerAreaOfInterestLocationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int Annotation = 255;
        }
    }
}