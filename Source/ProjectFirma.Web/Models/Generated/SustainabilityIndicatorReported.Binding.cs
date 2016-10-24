//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicatorReported]
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
    [Table("[dbo].[SustainabilityIndicatorReported]")]
    public partial class SustainabilityIndicatorReported : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SustainabilityIndicatorReported()
        {
            this.SustainabilityIndicatorReportedSubcategoryOptions = new HashSet<SustainabilityIndicatorReportedSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicatorReported(int sustainabilityIndicatorReportedID, int sustainabilityIndicatorID, int sustainabilityIndicatorReportingPeriodID, double reportedValue) : this()
        {
            this.SustainabilityIndicatorReportedID = sustainabilityIndicatorReportedID;
            this.SustainabilityIndicatorID = sustainabilityIndicatorID;
            this.SustainabilityIndicatorReportingPeriodID = sustainabilityIndicatorReportingPeriodID;
            this.ReportedValue = reportedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityIndicatorReported(int sustainabilityIndicatorID, int sustainabilityIndicatorReportingPeriodID, double reportedValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SustainabilityIndicatorReportedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SustainabilityIndicatorID = sustainabilityIndicatorID;
            this.SustainabilityIndicatorReportingPeriodID = sustainabilityIndicatorReportingPeriodID;
            this.ReportedValue = reportedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SustainabilityIndicatorReported(SustainabilityIndicator sustainabilityIndicator, SustainabilityIndicatorReportingPeriod sustainabilityIndicatorReportingPeriod, double reportedValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SustainabilityIndicatorReportedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SustainabilityIndicatorID = sustainabilityIndicator.SustainabilityIndicatorID;
            this.SustainabilityIndicator = sustainabilityIndicator;
            sustainabilityIndicator.SustainabilityIndicatorReporteds.Add(this);
            this.SustainabilityIndicatorReportingPeriodID = sustainabilityIndicatorReportingPeriod.SustainabilityIndicatorReportingPeriodID;
            this.SustainabilityIndicatorReportingPeriod = sustainabilityIndicatorReportingPeriod;
            sustainabilityIndicatorReportingPeriod.SustainabilityIndicatorReporteds.Add(this);
            this.ReportedValue = reportedValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SustainabilityIndicatorReported CreateNewBlank(SustainabilityIndicator sustainabilityIndicator, SustainabilityIndicatorReportingPeriod sustainabilityIndicatorReportingPeriod)
        {
            return new SustainabilityIndicatorReported(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod, default(double));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SustainabilityIndicatorReportedSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SustainabilityIndicatorReported).Name, typeof(SustainabilityIndicatorReportedSubcategoryOption).Name};

        [Key]
        public int SustainabilityIndicatorReportedID { get; set; }
        public int SustainabilityIndicatorID { get; set; }
        public int SustainabilityIndicatorReportingPeriodID { get; set; }
        public double ReportedValue { get; set; }
        public int PrimaryKey { get { return SustainabilityIndicatorReportedID; } set { SustainabilityIndicatorReportedID = value; } }

        public virtual ICollection<SustainabilityIndicatorReportedSubcategoryOption> SustainabilityIndicatorReportedSubcategoryOptions { get; set; }
        public virtual SustainabilityIndicator SustainabilityIndicator { get; set; }
        public virtual SustainabilityIndicatorReportingPeriod SustainabilityIndicatorReportingPeriod { get; set; }

        public static class FieldLengths
        {

        }
    }
}