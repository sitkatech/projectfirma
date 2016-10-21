using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Watershed
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var watershed = TestFramework.TestWatershed.Create();

            // Act
            var viewModel = new EditViewModel(watershed);

            // Assert
            Assert.That(viewModel.WatershedID, Is.EqualTo(watershed.WatershedID));
            Assert.That(viewModel.WatershedName, Is.EqualTo(watershed.WatershedName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var watershed = TestFramework.TestWatershed.Create();
            var viewModel = new EditViewModel(watershed);
            viewModel.WatershedName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.WatershedName), Models.Watershed.FieldLengths.WatershedName);

            // Act
            viewModel.UpdateModel(watershed, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(watershed.WatershedName, Is.EqualTo(viewModel.WatershedName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var watershed = TestFramework.TestWatershed.Create();
            // Inducing an error in Watershed
            watershed.WatershedName = null;
            var viewModel = new EditViewModel(watershed);
            var nameOfWatershedName = GeneralUtility.NameOf(() => viewModel.WatershedName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfWatershedName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.WatershedName = TestFramework.MakeTestNameLongerThan(nameOfWatershedName, Models.Watershed.FieldLengths.WatershedName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfWatershedName, Models.Watershed.FieldLengths.WatershedName);

            // Act
            // Happy path
            viewModel.WatershedName = TestFramework.MakeTestName(nameOfWatershedName, Models.Watershed.FieldLengths.WatershedName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}