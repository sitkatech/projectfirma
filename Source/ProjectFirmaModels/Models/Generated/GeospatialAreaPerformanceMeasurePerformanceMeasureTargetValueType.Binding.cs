//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]")]
    public partial class GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType(int geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID, int geospatialAreaID, int performanceMeasureID, int performanceMeasureTargetValueTypeID) : this()
        {
            this.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID = geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID;
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureTargetValueTypeID = performanceMeasureTargetValueTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType(int geospatialAreaID, int performanceMeasureID, int performanceMeasureTargetValueTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureTargetValueTypeID = performanceMeasureTargetValueTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure, PerformanceMeasureTargetValueType performanceMeasureTargetValueType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypes.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypes.Add(this);
            this.PerformanceMeasureTargetValueTypeID = performanceMeasureTargetValueType.PerformanceMeasureTargetValueTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType CreateNewBlank(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure, PerformanceMeasureTargetValueType performanceMeasureTargetValueType)
        {
            return new GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType(geospatialArea, performanceMeasure, performanceMeasureTargetValueType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID { get; set; }
        public int TenantID { get; set; }
        public int GeospatialAreaID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureTargetValueTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID; } set { GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialArea GeospatialArea { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public PerformanceMeasureTargetValueType PerformanceMeasureTargetValueType { get { return PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}