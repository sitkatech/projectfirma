//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyBranch]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[MatchmakerOrganizationTaxonomyBranch] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[MatchmakerOrganizationTaxonomyBranch]")]
    public partial class MatchmakerOrganizationTaxonomyBranch : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchmakerOrganizationTaxonomyBranch()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationTaxonomyBranch(int matchmakerOrganizationTaxonomyBranchID, int organizationID, int taxonomyBranchID, bool isActive) : this()
        {
            this.MatchmakerOrganizationTaxonomyBranchID = matchmakerOrganizationTaxonomyBranchID;
            this.OrganizationID = organizationID;
            this.TaxonomyBranchID = taxonomyBranchID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationTaxonomyBranch(int organizationID, int taxonomyBranchID, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationTaxonomyBranchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.TaxonomyBranchID = taxonomyBranchID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MatchmakerOrganizationTaxonomyBranch(Organization organization, TaxonomyBranch taxonomyBranch, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationTaxonomyBranchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.MatchmakerOrganizationTaxonomyBranches.Add(this);
            this.TaxonomyBranchID = taxonomyBranch.TaxonomyBranchID;
            this.TaxonomyBranch = taxonomyBranch;
            taxonomyBranch.MatchmakerOrganizationTaxonomyBranches.Add(this);
            this.IsActive = isActive;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchmakerOrganizationTaxonomyBranch CreateNewBlank(Organization organization, TaxonomyBranch taxonomyBranch)
        {
            return new MatchmakerOrganizationTaxonomyBranch(organization, taxonomyBranch, default(bool));
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchmakerOrganizationTaxonomyBranch).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllMatchmakerOrganizationTaxonomyBranches.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int MatchmakerOrganizationTaxonomyBranchID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int TaxonomyBranchID { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerOrganizationTaxonomyBranchID; } set { MatchmakerOrganizationTaxonomyBranchID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }
        public virtual TaxonomyBranch TaxonomyBranch { get; set; }

        public static class FieldLengths
        {

        }
    }
}