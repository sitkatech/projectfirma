//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdCategory
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdCategory>
    {
        public ThresholdCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdCategoryPrimaryKey(ThresholdCategory thresholdCategory) : base(thresholdCategory){}

        public static implicit operator ThresholdCategoryPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdCategoryPrimaryKey(ThresholdCategory thresholdCategory)
        {
            return new ThresholdCategoryPrimaryKey(thresholdCategory);
        }
    }
}