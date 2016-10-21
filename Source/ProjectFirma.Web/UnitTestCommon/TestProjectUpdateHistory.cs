using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectUpdateHistory
        {
            public static ProjectUpdateHistory Create(ProjectUpdateBatch projectUpdateBatch, ProjectUpdateState projectUpdateState, Person person)
            {
                return Create(projectUpdateBatch, projectUpdateState, person, DateTime.Now);
            }

            public static ProjectUpdateHistory Create(ProjectUpdateBatch projectUpdateBatch, ProjectUpdateState projectUpdateState, Person person, DateTime transitionDate)
            {
                var projectUpdateHistory = new ProjectUpdateHistory(projectUpdateBatch, projectUpdateState, person, transitionDate);
                return projectUpdateHistory;
            }
        }
    }
}