using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProposedProject
        {
            public static ProposedProject Create()
            {
                var leadImplementerOrganization = TestOrganization.Create();
                var person = TestPerson.Create();
                var project = ProposedProject.CreateNewBlank(leadImplementerOrganization, person, ProjectLocationSimpleType.None, FundingType.Capital, ProposedProjectState.Draft);
                return project;
            }
        }
    }
}