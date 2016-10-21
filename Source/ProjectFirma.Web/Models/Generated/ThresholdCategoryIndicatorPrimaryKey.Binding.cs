//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdCategoryIndicator
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdCategoryIndicatorPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdCategoryIndicator>
    {
        public ThresholdCategoryIndicatorPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdCategoryIndicatorPrimaryKey(ThresholdCategoryIndicator thresholdCategoryIndicator) : base(thresholdCategoryIndicator){}

        public static implicit operator ThresholdCategoryIndicatorPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdCategoryIndicatorPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdCategoryIndicatorPrimaryKey(ThresholdCategoryIndicator thresholdCategoryIndicator)
        {
            return new ThresholdCategoryIndicatorPrimaryKey(thresholdCategoryIndicator);
        }
    }
}