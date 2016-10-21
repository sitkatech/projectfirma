//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocalAndRegionalPlan]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocalAndRegionalPlan GetProjectLocalAndRegionalPlan(this IQueryable<ProjectLocalAndRegionalPlan> projectLocalAndRegionalPlans, int projectLocalAndRegionalPlanID)
        {
            var projectLocalAndRegionalPlan = projectLocalAndRegionalPlans.SingleOrDefault(x => x.ProjectLocalAndRegionalPlanID == projectLocalAndRegionalPlanID);
            Check.RequireNotNullThrowNotFound(projectLocalAndRegionalPlan, "ProjectLocalAndRegionalPlan", projectLocalAndRegionalPlanID);
            return projectLocalAndRegionalPlan;
        }

        public static void DeleteProjectLocalAndRegionalPlan(this IQueryable<ProjectLocalAndRegionalPlan> projectLocalAndRegionalPlans, List<int> projectLocalAndRegionalPlanIDList)
        {
            if(projectLocalAndRegionalPlanIDList.Any())
            {
                projectLocalAndRegionalPlans.Where(x => projectLocalAndRegionalPlanIDList.Contains(x.ProjectLocalAndRegionalPlanID)).Delete();
            }
        }

        public static void DeleteProjectLocalAndRegionalPlan(this IQueryable<ProjectLocalAndRegionalPlan> projectLocalAndRegionalPlans, ICollection<ProjectLocalAndRegionalPlan> projectLocalAndRegionalPlansToDelete)
        {
            if(projectLocalAndRegionalPlansToDelete.Any())
            {
                var projectLocalAndRegionalPlanIDList = projectLocalAndRegionalPlansToDelete.Select(x => x.ProjectLocalAndRegionalPlanID).ToList();
                projectLocalAndRegionalPlans.Where(x => projectLocalAndRegionalPlanIDList.Contains(x.ProjectLocalAndRegionalPlanID)).Delete();
            }
        }

        public static void DeleteProjectLocalAndRegionalPlan(this IQueryable<ProjectLocalAndRegionalPlan> projectLocalAndRegionalPlans, int projectLocalAndRegionalPlanID)
        {
            DeleteProjectLocalAndRegionalPlan(projectLocalAndRegionalPlans, new List<int> { projectLocalAndRegionalPlanID });
        }

        public static void DeleteProjectLocalAndRegionalPlan(this IQueryable<ProjectLocalAndRegionalPlan> projectLocalAndRegionalPlans, ProjectLocalAndRegionalPlan projectLocalAndRegionalPlanToDelete)
        {
            DeleteProjectLocalAndRegionalPlan(projectLocalAndRegionalPlans, new List<ProjectLocalAndRegionalPlan> { projectLocalAndRegionalPlanToDelete });
        }
    }
}