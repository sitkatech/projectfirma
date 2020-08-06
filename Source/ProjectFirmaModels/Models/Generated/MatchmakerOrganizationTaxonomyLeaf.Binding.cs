//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyLeaf]
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
    // Table [dbo].[MatchmakerOrganizationTaxonomyLeaf] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[MatchmakerOrganizationTaxonomyLeaf]")]
    public partial class MatchmakerOrganizationTaxonomyLeaf : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchmakerOrganizationTaxonomyLeaf()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationTaxonomyLeaf(int matchmakerOrganizationTaxonomyLeafID, int organizationID, int taxonomyLeafID, bool isActive) : this()
        {
            this.MatchmakerOrganizationTaxonomyLeafID = matchmakerOrganizationTaxonomyLeafID;
            this.OrganizationID = organizationID;
            this.TaxonomyLeafID = taxonomyLeafID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationTaxonomyLeaf(int organizationID, int taxonomyLeafID, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationTaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.TaxonomyLeafID = taxonomyLeafID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MatchmakerOrganizationTaxonomyLeaf(Organization organization, TaxonomyLeaf taxonomyLeaf, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationTaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.MatchmakerOrganizationTaxonomyLeafs.Add(this);
            this.TaxonomyLeafID = taxonomyLeaf.TaxonomyLeafID;
            this.TaxonomyLeaf = taxonomyLeaf;
            taxonomyLeaf.MatchmakerOrganizationTaxonomyLeafs.Add(this);
            this.IsActive = isActive;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchmakerOrganizationTaxonomyLeaf CreateNewBlank(Organization organization, TaxonomyLeaf taxonomyLeaf)
        {
            return new MatchmakerOrganizationTaxonomyLeaf(organization, taxonomyLeaf, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchmakerOrganizationTaxonomyLeaf).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllMatchmakerOrganizationTaxonomyLeafs.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int MatchmakerOrganizationTaxonomyLeafID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int TaxonomyLeafID { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerOrganizationTaxonomyLeafID; } set { MatchmakerOrganizationTaxonomyLeafID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }
        public virtual TaxonomyLeaf TaxonomyLeaf { get; set; }

        public static class FieldLengths
        {

        }
    }
}