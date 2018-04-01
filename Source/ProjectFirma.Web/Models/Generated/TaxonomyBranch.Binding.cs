//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyBranch]
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
    [Table("[dbo].[TaxonomyBranch]")]
    public partial class TaxonomyBranch : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyBranch()
        {
            this.TaxonomyBranchPerformanceMeasures = new HashSet<TaxonomyBranchPerformanceMeasure>();
            this.TaxonomyLeafs = new HashSet<TaxonomyLeaf>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyBranch(int taxonomyBranchID, int taxonomyTrunkID, string taxonomyBranchName, string taxonomyBranchDescription, string themeColor, string taxonomyBranchCode) : this()
        {
            this.TaxonomyBranchID = taxonomyBranchID;
            this.TaxonomyTrunkID = taxonomyTrunkID;
            this.TaxonomyBranchName = taxonomyBranchName;
            this.TaxonomyBranchDescription = taxonomyBranchDescription;
            this.ThemeColor = themeColor;
            this.TaxonomyBranchCode = taxonomyBranchCode;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyBranch(int taxonomyTrunkID, string taxonomyBranchName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyBranchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyTrunkID = taxonomyTrunkID;
            this.TaxonomyBranchName = taxonomyBranchName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyBranch(TaxonomyTrunk taxonomyTrunk, string taxonomyBranchName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyBranchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyTrunkID = taxonomyTrunk.TaxonomyTrunkID;
            this.TaxonomyTrunk = taxonomyTrunk;
            taxonomyTrunk.TaxonomyBranches.Add(this);
            this.TaxonomyBranchName = taxonomyBranchName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyBranch CreateNewBlank(TaxonomyTrunk taxonomyTrunk)
        {
            return new TaxonomyBranch(taxonomyTrunk, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TaxonomyBranchPerformanceMeasures.Any() || TaxonomyLeafs.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyBranch).Name, typeof(TaxonomyBranchPerformanceMeasure).Name, typeof(TaxonomyLeaf).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {

            foreach(var x in TaxonomyBranchPerformanceMeasures.ToList())
            {
                x.DeleteFull();
            }

            foreach(var x in TaxonomyLeafs.ToList())
            {
                x.DeleteFull();
            }
            HttpRequestStorage.DatabaseEntities.AllTaxonomyBranches.Remove(this);                
        }

        [Key]
        public int TaxonomyBranchID { get; set; }
        public int TenantID { get; private set; }
        public int TaxonomyTrunkID { get; set; }
        public string TaxonomyBranchName { get; set; }
        public string TaxonomyBranchDescription { get; set; }
        public string ThemeColor { get; set; }
        public string TaxonomyBranchCode { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TaxonomyBranchID; } set { TaxonomyBranchID = value; } }

        public virtual ICollection<TaxonomyBranchPerformanceMeasure> TaxonomyBranchPerformanceMeasures { get; set; }
        public virtual ICollection<TaxonomyLeaf> TaxonomyLeafs { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyTrunk TaxonomyTrunk { get; set; }

        public static class FieldLengths
        {
            public const int TaxonomyBranchName = 100;
            public const int TaxonomyBranchDescription = 4000;
            public const int ThemeColor = 7;
            public const int TaxonomyBranchCode = 10;
        }
    }
}