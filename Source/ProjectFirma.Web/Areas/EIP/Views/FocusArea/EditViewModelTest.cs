using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.FocusArea
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var focusArea = TestFramework.TestFocusArea.Create();

            // Act
            var viewModel = new EditViewModel(focusArea);

            // Assert
            Assert.That(viewModel.FocusAreaID, Is.EqualTo(focusArea.FocusAreaID));
            Assert.That(viewModel.FocusAreaName, Is.EqualTo(focusArea.FocusAreaName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var focusArea = TestFramework.TestFocusArea.Create();
            var viewModel = new EditViewModel(focusArea);
            viewModel.FocusAreaName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.FocusAreaName), Models.FocusArea.FieldLengths.FocusAreaName);

            // Act
            viewModel.UpdateModel(focusArea, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(focusArea.FocusAreaName, Is.EqualTo(viewModel.FocusAreaName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var focusArea = TestFramework.TestFocusArea.Create();
            var viewModel = new EditViewModel(focusArea);
            var nameOfFocusAreaName = GeneralUtility.NameOf(() => viewModel.FocusAreaName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfFocusAreaName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.FocusAreaName = TestFramework.MakeTestNameLongerThan(nameOfFocusAreaName, Models.FocusArea.FieldLengths.FocusAreaName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfFocusAreaName, Models.FocusArea.FieldLengths.FocusAreaName);

            // Act
            // Happy path
            viewModel.FocusAreaName = TestFramework.MakeTestName(nameOfFocusAreaName, Models.FocusArea.FieldLengths.FocusAreaName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}