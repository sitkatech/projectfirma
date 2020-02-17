//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EvaluationCriteria
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriteriaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EvaluationCriteria>
    {
        public EvaluationCriteriaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EvaluationCriteriaPrimaryKey(EvaluationCriteria evaluationCriteria) : base(evaluationCriteria){}

        public static implicit operator EvaluationCriteriaPrimaryKey(int primaryKeyValue)
        {
            return new EvaluationCriteriaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EvaluationCriteriaPrimaryKey(EvaluationCriteria evaluationCriteria)
        {
            return new EvaluationCriteriaPrimaryKey(evaluationCriteria);
        }
    }
}