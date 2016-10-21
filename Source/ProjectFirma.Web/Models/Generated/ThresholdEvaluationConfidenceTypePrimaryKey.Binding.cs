//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdEvaluationConfidenceType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdEvaluationConfidenceTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdEvaluationConfidenceType>
    {
        public ThresholdEvaluationConfidenceTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdEvaluationConfidenceTypePrimaryKey(ThresholdEvaluationConfidenceType thresholdEvaluationConfidenceType) : base(thresholdEvaluationConfidenceType){}

        public static implicit operator ThresholdEvaluationConfidenceTypePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdEvaluationConfidenceTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdEvaluationConfidenceTypePrimaryKey(ThresholdEvaluationConfidenceType thresholdEvaluationConfidenceType)
        {
            return new ThresholdEvaluationConfidenceTypePrimaryKey(thresholdEvaluationConfidenceType);
        }
    }
}