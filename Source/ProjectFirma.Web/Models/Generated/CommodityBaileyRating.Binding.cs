//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityBaileyRating]
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
    [Table("[dbo].[CommodityBaileyRating]")]
    public partial class CommodityBaileyRating : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CommodityBaileyRating()
        {
            this.BankedCommodities = new HashSet<BankedCommodity>();
            this.ParcelExistingPhysicalInventories = new HashSet<ParcelExistingPhysicalInventory>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityBaileyRating(int commodityBaileyRatingID, int commodityID, int? baileyRatingID) : this()
        {
            this.CommodityBaileyRatingID = commodityBaileyRatingID;
            this.CommodityID = commodityID;
            this.BaileyRatingID = baileyRatingID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityBaileyRating(int commodityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            CommodityBaileyRatingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CommodityID = commodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CommodityBaileyRating(Commodity commodity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CommodityBaileyRatingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CommodityID = commodity.CommodityID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CommodityBaileyRating CreateNewBlank(Commodity commodity)
        {
            return new CommodityBaileyRating(commodity);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return BankedCommodities.Any() || ParcelExistingPhysicalInventories.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CommodityBaileyRating).Name, typeof(BankedCommodity).Name, typeof(ParcelExistingPhysicalInventory).Name};

        [Key]
        public int CommodityBaileyRatingID { get; set; }
        public int CommodityID { get; set; }
        public int? BaileyRatingID { get; set; }
        public int PrimaryKey { get { return CommodityBaileyRatingID; } set { CommodityBaileyRatingID = value; } }

        public virtual ICollection<BankedCommodity> BankedCommodities { get; set; }
        public virtual ICollection<ParcelExistingPhysicalInventory> ParcelExistingPhysicalInventories { get; set; }
        public Commodity Commodity { get { return Commodity.AllLookupDictionary[CommodityID]; } }
        public BaileyRating BaileyRating { get { return BaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[BaileyRatingID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}