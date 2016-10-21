//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionConversion]
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
    [Table("[dbo].[TdrTransactionConversion]")]
    public partial class TdrTransactionConversion : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionConversion()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionConversion(int tdrTransactionConversionID, int tdrTransactionID, int? landBankID, int parcelID, int ownershipID, int commodityConvertedToID, short? iPESScore, int? baileyRatingID, int sendingQuantity, int receivingQuantity) : this()
        {
            this.TdrTransactionConversionID = tdrTransactionConversionID;
            this.TdrTransactionID = tdrTransactionID;
            this.LandBankID = landBankID;
            this.ParcelID = parcelID;
            this.OwnershipID = ownershipID;
            this.CommodityConvertedToID = commodityConvertedToID;
            this.IPESScore = iPESScore;
            this.BaileyRatingID = baileyRatingID;
            this.SendingQuantity = sendingQuantity;
            this.ReceivingQuantity = receivingQuantity;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionConversion(int tdrTransactionID, int parcelID, int ownershipID, int commodityConvertedToID, int sendingQuantity, int receivingQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionConversionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.ParcelID = parcelID;
            this.OwnershipID = ownershipID;
            this.CommodityConvertedToID = commodityConvertedToID;
            this.SendingQuantity = sendingQuantity;
            this.ReceivingQuantity = receivingQuantity;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionConversion(TdrTransaction tdrTransaction, Parcel parcel, Ownership ownership, Commodity commodityConvertedTo, int sendingQuantity, int receivingQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionConversionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.TdrTransactionConversions.Add(this);
            this.OwnershipID = ownership.OwnershipID;
            this.CommodityConvertedToID = commodityConvertedTo.CommodityID;
            this.SendingQuantity = sendingQuantity;
            this.ReceivingQuantity = receivingQuantity;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionConversion CreateNewBlank(TdrTransaction tdrTransaction, Parcel parcel, Ownership ownership, Commodity commodityConvertedTo)
        {
            return new TdrTransactionConversion(tdrTransaction, parcel, ownership, commodityConvertedTo, default(int), default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionConversion).Name};

        [Key]
        public int TdrTransactionConversionID { get; set; }
        public int TdrTransactionID { get; set; }
        public int? LandBankID { get; set; }
        public int ParcelID { get; set; }
        public int OwnershipID { get; set; }
        public int CommodityConvertedToID { get; set; }
        public short? IPESScore { get; set; }
        public int? BaileyRatingID { get; set; }
        public int SendingQuantity { get; set; }
        public int ReceivingQuantity { get; set; }
        public int PrimaryKey { get { return TdrTransactionConversionID; } set { TdrTransactionConversionID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public virtual LandBank LandBank { get; set; }
        public virtual Parcel Parcel { get; set; }
        public Ownership Ownership { get { return Ownership.AllLookupDictionary[OwnershipID]; } }
        public Commodity CommodityConvertedTo { get { return Commodity.AllLookupDictionary[CommodityConvertedToID]; } }
        public BaileyRating BaileyRating { get { return BaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[BaileyRatingID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}