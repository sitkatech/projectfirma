using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Assessment
{
    public class ManageViewData : FirmaViewData
    {
        public readonly bool HasEditPermissions;
        public readonly List<AssessmentGoal> AssessmentGoals;
        public readonly string AddQuestionUrl;
        public readonly string DownloadAllAssessmentsUrl;

        public ManageViewData(Person currentPerson, List<AssessmentGoal> assessmentGoals)
            : base(currentPerson)
        {
            PageTitle = "Manage  Assessment";
            HasEditPermissions = new AssessmentManageFeature().HasPermissionByPerson(CurrentPerson);
            AssessmentGoals = assessmentGoals;
            AddQuestionUrl = SitkaRoute<AssessmentController>.BuildUrlFromExpression(c => c.NewQuestion());
            DownloadAllAssessmentsUrl = SitkaRoute<AssessmentController>.BuildUrlFromExpression(c => c.IndexExcelDownload());
        }
    }
}