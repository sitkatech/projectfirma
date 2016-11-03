using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectAssessmentQuestion : IAuditableEntity, IQuestionAnswer
    {
        public ProposedProjectAssessmentQuestion(ProposedProjectAssessmentQuestionSimple projectAssessmentQuestionSimple)
        {
            ProposedProjectID = projectAssessmentQuestionSimple.ProposedProjectID;
            AssessmentQuestionID = projectAssessmentQuestionSimple.AssessmentQuestionID;
            Answer = projectAssessmentQuestionSimple.Answer;
            ProposedProjectAssessmentQuestionID = ModelObjectHelpers.NotYetAssignedID;
        }

        public string AuditDescriptionString
        {
            get { return string.Format("ProposedProjectAssessmentQuestion: {0}", ProposedProjectAssessmentQuestionID); }
        }

    }
}