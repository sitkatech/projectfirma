//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProgramEIPPerformanceMeasure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProgramEIPPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProgramEIPPerformanceMeasure>
    {
        public ProgramEIPPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProgramEIPPerformanceMeasurePrimaryKey(ProgramEIPPerformanceMeasure programEIPPerformanceMeasure) : base(programEIPPerformanceMeasure){}

        public static implicit operator ProgramEIPPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new ProgramEIPPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProgramEIPPerformanceMeasurePrimaryKey(ProgramEIPPerformanceMeasure programEIPPerformanceMeasure)
        {
            return new ProgramEIPPerformanceMeasurePrimaryKey(programEIPPerformanceMeasure);
        }
    }
}