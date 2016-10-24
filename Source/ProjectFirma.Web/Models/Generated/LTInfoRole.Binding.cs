//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LTInfoRole]
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
    public abstract partial class LTInfoRole : IHavePrimaryKey
    {
        public static readonly LTInfoRoleAdmin Admin = LTInfoRoleAdmin.Instance;
        public static readonly LTInfoRoleNormal Normal = LTInfoRoleNormal.Instance;
        public static readonly LTInfoRoleUnassigned Unassigned = LTInfoRoleUnassigned.Instance;
        public static readonly LTInfoRoleIndicatorEditor IndicatorEditor = LTInfoRoleIndicatorEditor.Instance;

        public static readonly List<LTInfoRole> All;
        public static readonly ReadOnlyDictionary<int, LTInfoRole> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static LTInfoRole()
        {
            All = new List<LTInfoRole> { Admin, Normal, Unassigned, IndicatorEditor };
            AllLookupDictionary = new ReadOnlyDictionary<int, LTInfoRole>(All.ToDictionary(x => x.LTInfoRoleID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected LTInfoRole(int lTInfoRoleID, string lTInfoRoleName, string lTInfoRoleDisplayName, string lTInfoRoleDescription, int lTInfoAreaID)
        {
            LTInfoRoleID = lTInfoRoleID;
            LTInfoRoleName = lTInfoRoleName;
            LTInfoRoleDisplayName = lTInfoRoleDisplayName;
            LTInfoRoleDescription = lTInfoRoleDescription;
            LTInfoAreaID = lTInfoAreaID;
        }
        public LTInfoArea LTInfoArea { get { return LTInfoArea.AllLookupDictionary[LTInfoAreaID]; } }
        [Key]
        public int LTInfoRoleID { get; private set; }
        public string LTInfoRoleName { get; private set; }
        public string LTInfoRoleDisplayName { get; private set; }
        public string LTInfoRoleDescription { get; private set; }
        public int LTInfoAreaID { get; private set; }
        public int PrimaryKey { get { return LTInfoRoleID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(LTInfoRole other)
        {
            if (other == null)
            {
                return false;
            }
            return other.LTInfoRoleID == LTInfoRoleID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as LTInfoRole);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return LTInfoRoleID;
        }

        public static bool operator ==(LTInfoRole left, LTInfoRole right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LTInfoRole left, LTInfoRole right)
        {
            return !Equals(left, right);
        }

        public LTInfoRoleEnum ToEnum { get { return (LTInfoRoleEnum)GetHashCode(); } }

        public static LTInfoRole ToType(int enumValue)
        {
            return ToType((LTInfoRoleEnum)enumValue);
        }

        public static LTInfoRole ToType(LTInfoRoleEnum enumValue)
        {
            switch (enumValue)
            {
                case LTInfoRoleEnum.Admin:
                    return Admin;
                case LTInfoRoleEnum.IndicatorEditor:
                    return IndicatorEditor;
                case LTInfoRoleEnum.Normal:
                    return Normal;
                case LTInfoRoleEnum.Unassigned:
                    return Unassigned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum LTInfoRoleEnum
    {
        Admin = 1,
        Normal = 2,
        Unassigned = 3,
        IndicatorEditor = 4
    }

    public partial class LTInfoRoleAdmin : LTInfoRole
    {
        private LTInfoRoleAdmin(int lTInfoRoleID, string lTInfoRoleName, string lTInfoRoleDisplayName, string lTInfoRoleDescription, int lTInfoAreaID) : base(lTInfoRoleID, lTInfoRoleName, lTInfoRoleDisplayName, lTInfoRoleDescription, lTInfoAreaID) {}
        public static readonly LTInfoRoleAdmin Instance = new LTInfoRoleAdmin(1, @"Admin", @"Administrator", @"", 3);
    }

    public partial class LTInfoRoleNormal : LTInfoRole
    {
        private LTInfoRoleNormal(int lTInfoRoleID, string lTInfoRoleName, string lTInfoRoleDisplayName, string lTInfoRoleDescription, int lTInfoAreaID) : base(lTInfoRoleID, lTInfoRoleName, lTInfoRoleDisplayName, lTInfoRoleDescription, lTInfoAreaID) {}
        public static readonly LTInfoRoleNormal Instance = new LTInfoRoleNormal(2, @"Normal", @"Normal User", @"Users with this role can view other user's profile or summary pages; otherwise, they are functionally equivalent to anonymous users.", 3);
    }

    public partial class LTInfoRoleUnassigned : LTInfoRole
    {
        private LTInfoRoleUnassigned(int lTInfoRoleID, string lTInfoRoleName, string lTInfoRoleDisplayName, string lTInfoRoleDescription, int lTInfoAreaID) : base(lTInfoRoleID, lTInfoRoleName, lTInfoRoleDisplayName, lTInfoRoleDescription, lTInfoAreaID) {}
        public static readonly LTInfoRoleUnassigned Instance = new LTInfoRoleUnassigned(3, @"Unassigned", @"Unassigned", @"", 3);
    }

    public partial class LTInfoRoleIndicatorEditor : LTInfoRole
    {
        private LTInfoRoleIndicatorEditor(int lTInfoRoleID, string lTInfoRoleName, string lTInfoRoleDisplayName, string lTInfoRoleDescription, int lTInfoAreaID) : base(lTInfoRoleID, lTInfoRoleName, lTInfoRoleDisplayName, lTInfoRoleDescription, lTInfoAreaID) {}
        public static readonly LTInfoRoleIndicatorEditor Instance = new LTInfoRoleIndicatorEditor(4, @"IndicatorEditor", @"Indicator Editor", @"", 3);
    }
}