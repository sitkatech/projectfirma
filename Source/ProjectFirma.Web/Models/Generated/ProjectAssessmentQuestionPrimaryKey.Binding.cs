//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectAssessmentQuestion
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
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