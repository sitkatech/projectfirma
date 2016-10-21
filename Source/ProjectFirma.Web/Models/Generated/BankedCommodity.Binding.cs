//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[BankedCommodity]
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
    [Table("[dbo].[BankedCommodity]")]
    public partial class BankedCommodity : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected BankedCommodity()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public BankedCommodity(int bankedCommodityID, int parcelID, int commodityBaileyRatingID, int bankedQuantity, DateTime bankedDate, string bankedCommodityNotes, string accelaCAPRecordID, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            this.BankedCommodityID = bankedCommodityID;
            this.ParcelID = parcelID;
            this.CommodityBaileyRatingID = commodityBaileyRatingID;
            this.BankedQuantity = bankedQuantity;
            this.BankedDate = bankedDate;
            this.BankedCommodityNotes = bankedCommodityNotes;
            this.AccelaCAPRecordID = accelaCAPRecordID;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public BankedCommodity(int parcelID, int commodityBaileyRatingID, int bankedQuantity, DateTime bankedDate, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            BankedCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ParcelID = parcelID;
            this.CommodityBaileyRatingID = commodityBaileyRatingID;
            this.BankedQuantity = bankedQuantity;
            this.BankedDate = bankedDate;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public BankedCommodity(Parcel parcel, CommodityBaileyRating commodityBaileyRating, int bankedQuantity, DateTime bankedDate, DateTime lastUpdateDate, Person lastUpdatePerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.BankedCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.BankedCommodities.Add(this);
            this.CommodityBaileyRatingID = commodityBaileyRating.CommodityBaileyRatingID;
            this.CommodityBaileyRating = commodityBaileyRating;
            commodityBaileyRating.BankedCommodities.Add(this);
            this.BankedQuantity = bankedQuantity;
            this.BankedDate = bankedDate;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePerson.PersonID;
            this.LastUpdatePerson = lastUpdatePerson;
            lastUpdatePerson.BankedCommoditiesWhereYouAreTheLastUpdatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static BankedCommodity CreateNewBlank(Parcel parcel, CommodityBaileyRating commodityBaileyRating, Person lastUpdatePerson)
        {
            return new BankedCommodity(parcel, commodityBaileyRating, default(int), default(DateTime), default(DateTime), lastUpdatePerson);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(BankedCommodity).Name};

        [Key]
        public int BankedCommodityID { get; set; }
        public int ParcelID { get; set; }
        public int CommodityBaileyRatingID { get; set; }
        public int BankedQuantity { get; set; }
        public DateTime BankedDate { get; set; }
        public string BankedCommodityNotes { get; set; }
        public string AccelaCAPRecordID { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatePersonID { get; set; }
        public int PrimaryKey { get { return BankedCommodityID; } set { BankedCommodityID = value; } }

        public virtual Parcel Parcel { get; set; }
        public virtual CommodityBaileyRating CommodityBaileyRating { get; set; }
        public virtual Person LastUpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int BankedCommodityNotes = 500;
            public const int AccelaCAPRecordID = 100;
        }
    }
}