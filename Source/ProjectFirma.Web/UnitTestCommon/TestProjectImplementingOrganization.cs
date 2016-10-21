using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectImplementingOrganization
        {
            public static ProjectImplementingOrganization Create()
            {
                var project = TestProject.Create();
                var organization = TestOrganization.Create();
                return Create(project, organization);
            }

            public static ProjectImplementingOrganization Create(Project project)
            {
                var organization = TestOrganization.Create();
                return Create(project, organization);
            }

            public static ProjectImplementingOrganization Create(Project project, Organization organization)
            {
                var projectImplementingOrganization = ProjectImplementingOrganization.CreateNewBlank(project, organization);
                return projectImplementingOrganization;
            }
        }
    }
}