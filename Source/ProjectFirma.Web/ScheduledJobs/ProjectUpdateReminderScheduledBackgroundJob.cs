using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateReminderScheduledBackgroundJob : ScheduledBackgroundJobBase
    {
        public ProjectUpdateReminderScheduledBackgroundJob(string jobName) : base()
        {
        }

        public override List<FirmaEnvironmentType> RunEnvironments => new List<FirmaEnvironmentType>
        {
            FirmaEnvironmentType.Local,
            FirmaEnvironmentType.Prod,
            FirmaEnvironmentType.Qa
        };

        protected override void RunJobImplementation()
        {
            ProcessRemindersImpl();
        }

        protected virtual void ProcessRemindersImpl()
        {
            Logger.Info($"Processing '{JobName}' notifications.");

            // we're "tenant-agnostic" right now
            var projectUpdateSettings = DbContext.AllProjectUpdateSettings.ToList();
            var reminderSubject = "Time to update your Projects";

            foreach (var projectUpdateSetting in projectUpdateSettings)
            {
                var notifications = new List<Notification>();
                var tenant = projectUpdateSetting.Tenant;

                var databaseEntities = new DatabaseEntities(tenant.TenantID);
                var projects = databaseEntities.Projects;

                if (projectUpdateSetting.EnableProjectUpdateReminders)
                {
                    var projectUpdateKickOffDate = projectUpdateSetting.ProjectUpdateKickOffDate;
                    if (DateTime.Today == projectUpdateKickOffDate.GetValueOrDefault().Date)
                    {
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                                                        projectUpdateSetting.ProjectUpdateKickOffIntroContent, tenant, true));
                    }
                }

                if (projectUpdateSetting.SendPeriodicReminders)
                {
                    if (TodayIsReminderDayForProjectUpdateConfiguration(projectUpdateSetting))
                    {
                        notifications.AddRange(RunNotifications(projects, reminderSubject, projectUpdateSetting.ProjectUpdateReminderIntroContent, tenant, false));
                        // notifyOnAll is false b/c we only send periodic reminders for projects whose updates haven't been submitted yet.
                    }
                }

                if (projectUpdateSetting.SendCloseOutNotification)
                {
                    var projectUpdateCloseOutDate = projectUpdateSetting.ProjectUpdateCloseOutDate;
                    if (DateTime.Today == projectUpdateCloseOutDate.GetValueOrDefault().Date)
                    {
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                            projectUpdateSetting.ProjectUpdateCloseOutIntroContent, tenant, false));
                    }
                }

                databaseEntities.AllNotifications.AddRange(notifications);
                databaseEntities.SaveChangesWithNoAuditing();
            }
        }

        private static bool TodayIsReminderDayForProjectUpdateConfiguration(
            ProjectUpdateSetting projectUpdateSetting)
        {
            return (DateTime.Today - projectUpdateSetting.ProjectUpdateKickOffDate.GetValueOrDefault().Date)
                   .Days % projectUpdateSetting.ProjectUpdateReminderInterval == 0;
        }

        /// <summary>
        /// Sends a notification to all the primary contacts for the given tenant's projects.
        /// </summary>
        /// <param name="allProjects"></param>
        /// <param name="reminderSubject"></param>
        /// <param name="introContent"></param>
        /// <param name="tenant"></param>
        /// <param name="notifyOnAll"></param>
        private List<Notification> RunNotifications(IQueryable<Project> allProjects, string reminderSubject,
            string introContent, Tenant tenant, bool notifyOnAll)
        {
            // Constrain to tenant boundaries.
            var tenantProjects = allProjects.Where(x => x.TenantID == tenant.TenantID).ToList();
            var tenantAttribute = DbContext.AllTenantAttributes.Single(a => a.TenantID == tenant.TenantID);
            var toolDisplayName = tenantAttribute.ToolDisplayName;

            var contactSupportEmail = tenantAttribute.PrimaryContactPerson.Email;

            var toolLogo = tenantAttribute.TenantSquareLogoFileResource;

            var projectUpdateNotificationHelper = new ProjectUpdateNotificationHelper(contactSupportEmail,
                introContent,
                reminderSubject,
                toolLogo,
                toolDisplayName
            );

            var projectsToNotifyOn = notifyOnAll
                ? tenantProjects.AsQueryable().GetUpdatableProjects()
                : tenantProjects.AsQueryable().GetUpdatableProjectsThatHaveNotBeenSubmitted();

            var projectsGroupedByPrimaryContact =
                projectsToNotifyOn.Where(x=>x.GetPrimaryContact() != null).GroupBy(x => x.GetPrimaryContact()).ToList();

            var notifications = projectsGroupedByPrimaryContact
                .SelectMany(x => projectUpdateNotificationHelper.SendProjectUpdateReminderMessage(x)).ToList();

            var message =
                $"Reminder emails sent to {projectsGroupedByPrimaryContact.Count} primary contacts for {projectsGroupedByPrimaryContact.Count} projects requiring an update.";
            Logger.Info(message);

            return notifications;
        }
    }
}
