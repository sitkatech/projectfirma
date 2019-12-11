//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]
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
    // Table [dbo].[GeospatialAreaPerformanceMeasureOverallTarget] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaPerformanceMeasureOverallTarget]")]
    public partial class GeospatialAreaPerformanceMeasureOverallTarget : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaPerformanceMeasureOverallTarget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasureOverallTarget(int geospatialAreaPerformanceMeasureOverallTargetID, int geospatialAreaID, int performanceMeasureID, double geospatialAreaPerformanceMeasureTargetValue, string geospatialAreaPerformanceMeasureTargetValueLabel) : this()
        {
            this.GeospatialAreaPerformanceMeasureOverallTargetID = geospatialAreaPerformanceMeasureOverallTargetID;
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.GeospatialAreaPerformanceMeasureTargetValue = geospatialAreaPerformanceMeasureTargetValue;
            this.GeospatialAreaPerformanceMeasureTargetValueLabel = geospatialAreaPerformanceMeasureTargetValueLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasureOverallTarget(int geospatialAreaID, int performanceMeasureID, double geospatialAreaPerformanceMeasureTargetValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasureOverallTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.GeospatialAreaPerformanceMeasureTargetValue = geospatialAreaPerformanceMeasureTargetValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialAreaPerformanceMeasureOverallTarget(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure, double geospatialAreaPerformanceMeasureTargetValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasureOverallTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.GeospatialAreaPerformanceMeasureOverallTargets.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.Add(this);
            this.GeospatialAreaPerformanceMeasureTargetValue = geospatialAreaPerformanceMeasureTargetValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaPerformanceMeasureOverallTarget CreateNewBlank(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure)
        {
            return new GeospatialAreaPerformanceMeasureOverallTarget(geospatialArea, performanceMeasure, default(double));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaPerformanceMeasureOverallTarget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaPerformanceMeasureOverallTargets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int GeospatialAreaPerformanceMeasureOverallTargetID { get; set; }
        public int TenantID { get; set; }
        public int GeospatialAreaID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double GeospatialAreaPerformanceMeasureTargetValue { get; set; }
        public string GeospatialAreaPerformanceMeasureTargetValueLabel { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaPerformanceMeasureOverallTargetID; } set { GeospatialAreaPerformanceMeasureOverallTargetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialArea GeospatialArea { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {
            public const int GeospatialAreaPerformanceMeasureTargetValueLabel = 100;
        }
    }
}