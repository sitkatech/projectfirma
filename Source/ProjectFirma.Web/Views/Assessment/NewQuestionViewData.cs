using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Assessment
{
    public class NewQuestionViewData : FirmaViewData
    {
        public readonly bool HasEditPermissions;
        public readonly IEnumerable<SelectListItem> SubGoalsGroup;

        public NewQuestionViewData(Person currentPerson, IEnumerable<SelectListItem> subGoalsGroup)
            : base(currentPerson)
        {
            HasEditPermissions = new AssessmentManageFeature().HasPermissionByPerson(CurrentPerson);
            SubGoalsGroup = subGoalsGroup;           
        }
    }
}