using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectTransportationQuestion : IAuditableEntity, ITransportationQuestionAnswer
    {
        public ProposedProjectTransportationQuestion(ProposedProjectTransportationQuestionSimple projectTransportationQuestionSimple)
        {
            ProposedProjectID = projectTransportationQuestionSimple.ProposedProjectID;
            TransportationQuestionID = projectTransportationQuestionSimple.TransportationQuestionID;
            Answer = projectTransportationQuestionSimple.Answer;
            ProposedProjectTransportationQuestionID = ModelObjectHelpers.NotYetAssignedID;
        }

        public string AuditDescriptionString
        {
            get { return string.Format("ProposedProjectTransportationQuestion: {0}", ProposedProjectTransportationQuestionID); }
        }

    }
}