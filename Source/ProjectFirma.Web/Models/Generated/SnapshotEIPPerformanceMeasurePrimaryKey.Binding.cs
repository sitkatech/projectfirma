//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotEIPPerformanceMeasure
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class SnapshotEIPPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotEIPPerformanceMeasure>
    {
        public SnapshotEIPPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotEIPPerformanceMeasurePrimaryKey(SnapshotEIPPerformanceMeasure snapshotEIPPerformanceMeasure) : base(snapshotEIPPerformanceMeasure){}

        public static implicit operator SnapshotEIPPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new SnapshotEIPPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotEIPPerformanceMeasurePrimaryKey(SnapshotEIPPerformanceMeasure snapshotEIPPerformanceMeasure)
        {
            return new SnapshotEIPPerformanceMeasurePrimaryKey(snapshotEIPPerformanceMeasure);
        }
    }
}