using System.Linq;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class AssessmentQuestion : IAuditableEntity
    {
        public bool IsArchived
        {
            get { return ArchiveDate.HasValue; }
        }
        public string AuditDescriptionString
        {
            get { return string.Format("Question: {0}", AssessmentQuestionID); }
        }

        public string EditUrl
        {
            get
            {
                return SitkaRoute<AssessmentController>.BuildUrlFromExpression(c => c.EditQuestion(AssessmentQuestionID));
            }
        }

        public int GetCountOfYesAnswers()
        {
            return ProjectAssessmentQuestions.Count(x => x.Answer ?? false) + ProposedProjectAssessmentQuestions.Count(x => x.Answer ?? false);
        }

        public int GetCountOfNoAnswers()
        {
            return ProjectAssessmentQuestions.Count(x => !x.Answer ?? false) + ProposedProjectAssessmentQuestions.Count(x => !x.Answer ?? false);
        }
    }
}