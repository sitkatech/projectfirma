//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionECMRetirement]
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
    [Table("[dbo].[TdrTransactionECMRetirement]")]
    public partial class TdrTransactionECMRetirement : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionECMRetirement()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionECMRetirement(int tdrTransactionECMRetirementID, int tdrTransactionID, int landBankID, int sendingParcelID, int retirementQuantity, short? sendingIPESScore, int? sendingBaileyRatingID, decimal transferPrice) : this()
        {
            this.TdrTransactionECMRetirementID = tdrTransactionECMRetirementID;
            this.TdrTransactionID = tdrTransactionID;
            this.LandBankID = landBankID;
            this.SendingParcelID = sendingParcelID;
            this.RetirementQuantity = retirementQuantity;
            this.SendingIPESScore = sendingIPESScore;
            this.SendingBaileyRatingID = sendingBaileyRatingID;
            this.TransferPrice = transferPrice;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionECMRetirement(int tdrTransactionID, int landBankID, int sendingParcelID, int retirementQuantity, decimal transferPrice) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionECMRetirementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.LandBankID = landBankID;
            this.SendingParcelID = sendingParcelID;
            this.RetirementQuantity = retirementQuantity;
            this.TransferPrice = transferPrice;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionECMRetirement(TdrTransaction tdrTransaction, LandBank landBank, Parcel sendingParcel, int retirementQuantity, decimal transferPrice) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionECMRetirementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            this.LandBankID = landBank.LandBankID;
            this.LandBank = landBank;
            landBank.TdrTransactionECMRetirements.Add(this);
            this.SendingParcelID = sendingParcel.ParcelID;
            this.SendingParcel = sendingParcel;
            sendingParcel.TdrTransactionECMRetirementsWhereYouAreTheSendingParcel.Add(this);
            this.RetirementQuantity = retirementQuantity;
            this.TransferPrice = transferPrice;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionECMRetirement CreateNewBlank(TdrTransaction tdrTransaction, LandBank landBank, Parcel sendingParcel)
        {
            return new TdrTransactionECMRetirement(tdrTransaction, landBank, sendingParcel, default(int), default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionECMRetirement).Name};

        [Key]
        public int TdrTransactionECMRetirementID { get; set; }
        public int TdrTransactionID { get; set; }
        public int LandBankID { get; set; }
        public int SendingParcelID { get; set; }
        public int RetirementQuantity { get; set; }
        public short? SendingIPESScore { get; set; }
        public int? SendingBaileyRatingID { get; set; }
        public decimal TransferPrice { get; set; }
        public int PrimaryKey { get { return TdrTransactionECMRetirementID; } set { TdrTransactionECMRetirementID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public virtual LandBank LandBank { get; set; }
        public virtual Parcel SendingParcel { get; set; }
        public BaileyRating SendingBaileyRating { get { return SendingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[SendingBaileyRatingID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}