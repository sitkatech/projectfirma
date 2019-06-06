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

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyBranch = TestFramework.TestTaxonomyBranch.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyBranch);

            // Assert
            Assert.That(viewModel.TaxonomyBranchID, Is.EqualTo(taxonomyBranch.TaxonomyBranchID));
            Assert.That(viewModel.TaxonomyBranchName, Is.EqualTo(taxonomyBranch.TaxonomyBranchName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyBranch = TestFramework.TestTaxonomyBranch.Create();
            var viewModel = new EditViewModel(taxonomyBranch);
            var nameOfTaxonomyBranchName = GeneralUtility.NameOf(() => viewModel.TaxonomyBranchName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyBranchName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyBranchName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyBranchName, ProjectFirmaModels.Models.TaxonomyBranch.FieldLengths.TaxonomyBranchName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyBranchName, ProjectFirmaModels.Models.TaxonomyBranch.FieldLengths.TaxonomyBranchName);

            // Act
            // Happy path
            viewModel.TaxonomyBranchName = TestFramework.MakeTestName(nameOfTaxonomyBranchName, ProjectFirmaModels.Models.TaxonomyBranch.FieldLengths.TaxonomyBranchName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
