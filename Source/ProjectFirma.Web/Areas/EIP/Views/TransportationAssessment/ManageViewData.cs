using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationAssessment
{
    public class ManageViewData : EIPViewData
    {
        public readonly bool HasEditPermissions;
        public readonly List<TransportationGoal> TransportationGoals;
        public readonly string AddTransportationQuestionUrl;
        public readonly string DownloadAllAssessmentsUrl;

        public ManageViewData(Person currentPerson, List<TransportationGoal> transportationGoals)
            : base(currentPerson)
        {
            PageTitle = "Manage Transportation Assessment";
            HasEditPermissions = new TransportationManageFeature().HasPermissionByPerson(CurrentPerson);
            TransportationGoals = transportationGoals;
            AddTransportationQuestionUrl = SitkaRoute<TransportationAssessmentController>.BuildUrlFromExpression(c => c.NewTransportationQuestion());
            DownloadAllAssessmentsUrl = SitkaRoute<TransportationAssessmentController>.BuildUrlFromExpression(c => c.IndexExcelDownload());
        }
    }
}