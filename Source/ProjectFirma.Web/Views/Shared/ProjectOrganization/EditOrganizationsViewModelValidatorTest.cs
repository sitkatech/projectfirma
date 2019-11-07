/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModelValidatorTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using NUnit.Framework;
using ProjectFirmaModels.Models;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Views.Shared.ProjectOrganization
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

           

            var projectOrganization1 = TestFramework.TestProjectOrganization.Create(project, organization1);
            var projectOrganization2 = TestFramework.TestProjectOrganization.Create(project, organization2);
            var projectOrganization3 = TestFramework.TestProjectOrganization.Create(project, organization3);
            
           
            var projectOrganizations = new List<ProjectFirmaModels.Models.ProjectOrganization>();
            var viewModel = new EditOrganizationsViewModel(project, projectOrganizations, TestFramework.TestFirmaSession.Create());

            //TODO tests
        }
    }
}
