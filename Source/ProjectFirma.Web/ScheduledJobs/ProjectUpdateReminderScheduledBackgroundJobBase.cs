using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public abstract class ProjectUpdateReminderScheduledBackgroundJobBase : ScheduledBackgroundJobBase
    {
        public readonly ReminderMessageType ReminderMessageType;

        protected ProjectUpdateReminderScheduledBackgroundJobBase(ReminderMessageType reminderMessageType)
            : base(string.Format("Project Update - {0}", reminderMessageType.ReminderMessageTypeDisplayName))
        {
            ReminderMessageType = reminderMessageType;
        }

        protected override void RunJobImplementation()
        {
            ProcessRemindersImpl();
        }

        protected virtual void ProcessRemindersImpl()
        {
            Logger.Info(string.Format("Processing '{0}' notifications.", JobName));
            var resultMessage = ReminderMessageType.SendReminderEmails();
            Logger.Info(resultMessage);
        }
    }
}