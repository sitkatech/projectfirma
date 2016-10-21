//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]
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
    [Table("[dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]")]
    public partial class EIPPerformanceMeasureExpectedSubcategoryOptionProposed : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureExpectedSubcategoryOptionProposed()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOptionProposed(int eIPPerformanceMeasureExpectedSubcategoryOptionProposedID, int eIPPerformanceMeasureExpectedProposedID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.EIPPerformanceMeasureExpectedSubcategoryOptionProposedID = eIPPerformanceMeasureExpectedSubcategoryOptionProposedID;
            this.EIPPerformanceMeasureExpectedProposedID = eIPPerformanceMeasureExpectedProposedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOptionProposed(int eIPPerformanceMeasureExpectedProposedID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureExpectedSubcategoryOptionProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EIPPerformanceMeasureExpectedProposedID = eIPPerformanceMeasureExpectedProposedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOptionProposed(EIPPerformanceMeasureExpectedProposed eIPPerformanceMeasureExpectedProposed, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureExpectedSubcategoryOptionProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EIPPerformanceMeasureExpectedProposedID = eIPPerformanceMeasureExpectedProposed.EIPPerformanceMeasureExpectedProposedID;
            this.EIPPerformanceMeasureExpectedProposed = eIPPerformanceMeasureExpectedProposed;
            eIPPerformanceMeasureExpectedProposed.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureExpectedSubcategoryOptionProposed CreateNewBlank(EIPPerformanceMeasureExpectedProposed eIPPerformanceMeasureExpectedProposed, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new EIPPerformanceMeasureExpectedSubcategoryOptionProposed(eIPPerformanceMeasureExpectedProposed, indicatorSubcategoryOption, eIPPerformanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureExpectedSubcategoryOptionProposed).Name};

        [Key]
        public int EIPPerformanceMeasureExpectedSubcategoryOptionProposedID { get; set; }
        public int EIPPerformanceMeasureExpectedProposedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureExpectedSubcategoryOptionProposedID; } set { EIPPerformanceMeasureExpectedSubcategoryOptionProposedID = value; } }

        public virtual EIPPerformanceMeasureExpectedProposed EIPPerformanceMeasureExpectedProposed { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}