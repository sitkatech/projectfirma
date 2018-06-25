using System.Collections.Generic;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateReminderScheduledBackgroundJob : ScheduledBackgroundJobBase
    {
        //public readonly ReminderMessageType ReminderMessageType;

        //protected ProjectUpdateReminderScheduledBackgroundJobBase(ReminderMessageType reminderMessageType)
        //    : base($"Project Update - {reminderMessageType.ReminderMessageTypeDisplayName}")
        //{
        //    ReminderMessageType = reminderMessageType;
        //}

        public static ProjectUpdateReminderScheduledBackgroundJob Instance { get; set; }

        static ProjectUpdateReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateReminderScheduledBackgroundJob("Project Update Reminder");
        }

        protected ProjectUpdateReminderScheduledBackgroundJob(string jobName) : base(jobName)
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
            //var resultMessage = ReminderMessageType.SendReminderEmails();
            //Logger.Info(resultMessage);
        }
    }
}