//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CommodityPool
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class CommodityPoolPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CommodityPool>
    {
        public CommodityPoolPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CommodityPoolPrimaryKey(CommodityPool commodityPool) : base(commodityPool){}

        public static implicit operator CommodityPoolPrimaryKey(int primaryKeyValue)
        {
            return new CommodityPoolPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CommodityPoolPrimaryKey(CommodityPool commodityPool)
        {
            return new CommodityPoolPrimaryKey(commodityPool);
        }
    }
}