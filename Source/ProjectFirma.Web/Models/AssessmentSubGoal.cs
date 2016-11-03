using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class AssessmentSubGoal : IAuditableEntity
    {
        public List<AssessmentQuestion> ActiveQuestions
        {
            get { return AssessmentQuestions.Where(x => !x.IsArchived).ToList(); }
        }

        public string EditUrl
        {
            get
            {
                return SitkaRoute<AssessmentController>.BuildUrlFromExpression(c => c.EditSubGoal(AssessmentSubGoalID));
            }
        }
        public string DisplayName
        {
            get { return string.Format("Sub Goal {0}: {1}", AssessmentSubGoalNumber, AssessmentSubGoalTitle); }
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