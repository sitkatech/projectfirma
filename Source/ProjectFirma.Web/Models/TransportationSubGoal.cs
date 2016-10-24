using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TransportationSubGoal : IAuditableEntity
    {
        public List<TransportationQuestion> ActiveQuestions
        {
            get { return TransportationQuestions.Where(x => !x.IsArchived).ToList(); }
        }
        public string EditUrl
        {
            get
            {
                return SitkaRoute<TransportationAssessmentController>.BuildUrlFromExpression(c => c.EditTransportationSubGoal(TransportationSubGoalID));
            }
        }
        public string DisplayName
        {
            get { return string.Format("Metric {0}: {1}", TransportationSubGoalNumber, TransportationSubGoalTitle); }
        }
        public string AuditDescriptionString
        {
            get
            {
                return DisplayName;
            }
        }
    }
}