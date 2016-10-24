//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActualSubcategoryOption]
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
    [Table("[dbo].[EIPPerformanceMeasureActualSubcategoryOption]")]
    public partial class EIPPerformanceMeasureActualSubcategoryOption : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureActualSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOption(int eIPPerformanceMeasureActualSubcategoryOptionID, int eIPPerformanceMeasureActualID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.EIPPerformanceMeasureActualSubcategoryOptionID = eIPPerformanceMeasureActualSubcategoryOptionID;
            this.EIPPerformanceMeasureActualID = eIPPerformanceMeasureActualID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOption(int eIPPerformanceMeasureActualID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureActualSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EIPPerformanceMeasureActualID = eIPPerformanceMeasureActualID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOption(EIPPerformanceMeasureActual eIPPerformanceMeasureActual, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureActualSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EIPPerformanceMeasureActualID = eIPPerformanceMeasureActual.EIPPerformanceMeasureActualID;
            this.EIPPerformanceMeasureActual = eIPPerformanceMeasureActual;
            eIPPerformanceMeasureActual.EIPPerformanceMeasureActualSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.EIPPerformanceMeasureActualSubcategoryOptions.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureActualSubcategoryOptions.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.EIPPerformanceMeasureActualSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureActualSubcategoryOption CreateNewBlank(EIPPerformanceMeasureActual eIPPerformanceMeasureActual, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new EIPPerformanceMeasureActualSubcategoryOption(eIPPerformanceMeasureActual, indicatorSubcategoryOption, eIPPerformanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureActualSubcategoryOption).Name};

        [Key]
        public int EIPPerformanceMeasureActualSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureActualID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureActualSubcategoryOptionID; } set { EIPPerformanceMeasureActualSubcategoryOptionID = value; } }

        public virtual EIPPerformanceMeasureActual EIPPerformanceMeasureActual { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}