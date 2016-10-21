using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.ActionPriority
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var actionPriority = TestFramework.TestActionPriority.Create();

            // Act
            var viewModel = new EditViewModel(actionPriority);

            // Assert
            Assert.That(viewModel.ActionPriorityID, Is.EqualTo(actionPriority.ActionPriorityID));
            Assert.That(viewModel.ActionPriorityName, Is.EqualTo(actionPriority.ActionPriorityName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var actionPriority = TestFramework.TestActionPriority.Create();
            var viewModel = new EditViewModel(actionPriority);
            viewModel.ActionPriorityName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ActionPriorityName), Models.ActionPriority.FieldLengths.ActionPriorityName);

            // Act
            viewModel.UpdateModel(actionPriority, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(actionPriority.ActionPriorityName, Is.EqualTo(viewModel.ActionPriorityName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var actionPriority = TestFramework.TestActionPriority.Create();
            var viewModel = new EditViewModel(actionPriority);
            var nameOfActionPriorityName = GeneralUtility.NameOf(() => viewModel.ActionPriorityName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfActionPriorityName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.ActionPriorityName = TestFramework.MakeTestNameLongerThan(nameOfActionPriorityName, Models.ActionPriority.FieldLengths.ActionPriorityName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfActionPriorityName, Models.ActionPriority.FieldLengths.ActionPriorityName);

            // Act
            // Happy path
            viewModel.ActionPriorityName = TestFramework.MakeTestName(nameOfActionPriorityName, Models.ActionPriority.FieldLengths.ActionPriorityName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}