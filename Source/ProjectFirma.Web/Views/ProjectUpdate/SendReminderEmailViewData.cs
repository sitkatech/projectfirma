using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class SendReminderEmailViewData
    {
        public readonly string ConfirmMessage;

        public SendReminderEmailViewData(string confirmMessage, List<ReminderMessageType> reminderMessageTypes)
        {
            ConfirmMessage = confirmMessage;
            ReminderMessageTypes = reminderMessageTypes;
        }

        public readonly List<ReminderMessageType> ReminderMessageTypes;
    }
}