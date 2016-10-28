//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotPerformanceMeasureSubcategoryOption
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SnapshotPerformanceMeasureSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotPerformanceMeasureSubcategoryOption>
    {
        public SnapshotPerformanceMeasureSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotPerformanceMeasureSubcategoryOptionPrimaryKey(SnapshotPerformanceMeasureSubcategoryOption snapshotPerformanceMeasureSubcategoryOption) : base(snapshotPerformanceMeasureSubcategoryOption){}

        public static implicit operator SnapshotPerformanceMeasureSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new SnapshotPerformanceMeasureSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotPerformanceMeasureSubcategoryOptionPrimaryKey(SnapshotPerformanceMeasureSubcategoryOption snapshotPerformanceMeasureSubcategoryOption)
        {
            return new SnapshotPerformanceMeasureSubcategoryOptionPrimaryKey(snapshotPerformanceMeasureSubcategoryOption);
        }
    }
}