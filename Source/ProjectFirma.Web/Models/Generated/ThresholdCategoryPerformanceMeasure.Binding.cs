//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategoryPerformanceMeasure]
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
    [Table("[dbo].[ThresholdCategoryPerformanceMeasure]")]
    public partial class ThresholdCategoryPerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdCategoryPerformanceMeasure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategoryPerformanceMeasure(int thresholdCategoryPerformanceMeasureID, int thresholdCategoryID, int performanceMeasureID, bool isPrimaryChart) : this()
        {
            this.ThresholdCategoryPerformanceMeasureID = thresholdCategoryPerformanceMeasureID;
            this.ThresholdCategoryID = thresholdCategoryID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategoryPerformanceMeasure(int thresholdCategoryID, int performanceMeasureID, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdCategoryPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdCategoryID = thresholdCategoryID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdCategoryPerformanceMeasure(ThresholdCategory thresholdCategory, PerformanceMeasure performanceMeasure, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdCategoryPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdCategoryID = thresholdCategory.ThresholdCategoryID;
            this.ThresholdCategory = thresholdCategory;
            thresholdCategory.ThresholdCategoryPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.ThresholdCategoryPerformanceMeasures.Add(this);
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdCategoryPerformanceMeasure CreateNewBlank(ThresholdCategory thresholdCategory, PerformanceMeasure performanceMeasure)
        {
            return new ThresholdCategoryPerformanceMeasure(thresholdCategory, performanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdCategoryPerformanceMeasure).Name};

        [Key]
        public int ThresholdCategoryPerformanceMeasureID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryChart { get; set; }
        public int PrimaryKey { get { return ThresholdCategoryPerformanceMeasureID; } set { ThresholdCategoryPerformanceMeasureID = value; } }

        public virtual ThresholdCategory ThresholdCategory { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}