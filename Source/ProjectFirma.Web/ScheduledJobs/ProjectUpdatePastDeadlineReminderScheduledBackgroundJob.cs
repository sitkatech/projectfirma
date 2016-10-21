using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdatePastDeadlineReminderScheduledBackgroundJob : ProjectUpdateReminderScheduledBackgroundJobBase
    {
        private const int DelinquentReminderIntervalInDays = 5;

        public static ProjectUpdatePastDeadlineReminderScheduledBackgroundJob Instance;

        static ProjectUpdatePastDeadlineReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdatePastDeadlineReminderScheduledBackgroundJob();
        }

        public ProjectUpdatePastDeadlineReminderScheduledBackgroundJob()
            : base(ReminderMessageType.PastDeadlineReminder)
        {
        }

        protected override void ProcessRemindersImpl()
        {
            Logger.Info(string.Format("Processing '{0}' notifications.", JobName));
            if (ProjectFirmaDateUtilities.IsDayToSendDelinquentReminder(DateTime.Today, DelinquentReminderIntervalInDays, 1, 15, 2, 1))
            {
                var resultMessage = ReminderMessageType.SendReminderEmails();
                Logger.Info(resultMessage);
            }
            else
            {
                Logger.Info("Not a day to send deliquency reminder");
            }
        }
    }
}