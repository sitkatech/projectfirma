//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CommodityUnitType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class CommodityUnitTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CommodityUnitType>
    {
        public CommodityUnitTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CommodityUnitTypePrimaryKey(CommodityUnitType commodityUnitType) : base(commodityUnitType){}

        public static implicit operator CommodityUnitTypePrimaryKey(int primaryKeyValue)
        {
            return new CommodityUnitTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator CommodityUnitTypePrimaryKey(CommodityUnitType commodityUnitType)
        {
            return new CommodityUnitTypePrimaryKey(commodityUnitType);
        }
    }
}