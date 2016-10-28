//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorSubcategoryOption]
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
    [Table("[dbo].[IndicatorSubcategoryOption]")]
    public partial class IndicatorSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected IndicatorSubcategoryOption()
        {
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.PerformanceMeasureExpectedSubcategoryOptions = new HashSet<PerformanceMeasureExpectedSubcategoryOption>();
            this.PerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<PerformanceMeasureExpectedSubcategoryOptionProposed>();
            this.SnapshotPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotPerformanceMeasureSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorSubcategoryOption(int indicatorSubcategoryOptionID, int indicatorSubcategoryID, string indicatorSubcategoryOptionName, int? sortOrder, string shortName) : this()
        {
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
            this.IndicatorSubcategoryOptionName = indicatorSubcategoryOptionName;
            this.SortOrder = sortOrder;
            this.ShortName = shortName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorSubcategoryOption(int indicatorSubcategoryID, string indicatorSubcategoryOptionName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            IndicatorSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
            this.IndicatorSubcategoryOptionName = indicatorSubcategoryOptionName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public IndicatorSubcategoryOption(IndicatorSubcategory indicatorSubcategory, string indicatorSubcategoryOptionName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.IndicatorSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.IndicatorSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionName = indicatorSubcategoryOptionName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static IndicatorSubcategoryOption CreateNewBlank(IndicatorSubcategory indicatorSubcategory)
        {
            return new IndicatorSubcategoryOption(indicatorSubcategory, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptionProposeds.Any() || SnapshotPerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(IndicatorSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionProposed).Name, typeof(SnapshotPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int IndicatorSubcategoryOptionID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public string IndicatorSubcategoryOptionName { get; set; }
        public int? SortOrder { get; set; }
        public string ShortName { get; set; }
        public int PrimaryKey { get { return IndicatorSubcategoryOptionID; } set { IndicatorSubcategoryOptionID = value; } }

        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> PerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasureSubcategoryOption> SnapshotPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {
            public const int IndicatorSubcategoryOptionName = 100;
            public const int ShortName = 50;
        }
    }
}