//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EvaluationVisibility
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class EvaluationVisibilityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EvaluationVisibility>
    {
        public EvaluationVisibilityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EvaluationVisibilityPrimaryKey(EvaluationVisibility evaluationVisibility) : base(evaluationVisibility){}

        public static implicit operator EvaluationVisibilityPrimaryKey(int primaryKeyValue)
        {
            return new EvaluationVisibilityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EvaluationVisibilityPrimaryKey(EvaluationVisibility evaluationVisibility)
        {
            return new EvaluationVisibilityPrimaryKey(evaluationVisibility);
        }
    }
}