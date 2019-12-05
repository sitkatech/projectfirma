//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategory]
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
    // Table [dbo].[PerformanceMeasureSubcategory] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PerformanceMeasureSubcategory]")]
    public partial class PerformanceMeasureSubcategory : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureSubcategory()
        {
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.PerformanceMeasureExpectedSubcategoryOptions = new HashSet<PerformanceMeasureExpectedSubcategoryOption>();
            this.PerformanceMeasureExpectedSubcategoryOptionUpdates = new HashSet<PerformanceMeasureExpectedSubcategoryOptionUpdate>();
            this.PerformanceMeasureSubcategoryOptions = new HashSet<PerformanceMeasureSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureSubcategory(int performanceMeasureSubcategoryID, int performanceMeasureID, string performanceMeasureSubcategoryDisplayName, string chartConfigurationJson, int? googleChartTypeID, string cumulativeChartConfigurationJson, int? cumulativeGoogleChartTypeID, string geospatialAreaTargetChartConfigurationJson, int? geospatialAreaTargetGoogleChartTypeID) : this()
        {
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryDisplayName = performanceMeasureSubcategoryDisplayName;
            this.ChartConfigurationJson = chartConfigurationJson;
            this.GoogleChartTypeID = googleChartTypeID;
            this.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
            this.CumulativeGoogleChartTypeID = cumulativeGoogleChartTypeID;
            this.GeospatialAreaTargetChartConfigurationJson = geospatialAreaTargetChartConfigurationJson;
            this.GeospatialAreaTargetGoogleChartTypeID = geospatialAreaTargetGoogleChartTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureSubcategory(int performanceMeasureID, string performanceMeasureSubcategoryDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureSubcategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryDisplayName = performanceMeasureSubcategoryDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureSubcategory(PerformanceMeasure performanceMeasure, string performanceMeasureSubcategoryDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureSubcategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureSubcategories.Add(this);
            this.PerformanceMeasureSubcategoryDisplayName = performanceMeasureSubcategoryDisplayName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureSubcategory CreateNewBlank(PerformanceMeasure performanceMeasure)
        {
            return new PerformanceMeasureSubcategory(performanceMeasure, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptionUpdates.Any() || PerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureSubcategory).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureSubcategoryOption).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPerformanceMeasureSubcategories.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in PerformanceMeasureActualSubcategoryOptions.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureActualSubcategoryOptionUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpectedSubcategoryOptions.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpectedSubcategoryOptionUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureSubcategoryOptions.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PerformanceMeasureSubcategoryID { get; set; }
        public int TenantID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureSubcategoryDisplayName { get; set; }
        public string ChartConfigurationJson { get; set; }
        public int? GoogleChartTypeID { get; set; }
        public string CumulativeChartConfigurationJson { get; set; }
        public int? CumulativeGoogleChartTypeID { get; set; }
        public string GeospatialAreaTargetChartConfigurationJson { get; set; }
        public int? GeospatialAreaTargetGoogleChartTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureSubcategoryID; } set { PerformanceMeasureSubcategoryID = value; } }

        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionUpdate> PerformanceMeasureExpectedSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureSubcategoryOption> PerformanceMeasureSubcategoryOptions { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public GoogleChartType CumulativeGoogleChartType { get { return CumulativeGoogleChartTypeID.HasValue ? GoogleChartType.AllLookupDictionary[CumulativeGoogleChartTypeID.Value] : null; } }
        public GoogleChartType GeospatialAreaTargetGoogleChartType { get { return GeospatialAreaTargetGoogleChartTypeID.HasValue ? GoogleChartType.AllLookupDictionary[GeospatialAreaTargetGoogleChartTypeID.Value] : null; } }
        public GoogleChartType GoogleChartType { get { return GoogleChartTypeID.HasValue ? GoogleChartType.AllLookupDictionary[GoogleChartTypeID.Value] : null; } }

        public static class FieldLengths
        {
            public const int PerformanceMeasureSubcategoryDisplayName = 200;
        }
    }
}