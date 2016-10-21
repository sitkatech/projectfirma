//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelCommodityBaileyRatingConfirmationStatus
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelCommodityBaileyRatingConfirmationStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelCommodityBaileyRatingConfirmationStatus>
    {
        public ParcelCommodityBaileyRatingConfirmationStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelCommodityBaileyRatingConfirmationStatusPrimaryKey(ParcelCommodityBaileyRatingConfirmationStatus parcelCommodityBaileyRatingConfirmationStatus) : base(parcelCommodityBaileyRatingConfirmationStatus){}

        public static implicit operator ParcelCommodityBaileyRatingConfirmationStatusPrimaryKey(int primaryKeyValue)
        {
            return new ParcelCommodityBaileyRatingConfirmationStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelCommodityBaileyRatingConfirmationStatusPrimaryKey(ParcelCommodityBaileyRatingConfirmationStatus parcelCommodityBaileyRatingConfirmationStatus)
        {
            return new ParcelCommodityBaileyRatingConfirmationStatusPrimaryKey(parcelCommodityBaileyRatingConfirmationStatus);
        }
    }
}