//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategoryOption]
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
    [Table("[dbo].[PerformanceMeasureSubcategoryOption]")]
    public partial class PerformanceMeasureSubcategoryOption : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureSubcategoryOption()
        {
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.PerformanceMeasureExpectedSubcategoryOptions = new HashSet<PerformanceMeasureExpectedSubcategoryOption>();
            this.SnapshotPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotPerformanceMeasureSubcategoryOption>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureSubcategoryOption(int performanceMeasureSubcategoryOptionID, int performanceMeasureSubcategoryID, string performanceMeasureSubcategoryOptionName, int? sortOrder, string shortName) : this()
        {
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
            this.PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOptionName;
            this.SortOrder = sortOrder;
            this.ShortName = shortName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureSubcategoryOption(int performanceMeasureSubcategoryID, string performanceMeasureSubcategoryOptionName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
            this.PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOptionName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureSubcategoryOption(PerformanceMeasureSubcategory performanceMeasureSubcategory, string performanceMeasureSubcategoryOptionName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            this.PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Add(this);
            this.PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOptionName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureSubcategoryOption CreateNewBlank(PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            return new PerformanceMeasureSubcategoryOption(performanceMeasureSubcategory, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || SnapshotPerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(SnapshotPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int TenantID { get; private set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        public string PerformanceMeasureSubcategoryOptionName { get; set; }
        public int? SortOrder { get; set; }
        public string ShortName { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureSubcategoryOptionID; } set { PerformanceMeasureSubcategoryOptionID = value; } }

        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasureSubcategoryOption> SnapshotPerformanceMeasureSubcategoryOptions { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureSubcategoryOptionName = 100;
            public const int ShortName = 50;
        }
    }
}