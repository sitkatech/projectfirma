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

namespace ProjectFirma.Web.Views.TaxonomyTrunk
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var taxonomyTrunk = TestFramework.TestTaxonomyTrunk.Create();

            // Act
            var viewModel = new EditViewModel(taxonomyTrunk);

            // Assert
            Assert.That(viewModel.TaxonomyTrunkID, Is.EqualTo(taxonomyTrunk.TaxonomyTrunkID));
            Assert.That(viewModel.TaxonomyTrunkName, Is.EqualTo(taxonomyTrunk.TaxonomyTrunkName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var taxonomyTrunk = TestFramework.TestTaxonomyTrunk.Create();
            var viewModel = new EditViewModel(taxonomyTrunk);
            viewModel.TaxonomyTrunkName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.TaxonomyTrunkName), ProjectFirmaModels.Models.TaxonomyTrunk.FieldLengths.TaxonomyTrunkName);

            // Act
            viewModel.UpdateModel(taxonomyTrunk, TestFramework.TestFirmaSession.Create());

            // Assert
            Assert.That(taxonomyTrunk.TaxonomyTrunkName, Is.EqualTo(viewModel.TaxonomyTrunkName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var taxonomyTrunk = TestFramework.TestTaxonomyTrunk.Create();
            var viewModel = new EditViewModel(taxonomyTrunk);
            var nameOfTaxonomyTrunkName = GeneralUtility.NameOf(() => viewModel.TaxonomyTrunkName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(2), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfTaxonomyTrunkName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.TaxonomyTrunkName = TestFramework.MakeTestNameLongerThan(nameOfTaxonomyTrunkName, ProjectFirmaModels.Models.TaxonomyTrunk.FieldLengths.TaxonomyTrunkName);
            viewModel.TaxonomyTrunkDescription = new HtmlString("Test Description");
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfTaxonomyTrunkName, ProjectFirmaModels.Models.TaxonomyTrunk.FieldLengths.TaxonomyTrunkName);

            // Act
            // Happy path
            viewModel.TaxonomyTrunkName = TestFramework.MakeTestName(nameOfTaxonomyTrunkName, ProjectFirmaModels.Models.TaxonomyTrunk.FieldLengths.TaxonomyTrunkName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
