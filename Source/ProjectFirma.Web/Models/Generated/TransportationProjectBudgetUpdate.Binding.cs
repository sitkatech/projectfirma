//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationProjectBudgetUpdate]
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
    [Table("[dbo].[TransportationProjectBudgetUpdate]")]
    public partial class TransportationProjectBudgetUpdate : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationProjectBudgetUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationProjectBudgetUpdate(int transportationProjectBudgetUpdateID, int projectUpdateBatchID, int fundingSourceID, int transportationProjectCostTypeID, int calendarYear, decimal? budgetedAmount) : this()
        {
            this.TransportationProjectBudgetUpdateID = transportationProjectBudgetUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.TransportationProjectCostTypeID = transportationProjectCostTypeID;
            this.CalendarYear = calendarYear;
            this.BudgetedAmount = budgetedAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationProjectBudgetUpdate(int projectUpdateBatchID, int fundingSourceID, int transportationProjectCostTypeID, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationProjectBudgetUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.TransportationProjectCostTypeID = transportationProjectCostTypeID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransportationProjectBudgetUpdate(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, TransportationProjectCostType transportationProjectCostType, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransportationProjectBudgetUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.TransportationProjectBudgetUpdates.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.TransportationProjectBudgetUpdates.Add(this);
            this.TransportationProjectCostTypeID = transportationProjectCostType.TransportationProjectCostTypeID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationProjectBudgetUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, TransportationProjectCostType transportationProjectCostType)
        {
            return new TransportationProjectBudgetUpdate(projectUpdateBatch, fundingSource, transportationProjectCostType, default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationProjectBudgetUpdate).Name};

        [Key]
        public int TransportationProjectBudgetUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FundingSourceID { get; set; }
        public int TransportationProjectCostTypeID { get; set; }
        public int CalendarYear { get; set; }
        public decimal? BudgetedAmount { get; set; }
        public int PrimaryKey { get { return TransportationProjectBudgetUpdateID; } set { TransportationProjectBudgetUpdateID = value; } }

        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public TransportationProjectCostType TransportationProjectCostType { get { return TransportationProjectCostType.AllLookupDictionary[TransportationProjectCostTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}