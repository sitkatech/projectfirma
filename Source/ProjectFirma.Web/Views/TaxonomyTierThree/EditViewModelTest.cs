/*-----------------------------------------------------------------------
<copyright file="EditViewModelTest.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyTierThree = TestFramework.TestTaxonomyTierThree.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyTierThree);

            // Assert
            Assert.That(viewModel.TaxonomyTierThreeID, Is.EqualTo(taxonomyTierThree.TaxonomyTierThreeID));
            Assert.That(viewModel.TaxonomyTierThreeName, Is.EqualTo(taxonomyTierThree.TaxonomyTierThreeName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var taxonomyTierThree = TestFramework.TestTaxonomyTierThree.Create();
            var viewModel = new EditViewModel(taxonomyTierThree);
            viewModel.TaxonomyTierThreeName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TaxonomyTierThreeName), Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName);

            // Act
            viewModel.UpdateModel(taxonomyTierThree, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(taxonomyTierThree.TaxonomyTierThreeName, Is.EqualTo(viewModel.TaxonomyTierThreeName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyTierThree = TestFramework.TestTaxonomyTierThree.Create();
            var viewModel = new EditViewModel(taxonomyTierThree);
            var nameOfTaxonomyTierThreeName = GeneralUtility.NameOf(() => viewModel.TaxonomyTierThreeName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(2), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyTierThreeName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyTierThreeName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyTierThreeName, Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName);
            viewModel.TaxonomyTierThreeDescription = "Test Description";
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyTierThreeName, Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName);

            // Act
            // Happy path
            viewModel.TaxonomyTierThreeName = TestFramework.MakeTestName(nameOfTaxonomyTierThreeName, Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
