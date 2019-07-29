//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditureUpdate]
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
    // Table [dbo].[ProjectFundingSourceExpenditureUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectFundingSourceExpenditureUpdate]")]
    public partial class ProjectFundingSourceExpenditureUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFundingSourceExpenditureUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceExpenditureUpdate(int projectFundingSourceExpenditureUpdateID, int projectUpdateBatchID, int fundingSourceID, int calendarYear, decimal expenditureAmount, int? costTypeID) : this()
        {
            this.ProjectFundingSourceExpenditureUpdateID = projectFundingSourceExpenditureUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
            this.CostTypeID = costTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceExpenditureUpdate(int projectUpdateBatchID, int fundingSourceID, int calendarYear, decimal expenditureAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceExpenditureUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFundingSourceExpenditureUpdate(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, int calendarYear, decimal expenditureAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceExpenditureUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectFundingSourceExpenditureUpdates.Add(this);
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFundingSourceExpenditureUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource)
        {
            return new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch, fundingSource, default(int), default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFundingSourceExpenditureUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectFundingSourceExpenditureUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectFundingSourceExpenditureUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FundingSourceID { get; set; }
        public int CalendarYear { get; set; }
        public decimal ExpenditureAmount { get; set; }
        public int? CostTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectFundingSourceExpenditureUpdateID; } set { ProjectFundingSourceExpenditureUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public virtual CostType CostType { get; set; }

        public static class FieldLengths
        {

        }
    }
}