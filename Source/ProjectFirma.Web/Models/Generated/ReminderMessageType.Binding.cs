//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReminderMessageType]
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
    public abstract partial class ReminderMessageType : IHavePrimaryKey
    {
        public static readonly ReminderMessageTypeKickoffReminder KickoffReminder = ReminderMessageTypeKickoffReminder.Instance;
        public static readonly ReminderMessageTypeSecondReminder SecondReminder = ReminderMessageTypeSecondReminder.Instance;
        public static readonly ReminderMessageTypeThirdReminder ThirdReminder = ReminderMessageTypeThirdReminder.Instance;
        public static readonly ReminderMessageTypeNearingDeadlineReminder NearingDeadlineReminder = ReminderMessageTypeNearingDeadlineReminder.Instance;
        public static readonly ReminderMessageTypeAtDeadlineReminder AtDeadlineReminder = ReminderMessageTypeAtDeadlineReminder.Instance;
        public static readonly ReminderMessageTypePastDeadlineReminder PastDeadlineReminder = ReminderMessageTypePastDeadlineReminder.Instance;

        public static readonly List<ReminderMessageType> All;
        public static readonly ReadOnlyDictionary<int, ReminderMessageType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ReminderMessageType()
        {
            All = new List<ReminderMessageType> { KickoffReminder, SecondReminder, ThirdReminder, NearingDeadlineReminder, AtDeadlineReminder, PastDeadlineReminder };
            AllLookupDictionary = new ReadOnlyDictionary<int, ReminderMessageType>(All.ToDictionary(x => x.ReminderMessageTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ReminderMessageType(int reminderMessageTypeID, string reminderMessageTypeName, string reminderMessageTypeDisplayName, string reminderMessageTypeSubject)
        {
            ReminderMessageTypeID = reminderMessageTypeID;
            ReminderMessageTypeName = reminderMessageTypeName;
            ReminderMessageTypeDisplayName = reminderMessageTypeDisplayName;
            ReminderMessageTypeSubject = reminderMessageTypeSubject;
        }

        [Key]
        public int ReminderMessageTypeID { get; private set; }
        public string ReminderMessageTypeName { get; private set; }
        public string ReminderMessageTypeDisplayName { get; private set; }
        public string ReminderMessageTypeSubject { get; private set; }
        public int PrimaryKey { get { return ReminderMessageTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ReminderMessageType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ReminderMessageTypeID == ReminderMessageTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ReminderMessageType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ReminderMessageTypeID;
        }

        public static bool operator ==(ReminderMessageType left, ReminderMessageType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReminderMessageType left, ReminderMessageType right)
        {
            return !Equals(left, right);
        }

        public ReminderMessageTypeEnum ToEnum { get { return (ReminderMessageTypeEnum)GetHashCode(); } }

        public static ReminderMessageType ToType(int enumValue)
        {
            return ToType((ReminderMessageTypeEnum)enumValue);
        }

        public static ReminderMessageType ToType(ReminderMessageTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ReminderMessageTypeEnum.AtDeadlineReminder:
                    return AtDeadlineReminder;
                case ReminderMessageTypeEnum.KickoffReminder:
                    return KickoffReminder;
                case ReminderMessageTypeEnum.NearingDeadlineReminder:
                    return NearingDeadlineReminder;
                case ReminderMessageTypeEnum.PastDeadlineReminder:
                    return PastDeadlineReminder;
                case ReminderMessageTypeEnum.SecondReminder:
                    return SecondReminder;
                case ReminderMessageTypeEnum.ThirdReminder:
                    return ThirdReminder;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ReminderMessageTypeEnum
    {
        KickoffReminder = 1,
        SecondReminder = 2,
        ThirdReminder = 3,
        NearingDeadlineReminder = 4,
        AtDeadlineReminder = 5,
        PastDeadlineReminder = 6
    }

    public partial class ReminderMessageTypeKickoffReminder : ReminderMessageType
    {
        private ReminderMessageTypeKickoffReminder(int reminderMessageTypeID, string reminderMessageTypeName, string reminderMessageTypeDisplayName, string reminderMessageTypeSubject) : base(reminderMessageTypeID, reminderMessageTypeName, reminderMessageTypeDisplayName, reminderMessageTypeSubject) {}
        public static readonly ReminderMessageTypeKickoffReminder Instance = new ReminderMessageTypeKickoffReminder(1, @"KickoffReminder", @"Kickoff Reminder (Nov 1)", @"Time to update your EIP Projects (Nov 1 reminder)");
    }

    public partial class ReminderMessageTypeSecondReminder : ReminderMessageType
    {
        private ReminderMessageTypeSecondReminder(int reminderMessageTypeID, string reminderMessageTypeName, string reminderMessageTypeDisplayName, string reminderMessageTypeSubject) : base(reminderMessageTypeID, reminderMessageTypeName, reminderMessageTypeDisplayName, reminderMessageTypeSubject) {}
        public static readonly ReminderMessageTypeSecondReminder Instance = new ReminderMessageTypeSecondReminder(2, @"SecondReminder", @"Second Reminder (Dec 1)", @"Time to update your EIP Projects (Dec 1 reminder)");
    }

    public partial class ReminderMessageTypeThirdReminder : ReminderMessageType
    {
        private ReminderMessageTypeThirdReminder(int reminderMessageTypeID, string reminderMessageTypeName, string reminderMessageTypeDisplayName, string reminderMessageTypeSubject) : base(reminderMessageTypeID, reminderMessageTypeName, reminderMessageTypeDisplayName, reminderMessageTypeSubject) {}
        public static readonly ReminderMessageTypeThirdReminder Instance = new ReminderMessageTypeThirdReminder(3, @"ThirdReminder", @"Third Reminder  (Jan 5)", @"Time to update your EIP Projects (Jan 5 reminder)");
    }

    public partial class ReminderMessageTypeNearingDeadlineReminder : ReminderMessageType
    {
        private ReminderMessageTypeNearingDeadlineReminder(int reminderMessageTypeID, string reminderMessageTypeName, string reminderMessageTypeDisplayName, string reminderMessageTypeSubject) : base(reminderMessageTypeID, reminderMessageTypeName, reminderMessageTypeDisplayName, reminderMessageTypeSubject) {}
        public static readonly ReminderMessageTypeNearingDeadlineReminder Instance = new ReminderMessageTypeNearingDeadlineReminder(4, @"NearingDeadlineReminder", @"Nearing Deadline Reminder (Jan 10)", @"Time to update your EIP Projects (Jan 10 reminder)");
    }

    public partial class ReminderMessageTypeAtDeadlineReminder : ReminderMessageType
    {
        private ReminderMessageTypeAtDeadlineReminder(int reminderMessageTypeID, string reminderMessageTypeName, string reminderMessageTypeDisplayName, string reminderMessageTypeSubject) : base(reminderMessageTypeID, reminderMessageTypeName, reminderMessageTypeDisplayName, reminderMessageTypeSubject) {}
        public static readonly ReminderMessageTypeAtDeadlineReminder Instance = new ReminderMessageTypeAtDeadlineReminder(5, @"AtDeadlineReminder", @"At Deadline Reminder (Jan 15)", @"Time to update your EIP Projects (Jan 15 reminder)");
    }

    public partial class ReminderMessageTypePastDeadlineReminder : ReminderMessageType
    {
        private ReminderMessageTypePastDeadlineReminder(int reminderMessageTypeID, string reminderMessageTypeName, string reminderMessageTypeDisplayName, string reminderMessageTypeSubject) : base(reminderMessageTypeID, reminderMessageTypeName, reminderMessageTypeDisplayName, reminderMessageTypeSubject) {}
        public static readonly ReminderMessageTypePastDeadlineReminder Instance = new ReminderMessageTypePastDeadlineReminder(6, @"PastDeadlineReminder", @"Past Deadline Reminder (Every 5 days after Jan 15)", @"Time to update your EIP Projects (Past-due reminder)");
    }
}