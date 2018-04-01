//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyBranchPerformanceMeasure]
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
    [Table("[dbo].[TaxonomyBranchPerformanceMeasure]")]
    public partial class TaxonomyBranchPerformanceMeasure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyBranchPerformanceMeasure()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyBranchPerformanceMeasure(int taxonomyBranchPerformanceMeasureID, int taxonomyBranchID, int performanceMeasureID, bool isPrimaryTaxonomyBranch) : this()
        {
            this.TaxonomyBranchPerformanceMeasureID = taxonomyBranchPerformanceMeasureID;
            this.TaxonomyBranchID = taxonomyBranchID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryTaxonomyBranch = isPrimaryTaxonomyBranch;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyBranchPerformanceMeasure(int taxonomyBranchID, int performanceMeasureID, bool isPrimaryTaxonomyBranch) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyBranchPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyBranchID = taxonomyBranchID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryTaxonomyBranch = isPrimaryTaxonomyBranch;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyBranchPerformanceMeasure(TaxonomyBranch taxonomyBranch, PerformanceMeasure performanceMeasure, bool isPrimaryTaxonomyBranch) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyBranchPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyBranchID = taxonomyBranch.TaxonomyBranchID;
            this.TaxonomyBranch = taxonomyBranch;
            taxonomyBranch.TaxonomyBranchPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.TaxonomyBranchPerformanceMeasures.Add(this);
            this.IsPrimaryTaxonomyBranch = isPrimaryTaxonomyBranch;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyBranchPerformanceMeasure CreateNewBlank(TaxonomyBranch taxonomyBranch, PerformanceMeasure performanceMeasure)
        {
            return new TaxonomyBranchPerformanceMeasure(taxonomyBranch, performanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyBranchPerformanceMeasure).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            HttpRequestStorage.DatabaseEntities.AllTaxonomyBranchPerformanceMeasures.Remove(this);                
        }

        [Key]
        public int TaxonomyBranchPerformanceMeasureID { get; set; }
        public int TenantID { get; private set; }
        public int TaxonomyBranchID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryTaxonomyBranch { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TaxonomyBranchPerformanceMeasureID; } set { TaxonomyBranchPerformanceMeasureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyBranch TaxonomyBranch { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}