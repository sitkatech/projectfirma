using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestLocalAndRegionalPlan
        {
            public static LocalAndRegionalPlan Create()
            {
                var localAndRegionalPlan = LocalAndRegionalPlan.CreateNewBlank();
                localAndRegionalPlan.LocalAndRegionalPlanName = MakeTestLocalAndRegionalPlanName();
                return localAndRegionalPlan;
            }

            public static LocalAndRegionalPlan Create(DatabaseEntities dbContext)
            {
                var localAndRegionalPlan = LocalAndRegionalPlan.CreateNewBlank();
                localAndRegionalPlan.LocalAndRegionalPlanName = MakeTestLocalAndRegionalPlanName();
                dbContext.LocalAndRegionalPlans.Add(localAndRegionalPlan);
                return localAndRegionalPlan;
            }

            private static string MakeTestLocalAndRegionalPlanName()
            {
                return MakeTestName("Test Local and Regional Plan Name", LocalAndRegionalPlan.FieldLengths.LocalAndRegionalPlanName);
            }
        }
    }
}