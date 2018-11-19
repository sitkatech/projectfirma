//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActivityType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class ActivityType : IHavePrimaryKey
    {
        public static readonly ActivityTypeTravel Travel = ActivityTypeTravel.Instance;
        public static readonly ActivityTypeStaffTime StaffTime = ActivityTypeStaffTime.Instance;
        public static readonly ActivityTypeTreatment Treatment = ActivityTypeTreatment.Instance;
        public static readonly ActivityTypeContractorTime ContractorTime = ActivityTypeContractorTime.Instance;
        public static readonly ActivityTypeSupplies Supplies = ActivityTypeSupplies.Instance;

        public static readonly List<ActivityType> All;
        public static readonly ReadOnlyDictionary<int, ActivityType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ActivityType()
        {
            All = new List<ActivityType> { Travel, StaffTime, Treatment, ContractorTime, Supplies };
            AllLookupDictionary = new ReadOnlyDictionary<int, ActivityType>(All.ToDictionary(x => x.ActivityTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ActivityType(int activityTypeID, string activityTypeName, string activityTypeDisplayName)
        {
            ActivityTypeID = activityTypeID;
            ActivityTypeName = activityTypeName;
            ActivityTypeDisplayName = activityTypeDisplayName;
        }

        [Key]
        public int ActivityTypeID { get; private set; }
        public string ActivityTypeName { get; private set; }
        public string ActivityTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ActivityTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ActivityType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ActivityTypeID == ActivityTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ActivityType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ActivityTypeID;
        }

        public static bool operator ==(ActivityType left, ActivityType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ActivityType left, ActivityType right)
        {
            return !Equals(left, right);
        }

        public ActivityTypeEnum ToEnum { get { return (ActivityTypeEnum)GetHashCode(); } }

        public static ActivityType ToType(int enumValue)
        {
            return ToType((ActivityTypeEnum)enumValue);
        }

        public static ActivityType ToType(ActivityTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ActivityTypeEnum.ContractorTime:
                    return ContractorTime;
                case ActivityTypeEnum.StaffTime:
                    return StaffTime;
                case ActivityTypeEnum.Supplies:
                    return Supplies;
                case ActivityTypeEnum.Travel:
                    return Travel;
                case ActivityTypeEnum.Treatment:
                    return Treatment;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ActivityTypeEnum
    {
        Travel = 1,
        StaffTime = 2,
        Treatment = 3,
        ContractorTime = 4,
        Supplies = 5
    }

    public partial class ActivityTypeTravel : ActivityType
    {
        private ActivityTypeTravel(int activityTypeID, string activityTypeName, string activityTypeDisplayName) : base(activityTypeID, activityTypeName, activityTypeDisplayName) {}
        public static readonly ActivityTypeTravel Instance = new ActivityTypeTravel(1, @"Travel", @"Travel");
    }

    public partial class ActivityTypeStaffTime : ActivityType
    {
        private ActivityTypeStaffTime(int activityTypeID, string activityTypeName, string activityTypeDisplayName) : base(activityTypeID, activityTypeName, activityTypeDisplayName) {}
        public static readonly ActivityTypeStaffTime Instance = new ActivityTypeStaffTime(2, @"StaffTime", @"Staff Time");
    }

    public partial class ActivityTypeTreatment : ActivityType
    {
        private ActivityTypeTreatment(int activityTypeID, string activityTypeName, string activityTypeDisplayName) : base(activityTypeID, activityTypeName, activityTypeDisplayName) {}
        public static readonly ActivityTypeTreatment Instance = new ActivityTypeTreatment(3, @"Treatment", @"Treatment");
    }

    public partial class ActivityTypeContractorTime : ActivityType
    {
        private ActivityTypeContractorTime(int activityTypeID, string activityTypeName, string activityTypeDisplayName) : base(activityTypeID, activityTypeName, activityTypeDisplayName) {}
        public static readonly ActivityTypeContractorTime Instance = new ActivityTypeContractorTime(4, @"ContractorTime", @"Contractor Time");
    }

    public partial class ActivityTypeSupplies : ActivityType
    {
        private ActivityTypeSupplies(int activityTypeID, string activityTypeName, string activityTypeDisplayName) : base(activityTypeID, activityTypeName, activityTypeDisplayName) {}
        public static readonly ActivityTypeSupplies Instance = new ActivityTypeSupplies(5, @"Supplies", @"Supplies");
    }
}