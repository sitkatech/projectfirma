//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorMonitoringProgram
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class IndicatorMonitoringProgramPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorMonitoringProgram>
    {
        public IndicatorMonitoringProgramPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorMonitoringProgramPrimaryKey(IndicatorMonitoringProgram indicatorMonitoringProgram) : base(indicatorMonitoringProgram){}

        public static implicit operator IndicatorMonitoringProgramPrimaryKey(int primaryKeyValue)
        {
            return new IndicatorMonitoringProgramPrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorMonitoringProgramPrimaryKey(IndicatorMonitoringProgram indicatorMonitoringProgram)
        {
            return new IndicatorMonitoringProgramPrimaryKey(indicatorMonitoringProgram);
        }
    }
}