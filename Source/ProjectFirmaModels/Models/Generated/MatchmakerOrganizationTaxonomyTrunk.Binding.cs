//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyTrunk]
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
    // Table [dbo].[MatchmakerOrganizationTaxonomyTrunk] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[MatchmakerOrganizationTaxonomyTrunk]")]
    public partial class MatchmakerOrganizationTaxonomyTrunk : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchmakerOrganizationTaxonomyTrunk()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationTaxonomyTrunk(int matchmakerOrganizationTaxonomyTrunkID, int organizationID, int taxonomyTrunkID, bool isActive) : this()
        {
            this.MatchmakerOrganizationTaxonomyTrunkID = matchmakerOrganizationTaxonomyTrunkID;
            this.OrganizationID = organizationID;
            this.TaxonomyTrunkID = taxonomyTrunkID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationTaxonomyTrunk(int organizationID, int taxonomyTrunkID, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationTaxonomyTrunkID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.TaxonomyTrunkID = taxonomyTrunkID;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MatchmakerOrganizationTaxonomyTrunk(Organization organization, TaxonomyTrunk taxonomyTrunk, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationTaxonomyTrunkID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.MatchmakerOrganizationTaxonomyTrunks.Add(this);
            this.TaxonomyTrunkID = taxonomyTrunk.TaxonomyTrunkID;
            this.TaxonomyTrunk = taxonomyTrunk;
            taxonomyTrunk.MatchmakerOrganizationTaxonomyTrunks.Add(this);
            this.IsActive = isActive;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchmakerOrganizationTaxonomyTrunk CreateNewBlank(Organization organization, TaxonomyTrunk taxonomyTrunk)
        {
            return new MatchmakerOrganizationTaxonomyTrunk(organization, taxonomyTrunk, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchmakerOrganizationTaxonomyTrunk).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllMatchmakerOrganizationTaxonomyTrunks.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int MatchmakerOrganizationTaxonomyTrunkID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int TaxonomyTrunkID { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerOrganizationTaxonomyTrunkID; } set { MatchmakerOrganizationTaxonomyTrunkID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }
        public virtual TaxonomyTrunk TaxonomyTrunk { get; set; }

        public static class FieldLengths
        {

        }
    }
}