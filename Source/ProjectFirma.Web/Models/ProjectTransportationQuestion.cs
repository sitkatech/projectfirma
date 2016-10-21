using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectTransportationQuestion : IAuditableEntity, ITransportationQuestionAnswer
    {
        public ProjectTransportationQuestion(ProjectTransportationQuestionSimple projectTransportationQuestionSimple)
        {
            ProjectID = projectTransportationQuestionSimple.ProjectID;
            TransportationQuestionID = projectTransportationQuestionSimple.TransportationQuestionID;
            Answer = projectTransportationQuestionSimple.Answer;
            ProjectTransportationQuestionID = ModelObjectHelpers.NotYetAssignedID;
        }

        public string AuditDescriptionString
        {
            get { return string.Format("ProjectTransportationQuestion: {0}", ProjectTransportationQuestionID); }
        }
    }
}