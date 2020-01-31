//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EvaluationCriteriaValue
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriteriaValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EvaluationCriteriaValue>
    {
        public EvaluationCriteriaValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EvaluationCriteriaValuePrimaryKey(EvaluationCriteriaValue evaluationCriteriaValue) : base(evaluationCriteriaValue){}

        public static implicit operator EvaluationCriteriaValuePrimaryKey(int primaryKeyValue)
        {
            return new EvaluationCriteriaValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator EvaluationCriteriaValuePrimaryKey(EvaluationCriteriaValue evaluationCriteriaValue)
        {
            return new EvaluationCriteriaValuePrimaryKey(evaluationCriteriaValue);
        }
    }
}