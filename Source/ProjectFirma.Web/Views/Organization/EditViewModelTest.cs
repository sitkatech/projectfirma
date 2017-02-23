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
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Organization
{
    [TestFixture]
    public class EditViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var organization = TestFramework.TestOrganization.Create();

            // Act
            var viewModel = new EditViewModel(organization);

            // Assert
            Assert.That(viewModel.OrganizationID, Is.EqualTo(organization.OrganizationID));
            Assert.That(viewModel.OrganizationName, Is.EqualTo(organization.OrganizationName));
            Assert.That(viewModel.OrganizationAbbreviation, Is.EqualTo(organization.OrganizationAbbreviation));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var organization = TestFramework.TestOrganization.Create();
            var viewModel = new EditViewModel(organization);
            viewModel.OrganizationName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.OrganizationName), Models.Organization.FieldLengths.OrganizationName);
            viewModel.OrganizationAbbreviation = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.OrganizationAbbreviation), Models.Organization.FieldLengths.OrganizationAbbreviation);

            // Act
            viewModel.UpdateModel(organization, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(organization.OrganizationName, Is.EqualTo(viewModel.OrganizationName));
            Assert.That(organization.OrganizationAbbreviation, Is.EqualTo(viewModel.OrganizationAbbreviation));
        }
    }
}
