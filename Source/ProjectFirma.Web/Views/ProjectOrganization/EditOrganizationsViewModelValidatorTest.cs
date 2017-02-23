/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModelValidatorTest.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    [TestFixture]
    public class EditOrganizationsOrganizationsViewModelValidatorTest
    {
        [Test]
        public void HasOneLeadImplementerOrNoOrganizationsTest()
        {
            var project = TestFramework.TestProject.Create();

            var primaryContact = TestFramework.TestPerson.Create();

            var organization1 = TestFramework.TestOrganization.Create();
            organization1.PrimaryContactPerson = primaryContact;
            organization1.PrimaryContactPersonID = primaryContact.PersonID;
            var organization2 = TestFramework.TestOrganization.Create();
            organization2.PrimaryContactPerson = primaryContact;
            organization2.PrimaryContactPersonID = primaryContact.PersonID;
            var organization3 = TestFramework.TestOrganization.Create();
            organization3.PrimaryContactPerson = primaryContact;
            organization3.PrimaryContactPersonID = primaryContact.PersonID;

            var validator = new EditOrganizationsViewModelValidator(new List<Models.Organization> {organization1, organization2, organization3});

            var projectImplementingOrganization1 = TestFramework.TestProjectImplementingOrganization.Create(project, organization1);
            var projectImplementingOrganization2 = TestFramework.TestProjectImplementingOrganization.Create(project, organization2);
            var projectFundingOrganization1 = TestFramework.TestProjectFundingOrganization.Create(project, organization3);
            var projectFundingOrganization2 = TestFramework.TestProjectFundingOrganization.Create(project, organization2);

            var projectImplementingOrganizationOrProjectFundingOrganization1 = new ProjectImplementingOrganizationOrProjectFundingOrganization(null, projectFundingOrganization1);
            var projectImplementingOrganizationOrProjectFundingOrganization2 = new ProjectImplementingOrganizationOrProjectFundingOrganization(projectImplementingOrganization2,
                projectFundingOrganization2);
            var projectImplementingOrganizationOrProjectFundingOrganization3 = new ProjectImplementingOrganizationOrProjectFundingOrganization(projectImplementingOrganization1, null);

            var projectImplementingOrganizationOrProjectFundingOrganizations = new List<ProjectImplementingOrganizationOrProjectFundingOrganization>();
            var viewModel = new EditOrganizationsViewModel(projectImplementingOrganizationOrProjectFundingOrganizations);

            // no organizations should be ok
            validator.ShouldHaveValidationErrorFor(person => person.ProjectOrganizationsViewModelJson, viewModel);

            projectImplementingOrganizationOrProjectFundingOrganizations.Add(projectImplementingOrganizationOrProjectFundingOrganization3);
            projectImplementingOrganizationOrProjectFundingOrganizations.Add(projectImplementingOrganizationOrProjectFundingOrganization2);
            projectImplementingOrganizationOrProjectFundingOrganizations.Add(projectImplementingOrganizationOrProjectFundingOrganization1);
            SetProjectOrganizationsViewModelJson(viewModel, projectImplementingOrganizationOrProjectFundingOrganizations, null);

            // no lead set so should have an error
            validator.ShouldHaveValidationErrorFor(person => person.ProjectOrganizationsViewModelJson, viewModel);

            // only one lead set should be happy

            var leadOrganizationID = projectImplementingOrganization1.OrganizationID;

            SetProjectOrganizationsViewModelJson(viewModel, projectImplementingOrganizationOrProjectFundingOrganizations, leadOrganizationID);
            validator.ShouldNotHaveValidationErrorFor(person => person.ProjectOrganizationsViewModelJson, viewModel);
        }

        private static void SetProjectOrganizationsViewModelJson(EditOrganizationsViewModel viewModel,
            IEnumerable<ProjectImplementingOrganizationOrProjectFundingOrganization> projectImplementingOrganizationOrProjectFundingOrganizations,
            int? leadOrganizationID)
        {
            viewModel.ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(leadOrganizationID,
                projectImplementingOrganizationOrProjectFundingOrganizations.Select(po => new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(po)).ToList());
        }
    }
}
