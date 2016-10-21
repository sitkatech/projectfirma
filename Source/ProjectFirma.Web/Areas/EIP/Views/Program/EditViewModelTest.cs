using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.Program
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var program = TestFramework.TestProgram.Create();

            // Act
            var viewModel = new EditViewModel(program);

            // Assert
            Assert.That(viewModel.ProgramID, Is.EqualTo(program.ProgramID));
            Assert.That(viewModel.ProgramName, Is.EqualTo(program.ProgramName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var program = TestFramework.TestProgram.Create();
            var viewModel = new EditViewModel(program);
            viewModel.ProgramName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProgramName), Models.Program.FieldLengths.ProgramName);

            // Act
            viewModel.UpdateModel(program, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(program.ProgramName, Is.EqualTo(viewModel.ProgramName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var program = TestFramework.TestProgram.Create();
            var viewModel = new EditViewModel(program);
            var nameOfProgramName = GeneralUtility.NameOf(() => viewModel.ProgramName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfProgramName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.ProgramName = TestFramework.MakeTestNameLongerThan(nameOfProgramName, Models.Program.FieldLengths.ProgramName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfProgramName, Models.Program.FieldLengths.ProgramName);

            // Act
            // Happy path
            viewModel.ProgramName = TestFramework.MakeTestName(nameOfProgramName, Models.Program.FieldLengths.ProgramName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}