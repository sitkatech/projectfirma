//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierThree]
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
    [Table("[dbo].[TaxonomyTierThree]")]
    public partial class TaxonomyTierThree : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyTierThree()
        {
            this.TaxonomyTierTwos = new HashSet<TaxonomyTierTwo>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierThree(int taxonomyTierThreeID, string taxonomyTierThreeName, string taxonomyTierThreeDescription, string themeColor, string taxonomyTierThreeCode) : this()
        {
            this.TaxonomyTierThreeID = taxonomyTierThreeID;
            this.TaxonomyTierThreeName = taxonomyTierThreeName;
            this.TaxonomyTierThreeDescription = taxonomyTierThreeDescription;
            this.ThemeColor = themeColor;
            this.TaxonomyTierThreeCode = taxonomyTierThreeCode;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierThree(string taxonomyTierThreeName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierThreeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyTierThreeName = taxonomyTierThreeName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyTierThree CreateNewBlank()
        {
            return new TaxonomyTierThree(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TaxonomyTierTwos.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyTierThree).Name, typeof(TaxonomyTierTwo).Name};

        [Key]
        public int TaxonomyTierThreeID { get; set; }
        public int TenantID { get; private set; }
        public string TaxonomyTierThreeName { get; set; }
        public string TaxonomyTierThreeDescription { get; set; }
        public string ThemeColor { get; set; }
        public string TaxonomyTierThreeCode { get; set; }
        public int PrimaryKey { get { return TaxonomyTierThreeID; } set { TaxonomyTierThreeID = value; } }

        public virtual ICollection<TaxonomyTierTwo> TaxonomyTierTwos { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int TaxonomyTierThreeName = 100;
            public const int TaxonomyTierThreeDescription = 4000;
            public const int ThemeColor = 20;
            public const int TaxonomyTierThreeCode = 10;
        }
    }
}