//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionConversionWithTransfer]
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
    [Table("[dbo].[TdrTransactionConversionWithTransfer]")]
    public partial class TdrTransactionConversionWithTransfer : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionConversionWithTransfer()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionConversionWithTransfer(int tdrTransactionConversionWithTransferID, int tdrTransactionID, int sendingOwnershipID, int sendingParcelID, int? sendingLandBankID, int receivingOwnershipID, int receivingParcelID, short? sendingIPESScore, int? sendingBaileyRatingID, short? receivingIPESScore, int? receivingBaileyRatingID, int sendingQuantity, int receivingQuantity, int commodityConvertedToID, decimal? transferPrice, DateTime? transferApprovalDate) : this()
        {
            this.TdrTransactionConversionWithTransferID = tdrTransactionConversionWithTransferID;
            this.TdrTransactionID = tdrTransactionID;
            this.SendingOwnershipID = sendingOwnershipID;
            this.SendingParcelID = sendingParcelID;
            this.SendingLandBankID = sendingLandBankID;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.SendingIPESScore = sendingIPESScore;
            this.SendingBaileyRatingID = sendingBaileyRatingID;
            this.ReceivingIPESScore = receivingIPESScore;
            this.ReceivingBaileyRatingID = receivingBaileyRatingID;
            this.SendingQuantity = sendingQuantity;
            this.ReceivingQuantity = receivingQuantity;
            this.CommodityConvertedToID = commodityConvertedToID;
            this.TransferPrice = transferPrice;
            this.TransferApprovalDate = transferApprovalDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionConversionWithTransfer(int tdrTransactionID, int sendingOwnershipID, int sendingParcelID, int receivingOwnershipID, int receivingParcelID, int sendingQuantity, int receivingQuantity, int commodityConvertedToID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionConversionWithTransferID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.SendingOwnershipID = sendingOwnershipID;
            this.SendingParcelID = sendingParcelID;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.SendingQuantity = sendingQuantity;
            this.ReceivingQuantity = receivingQuantity;
            this.CommodityConvertedToID = commodityConvertedToID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionConversionWithTransfer(TdrTransaction tdrTransaction, Ownership sendingOwnership, Parcel sendingParcel, Ownership receivingOwnership, Parcel receivingParcel, int sendingQuantity, int receivingQuantity, Commodity commodityConvertedTo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionConversionWithTransferID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            this.SendingOwnershipID = sendingOwnership.OwnershipID;
            this.SendingParcelID = sendingParcel.ParcelID;
            this.SendingParcel = sendingParcel;
            sendingParcel.TdrTransactionConversionWithTransfersWhereYouAreTheSendingParcel.Add(this);
            this.ReceivingOwnershipID = receivingOwnership.OwnershipID;
            this.ReceivingParcelID = receivingParcel.ParcelID;
            this.ReceivingParcel = receivingParcel;
            receivingParcel.TdrTransactionConversionWithTransfersWhereYouAreTheReceivingParcel.Add(this);
            this.SendingQuantity = sendingQuantity;
            this.ReceivingQuantity = receivingQuantity;
            this.CommodityConvertedToID = commodityConvertedTo.CommodityID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionConversionWithTransfer CreateNewBlank(TdrTransaction tdrTransaction, Ownership sendingOwnership, Parcel sendingParcel, Ownership receivingOwnership, Parcel receivingParcel, Commodity commodityConvertedTo)
        {
            return new TdrTransactionConversionWithTransfer(tdrTransaction, sendingOwnership, sendingParcel, receivingOwnership, receivingParcel, default(int), default(int), commodityConvertedTo);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionConversionWithTransfer).Name};

        [Key]
        public int TdrTransactionConversionWithTransferID { get; set; }
        public int TdrTransactionID { get; set; }
        public int SendingOwnershipID { get; set; }
        public int SendingParcelID { get; set; }
        public int? SendingLandBankID { get; set; }
        public int ReceivingOwnershipID { get; set; }
        public int ReceivingParcelID { get; set; }
        public short? SendingIPESScore { get; set; }
        public int? SendingBaileyRatingID { get; set; }
        public short? ReceivingIPESScore { get; set; }
        public int? ReceivingBaileyRatingID { get; set; }
        public int SendingQuantity { get; set; }
        public int ReceivingQuantity { get; set; }
        public int CommodityConvertedToID { get; set; }
        public decimal? TransferPrice { get; set; }
        public DateTime? TransferApprovalDate { get; set; }
        public int PrimaryKey { get { return TdrTransactionConversionWithTransferID; } set { TdrTransactionConversionWithTransferID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public Ownership ReceivingOwnership { get { return Ownership.AllLookupDictionary[ReceivingOwnershipID]; } }
        public Ownership SendingOwnership { get { return Ownership.AllLookupDictionary[SendingOwnershipID]; } }
        public virtual Parcel ReceivingParcel { get; set; }
        public virtual Parcel SendingParcel { get; set; }
        public virtual LandBank SendingLandBank { get; set; }
        public BaileyRating ReceivingBaileyRating { get { return ReceivingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[ReceivingBaileyRatingID.Value] : null; } }
        public BaileyRating SendingBaileyRating { get { return SendingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[SendingBaileyRatingID.Value] : null; } }
        public Commodity CommodityConvertedTo { get { return Commodity.AllLookupDictionary[CommodityConvertedToID]; } }

        public static class FieldLengths
        {

        }
    }
}