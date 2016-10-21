//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdEvaluationTrendType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdEvaluationTrendTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdEvaluationTrendType>
    {
        public ThresholdEvaluationTrendTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdEvaluationTrendTypePrimaryKey(ThresholdEvaluationTrendType thresholdEvaluationTrendType) : base(thresholdEvaluationTrendType){}

        public static implicit operator ThresholdEvaluationTrendTypePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdEvaluationTrendTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdEvaluationTrendTypePrimaryKey(ThresholdEvaluationTrendType thresholdEvaluationTrendType)
        {
            return new ThresholdEvaluationTrendTypePrimaryKey(thresholdEvaluationTrendType);
        }
    }
}