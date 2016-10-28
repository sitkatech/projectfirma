//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotPerformanceMeasure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SnapshotPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotPerformanceMeasure>
    {
        public SnapshotPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotPerformanceMeasurePrimaryKey(SnapshotPerformanceMeasure snapshotPerformanceMeasure) : base(snapshotPerformanceMeasure){}

        public static implicit operator SnapshotPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new SnapshotPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotPerformanceMeasurePrimaryKey(SnapshotPerformanceMeasure snapshotPerformanceMeasure)
        {
            return new SnapshotPerformanceMeasurePrimaryKey(snapshotPerformanceMeasure);
        }
    }
}