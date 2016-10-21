//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorReportedSubcategoryOption]
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
    [Table("[dbo].[ThresholdIndicatorReportedSubcategoryOption]")]
    public partial class ThresholdIndicatorReportedSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdIndicatorReportedSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorReportedSubcategoryOption(int thresholdIndicatorReportedSubcategoryOptionID, int thresholdIndicatorReportedID, int indicatorSubcategoryOptionID, int thresholdIndicatorID, int indicatorSubcategoryID) : this()
        {
            this.ThresholdIndicatorReportedSubcategoryOptionID = thresholdIndicatorReportedSubcategoryOptionID;
            this.ThresholdIndicatorReportedID = thresholdIndicatorReportedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorReportedSubcategoryOption(int thresholdIndicatorReportedID, int indicatorSubcategoryOptionID, int thresholdIndicatorID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdIndicatorReportedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdIndicatorReportedID = thresholdIndicatorReportedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdIndicatorReportedSubcategoryOption(ThresholdIndicatorReported thresholdIndicatorReported, IndicatorSubcategoryOption indicatorSubcategoryOption, ThresholdIndicator thresholdIndicator, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdIndicatorReportedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdIndicatorReportedID = thresholdIndicatorReported.ThresholdIndicatorReportedID;
            this.ThresholdIndicatorReported = thresholdIndicatorReported;
            thresholdIndicatorReported.ThresholdIndicatorReportedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.ThresholdIndicatorReportedSubcategoryOptions.Add(this);
            this.ThresholdIndicatorID = thresholdIndicator.ThresholdIndicatorID;
            this.ThresholdIndicator = thresholdIndicator;
            thresholdIndicator.ThresholdIndicatorReportedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.ThresholdIndicatorReportedSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdIndicatorReportedSubcategoryOption CreateNewBlank(ThresholdIndicatorReported thresholdIndicatorReported, IndicatorSubcategoryOption indicatorSubcategoryOption, ThresholdIndicator thresholdIndicator, IndicatorSubcategory indicatorSubcategory)
        {
            return new ThresholdIndicatorReportedSubcategoryOption(thresholdIndicatorReported, indicatorSubcategoryOption, thresholdIndicator, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdIndicatorReportedSubcategoryOption).Name};

        [Key]
        public int ThresholdIndicatorReportedSubcategoryOptionID { get; set; }
        public int ThresholdIndicatorReportedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int ThresholdIndicatorID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return ThresholdIndicatorReportedSubcategoryOptionID; } set { ThresholdIndicatorReportedSubcategoryOptionID = value; } }

        public virtual ThresholdIndicatorReported ThresholdIndicatorReported { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual ThresholdIndicator ThresholdIndicator { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}