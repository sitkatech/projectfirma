//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdCategoryPerformanceMeasure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdCategoryPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdCategoryPerformanceMeasure>
    {
        public ThresholdCategoryPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdCategoryPerformanceMeasurePrimaryKey(ThresholdCategoryPerformanceMeasure thresholdCategoryPerformanceMeasure) : base(thresholdCategoryPerformanceMeasure){}

        public static implicit operator ThresholdCategoryPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdCategoryPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdCategoryPerformanceMeasurePrimaryKey(ThresholdCategoryPerformanceMeasure thresholdCategoryPerformanceMeasure)
        {
            return new ThresholdCategoryPerformanceMeasurePrimaryKey(thresholdCategoryPerformanceMeasure);
        }
    }
}