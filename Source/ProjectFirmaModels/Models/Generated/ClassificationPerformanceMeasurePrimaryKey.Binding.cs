//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ClassificationPerformanceMeasure
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ClassificationPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ClassificationPerformanceMeasure>
    {
        public ClassificationPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ClassificationPerformanceMeasurePrimaryKey(ClassificationPerformanceMeasure classificationPerformanceMeasure) : base(classificationPerformanceMeasure){}

        public static implicit operator ClassificationPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new ClassificationPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ClassificationPerformanceMeasurePrimaryKey(ClassificationPerformanceMeasure classificationPerformanceMeasure)
        {
            return new ClassificationPerformanceMeasurePrimaryKey(classificationPerformanceMeasure);
        }
    }
}