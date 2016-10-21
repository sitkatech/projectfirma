//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgencyTransactionTypeCommodity]
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
    [Table("[dbo].[LeadAgencyTransactionTypeCommodity]")]
    public partial class LeadAgencyTransactionTypeCommodity : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected LeadAgencyTransactionTypeCommodity()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgencyTransactionTypeCommodity(int leadAgencyTransactionTypeCommodityID, int leadAgencyID, int transactionTypeCommodityID) : this()
        {
            this.LeadAgencyTransactionTypeCommodityID = leadAgencyTransactionTypeCommodityID;
            this.LeadAgencyID = leadAgencyID;
            this.TransactionTypeCommodityID = transactionTypeCommodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgencyTransactionTypeCommodity(int leadAgencyID, int transactionTypeCommodityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            LeadAgencyTransactionTypeCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.LeadAgencyID = leadAgencyID;
            this.TransactionTypeCommodityID = transactionTypeCommodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public LeadAgencyTransactionTypeCommodity(LeadAgency leadAgency, TransactionTypeCommodity transactionTypeCommodity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.LeadAgencyTransactionTypeCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.LeadAgencyID = leadAgency.LeadAgencyID;
            this.LeadAgency = leadAgency;
            leadAgency.LeadAgencyTransactionTypeCommodities.Add(this);
            this.TransactionTypeCommodityID = transactionTypeCommodity.TransactionTypeCommodityID;
            this.TransactionTypeCommodity = transactionTypeCommodity;
            transactionTypeCommodity.LeadAgencyTransactionTypeCommodities.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static LeadAgencyTransactionTypeCommodity CreateNewBlank(LeadAgency leadAgency, TransactionTypeCommodity transactionTypeCommodity)
        {
            return new LeadAgencyTransactionTypeCommodity(leadAgency, transactionTypeCommodity);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(LeadAgencyTransactionTypeCommodity).Name};

        [Key]
        public int LeadAgencyTransactionTypeCommodityID { get; set; }
        public int LeadAgencyID { get; set; }
        public int TransactionTypeCommodityID { get; set; }
        public int PrimaryKey { get { return LeadAgencyTransactionTypeCommodityID; } set { LeadAgencyTransactionTypeCommodityID = value; } }

        public virtual LeadAgency LeadAgency { get; set; }
        public virtual TransactionTypeCommodity TransactionTypeCommodity { get; set; }

        public static class FieldLengths
        {

        }
    }
}