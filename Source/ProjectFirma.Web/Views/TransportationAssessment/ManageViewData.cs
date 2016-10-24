using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.TransportationAssessment
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