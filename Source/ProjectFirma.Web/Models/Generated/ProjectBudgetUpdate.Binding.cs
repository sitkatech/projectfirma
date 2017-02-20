//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudgetUpdate]
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
    [Table("[dbo].[ProjectBudgetUpdate]")]
    public partial class ProjectBudgetUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectBudgetUpdate()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectBudgetUpdate(int projectBudgetUpdateID, int projectUpdateBatchID, int fundingSourceID, int projectCostTypeID, int calendarYear, decimal? budgetedAmount) : this()
        {
            this.ProjectBudgetUpdateID = projectBudgetUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.ProjectCostTypeID = projectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectBudgetUpdate(int projectUpdateBatchID, int fundingSourceID, int projectCostTypeID, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectBudgetUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.ProjectCostTypeID = projectCostTypeID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectBudgetUpdate(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, ProjectCostType projectCostType, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectBudgetUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectBudgetUpdates.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectBudgetUpdates.Add(this);
            this.ProjectCostTypeID = projectCostType.ProjectCostTypeID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectBudgetUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, ProjectCostType projectCostType)
        {
            return new ProjectBudgetUpdate(projectUpdateBatch, fundingSource, projectCostType, default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectBudgetUpdate).Name};

        [Key]
        public int ProjectBudgetUpdateID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FundingSourceID { get; set; }
        public int ProjectCostTypeID { get; set; }
        public int CalendarYear { get; set; }
        public decimal? BudgetedAmount { get; set; }
        public int PrimaryKey { get { return ProjectBudgetUpdateID; } set { ProjectBudgetUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public ProjectCostType ProjectCostType { get { return ProjectCostType.AllLookupDictionary[ProjectCostTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}