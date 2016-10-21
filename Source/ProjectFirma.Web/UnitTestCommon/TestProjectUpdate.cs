using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectUpdate
        {
            public static ProjectUpdate Create()
            {
                var projectUpdateBatch = TestProjectUpdateBatch.Create();
                return Create(projectUpdateBatch);
            }

            public static ProjectUpdate Create(ProjectUpdateBatch projectUpdateBatch)
            {
                var projectUpdate = new ProjectUpdate(projectUpdateBatch, ProjectStage.PlanningDesign, MakeTestName("Project Description"), ProjectLocationSimpleType.None);
                projectUpdateBatch.ProjectUpdate = projectUpdate;
                return projectUpdate;
            }
        }
    }
}