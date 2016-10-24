using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.TransportationStrategy
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var transportationStrategy = TestFramework.TestTransportationStrategy.Create();

            // Act
            var viewModel = new EditViewModel(transportationStrategy);

            // Assert
            Assert.That(viewModel.TransportationStrategyID, Is.EqualTo(transportationStrategy.TransportationStrategyID));
            Assert.That(viewModel.TransportationStrategyName, Is.EqualTo(transportationStrategy.TransportationStrategyName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var transportationStrategy = TestFramework.TestTransportationStrategy.Create();
            var viewModel = new EditViewModel(transportationStrategy);
            viewModel.TransportationStrategyName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TransportationStrategyName),
                Models.TransportationStrategy.FieldLengths.TransportationStrategyName);

            // Act
            viewModel.UpdateModel(transportationStrategy, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(transportationStrategy.TransportationStrategyName, Is.EqualTo(viewModel.TransportationStrategyName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var transportationStrategy = TestFramework.TestTransportationStrategy.Create();
            var viewModel = new EditViewModel(transportationStrategy);
            var nameOfTransportationStrategyName = GeneralUtility.NameOf(() => viewModel.TransportationStrategyName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTransportationStrategyName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TransportationStrategyName = TestFramework.MakeTestNameLongerThan(nameOfTransportationStrategyName, Models.TransportationStrategy.FieldLengths.TransportationStrategyName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTransportationStrategyName, Models.TransportationStrategy.FieldLengths.TransportationStrategyName);

            // Act
            // Happy path
            viewModel.TransportationStrategyName = TestFramework.MakeTestName(nameOfTransportationStrategyName, Models.TransportationStrategy.FieldLengths.TransportationStrategyName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}