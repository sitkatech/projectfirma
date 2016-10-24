//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdEvaluation
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdEvaluationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdEvaluation>
    {
        public ThresholdEvaluationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdEvaluationPrimaryKey(ThresholdEvaluation thresholdEvaluation) : base(thresholdEvaluation){}

        public static implicit operator ThresholdEvaluationPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdEvaluationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdEvaluationPrimaryKey(ThresholdEvaluation thresholdEvaluation)
        {
            return new ThresholdEvaluationPrimaryKey(thresholdEvaluation);
        }
    }
}