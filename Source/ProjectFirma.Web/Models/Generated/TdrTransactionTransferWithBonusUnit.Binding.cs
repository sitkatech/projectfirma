//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionTransferWithBonusUnit]
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
    [Table("[dbo].[TdrTransactionTransferWithBonusUnit]")]
    public partial class TdrTransactionTransferWithBonusUnit : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionTransferWithBonusUnit()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionTransferWithBonusUnit(int tdrTransactionTransferWithBonusUnitID, int tdrTransactionID, int? sendingLandBankID, int sendingParcelID, int sendingBonusPoolID, int sendingQuantity, short? sendingIPESScore, int? sendingBaileyRatingID, int receivingOwnershipID, int receivingParcelID, int receivingQuantity, short? receivingIPESScore, int? receivingBaileyRatingID, byte bonusUnits, decimal? transferPrice) : this()
        {
            this.TdrTransactionTransferWithBonusUnitID = tdrTransactionTransferWithBonusUnitID;
            this.TdrTransactionID = tdrTransactionID;
            this.SendingLandBankID = sendingLandBankID;
            this.SendingParcelID = sendingParcelID;
            this.SendingBonusPoolID = sendingBonusPoolID;
            this.SendingQuantity = sendingQuantity;
            this.SendingIPESScore = sendingIPESScore;
            this.SendingBaileyRatingID = sendingBaileyRatingID;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.ReceivingQuantity = receivingQuantity;
            this.ReceivingIPESScore = receivingIPESScore;
            this.ReceivingBaileyRatingID = receivingBaileyRatingID;
            this.BonusUnits = bonusUnits;
            this.TransferPrice = transferPrice;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionTransferWithBonusUnit(int tdrTransactionID, int sendingParcelID, int sendingBonusPoolID, int sendingQuantity, int receivingOwnershipID, int receivingParcelID, int receivingQuantity, byte bonusUnits) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionTransferWithBonusUnitID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.SendingParcelID = sendingParcelID;
            this.SendingBonusPoolID = sendingBonusPoolID;
            this.SendingQuantity = sendingQuantity;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.ReceivingQuantity = receivingQuantity;
            this.BonusUnits = bonusUnits;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionTransferWithBonusUnit(TdrTransaction tdrTransaction, Parcel sendingParcel, CommodityPool sendingBonusPool, int sendingQuantity, Ownership receivingOwnership, Parcel receivingParcel, int receivingQuantity, byte bonusUnits) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionTransferWithBonusUnitID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            this.SendingParcelID = sendingParcel.ParcelID;
            this.SendingParcel = sendingParcel;
            sendingParcel.TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingParcel.Add(this);
            this.SendingBonusPoolID = sendingBonusPool.CommodityPoolID;
            this.SendingBonusPool = sendingBonusPool;
            sendingBonusPool.TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingBonusPool.Add(this);
            this.SendingQuantity = sendingQuantity;
            this.ReceivingOwnershipID = receivingOwnership.OwnershipID;
            this.ReceivingParcelID = receivingParcel.ParcelID;
            this.ReceivingParcel = receivingParcel;
            receivingParcel.TdrTransactionTransferWithBonusUnitsWhereYouAreTheReceivingParcel.Add(this);
            this.ReceivingQuantity = receivingQuantity;
            this.BonusUnits = bonusUnits;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionTransferWithBonusUnit CreateNewBlank(TdrTransaction tdrTransaction, Parcel sendingParcel, CommodityPool sendingBonusPool, Ownership receivingOwnership, Parcel receivingParcel)
        {
            return new TdrTransactionTransferWithBonusUnit(tdrTransaction, sendingParcel, sendingBonusPool, default(int), receivingOwnership, receivingParcel, default(int), default(byte));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionTransferWithBonusUnit).Name};

        [Key]
        public int TdrTransactionTransferWithBonusUnitID { get; set; }
        public int TdrTransactionID { get; set; }
        public int? SendingLandBankID { get; set; }
        public int SendingParcelID { get; set; }
        public int SendingBonusPoolID { get; set; }
        public int SendingQuantity { get; set; }
        public short? SendingIPESScore { get; set; }
        public int? SendingBaileyRatingID { get; set; }
        public int ReceivingOwnershipID { get; set; }
        public int ReceivingParcelID { get; set; }
        public int ReceivingQuantity { get; set; }
        public short? ReceivingIPESScore { get; set; }
        public int? ReceivingBaileyRatingID { get; set; }
        public byte BonusUnits { get; set; }
        public decimal? TransferPrice { get; set; }
        public int PrimaryKey { get { return TdrTransactionTransferWithBonusUnitID; } set { TdrTransactionTransferWithBonusUnitID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public virtual LandBank SendingLandBank { get; set; }
        public virtual Parcel ReceivingParcel { get; set; }
        public virtual Parcel SendingParcel { get; set; }
        public virtual CommodityPool SendingBonusPool { get; set; }
        public BaileyRating ReceivingBaileyRating { get { return ReceivingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[ReceivingBaileyRatingID.Value] : null; } }
        public BaileyRating SendingBaileyRating { get { return SendingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[SendingBaileyRatingID.Value] : null; } }
        public Ownership ReceivingOwnership { get { return Ownership.AllLookupDictionary[ReceivingOwnershipID]; } }

        public static class FieldLengths
        {

        }
    }
}