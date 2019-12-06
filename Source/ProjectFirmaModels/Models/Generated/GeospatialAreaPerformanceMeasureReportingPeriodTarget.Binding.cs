//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureReportingPeriodTarget]
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
    // Table [dbo].[GeospatialAreaPerformanceMeasureReportingPeriodTarget] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaPerformanceMeasureReportingPeriodTarget]")]
    public partial class GeospatialAreaPerformanceMeasureReportingPeriodTarget : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaPerformanceMeasureReportingPeriodTarget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasureReportingPeriodTarget(int geospatialAreaPerformanceMeasureReportingPeriodTargetID, int geospatialAreaID, int performanceMeasureID, int performanceMeasureReportingPeriodID, double? geospatialAreaPerformanceMeasureTargetValue, string geospatialAreaPerformanceMeasureTargetValueLabel) : this()
        {
            this.GeospatialAreaPerformanceMeasureReportingPeriodTargetID = geospatialAreaPerformanceMeasureReportingPeriodTargetID;
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
            this.GeospatialAreaPerformanceMeasureTargetValue = geospatialAreaPerformanceMeasureTargetValue;
            this.GeospatialAreaPerformanceMeasureTargetValueLabel = geospatialAreaPerformanceMeasureTargetValueLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaPerformanceMeasureReportingPeriodTarget(int geospatialAreaID, int performanceMeasureID, int performanceMeasureReportingPeriodID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasureReportingPeriodTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaID = geospatialAreaID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialAreaPerformanceMeasureReportingPeriodTarget(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaPerformanceMeasureReportingPeriodTargetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Add(this);
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID;
            this.PerformanceMeasureReportingPeriod = performanceMeasureReportingPeriod;
            performanceMeasureReportingPeriod.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaPerformanceMeasureReportingPeriodTarget CreateNewBlank(GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod)
        {
            return new GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, performanceMeasureReportingPeriod);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaPerformanceMeasureReportingPeriodTarget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaPerformanceMeasureReportingPeriodTargets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int GeospatialAreaPerformanceMeasureReportingPeriodTargetID { get; set; }
        public int TenantID { get; set; }
        public int GeospatialAreaID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureReportingPeriodID { get; set; }
        public double? GeospatialAreaPerformanceMeasureTargetValue { get; set; }
        public string GeospatialAreaPerformanceMeasureTargetValueLabel { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaPerformanceMeasureReportingPeriodTargetID; } set { GeospatialAreaPerformanceMeasureReportingPeriodTargetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialArea GeospatialArea { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod { get; set; }

        public static class FieldLengths
        {
            public const int GeospatialAreaPerformanceMeasureTargetValueLabel = 100;
        }
    }
}