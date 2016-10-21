using ProjectFirma.Web.Areas.EIP.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TransportationGoal
    {
        public string EditUrl
        {
            get
            {
                return  SitkaRoute<TransportationAssessmentController>.BuildUrlFromExpression(c => c.EditTransportationGoal(TransportationGoalID));
            }
        }
        public string DisplayName
        {
            get { return string.Format("Goal {0}: {1}", TransportationGoalNumber, TransportationGoalTitle); }
        }
    }
}