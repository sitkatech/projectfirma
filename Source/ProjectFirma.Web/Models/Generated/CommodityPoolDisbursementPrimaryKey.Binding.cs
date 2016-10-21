//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CommodityPoolDisbursement
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class CommodityPoolDisbursementPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CommodityPoolDisbursement>
    {
        public CommodityPoolDisbursementPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CommodityPoolDisbursementPrimaryKey(CommodityPoolDisbursement commodityPoolDisbursement) : base(commodityPoolDisbursement){}

        public static implicit operator CommodityPoolDisbursementPrimaryKey(int primaryKeyValue)
        {
            return new CommodityPoolDisbursementPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CommodityPoolDisbursementPrimaryKey(CommodityPoolDisbursement commodityPoolDisbursement)
        {
            return new CommodityPoolDisbursementPrimaryKey(commodityPoolDisbursement);
        }
    }
}