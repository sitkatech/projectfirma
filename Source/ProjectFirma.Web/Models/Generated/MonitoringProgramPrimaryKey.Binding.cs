//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MonitoringProgram
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class MonitoringProgramPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MonitoringProgram>
    {
        public MonitoringProgramPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MonitoringProgramPrimaryKey(MonitoringProgram monitoringProgram) : base(monitoringProgram){}

        public static implicit operator MonitoringProgramPrimaryKey(int primaryKeyValue)
        {
            return new MonitoringProgramPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MonitoringProgramPrimaryKey(MonitoringProgram monitoringProgram)
        {
            return new MonitoringProgramPrimaryKey(monitoringProgram);
        }
    }
}