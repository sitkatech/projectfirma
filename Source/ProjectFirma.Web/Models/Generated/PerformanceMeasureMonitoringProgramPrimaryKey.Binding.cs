//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureMonitoringProgram
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureMonitoringProgramPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureMonitoringProgram>
    {
        public PerformanceMeasureMonitoringProgramPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureMonitoringProgramPrimaryKey(PerformanceMeasureMonitoringProgram performanceMeasureMonitoringProgram) : base(performanceMeasureMonitoringProgram){}

        public static implicit operator PerformanceMeasureMonitoringProgramPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureMonitoringProgramPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureMonitoringProgramPrimaryKey(PerformanceMeasureMonitoringProgram performanceMeasureMonitoringProgram)
        {
            return new PerformanceMeasureMonitoringProgramPrimaryKey(performanceMeasureMonitoringProgram);
        }
    }
}