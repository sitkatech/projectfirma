namespace ProjectFirma.Web.Models
{
    public class ProjectTransportationQuestionSimple
    {
        public int ProjectID { get; set; }
        public int TransportationQuestionID { get; set; }
        public bool? Answer { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectTransportationQuestionSimple()
        {
        }

        //Build a simple for a question that has already been answered
        public ProjectTransportationQuestionSimple(ProjectTransportationQuestion projectTransportationQuestion)
        {
            ProjectID = projectTransportationQuestion.ProjectID;
            TransportationQuestionID = projectTransportationQuestion.TransportationQuestionID;
            Answer = projectTransportationQuestion.Answer;
        }


        //Build a simple when we only have the question, but no answer
        public ProjectTransportationQuestionSimple(TransportationQuestion transportationQuestion, Project project)
        {
            TransportationQuestionID = transportationQuestion.TransportationQuestionID;
            ProjectID = project.ProjectID;
            Answer = null;
        }
    }
}