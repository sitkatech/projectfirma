//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdRole]
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
    public abstract partial class ThresholdRole : IHavePrimaryKey
    {
        public static readonly ThresholdRoleAdmin Admin = ThresholdRoleAdmin.Instance;
        public static readonly ThresholdRoleNormal Normal = ThresholdRoleNormal.Instance;
        public static readonly ThresholdRoleUnassigned Unassigned = ThresholdRoleUnassigned.Instance;

        public static readonly List<ThresholdRole> All;
        public static readonly ReadOnlyDictionary<int, ThresholdRole> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ThresholdRole()
        {
            All = new List<ThresholdRole> { Admin, Normal, Unassigned };
            AllLookupDictionary = new ReadOnlyDictionary<int, ThresholdRole>(All.ToDictionary(x => x.ThresholdRoleID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ThresholdRole(int thresholdRoleID, string thresholdRoleName, string thresholdRoleDisplayName, string thresholdRoleDescription, int lTInfoAreaID)
        {
            ThresholdRoleID = thresholdRoleID;
            ThresholdRoleName = thresholdRoleName;
            ThresholdRoleDisplayName = thresholdRoleDisplayName;
            ThresholdRoleDescription = thresholdRoleDescription;
            LTInfoAreaID = lTInfoAreaID;
        }
        public LTInfoArea LTInfoArea { get { return LTInfoArea.AllLookupDictionary[LTInfoAreaID]; } }
        [Key]
        public int ThresholdRoleID { get; private set; }
        public string ThresholdRoleName { get; private set; }
        public string ThresholdRoleDisplayName { get; private set; }
        public string ThresholdRoleDescription { get; private set; }
        public int LTInfoAreaID { get; private set; }
        public int PrimaryKey { get { return ThresholdRoleID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ThresholdRole other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ThresholdRoleID == ThresholdRoleID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ThresholdRole);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ThresholdRoleID;
        }

        public static bool operator ==(ThresholdRole left, ThresholdRole right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThresholdRole left, ThresholdRole right)
        {
            return !Equals(left, right);
        }

        public ThresholdRoleEnum ToEnum { get { return (ThresholdRoleEnum)GetHashCode(); } }

        public static ThresholdRole ToType(int enumValue)
        {
            return ToType((ThresholdRoleEnum)enumValue);
        }

        public static ThresholdRole ToType(ThresholdRoleEnum enumValue)
        {
            switch (enumValue)
            {
                case ThresholdRoleEnum.Admin:
                    return Admin;
                case ThresholdRoleEnum.Normal:
                    return Normal;
                case ThresholdRoleEnum.Unassigned:
                    return Unassigned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ThresholdRoleEnum
    {
        Admin = 1,
        Normal = 2,
        Unassigned = 3
    }

    public partial class ThresholdRoleAdmin : ThresholdRole
    {
        private ThresholdRoleAdmin(int thresholdRoleID, string thresholdRoleName, string thresholdRoleDisplayName, string thresholdRoleDescription, int lTInfoAreaID) : base(thresholdRoleID, thresholdRoleName, thresholdRoleDisplayName, thresholdRoleDescription, lTInfoAreaID) {}
        public static readonly ThresholdRoleAdmin Instance = new ThresholdRoleAdmin(1, @"Admin", @"Administrator", @"", 5);
    }

    public partial class ThresholdRoleNormal : ThresholdRole
    {
        private ThresholdRoleNormal(int thresholdRoleID, string thresholdRoleName, string thresholdRoleDisplayName, string thresholdRoleDescription, int lTInfoAreaID) : base(thresholdRoleID, thresholdRoleName, thresholdRoleDisplayName, thresholdRoleDescription, lTInfoAreaID) {}
        public static readonly ThresholdRoleNormal Instance = new ThresholdRoleNormal(2, @"Normal", @"Normal User", @"Users with this role can't do anything special - they are functionally equivalent to anonymous users, but this could change over time as we add functionality to the Thresholds Dashboard.", 5);
    }

    public partial class ThresholdRoleUnassigned : ThresholdRole
    {
        private ThresholdRoleUnassigned(int thresholdRoleID, string thresholdRoleName, string thresholdRoleDisplayName, string thresholdRoleDescription, int lTInfoAreaID) : base(thresholdRoleID, thresholdRoleName, thresholdRoleDisplayName, thresholdRoleDescription, lTInfoAreaID) {}
        public static readonly ThresholdRoleUnassigned Instance = new ThresholdRoleUnassigned(3, @"Unassigned", @"Unassigned", @"", 5);
    }
}