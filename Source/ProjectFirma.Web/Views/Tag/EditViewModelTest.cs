/*-----------------------------------------------------------------------
<copyright file="EditViewModelTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

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
            viewModel.TagName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TagName), ProjectFirmaModels.Models.Tag.FieldLengths.TagName);

            // Act
            viewModel.UpdateModel(tag, TestFramework.TestFirmaSession.Create());

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
            viewModel.TagName = TestFramework.MakeTestNameLongerThan(nameOfTagName, ProjectFirmaModels.Models.Tag.FieldLengths.TagName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.AtLeast(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTagName, ProjectFirmaModels.Models.Tag.FieldLengths.TagName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TagName = TestFramework.MakeTestName(string.Format("{0}&", nameOfTagName), ProjectFirmaModels.Models.Tag.FieldLengths.TagName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);


            // Assert
            Assert.That(validationResults.Count, Is.AtLeast(1), "Expecting certain number of errors");
            TestFramework.AssertInvalidCharacters(validationResults);

            // Act
            // Happy path
            viewModel.TagName = TestFramework.MakeTestNameWithoutCertainCharacters(nameOfTagName, ProjectFirmaModels.Models.Tag.FieldLengths.TagName, @"[^a-zA-Z0-9-_\s]");
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
