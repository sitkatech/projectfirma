//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EvaluationCriterion
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class EvaluationCriterionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EvaluationCriterion>
    {
        public EvaluationCriterionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EvaluationCriterionPrimaryKey(EvaluationCriterion evaluationCriterion) : base(evaluationCriterion){}

        public static implicit operator EvaluationCriterionPrimaryKey(int primaryKeyValue)
        {
            return new EvaluationCriterionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EvaluationCriterionPrimaryKey(EvaluationCriterion evaluationCriterion)
        {
            return new EvaluationCriterionPrimaryKey(evaluationCriterion);
        }
    }
}