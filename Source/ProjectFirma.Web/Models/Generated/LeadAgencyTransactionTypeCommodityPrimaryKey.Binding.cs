//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LeadAgencyTransactionTypeCommodity
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencyTransactionTypeCommodityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LeadAgencyTransactionTypeCommodity>
    {
        public LeadAgencyTransactionTypeCommodityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LeadAgencyTransactionTypeCommodityPrimaryKey(LeadAgencyTransactionTypeCommodity leadAgencyTransactionTypeCommodity) : base(leadAgencyTransactionTypeCommodity){}

        public static implicit operator LeadAgencyTransactionTypeCommodityPrimaryKey(int primaryKeyValue)
        {
            return new LeadAgencyTransactionTypeCommodityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LeadAgencyTransactionTypeCommodityPrimaryKey(LeadAgencyTransactionTypeCommodity leadAgencyTransactionTypeCommodity)
        {
            return new LeadAgencyTransactionTypeCommodityPrimaryKey(leadAgencyTransactionTypeCommodity);
        }
    }
}