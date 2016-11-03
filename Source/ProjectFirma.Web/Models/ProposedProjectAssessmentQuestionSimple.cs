namespace ProjectFirma.Web.Models
{
    public class ProposedProjectAssessmentQuestionSimple
    {
        public int ProposedProjectID { get; set; }
        public int AssessmentQuestionID { get; set; }
        public bool? Answer { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProposedProjectAssessmentQuestionSimple()
        {
        }

        //Build a simple for a question that has already been answered
        public ProposedProjectAssessmentQuestionSimple(ProposedProjectAssessmentQuestion proposedProjectAssessmentQuestion)
        {
            ProposedProjectID = proposedProjectAssessmentQuestion.ProposedProjectID;
            AssessmentQuestionID = proposedProjectAssessmentQuestion.AssessmentQuestionID;
            Answer = proposedProjectAssessmentQuestion.Answer;
        }


        //Build a simple when we only have the question, but no answer
        public ProposedProjectAssessmentQuestionSimple(AssessmentQuestion assessmentQuestion, ProposedProject proposedProject)
        {
            AssessmentQuestionID = assessmentQuestion.AssessmentQuestionID;
            ProposedProjectID = proposedProject.ProposedProjectID;
            Answer = null;
        }
    }
}