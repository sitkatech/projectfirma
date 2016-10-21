//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LeadAgencyTransactionTypeCommodityLog
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencyTransactionTypeCommodityLogPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LeadAgencyTransactionTypeCommodityLog>
    {
        public LeadAgencyTransactionTypeCommodityLogPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LeadAgencyTransactionTypeCommodityLogPrimaryKey(LeadAgencyTransactionTypeCommodityLog leadAgencyTransactionTypeCommodityLog) : base(leadAgencyTransactionTypeCommodityLog){}

        public static implicit operator LeadAgencyTransactionTypeCommodityLogPrimaryKey(int primaryKeyValue)
        {
            return new LeadAgencyTransactionTypeCommodityLogPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LeadAgencyTransactionTypeCommodityLogPrimaryKey(LeadAgencyTransactionTypeCommodityLog leadAgencyTransactionTypeCommodityLog)
        {
            return new LeadAgencyTransactionTypeCommodityLogPrimaryKey(leadAgencyTransactionTypeCommodityLog);
        }
    }
}