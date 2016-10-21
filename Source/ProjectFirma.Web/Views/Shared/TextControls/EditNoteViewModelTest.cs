using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    [TestFixture]
    public class EditNoteViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var projectNote = TestFramework.TestProjectNote.Create();

            // Act
            var viewModel = new EditNoteViewModel(projectNote.Note);

            // Assert
            Assert.That(viewModel.Note, Is.EqualTo(projectNote.Note));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var projectNote = TestFramework.TestProjectNote.Create();
            var viewModel = new EditNoteViewModel(projectNote.Note);
            viewModel.Note = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.Note), Models.ProjectNote.FieldLengths.Note);

            // Act
            viewModel.UpdateModel(projectNote, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(projectNote.Note, Is.EqualTo(viewModel.Note));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var projectNote = TestFramework.TestProjectNote.Create();
            // Inducing errors in projectNote
            projectNote.Note = null;
            var viewModel = new EditNoteViewModel(projectNote.Note);
            var nameOfNote = GeneralUtility.NameOf(() => viewModel.Note);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfNote);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.Note = TestFramework.MakeTestNameLongerThan(nameOfNote, Models.ProjectNote.FieldLengths.Note);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfNote, Models.ProjectNote.FieldLengths.Note);

            // Act
            // Happy path
            viewModel.Note = TestFramework.MakeTestName(nameOfNote, Models.ProjectNote.FieldLengths.Note);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}