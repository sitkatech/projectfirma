using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectNotificationGridSpec : GridSpec<Models.Notification>
    {
        public ProjectNotificationGridSpec()
        {
            Add("Date", x => x.NotificationDate, 120);
            Add("Notification Type", x => x.NotificationType.NotificationTypeDisplayName, 140, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Notification", x => x.GetFullDescriptionFromProjectPerspective(), 400, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Person Notified", x => x.Person.GetFullNameFirstLastAndOrgAsUrl(), 400);
        }
    }
}