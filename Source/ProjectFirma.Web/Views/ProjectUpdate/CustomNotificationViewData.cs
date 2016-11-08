using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class CustomNotificationViewData : FirmaUserControlViewData
    {
        public readonly string PersonLabel;
        public readonly List<Person> PeopleToNotify;
        public readonly string SendPreviewEmailUrl;
        public readonly string SupportEmail;
        public readonly Person CurrentPerson;

        public CustomNotificationViewData(Person currentPerson, List<Person> peopleToNotify, string sendPreviewEmailUrl)
        {
            PeopleToNotify = peopleToNotify;
            CurrentPerson = currentPerson;
            SendPreviewEmailUrl = sendPreviewEmailUrl;
            PersonLabel = peopleToNotify.Count > 1 ? "People" : "Person";
            SupportEmail = Notification.DoNotReplyMailAddress().Address;
        }
    }
}