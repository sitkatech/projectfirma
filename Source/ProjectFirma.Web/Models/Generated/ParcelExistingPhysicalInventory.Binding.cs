//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelExistingPhysicalInventory]
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
    [Table("[dbo].[ParcelExistingPhysicalInventory]")]
    public partial class ParcelExistingPhysicalInventory : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelExistingPhysicalInventory()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelExistingPhysicalInventory(int parcelExistingPhysicalInventoryID, int parcelID, int commodityBaileyRatingID, int existingPhysicalInventoryQuantity, DateTime? verifiedAsOfDate, string existingPhysicalInventoryNotes, DateTime lastUpdateDate, int lastUpdatePersonID, int encumberedForPendingPermitQuantity, int baseAllowableQuantity) : this()
        {
            this.ParcelExistingPhysicalInventoryID = parcelExistingPhysicalInventoryID;
            this.ParcelID = parcelID;
            this.CommodityBaileyRatingID = commodityBaileyRatingID;
            this.ExistingPhysicalInventoryQuantity = existingPhysicalInventoryQuantity;
            this.VerifiedAsOfDate = verifiedAsOfDate;
            this.ExistingPhysicalInventoryNotes = existingPhysicalInventoryNotes;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.EncumberedForPendingPermitQuantity = encumberedForPendingPermitQuantity;
            this.BaseAllowableQuantity = baseAllowableQuantity;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelExistingPhysicalInventory(int parcelID, int commodityBaileyRatingID, int existingPhysicalInventoryQuantity, DateTime lastUpdateDate, int lastUpdatePersonID, int encumberedForPendingPermitQuantity, int baseAllowableQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelExistingPhysicalInventoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ParcelID = parcelID;
            this.CommodityBaileyRatingID = commodityBaileyRatingID;
            this.ExistingPhysicalInventoryQuantity = existingPhysicalInventoryQuantity;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.EncumberedForPendingPermitQuantity = encumberedForPendingPermitQuantity;
            this.BaseAllowableQuantity = baseAllowableQuantity;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ParcelExistingPhysicalInventory(Parcel parcel, CommodityBaileyRating commodityBaileyRating, int existingPhysicalInventoryQuantity, DateTime lastUpdateDate, Person lastUpdatePerson, int encumberedForPendingPermitQuantity, int baseAllowableQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelExistingPhysicalInventoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.ParcelExistingPhysicalInventories.Add(this);
            this.CommodityBaileyRatingID = commodityBaileyRating.CommodityBaileyRatingID;
            this.CommodityBaileyRating = commodityBaileyRating;
            commodityBaileyRating.ParcelExistingPhysicalInventories.Add(this);
            this.ExistingPhysicalInventoryQuantity = existingPhysicalInventoryQuantity;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePerson.PersonID;
            this.LastUpdatePerson = lastUpdatePerson;
            lastUpdatePerson.ParcelExistingPhysicalInventoriesWhereYouAreTheLastUpdatePerson.Add(this);
            this.EncumberedForPendingPermitQuantity = encumberedForPendingPermitQuantity;
            this.BaseAllowableQuantity = baseAllowableQuantity;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelExistingPhysicalInventory CreateNewBlank(Parcel parcel, CommodityBaileyRating commodityBaileyRating, Person lastUpdatePerson)
        {
            return new ParcelExistingPhysicalInventory(parcel, commodityBaileyRating, default(int), default(DateTime), lastUpdatePerson, default(int), default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelExistingPhysicalInventory).Name};

        [Key]
        public int ParcelExistingPhysicalInventoryID { get; set; }
        public int ParcelID { get; set; }
        public int CommodityBaileyRatingID { get; set; }
        public int ExistingPhysicalInventoryQuantity { get; set; }
        public DateTime? VerifiedAsOfDate { get; set; }
        public string ExistingPhysicalInventoryNotes { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatePersonID { get; set; }
        public int EncumberedForPendingPermitQuantity { get; set; }
        public int BaseAllowableQuantity { get; set; }
        public int PrimaryKey { get { return ParcelExistingPhysicalInventoryID; } set { ParcelExistingPhysicalInventoryID = value; } }

        public virtual Parcel Parcel { get; set; }
        public virtual CommodityBaileyRating CommodityBaileyRating { get; set; }
        public virtual Person LastUpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int ExistingPhysicalInventoryNotes = 500;
        }
    }
}