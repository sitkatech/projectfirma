//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MappedRegion]
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
    [Table("[dbo].[MappedRegion]")]
    public partial class MappedRegion : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MappedRegion()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MappedRegion(int mappedRegionID, string regionName, string regionDisplayName, DbGeometry regionFeature) : this()
        {
            this.MappedRegionID = mappedRegionID;
            this.RegionName = regionName;
            this.RegionDisplayName = regionDisplayName;
            this.RegionFeature = regionFeature;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MappedRegion(string regionName, string regionDisplayName, DbGeometry regionFeature) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MappedRegionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.RegionName = regionName;
            this.RegionDisplayName = regionDisplayName;
            this.RegionFeature = regionFeature;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MappedRegion CreateNewBlank()
        {
            return new MappedRegion(default(string), default(string), default(DbGeometry));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MappedRegion).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllMappedRegions.Remove(this);
        }

        [Key]
        public int MappedRegionID { get; set; }
        public int TenantID { get; private set; }
        public string RegionName { get; set; }
        public string RegionDisplayName { get; set; }
        public DbGeometry RegionFeature { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MappedRegionID; } set { MappedRegionID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int RegionName = 255;
            public const int RegionDisplayName = 255;
        }
    }
}