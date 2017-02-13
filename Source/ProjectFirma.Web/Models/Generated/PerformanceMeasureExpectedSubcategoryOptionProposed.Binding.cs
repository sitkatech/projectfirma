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
    public partial class PerformanceMeasureExpectedSubcategoryOptionProposed : IHavePrimaryKey, IHaveATenantID
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
        public PerformanceMeasureExpectedSubcategoryOptionProposed(int performanceMeasureExpectedSubcategoryOptionProposedID, int performanceMeasureExpectedProposedID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.PerformanceMeasureExpectedSubcategoryOptionProposedID = performanceMeasureExpectedSubcategoryOptionProposedID;
            this.PerformanceMeasureExpectedProposedID = performanceMeasureExpectedProposedID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionProposed(int performanceMeasureExpectedProposedID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureExpectedSubcategoryOptionProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.PerformanceMeasureExpectedProposedID = performanceMeasureExpectedProposedID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionProposed(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureExpectedSubcategoryOptionProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.PerformanceMeasureExpectedProposedID = performanceMeasureExpectedProposed.PerformanceMeasureExpectedProposedID;
            this.PerformanceMeasureExpectedProposed = performanceMeasureExpectedProposed;
            performanceMeasureExpectedProposed.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureSubcategoryOption = performanceMeasureSubcategoryOption;
            performanceMeasureSubcategoryOption.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            this.PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            performanceMeasureSubcategory.PerformanceMeasureExpectedSubcategoryOptionProposeds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureExpectedSubcategoryOptionProposed CreateNewBlank(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionProposed(performanceMeasureExpectedProposed, performanceMeasureSubcategoryOption, performanceMeasure, performanceMeasureSubcategory);
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
        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        public int TenantID { get; private set; }
        public int PrimaryKey { get { return PerformanceMeasureExpectedSubcategoryOptionProposedID; } set { PerformanceMeasureExpectedSubcategoryOptionProposedID = value; } }

        public virtual PerformanceMeasureExpectedProposed PerformanceMeasureExpectedProposed { get; set; }
        public virtual PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {

        }
    }
}