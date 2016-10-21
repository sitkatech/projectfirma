using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationAssessment
{
    public class NewTransportationQuestionViewData : EIPViewData
    {
        public readonly bool HasEditPermissions;
        public readonly IEnumerable<SelectListItem> TransportationSubGoalsGroup;

        public NewTransportationQuestionViewData(Person currentPerson, IEnumerable<SelectListItem> transportationSubGoalsGroup)
            : base(currentPerson)
        {
            HasEditPermissions = new TransportationManageFeature().HasPermissionByPerson(CurrentPerson);
            TransportationSubGoalsGroup = transportationSubGoalsGroup;           
        }
    }
}