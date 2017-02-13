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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
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
            this.PerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<PerformanceMeasureExpectedSubcategoryOptionProposed>();
            this.PerformanceMeasureSubcategoryOptions = new HashSet<PerformanceMeasureSubcategoryOption>();
            this.SnapshotPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotPerformanceMeasureSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureSubcategory(int performanceMeasureSubcategoryID, int performanceMeasureID, string performanceMeasureSubcategoryDisplayName, string chartConfigurationJson, string chartType, bool? swapChartAxes) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryDisplayName = performanceMeasureSubcategoryDisplayName;
            this.ChartConfigurationJson = chartConfigurationJson;
            this.ChartType = chartType;
            this.SwapChartAxes = swapChartAxes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureSubcategory(int performanceMeasureID, string performanceMeasureSubcategoryDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureSubcategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
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
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
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
            return PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptionProposeds.Any() || PerformanceMeasureSubcategoryOptions.Any() || SnapshotPerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureSubcategory).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionProposed).Name, typeof(PerformanceMeasureSubcategoryOption).Name, typeof(SnapshotPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int PerformanceMeasureSubcategoryID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureSubcategoryDisplayName { get; set; }
        public string ChartConfigurationJson { get; set; }
        public string ChartType { get; set; }
        public bool? SwapChartAxes { get; set; }
        public int TenantID { get; private set; }
        public int PrimaryKey { get { return PerformanceMeasureSubcategoryID; } set { PerformanceMeasureSubcategoryID = value; } }

        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> PerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ICollection<PerformanceMeasureSubcategoryOption> PerformanceMeasureSubcategoryOptions { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasureSubcategoryOption> SnapshotPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int PerformanceMeasureSubcategoryDisplayName = 200;
            public const int ChartType = 100;
        }
    }
}