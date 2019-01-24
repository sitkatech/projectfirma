//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureDataSourceType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureDataSourceTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureDataSourceType>
    {
        public PerformanceMeasureDataSourceTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureDataSourceTypePrimaryKey(PerformanceMeasureDataSourceType performanceMeasureDataSourceType) : base(performanceMeasureDataSourceType){}

        public static implicit operator PerformanceMeasureDataSourceTypePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureDataSourceTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureDataSourceTypePrimaryKey(PerformanceMeasureDataSourceType performanceMeasureDataSourceType)
        {
            return new PerformanceMeasureDataSourceTypePrimaryKey(performanceMeasureDataSourceType);
        }
    }
}