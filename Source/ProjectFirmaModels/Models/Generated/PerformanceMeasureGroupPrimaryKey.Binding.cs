//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureGroup
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureGroupPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureGroup>
    {
        public PerformanceMeasureGroupPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureGroupPrimaryKey(PerformanceMeasureGroup performanceMeasureGroup) : base(performanceMeasureGroup){}

        public static implicit operator PerformanceMeasureGroupPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureGroupPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureGroupPrimaryKey(PerformanceMeasureGroup performanceMeasureGroup)
        {
            return new PerformanceMeasureGroupPrimaryKey(performanceMeasureGroup);
        }
    }
}