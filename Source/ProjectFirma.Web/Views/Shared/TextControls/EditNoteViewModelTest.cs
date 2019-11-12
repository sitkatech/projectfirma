/*-----------------------------------------------------------------------
<copyright file="EditNoteViewModelTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
            viewModel.Note = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.Note), ProjectFirmaModels.Models.ProjectNote.FieldLengths.Note);

            // Act
            viewModel.UpdateModel(projectNote, TestFramework.TestFirmaSession.Create());

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
            viewModel.Note = TestFramework.MakeTestNameLongerThan(nameOfNote, ProjectFirmaModels.Models.ProjectNote.FieldLengths.Note);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfNote, ProjectFirmaModels.Models.ProjectNote.FieldLengths.Note);

            // Act
            // Happy path
            viewModel.Note = TestFramework.MakeTestName(nameOfNote, ProjectFirmaModels.Models.ProjectNote.FieldLengths.Note);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
