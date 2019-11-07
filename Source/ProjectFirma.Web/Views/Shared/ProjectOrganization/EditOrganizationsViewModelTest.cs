/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModelTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ApprovalTests.Reporters;
using NUnit.Framework;
using ProjectFirmaModels.Models;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Views.Shared.ProjectOrganization
{
    [TestFixture]
    public class EditOrganizationsViewModelTest
    {
        private List<ProjectFirmaModels.Models.ProjectOrganization> _projectOrganizations;
        private ProjectFirmaModels.Models.Project _project;
        private List<ProjectFirmaModels.Models.Organization> _allOrganizations;
        private ProjectFirmaModels.Models.Organization _organization1;
        private ProjectFirmaModels.Models.Organization _organization2;
        private ProjectFirmaModels.Models.Organization _organization3;

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

            var projectOrganization1 = TestFramework.TestProjectOrganization.Create(_project, _organization1);
            var projectOrganization2 = TestFramework.TestProjectOrganization.Create(_project, _organization2);
            var projectOrganization3 = TestFramework.TestProjectOrganization.Create(_project, _organization3);
            _projectOrganizations = new List<ProjectFirmaModels.Models.ProjectOrganization> { projectOrganization1, projectOrganization2, projectOrganization3 };
            _allOrganizations = new List<ProjectFirmaModels.Models.Organization> {_organization1, _organization2, _organization3};
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Act
            var viewModel = new EditOrganizationsViewModel(_project, _projectOrganizations, TestFramework.TestFirmaSession.Create());

            // Assert
            Assert.That(viewModel.ProjectOrganizationSimples, Is.Not.Null);
        }

        [Test]
        [Ignore]
        public void UpdateModelTest()
        {
            //// Arrange
            //var viewModel = new EditOrganizationsViewModel();
            //var projectOrganizationJson1 = new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(_organization1.OrganizationID, _organization1.OrganizationName, true, false);
            //var projectOrganizationJson2 = new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(_organization2.OrganizationID, _organization2.OrganizationName, false, true);
            //var projectOrganizationJson3 = new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(_organization3.OrganizationID, _organization3.OrganizationName, true, true);
            //var projectOrganizationJsons = new List<ProjectOrganizationsViewModelJson.ProjectOrganizationJson> {projectOrganizationJson1, projectOrganizationJson2, projectOrganizationJson3};
            //viewModel.ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(_organization3.OrganizationID, projectOrganizationJsons);

            //// Act
            //viewModel.UpdateModel(_project, _projectFundingOrganizations, _projectImplementingOrganizations);

            //// Assert
            //Assert.That(_project.ProjectFundingOrganizations.Select(x => x.OrganizationID),
            //    Is.EquivalentTo(new List<int> {projectOrganizationJson1.OrganizationID, projectOrganizationJson3.OrganizationID}));
            //Assert.That(_project.ProjectImplementingOrganizations.Select(x => x.OrganizationID),
            //    Is.EquivalentTo(new List<int> {projectOrganizationJson2.OrganizationID, projectOrganizationJson3.OrganizationID}));
            //Assert.That(_project.ProjectImplementingOrganizations.Single(x => x.IsLeadOrganization).OrganizationID, Is.EqualTo(projectOrganizationJson3.OrganizationID));
            //Assert.That(_projectFundingOrganizations.Select(x => x.OrganizationID), Is.EquivalentTo(new List<int> {projectOrganizationJson1.OrganizationID, projectOrganizationJson3.OrganizationID}));
            //Assert.That(_projectImplementingOrganizations.Select(x => x.OrganizationID),
            //    Is.EquivalentTo(new List<int> {projectOrganizationJson2.OrganizationID, projectOrganizationJson3.OrganizationID}));
        }
    }
}
