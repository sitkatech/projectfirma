//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotPerformanceMeasureSubcategoryOption]
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
    [Table("[dbo].[SnapshotPerformanceMeasureSubcategoryOption]")]
    public partial class SnapshotPerformanceMeasureSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotPerformanceMeasureSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotPerformanceMeasureSubcategoryOption(int snapshotPerformanceMeasureSubcategoryOptionID, int snapshotPerformanceMeasureID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.SnapshotPerformanceMeasureSubcategoryOptionID = snapshotPerformanceMeasureSubcategoryOptionID;
            this.SnapshotPerformanceMeasureID = snapshotPerformanceMeasureID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotPerformanceMeasureSubcategoryOption(int snapshotPerformanceMeasureID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SnapshotPerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SnapshotPerformanceMeasureID = snapshotPerformanceMeasureID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotPerformanceMeasureSubcategoryOption(SnapshotPerformanceMeasure snapshotPerformanceMeasure, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotPerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SnapshotPerformanceMeasureID = snapshotPerformanceMeasure.SnapshotPerformanceMeasureID;
            this.SnapshotPerformanceMeasure = snapshotPerformanceMeasure;
            snapshotPerformanceMeasure.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotPerformanceMeasureSubcategoryOption CreateNewBlank(SnapshotPerformanceMeasure snapshotPerformanceMeasure, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new SnapshotPerformanceMeasureSubcategoryOption(snapshotPerformanceMeasure, indicatorSubcategoryOption, performanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int SnapshotPerformanceMeasureSubcategoryOptionID { get; set; }
        public int SnapshotPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return SnapshotPerformanceMeasureSubcategoryOptionID; } set { SnapshotPerformanceMeasureSubcategoryOptionID = value; } }

        public virtual SnapshotPerformanceMeasure SnapshotPerformanceMeasure { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}