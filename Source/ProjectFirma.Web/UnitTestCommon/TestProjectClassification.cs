using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectClassification
        {
            public static ProjectClassification Create()
            {
                var project = TestProject.Create();
                var classification = TestClassification.Create();
                return Create(project, classification);
            }

            public static ProjectClassification Create(Project project, Classification classification)
            {
                var projectClassification = ProjectClassification.CreateNewBlank(project, classification);
                return projectClassification;
            }
        }
    }
}