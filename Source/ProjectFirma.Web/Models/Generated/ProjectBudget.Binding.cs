//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudget]
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
    [Table("[dbo].[ProjectBudget]")]
    public partial class ProjectBudget : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectBudget()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectBudget(int projectBudgetID, int projectID, int fundingSourceID, int projectCostTypeID, int calendarYear, decimal budgetedAmount) : this()
        {
            this.ProjectBudgetID = projectBudgetID;
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.ProjectCostTypeID = projectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectBudget(int projectID, int fundingSourceID, int projectCostTypeID, int calendarYear, decimal budgetedAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.ProjectCostTypeID = projectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectBudget(Project project, FundingSource fundingSource, ProjectCostType projectCostType, int calendarYear, decimal budgetedAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectBudgets.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectBudgets.Add(this);
            this.ProjectCostTypeID = projectCostType.ProjectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectBudget CreateNewBlank(Project project, FundingSource fundingSource, ProjectCostType projectCostType)
        {
            return new ProjectBudget(project, fundingSource, projectCostType, default(int), default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectBudget).Name};

        [Key]
        public int ProjectBudgetID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public int ProjectCostTypeID { get; set; }
        public int CalendarYear { get; set; }
        public decimal BudgetedAmount { get; set; }
        public int PrimaryKey { get { return ProjectBudgetID; } set { ProjectBudgetID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public ProjectCostType ProjectCostType { get { return ProjectCostType.AllLookupDictionary[ProjectCostTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}