using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class CustomNotificationViewData : FirmaUserControlViewData
    {
        public readonly string PersonLabel;
        public readonly List<Person> PeopleToNotify;
        public readonly IEnumerable<SelectListItem> ReminderTemplates;
        public readonly string LoadReminderTemplateUrl;
        public readonly string SendPreviewEmailUrl;
        public readonly string SupportEmail;
        public readonly Person CurrentPerson;

        public CustomNotificationViewData(Person currentPerson, List<Person> peopleToNotify, string loadReminderTemplateUrl, string sendPreviewEmailUrl)
        {
            PeopleToNotify = peopleToNotify;
            LoadReminderTemplateUrl = loadReminderTemplateUrl;
            CurrentPerson = currentPerson;
            SendPreviewEmailUrl = sendPreviewEmailUrl;
            PersonLabel = peopleToNotify.Count > 1 ? "People" : "Person";
            ReminderTemplates = ReminderMessageType.All.ToSelectListWithEmptyFirstRow(x => x.ToEnum.ToString(), x => x.ReminderMessageTypeDisplayName, "Custom");
            SupportEmail = Notification.DoNotReplyMailAddress().Address;
        }
    }
}