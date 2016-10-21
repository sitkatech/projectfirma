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
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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
            this.EIPPerformanceMeasureActualSubcategoryOptions = new HashSet<EIPPerformanceMeasureActualSubcategoryOption>();
            this.EIPPerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<EIPPerformanceMeasureActualSubcategoryOptionUpdate>();
            this.EIPPerformanceMeasureExpectedSubcategoryOptions = new HashSet<EIPPerformanceMeasureExpectedSubcategoryOption>();
            this.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<EIPPerformanceMeasureExpectedSubcategoryOptionProposed>();
            this.SnapshotEIPPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotEIPPerformanceMeasureSubcategoryOption>();
            this.SustainabilityIndicatorReportedSubcategoryOptions = new HashSet<SustainabilityIndicatorReportedSubcategoryOption>();
            this.ThresholdIndicatorReportedSubcategoryOptions = new HashSet<ThresholdIndicatorReportedSubcategoryOption>();
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
            return EIPPerformanceMeasureActualSubcategoryOptions.Any() || EIPPerformanceMeasureActualSubcategoryOptionUpdates.Any() || EIPPerformanceMeasureExpectedSubcategoryOptions.Any() || EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Any() || SnapshotEIPPerformanceMeasureSubcategoryOptions.Any() || SustainabilityIndicatorReportedSubcategoryOptions.Any() || ThresholdIndicatorReportedSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(IndicatorSubcategoryOption).Name, typeof(EIPPerformanceMeasureActualSubcategoryOption).Name, typeof(EIPPerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(EIPPerformanceMeasureExpectedSubcategoryOption).Name, typeof(EIPPerformanceMeasureExpectedSubcategoryOptionProposed).Name, typeof(SnapshotEIPPerformanceMeasureSubcategoryOption).Name, typeof(SustainabilityIndicatorReportedSubcategoryOption).Name, typeof(ThresholdIndicatorReportedSubcategoryOption).Name};

        [Key]
        public int IndicatorSubcategoryOptionID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public string IndicatorSubcategoryOptionName { get; set; }
        public int? SortOrder { get; set; }
        public string ShortName { get; set; }
        public int PrimaryKey { get { return IndicatorSubcategoryOptionID; } set { IndicatorSubcategoryOptionID = value; } }

        public virtual ICollection<EIPPerformanceMeasureActualSubcategoryOption> EIPPerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<EIPPerformanceMeasureActualSubcategoryOptionUpdate> EIPPerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<EIPPerformanceMeasureExpectedSubcategoryOption> EIPPerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> EIPPerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ICollection<SnapshotEIPPerformanceMeasureSubcategoryOption> SnapshotEIPPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual ICollection<SustainabilityIndicatorReportedSubcategoryOption> SustainabilityIndicatorReportedSubcategoryOptions { get; set; }
        public virtual ICollection<ThresholdIndicatorReportedSubcategoryOption> ThresholdIndicatorReportedSubcategoryOptions { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {
            public const int IndicatorSubcategoryOptionName = 100;
            public const int ShortName = 50;
        }
    }
}