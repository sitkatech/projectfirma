//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.BankedCommodity
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class BankedCommodityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<BankedCommodity>
    {
        public BankedCommodityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public BankedCommodityPrimaryKey(BankedCommodity bankedCommodity) : base(bankedCommodity){}

        public static implicit operator BankedCommodityPrimaryKey(int primaryKeyValue)
        {
            return new BankedCommodityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator BankedCommodityPrimaryKey(BankedCommodity bankedCommodity)
        {
            return new BankedCommodityPrimaryKey(bankedCommodity);
        }
    }
}