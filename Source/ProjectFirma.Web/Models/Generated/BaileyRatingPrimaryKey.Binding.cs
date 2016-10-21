//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.BaileyRating
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class BaileyRatingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<BaileyRating>
    {
        public BaileyRatingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public BaileyRatingPrimaryKey(BaileyRating baileyRating) : base(baileyRating){}

        public static implicit operator BaileyRatingPrimaryKey(int primaryKeyValue)
        {
            return new BaileyRatingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator BaileyRatingPrimaryKey(BaileyRating baileyRating)
        {
            return new BaileyRatingPrimaryKey(baileyRating);
        }
    }
}