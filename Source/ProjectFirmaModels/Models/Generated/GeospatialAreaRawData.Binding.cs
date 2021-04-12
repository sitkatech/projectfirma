//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaRawData]
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
    // Table [dbo].[GeospatialAreaRawData] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaRawData]")]
    public partial class GeospatialAreaRawData : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaRawData()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaRawData(int geospatialAreaRawDataID, int geospatialAreaTypeID, string resultJson) : this()
        {
            this.GeospatialAreaRawDataID = geospatialAreaRawDataID;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.ResultJson = resultJson;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaRawData(int geospatialAreaTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaRawDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialAreaRawData(GeospatialAreaType geospatialAreaType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaRawDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            this.GeospatialAreaType = geospatialAreaType;
            geospatialAreaType.GeospatialAreaRawDatas.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaRawData CreateNewBlank(GeospatialAreaType geospatialAreaType)
        {
            return new GeospatialAreaRawData(geospatialAreaType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaRawData).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaRawDatas.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int GeospatialAreaRawDataID { get; set; }
        public int TenantID { get; set; }
        public int GeospatialAreaTypeID { get; set; }
        public string ResultJson { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaRawDataID; } set { GeospatialAreaRawDataID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialAreaType GeospatialAreaType { get; set; }

        public static class FieldLengths
        {

        }
    }
}