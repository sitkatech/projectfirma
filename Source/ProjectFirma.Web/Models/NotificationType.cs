/*-----------------------------------------------------------------------
<copyright file="NotificationType.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Linq;
using System.Web;

namespace ProjectFirma.Web.Models
{
    public partial class NotificationType
    {
        public abstract HtmlString GetEntityDetailsAsHref(Notification notification);
        public abstract int GetEntityCount(Notification notification);
        public abstract HtmlString GetFullDescriptionFromUserPerspective(Notification notification);
        public abstract string GetFullDescriptionFromProjectPerspective();
        public abstract string GetFullDescriptionFromRegistrationPerspective();

        protected static HtmlString GetNotificationProjectDisplayNameAsHrefs(Notification notification)
        {
            return new HtmlString(string.Join(", ", notification.NotificationProjects.OrderBy(x => x.Project.ProjectName).Select(x => x.Project.DisplayNameAsUrl)));
        }

        protected static HtmlString GetNotificationProposedProjectDisplayNameAsHrefs(Notification notification)
        {
            return new HtmlString(string.Join(", ", notification.NotificationProposedProjects.OrderBy(x => x.ProposedProject.ProjectName).Select(x => x.ProposedProject.DisplayNameAsUrl)));
        }
    }

    public partial class NotificationTypeProjectUpdateReminder
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return new HtmlString(string.Empty);
        }

        public override int GetEntityCount(Notification notification)
        {
            return 0;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString("Project Update reminder sent.");
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return "Project Update reminder sent.";
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }

    public partial class NotificationTypeProjectUpdateSubmitted
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return GetNotificationProjectDisplayNameAsHrefs(notification);
        }

        public override int GetEntityCount(Notification notification)
        {
            return notification.NotificationProjects.Count;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString(string.Format("The update for project {0} was submitted", GetEntityDetailsAsHref(notification)));
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return "Project update was submitted";
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }

    public partial class NotificationTypeProjectUpdateReturned
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return GetNotificationProjectDisplayNameAsHrefs(notification);
        }

        public override int GetEntityCount(Notification notification)
        {
            return notification.NotificationProjects.Count;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString(string.Format("The update for project {0} has been returned", GetEntityDetailsAsHref(notification)));
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return "Project update has been returned";
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }

    public partial class NotificationTypeProjectUpdateApproved
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return GetNotificationProjectDisplayNameAsHrefs(notification);
        }

        public override int GetEntityCount(Notification notification)
        {
            return notification.NotificationProjects.Count;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString(string.Format("The update for project {0} was approved", GetEntityDetailsAsHref(notification)));
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return "Project update was approved";
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }

    public partial class NotificationTypeCustom
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return new HtmlString(string.Empty);
        }

        public override int GetEntityCount(Notification notification)
        {
            return 0;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString("A customized notification was sent.");
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return string.Empty;
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }

    public partial class NotificationTypeProposedProjectSubmitted
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return GetNotificationProposedProjectDisplayNameAsHrefs(notification);
        }

        public override int GetEntityCount(Notification notification)
        {
            return notification.NotificationProposedProjects.Count;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString(string.Format("A project proposal {0} was submitted for review", GetEntityDetailsAsHref(notification)));
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return "Proposal was submitted.";
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }

    public partial class NotificationTypeProposedProjectApproved
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return GetNotificationProposedProjectDisplayNameAsHrefs(notification);
        }

        public override int GetEntityCount(Notification notification)
        {
            return notification.NotificationProposedProjects.Count;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString(string.Format("A project proposal {0} was approved for the 5-year list", GetEntityDetailsAsHref(notification)));
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return "Proposal was approved";
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }

    public partial class NotificationTypeProposedProjectReturned
    {
        public override HtmlString GetEntityDetailsAsHref(Notification notification)
        {
            return GetNotificationProposedProjectDisplayNameAsHrefs(notification);
        }

        public override int GetEntityCount(Notification notification)
        {
            return notification.NotificationProposedProjects.Count;
        }

        public override HtmlString GetFullDescriptionFromUserPerspective(Notification notification)
        {
            return new HtmlString(string.Format("A project proposal {0} was returned for additional information", GetEntityDetailsAsHref(notification)));
        }

        public override string GetFullDescriptionFromProjectPerspective()
        {
            return "Proposal was returned";
        }

        public override string GetFullDescriptionFromRegistrationPerspective()
        {
            return string.Empty;
        }
    }
}
