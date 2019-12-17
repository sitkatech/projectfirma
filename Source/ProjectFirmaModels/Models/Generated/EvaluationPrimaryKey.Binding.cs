//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Evaluation
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class EvaluationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Evaluation>
    {
        public EvaluationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EvaluationPrimaryKey(Evaluation evaluation) : base(evaluation){}

        public static implicit operator EvaluationPrimaryKey(int primaryKeyValue)
        {
            return new EvaluationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EvaluationPrimaryKey(Evaluation evaluation)
        {
            return new EvaluationPrimaryKey(evaluation);
        }
    }
}