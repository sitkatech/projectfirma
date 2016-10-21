using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectWatershed
        {
            public static ProjectWatershed Create()
            {
                var project = TestProject.Create();
                var watershed = TestWatershed.Create();
                return Create(project, watershed);
            }

            public static ProjectWatershed Create(DatabaseEntities dbContext)
            {
                var project = TestProject.Create(dbContext);
                var watershed = TestWatershed.Create(dbContext);
                return Create(project, watershed);
            }

            public static ProjectWatershed Create(Project project, Watershed watershed)
            {
                var projectWatershed = ProjectWatershed.CreateNewBlank(project, watershed);
                return projectWatershed;
            }
        }
    }
}