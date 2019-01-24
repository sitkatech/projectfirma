//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class NotificationType : IHavePrimaryKey
    {
        public static readonly NotificationTypeProjectUpdateReminder ProjectUpdateReminder = NotificationTypeProjectUpdateReminder.Instance;
        public static readonly NotificationTypeProjectUpdateSubmitted ProjectUpdateSubmitted = NotificationTypeProjectUpdateSubmitted.Instance;
        public static readonly NotificationTypeProjectUpdateReturned ProjectUpdateReturned = NotificationTypeProjectUpdateReturned.Instance;
        public static readonly NotificationTypeProjectUpdateApproved ProjectUpdateApproved = NotificationTypeProjectUpdateApproved.Instance;
        public static readonly NotificationTypeCustom Custom = NotificationTypeCustom.Instance;
        public static readonly NotificationTypeProjectSubmitted ProjectSubmitted = NotificationTypeProjectSubmitted.Instance;
        public static readonly NotificationTypeProjectApproved ProjectApproved = NotificationTypeProjectApproved.Instance;
        public static readonly NotificationTypeProjectReturned ProjectReturned = NotificationTypeProjectReturned.Instance;

        public static readonly List<NotificationType> All;
        public static readonly ReadOnlyDictionary<int, NotificationType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static NotificationType()
        {
            All = new List<NotificationType> { ProjectUpdateReminder, ProjectUpdateSubmitted, ProjectUpdateReturned, ProjectUpdateApproved, Custom, ProjectSubmitted, ProjectApproved, ProjectReturned };
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
        [NotMapped]
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
                case NotificationTypeEnum.ProjectApproved:
                    return ProjectApproved;
                case NotificationTypeEnum.ProjectReturned:
                    return ProjectReturned;
                case NotificationTypeEnum.ProjectSubmitted:
                    return ProjectSubmitted;
                case NotificationTypeEnum.ProjectUpdateApproved:
                    return ProjectUpdateApproved;
                case NotificationTypeEnum.ProjectUpdateReminder:
                    return ProjectUpdateReminder;
                case NotificationTypeEnum.ProjectUpdateReturned:
                    return ProjectUpdateReturned;
                case NotificationTypeEnum.ProjectUpdateSubmitted:
                    return ProjectUpdateSubmitted;
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
        ProjectSubmitted = 6,
        ProjectApproved = 7,
        ProjectReturned = 8
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

    public partial class NotificationTypeProjectSubmitted : NotificationType
    {
        private NotificationTypeProjectSubmitted(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProjectSubmitted Instance = new NotificationTypeProjectSubmitted(6, @"ProjectSubmitted", @"Project Submitted");
    }

    public partial class NotificationTypeProjectApproved : NotificationType
    {
        private NotificationTypeProjectApproved(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProjectApproved Instance = new NotificationTypeProjectApproved(7, @"ProjectApproved", @"Project Approved");
    }

    public partial class NotificationTypeProjectReturned : NotificationType
    {
        private NotificationTypeProjectReturned(int notificationTypeID, string notificationTypeName, string notificationTypeDisplayName) : base(notificationTypeID, notificationTypeName, notificationTypeDisplayName) {}
        public static readonly NotificationTypeProjectReturned Instance = new NotificationTypeProjectReturned(8, @"ProjectReturned", @"Project Returned");
    }
}