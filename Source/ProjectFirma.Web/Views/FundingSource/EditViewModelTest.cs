/*-----------------------------------------------------------------------
<copyright file="EditViewModelTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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

namespace ProjectFirma.Web.Views.FundingSource
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var fundingSource = TestFramework.TestFundingSource.Create();

            // Act
            var viewModel = new EditViewModel(fundingSource);

            // Assert
            Assert.That(viewModel.FundingSourceID, Is.EqualTo(fundingSource.FundingSourceID));
            Assert.That(viewModel.FundingSourceName, Is.EqualTo(fundingSource.FundingSourceName));
            Assert.That(viewModel.OrganizationID, Is.EqualTo(fundingSource.OrganizationID));
            Assert.That(viewModel.IsActive, Is.EqualTo(fundingSource.IsActive));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var organization = TestFramework.TestOrganization.Create();
            var fundingSource = TestFramework.TestFundingSource.Create();
            var viewModel = new EditViewModel(fundingSource);
            viewModel.FundingSourceName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.FundingSourceName), Models.FundingSource.FieldLengths.FundingSourceName);
            viewModel.OrganizationID = organization.OrganizationID;
            viewModel.IsActive = true;

            // Act
            viewModel.UpdateModel(fundingSource, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(fundingSource.FundingSourceName, Is.EqualTo(viewModel.FundingSourceName));
            Assert.That(fundingSource.OrganizationID, Is.EqualTo(viewModel.OrganizationID));
            Assert.That(fundingSource.IsActive, Is.EqualTo(viewModel.IsActive));
        }

        [Test]
        public void CanValidateModelTest()
        {
            // Arrange
            var fundingSource = TestFramework.TestFundingSource.Create();
            var viewModel = new EditViewModel(fundingSource);
            var nameOfFundingSourceName = GeneralUtility.NameOf(() => viewModel.FundingSourceName);

            ICollection<ValidationResult> validationResults;

            // Act
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldRequired(validationResults, nameOfFundingSourceName);

            // Act
            // Set string fields to string longer than their max lengths
            viewModel.FundingSourceName = TestFramework.MakeTestNameLongerThan(nameOfFundingSourceName, Models.FundingSource.FieldLengths.FundingSourceName);
            DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
            TestFramework.AssertFieldStringLength(validationResults, nameOfFundingSourceName, Models.FundingSource.FieldLengths.FundingSourceName);

            // Act
            // Happy path
            viewModel.FundingSourceName = TestFramework.MakeTestName(nameOfFundingSourceName, Models.FundingSource.FieldLengths.FundingSourceName);
            var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

            // Assert
            Assert.That(isValid, Is.True, "Should pass validation");
        }
    }
}
