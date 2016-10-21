using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.LocalAndRegionalPlan
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var localAndRegionalPlan = TestFramework.TestLocalAndRegionalPlan.Create();

            // Act
            var viewModel = new EditViewModel(localAndRegionalPlan);

            // Assert
            Assert.That(viewModel.LocalAndRegionalPlanID, Is.EqualTo(localAndRegionalPlan.LocalAndRegionalPlanID));
            Assert.That(viewModel.LocalAndRegionalPlanName, Is.EqualTo(localAndRegionalPlan.LocalAndRegionalPlanName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var localAndRegionalPlan = TestFramework.TestLocalAndRegionalPlan.Create();
            var viewModel = new EditViewModel(localAndRegionalPlan);
            viewModel.LocalAndRegionalPlanName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.LocalAndRegionalPlanName),
                Models.LocalAndRegionalPlan.FieldLengths.LocalAndRegionalPlanName);

            // Act
            viewModel.UpdateModel(localAndRegionalPlan, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(localAndRegionalPlan.LocalAndRegionalPlanName, Is.EqualTo(viewModel.LocalAndRegionalPlanName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var localAndRegionalPlan = TestFramework.TestLocalAndRegionalPlan.Create();
            // Make localAndRegionalPlan deficient so we'll get a validation error
            localAndRegionalPlan.LocalAndRegionalPlanName = null;
            var viewModel = new EditViewModel(localAndRegionalPlan);
            var nameOfLocalAndRegionalPlanName = GeneralUtility.NameOf(() => viewModel.LocalAndRegionalPlanName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfLocalAndRegionalPlanName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.LocalAndRegionalPlanName = TestFramework.MakeTestNameLongerThan(nameOfLocalAndRegionalPlanName, Models.LocalAndRegionalPlan.FieldLengths.LocalAndRegionalPlanName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfLocalAndRegionalPlanName, Models.LocalAndRegionalPlan.FieldLengths.LocalAndRegionalPlanName);

            // Act
            // Happy path
            viewModel.LocalAndRegionalPlanName = TestFramework.MakeTestName(nameOfLocalAndRegionalPlanName, Models.LocalAndRegionalPlan.FieldLengths.LocalAndRegionalPlanName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}