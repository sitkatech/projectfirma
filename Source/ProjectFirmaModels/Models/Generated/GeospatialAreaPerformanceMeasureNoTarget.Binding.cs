//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureNoTarget]
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
    // Table [dbo].[GeospatialAreaPerformanceMeasureNoTarget] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaPerformanceMeasureNoTarget]")]
    public partial class GeospatialAreaPerformanceMeasureNoTarget : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaPerformanceMeasureNoTarget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasureNoTarget(int geospatialAreaPerformanceMeasureNoTargetID, int geospatialAreaID, int performanceMeasureID) : this()
        {
            this.GeospatialAreaPerformanceMeasureNoTargetID = geospatialAreaPerformanceMeasureNoTargetID;
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasureNoTarget(int geospatialAreaID, int performanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasureNoTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialAreaPerformanceMeasureNoTarget(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasureNoTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.GeospatialAreaPerformanceMeasureNoTargets.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.GeospatialAreaPerformanceMeasureNoTargets.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaPerformanceMeasureNoTarget CreateNewBlank(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure)
        {
            return new GeospatialAreaPerformanceMeasureNoTarget(geospatialArea, performanceMeasure);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaPerformanceMeasureNoTarget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaPerformanceMeasureNoTargets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int GeospatialAreaPerformanceMeasureNoTargetID { get; set; }
        public int TenantID { get; set; }
        public int GeospatialAreaID { get; set; }
        public int PerformanceMeasureID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaPerformanceMeasureNoTargetID; } set { GeospatialAreaPerformanceMeasureNoTargetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialArea GeospatialArea { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}