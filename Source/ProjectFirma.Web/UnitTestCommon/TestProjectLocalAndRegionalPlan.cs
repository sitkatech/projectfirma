using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectLocalAndRegionalPlan
        {
            public static ProjectLocalAndRegionalPlan Create()
            {
                var project = TestProject.Create();
                var localAndRegionalPlan = TestLocalAndRegionalPlan.Create();
                return Create(project, localAndRegionalPlan);
            }

            public static ProjectLocalAndRegionalPlan Create(DatabaseEntities dbContext)
            {
                var project = TestProject.Create(dbContext);
                var localAndRegionalPlan = TestLocalAndRegionalPlan.Create(dbContext);
                var projectLocalAndRegionalPlan = Create(project, localAndRegionalPlan);
                dbContext.ProjectLocalAndRegionalPlans.Add(projectLocalAndRegionalPlan);
                return projectLocalAndRegionalPlan;
            }

            public static ProjectLocalAndRegionalPlan Create(Project project, LocalAndRegionalPlan localAndRegionalPlan)
            {
                var projectLocalAndRegionalPlan = ProjectLocalAndRegionalPlan.CreateNewBlank(project, localAndRegionalPlan);
                return projectLocalAndRegionalPlan;
            }
        }
    }
}