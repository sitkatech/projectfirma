using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Tag
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var tag = TestFramework.TestTag.Create();

            // Act
            var viewModel = new EditViewModel(tag);

            // Assert
            Assert.That(viewModel.TagID, Is.EqualTo(tag.TagID));
            Assert.That(viewModel.TagName, Is.EqualTo(tag.TagName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var tag = TestFramework.TestTag.Create();
            var viewModel = new EditViewModel(tag);
            viewModel.TagName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TagName), Models.Tag.FieldLengths.TagName);

            // Act
            viewModel.UpdateModel(tag, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(tag.TagName, Is.EqualTo(viewModel.TagName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var tag = TestFramework.TestTag.Create();
            // Inducing an error in Tag
            tag.TagName = null;
            var viewModel = new EditViewModel(tag);
            var nameOfTagName = GeneralUtility.NameOf(() => viewModel.TagName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTagName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TagName = TestFramework.MakeTestNameLongerThan(nameOfTagName, Models.Tag.FieldLengths.TagName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.AtLeast(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTagName, Models.Tag.FieldLengths.TagName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TagName = TestFramework.MakeTestName(string.Format("{0}&", nameOfTagName), Models.Tag.FieldLengths.TagName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);


            // Assert
            Assert.That(validationResults.Count, Is.AtLeast(1), "Expecting certain number of errors");
            TestFramework.AssertInvalidCharacters(validationResults);

            // Act
            // Happy path
            viewModel.TagName = TestFramework.MakeTestNameWithoutCertainCharacters(nameOfTagName, Models.Tag.FieldLengths.TagName, @"[^a-zA-Z0-9-_\s]");
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}