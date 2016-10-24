//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class NotificationType : IHavePrimaryKey
    {
        public static readonly NotificationTypeProjectUpdateReminder ProjectUpdateReminder = NotificationTypeProjectUpdateReminder.Instance;
        public static readonly NotificationTypeProjectUpdateSubmitted ProjectUpdateSubmitted = NotificationTypeProjectUpdateSubmitted.Instance;
        public static readonly NotificationTypeProjectUpdateReturned ProjectUpdateReturned = NotificationTypeProjectUpdateReturned.Instance;
        public static readonly NotificationTypeProjectUpdateApproved ProjectUpdateApproved = NotificationTypeProjectUpdateApproved.Instance;
        public static readonly NotificationTypeCustom Custom = NotificationTypeCustom.Instance;
        public static readonly NotificationTypeProposedProjectSubmitted ProposedProjectSubmitted = NotificationTypeProposedProjectSubmitted.Instance;
        public static readonly NotificationTypeProposedProjectApproved ProposedProjectApproved = NotificationTypeProposedProjectApproved.Instance;
        public static readonly NotificationTypeProposedProjectReturned ProposedProjectReturned = NotificationTypeProposedProjectReturned.Instance;

        public static readonly List<NotificationType> All;
        public static readonly ReadOnlyDictionary<int, NotificationType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static NotificationType()
        {
            All = new List<NotificationType> { ProjectUpdateReminder, ProjectUpdateSubmitted, ProjectUpdateReturned, ProjectUpdateApproved, Custom, ProposedProjectSubmitted, ProposedProjectApproved, ProposedProjectReturned };
            AllLookupDictionary = new ReadOnlyDictionary<int, NotificationType>(All.ToDictionary(x => x.NotificationTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected NotificationType(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName)
        {
            NotificationTypeID = notificationTypeID;
            NotificationTypeName = notificationTypeName;
            NotificationTypeDisplayName = notificationTypeDisplayName;
        }

        [Key]
        public int NotificationTypeID { get; private set; }
        public string NotificationTypeName { get; private set; }
        public string NotificationTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return NotificationTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(NotificationType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.NotificationTypeID == NotificationTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as NotificationType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return NotificationTypeID;
        }

        public static bool operator ==(NotificationType left, NotificationType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NotificationType left, NotificationType right)
        {
            return !Equals(left, right);
        }

        public NotificationTypeEnum ToEnum { get { return (NotificationTypeEnum)GetHashCode(); } }

        public static NotificationType ToType(int enumValue)
        {
            return ToType((NotificationTypeEnum)enumValue);
        }

        public static NotificationType ToType(NotificationTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case NotificationTypeEnum.Custom:
                    return Custom;
                case NotificationTypeEnum.ProjectUpdateApproved:
                    return ProjectUpdateApproved;
                case NotificationTypeEnum.ProjectUpdateReminder:
                    return ProjectUpdateReminder;
                case NotificationTypeEnum.ProjectUpdateReturned:
                    return ProjectUpdateReturned;
                case NotificationTypeEnum.ProjectUpdateSubmitted:
                    return ProjectUpdateSubmitted;
                case NotificationTypeEnum.ProposedProjectApproved:
                    return ProposedProjectApproved;
                case NotificationTypeEnum.ProposedProjectReturned:
                    return ProposedProjectReturned;
                case NotificationTypeEnum.ProposedProjectSubmitted:
                    return ProposedProjectSubmitted;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum NotificationTypeEnum
    {
        ProjectUpdateReminder = 1,
        ProjectUpdateSubmitted = 2,
        ProjectUpdateReturned = 3,
        ProjectUpdateApproved = 4,
        Custom = 5,
        ProposedProjectSubmitted = 6,
        ProposedProjectApproved = 7,
        ProposedProjectReturned = 8
    }

    public partial class NotificationTypeProjectUpdateReminder : NotificationType
    {
        private NotificationTypeProjectUpdateReminder(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProjectUpdateReminder Instance = new NotificationTypeProjectUpdateReminder(1, @"ProjectUpdateReminder", @"Project Update Reminder");
    }

    public partial class NotificationTypeProjectUpdateSubmitted : NotificationType
    {
        private NotificationTypeProjectUpdateSubmitted(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProjectUpdateSubmitted Instance = new NotificationTypeProjectUpdateSubmitted(2, @"ProjectUpdateSubmitted", @"Project Update Submitted");
    }

    public partial class NotificationTypeProjectUpdateReturned : NotificationType
    {
        private NotificationTypeProjectUpdateReturned(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProjectUpdateReturned Instance = new NotificationTypeProjectUpdateReturned(3, @"ProjectUpdateReturned", @"Project Update Returned");
    }

    public partial class NotificationTypeProjectUpdateApproved : NotificationType
    {
        private NotificationTypeProjectUpdateApproved(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProjectUpdateApproved Instance = new NotificationTypeProjectUpdateApproved(4, @"ProjectUpdateApproved", @"Project Update Approved");
    }

    public partial class NotificationTypeCustom : NotificationType
    {
        private NotificationTypeCustom(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeCustom Instance = new NotificationTypeCustom(5, @"Custom", @"Custom Notification");
    }

    public partial class NotificationTypeProposedProjectSubmitted : NotificationType
    {
        private NotificationTypeProposedProjectSubmitted(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProposedProjectSubmitted Instance = new NotificationTypeProposedProjectSubmitted(6, @"ProposedProjectSubmitted", @"Proposed Project Submitted");
    }

    public partial class NotificationTypeProposedProjectApproved : NotificationType
    {
        private NotificationTypeProposedProjectApproved(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProposedProjectApproved Instance = new NotificationTypeProposedProjectApproved(7, @"ProposedProjectApproved", @"Proposed Project Approved");
    }

    public partial class NotificationTypeProposedProjectReturned : NotificationType
    {
        private NotificationTypeProposedProjectReturned(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProposedProjectReturned Instance = new NotificationTypeProposedProjectReturned(8, @"ProposedProjectReturned", @"Proposed Project Returned");
    }
}