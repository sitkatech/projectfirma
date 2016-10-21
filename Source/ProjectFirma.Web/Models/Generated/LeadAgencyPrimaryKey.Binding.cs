//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LeadAgency
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencyPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LeadAgency>
    {
        public LeadAgencyPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LeadAgencyPrimaryKey(LeadAgency leadAgency) : base(leadAgency){}

        public static implicit operator LeadAgencyPrimaryKey(int primaryKeyValue)
        {
            return new LeadAgencyPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LeadAgencyPrimaryKey(LeadAgency leadAgency)
        {
            return new LeadAgencyPrimaryKey(leadAgency);
        }
    }
}