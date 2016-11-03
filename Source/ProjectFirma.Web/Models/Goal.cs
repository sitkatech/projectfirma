using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class AssessmentGoal
    {
        public string EditUrl
        {
            get
            {
                return  SitkaRoute<AssessmentController>.BuildUrlFromExpression(c => c.EditGoal(AssessmentGoalID));
            }
        }
        public string DisplayName
        {
            get { return string.Format("Assessment Goal {0}: {1}", AssessmentGoalNumber, AssessmentGoalTitle); }
        }
    }
}