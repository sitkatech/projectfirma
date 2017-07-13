/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModelValidatorTest.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    [TestFixture]
    public class EditOrganizationsViewModelValidatorTest
    {
        [Test]
        public void HasOneLeadImplementerOrNoOrganizationsTest()
        {
            var project = TestFramework.TestProject.Create();

            var primaryContact = TestFramework.TestPerson.Create();

            var organization1 = TestFramework.TestOrganization.Create("SomeOrg1");
            organization1.PrimaryContactPerson = primaryContact;
            organization1.PrimaryContactPersonID = primaryContact.PersonID;
            var organization2 = TestFramework.TestOrganization.Create("SomeOrg2");
            organization2.PrimaryContactPerson = primaryContact;
            organization2.PrimaryContactPersonID = primaryContact.PersonID;
            var organization3 = TestFramework.TestOrganization.Create("SomeOrg3");
            organization3.PrimaryContactPerson = primaryContact;
            organization3.PrimaryContactPersonID = primaryContact.PersonID;

            var validator = new EditOrganizationsViewModelValidator(new List<Models.Organization> {organization1, organization2, organization3});

            var projectOrganization1 = TestFramework.TestProjectOrganization.Create(project, organization1);
            var projectOrganization2 = TestFramework.TestProjectOrganization.Create(project, organization2);
            var projectOrganization3 = TestFramework.TestProjectOrganization.Create(project, organization3);
            
           
            var projectOrganizations = new List<Models.ProjectOrganization>();
            var viewModel = new EditOrganizationsViewModel(projectOrganizations, project);

            // no organizations should be ok
            validator.ShouldHaveValidationErrorFor(person => person.ProjectOrganizationsViewModelJson, viewModel);

            projectOrganizations.Add(projectOrganization1);
            projectOrganizations.Add(projectOrganization2);
            projectOrganizations.Add(projectOrganization3);
            SetProjectOrganizationsViewModelJson(viewModel, projectOrganizations, null);

            // no lead set so should have an error
            validator.ShouldHaveValidationErrorFor(person => person.ProjectOrganizationsViewModelJson, viewModel);

            // only one lead set should be happy

            project.LeadImplementerOrganization = projectOrganization1.Organization;
            var leadOrganizationID = projectOrganization1.OrganizationID;

            SetProjectOrganizationsViewModelJson(viewModel, projectOrganizations, leadOrganizationID);
            validator.ShouldNotHaveValidationErrorFor(person => person.ProjectOrganizationsViewModelJson, viewModel);
        }

        private static void SetProjectOrganizationsViewModelJson(EditOrganizationsViewModel viewModel,
            IEnumerable<Models.ProjectOrganization> projectOrganizations,
            int? leadOrganizationID)
        {
            viewModel.ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(leadOrganizationID,
                projectOrganizations.GroupBy(x => x.Organization).Select(po => new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(po.Key, po.ToList())).ToList());
        }
    }
}
