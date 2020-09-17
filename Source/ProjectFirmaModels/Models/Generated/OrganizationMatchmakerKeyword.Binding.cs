//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationMatchmakerKeyword]
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
    // Table [dbo].[OrganizationMatchmakerKeyword] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[OrganizationMatchmakerKeyword]")]
    public partial class OrganizationMatchmakerKeyword : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected OrganizationMatchmakerKeyword()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationMatchmakerKeyword(int organizationMatchmakerKeywordID, int organizationID, int matchmakerKeywordID) : this()
        {
            this.OrganizationMatchmakerKeywordID = organizationMatchmakerKeywordID;
            this.OrganizationID = organizationID;
            this.MatchmakerKeywordID = matchmakerKeywordID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationMatchmakerKeyword(int organizationID, int matchmakerKeywordID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationMatchmakerKeywordID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.MatchmakerKeywordID = matchmakerKeywordID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public OrganizationMatchmakerKeyword(Organization organization, MatchmakerKeyword matchmakerKeyword) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationMatchmakerKeywordID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.OrganizationMatchmakerKeywords.Add(this);
            this.MatchmakerKeywordID = matchmakerKeyword.MatchmakerKeywordID;
            this.MatchmakerKeyword = matchmakerKeyword;
            matchmakerKeyword.OrganizationMatchmakerKeywords.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static OrganizationMatchmakerKeyword CreateNewBlank(Organization organization, MatchmakerKeyword matchmakerKeyword)
        {
            return new OrganizationMatchmakerKeyword(organization, matchmakerKeyword);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(OrganizationMatchmakerKeyword).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllOrganizationMatchmakerKeywords.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int OrganizationMatchmakerKeywordID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int MatchmakerKeywordID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationMatchmakerKeywordID; } set { OrganizationMatchmakerKeywordID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }
        public virtual MatchmakerKeyword MatchmakerKeyword { get; set; }

        public static class FieldLengths
        {

        }
    }
}