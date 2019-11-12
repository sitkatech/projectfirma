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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Views.TaxonomyLeaf
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyLeaf = TestFramework.TestTaxonomyLeaf.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyLeaf);

            // Assert
            Assert.That(viewModel.TaxonomyLeafID, Is.EqualTo(taxonomyLeaf.TaxonomyLeafID));
            Assert.That(viewModel.TaxonomyLeafName, Is.EqualTo(taxonomyLeaf.TaxonomyLeafName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var taxonomyLeaf = TestFramework.TestTaxonomyLeaf.Create();
            var viewModel = new EditViewModel(taxonomyLeaf);
            viewModel.TaxonomyLeafName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TaxonomyLeafName), ProjectFirmaModels.Models.TaxonomyLeaf.FieldLengths.TaxonomyLeafName);

            // Act
            viewModel.UpdateModel(taxonomyLeaf, TestFramework.TestFirmaSession.Create());

            // Assert
            Assert.That(taxonomyLeaf.TaxonomyLeafName, Is.EqualTo(viewModel.TaxonomyLeafName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyLeaf = TestFramework.TestTaxonomyLeaf.Create();
            var viewModel = new EditViewModel(taxonomyLeaf);
            var nameOfTaxonomyLeafName = GeneralUtility.NameOf(() => viewModel.TaxonomyLeafName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(2), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyLeafName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyLeafName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyLeafName, ProjectFirmaModels.Models.TaxonomyLeaf.FieldLengths.TaxonomyLeafName);
            viewModel.TaxonomyLeafDescription = new HtmlString("Test Description");
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyLeafName, ProjectFirmaModels.Models.TaxonomyLeaf.FieldLengths.TaxonomyLeafName);

            // Act
            // Happy path
            viewModel.TaxonomyLeafName = TestFramework.MakeTestName(nameOfTaxonomyLeafName, ProjectFirmaModels.Models.TaxonomyLeaf.FieldLengths.TaxonomyLeafName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
