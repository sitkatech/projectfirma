using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyTierOne);

            // Assert
            Assert.That(viewModel.TaxonomyTierOneID, Is.EqualTo(taxonomyTierOne.TaxonomyTierOneID));
            Assert.That(viewModel.TaxonomyTierOneName, Is.EqualTo(taxonomyTierOne.TaxonomyTierOneName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var taxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create();
            var viewModel = new EditViewModel(taxonomyTierOne);
            viewModel.TaxonomyTierOneName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TaxonomyTierOneName), Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);

            // Act
            viewModel.UpdateModel(taxonomyTierOne, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(taxonomyTierOne.TaxonomyTierOneName, Is.EqualTo(viewModel.TaxonomyTierOneName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create();
            var viewModel = new EditViewModel(taxonomyTierOne);
            var nameOfTaxonomyTierOneName = GeneralUtility.NameOf(() => viewModel.TaxonomyTierOneName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyTierOneName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyTierOneName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyTierOneName, Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyTierOneName, Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);

            // Act
            // Happy path
            viewModel.TaxonomyTierOneName = TestFramework.MakeTestName(nameOfTaxonomyTierOneName, Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}