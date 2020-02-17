//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EvaluationStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class EvaluationStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EvaluationStatus>
    {
        public EvaluationStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EvaluationStatusPrimaryKey(EvaluationStatus evaluationStatus) : base(evaluationStatus){}

        public static implicit operator EvaluationStatusPrimaryKey(int primaryKeyValue)
        {
            return new EvaluationStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EvaluationStatusPrimaryKey(EvaluationStatus evaluationStatus)
        {
            return new EvaluationStatusPrimaryKey(evaluationStatus);
        }
    }
}