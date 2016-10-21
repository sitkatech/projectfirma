//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]
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
    [Table("[dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]")]
    public partial class EIPPerformanceMeasureActualSubcategoryOptionUpdate : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureActualSubcategoryOptionUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionUpdate(int eIPPerformanceMeasureActualSubcategoryOptionUpdateID, int eIPPerformanceMeasureActualUpdateID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            this.EIPPerformanceMeasureActualSubcategoryOptionUpdateID = eIPPerformanceMeasureActualSubcategoryOptionUpdateID;
            this.EIPPerformanceMeasureActualUpdateID = eIPPerformanceMeasureActualUpdateID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionUpdate(int eIPPerformanceMeasureActualUpdateID, int indicatorSubcategoryOptionID, int eIPPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureActualSubcategoryOptionUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EIPPerformanceMeasureActualUpdateID = eIPPerformanceMeasureActualUpdateID;
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionUpdate(EIPPerformanceMeasureActualUpdate eIPPerformanceMeasureActualUpdate, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureActualSubcategoryOptionUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EIPPerformanceMeasureActualUpdateID = eIPPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualUpdateID;
            this.EIPPerformanceMeasureActualUpdate = eIPPerformanceMeasureActualUpdate;
            eIPPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
            this.IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            this.IndicatorSubcategoryOption = indicatorSubcategoryOption;
            indicatorSubcategoryOption.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
            this.IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            this.IndicatorSubcategory = indicatorSubcategory;
            indicatorSubcategory.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureActualSubcategoryOptionUpdate CreateNewBlank(EIPPerformanceMeasureActualUpdate eIPPerformanceMeasureActualUpdate, IndicatorSubcategoryOption indicatorSubcategoryOption, EIPPerformanceMeasure eIPPerformanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            return new EIPPerformanceMeasureActualSubcategoryOptionUpdate(eIPPerformanceMeasureActualUpdate, indicatorSubcategoryOption, eIPPerformanceMeasure, indicatorSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureActualSubcategoryOptionUpdate).Name};

        [Key]
        public int EIPPerformanceMeasureActualSubcategoryOptionUpdateID { get; set; }
        public int EIPPerformanceMeasureActualUpdateID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureActualSubcategoryOptionUpdateID; } set { EIPPerformanceMeasureActualSubcategoryOptionUpdateID = value; } }

        public virtual EIPPerformanceMeasureActualUpdate EIPPerformanceMeasureActualUpdate { get; set; }
        public virtual IndicatorSubcategoryOption IndicatorSubcategoryOption { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }
        public virtual IndicatorSubcategory IndicatorSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}