//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdEvaluationStatusType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdEvaluationStatusTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdEvaluationStatusType>
    {
        public ThresholdEvaluationStatusTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdEvaluationStatusTypePrimaryKey(ThresholdEvaluationStatusType thresholdEvaluationStatusType) : base(thresholdEvaluationStatusType){}

        public static implicit operator ThresholdEvaluationStatusTypePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdEvaluationStatusTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdEvaluationStatusTypePrimaryKey(ThresholdEvaluationStatusType thresholdEvaluationStatusType)
        {
            return new ThresholdEvaluationStatusTypePrimaryKey(thresholdEvaluationStatusType);
        }
    }
}