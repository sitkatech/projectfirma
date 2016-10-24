using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    [TestFixture]
    public class BasicsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var projectUpdate = TestFramework.TestProjectUpdate.Create();

            // Act
            var viewModel = new BasicsViewModel(projectUpdate, true, null);

            // Assert
            Assert.That(viewModel.ProjectDescription, Is.EqualTo(projectUpdate.ProjectDescription));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var projectUpdate = TestFramework.TestProjectUpdate.Create();
            var viewModel = new BasicsViewModel(projectUpdate, true, null);
            viewModel.ProjectDescription = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectDescription), Models.ProjectUpdate.FieldLengths.ProjectDescription);

            // Act
            viewModel.UpdateModel(projectUpdate.ProjectUpdateBatch);

            // Assert
            Assert.That(projectUpdate.ProjectDescription, Is.EqualTo(viewModel.ProjectDescription));
        }
    }
}