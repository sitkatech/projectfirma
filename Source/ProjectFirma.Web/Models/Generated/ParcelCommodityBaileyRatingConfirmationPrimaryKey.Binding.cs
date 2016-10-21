//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelCommodityBaileyRatingConfirmation
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelCommodityBaileyRatingConfirmationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelCommodityBaileyRatingConfirmation>
    {
        public ParcelCommodityBaileyRatingConfirmationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelCommodityBaileyRatingConfirmationPrimaryKey(ParcelCommodityBaileyRatingConfirmation parcelCommodityBaileyRatingConfirmation) : base(parcelCommodityBaileyRatingConfirmation){}

        public static implicit operator ParcelCommodityBaileyRatingConfirmationPrimaryKey(int primaryKeyValue)
        {
            return new ParcelCommodityBaileyRatingConfirmationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelCommodityBaileyRatingConfirmationPrimaryKey(ParcelCommodityBaileyRatingConfirmation parcelCommodityBaileyRatingConfirmation)
        {
            return new ParcelCommodityBaileyRatingConfirmationPrimaryKey(parcelCommodityBaileyRatingConfirmation);
        }
    }
}