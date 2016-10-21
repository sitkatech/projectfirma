//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionLandBankAcquisition]
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
    [Table("[dbo].[TdrTransactionLandBankAcquisition]")]
    public partial class TdrTransactionLandBankAcquisition : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionLandBankAcquisition()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionLandBankAcquisition(int tdrTransactionLandBankAcquisitionID, int tdrTransactionID, int sendingParcelID, int sendingQuantity, short? sendingIPESScore, int? sendingBaileyRatingID, int landBankID, int? receivingCommodityConvertedToID, decimal transferPrice) : this()
        {
            this.TdrTransactionLandBankAcquisitionID = tdrTransactionLandBankAcquisitionID;
            this.TdrTransactionID = tdrTransactionID;
            this.SendingParcelID = sendingParcelID;
            this.SendingQuantity = sendingQuantity;
            this.SendingIPESScore = sendingIPESScore;
            this.SendingBaileyRatingID = sendingBaileyRatingID;
            this.LandBankID = landBankID;
            this.ReceivingCommodityConvertedToID = receivingCommodityConvertedToID;
            this.TransferPrice = transferPrice;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionLandBankAcquisition(int tdrTransactionID, int sendingParcelID, int sendingQuantity, int landBankID, decimal transferPrice) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionLandBankAcquisitionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.SendingParcelID = sendingParcelID;
            this.SendingQuantity = sendingQuantity;
            this.LandBankID = landBankID;
            this.TransferPrice = transferPrice;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionLandBankAcquisition(TdrTransaction tdrTransaction, Parcel sendingParcel, int sendingQuantity, LandBank landBank, decimal transferPrice) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionLandBankAcquisitionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            this.SendingParcelID = sendingParcel.ParcelID;
            this.SendingParcel = sendingParcel;
            sendingParcel.TdrTransactionLandBankAcquisitionsWhereYouAreTheSendingParcel.Add(this);
            this.SendingQuantity = sendingQuantity;
            this.LandBankID = landBank.LandBankID;
            this.LandBank = landBank;
            landBank.TdrTransactionLandBankAcquisitions.Add(this);
            this.TransferPrice = transferPrice;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionLandBankAcquisition CreateNewBlank(TdrTransaction tdrTransaction, Parcel sendingParcel, LandBank landBank)
        {
            return new TdrTransactionLandBankAcquisition(tdrTransaction, sendingParcel, default(int), landBank, default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionLandBankAcquisition).Name};

        [Key]
        public int TdrTransactionLandBankAcquisitionID { get; set; }
        public int TdrTransactionID { get; set; }
        public int SendingParcelID { get; set; }
        public int SendingQuantity { get; set; }
        public short? SendingIPESScore { get; set; }
        public int? SendingBaileyRatingID { get; set; }
        public int LandBankID { get; set; }
        public int? ReceivingCommodityConvertedToID { get; set; }
        public decimal TransferPrice { get; set; }
        public int PrimaryKey { get { return TdrTransactionLandBankAcquisitionID; } set { TdrTransactionLandBankAcquisitionID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public virtual Parcel SendingParcel { get; set; }
        public BaileyRating SendingBaileyRating { get { return SendingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[SendingBaileyRatingID.Value] : null; } }
        public virtual LandBank LandBank { get; set; }
        public Commodity ReceivingCommodityConvertedTo { get { return ReceivingCommodityConvertedToID.HasValue ? Commodity.AllLookupDictionary[ReceivingCommodityConvertedToID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}