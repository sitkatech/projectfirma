//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOption]
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
    [Table("[dbo].[PerformanceMeasureActualSubcategoryOption]")]
    public partial class PerformanceMeasureActualSubcategoryOption : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureActualSubcategoryOption()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOption(int performanceMeasureActualSubcategoryOptionID, int performanceMeasureActualID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            this.PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOptionID;
            this.PerformanceMeasureActualID = performanceMeasureActualID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOption(int performanceMeasureActualID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureActualSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureActualID = performanceMeasureActualID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureActualSubcategoryOption(PerformanceMeasureActual performanceMeasureActual, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureActualSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureActualID = performanceMeasureActual.PerformanceMeasureActualID;
            this.PerformanceMeasureActual = performanceMeasureActual;
            performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions.Add(this);
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureSubcategoryOption = performanceMeasureSubcategoryOption;
            performanceMeasureSubcategoryOption.PerformanceMeasureActualSubcategoryOptions.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureActualSubcategoryOptions.Add(this);
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            this.PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            performanceMeasureSubcategory.PerformanceMeasureActualSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureActualSubcategoryOption CreateNewBlank(PerformanceMeasureActual performanceMeasureActual, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            return new PerformanceMeasureActualSubcategoryOption(performanceMeasureActual, performanceMeasureSubcategoryOption, performanceMeasure, performanceMeasureSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureActualSubcategoryOption).Name};

        [Key]
        public int PerformanceMeasureActualSubcategoryOptionID { get; set; }
        public int TenantID { get; private set; }
        public int PerformanceMeasureActualID { get; set; }
        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureActualSubcategoryOptionID; } set { PerformanceMeasureActualSubcategoryOptionID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual PerformanceMeasureActual PerformanceMeasureActual { get; set; }
        public virtual PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}