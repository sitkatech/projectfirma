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
            viewModel.FundingSourceName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.FundingSourceName), ProjectFirmaModels.Models.FundingSource.FieldLengths.FundingSourceName);
            viewModel.OrganizationID = organization.OrganizationID;
            viewModel.IsActive = true;

            // Act
            viewModel.UpdateModel(fundingSource, TestFramework.TestFirmaSession.Create());

            // Assert
            Assert.That(fundingSource.FundingSourceName, Is.EqualTo(viewModel.FundingSourceName));
            Assert.That(fundingSource.OrganizationID, Is.EqualTo(viewModel.OrganizationID));
            Assert.That(fundingSource.IsActive, Is.EqualTo(viewModel.IsActive));
        }

    }
}
