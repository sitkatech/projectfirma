using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectFundingOrganization
        {
            public static ProjectFundingOrganization Create()
            {
                var project = TestProject.Create();
                var organization = TestOrganization.Create();
                return Create(project, organization);
            }

            public static ProjectFundingOrganization Create(Project project, Organization organization)
            {
                var projectFundingOrganization = ProjectFundingOrganization.CreateNewBlank(project, organization);
                return projectFundingOrganization;
            }
        }
    }
}