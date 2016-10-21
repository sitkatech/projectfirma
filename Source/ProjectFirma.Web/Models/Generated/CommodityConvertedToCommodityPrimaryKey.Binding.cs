//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CommodityConvertedToCommodity
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class CommodityConvertedToCommodityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CommodityConvertedToCommodity>
    {
        public CommodityConvertedToCommodityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CommodityConvertedToCommodityPrimaryKey(CommodityConvertedToCommodity commodityConvertedToCommodity) : base(commodityConvertedToCommodity){}

        public static implicit operator CommodityConvertedToCommodityPrimaryKey(int primaryKeyValue)
        {
            return new CommodityConvertedToCommodityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CommodityConvertedToCommodityPrimaryKey(CommodityConvertedToCommodity commodityConvertedToCommodity)
        {
            return new CommodityConvertedToCommodityPrimaryKey(commodityConvertedToCommodity);
        }
    }
}