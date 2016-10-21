//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationProjectBudget]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[TransportationProjectBudget]")]
    public partial class TransportationProjectBudget : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationProjectBudget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationProjectBudget(int transportationProjectBudgetID, int projectID, int fundingSourceID, int transportationProjectCostTypeID, int calendarYear, decimal budgetedAmount) : this()
        {
            this.TransportationProjectBudgetID = transportationProjectBudgetID;
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.TransportationProjectCostTypeID = transportationProjectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationProjectBudget(int projectID, int fundingSourceID, int transportationProjectCostTypeID, int calendarYear, decimal budgetedAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationProjectBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.TransportationProjectCostTypeID = transportationProjectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransportationProjectBudget(Project project, FundingSource fundingSource, TransportationProjectCostType transportationProjectCostType, int calendarYear, decimal budgetedAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransportationProjectBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.TransportationProjectBudgets.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.TransportationProjectBudgets.Add(this);
            this.TransportationProjectCostTypeID = transportationProjectCostType.TransportationProjectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationProjectBudget CreateNewBlank(Project project, FundingSource fundingSource, TransportationProjectCostType transportationProjectCostType)
        {
            return new TransportationProjectBudget(project, fundingSource, transportationProjectCostType, default(int), default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationProjectBudget).Name};

        [Key]
        public int TransportationProjectBudgetID { get; set; }
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public int TransportationProjectCostTypeID { get; set; }
        public int CalendarYear { get; set; }
        public decimal BudgetedAmount { get; set; }
        public int PrimaryKey { get { return TransportationProjectBudgetID; } set { TransportationProjectBudgetID = value; } }

        public virtual Project Project { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public TransportationProjectCostType TransportationProjectCostType { get { return TransportationProjectCostType.AllLookupDictionary[TransportationProjectCostTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}