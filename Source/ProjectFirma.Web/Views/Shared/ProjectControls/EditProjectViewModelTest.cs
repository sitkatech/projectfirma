using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    [TestFixture]
    public class EditProjectViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create();

            // Act
            var viewModel = new EditProjectViewModel(project, false);

            // Assert
            Assert.That(viewModel.ProjectID, Is.EqualTo(project.ProjectID));
            Assert.That(viewModel.ProjectName, Is.EqualTo(project.ProjectName));
            Assert.That(viewModel.ProjectDescription, Is.EqualTo(project.ProjectDescription));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create();
            var viewModel = new EditProjectViewModel(project, false);
            viewModel.ProjectName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectName), Models.Project.FieldLengths.ProjectName);
            viewModel.ProjectDescription = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectDescription), Models.Project.FieldLengths.ProjectDescription);
            viewModel.LeadImplementerOrganizationID = TestFramework.TestOrganization.Create().OrganizationID;

            // Act
            viewModel.UpdateModel(project);

            // Assert
            Assert.That(project.ProjectName, Is.EqualTo(viewModel.ProjectName));
            Assert.That(project.ProjectDescription, Is.EqualTo(viewModel.ProjectDescription));
        }
    }
}