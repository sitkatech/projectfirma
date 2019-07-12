//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceBudget]
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
    // Table [dbo].[ProjectFundingSourceBudget] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectFundingSourceBudget]")]
    public partial class ProjectFundingSourceBudget : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFundingSourceBudget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceBudget(int projectFundingSourceBudgetID, int projectID, int fundingSourceID, decimal? securedAmount, decimal? targetedAmount) : this()
        {
            this.ProjectFundingSourceBudgetID = projectFundingSourceBudgetID;
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.SecuredAmount = securedAmount;
            this.TargetedAmount = targetedAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceBudget(int projectID, int fundingSourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFundingSourceBudget(Project project, FundingSource fundingSource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectFundingSourceBudgets.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectFundingSourceBudgets.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFundingSourceBudget CreateNewBlank(Project project, FundingSource fundingSource)
        {
            return new ProjectFundingSourceBudget(project, fundingSource);
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
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFundingSourceBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectFundingSourceBudgets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectFundingSourceBudgetID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal? SecuredAmount { get; set; }
        public decimal? TargetedAmount { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectFundingSourceBudgetID; } set { ProjectFundingSourceBudgetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual FundingSource FundingSource { get; set; }

        public static class FieldLengths
        {

        }
    }
}