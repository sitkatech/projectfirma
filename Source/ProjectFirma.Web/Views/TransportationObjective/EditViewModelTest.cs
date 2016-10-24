using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.TransportationObjective
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var transportationObjective = TestFramework.TestTransportationObjective.Create();

            // Act
            var viewModel = new EditViewModel(transportationObjective);

            // Assert
            Assert.That(viewModel.TransportationObjectiveID, Is.EqualTo(transportationObjective.TransportationObjectiveID));
            Assert.That(viewModel.TransportationObjectiveName, Is.EqualTo(transportationObjective.TransportationObjectiveName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var transportationObjective = TestFramework.TestTransportationObjective.Create();
            var viewModel = new EditViewModel(transportationObjective);
            viewModel.TransportationObjectiveName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TransportationObjectiveName),
                Models.TransportationObjective.FieldLengths.TransportationObjectiveName);

            // Act
            viewModel.UpdateModel(transportationObjective, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(transportationObjective.TransportationObjectiveName, Is.EqualTo(viewModel.TransportationObjectiveName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var transportationObjective = TestFramework.TestTransportationObjective.Create();
            var viewModel = new EditViewModel(transportationObjective);
            var nameOfTransportationObjectiveName = GeneralUtility.NameOf(() => viewModel.TransportationObjectiveName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTransportationObjectiveName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TransportationObjectiveName = TestFramework.MakeTestNameLongerThan(nameOfTransportationObjectiveName, Models.TransportationObjective.FieldLengths.TransportationObjectiveName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTransportationObjectiveName, Models.TransportationObjective.FieldLengths.TransportationObjectiveName);

            // Act
            // Happy path
            viewModel.TransportationObjectiveName = TestFramework.MakeTestName(nameOfTransportationObjectiveName, Models.TransportationObjective.FieldLengths.TransportationObjectiveName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}