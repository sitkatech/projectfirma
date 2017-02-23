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

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyTierTwo = TestFramework.TestTaxonomyTierTwo.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyTierTwo);

            // Assert
            Assert.That(viewModel.TaxonomyTierTwoID, Is.EqualTo(taxonomyTierTwo.TaxonomyTierTwoID));
            Assert.That(viewModel.TaxonomyTierTwoName, Is.EqualTo(taxonomyTierTwo.TaxonomyTierTwoName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var taxonomyTierTwo = TestFramework.TestTaxonomyTierTwo.Create();
            var viewModel = new EditViewModel(taxonomyTierTwo);
            viewModel.TaxonomyTierTwoName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TaxonomyTierTwoName), Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);

            // Act
            viewModel.UpdateModel(taxonomyTierTwo, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(taxonomyTierTwo.TaxonomyTierTwoName, Is.EqualTo(viewModel.TaxonomyTierTwoName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyTierTwo = TestFramework.TestTaxonomyTierTwo.Create();
            var viewModel = new EditViewModel(taxonomyTierTwo);
            var nameOfTaxonomyTierTwoName = GeneralUtility.NameOf(() => viewModel.TaxonomyTierTwoName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyTierTwoName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyTierTwoName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyTierTwoName, Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyTierTwoName, Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);

            // Act
            // Happy path
            viewModel.TaxonomyTierTwoName = TestFramework.MakeTestName(nameOfTaxonomyTierTwoName, Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
