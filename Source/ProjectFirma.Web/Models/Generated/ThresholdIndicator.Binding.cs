//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicator]
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
    [Table("[dbo].[ThresholdIndicator]")]
    public partial class ThresholdIndicator : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdIndicator()
        {
            this.IndicatorSubcategories = new HashSet<IndicatorSubcategory>();
            this.ThresholdEvaluations = new HashSet<ThresholdEvaluation>();
            this.ThresholdIndicatorImages = new HashSet<ThresholdIndicatorImage>();
            this.ThresholdIndicatorReporteds = new HashSet<ThresholdIndicatorReported>();
            this.ThresholdIndicatorReportedSubcategoryOptions = new HashSet<ThresholdIndicatorReportedSubcategoryOption>();
            this.ThresholdIndicatorReportingPeriods = new HashSet<ThresholdIndicatorReportingPeriod>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicator(int thresholdIndicatorID, int indicatorID, int thresholdReportingCategoryID, bool useCustomDateRange, int thresholdStandardTypeID, string applicableStandard, string standardNarrative, string tRPAIndicator, string relevance, string humanAndEnvironmentalDrivers, int? optionalChartImageFileResourceID) : this()
        {
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.IndicatorID = indicatorID;
            this.ThresholdReportingCategoryID = thresholdReportingCategoryID;
            this.UseCustomDateRange = useCustomDateRange;
            this.ThresholdStandardTypeID = thresholdStandardTypeID;
            this.ApplicableStandard = applicableStandard;
            this.StandardNarrative = standardNarrative;
            this.TRPAIndicator = tRPAIndicator;
            this.Relevance = relevance;
            this.HumanAndEnvironmentalDrivers = humanAndEnvironmentalDrivers;
            this.OptionalChartImageFileResourceID = optionalChartImageFileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicator(int indicatorID, int thresholdReportingCategoryID, bool useCustomDateRange, int thresholdStandardTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdIndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorID = indicatorID;
            this.ThresholdReportingCategoryID = thresholdReportingCategoryID;
            this.UseCustomDateRange = useCustomDateRange;
            this.ThresholdStandardTypeID = thresholdStandardTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdIndicator(Indicator indicator, ThresholdReportingCategory thresholdReportingCategory, bool useCustomDateRange, ThresholdStandardType thresholdStandardType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdIndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
            this.ThresholdReportingCategoryID = thresholdReportingCategory.ThresholdReportingCategoryID;
            this.ThresholdReportingCategory = thresholdReportingCategory;
            thresholdReportingCategory.ThresholdIndicators.Add(this);
            this.UseCustomDateRange = useCustomDateRange;
            this.ThresholdStandardTypeID = thresholdStandardType.ThresholdStandardTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdIndicator CreateNewBlank(Indicator indicator, ThresholdReportingCategory thresholdReportingCategory, ThresholdStandardType thresholdStandardType)
        {
            return new ThresholdIndicator(indicator, thresholdReportingCategory, default(bool), thresholdStandardType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return IndicatorSubcategories.Any() || ThresholdEvaluations.Any() || ThresholdIndicatorImages.Any() || ThresholdIndicatorReporteds.Any() || ThresholdIndicatorReportedSubcategoryOptions.Any() || ThresholdIndicatorReportingPeriods.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdIndicator).Name, typeof(IndicatorSubcategory).Name, typeof(ThresholdEvaluation).Name, typeof(ThresholdIndicatorImage).Name, typeof(ThresholdIndicatorReported).Name, typeof(ThresholdIndicatorReportedSubcategoryOption).Name, typeof(ThresholdIndicatorReportingPeriod).Name};

        [Key]
        public int ThresholdIndicatorID { get; set; }
        public int IndicatorID { get; set; }
        public int ThresholdReportingCategoryID { get; set; }
        public bool UseCustomDateRange { get; set; }
        public int ThresholdStandardTypeID { get; set; }
        public string ApplicableStandard { get; set; }
        public string StandardNarrative { get; set; }
        public string TRPAIndicator { get; set; }
        public string Relevance { get; set; }
        public string HumanAndEnvironmentalDrivers { get; set; }
        public int? OptionalChartImageFileResourceID { get; set; }
        public int PrimaryKey { get { return ThresholdIndicatorID; } set { ThresholdIndicatorID = value; } }

        public virtual ICollection<IndicatorSubcategory> IndicatorSubcategories { get; set; }
        public virtual ICollection<ThresholdEvaluation> ThresholdEvaluations { get; set; }
        public virtual ICollection<ThresholdIndicatorImage> ThresholdIndicatorImages { get; set; }
        public virtual ICollection<ThresholdIndicatorReported> ThresholdIndicatorReporteds { get; set; }
        public virtual ICollection<ThresholdIndicatorReportedSubcategoryOption> ThresholdIndicatorReportedSubcategoryOptions { get; set; }
        public virtual ICollection<ThresholdIndicatorReportingPeriod> ThresholdIndicatorReportingPeriods { get; set; }
        public virtual Indicator Indicator { get; set; }
        public virtual ThresholdReportingCategory ThresholdReportingCategory { get; set; }
        public ThresholdStandardType ThresholdStandardType { get { return ThresholdStandardType.AllLookupDictionary[ThresholdStandardTypeID]; } }
        public virtual FileResource OptionalChartImageFileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}