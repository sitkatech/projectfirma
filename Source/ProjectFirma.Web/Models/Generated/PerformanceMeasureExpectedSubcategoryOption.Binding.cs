//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOption]
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
    [Table("[dbo].[PerformanceMeasureExpectedSubcategoryOption]")]
    public partial class PerformanceMeasureExpectedSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureExpectedSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOption(int performanceMeasureExpectedSubcategoryOptionID, int performanceMeasureExpectedID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.PerformanceMeasureExpectedSubcategoryOptionID = performanceMeasureExpectedSubcategoryOptionID;
            this.PerformanceMeasureExpectedID = performanceMeasureExpectedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOption(int performanceMeasureExpectedID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PerformanceMeasureExpectedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureExpectedID = performanceMeasureExpectedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOption(PerformanceMeasureExpected performanceMeasureExpected, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureExpectedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureExpectedID = performanceMeasureExpected.PerformanceMeasureExpectedID;
            this.PerformanceMeasureExpected = performanceMeasureExpected;
            performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.PerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.PerformanceMeasureExpectedSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureExpectedSubcategoryOption CreateNewBlank(PerformanceMeasureExpected performanceMeasureExpected, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new PerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpected, indicatorSubcategoryOption, performanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureExpectedSubcategoryOption).Name};

        [Key]
        public int PerformanceMeasureExpectedSubcategoryOptionID { get; set; }
        public int PerformanceMeasureExpectedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureExpectedSubcategoryOptionID; } set { PerformanceMeasureExpectedSubcategoryOptionID = value; } }

        public virtual PerformanceMeasureExpected PerformanceMeasureExpected { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}