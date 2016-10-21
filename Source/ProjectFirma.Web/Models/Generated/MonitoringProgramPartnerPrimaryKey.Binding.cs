//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MonitoringProgramPartner
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class MonitoringProgramPartnerPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MonitoringProgramPartner>
    {
        public MonitoringProgramPartnerPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MonitoringProgramPartnerPrimaryKey(MonitoringProgramPartner monitoringProgramPartner) : base(monitoringProgramPartner){}

        public static implicit operator MonitoringProgramPartnerPrimaryKey(int primaryKeyValue)
        {
            return new MonitoringProgramPartnerPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MonitoringProgramPartnerPrimaryKey(MonitoringProgramPartner monitoringProgramPartner)
        {
            return new MonitoringProgramPartnerPrimaryKey(monitoringProgramPartner);
        }
    }
}