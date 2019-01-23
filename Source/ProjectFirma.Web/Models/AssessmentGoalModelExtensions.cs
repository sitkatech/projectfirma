using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class AssessmentGoalModelExtensions
    {
        public static string GetEditUrl(this AssessmentGoal assessmentGoal)
        {
            return SitkaRoute<AssessmentController>.BuildUrlFromExpression(c => c.EditGoal(assessmentGoal.AssessmentGoalID));
        }
    }
}