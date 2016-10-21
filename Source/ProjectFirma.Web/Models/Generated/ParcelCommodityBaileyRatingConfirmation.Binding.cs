//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelCommodityBaileyRatingConfirmation]
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
    [Table("[dbo].[ParcelCommodityBaileyRatingConfirmation]")]
    public partial class ParcelCommodityBaileyRatingConfirmation : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelCommodityBaileyRatingConfirmation()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelCommodityBaileyRatingConfirmation(int parcelCommodityBaileyRatingConfirmationID, int parcelID, int commodityID, int? baileyRatingID, int parcelCommodityBaileyRatingConfirmationStatusID, int confirmedByPersonID, DateTime confirmationDate, string confirmationNotes) : this()
        {
            this.ParcelCommodityBaileyRatingConfirmationID = parcelCommodityBaileyRatingConfirmationID;
            this.ParcelID = parcelID;
            this.CommodityID = commodityID;
            this.BaileyRatingID = baileyRatingID;
            this.ParcelCommodityBaileyRatingConfirmationStatusID = parcelCommodityBaileyRatingConfirmationStatusID;
            this.ConfirmedByPersonID = confirmedByPersonID;
            this.ConfirmationDate = confirmationDate;
            this.ConfirmationNotes = confirmationNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelCommodityBaileyRatingConfirmation(int parcelID, int commodityID, int parcelCommodityBaileyRatingConfirmationStatusID, int confirmedByPersonID, DateTime confirmationDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelCommodityBaileyRatingConfirmationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ParcelID = parcelID;
            this.CommodityID = commodityID;
            this.ParcelCommodityBaileyRatingConfirmationStatusID = parcelCommodityBaileyRatingConfirmationStatusID;
            this.ConfirmedByPersonID = confirmedByPersonID;
            this.ConfirmationDate = confirmationDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ParcelCommodityBaileyRatingConfirmation(Parcel parcel, Commodity commodity, ParcelCommodityBaileyRatingConfirmationStatus parcelCommodityBaileyRatingConfirmationStatus, Person confirmedByPerson, DateTime confirmationDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelCommodityBaileyRatingConfirmationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.ParcelCommodityBaileyRatingConfirmations.Add(this);
            this.CommodityID = commodity.CommodityID;
            this.ParcelCommodityBaileyRatingConfirmationStatusID = parcelCommodityBaileyRatingConfirmationStatus.ParcelCommodityBaileyRatingConfirmationStatusID;
            this.ConfirmedByPersonID = confirmedByPerson.PersonID;
            this.ConfirmedByPerson = confirmedByPerson;
            confirmedByPerson.ParcelCommodityBaileyRatingConfirmationsWhereYouAreTheConfirmedByPerson.Add(this);
            this.ConfirmationDate = confirmationDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelCommodityBaileyRatingConfirmation CreateNewBlank(Parcel parcel, Commodity commodity, ParcelCommodityBaileyRatingConfirmationStatus parcelCommodityBaileyRatingConfirmationStatus, Person confirmedByPerson)
        {
            return new ParcelCommodityBaileyRatingConfirmation(parcel, commodity, parcelCommodityBaileyRatingConfirmationStatus, confirmedByPerson, default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelCommodityBaileyRatingConfirmation).Name};

        [Key]
        public int ParcelCommodityBaileyRatingConfirmationID { get; set; }
        public int ParcelID { get; set; }
        public int CommodityID { get; set; }
        public int? BaileyRatingID { get; set; }
        public int ParcelCommodityBaileyRatingConfirmationStatusID { get; set; }
        public int ConfirmedByPersonID { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string ConfirmationNotes { get; set; }
        public int PrimaryKey { get { return ParcelCommodityBaileyRatingConfirmationID; } set { ParcelCommodityBaileyRatingConfirmationID = value; } }

        public virtual Parcel Parcel { get; set; }
        public Commodity Commodity { get { return Commodity.AllLookupDictionary[CommodityID]; } }
        public BaileyRating BaileyRating { get { return BaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[BaileyRatingID.Value] : null; } }
        public ParcelCommodityBaileyRatingConfirmationStatus ParcelCommodityBaileyRatingConfirmationStatus { get { return ParcelCommodityBaileyRatingConfirmationStatus.AllLookupDictionary[ParcelCommodityBaileyRatingConfirmationStatusID]; } }
        public virtual Person ConfirmedByPerson { get; set; }

        public static class FieldLengths
        {
            public const int ConfirmationNotes = 200;
        }
    }
}