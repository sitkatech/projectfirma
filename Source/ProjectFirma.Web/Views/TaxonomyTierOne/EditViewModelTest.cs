/*-----------------------------------------------------------------------
<copyright file="EditViewModelTest.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyTierOne);

            // Assert
            Assert.That(viewModel.TaxonomyTierOneID, Is.EqualTo(taxonomyTierOne.TaxonomyTierOneID));
            Assert.That(viewModel.TaxonomyTierOneName, Is.EqualTo(taxonomyTierOne.TaxonomyTierOneName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var taxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create();
            var viewModel = new EditViewModel(taxonomyTierOne);
            viewModel.TaxonomyTierOneName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TaxonomyTierOneName), Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);

            // Act
            viewModel.UpdateModel(taxonomyTierOne, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(taxonomyTierOne.TaxonomyTierOneName, Is.EqualTo(viewModel.TaxonomyTierOneName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create();
            var viewModel = new EditViewModel(taxonomyTierOne);
            var nameOfTaxonomyTierOneName = GeneralUtility.NameOf(() => viewModel.TaxonomyTierOneName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(2), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyTierOneName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyTierOneName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyTierOneName, Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);
            viewModel.TaxonomyTierOneDescription = "Test Description";
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyTierOneName, Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);

            // Act
            // Happy path
            viewModel.TaxonomyTierOneName = TestFramework.MakeTestName(nameOfTaxonomyTierOneName, Models.TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
