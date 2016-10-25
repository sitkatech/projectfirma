using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectLocalAndRegionalPlan
{
    public class EditProjectLocalAndRegionalPlansViewData : FirmaUserControlViewData
    {
        public readonly List<LocalAndRegionalPlanSimple> AllLocalAndRegionalPlans;
        public readonly int ProjectID;

        public EditProjectLocalAndRegionalPlansViewData(Models.Project project, List<LocalAndRegionalPlanSimple> allLocalAndRegionalPlans)
        {
            AllLocalAndRegionalPlans = allLocalAndRegionalPlans;
            ProjectID = project.ProjectID;
        }
    }
}