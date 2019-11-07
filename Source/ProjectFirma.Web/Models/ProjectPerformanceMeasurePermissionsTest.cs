/*-----------------------------------------------------------------------
<copyright file="ProjectPerformanceMeasurePermissionsTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
            var editPerformanceMeasureFeature = new ProjectEditAsAdminFeature();
            var viewPerformanceMeasureFeature = new ProjectsInProposalStageViewListFeature();

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
                TestExpectedUserPermission(userAnonymous, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, deferredProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, deferredProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, deferredProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, deferredProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, deferredProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    deferredProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                
                TestExpectedUserPermission(userAdmin, deferredProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, deferredProject, editPerformanceMeasureFeature, true);
            }

            // Planning/Design Project
            // -----------------------
            {
                // Planning / Design Project
                var planningDesignProject = TestFramework.TestProject.Create();
                planningDesignProject.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, planningDesignProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, planningDesignProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, planningDesignProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    planningDesignProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, planningDesignProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, editPerformanceMeasureFeature, true);
            }

            // Implementation Project
            // -----------------------
            {
                // Implementation Project
                var implementationProject = TestFramework.TestProject.Create();
                implementationProject.ProjectStageID = ProjectStage.Implementation.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, implementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, implementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, implementationProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, implementationProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, implementationProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    implementationProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, implementationProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, implementationProject, editPerformanceMeasureFeature, true);
            }

            // Post-Implementation Project
            // -----------------------
            {
                // Post-Implementation Project
                var postImplementationProject = TestFramework.TestProject.Create();
                postImplementationProject.ProjectStageID = ProjectStage.PostImplementation.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, postImplementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, postImplementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, postImplementationProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, postImplementationProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, postImplementationProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    postImplementationProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, postImplementationProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, postImplementationProject, editPerformanceMeasureFeature, true);
            }

            // Completed Project
            // -----------------------
            {
                // Completed Project
                var completedProject = TestFramework.TestProject.Create();
                completedProject.ProjectStageID = ProjectStage.Completed.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, completedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, completedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, completedProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, completedProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, completedProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    completedProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, completedProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, completedProject, editPerformanceMeasureFeature, true);
            }

            // Terminated Project
            // -----------------------
            {
                // Terminated Project
                var terminatedProject = TestFramework.TestProject.Create();
                terminatedProject.ProjectStageID = ProjectStage.Terminated.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, terminatedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, terminatedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, terminatedProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, terminatedProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, terminatedProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    terminatedProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, terminatedProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, terminatedProject, editPerformanceMeasureFeature, true);
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
            var tempFirmaSession = new FirmaSession(user);
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
            var tempFirmaSession = new FirmaSession(user);
            Assert.That(projectCheckingFeature.HasPermission(tempFirmaSession, project).HasPermission == expectedPermission);

            user.Organization = originalUserOrg;
            user.OrganizationID = originalUserOrgID;
        }
    }
}
