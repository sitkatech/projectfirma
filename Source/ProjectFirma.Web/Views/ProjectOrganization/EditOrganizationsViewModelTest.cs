/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModelTest.cs" company="Tahoe Regional Planning Agency">
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
using ApprovalTests.Reporters;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    [TestFixture]
    public class EditOrganizationsViewModelTest
    {
        private List<ProjectImplementingOrganizationOrProjectFundingOrganization> _projectImplementingOrganizationOrProjectFundingOrganizations;
        private Models.Project _project;
        private List<ProjectFundingOrganization> _projectFundingOrganizations;
        private List<ProjectImplementingOrganization> _projectImplementingOrganizations;
        private List<Models.Organization> _allOrganizations;
        private Models.Organization _organization1;
        private Models.Organization _organization2;
        private Models.Organization _organization3;

        [SetUp]
        public void Setup()
        {
            _project = TestFramework.TestProject.Create();

            _organization1 = TestFramework.TestOrganization.Create();
            _organization1.OrganizationID = 77777;
            _organization1.OrganizationName = "Organization 77777";
            _organization2 = TestFramework.TestOrganization.Create();
            _organization2.OrganizationID = 88888;
            _organization2.OrganizationName = "Organization 88888";
            _organization3 = TestFramework.TestOrganization.Create();
            _organization3.OrganizationID = 99999;
            _organization3.OrganizationName = "Organization 99999";

            var projectImplementingOrganization1 = TestFramework.TestProjectImplementingOrganization.Create(_project, _organization1);
            var projectImplementingOrganization2 = TestFramework.TestProjectImplementingOrganization.Create(_project, _organization2);
            projectImplementingOrganization1.IsLeadOrganization = true;
            _projectImplementingOrganizations = new List<ProjectImplementingOrganization> {projectImplementingOrganization1, projectImplementingOrganization2};
            _allOrganizations = new List<Models.Organization> {_organization1, _organization2, _organization3};
            var projectFundingOrganization1 = TestFramework.TestProjectFundingOrganization.Create(_project, _organization3);
            var projectFundingOrganization2 = TestFramework.TestProjectFundingOrganization.Create(_project, _organization2);
            _projectFundingOrganizations = new List<ProjectFundingOrganization> {projectFundingOrganization1, projectFundingOrganization2};

            var projectImplementingOrganizationOrProjectFundingOrganization1 = new ProjectImplementingOrganizationOrProjectFundingOrganization(null, projectFundingOrganization1);
            var projectImplementingOrganizationOrProjectFundingOrganization2 = new ProjectImplementingOrganizationOrProjectFundingOrganization(projectImplementingOrganization2,
                projectFundingOrganization2);
            var projectImplementingOrganizationOrProjectFundingOrganization3 = new ProjectImplementingOrganizationOrProjectFundingOrganization(projectImplementingOrganization1, null);

            _projectImplementingOrganizationOrProjectFundingOrganizations = new List<ProjectImplementingOrganizationOrProjectFundingOrganization>
            {
                projectImplementingOrganizationOrProjectFundingOrganization3,
                projectImplementingOrganizationOrProjectFundingOrganization2,
                projectImplementingOrganizationOrProjectFundingOrganization1
            };
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Act
            var viewModel = new EditOrganizationsViewModel(_projectImplementingOrganizationOrProjectFundingOrganizations);

            // Assert
            Assert.That(viewModel.ProjectOrganizationsViewModelJson, Is.Not.Null);
            ObjectApproval.ObjectApprover.VerifyWithJson(viewModel.ProjectOrganizationsViewModelJson);
        }

        [Test]
        [Ignore]
        public void UpdateModelTest()
        {
            // Arrange
            var viewModel = new EditOrganizationsViewModel();
            var projectOrganizationJson1 = new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(_organization1.OrganizationID, _organization1.OrganizationName, true, false);
            var projectOrganizationJson2 = new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(_organization2.OrganizationID, _organization2.OrganizationName, false, true);
            var projectOrganizationJson3 = new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(_organization3.OrganizationID, _organization3.OrganizationName, true, true);
            var projectOrganizationJsons = new List<ProjectOrganizationsViewModelJson.ProjectOrganizationJson> {projectOrganizationJson1, projectOrganizationJson2, projectOrganizationJson3};
            viewModel.ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(_organization3.OrganizationID, projectOrganizationJsons);

            // Act
            viewModel.UpdateModel(_project, _projectFundingOrganizations, _projectImplementingOrganizations);

            // Assert
            Assert.That(_project.ProjectFundingOrganizations.Select(x => x.OrganizationID),
                Is.EquivalentTo(new List<int> {projectOrganizationJson1.OrganizationID, projectOrganizationJson3.OrganizationID}));
            Assert.That(_project.ProjectImplementingOrganizations.Select(x => x.OrganizationID),
                Is.EquivalentTo(new List<int> {projectOrganizationJson2.OrganizationID, projectOrganizationJson3.OrganizationID}));
            Assert.That(_project.ProjectImplementingOrganizations.Single(x => x.IsLeadOrganization).OrganizationID, Is.EqualTo(projectOrganizationJson3.OrganizationID));
            Assert.That(_projectFundingOrganizations.Select(x => x.OrganizationID), Is.EquivalentTo(new List<int> {projectOrganizationJson1.OrganizationID, projectOrganizationJson3.OrganizationID}));
            Assert.That(_projectImplementingOrganizations.Select(x => x.OrganizationID),
                Is.EquivalentTo(new List<int> {projectOrganizationJson2.OrganizationID, projectOrganizationJson3.OrganizationID}));
        }
    }
}
