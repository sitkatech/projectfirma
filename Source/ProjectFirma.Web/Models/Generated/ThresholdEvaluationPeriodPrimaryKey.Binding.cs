//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdEvaluationPeriod
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdEvaluationPeriodPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdEvaluationPeriod>
    {
        public ThresholdEvaluationPeriodPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdEvaluationPeriodPrimaryKey(ThresholdEvaluationPeriod thresholdEvaluationPeriod) : base(thresholdEvaluationPeriod){}

        public static implicit operator ThresholdEvaluationPeriodPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdEvaluationPeriodPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdEvaluationPeriodPrimaryKey(ThresholdEvaluationPeriod thresholdEvaluationPeriod)
        {
            return new ThresholdEvaluationPeriodPrimaryKey(thresholdEvaluationPeriod);
        }
    }
}