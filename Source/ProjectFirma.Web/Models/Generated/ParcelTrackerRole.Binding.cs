//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelTrackerRole]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public abstract partial class ParcelTrackerRole : IHavePrimaryKey
    {
        public static readonly ParcelTrackerRoleAdmin Admin = ParcelTrackerRoleAdmin.Instance;
        public static readonly ParcelTrackerRolePower Power = ParcelTrackerRolePower.Instance;
        public static readonly ParcelTrackerRoleNormal Normal = ParcelTrackerRoleNormal.Instance;
        public static readonly ParcelTrackerRoleReadOnly ReadOnly = ParcelTrackerRoleReadOnly.Instance;
        public static readonly ParcelTrackerRoleParcelEditor ParcelEditor = ParcelTrackerRoleParcelEditor.Instance;
        public static readonly ParcelTrackerRoleUnassigned Unassigned = ParcelTrackerRoleUnassigned.Instance;

        public static readonly List<ParcelTrackerRole> All;
        public static readonly ReadOnlyDictionary<int, ParcelTrackerRole> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ParcelTrackerRole()
        {
            All = new List<ParcelTrackerRole> { Admin, Power, Normal, ReadOnly, ParcelEditor, Unassigned };
            AllLookupDictionary = new ReadOnlyDictionary<int, ParcelTrackerRole>(All.ToDictionary(x => x.ParcelTrackerRoleID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ParcelTrackerRole(int parcelTrackerRoleID, string parcelTrackerRoleName, string parcelTrackerRoleDisplayName, string parcelTrackerRoleDescription, int lTInfoAreaID)
        {
            ParcelTrackerRoleID = parcelTrackerRoleID;
            ParcelTrackerRoleName = parcelTrackerRoleName;
            ParcelTrackerRoleDisplayName = parcelTrackerRoleDisplayName;
            ParcelTrackerRoleDescription = parcelTrackerRoleDescription;
            LTInfoAreaID = lTInfoAreaID;
        }
        public LTInfoArea LTInfoArea { get { return LTInfoArea.AllLookupDictionary[LTInfoAreaID]; } }
        [Key]
        public int ParcelTrackerRoleID { get; private set; }
        public string ParcelTrackerRoleName { get; private set; }
        public string ParcelTrackerRoleDisplayName { get; private set; }
        public string ParcelTrackerRoleDescription { get; private set; }
        public int LTInfoAreaID { get; private set; }
        public int PrimaryKey { get { return ParcelTrackerRoleID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ParcelTrackerRole other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ParcelTrackerRoleID == ParcelTrackerRoleID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ParcelTrackerRole);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ParcelTrackerRoleID;
        }

        public static bool operator ==(ParcelTrackerRole left, ParcelTrackerRole right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ParcelTrackerRole left, ParcelTrackerRole right)
        {
            return !Equals(left, right);
        }

        public ParcelTrackerRoleEnum ToEnum { get { return (ParcelTrackerRoleEnum)GetHashCode(); } }

        public static ParcelTrackerRole ToType(int enumValue)
        {
            return ToType((ParcelTrackerRoleEnum)enumValue);
        }

        public static ParcelTrackerRole ToType(ParcelTrackerRoleEnum enumValue)
        {
            switch (enumValue)
            {
                case ParcelTrackerRoleEnum.Admin:
                    return Admin;
                case ParcelTrackerRoleEnum.Normal:
                    return Normal;
                case ParcelTrackerRoleEnum.ParcelEditor:
                    return ParcelEditor;
                case ParcelTrackerRoleEnum.Power:
                    return Power;
                case ParcelTrackerRoleEnum.ReadOnly:
                    return ReadOnly;
                case ParcelTrackerRoleEnum.Unassigned:
                    return Unassigned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ParcelTrackerRoleEnum
    {
        Admin = 1,
        Power = 2,
        Normal = 3,
        ReadOnly = 4,
        ParcelEditor = 6,
        Unassigned = 7
    }

    public partial class ParcelTrackerRoleAdmin : ParcelTrackerRole
    {
        private ParcelTrackerRoleAdmin(int parcelTrackerRoleID, string parcelTrackerRoleName, string parcelTrackerRoleDisplayName, string parcelTrackerRoleDescription, int lTInfoAreaID) : base(parcelTrackerRoleID, parcelTrackerRoleName, parcelTrackerRoleDisplayName, parcelTrackerRoleDescription, lTInfoAreaID) {}
        public static readonly ParcelTrackerRoleAdmin Instance = new ParcelTrackerRoleAdmin(1, @"Admin", @"Administrator", @"", 4);
    }

    public partial class ParcelTrackerRolePower : ParcelTrackerRole
    {
        private ParcelTrackerRolePower(int parcelTrackerRoleID, string parcelTrackerRoleName, string parcelTrackerRoleDisplayName, string parcelTrackerRoleDescription, int lTInfoAreaID) : base(parcelTrackerRoleID, parcelTrackerRoleName, parcelTrackerRoleDisplayName, parcelTrackerRoleDescription, lTInfoAreaID) {}
        public static readonly ParcelTrackerRolePower Instance = new ParcelTrackerRolePower(2, @"Power", @"Power User", @"", 4);
    }

    public partial class ParcelTrackerRoleNormal : ParcelTrackerRole
    {
        private ParcelTrackerRoleNormal(int parcelTrackerRoleID, string parcelTrackerRoleName, string parcelTrackerRoleDisplayName, string parcelTrackerRoleDescription, int lTInfoAreaID) : base(parcelTrackerRoleID, parcelTrackerRoleName, parcelTrackerRoleDisplayName, parcelTrackerRoleDescription, lTInfoAreaID) {}
        public static readonly ParcelTrackerRoleNormal Instance = new ParcelTrackerRoleNormal(3, @"Normal", @"Normal User", @"Users with this role can draft and submit commodities transactions but are limited to transaction types based on their affiliated organization (Lead Agency). They can also delete draft transactions that they created.", 4);
    }

    public partial class ParcelTrackerRoleReadOnly : ParcelTrackerRole
    {
        private ParcelTrackerRoleReadOnly(int parcelTrackerRoleID, string parcelTrackerRoleName, string parcelTrackerRoleDisplayName, string parcelTrackerRoleDescription, int lTInfoAreaID) : base(parcelTrackerRoleID, parcelTrackerRoleName, parcelTrackerRoleDisplayName, parcelTrackerRoleDescription, lTInfoAreaID) {}
        public static readonly ParcelTrackerRoleReadOnly Instance = new ParcelTrackerRoleReadOnly(4, @"ReadOnly", @"Read-only User", @"", 4);
    }

    public partial class ParcelTrackerRoleParcelEditor : ParcelTrackerRole
    {
        private ParcelTrackerRoleParcelEditor(int parcelTrackerRoleID, string parcelTrackerRoleName, string parcelTrackerRoleDisplayName, string parcelTrackerRoleDescription, int lTInfoAreaID) : base(parcelTrackerRoleID, parcelTrackerRoleName, parcelTrackerRoleDisplayName, parcelTrackerRoleDescription, lTInfoAreaID) {}
        public static readonly ParcelTrackerRoleParcelEditor Instance = new ParcelTrackerRoleParcelEditor(6, @"ParcelEditor", @"Parcel Editor", @"Users with this role have same permissions as Normal Users, but can also add parcels, update parcel information, add land capability records, and bank commodities.", 4);
    }

    public partial class ParcelTrackerRoleUnassigned : ParcelTrackerRole
    {
        private ParcelTrackerRoleUnassigned(int parcelTrackerRoleID, string parcelTrackerRoleName, string parcelTrackerRoleDisplayName, string parcelTrackerRoleDescription, int lTInfoAreaID) : base(parcelTrackerRoleID, parcelTrackerRoleName, parcelTrackerRoleDisplayName, parcelTrackerRoleDescription, lTInfoAreaID) {}
        public static readonly ParcelTrackerRoleUnassigned Instance = new ParcelTrackerRoleUnassigned(7, @"Unassigned", @"Unassigned", @"", 4);
    }
}