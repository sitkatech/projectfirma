using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProposedProject
{
    [TestFixture]
    public class BasicsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var proposedProject = TestFramework.TestProposedProject.Create();

            // Act
            var viewModel = new BasicsViewModel(proposedProject);

            // Assert
            Assert.That(viewModel.ProposedProjectID, Is.EqualTo(proposedProject.ProposedProjectID));
            Assert.That(viewModel.ProjectName, Is.EqualTo(proposedProject.ProjectName));
            Assert.That(viewModel.ProjectDescription, Is.EqualTo(proposedProject.ProjectDescription));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var proposedProject = TestFramework.TestProposedProject.Create();
            var viewModel = new BasicsViewModel(proposedProject);
            viewModel.ProjectName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectName), Models.ProposedProject.FieldLengths.ProjectName);
            viewModel.ProjectDescription = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectDescription), Models.ProposedProject.FieldLengths.ProjectDescription);
            viewModel.LeadImplementerOrganizationID = TestFramework.TestOrganization.Create().OrganizationID;

            // Act            
            viewModel.UpdateModel(proposedProject, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(proposedProject.ProjectName, Is.EqualTo(viewModel.ProjectName));
            Assert.That(proposedProject.ProjectDescription, Is.EqualTo(viewModel.ProjectDescription));
        }
    }
}