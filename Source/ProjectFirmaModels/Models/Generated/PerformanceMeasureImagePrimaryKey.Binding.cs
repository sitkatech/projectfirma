//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureImage
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureImage>
    {
        public PerformanceMeasureImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureImagePrimaryKey(PerformanceMeasureImage performanceMeasureImage) : base(performanceMeasureImage){}

        public static implicit operator PerformanceMeasureImagePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureImagePrimaryKey(PerformanceMeasureImage performanceMeasureImage)
        {
            return new PerformanceMeasureImagePrimaryKey(performanceMeasureImage);
        }
    }
}