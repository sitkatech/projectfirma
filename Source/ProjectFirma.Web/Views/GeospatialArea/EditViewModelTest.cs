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
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var geospatialArea = TestFramework.TestGeospatialArea.Create();

            // Act
            var viewModel = new EditViewModel(geospatialArea);

            // Assert
            Assert.That(viewModel.GeospatialAreaID, Is.EqualTo(geospatialArea.GeospatialAreaID));
            Assert.That(viewModel.GeospatialAreaName, Is.EqualTo(geospatialArea.GeospatialAreaName));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var geospatialArea = TestFramework.TestGeospatialArea.Create();
            var viewModel = new EditViewModel(geospatialArea);
            viewModel.GeospatialAreaName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.GeospatialAreaName), Models.GeospatialArea.FieldLengths.GeospatialAreaName);

            // Act
            viewModel.UpdateModel(geospatialArea, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(geospatialArea.GeospatialAreaName, Is.EqualTo(viewModel.GeospatialAreaName));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var geospatialArea = TestFramework.TestGeospatialArea.Create();
            // Inducing an error in GeospatialArea
            geospatialArea.GeospatialAreaName = null;
            var viewModel = new EditViewModel(geospatialArea);
            var nameOfGeospatialAreaName = GeneralUtility.NameOf(() => viewModel.GeospatialAreaName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfGeospatialAreaName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.GeospatialAreaName = TestFramework.MakeTestNameLongerThan(nameOfGeospatialAreaName, Models.GeospatialArea.FieldLengths.GeospatialAreaName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfGeospatialAreaName, Models.GeospatialArea.FieldLengths.GeospatialAreaName);

            // Act
            // Happy path
            viewModel.GeospatialAreaName = TestFramework.MakeTestName(nameOfGeospatialAreaName, Models.GeospatialArea.FieldLengths.GeospatialAreaName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
