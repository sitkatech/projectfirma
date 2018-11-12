//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeafPerformanceMeasure]
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
    [Table("[dbo].[TaxonomyLeafPerformanceMeasure]")]
    public partial class TaxonomyLeafPerformanceMeasure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyLeafPerformanceMeasure()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyLeafPerformanceMeasure(int taxonomyLeafPerformanceMeasureID, int taxonomyLeafID, int performanceMeasureID, bool isPrimaryTaxonomyLeaf) : this()
        {
            this.TaxonomyLeafPerformanceMeasureID = taxonomyLeafPerformanceMeasureID;
            this.TaxonomyLeafID = taxonomyLeafID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryTaxonomyLeaf = isPrimaryTaxonomyLeaf;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyLeafPerformanceMeasure(int taxonomyLeafID, int performanceMeasureID, bool isPrimaryTaxonomyLeaf) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyLeafPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyLeafID = taxonomyLeafID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryTaxonomyLeaf = isPrimaryTaxonomyLeaf;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyLeafPerformanceMeasure(TaxonomyLeaf taxonomyLeaf, PerformanceMeasure performanceMeasure, bool isPrimaryTaxonomyLeaf) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyLeafPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyLeafID = taxonomyLeaf.TaxonomyLeafID;
            this.TaxonomyLeaf = taxonomyLeaf;
            taxonomyLeaf.TaxonomyLeafPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.TaxonomyLeafPerformanceMeasures.Add(this);
            this.IsPrimaryTaxonomyLeaf = isPrimaryTaxonomyLeaf;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyLeafPerformanceMeasure CreateNewBlank(TaxonomyLeaf taxonomyLeaf, PerformanceMeasure performanceMeasure)
        {
            return new TaxonomyLeafPerformanceMeasure(taxonomyLeaf, performanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyLeafPerformanceMeasure).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            DeleteFull(HttpRequestStorage.DatabaseEntities);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            dbContext.AllTaxonomyLeafPerformanceMeasures.Remove(this);
        }

        [Key]
        public int TaxonomyLeafPerformanceMeasureID { get; set; }
        public int TenantID { get; private set; }
        public int TaxonomyLeafID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryTaxonomyLeaf { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TaxonomyLeafPerformanceMeasureID; } set { TaxonomyLeafPerformanceMeasureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyLeaf TaxonomyLeaf { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}