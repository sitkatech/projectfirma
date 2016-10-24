using ProjectFirma.Web.Security;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    // Test some permissions issues raised by ProjectFirma story #150 - http://projects.sitkatech.com/projects/projectFirma/cards/150
    [TestFixture]
    public class ProjectEIPPerformanceMeasurePermissionsTest
    {
        [Test]
        public void ProjectProposedTest()
        {
            var editEIPPerformanceMeasureFeature = new EIPPerformanceMeasureExpectedFromProjectManageFeature();
            var viewEIPPerformanceMeasureFeature = new EIPPerformanceMeasureExpectedFromProjectViewFeature();

            // Test organizations we'll use for membership checks
            var testOrganizationForProject = TestFramework.TestOrganization.Create("The Test Organization for Project");
            var testOrganizationJustForUser = TestFramework.TestOrganization.Create("The Test Organization for User");

            Person userAnonymous = null;

            var userNormal = TestFramework.TestPerson.Create();
            userNormal.EIPRoleID = EIPRole.Normal.RoleID;

            var userApprover = TestFramework.TestPerson.Create();
            userApprover.EIPRoleID = EIPRole.Approver.RoleID;

            var userAdmin = TestFramework.TestPerson.Create();
            userAdmin.EIPRoleID = EIPRole.Admin.RoleID;

            // Deferred Project
            // ----------------
            {
                // Deferred Project
                var deferredProject = TestFramework.TestProject.Create();
                deferredProject.ProjectStageID = ProjectStage.Deferred.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, deferredProject, viewEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, deferredProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, deferredProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, deferredProject, viewEIPPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, deferredProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, deferredProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, deferredProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, deferredProject, editEIPPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, deferredProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    deferredProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, deferredProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    deferredProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
                TestExpectedUserPermission(userAdmin, deferredProject, editEIPPerformanceMeasureFeature, true);
            }

            // Planning/Design Project
            // -----------------------
            {
                // Planning / Design Project
                var planningDesignProject = TestFramework.TestProject.Create();
                planningDesignProject.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userNormal, planningDesignProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, planningDesignProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, planningDesignProject, viewEIPPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, planningDesignProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, planningDesignProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, planningDesignProject, editEIPPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, planningDesignProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    planningDesignProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, planningDesignProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, true);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    planningDesignProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    true);
                TestExpectedUserPermission(userAdmin, planningDesignProject, editEIPPerformanceMeasureFeature, true);
            }

            // Implementation Project
            // -----------------------
            {
                // Implementation Project
                var implementationProject = TestFramework.TestProject.Create();
                implementationProject.ProjectStageID = ProjectStage.Implementation.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, implementationProject, viewEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, implementationProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, implementationProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, implementationProject, viewEIPPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, implementationProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, implementationProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, implementationProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, implementationProject, editEIPPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, implementationProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    implementationProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, implementationProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    implementationProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, implementationProject, editEIPPerformanceMeasureFeature, true);
            }

            // Post-Implementation Project
            // -----------------------
            {
                // Post-Implementation Project
                var postImplementationProject = TestFramework.TestProject.Create();
                postImplementationProject.ProjectStageID = ProjectStage.PostImplementation.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, postImplementationProject, viewEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, postImplementationProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, postImplementationProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, postImplementationProject, viewEIPPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, postImplementationProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, postImplementationProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, postImplementationProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, postImplementationProject, editEIPPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, postImplementationProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    postImplementationProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, postImplementationProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    postImplementationProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, postImplementationProject, editEIPPerformanceMeasureFeature, true);
            }

            // Completed Project
            // -----------------------
            {
                // Completed Project
                var completedProject = TestFramework.TestProject.Create();
                completedProject.ProjectStageID = ProjectStage.Completed.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, completedProject, viewEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, completedProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, completedProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, completedProject, viewEIPPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, completedProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, completedProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, completedProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, completedProject, editEIPPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, completedProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    completedProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, completedProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    completedProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, completedProject, editEIPPerformanceMeasureFeature, true);
            }

            // Terminated Project
            // -----------------------
            {
                // Terminated Project
                var terminatedProject = TestFramework.TestProject.Create();
                terminatedProject.ProjectStageID = ProjectStage.Terminated.ProjectStageID;

                // - View PMs -
                TestExpectedUserPermission(userAnonymous, terminatedProject, viewEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, terminatedProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userApprover, terminatedProject, viewEIPPerformanceMeasureFeature, true);
                TestExpectedUserPermission(userAdmin, terminatedProject, viewEIPPerformanceMeasureFeature, true);

                // - Edit PMs -
                TestExpectedUserPermission(userAnonymous, terminatedProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userNormal, terminatedProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userApprover, terminatedProject, editEIPPerformanceMeasureFeature, false);
                TestExpectedUserPermission(userAdmin, terminatedProject, editEIPPerformanceMeasureFeature, true);

                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, terminatedProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    terminatedProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userApprover, terminatedProject, editEIPPerformanceMeasureFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userApprover,
                    terminatedProject,
                    editEIPPerformanceMeasureFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                TestExpectedUserPermission(userAdmin, terminatedProject, editEIPPerformanceMeasureFeature, true);
            }
        }

        [Test]
        public void ProjectEditReportedEIPPerformanceMeasureTest()
        {
            var editEIPPerformanceMeasureActualFeature = new EIPPerformanceMeasureActualFromProjectManageFeature();

            // Test organizations we'll use for membership checks
            var testOrganizationForProject = TestFramework.TestOrganization.Create("The Test Organization for Project");
            var testOrganizationJustForUser = TestFramework.TestOrganization.Create("The Test Organization for User");

            Person userAnonymous = null;

            var userNormal = TestFramework.TestPerson.Create();
            userNormal.EIPRoleID = EIPRole.Normal.RoleID;

            var userApprover = TestFramework.TestPerson.Create();
            userNormal.EIPRoleID = EIPRole.Approver.RoleID;

            var userAdmin = TestFramework.TestPerson.Create();
            userAdmin.EIPRoleID = EIPRole.Admin.RoleID;

            // Planning/Design Project
            // ----------------
            {
                var planningDesignProject = TestFramework.TestProject.Create();
                planningDesignProject.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;

                // - Edit Actual PMs -
                TestExpectedUserPermission(userAnonymous, planningDesignProject, editEIPPerformanceMeasureActualFeature, false);
                TestExpectedUserPermission(userNormal, planningDesignProject, editEIPPerformanceMeasureActualFeature, false);
                TestExpectedUserPermission(userApprover, planningDesignProject, editEIPPerformanceMeasureActualFeature, false);
                TestExpectedUserPermissionWithUserInLeadImplementingOrg(userNormal, planningDesignProject, editEIPPerformanceMeasureActualFeature, testOrganizationForProject, false);
                TestExpectedUserPermissionWithUserAsPrimaryContactForImplementingOrg(userNormal,
                    planningDesignProject,
                    editEIPPerformanceMeasureActualFeature,
                    testOrganizationJustForUser,
                    testOrganizationForProject,
                    false);
                // Only Admin should be allowed to edit actual, reported PMs
                TestExpectedUserPermission(userAdmin, planningDesignProject, editEIPPerformanceMeasureActualFeature, true);
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
            userNormal.EIPRoleID = EIPRole.Normal.RoleID;

            var userApprover = TestFramework.TestPerson.Create();
            userNormal.EIPRoleID = EIPRole.Approver.RoleID;

            var userAdmin = TestFramework.TestPerson.Create();
            userAdmin.EIPRoleID = EIPRole.Admin.RoleID;

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
            }
        }

        private static void MakeOrganizationTheOnlyAndTheLeadImplementingOrganization(Project theProject, Organization leadOrganization)
        {
            theProject.ProjectImplementingOrganizations.Clear();
            theProject.ProjectImplementingOrganizations.Add(new ProjectImplementingOrganization(theProject, leadOrganization, true));
        }

        private static void TestExpectedUserPermission(Person user, Project project, ILakeTahoeInfoBaseFeatureWithContext<Project> projectCheckingFeature, bool expectedPermission)
        {
            Assert.That(projectCheckingFeature.HasPermission(user, project).HasPermission == expectedPermission);
        }

        private static void TestExpectedUserPermissionWithUserInLeadImplementingOrg(Person user,
            Project project,
            ILakeTahoeInfoBaseFeatureWithContext<Project> projectCheckingFeature,
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
            ILakeTahoeInfoBaseFeatureWithContext<Project> projectCheckingFeature,
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