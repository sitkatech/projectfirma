//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgencyTransactionTypeCommodityLog]
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
    [Table("[dbo].[LeadAgencyTransactionTypeCommodityLog]")]
    public partial class LeadAgencyTransactionTypeCommodityLog : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected LeadAgencyTransactionTypeCommodityLog()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgencyTransactionTypeCommodityLog(int leadAgencyTransactionTypeCommodityLogID, int leadAgencyID, int transactionTypeCommodityID, int leadAgencyTransactionTypeCommodityLogChangeTypeID, DateTime changeDate) : this()
        {
            this.LeadAgencyTransactionTypeCommodityLogID = leadAgencyTransactionTypeCommodityLogID;
            this.LeadAgencyID = leadAgencyID;
            this.TransactionTypeCommodityID = transactionTypeCommodityID;
            this.LeadAgencyTransactionTypeCommodityLogChangeTypeID = leadAgencyTransactionTypeCommodityLogChangeTypeID;
            this.ChangeDate = changeDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgencyTransactionTypeCommodityLog(int leadAgencyID, int transactionTypeCommodityID, int leadAgencyTransactionTypeCommodityLogChangeTypeID, DateTime changeDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            LeadAgencyTransactionTypeCommodityLogID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.LeadAgencyID = leadAgencyID;
            this.TransactionTypeCommodityID = transactionTypeCommodityID;
            this.LeadAgencyTransactionTypeCommodityLogChangeTypeID = leadAgencyTransactionTypeCommodityLogChangeTypeID;
            this.ChangeDate = changeDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public LeadAgencyTransactionTypeCommodityLog(LeadAgency leadAgency, TransactionTypeCommodity transactionTypeCommodity, LeadAgencyTransactionTypeCommodityLogChangeType leadAgencyTransactionTypeCommodityLogChangeType, DateTime changeDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.LeadAgencyTransactionTypeCommodityLogID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.LeadAgencyID = leadAgency.LeadAgencyID;
            this.LeadAgency = leadAgency;
            leadAgency.LeadAgencyTransactionTypeCommodityLogs.Add(this);
            this.TransactionTypeCommodityID = transactionTypeCommodity.TransactionTypeCommodityID;
            this.TransactionTypeCommodity = transactionTypeCommodity;
            transactionTypeCommodity.LeadAgencyTransactionTypeCommodityLogs.Add(this);
            this.LeadAgencyTransactionTypeCommodityLogChangeTypeID = leadAgencyTransactionTypeCommodityLogChangeType.LeadAgencyTransactionTypeCommodityLogChangeTypeID;
            this.ChangeDate = changeDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static LeadAgencyTransactionTypeCommodityLog CreateNewBlank(LeadAgency leadAgency, TransactionTypeCommodity transactionTypeCommodity, LeadAgencyTransactionTypeCommodityLogChangeType leadAgencyTransactionTypeCommodityLogChangeType)
        {
            return new LeadAgencyTransactionTypeCommodityLog(leadAgency, transactionTypeCommodity, leadAgencyTransactionTypeCommodityLogChangeType, default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(LeadAgencyTransactionTypeCommodityLog).Name};

        [Key]
        public int LeadAgencyTransactionTypeCommodityLogID { get; set; }
        public int LeadAgencyID { get; set; }
        public int TransactionTypeCommodityID { get; set; }
        public int LeadAgencyTransactionTypeCommodityLogChangeTypeID { get; set; }
        public DateTime ChangeDate { get; set; }
        public int PrimaryKey { get { return LeadAgencyTransactionTypeCommodityLogID; } set { LeadAgencyTransactionTypeCommodityLogID = value; } }

        public virtual LeadAgency LeadAgency { get; set; }
        public virtual TransactionTypeCommodity TransactionTypeCommodity { get; set; }
        public LeadAgencyTransactionTypeCommodityLogChangeType LeadAgencyTransactionTypeCommodityLogChangeType { get { return LeadAgencyTransactionTypeCommodityLogChangeType.AllLookupDictionary[LeadAgencyTransactionTypeCommodityLogChangeTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}