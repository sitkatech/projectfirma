using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyTierTwo = TestFramework.TestTaxonomyTierTwo.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyTierTwo);

            // Assert
            Assert.That(viewModel.TaxonomyTierTwoID, Is.EqualTo(taxonomyTierTwo.TaxonomyTierTwoID));
            Assert.That(viewModel.TaxonomyTierTwoName, Is.EqualTo(taxonomyTierTwo.TaxonomyTierTwoName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var taxonomyTierTwo = TestFramework.TestTaxonomyTierTwo.Create();
            var viewModel = new EditViewModel(taxonomyTierTwo);
            viewModel.TaxonomyTierTwoName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TaxonomyTierTwoName), Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);

            // Act
            viewModel.UpdateModel(taxonomyTierTwo, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(taxonomyTierTwo.TaxonomyTierTwoName, Is.EqualTo(viewModel.TaxonomyTierTwoName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyTierTwo = TestFramework.TestTaxonomyTierTwo.Create();
            var viewModel = new EditViewModel(taxonomyTierTwo);
            var nameOfTaxonomyTierTwoName = GeneralUtility.NameOf(() => viewModel.TaxonomyTierTwoName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyTierTwoName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyTierTwoName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyTierTwoName, Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyTierTwoName, Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);

            // Act
            // Happy path
            viewModel.TaxonomyTierTwoName = TestFramework.MakeTestName(nameOfTaxonomyTierTwoName, Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}