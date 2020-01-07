//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectEvaluation
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectEvaluationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectEvaluation>
    {
        public ProjectEvaluationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectEvaluationPrimaryKey(ProjectEvaluation projectEvaluation) : base(projectEvaluation){}

        public static implicit operator ProjectEvaluationPrimaryKey(int primaryKeyValue)
        {
            return new ProjectEvaluationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectEvaluationPrimaryKey(ProjectEvaluation projectEvaluation)
        {
            return new ProjectEvaluationPrimaryKey(projectEvaluation);
        }
    }
}