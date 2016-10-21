//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vTdrTransactionCanBeCountedInInventory]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class vTdrTransactionCanBeCountedInInventory
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vTdrTransactionCanBeCountedInInventory()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vTdrTransactionCanBeCountedInInventory(int tdrTransactionID, int leadAgencyID, string leadAgencyAbbreviation, int transactionTypeID, string transactionTypeAbbreviation, int commodityID, int transactionStateID, DateTime lastUpdateDate) : this()
        {
            this.TdrTransactionID = tdrTransactionID;
            this.LeadAgencyID = leadAgencyID;
            this.LeadAgencyAbbreviation = leadAgencyAbbreviation;
            this.TransactionTypeID = transactionTypeID;
            this.TransactionTypeAbbreviation = transactionTypeAbbreviation;
            this.CommodityID = commodityID;
            this.TransactionStateID = transactionStateID;
            this.LastUpdateDate = lastUpdateDate;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vTdrTransactionCanBeCountedInInventory(vTdrTransactionCanBeCountedInInventory vTdrTransactionCanBeCountedInInventory) : this()
        {
            this.TdrTransactionID = vTdrTransactionCanBeCountedInInventory.TdrTransactionID;
            this.LeadAgencyID = vTdrTransactionCanBeCountedInInventory.LeadAgencyID;
            this.LeadAgencyAbbreviation = vTdrTransactionCanBeCountedInInventory.LeadAgencyAbbreviation;
            this.TransactionTypeID = vTdrTransactionCanBeCountedInInventory.TransactionTypeID;
            this.TransactionTypeAbbreviation = vTdrTransactionCanBeCountedInInventory.TransactionTypeAbbreviation;
            this.CommodityID = vTdrTransactionCanBeCountedInInventory.CommodityID;
            this.TransactionStateID = vTdrTransactionCanBeCountedInInventory.TransactionStateID;
            this.LastUpdateDate = vTdrTransactionCanBeCountedInInventory.LastUpdateDate;
            CallAfterConstructor(vTdrTransactionCanBeCountedInInventory);
        }

        partial void CallAfterConstructor(vTdrTransactionCanBeCountedInInventory vTdrTransactionCanBeCountedInInventory);

        public int TdrTransactionID { get; set; }
        public int LeadAgencyID { get; set; }
        public string LeadAgencyAbbreviation { get; set; }
        public int TransactionTypeID { get; set; }
        public string TransactionTypeAbbreviation { get; set; }
        public int CommodityID { get; set; }
        public int TransactionStateID { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}