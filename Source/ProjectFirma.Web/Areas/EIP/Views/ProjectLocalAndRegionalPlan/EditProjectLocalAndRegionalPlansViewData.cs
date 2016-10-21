using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectLocalAndRegionalPlan
{
    public class EditProjectLocalAndRegionalPlansViewData : LakeTahoeInfoUserControlViewData
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