//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategoryIndicator]
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
    [Table("[dbo].[ThresholdCategoryIndicator]")]
    public partial class ThresholdCategoryIndicator : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdCategoryIndicator()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategoryIndicator(int thresholdCategoryIndicatorID, int thresholdCategoryID, int indicatorID, bool isPrimaryChart) : this()
        {
            this.ThresholdCategoryIndicatorID = thresholdCategoryIndicatorID;
            this.ThresholdCategoryID = thresholdCategoryID;
            this.IndicatorID = indicatorID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategoryIndicator(int thresholdCategoryID, int indicatorID, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdCategoryIndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdCategoryID = thresholdCategoryID;
            this.IndicatorID = indicatorID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdCategoryIndicator(ThresholdCategory thresholdCategory, Indicator indicator, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdCategoryIndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdCategoryID = thresholdCategory.ThresholdCategoryID;
            this.ThresholdCategory = thresholdCategory;
            thresholdCategory.ThresholdCategoryIndicators.Add(this);
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
            indicator.ThresholdCategoryIndicators.Add(this);
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdCategoryIndicator CreateNewBlank(ThresholdCategory thresholdCategory, Indicator indicator)
        {
            return new ThresholdCategoryIndicator(thresholdCategory, indicator, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdCategoryIndicator).Name};

        [Key]
        public int ThresholdCategoryIndicatorID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public int IndicatorID { get; set; }
        public bool IsPrimaryChart { get; set; }
        public int PrimaryKey { get { return ThresholdCategoryIndicatorID; } set { ThresholdCategoryIndicatorID = value; } }

        public virtual ThresholdCategory ThresholdCategory { get; set; }
        public virtual Indicator Indicator { get; set; }

        public static class FieldLengths
        {

        }
    }
}