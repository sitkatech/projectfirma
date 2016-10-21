using System;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Common;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TransportationQuestion : IAuditableEntity
    {
        public bool IsArchived
        {
            get { return ArchiveDate.HasValue; }
        }
        public string AuditDescriptionString
        {
            get { return string.Format("TransportationQuestion: {0}", TransportationQuestionID); }
        }

        public string EditUrl
        {
            get
            {
                return SitkaRoute<TransportationAssessmentController>.BuildUrlFromExpression(c => c.EditTransportationQuestion(TransportationQuestionID));
            }
        }

        public int GetCountOfYesAnswers()
        {
            return ProjectTransportationQuestions.Count(x => x.Answer ?? false) + ProposedProjectTransportationQuestions.Count(x => x.Answer ?? false);
        }

        public int GetCountOfNoAnswers()
        {
            return ProjectTransportationQuestions.Count(x => !x.Answer ?? false) + ProposedProjectTransportationQuestions.Count(x => !x.Answer ?? false);
        }
    }
}