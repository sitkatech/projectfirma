//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionTransfer]
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
    [Table("[dbo].[TdrTransactionTransfer]")]
    public partial class TdrTransactionTransfer : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionTransfer()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionTransfer(int tdrTransactionTransferID, int tdrTransactionID, int? sendingLandBankID, int sendingParcelID, int sendingQuantity, short? sendingIPESScore, int? sendingBaileyRatingID, int receivingOwnershipID, int receivingParcelID, int receivingQuantity, short? receivingIPESScore, int? receivingBaileyRatingID, decimal? transferPrice, int? retiredQuantity) : this()
        {
            this.TdrTransactionTransferID = tdrTransactionTransferID;
            this.TdrTransactionID = tdrTransactionID;
            this.SendingLandBankID = sendingLandBankID;
            this.SendingParcelID = sendingParcelID;
            this.SendingQuantity = sendingQuantity;
            this.SendingIPESScore = sendingIPESScore;
            this.SendingBaileyRatingID = sendingBaileyRatingID;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.ReceivingQuantity = receivingQuantity;
            this.ReceivingIPESScore = receivingIPESScore;
            this.ReceivingBaileyRatingID = receivingBaileyRatingID;
            this.TransferPrice = transferPrice;
            this.RetiredQuantity = retiredQuantity;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionTransfer(int tdrTransactionID, int sendingParcelID, int sendingQuantity, int receivingOwnershipID, int receivingParcelID, int receivingQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionTransferID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.SendingParcelID = sendingParcelID;
            this.SendingQuantity = sendingQuantity;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.ReceivingQuantity = receivingQuantity;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionTransfer(TdrTransaction tdrTransaction, Parcel sendingParcel, int sendingQuantity, Ownership receivingOwnership, Parcel receivingParcel, int receivingQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionTransferID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            this.SendingParcelID = sendingParcel.ParcelID;
            this.SendingParcel = sendingParcel;
            sendingParcel.TdrTransactionTransfersWhereYouAreTheSendingParcel.Add(this);
            this.SendingQuantity = sendingQuantity;
            this.ReceivingOwnershipID = receivingOwnership.OwnershipID;
            this.ReceivingParcelID = receivingParcel.ParcelID;
            this.ReceivingParcel = receivingParcel;
            receivingParcel.TdrTransactionTransfersWhereYouAreTheReceivingParcel.Add(this);
            this.ReceivingQuantity = receivingQuantity;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionTransfer CreateNewBlank(TdrTransaction tdrTransaction, Parcel sendingParcel, Ownership receivingOwnership, Parcel receivingParcel)
        {
            return new TdrTransactionTransfer(tdrTransaction, sendingParcel, default(int), receivingOwnership, receivingParcel, default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionTransfer).Name};

        [Key]
        public int TdrTransactionTransferID { get; set; }
        public int TdrTransactionID { get; set; }
        public int? SendingLandBankID { get; set; }
        public int SendingParcelID { get; set; }
        public int SendingQuantity { get; set; }
        public short? SendingIPESScore { get; set; }
        public int? SendingBaileyRatingID { get; set; }
        public int ReceivingOwnershipID { get; set; }
        public int ReceivingParcelID { get; set; }
        public int ReceivingQuantity { get; set; }
        public short? ReceivingIPESScore { get; set; }
        public int? ReceivingBaileyRatingID { get; set; }
        public decimal? TransferPrice { get; set; }
        public int? RetiredQuantity { get; set; }
        public int PrimaryKey { get { return TdrTransactionTransferID; } set { TdrTransactionTransferID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public virtual LandBank SendingLandBank { get; set; }
        public virtual Parcel ReceivingParcel { get; set; }
        public virtual Parcel SendingParcel { get; set; }
        public BaileyRating ReceivingBaileyRating { get { return ReceivingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[ReceivingBaileyRatingID.Value] : null; } }
        public BaileyRating SendingBaileyRating { get { return SendingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[SendingBaileyRatingID.Value] : null; } }
        public Ownership ReceivingOwnership { get { return Ownership.AllLookupDictionary[ReceivingOwnershipID]; } }

        public static class FieldLengths
        {

        }
    }
}