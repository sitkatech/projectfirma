using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectThresholdCategory
        {
            public static ProjectThresholdCategory Create()
            {
                var project = TestProject.Create();
                var thresholdCategory = TestThresholdCategory.Create();
                return Create(project, thresholdCategory);
            }

            public static ProjectThresholdCategory Create(Project project, ThresholdCategory thresholdCategory)
            {
                var projectThresholdCategory = ProjectThresholdCategory.CreateNewBlank(project, thresholdCategory);
                return projectThresholdCategory;
            }
        }
    }
}