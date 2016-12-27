//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwoPerformanceMeasure]
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
    [Table("[dbo].[TaxonomyTierTwoPerformanceMeasure]")]
    public partial class TaxonomyTierTwoPerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyTierTwoPerformanceMeasure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasure(int taxonomyTierTwoPerformanceMeasureID, int taxonomyTierTwoID, int performanceMeasureID, bool isPrimaryTaxonomyTierTwo) : this()
        {
            this.TaxonomyTierTwoPerformanceMeasureID = taxonomyTierTwoPerformanceMeasureID;
            this.TaxonomyTierTwoID = taxonomyTierTwoID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryTaxonomyTierTwo = isPrimaryTaxonomyTierTwo;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasure(int taxonomyTierTwoID, int performanceMeasureID, bool isPrimaryTaxonomyTierTwo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TaxonomyTierTwoPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyTierTwoID = taxonomyTierTwoID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryTaxonomyTierTwo = isPrimaryTaxonomyTierTwo;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasure(TaxonomyTierTwo taxonomyTierTwo, PerformanceMeasure performanceMeasure, bool isPrimaryTaxonomyTierTwo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierTwoPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyTierTwoID = taxonomyTierTwo.TaxonomyTierTwoID;
            this.TaxonomyTierTwo = taxonomyTierTwo;
            taxonomyTierTwo.TaxonomyTierTwoPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.TaxonomyTierTwoPerformanceMeasures.Add(this);
            this.IsPrimaryTaxonomyTierTwo = isPrimaryTaxonomyTierTwo;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyTierTwoPerformanceMeasure CreateNewBlank(TaxonomyTierTwo taxonomyTierTwo, PerformanceMeasure performanceMeasure)
        {
            return new TaxonomyTierTwoPerformanceMeasure(taxonomyTierTwo, performanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyTierTwoPerformanceMeasure).Name};

        [Key]
        public int TaxonomyTierTwoPerformanceMeasureID { get; set; }
        public int TaxonomyTierTwoID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryTaxonomyTierTwo { get; set; }
        public int PrimaryKey { get { return TaxonomyTierTwoPerformanceMeasureID; } set { TaxonomyTierTwoPerformanceMeasureID = value; } }

        public virtual TaxonomyTierTwo TaxonomyTierTwo { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}