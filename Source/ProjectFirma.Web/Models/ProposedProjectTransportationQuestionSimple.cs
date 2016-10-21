namespace ProjectFirma.Web.Models
{
    public class ProposedProjectTransportationQuestionSimple
    {
        public int ProposedProjectID { get; set; }
        public int TransportationQuestionID { get; set; }
        public bool? Answer { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProposedProjectTransportationQuestionSimple()
        {
        }

        //Build a simple for a question that has already been answered
        public ProposedProjectTransportationQuestionSimple(ProposedProjectTransportationQuestion proposedProjectTransportationQuestion)
        {
            ProposedProjectID = proposedProjectTransportationQuestion.ProposedProjectID;
            TransportationQuestionID = proposedProjectTransportationQuestion.TransportationQuestionID;
            Answer = proposedProjectTransportationQuestion.Answer;
        }


        //Build a simple when we only have the question, but no answer
        public ProposedProjectTransportationQuestionSimple(TransportationQuestion transportationQuestion, ProposedProject proposedProject)
        {
            TransportationQuestionID = transportationQuestion.TransportationQuestionID;
            ProposedProjectID = proposedProject.ProposedProjectID;
            Answer = null;
        }
    }
}