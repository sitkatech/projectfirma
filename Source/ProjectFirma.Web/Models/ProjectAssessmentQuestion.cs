using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectAssessmentQuestion : IAuditableEntity, IQuestionAnswer
    {
        public ProjectAssessmentQuestion(ProjectAssessmentQuestionSimple projectAssessmentQuestionSimple)
        {
            ProjectID = projectAssessmentQuestionSimple.ProjectID;
            AssessmentQuestionID = projectAssessmentQuestionSimple.AssessmentQuestionID;
            Answer = projectAssessmentQuestionSimple.Answer;
            ProjectAssessmentQuestionID = ModelObjectHelpers.NotYetAssignedID;
        }

        public string AuditDescriptionString
        {
            get { return string.Format("ProjectAssessmentQuestion: {0}", ProjectAssessmentQuestionID); }
        }
    }
}