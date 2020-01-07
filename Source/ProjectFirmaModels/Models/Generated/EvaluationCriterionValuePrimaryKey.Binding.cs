//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EvaluationCriterionValue
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriterionValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EvaluationCriterionValue>
    {
        public EvaluationCriterionValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EvaluationCriterionValuePrimaryKey(EvaluationCriterionValue evaluationCriterionValue) : base(evaluationCriterionValue){}

        public static implicit operator EvaluationCriterionValuePrimaryKey(int primaryKeyValue)
        {
            return new EvaluationCriterionValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator EvaluationCriterionValuePrimaryKey(EvaluationCriterionValue evaluationCriterionValue)
        {
            return new EvaluationCriterionValuePrimaryKey(evaluationCriterionValue);
        }
    }
}