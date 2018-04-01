//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeaf]
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
    [Table("[dbo].[TaxonomyLeaf]")]
    public partial class TaxonomyLeaf : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyLeaf()
        {
            this.Projects = new HashSet<Project>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyLeaf(int taxonomyLeafID, int taxonomyBranchID, string taxonomyLeafName, string taxonomyLeafDescription, string taxonomyLeafCode) : this()
        {
            this.TaxonomyLeafID = taxonomyLeafID;
            this.TaxonomyBranchID = taxonomyBranchID;
            this.TaxonomyLeafName = taxonomyLeafName;
            this.TaxonomyLeafDescription = taxonomyLeafDescription;
            this.TaxonomyLeafCode = taxonomyLeafCode;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyLeaf(int taxonomyBranchID, string taxonomyLeafName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyBranchID = taxonomyBranchID;
            this.TaxonomyLeafName = taxonomyLeafName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyLeaf(TaxonomyBranch taxonomyBranch, string taxonomyLeafName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyBranchID = taxonomyBranch.TaxonomyBranchID;
            this.TaxonomyBranch = taxonomyBranch;
            taxonomyBranch.TaxonomyLeafs.Add(this);
            this.TaxonomyLeafName = taxonomyLeafName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyLeaf CreateNewBlank(TaxonomyBranch taxonomyBranch)
        {
            return new TaxonomyLeaf(taxonomyBranch, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Projects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyLeaf).Name, typeof(Project).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {

            foreach(var x in Projects.ToList())
            {
                x.DeleteFull();
            }
            HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.Remove(this);                
        }

        [Key]
        public int TaxonomyLeafID { get; set; }
        public int TenantID { get; private set; }
        public int TaxonomyBranchID { get; set; }
        public string TaxonomyLeafName { get; set; }
        public string TaxonomyLeafDescription { get; set; }
        public string TaxonomyLeafCode { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TaxonomyLeafID; } set { TaxonomyLeafID = value; } }

        public virtual ICollection<Project> Projects { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyBranch TaxonomyBranch { get; set; }

        public static class FieldLengths
        {
            public const int TaxonomyLeafName = 100;
            public const int TaxonomyLeafDescription = 4000;
            public const int TaxonomyLeafCode = 10;
        }
    }
}