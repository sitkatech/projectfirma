using ProjectFirma.Web.Security;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class ProjectPerformanceMeasurePermissionsTest
    {
        [Test]
        public void ProjectProposedTest()
        {
            var editPerformanceMeasureFeature = new PerformanceMeasureExpectedFromProjectManageFeature();
            var viewPerformanceMeasureFeature = new PerformanceMeasureExpectedFromProjectViewFeature();

            // Test organizations we'll use for membership checks
            var testOrganizationForProject = TestFramework.TestOrganization.Create("The Test Organization for Project");
            var testOrganizationJustForUser = TestFramework.TestOrganization.Create("The Test Organization for User");

            Person userAnonymous = null;

            var userNormal = TestFramework.TestPerson.Create();
            userNormal.RoleID = Role.Normal.RoleID;

            var userApprover = TestFramework.TestPerson.Create();
            userApprover.RoleID = Role.Approver.RoleID;

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
                TestExpectedUserPermission(userAnonymous, deferredProject, viewPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, deferredProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, deferredProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, deferredProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, deferredProject, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, deferredProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, deferredProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, deferredProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, deferredProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, deferredProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, deferredProject, editPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    deferredProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, deferredProject, editPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    deferredProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
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
                TestExpectedUserPermission(userAnonymous, planningDesignProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, planningDesignProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, planningDesignProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, planningDesignProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, planningDesignProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, planningDesignProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, planningDesignProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, planningDesignProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, planningDesignProject, editPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    planningDesignProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, planningDesignProject, editPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    planningDesignProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
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
                TestExpectedUserPermission(userAnonymous, implementationProject, viewPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, implementationProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, implementationProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, implementationProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, implementationProject, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, implementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, implementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, implementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, implementationProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, implementationProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, implementationProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    implementationProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, implementationProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
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
                TestExpectedUserPermission(userAnonymous, postImplementationProject, viewPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, postImplementationProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, postImplementationProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, postImplementationProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, postImplementationProject, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, postImplementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, postImplementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, postImplementationProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, postImplementationProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, postImplementationProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, postImplementationProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    postImplementationProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, postImplementationProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
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
                TestExpectedUserPermission(userAnonymous, completedProject, viewPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, completedProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, completedProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, completedProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, completedProject, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, completedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, completedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, completedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, completedProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, completedProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, completedProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    completedProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, completedProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
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
                TestExpectedUserPermission(userAnonymous, terminatedProject, viewPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, terminatedProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, terminatedProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, terminatedProject, viewPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, terminatedProject, viewPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, terminatedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, terminatedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, terminatedProject, editPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, terminatedProject, editPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userSitkaAdmin, terminatedProject, editPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, terminatedProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    terminatedProject,
                    editPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, terminatedProject, editPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
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

            var userApprover = TestFramework.TestPerson.Create();
            userNormal.RoleID = Role.Approver.RoleID;

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
                TestExpectedUserPermission(userApprover, planningDesignProject, editPerformanceMeasureActualFeature, false);
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
            var manageReportedExpendituresFeature = new ProjectFundingSourceExpenditureFromProjectManageFeature();

            // Test organizations we'll use for membership checks
            var testOrganizationForProject = TestFramework.TestOrganization.Create("The Test Organization for Project");
            var testOrganizationJustForUser = TestFramework.TestOrganization.Create("The Test Organization for User");

            Person userAnonymous = null;

            var userNormal = TestFramework.TestPerson.Create();
            userNormal.RoleID = Role.Normal.RoleID;

            var userApprover = TestFramework.TestPerson.Create();
            userNormal.RoleID = Role.Approver.RoleID;

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
                TestExpectedUserPermission(userApprover, planningDesignProject, manageReportedExpendituresFeature, false);
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

        private static void MakeOrganizationTheOnlyAndTheLeadImplementingOrganization(Project theProject, Organization leadOrganization)
        {
            theProject.ProjectImplementingOrganizations.Clear();
            theProject.ProjectImplementingOrganizations.Add(new ProjectImplementingOrganization(theProject, leadOrganization, true));
        }

        private static void TestExpectedUserPermission(Person user, Project project, IFirmaBaseFeatureWithContext<Project> projectCheckingFeature, bool expectedPermission)
        {
            Assert.That(projectCheckingFeature.HasPermission(user, project).HasPermission == expectedPermission);
        }

        private static void TestExpectedUserPermissionWithUserInLeadImplementingOrg(Person user,
            Project project,
            IFirmaBaseFeatureWithContext<Project> projectCheckingFeature,
            Organization optionalOrganizationToMakeUserTemporaryMemberOf,
            bool expectedPermission)
        {
            Assert.That(project.LeadImplementer == null);

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

            Assert.That(projectCheckingFeature.HasPermission(user, project).HasPermission == expectedPermission);
            project.ProjectImplementingOrganizations.Clear();
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
            Assert.That(project.LeadImplementer == null);

            // We deliberately put user in a DIFFERENT org, so make user these aren't the same org
            Assert.That(orgUserShouldBeMemberOf.OrganizationID != organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.OrganizationID);
            var originalUserOrg = user.Organization;
            var originalUserOrgID = user.OrganizationID;
            user.Organization = orgUserShouldBeMemberOf;
            user.OrganizationID = orgUserShouldBeMemberOf.OrganizationID;

            // Make sure the user WAS NOT already primary contact. That would indicate confusion or misuse.
            Assert.That(user.OrganizationID != organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.OrganizationID);
            Assert.That(project.PrimaryContactPerson == null);

            organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.PrimaryContactPerson = user;
            organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.PrimaryContactPersonID = user.PersonID;

            project.ProjectImplementingOrganizations.Add(new ProjectImplementingOrganization(project, organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg, true));
            Assert.That(project.LeadImplementer.OrganizationID == organizationToMakeUserTemporaryPrimaryContactOfImplementingOrg.OrganizationID);

            Assert.That(projectCheckingFeature.HasPermission(user, project).HasPermission == expectedPermission);

            project.ProjectImplementingOrganizations.Clear();
            user.Organization = originalUserOrg;
            user.OrganizationID = originalUserOrgID;
            Assert.That(project.LeadImplementer == null);
        }
    }
}