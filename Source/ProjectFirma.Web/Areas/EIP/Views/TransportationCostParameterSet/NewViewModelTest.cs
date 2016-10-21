using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationCostParameterSet
{
    [TestFixture]
    public class NewViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var transportationBudgetInflation = TestFramework.TestTransportationCostParameterSet.Create();

            // Act
            var viewModel = new NewViewModel(transportationBudgetInflation);

            // Assert
            Assert.That(viewModel.InflationRate.ToString(), Is.EqualTo(transportationBudgetInflation.InflationRate.ToStringPercent()));            
            Assert.That(viewModel.Comment, Is.EqualTo(transportationBudgetInflation.Comment));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var transportationBudgetInflation = TestFramework.TestTransportationCostParameterSet.Create();
            var viewModel = new NewViewModel(transportationBudgetInflation);
            viewModel.Comment = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.Comment), Models.TransportationCostParameterSet.FieldLengths.Comment);

            // Act
            viewModel.UpdateModel(transportationBudgetInflation, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(transportationBudgetInflation.Comment, Is.EqualTo(viewModel.Comment));
        }

        //[Test]
        //public void CanValidateModelTest()
        //{
        //    // Arrange
        //    var TransportationCostParameterSet = TestFramework.TestTransportationCostParameterSet.Create();
        //    var viewModel = new EditViewModel(TransportationCostParameterSet);
        //    var nameOfTransportationBudgetInflationComment = GeneralUtility.NameOf(() => viewModel.Comment);

        //    ICollection<ValidationResult> validationResults;

        //    // Act
        //    DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

        //    // Assert
        //    Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
        //    TestFramework.AssertFieldRequired(validationResults, nameOfTransportationBudgetInflationComment);

        //    // Act
        //    // Set string fields to string longer than their max lengths
        //    viewModel.Comment = TestFramework.MakeTestNameLongerThan(nameOfTransportationBudgetInflationComment, Models.TransportationCostParameterSet.FieldLengths.Comment);
        //    DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

        //    // Assert
        //    Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
        //    TestFramework.AssertFieldStringLength(validationResults, nameOfTransportationBudgetInflationComment, Models.TransportationCostParameterSet.FieldLengths.Comment);

        //    // Act
        //    // Happy path
        //    viewModel.Comment = TestFramework.MakeTestName(nameOfTransportationBudgetInflationComment, Models.TransportationCostParameterSet.FieldLengths.Comment);
        //    var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

        //    viewModel.StartYear = 2011;
        //    viewModel.InflationRate = 0.8m;
        //    // Assert
        //    Assert.That(isValid, Is.True, "Should pass validation");
        //}
    }
}