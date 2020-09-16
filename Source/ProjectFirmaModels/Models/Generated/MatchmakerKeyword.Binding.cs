//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerKeyword]
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
    // Table [dbo].[MatchmakerKeyword] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[MatchmakerKeyword]")]
    public partial class MatchmakerKeyword : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchmakerKeyword()
        {
            this.OrganizationMatchmakerKeywords = new HashSet<OrganizationMatchmakerKeyword>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerKeyword(int matchmakerKeywordID, string matchmakerKeywordName, string matchmakerKeywordDescription) : this()
        {
            this.MatchmakerKeywordID = matchmakerKeywordID;
            this.MatchmakerKeywordName = matchmakerKeywordName;
            this.MatchmakerKeywordDescription = matchmakerKeywordDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerKeyword(string matchmakerKeywordName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerKeywordID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.MatchmakerKeywordName = matchmakerKeywordName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchmakerKeyword CreateNewBlank()
        {
            return new MatchmakerKeyword(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return OrganizationMatchmakerKeywords.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(OrganizationMatchmakerKeywords.Any())
            {
                dependentObjects.Add(typeof(OrganizationMatchmakerKeyword).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchmakerKeyword).Name, typeof(OrganizationMatchmakerKeyword).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllMatchmakerKeywords.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in OrganizationMatchmakerKeywords.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int MatchmakerKeywordID { get; set; }
        public int TenantID { get; set; }
        public string MatchmakerKeywordName { get; set; }
        public string MatchmakerKeywordDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerKeywordID; } set { MatchmakerKeywordID = value; } }

        public virtual ICollection<OrganizationMatchmakerKeyword> OrganizationMatchmakerKeywords { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int MatchmakerKeywordName = 100;
            public const int MatchmakerKeywordDescription = 1000;
        }
    }
}