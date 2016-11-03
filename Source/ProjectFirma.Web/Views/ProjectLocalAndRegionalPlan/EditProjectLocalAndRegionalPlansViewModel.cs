using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectLocalAndRegionalPlan
{
    public class EditProjectLocalAndRegionalPlansViewModel : FormViewModel
    {
        public List<ProjectLocalAndRegionalPlanSimple> ProjectLocalAndRegionalPlans { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectLocalAndRegionalPlansViewModel()
        {
        }

        public EditProjectLocalAndRegionalPlansViewModel(List<ProjectLocalAndRegionalPlanSimple> projectLocalAndRegionalPlans)
        {
            ProjectLocalAndRegionalPlans = projectLocalAndRegionalPlans;
        }

        public void UpdateModel(List<Models.ProjectLocalAndRegionalPlan> currentProjectLocalAndRegionalPlans, IList<Models.ProjectLocalAndRegionalPlan> allProjectLocalAndRegionalPlans)
        {
            var projectLocalAndRegionalPlansUpdated = new List<Models.ProjectLocalAndRegionalPlan>();
            if (ProjectLocalAndRegionalPlans != null)
            {
                // Completely rebuild the list
                projectLocalAndRegionalPlansUpdated = ProjectLocalAndRegionalPlans.Select(x => new Models.ProjectLocalAndRegionalPlan(x.ProjectID, x.LocalAndRegionalPlanID)).ToList();
            }
            currentProjectLocalAndRegionalPlans.Merge(projectLocalAndRegionalPlansUpdated,
                allProjectLocalAndRegionalPlans,
                (x, y) => x.ProjectID == y.ProjectID && x.LocalAndRegionalPlanID == y.LocalAndRegionalPlanID);
        }
    }
}