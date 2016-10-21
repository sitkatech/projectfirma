//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransactionTypeCommodity]
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
    [Table("[dbo].[TransactionTypeCommodity]")]
    public partial class TransactionTypeCommodity : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransactionTypeCommodity()
        {
            this.LeadAgencyTransactionTypeCommodities = new HashSet<LeadAgencyTransactionTypeCommodity>();
            this.LeadAgencyTransactionTypeCommodityLogs = new HashSet<LeadAgencyTransactionTypeCommodityLog>();
            this.TdrTransactions = new HashSet<TdrTransaction>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransactionTypeCommodity(int transactionTypeCommodityID, int transactionTypeID, int commodityID) : this()
        {
            this.TransactionTypeCommodityID = transactionTypeCommodityID;
            this.TransactionTypeID = transactionTypeID;
            this.CommodityID = commodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransactionTypeCommodity(int transactionTypeID, int commodityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransactionTypeCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransactionTypeID = transactionTypeID;
            this.CommodityID = commodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransactionTypeCommodity(TransactionType transactionType, Commodity commodity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransactionTypeCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TransactionTypeID = transactionType.TransactionTypeID;
            this.CommodityID = commodity.CommodityID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransactionTypeCommodity CreateNewBlank(TransactionType transactionType, Commodity commodity)
        {
            return new TransactionTypeCommodity(transactionType, commodity);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return LeadAgencyTransactionTypeCommodities.Any() || LeadAgencyTransactionTypeCommodityLogs.Any() || TdrTransactions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransactionTypeCommodity).Name, typeof(LeadAgencyTransactionTypeCommodity).Name, typeof(LeadAgencyTransactionTypeCommodityLog).Name, typeof(TdrTransaction).Name};

        [Key]
        public int TransactionTypeCommodityID { get; set; }
        public int TransactionTypeID { get; set; }
        public int CommodityID { get; set; }
        public int PrimaryKey { get { return TransactionTypeCommodityID; } set { TransactionTypeCommodityID = value; } }

        public virtual ICollection<LeadAgencyTransactionTypeCommodity> LeadAgencyTransactionTypeCommodities { get; set; }
        public virtual ICollection<LeadAgencyTransactionTypeCommodityLog> LeadAgencyTransactionTypeCommodityLogs { get; set; }
        public virtual ICollection<TdrTransaction> TdrTransactions { get; set; }
        public TransactionType TransactionType { get { return TransactionType.AllLookupDictionary[TransactionTypeID]; } }
        public Commodity Commodity { get { return Commodity.AllLookupDictionary[CommodityID]; } }

        public static class FieldLengths
        {

        }
    }
}