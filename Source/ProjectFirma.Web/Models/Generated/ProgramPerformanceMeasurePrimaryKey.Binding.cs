//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProgramPerformanceMeasure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProgramPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProgramPerformanceMeasure>
    {
        public ProgramPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProgramPerformanceMeasurePrimaryKey(ProgramPerformanceMeasure programPerformanceMeasure) : base(programPerformanceMeasure){}

        public static implicit operator ProgramPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new ProgramPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProgramPerformanceMeasurePrimaryKey(ProgramPerformanceMeasure programPerformanceMeasure)
        {
            return new ProgramPerformanceMeasurePrimaryKey(programPerformanceMeasure);
        }
    }
}