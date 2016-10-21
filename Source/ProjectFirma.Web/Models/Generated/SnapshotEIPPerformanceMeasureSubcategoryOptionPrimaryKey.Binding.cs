//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotEIPPerformanceMeasureSubcategoryOption
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class SnapshotEIPPerformanceMeasureSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotEIPPerformanceMeasureSubcategoryOption>
    {
        public SnapshotEIPPerformanceMeasureSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotEIPPerformanceMeasureSubcategoryOptionPrimaryKey(SnapshotEIPPerformanceMeasureSubcategoryOption snapshotEIPPerformanceMeasureSubcategoryOption) : base(snapshotEIPPerformanceMeasureSubcategoryOption){}

        public static implicit operator SnapshotEIPPerformanceMeasureSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new SnapshotEIPPerformanceMeasureSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotEIPPerformanceMeasureSubcategoryOptionPrimaryKey(SnapshotEIPPerformanceMeasureSubcategoryOption snapshotEIPPerformanceMeasureSubcategoryOption)
        {
            return new SnapshotEIPPerformanceMeasureSubcategoryOptionPrimaryKey(snapshotEIPPerformanceMeasureSubcategoryOption);
        }
    }
}