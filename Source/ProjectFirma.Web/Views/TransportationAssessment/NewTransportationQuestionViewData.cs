using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.TransportationAssessment
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