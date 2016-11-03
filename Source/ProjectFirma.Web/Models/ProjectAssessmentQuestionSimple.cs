namespace ProjectFirma.Web.Models
{
    public class ProjectAssessmentQuestionSimple
    {
        public int ProjectID { get; set; }
        public int AssessmentQuestionID { get; set; }
        public bool? Answer { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectAssessmentQuestionSimple()
        {
        }

        //Build a simple for a question that has already been answered
        public ProjectAssessmentQuestionSimple(ProjectAssessmentQuestion projectAssessmentQuestion)
        {
            ProjectID = projectAssessmentQuestion.ProjectID;
            AssessmentQuestionID = projectAssessmentQuestion.AssessmentQuestionID;
            Answer = projectAssessmentQuestion.Answer;
        }


        //Build a simple when we only have the question, but no answer
        public ProjectAssessmentQuestionSimple(AssessmentQuestion assessmentQuestion, Project project)
        {
            AssessmentQuestionID = assessmentQuestion.AssessmentQuestionID;
            ProjectID = project.ProjectID;
            Answer = null;
        }
    }
}