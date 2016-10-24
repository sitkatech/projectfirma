//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicator]
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
    [Table("[dbo].[SustainabilityIndicator]")]
    public partial class SustainabilityIndicator : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SustainabilityIndicator()
        {
            this.IndicatorSubcategories = new HashSet<IndicatorSubcategory>();
            this.SustainabilityIndicatorReporteds = new HashSet<SustainabilityIndicatorReported>();
            this.SustainabilityIndicatorReportedSubcategoryOptions = new HashSet<SustainabilityIndicatorReportedSubcategoryOption>();
            this.SustainabilityIndicatorReportingPeriods = new HashSet<SustainabilityIndicatorReportingPeriod>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicator(int sustainabilityIndicatorID, int indicatorID, int sustainabilityAspectID, bool useCustomDateRange) : this()
        {
            this.SustainabilityIndicatorID = sustainabilityIndicatorID;
            this.IndicatorID = indicatorID;
            this.SustainabilityAspectID = sustainabilityAspectID;
            this.UseCustomDateRange = useCustomDateRange;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicator(int indicatorID, int sustainabilityAspectID, bool useCustomDateRange) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SustainabilityIndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorID = indicatorID;
            this.SustainabilityAspectID = sustainabilityAspectID;
            this.UseCustomDateRange = useCustomDateRange;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SustainabilityIndicator(Indicator indicator, SustainabilityAspect sustainabilityAspect, bool useCustomDateRange) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SustainabilityIndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
            this.SustainabilityAspectID = sustainabilityAspect.SustainabilityAspectID;
            this.SustainabilityAspect = sustainabilityAspect;
            sustainabilityAspect.SustainabilityIndicators.Add(this);
            this.UseCustomDateRange = useCustomDateRange;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SustainabilityIndicator CreateNewBlank(Indicator indicator, SustainabilityAspect sustainabilityAspect)
        {
            return new SustainabilityIndicator(indicator, sustainabilityAspect, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return IndicatorSubcategories.Any() || SustainabilityIndicatorReporteds.Any() || SustainabilityIndicatorReportedSubcategoryOptions.Any() || SustainabilityIndicatorReportingPeriods.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SustainabilityIndicator).Name, typeof(IndicatorSubcategory).Name, typeof(SustainabilityIndicatorReported).Name, typeof(SustainabilityIndicatorReportedSubcategoryOption).Name, typeof(SustainabilityIndicatorReportingPeriod).Name};

        [Key]
        public int SustainabilityIndicatorID { get; set; }
        public int IndicatorID { get; set; }
        public int SustainabilityAspectID { get; set; }
        public bool UseCustomDateRange { get; set; }
        public int PrimaryKey { get { return SustainabilityIndicatorID; } set { SustainabilityIndicatorID = value; } }

        public virtual ICollection<IndicatorSubcategory> IndicatorSubcategories { get; set; }
        public virtual ICollection<SustainabilityIndicatorReported> SustainabilityIndicatorReporteds { get; set; }
        public virtual ICollection<SustainabilityIndicatorReportedSubcategoryOption> SustainabilityIndicatorReportedSubcategoryOptions { get; set; }
        public virtual ICollection<SustainabilityIndicatorReportingPeriod> SustainabilityIndicatorReportingPeriods { get; set; }
        public virtual Indicator Indicator { get; set; }
        public virtual SustainabilityAspect SustainabilityAspect { get; set; }

        public static class FieldLengths
        {

        }
    }
}