namespace ProjectFirma.Web.Models
{
    public class ReminderMessageSimple
    {
        public readonly string Body;
        public readonly string Subject;

        public ReminderMessageSimple(ReminderMessageType reminderMessageType, Person person)
        {
            var reminderMessage = reminderMessageType;
            Body = reminderMessage.GetBodyContent(person).Replace("cid:eip-logo", "https://localhost-eip.laketahoeinfo.org/Content/img/eip-logo-factsheet.png");
            Subject = reminderMessage.ReminderMessageTypeSubject;
        }
    }
}