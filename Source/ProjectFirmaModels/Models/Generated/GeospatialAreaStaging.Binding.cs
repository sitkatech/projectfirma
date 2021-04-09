//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaStaging]
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
    // Table [dbo].[GeospatialAreaStaging] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaStaging]")]
    public partial class GeospatialAreaStaging : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaStaging()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaStaging(int geospatialAreaStagingID, string name, string externalID, DbGeometry geometry) : this()
        {
            this.GeospatialAreaStagingID = geospatialAreaStagingID;
            this.Name = name;
            this.ExternalID = externalID;
            this.Geometry = geometry;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaStaging(string name, string externalID, DbGeometry geometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.Name = name;
            this.ExternalID = externalID;
            this.Geometry = geometry;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaStaging CreateNewBlank()
        {
            return new GeospatialAreaStaging(default(string), default(string), default(DbGeometry));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaStaging).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaStagings.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int GeospatialAreaStagingID { get; set; }
        public int TenantID { get; set; }
        public string Name { get; set; }
        public string ExternalID { get; set; }
        public DbGeometry Geometry { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaStagingID; } set { GeospatialAreaStagingID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int Name = 100;
            public const int ExternalID = 100;
        }
    }
}