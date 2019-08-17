using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

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
                var tenantID = projectUpdateSetting.TenantID;
                var databaseEntities = new DatabaseEntities(tenantID);
                var projects = databaseEntities.Projects.ToList();

                var tenantAttribute = databaseEntities.TenantAttributes.Single();
                if (projectUpdateSetting.EnableProjectUpdateReminders)
                {
                    var projectUpdateKickOffDate = projectUpdateSetting.ProjectUpdateKickOffDate;
                    if (DateTime.Today == projectUpdateKickOffDate.GetValueOrDefault().Date)
                    {
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                                                        projectUpdateSetting.ProjectUpdateKickOffIntroContent, true, tenantAttribute));
                    }
                }

                if (projectUpdateSetting.SendPeriodicReminders)
                {
                    if (TodayIsReminderDayForProjectUpdateConfiguration(projectUpdateSetting))
                    {
                        notifications.AddRange(RunNotifications(projects, reminderSubject, projectUpdateSetting.ProjectUpdateReminderIntroContent, false, tenantAttribute));
                        // notifyOnAll is false b/c we only send periodic reminders for projects whose updates haven't been submitted yet.
                    }
                }

                if (projectUpdateSetting.SendCloseOutNotification)
                {
                    var projectUpdateCloseOutDate = projectUpdateSetting.ProjectUpdateCloseOutDate;
                    if (DateTime.Today == projectUpdateCloseOutDate.GetValueOrDefault().Date)
                    {
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                            projectUpdateSetting.ProjectUpdateCloseOutIntroContent, false, tenantAttribute));
                    }
                }

                databaseEntities.AllNotifications.AddRange(notifications);
                databaseEntities.SaveChangesWithNoAuditing(tenantID);
            }
        }

        private static bool TodayIsReminderDayForProjectUpdateConfiguration(
            ProjectUpdateSetting projectUpdateSetting)
        {
            var isReminderDay = (DateTime.Today - projectUpdateSetting.ProjectUpdateKickOffDate.GetValueOrDefault().Date)
                                                                  .Days % projectUpdateSetting.ProjectUpdateReminderInterval == 0;
            var isAfterCloseOut = (DateTime.Today >= projectUpdateSetting.ProjectUpdateCloseOutDate);
            return isReminderDay && !isAfterCloseOut;
        }

        /// <summary>
        /// Sends a notification to all the primary contacts for the given tenant's projects.
        /// </summary>
        /// <param name="projectsForTenant"></param>
        /// <param name="reminderSubject"></param>
        /// <param name="introContent"></param>
        /// <param name="notifyOnAll"></param>
        /// <param name="attribute"></param>
        private List<Notification> RunNotifications(IEnumerable<Project> projectsForTenant, string reminderSubject,
            string introContent, bool notifyOnAll, TenantAttribute attribute)
        {
            // Constrain to tenant boundaries.
            var toolDisplayName = attribute.ToolDisplayName;

            var contactSupportEmail = attribute.PrimaryContactPerson.Email;

            var toolLogo = attribute.TenantSquareLogoFileResource;

            var projectUpdateNotificationHelper = new ProjectUpdateNotificationHelper(contactSupportEmail, introContent, reminderSubject, toolLogo, toolDisplayName);

            var projectsToNotifyOn = notifyOnAll
                ? projectsForTenant.AsQueryable().GetUpdatableProjects()
                : projectsForTenant.AsQueryable().GetUpdatableProjectsThatHaveNotBeenSubmitted();

            var projectsGroupedByPrimaryContact =
                projectsToNotifyOn.Where(x => x.GetPrimaryContact() != null).GroupBy(x => x.GetPrimaryContact())
                    .ToList();

            var notifications = projectsGroupedByPrimaryContact
                .SelectMany(x => projectUpdateNotificationHelper.SendProjectUpdateReminderMessage(x)).ToList();

            var message =
                $"Reminder emails sent to {projectsGroupedByPrimaryContact.Count} {FieldDefinitionEnum.ProjectPrimaryContact.ToType().GetFieldDefinitionLabelPluralized()} for {projectsGroupedByPrimaryContact.Count} projects requiring an update.";
            Logger.Info(message);

            return notifications;
        }
    }
}
