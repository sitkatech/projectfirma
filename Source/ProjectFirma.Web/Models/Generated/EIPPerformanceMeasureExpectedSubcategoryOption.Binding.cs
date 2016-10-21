//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]
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
    [Table("[dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]")]
    public partial class EIPPerformanceMeasureExpectedSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureExpectedSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOption(int eIPPerformanceMeasureExpectedSubcategoryOptionID, int eIPPerformanceMeasureExpectedID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.EIPPerformanceMeasureExpectedSubcategoryOptionID = eIPPerformanceMeasureExpectedSubcategoryOptionID;
            this.EIPPerformanceMeasureExpectedID = eIPPerformanceMeasureExpectedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOption(int eIPPerformanceMeasureExpectedID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureExpectedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EIPPerformanceMeasureExpectedID = eIPPerformanceMeasureExpectedID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOption(EIPPerformanceMeasureExpected eIPPerformanceMeasureExpected, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureExpectedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EIPPerformanceMeasureExpectedID = eIPPerformanceMeasureExpected.EIPPerformanceMeasureExpectedID;
            this.EIPPerformanceMeasureExpected = eIPPerformanceMeasureExpected;
            eIPPerformanceMeasureExpected.EIPPerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.EIPPerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.EIPPerformanceMeasureExpectedSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureExpectedSubcategoryOption CreateNewBlank(EIPPerformanceMeasureExpected eIPPerformanceMeasureExpected, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new EIPPerformanceMeasureExpectedSubcategoryOption(eIPPerformanceMeasureExpected, indicatorSubcategoryOption, eIPPerformanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureExpectedSubcategoryOption).Name};

        [Key]
        public int EIPPerformanceMeasureExpectedSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureExpectedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureExpectedSubcategoryOptionID; } set { EIPPerformanceMeasureExpectedSubcategoryOptionID = value; } }

        public virtual EIPPerformanceMeasureExpected EIPPerformanceMeasureExpected { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}