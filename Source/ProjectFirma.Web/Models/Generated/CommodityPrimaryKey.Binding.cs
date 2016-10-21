//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Commodity
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class CommodityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Commodity>
    {
        public CommodityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CommodityPrimaryKey(Commodity commodity) : base(commodity){}

        public static implicit operator CommodityPrimaryKey(int primaryKeyValue)
        {
            return new CommodityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CommodityPrimaryKey(Commodity commodity)
        {
            return new CommodityPrimaryKey(commodity);
        }
    }
}