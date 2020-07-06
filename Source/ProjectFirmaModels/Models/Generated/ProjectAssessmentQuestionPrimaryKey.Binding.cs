//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectAssessmentQuestion
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectAssessmentQuestionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectAssessmentQuestion>
    {
        public ProjectAssessmentQuestionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectAssessmentQuestionPrimaryKey(ProjectAssessmentQuestion projectAssessmentQuestion) : base(projectAssessmentQuestion){}

        public static implicit operator ProjectAssessmentQuestionPrimaryKey(int primaryKeyValue)
        {
            return new ProjectAssessmentQuestionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectAssessmentQuestionPrimaryKey(ProjectAssessmentQuestion projectAssessmentQuestion)
        {
            return new ProjectAssessmentQuestionPrimaryKey(projectAssessmentQuestion);
        }
    }
}