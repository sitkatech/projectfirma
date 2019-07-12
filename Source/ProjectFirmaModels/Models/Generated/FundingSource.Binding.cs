//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSource]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[FundingSource] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FundingSource]")]
    public partial class FundingSource : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingSource()
        {
            this.FundingSourceCustomAttributes = new HashSet<FundingSourceCustomAttribute>();
            this.ProjectFundingSourceBudgets = new HashSet<ProjectFundingSourceBudget>();
            this.ProjectFundingSourceBudgetUpdates = new HashSet<ProjectFundingSourceBudgetUpdate>();
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectFundingSourceExpenditureUpdates = new HashSet<ProjectFundingSourceExpenditureUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSource(int fundingSourceID, int organizationID, string fundingSourceName, bool isActive, string fundingSourceDescription, decimal? fundingSourceAmount) : this()
        {
            this.FundingSourceID = fundingSourceID;
            this.OrganizationID = organizationID;
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
            this.FundingSourceDescription = fundingSourceDescription;
            this.FundingSourceAmount = fundingSourceAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSource(int organizationID, string fundingSourceName, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingSource(Organization organization, string fundingSourceName, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.FundingSources.Add(this);
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingSource CreateNewBlank(Organization organization)
        {
            return new FundingSource(organization, default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FundingSourceCustomAttributes.Any() || ProjectFundingSourceBudgets.Any() || ProjectFundingSourceBudgetUpdates.Any() || ProjectFundingSourceExpenditures.Any() || ProjectFundingSourceExpenditureUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingSource).Name, typeof(FundingSourceCustomAttribute).Name, typeof(ProjectFundingSourceBudget).Name, typeof(ProjectFundingSourceBudgetUpdate).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectFundingSourceExpenditureUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFundingSources.Remove(this);
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

            foreach(var x in FundingSourceCustomAttributes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceBudgets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceBudgetUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceExpenditures.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceExpenditureUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FundingSourceID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public string FundingSourceName { get; set; }
        public bool IsActive { get; set; }
        public string FundingSourceDescription { get; set; }
        public decimal? FundingSourceAmount { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingSourceID; } set { FundingSourceID = value; } }

        public virtual ICollection<FundingSourceCustomAttribute> FundingSourceCustomAttributes { get; set; }
        public virtual ICollection<ProjectFundingSourceBudget> ProjectFundingSourceBudgets { get; set; }
        public virtual ICollection<ProjectFundingSourceBudgetUpdate> ProjectFundingSourceBudgetUpdates { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int FundingSourceName = 200;
            public const int FundingSourceDescription = 500;
        }
    }
}