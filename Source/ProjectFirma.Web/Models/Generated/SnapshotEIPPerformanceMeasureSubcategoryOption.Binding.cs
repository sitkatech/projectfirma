//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]
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
    [Table("[dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]")]
    public partial class SnapshotEIPPerformanceMeasureSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotEIPPerformanceMeasureSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotEIPPerformanceMeasureSubcategoryOption(int snapshotEIPPerformanceMeasureSubcategoryOptionID, int snapshotEIPPerformanceMeasureID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.SnapshotEIPPerformanceMeasureSubcategoryOptionID = snapshotEIPPerformanceMeasureSubcategoryOptionID;
            this.SnapshotEIPPerformanceMeasureID = snapshotEIPPerformanceMeasureID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotEIPPerformanceMeasureSubcategoryOption(int snapshotEIPPerformanceMeasureID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SnapshotEIPPerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SnapshotEIPPerformanceMeasureID = snapshotEIPPerformanceMeasureID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotEIPPerformanceMeasureSubcategoryOption(SnapshotEIPPerformanceMeasure snapshotEIPPerformanceMeasure, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotEIPPerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SnapshotEIPPerformanceMeasureID = snapshotEIPPerformanceMeasure.SnapshotEIPPerformanceMeasureID;
            this.SnapshotEIPPerformanceMeasure = snapshotEIPPerformanceMeasure;
            snapshotEIPPerformanceMeasure.SnapshotEIPPerformanceMeasureSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.SnapshotEIPPerformanceMeasureSubcategoryOptions.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.SnapshotEIPPerformanceMeasureSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.SnapshotEIPPerformanceMeasureSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotEIPPerformanceMeasureSubcategoryOption CreateNewBlank(SnapshotEIPPerformanceMeasure snapshotEIPPerformanceMeasure, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new SnapshotEIPPerformanceMeasureSubcategoryOption(snapshotEIPPerformanceMeasure, indicatorSubcategoryOption, eIPPerformanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotEIPPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int SnapshotEIPPerformanceMeasureSubcategoryOptionID { get; set; }
        public int SnapshotEIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return SnapshotEIPPerformanceMeasureSubcategoryOptionID; } set { SnapshotEIPPerformanceMeasureSubcategoryOptionID = value; } }

        public virtual SnapshotEIPPerformanceMeasure SnapshotEIPPerformanceMeasure { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}