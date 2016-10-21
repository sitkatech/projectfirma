using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.User
{
    public class UserNotificationGridSpec : GridSpec<Notification>
    {
        public UserNotificationGridSpec()
        {
            Add("Date", x => x.NotificationDate, 120);
            Add("Notification Type", x => x.NotificationType.NotificationTypeDisplayName, 140, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Notification",
                x => x.GetFullDescriptionFromUserPerspective(),
                500,
                DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", x => x.NotificationProjects.Count, 100);
            Add("Project", x =>
            {
                if (x.NotificationType == NotificationType.ProjectUpdateReminder)
                {
                    return new HtmlString(string.Empty);
                }
                var notificationProject = x.NotificationProjects.SingleOrDefault();
                if (notificationProject == null)
                {
                    return new HtmlString(string.Empty);
                }
                return notificationProject.Project.DisplayNameAsUrl;
            }, 200, DhtmlxGridColumnFilterType.Html);
        }
    }
}