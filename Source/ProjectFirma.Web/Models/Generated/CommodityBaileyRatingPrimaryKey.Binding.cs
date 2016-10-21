//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CommodityBaileyRating
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class CommodityBaileyRatingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CommodityBaileyRating>
    {
        public CommodityBaileyRatingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CommodityBaileyRatingPrimaryKey(CommodityBaileyRating commodityBaileyRating) : base(commodityBaileyRating){}

        public static implicit operator CommodityBaileyRatingPrimaryKey(int primaryKeyValue)
        {
            return new CommodityBaileyRatingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CommodityBaileyRatingPrimaryKey(CommodityBaileyRating commodityBaileyRating)
        {
            return new CommodityBaileyRatingPrimaryKey(commodityBaileyRating);
        }
    }
}