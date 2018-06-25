namespace ProjectFirma.Web.ScheduledJobs
{
    public abstract class ProjectUpdateReminderScheduledBackgroundJobBase : ScheduledBackgroundJobBase
    {
        //public readonly ReminderMessageType ReminderMessageType;

        //protected ProjectUpdateReminderScheduledBackgroundJobBase(ReminderMessageType reminderMessageType)
        //    : base($"Project Update - {reminderMessageType.ReminderMessageTypeDisplayName}")
        //{
        //    ReminderMessageType = reminderMessageType;
        //}

        protected override void RunJobImplementation()
        {
            ProcessRemindersImpl();
        }

        protected virtual void ProcessRemindersImpl()
        {
            Logger.Info($"Processing '{JobName}' notifications.");
            //var resultMessage = ReminderMessageType.SendReminderEmails();
            //Logger.Info(resultMessage);
        }
    }
}