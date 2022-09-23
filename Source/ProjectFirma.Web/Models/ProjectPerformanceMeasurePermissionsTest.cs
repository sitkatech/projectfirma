/*-----------------------------------------------------------------------
<copyright file="ProjectPerformanceMeasurePermissionsTest.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using ProjectFirma.Web.Security;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.UnitTestCommon;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirmaModels.Models
{
    [TestFixture]
    public class ProjectPerformanceMeasurePermissionsTest
    {
        [Test]
        public void ProjectProposedTest()
        {
            var projectEditAsAdminFeature = new ProjectEditAsAdminFeature();
            var projectsInProposalStageViewListFeature = new ProjectsInProposalStageViewListFeature();

            // Test organizations we'll use for membership checks
            var testOrganizationForProject = TestFramework.TestOrganization.Create("The Test Organization for Project");
            var testOrganizationJustForUser = TestFramework.TestOrganization.Create("The Test Organization for User");

            Person userAnonymous = null;

            var userNormal = TestFramework.TestPerson.Create();
            userNormal.RoleID = Role.Normal.RoleID;

            var userAdmin = TestFramework.TestPerson.Create();
            userAdmin.RoleID = Role.Admin.RoleID;

            var userSitkaAdmin = TestFramework.TestPerson.Create();
            userSitkaAdmin.RoleID = Role.SitkaAdmin.RoleID;

            // Deferred Project
            // ----------------
            {
                // Deferred Project
                var deferredProject = TestFramework.TestProject.Create();
                deferredProject.ProjectStageID = ProjectStage.Deferred.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, projectsInProposalStageViewListFeature, false);
                TestExpectedUserPermission(userNormal, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userAdmin, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, projectsInProposalStageViewListFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, deferredProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userNormal, deferredProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userAdmin, deferredProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, deferredProject, projectEditAsAdminFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, deferredProject, projectEditAsAdminFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    deferredProject,
                    projectEditAsAdminFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                
                TestExpectedUserPermission(userAdmin, deferredProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, deferredProject, projectEditAsAdminFeature, true);
            }

            // Planning/Design Project
            // -----------------------
            {
                // Planning / Design Project
                var planningDesignProject = TestFramework.TestProject.Create();
                planningDesignProject.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, projectsInProposalStageViewListFeature, false);
                TestExpectedUserPermission(userNormal, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userAdmin, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, projectsInProposalStageViewListFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userNormal, planningDesignProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userAdmin, planningDesignProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, projectEditAsAdminFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, planningDesignProject, projectEditAsAdminFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    planningDesignProject,
                    projectEditAsAdminFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, planningDesignProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, projectEditAsAdminFeature, true);
            }

            // Implementation Project
            // -----------------------
            {
                // Implementation Project
                var implementationProject = TestFramework.TestProject.Create();
                implementationProject.ProjectStageID = ProjectStage.Implementation.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, projectsInProposalStageViewListFeature, false);
                TestExpectedUserPermission(userNormal, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userAdmin, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, projectsInProposalStageViewListFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, implementationProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userNormal, implementationProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userAdmin, implementationProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, implementationProject, projectEditAsAdminFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, implementationProject, projectEditAsAdminFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    implementationProject,
                    projectEditAsAdminFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, implementationProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, implementationProject, projectEditAsAdminFeature, true);
            }

            // Post-Implementation Project
            // -----------------------
            {
                // Post-Implementation Project
                var postImplementationProject = TestFramework.TestProject.Create();
                postImplementationProject.ProjectStageID = ProjectStage.PostImplementation.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, projectsInProposalStageViewListFeature, false);
                TestExpectedUserPermission(userNormal, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userAdmin, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, projectsInProposalStageViewListFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, postImplementationProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userNormal, postImplementationProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userAdmin, postImplementationProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, postImplementationProject, projectEditAsAdminFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, postImplementationProject, projectEditAsAdminFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    postImplementationProject,
                    projectEditAsAdminFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, postImplementationProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, postImplementationProject, projectEditAsAdminFeature, true);
            }

            // Completed Project
            // -----------------------
            {
                // Completed Project
                var completedProject = TestFramework.TestProject.Create();
                completedProject.ProjectStageID = ProjectStage.Completed.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, projectsInProposalStageViewListFeature, false);
                TestExpectedUserPermission(userNormal, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userAdmin, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, projectsInProposalStageViewListFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, completedProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userNormal, completedProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userAdmin, completedProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, completedProject, projectEditAsAdminFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, completedProject, projectEditAsAdminFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    completedProject,
                    projectEditAsAdminFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, completedProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, completedProject, projectEditAsAdminFeature, true);
            }

            // Terminated Project
            // -----------------------
            {
                // Terminated Project
                var terminatedProject = TestFramework.TestProject.Create();
                terminatedProject.ProjectStageID = ProjectStage.Terminated.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, projectsInProposalStageViewListFeature, false);
                TestExpectedUserPermission(userNormal, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userAdmin, projectsInProposalStageViewListFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, projectsInProposalStageViewListFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, terminatedProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userNormal, terminatedProject, projectEditAsAdminFeature, false);
                TestExpectedUserPermission(userAdmin, terminatedProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, terminatedProject, projectEditAsAdminFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, terminatedProject, projectEditAsAdminFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    terminatedProject,
                    projectEditAsAdminFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, terminatedProject, projectEditAsAdminFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, terminatedProject, projectEditAsAdminFeature, true);
            }
        }

        [Test]
        public void ProjectEditReportedPerformanceMeasureTest()
        {
            var editPerformanceMeasureActualFeature = new PerformanceMeasureActualFromProjectManageFeature();

            // Test organizations we'll use for membership checks
            var testOrganizationForProject = TestFramework.TestOrganization.Create("The Test Organization for Project");
            var testOrganizationJustForUser = TestFramework.TestOrganization.Create("The Test Organization for User");

            Person userAnonymous = null;

            var userNormal = TestFramework.TestPerson.Create();
            userNormal.RoleID = Role.Normal.RoleID;

            var userAdmin = TestFramework.TestPerson.Create();
            userAdmin.RoleID = Role.Admin.RoleID;

            var userSitkaAdmin = TestFramework.TestPerson.Create();
            userSitkaAdmin.RoleID = Role.SitkaAdmin.RoleID;

            // Planning/Design Project
            // ----------------
            {
                var planningDesignProject = TestFramework.TestProject.Create();
                planningDesignProject.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;

                // - Edit Actual PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, editPerformanceMeasureActualFeature, false);
                TestExpectedUserPermission(userNormal, planningDesignProject, editPerformanceMeasureActualFeature, false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, planningDesignProject, editPerformanceMeasureActualFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    planningDesignProject,
                    editPerformanceMeasureActualFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                // Only Admin should be allowed to edit actual, reported PMs
                TestExpectedUserPermission(userAdmin, planningDesignProject, editPerformanceMeasureActualFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, editPerformanceMeasureActualFeature, true);
            }
        }

        [Test]
        public void ProjectEditReportedExpendituresTest()
        {
            var manageReportedExpendituresFeature = new ProjectEditAsAdminFeature();

            // Test organizations we'll use for membership checks
            var testOrganizationForProject = TestFramework.TestOrganization.Create("The Test Organization for Project");
            var testOrganizationJustForUser = TestFramework.TestOrganization.Create("The Test Organization for User");

            Person userAnonymous = null;

            var userNormal = TestFramework.TestPerson.Create();
            userNormal.RoleID = Role.Normal.RoleID;

            var userAdmin = TestFramework.TestPerson.Create();
            userAdmin.RoleID = Role.Admin.RoleID;

            var userSitkaAdmin = TestFramework.TestPerson.Create();
            userSitkaAdmin.RoleID = Role.SitkaAdmin.RoleID;

            // Planning/Design Project
            // ----------------
            {
                var planningDesignProject = TestFramework.TestProject.Create();
                planningDesignProject.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;

                // - Edit Actual PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, manageReportedExpendituresFeature, false);
                TestExpectedUserPermission(userNormal, planningDesignProject, manageReportedExpendituresFeature, false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, planningDesignProject, manageReportedExpendituresFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    planningDesignProject,
                    manageReportedExpendituresFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                // Only Admin should be allowed to edit actual, reported PMs
                TestExpectedUserPermission(userAdmin, planningDesignProject, manageReportedExpendituresFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, manageReportedExpendituresFeature, true);
            }
        }

        private static void MakeOrganizationTheOnlyAndTheLeadImplementingOrganization(Project project, Organization leadOrganization)
        {
            project.ProjectOrganizations.Clear();

            var leadImplementingRelationshipType = MultiTenantHelpers.GetIsPrimaryContactOrganizationRelationship();
            if (leadImplementingRelationshipType != null)
            {
                project.ProjectOrganizations.Add(new ProjectOrganization(project, leadOrganization, leadImplementingRelationshipType));
            }
        }

        private static void TestExpectedUserPermission(Person user, Project project, IFirmaBaseFeatureWithContext<Project> projectCheckingFeature, bool expectedPermission)
        {
            // Hack - fudge up a fake Session
            var tmpFirmaSession = TestFramework.TestFirmaSession.Create();
            // Normally we don't allow deliberate setting of null Person in constructor, so we need to work around this in test context.
            tmpFirmaSession.Person = user;
            Assert.That(projectCheckingFeature.HasPermission(tmpFirmaSession, project).HasPermission == expectedPermission);
        }

        private static void TestExpectedUserPermission(FirmaSession firmaSession, Project project, IFirmaBaseFeatureWithContext<Project> projectCheckingFeature, bool expectedPermission)
        {
            Assert.That(projectCheckingFeature.HasPermission(firmaSession, project).HasPermission == expectedPermission);
        }

        private static void TestExpectedUserPermission(Person user, FirmaFeature projectCheckingFeature, bool expectedPermission)
        {
            Assert.That(projectCheckingFeature.HasPermissionByPerson(user) == expectedPermission);
        }

        private static void TestExpectedUserPermission(FirmaSession firmaSession, FirmaFeature projectCheckingFeature, bool expectedPermission)
        {
            Assert.That(projectCheckingFeature.HasPermissionByFirmaSession(firmaSession) == expectedPermission);
        }

        private static void TestExpectedUserPermissionWithUserInLeadImplementingOrg(Person user,
            Project project,
            IFirmaBaseFeatureWithContext<Project> projectCheckingFeature,
            Organization optionalOrganizationToMakeUserTemporaryMemberOf,
            bool expectedPermission)
        {
            var originalUserOrg = user.Organization;
            var originalUserOrgID = user.OrganizationID;
            // Make sure the user WAS NOT already a member of this org. That would indicate some confusion or misuse in the test setup.
            if (optionalOrganizationToMakeUserTemporaryMemberOf != null)
            {
                MakeOrganizationTheOnlyAndTheLeadImplementingOrganization(project, optionalOrganizationToMakeUserTemporaryMemberOf);
                Assert.That(user.OrganizationID != optionalOrganizationToMakeUserTemporaryMemberOf.OrganizationID);
                user.Organization = optionalOrganizationToMakeUserTemporaryMemberOf;
                user.OrganizationID = optionalOrganizationToMakeUserTemporaryMemberOf.OrganizationID;
            }

            // Temp fake Session
            var tempFirmaSession = new FirmaSession(HttpRequestStorage.DatabaseEntities, user);
            Assert.That(projectCheckingFeature.HasPermission(tempFirmaSession, project).HasPermission == expectedPermission);
            project.ProjectOrganizations.Clear();
            user.Organization = originalUserOrg;
            user.OrganizationID = originalUserOrgID;
        }

        private static void TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(Person user,
            Project project,
            IFirmaBaseFeatureWithContext<Project> projectCheckingFeature,
            Organization orgUserShouldBeMemberOf,
            Organization organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg,
            bool expectedPermission)
        {
            // We deliberately put user in a DIFFERENT org, so make user these aren't the same org
            Assert.That(orgUserShouldBeMemberOf.OrganizationID != organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.OrganizationID);
            var originalUserOrg = user.Organization;
            var originalUserOrgID = user.OrganizationID;
            user.Organization = orgUserShouldBeMemberOf;
            user.OrganizationID = orgUserShouldBeMemberOf.OrganizationID;

            // Make sure the user WAS NOT already primary contact. That would indicate confusion or misuse.
            Assert.That(user.OrganizationID != organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.OrganizationID);
            Assert.That(project.GetPrimaryContact() == null);

            organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.PrimaryContactPerson = user;
            organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.PrimaryContactPersonID = user.PersonID;

            // Temp fake Session
            var tempFirmaSession = new FirmaSession(HttpRequestStorage.DatabaseEntities, user);
            Assert.That(projectCheckingFeature.HasPermission(tempFirmaSession, project).HasPermission == expectedPermission);

            user.Organization = originalUserOrg;
            user.OrganizationID = originalUserOrgID;
        }
    }
}
