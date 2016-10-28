//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]
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
    [Table("[dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]")]
    public partial class PerformanceMeasureActualSubcategoryOptionUpdate : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureActualSubcategoryOptionUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdate(int performanceMeasureActualSubcategoryOptionUpdateID, int performanceMeasureActualUpdateID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.PerformanceMeasureActualSubcategoryOptionUpdateID = performanceMeasureActualSubcategoryOptionUpdateID;
            this.PerformanceMeasureActualUpdateID = performanceMeasureActualUpdateID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdate(int performanceMeasureActualUpdateID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PerformanceMeasureActualSubcategoryOptionUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureActualUpdateID = performanceMeasureActualUpdateID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdate(PerformanceMeasureActualUpdate performanceMeasureActualUpdate, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureActualSubcategoryOptionUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureActualUpdateID = performanceMeasureActualUpdate.PerformanceMeasureActualUpdateID;
            this.PerformanceMeasureActualUpdate = performanceMeasureActualUpdate;
            performanceMeasureActualUpdate.PerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.PerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.PerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureActualSubcategoryOptionUpdate CreateNewBlank(PerformanceMeasureActualUpdate performanceMeasureActualUpdate, IndicatorSubcategoryOption indicatorSubcategoryOption, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new PerformanceMeasureActualSubcategoryOptionUpdate(performanceMeasureActualUpdate, indicatorSubcategoryOption, performanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name};

        [Key]
        public int PerformanceMeasureActualSubcategoryOptionUpdateID { get; set; }
        public int PerformanceMeasureActualUpdateID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureActualSubcategoryOptionUpdateID; } set { PerformanceMeasureActualSubcategoryOptionUpdateID = value; } }

        public virtual PerformanceMeasureActualUpdate PerformanceMeasureActualUpdate { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}