//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotPerformanceMeasureSubcategoryOption]
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
    [Table("[dbo].[SnapshotPerformanceMeasureSubcategoryOption]")]
    public partial class SnapshotPerformanceMeasureSubcategoryOption : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotPerformanceMeasureSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotPerformanceMeasureSubcategoryOption(int snapshotPerformanceMeasureSubcategoryOptionID, int snapshotPerformanceMeasureID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.SnapshotPerformanceMeasureSubcategoryOptionID = snapshotPerformanceMeasureSubcategoryOptionID;
            this.SnapshotPerformanceMeasureID = snapshotPerformanceMeasureID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotPerformanceMeasureSubcategoryOption(int snapshotPerformanceMeasureID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotPerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.SnapshotPerformanceMeasureID = snapshotPerformanceMeasureID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotPerformanceMeasureSubcategoryOption(SnapshotPerformanceMeasure snapshotPerformanceMeasure, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotPerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.SnapshotPerformanceMeasureID = snapshotPerformanceMeasure.SnapshotPerformanceMeasureID;
            this.SnapshotPerformanceMeasure = snapshotPerformanceMeasure;
            snapshotPerformanceMeasure.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureSubcategoryOption = performanceMeasureSubcategoryOption;
            performanceMeasureSubcategoryOption.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            this.PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            performanceMeasureSubcategory.SnapshotPerformanceMeasureSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotPerformanceMeasureSubcategoryOption CreateNewBlank(SnapshotPerformanceMeasure snapshotPerformanceMeasure, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            return new SnapshotPerformanceMeasureSubcategoryOption(snapshotPerformanceMeasure, performanceMeasureSubcategoryOption, performanceMeasure, performanceMeasureSubcategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int SnapshotPerformanceMeasureSubcategoryOptionID { get; set; }
        public int TenantID { get; set; }
        public int SnapshotPerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        public int PrimaryKey { get { return SnapshotPerformanceMeasureSubcategoryOptionID; } set { SnapshotPerformanceMeasureSubcategoryOptionID = value; } }

        public virtual Tenant Tenant { get; set; }
        public virtual SnapshotPerformanceMeasure SnapshotPerformanceMeasure { get; set; }
        public virtual PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}