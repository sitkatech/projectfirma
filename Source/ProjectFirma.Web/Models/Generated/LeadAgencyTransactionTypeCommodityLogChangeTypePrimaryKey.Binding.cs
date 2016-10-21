//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LeadAgencyTransactionTypeCommodityLogChangeType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencyTransactionTypeCommodityLogChangeTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LeadAgencyTransactionTypeCommodityLogChangeType>
    {
        public LeadAgencyTransactionTypeCommodityLogChangeTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LeadAgencyTransactionTypeCommodityLogChangeTypePrimaryKey(LeadAgencyTransactionTypeCommodityLogChangeType leadAgencyTransactionTypeCommodityLogChangeType) : base(leadAgencyTransactionTypeCommodityLogChangeType){}

        public static implicit operator LeadAgencyTransactionTypeCommodityLogChangeTypePrimaryKey(int primaryKeyValue)
        {
            return new LeadAgencyTransactionTypeCommodityLogChangeTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator LeadAgencyTransactionTypeCommodityLogChangeTypePrimaryKey(LeadAgencyTransactionTypeCommodityLogChangeType leadAgencyTransactionTypeCommodityLogChangeType)
        {
            return new LeadAgencyTransactionTypeCommodityLogChangeTypePrimaryKey(leadAgencyTransactionTypeCommodityLogChangeType);
        }
    }
}