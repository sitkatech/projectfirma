//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdEvaluationManagementStatusType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdEvaluationManagementStatusTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdEvaluationManagementStatusType>
    {
        public ThresholdEvaluationManagementStatusTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdEvaluationManagementStatusTypePrimaryKey(ThresholdEvaluationManagementStatusType thresholdEvaluationManagementStatusType) : base(thresholdEvaluationManagementStatusType){}

        public static implicit operator ThresholdEvaluationManagementStatusTypePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdEvaluationManagementStatusTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdEvaluationManagementStatusTypePrimaryKey(ThresholdEvaluationManagementStatusType thresholdEvaluationManagementStatusType)
        {
            return new ThresholdEvaluationManagementStatusTypePrimaryKey(thresholdEvaluationManagementStatusType);
        }
    }
}