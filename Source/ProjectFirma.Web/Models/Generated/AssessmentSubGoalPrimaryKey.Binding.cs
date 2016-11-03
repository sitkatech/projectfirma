//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AssessmentSubGoal
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class AssessmentSubGoalPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AssessmentSubGoal>
    {
        public AssessmentSubGoalPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AssessmentSubGoalPrimaryKey(AssessmentSubGoal assessmentSubGoal) : base(assessmentSubGoal){}

        public static implicit operator AssessmentSubGoalPrimaryKey(int primaryKeyValue)
        {
            return new AssessmentSubGoalPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AssessmentSubGoalPrimaryKey(AssessmentSubGoal assessmentSubGoal)
        {
            return new AssessmentSubGoalPrimaryKey(assessmentSubGoal);
        }
    }
}