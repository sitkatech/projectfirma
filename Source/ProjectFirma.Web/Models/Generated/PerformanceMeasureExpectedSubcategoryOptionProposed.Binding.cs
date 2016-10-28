//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]
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
    [Table("[dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]")]
    public partial class PerformanceMeasureExpectedSubcategoryOptionProposed : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureExpectedSubcategoryOptionProposed()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionProposed(int performanceMeasureExpectedSubcategoryOptionProposedID, int performanceMeasureExpectedProposedID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.PerformanceMeasureExpectedSubcategoryOptionProposedID = performanceMeasureExpectedSubcategoryOptionProposedID;
            this.PerformanceMeasureExpectedProposedID = performanceMeasureExpectedProposedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionProposed(int performanceMeasureExpectedProposedID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PerformanceMeasureExpectedSubcategoryOptionProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureExpectedProposedID = performanceMeasureExpectedProposedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionProposed(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureExpectedSubcategoryOptionProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureExpectedProposedID = performanceMeasureExpectedProposed.PerformanceMeasureExpectedProposedID;
            this.PerformanceMeasureExpectedProposed = performanceMeasureExpectedProposed;
            performanceMeasureExpectedProposed.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureExpectedSubcategoryOptionProposed CreateNewBlank(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionProposed(performanceMeasureExpectedProposed, indicatorSubcategoryOption, performanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureExpectedSubcategoryOptionProposed).Name};

        [Key]
        public int PerformanceMeasureExpectedSubcategoryOptionProposedID { get; set; }
        public int PerformanceMeasureExpectedProposedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureExpectedSubcategoryOptionProposedID; } set { PerformanceMeasureExpectedSubcategoryOptionProposedID = value; } }

        public virtual PerformanceMeasureExpectedProposed PerformanceMeasureExpectedProposed { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}