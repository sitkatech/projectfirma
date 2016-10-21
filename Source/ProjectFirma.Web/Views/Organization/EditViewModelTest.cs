using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Organization
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var organization = TestFramework.TestOrganization.Create();

            // Act
            var viewModel = new EditViewModel(organization);

            // Assert
            Assert.That(viewModel.OrganizationID, Is.EqualTo(organization.OrganizationID));
            Assert.That(viewModel.OrganizationName, Is.EqualTo(organization.OrganizationName));
            Assert.That(viewModel.OrganizationAbbreviation, Is.EqualTo(organization.OrganizationAbbreviation));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var organization = TestFramework.TestOrganization.Create();
            var viewModel = new EditViewModel(organization);
            viewModel.OrganizationName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.OrganizationName), Models.Organization.FieldLengths.OrganizationName);
            viewModel.OrganizationAbbreviation = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.OrganizationAbbreviation), Models.Organization.FieldLengths.OrganizationAbbreviation);

            // Act
            viewModel.UpdateModel(organization, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(organization.OrganizationName, Is.EqualTo(viewModel.OrganizationName));
            Assert.That(organization.OrganizationAbbreviation, Is.EqualTo(viewModel.OrganizationAbbreviation));
        }
    }
}