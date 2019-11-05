//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureReportedValue
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportedValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureReportedValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureReportedValuePrimaryKey(PerformanceMeasureReportedValue performanceMeasureReportedValue) : base(performanceMeasureReportedValue){}

        public static implicit operator PerformanceMeasureReportedValuePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureReportedValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureReportedValuePrimaryKey(PerformanceMeasureReportedValue performanceMeasureReportedValue)
        {
            return new PerformanceMeasureReportedValuePrimaryKey(performanceMeasureReportedValue);
        }
    }
}