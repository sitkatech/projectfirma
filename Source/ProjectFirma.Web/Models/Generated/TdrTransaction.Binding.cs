//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransaction]
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
    [Table("[dbo].[TdrTransaction]")]
    public partial class TdrTransaction : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransaction()
        {
            this.ResidentialAllocations = new HashSet<ResidentialAllocation>();
            this.ResidentialAllocationsWhereYouAreTheWithdrawnTdrTransaction = new HashSet<ResidentialAllocation>();
            this.TdrTransactionAllocations = new HashSet<TdrTransactionAllocation>();
            this.TdrTransactionAllocationAssignments = new HashSet<TdrTransactionAllocationAssignment>();
            this.TdrTransactionConversions = new HashSet<TdrTransactionConversion>();
            this.TdrTransactionConversionWithTransfers = new HashSet<TdrTransactionConversionWithTransfer>();
            this.TdrTransactionECMRetirements = new HashSet<TdrTransactionECMRetirement>();
            this.TdrTransactionLandBankAcquisitions = new HashSet<TdrTransactionLandBankAcquisition>();
            this.TdrTransactionStateHistories = new HashSet<TdrTransactionStateHistory>();
            this.TdrTransactionTransfers = new HashSet<TdrTransactionTransfer>();
            this.TdrTransactionTransferWithBonusUnits = new HashSet<TdrTransactionTransferWithBonusUnit>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransaction(int tdrTransactionID, int leadAgencyID, string leadAgencyAbbreviation, int transactionTypeCommodityID, int transactionTypeID, string transactionTypeAbbreviation, int commodityID, string deallocatedRationale, DateTime lastUpdateDate, int lastUpdatePersonID, string projectNumber, string comments, int transactionStateID, int? accelaCAPRecordID, DateTime? approvalDate) : this()
        {
            this.TdrTransactionID = tdrTransactionID;
            this.LeadAgencyID = leadAgencyID;
            this.LeadAgencyAbbreviation = leadAgencyAbbreviation;
            this.TransactionTypeCommodityID = transactionTypeCommodityID;
            this.TransactionTypeID = transactionTypeID;
            this.TransactionTypeAbbreviation = transactionTypeAbbreviation;
            this.CommodityID = commodityID;
            this.DeallocatedRationale = deallocatedRationale;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.ProjectNumber = projectNumber;
            this.Comments = comments;
            this.TransactionStateID = transactionStateID;
            this.AccelaCAPRecordID = accelaCAPRecordID;
            this.ApprovalDate = approvalDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransaction(int leadAgencyID, string leadAgencyAbbreviation, int transactionTypeCommodityID, int transactionTypeID, string transactionTypeAbbreviation, int commodityID, DateTime lastUpdateDate, int lastUpdatePersonID, int transactionStateID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.LeadAgencyID = leadAgencyID;
            this.LeadAgencyAbbreviation = leadAgencyAbbreviation;
            this.TransactionTypeCommodityID = transactionTypeCommodityID;
            this.TransactionTypeID = transactionTypeID;
            this.TransactionTypeAbbreviation = transactionTypeAbbreviation;
            this.CommodityID = commodityID;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.TransactionStateID = transactionStateID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransaction(LeadAgency leadAgency, string leadAgencyAbbreviation, TransactionTypeCommodity transactionTypeCommodity, TransactionType transactionType, string transactionTypeAbbreviation, Commodity commodity, DateTime lastUpdateDate, Person lastUpdatePerson, TransactionState transactionState) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.LeadAgencyID = leadAgency.LeadAgencyID;
            this.LeadAgency = leadAgency;
            leadAgency.TdrTransactions.Add(this);
            this.LeadAgencyAbbreviation = leadAgencyAbbreviation;
            this.TransactionTypeCommodityID = transactionTypeCommodity.TransactionTypeCommodityID;
            this.TransactionTypeCommodity = transactionTypeCommodity;
            transactionTypeCommodity.TdrTransactions.Add(this);
            this.TransactionTypeID = transactionType.TransactionTypeID;
            this.TransactionTypeAbbreviation = transactionTypeAbbreviation;
            this.CommodityID = commodity.CommodityID;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePerson.PersonID;
            this.LastUpdatePerson = lastUpdatePerson;
            lastUpdatePerson.TdrTransactionsWhereYouAreTheLastUpdatePerson.Add(this);
            this.TransactionStateID = transactionState.TransactionStateID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransaction CreateNewBlank(LeadAgency leadAgency, TransactionTypeCommodity transactionTypeCommodity, TransactionType transactionType, Commodity commodity, Person lastUpdatePerson, TransactionState transactionState)
        {
            return new TdrTransaction(leadAgency, default(string), transactionTypeCommodity, transactionType, default(string), commodity, default(DateTime), lastUpdatePerson, transactionState);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return (ResidentialAllocation != null) || (ResidentialAllocationWhereYouAreTheWithdrawnTdrTransaction != null) || (TdrTransactionAllocation != null) || (TdrTransactionAllocationAssignment != null) || (TdrTransactionConversion != null) || (TdrTransactionConversionWithTransfer != null) || (TdrTransactionECMRetirement != null) || (TdrTransactionLandBankAcquisition != null) || TdrTransactionStateHistories.Any() || (TdrTransactionTransfer != null) || (TdrTransactionTransferWithBonusUnit != null);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransaction).Name, typeof(ResidentialAllocation).Name, typeof(TdrTransactionAllocation).Name, typeof(TdrTransactionAllocationAssignment).Name, typeof(TdrTransactionConversion).Name, typeof(TdrTransactionConversionWithTransfer).Name, typeof(TdrTransactionECMRetirement).Name, typeof(TdrTransactionLandBankAcquisition).Name, typeof(TdrTransactionStateHistory).Name, typeof(TdrTransactionTransfer).Name, typeof(TdrTransactionTransferWithBonusUnit).Name};

        [Key]
        public int TdrTransactionID { get; set; }
        public int LeadAgencyID { get; set; }
        public string LeadAgencyAbbreviation { get; set; }
        public int TransactionTypeCommodityID { get; set; }
        public int TransactionTypeID { get; set; }
        public string TransactionTypeAbbreviation { get; set; }
        public int CommodityID { get; set; }
        public string DeallocatedRationale { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatePersonID { get; set; }
        public string ProjectNumber { get; set; }
        public string Comments { get; set; }
        public int TransactionStateID { get; set; }
        public int? AccelaCAPRecordID { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int PrimaryKey { get { return TdrTransactionID; } set { TdrTransactionID = value; } }

        protected virtual ICollection<ResidentialAllocation> ResidentialAllocations { get; set; }
        public ResidentialAllocation ResidentialAllocation { get { return ResidentialAllocations.SingleOrDefault(); } set { ResidentialAllocations = new List<ResidentialAllocation>{value};} }
        protected virtual ICollection<ResidentialAllocation> ResidentialAllocationsWhereYouAreTheWithdrawnTdrTransaction { get; set; }
        public ResidentialAllocation ResidentialAllocationWhereYouAreTheWithdrawnTdrTransaction { get { return ResidentialAllocationsWhereYouAreTheWithdrawnTdrTransaction.SingleOrDefault(); } set { ResidentialAllocationsWhereYouAreTheWithdrawnTdrTransaction = new List<ResidentialAllocation>{value};} }
        protected virtual ICollection<TdrTransactionAllocation> TdrTransactionAllocations { get; set; }
        public TdrTransactionAllocation TdrTransactionAllocation { get { return TdrTransactionAllocations.SingleOrDefault(); } set { TdrTransactionAllocations = new List<TdrTransactionAllocation>{value};} }
        protected virtual ICollection<TdrTransactionAllocationAssignment> TdrTransactionAllocationAssignments { get; set; }
        public TdrTransactionAllocationAssignment TdrTransactionAllocationAssignment { get { return TdrTransactionAllocationAssignments.SingleOrDefault(); } set { TdrTransactionAllocationAssignments = new List<TdrTransactionAllocationAssignment>{value};} }
        protected virtual ICollection<TdrTransactionConversion> TdrTransactionConversions { get; set; }
        public TdrTransactionConversion TdrTransactionConversion { get { return TdrTransactionConversions.SingleOrDefault(); } set { TdrTransactionConversions = new List<TdrTransactionConversion>{value};} }
        protected virtual ICollection<TdrTransactionConversionWithTransfer> TdrTransactionConversionWithTransfers { get; set; }
        public TdrTransactionConversionWithTransfer TdrTransactionConversionWithTransfer { get { return TdrTransactionConversionWithTransfers.SingleOrDefault(); } set { TdrTransactionConversionWithTransfers = new List<TdrTransactionConversionWithTransfer>{value};} }
        protected virtual ICollection<TdrTransactionECMRetirement> TdrTransactionECMRetirements { get; set; }
        public TdrTransactionECMRetirement TdrTransactionECMRetirement { get { return TdrTransactionECMRetirements.SingleOrDefault(); } set { TdrTransactionECMRetirements = new List<TdrTransactionECMRetirement>{value};} }
        protected virtual ICollection<TdrTransactionLandBankAcquisition> TdrTransactionLandBankAcquisitions { get; set; }
        public TdrTransactionLandBankAcquisition TdrTransactionLandBankAcquisition { get { return TdrTransactionLandBankAcquisitions.SingleOrDefault(); } set { TdrTransactionLandBankAcquisitions = new List<TdrTransactionLandBankAcquisition>{value};} }
        public virtual ICollection<TdrTransactionStateHistory> TdrTransactionStateHistories { get; set; }
        protected virtual ICollection<TdrTransactionTransfer> TdrTransactionTransfers { get; set; }
        public TdrTransactionTransfer TdrTransactionTransfer { get { return TdrTransactionTransfers.SingleOrDefault(); } set { TdrTransactionTransfers = new List<TdrTransactionTransfer>{value};} }
        protected virtual ICollection<TdrTransactionTransferWithBonusUnit> TdrTransactionTransferWithBonusUnits { get; set; }
        public TdrTransactionTransferWithBonusUnit TdrTransactionTransferWithBonusUnit { get { return TdrTransactionTransferWithBonusUnits.SingleOrDefault(); } set { TdrTransactionTransferWithBonusUnits = new List<TdrTransactionTransferWithBonusUnit>{value};} }
        public virtual LeadAgency LeadAgency { get; set; }
        public virtual TransactionTypeCommodity TransactionTypeCommodity { get; set; }
        public TransactionType TransactionType { get { return TransactionType.AllLookupDictionary[TransactionTypeID]; } }
        public Commodity Commodity { get { return Commodity.AllLookupDictionary[CommodityID]; } }
        public virtual Person LastUpdatePerson { get; set; }
        public TransactionState TransactionState { get { return TransactionState.AllLookupDictionary[TransactionStateID]; } }
        public virtual AccelaCAPRecord AccelaCAPRecord { get; set; }

        public static class FieldLengths
        {
            public const int LeadAgencyAbbreviation = 10;
            public const int TransactionTypeAbbreviation = 10;
            public const int DeallocatedRationale = 500;
            public const int ProjectNumber = 30;
        }
    }
}