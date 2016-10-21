using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectUpdateBatch
        {
            public static ProjectUpdateBatch Create()
            {
                var project = TestProject.Create();
                return Create(project);
            }

            public static ProjectUpdateBatch Create(Project project)
            {
                var person = TestPerson.Create();
                var projectUpdateBatch = new ProjectUpdateBatch(project, DateTime.Now, false, false, false, false, false, person, ProjectUpdateState.Created, false);
                return projectUpdateBatch;
            }
        }
    }
}