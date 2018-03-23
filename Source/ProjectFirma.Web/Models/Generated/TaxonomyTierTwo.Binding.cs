//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwo]
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
    [Table("[dbo].[TaxonomyTierTwo]")]
    public partial class TaxonomyTierTwo : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyTierTwo()
        {
            this.TaxonomyLeafs = new HashSet<TaxonomyLeaf>();
            this.TaxonomyTierTwoPerformanceMeasures = new HashSet<TaxonomyTierTwoPerformanceMeasure>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwo(int taxonomyTierTwoID, int taxonomyTrunkID, string taxonomyTierTwoName, string taxonomyTierTwoDescription, string themeColor, string taxonomyTierTwoCode) : this()
        {
            this.TaxonomyTierTwoID = taxonomyTierTwoID;
            this.TaxonomyTrunkID = taxonomyTrunkID;
            this.TaxonomyTierTwoName = taxonomyTierTwoName;
            this.TaxonomyTierTwoDescription = taxonomyTierTwoDescription;
            this.ThemeColor = themeColor;
            this.TaxonomyTierTwoCode = taxonomyTierTwoCode;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwo(int taxonomyTrunkID, string taxonomyTierTwoName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierTwoID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyTrunkID = taxonomyTrunkID;
            this.TaxonomyTierTwoName = taxonomyTierTwoName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyTierTwo(TaxonomyTrunk taxonomyTrunk, string taxonomyTierTwoName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierTwoID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyTrunkID = taxonomyTrunk.TaxonomyTrunkID;
            this.TaxonomyTrunk = taxonomyTrunk;
            taxonomyTrunk.TaxonomyTierTwos.Add(this);
            this.TaxonomyTierTwoName = taxonomyTierTwoName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyTierTwo CreateNewBlank(TaxonomyTrunk taxonomyTrunk)
        {
            return new TaxonomyTierTwo(taxonomyTrunk, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TaxonomyLeafs.Any() || TaxonomyTierTwoPerformanceMeasures.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyTierTwo).Name, typeof(TaxonomyLeaf).Name, typeof(TaxonomyTierTwoPerformanceMeasure).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {

            foreach(var x in TaxonomyLeafs.ToList())
            {
                x.DeleteFull();
            }

            foreach(var x in TaxonomyTierTwoPerformanceMeasures.ToList())
            {
                x.DeleteFull();
            }
            HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwos.Remove(this);                
        }

        [Key]
        public int TaxonomyTierTwoID { get; set; }
        public int TenantID { get; private set; }
        public int TaxonomyTrunkID { get; set; }
        public string TaxonomyTierTwoName { get; set; }
        public string TaxonomyTierTwoDescription { get; set; }
        public string ThemeColor { get; set; }
        public string TaxonomyTierTwoCode { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TaxonomyTierTwoID; } set { TaxonomyTierTwoID = value; } }

        public virtual ICollection<TaxonomyLeaf> TaxonomyLeafs { get; set; }
        public virtual ICollection<TaxonomyTierTwoPerformanceMeasure> TaxonomyTierTwoPerformanceMeasures { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyTrunk TaxonomyTrunk { get; set; }

        public static class FieldLengths
        {
            public const int TaxonomyTierTwoName = 100;
            public const int TaxonomyTierTwoDescription = 4000;
            public const int ThemeColor = 7;
            public const int TaxonomyTierTwoCode = 10;
        }
    }
}