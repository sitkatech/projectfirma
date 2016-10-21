//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicatorReportedSubcategoryOption]
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
    [Table("[dbo].[SustainabilityIndicatorReportedSubcategoryOption]")]
    public partial class SustainabilityIndicatorReportedSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SustainabilityIndicatorReportedSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicatorReportedSubcategoryOption(int sustainabilityIndicatorReportedSubcategoryOptionID, int sustainabilityIndicatorReportedID, int indicatorSubcategoryOptionID, int sustainabilityIndicatorID, int indicatorSubcategoryID) : this()
        {
            this.SustainabilityIndicatorReportedSubcategoryOptionID = sustainabilityIndicatorReportedSubcategoryOptionID;
            this.SustainabilityIndicatorReportedID = sustainabilityIndicatorReportedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.SustainabilityIndicatorID = sustainabilityIndicatorID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicatorReportedSubcategoryOption(int sustainabilityIndicatorReportedID, int indicatorSubcategoryOptionID, int sustainabilityIndicatorID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SustainabilityIndicatorReportedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SustainabilityIndicatorReportedID = sustainabilityIndicatorReportedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.SustainabilityIndicatorID = sustainabilityIndicatorID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SustainabilityIndicatorReportedSubcategoryOption(SustainabilityIndicatorReported sustainabilityIndicatorReported, IndicatorSubcategoryOption indicatorSubcategoryOption, SustainabilityIndicator sustainabilityIndicator, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SustainabilityIndicatorReportedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SustainabilityIndicatorReportedID = sustainabilityIndicatorReported.SustainabilityIndicatorReportedID;
            this.SustainabilityIndicatorReported = sustainabilityIndicatorReported;
            sustainabilityIndicatorReported.SustainabilityIndicatorReportedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.SustainabilityIndicatorReportedSubcategoryOptions.Add(this);
            this.SustainabilityIndicatorID = sustainabilityIndicator.SustainabilityIndicatorID;
            this.SustainabilityIndicator = sustainabilityIndicator;
            sustainabilityIndicator.SustainabilityIndicatorReportedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.SustainabilityIndicatorReportedSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SustainabilityIndicatorReportedSubcategoryOption CreateNewBlank(SustainabilityIndicatorReported sustainabilityIndicatorReported, IndicatorSubcategoryOption indicatorSubcategoryOption, SustainabilityIndicator sustainabilityIndicator, IndicatorSubcategory indicatorSubcategory)
        {
            return new SustainabilityIndicatorReportedSubcategoryOption(sustainabilityIndicatorReported, indicatorSubcategoryOption, sustainabilityIndicator, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SustainabilityIndicatorReportedSubcategoryOption).Name};

        [Key]
        public int SustainabilityIndicatorReportedSubcategoryOptionID { get; set; }
        public int SustainabilityIndicatorReportedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int SustainabilityIndicatorID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return SustainabilityIndicatorReportedSubcategoryOptionID; } set { SustainabilityIndicatorReportedSubcategoryOptionID = value; } }

        public virtual SustainabilityIndicatorReported SustainabilityIndicatorReported { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual SustainabilityIndicator SustainabilityIndicator { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}