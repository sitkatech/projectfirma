//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityRole]
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
    public abstract partial class SustainabilityRole : IHavePrimaryKey
    {
        public static readonly SustainabilityRoleAdmin Admin = SustainabilityRoleAdmin.Instance;
        public static readonly SustainabilityRoleNormal Normal = SustainabilityRoleNormal.Instance;
        public static readonly SustainabilityRoleUnassigned Unassigned = SustainabilityRoleUnassigned.Instance;

        public static readonly List<SustainabilityRole> All;
        public static readonly ReadOnlyDictionary<int, SustainabilityRole> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static SustainabilityRole()
        {
            All = new List<SustainabilityRole> { Admin, Normal, Unassigned };
            AllLookupDictionary = new ReadOnlyDictionary<int, SustainabilityRole>(All.ToDictionary(x => x.SustainabilityRoleID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected SustainabilityRole(int sustainabilityRoleID, string sustainabilityRoleName, string sustainabilityRoleDisplayName, string sustainabilityRoleDescription, int lTInfoAreaID)
        {
            SustainabilityRoleID = sustainabilityRoleID;
            SustainabilityRoleName = sustainabilityRoleName;
            SustainabilityRoleDisplayName = sustainabilityRoleDisplayName;
            SustainabilityRoleDescription = sustainabilityRoleDescription;
            LTInfoAreaID = lTInfoAreaID;
        }
        public LTInfoArea LTInfoArea { get { return LTInfoArea.AllLookupDictionary[LTInfoAreaID]; } }
        [Key]
        public int SustainabilityRoleID { get; private set; }
        public string SustainabilityRoleName { get; private set; }
        public string SustainabilityRoleDisplayName { get; private set; }
        public string SustainabilityRoleDescription { get; private set; }
        public int LTInfoAreaID { get; private set; }
        public int PrimaryKey { get { return SustainabilityRoleID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(SustainabilityRole other)
        {
            if (other == null)
            {
                return false;
            }
            return other.SustainabilityRoleID == SustainabilityRoleID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as SustainabilityRole);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return SustainabilityRoleID;
        }

        public static bool operator ==(SustainabilityRole left, SustainabilityRole right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SustainabilityRole left, SustainabilityRole right)
        {
            return !Equals(left, right);
        }

        public SustainabilityRoleEnum ToEnum { get { return (SustainabilityRoleEnum)GetHashCode(); } }

        public static SustainabilityRole ToType(int enumValue)
        {
            return ToType((SustainabilityRoleEnum)enumValue);
        }

        public static SustainabilityRole ToType(SustainabilityRoleEnum enumValue)
        {
            switch (enumValue)
            {
                case SustainabilityRoleEnum.Admin:
                    return Admin;
                case SustainabilityRoleEnum.Normal:
                    return Normal;
                case SustainabilityRoleEnum.Unassigned:
                    return Unassigned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum SustainabilityRoleEnum
    {
        Admin = 1,
        Normal = 2,
        Unassigned = 3
    }

    public partial class SustainabilityRoleAdmin : SustainabilityRole
    {
        private SustainabilityRoleAdmin(int sustainabilityRoleID, string sustainabilityRoleName, string sustainabilityRoleDisplayName, string sustainabilityRoleDescription, int lTInfoAreaID) : base(sustainabilityRoleID, sustainabilityRoleName, sustainabilityRoleDisplayName, sustainabilityRoleDescription, lTInfoAreaID) {}
        public static readonly SustainabilityRoleAdmin Instance = new SustainabilityRoleAdmin(1, @"Admin", @"Administrator", @"", 2);
    }

    public partial class SustainabilityRoleNormal : SustainabilityRole
    {
        private SustainabilityRoleNormal(int sustainabilityRoleID, string sustainabilityRoleName, string sustainabilityRoleDisplayName, string sustainabilityRoleDescription, int lTInfoAreaID) : base(sustainabilityRoleID, sustainabilityRoleName, sustainabilityRoleDisplayName, sustainabilityRoleDescription, lTInfoAreaID) {}
        public static readonly SustainabilityRoleNormal Instance = new SustainabilityRoleNormal(2, @"Normal", @"Normal User", @"Users with this role can't do anything special - they are functionally equivalent to anonymous users, but this could change over time as we add functionality to the Sustainability Dashboard.", 2);
    }

    public partial class SustainabilityRoleUnassigned : SustainabilityRole
    {
        private SustainabilityRoleUnassigned(int sustainabilityRoleID, string sustainabilityRoleName, string sustainabilityRoleDisplayName, string sustainabilityRoleDescription, int lTInfoAreaID) : base(sustainabilityRoleID, sustainabilityRoleName, sustainabilityRoleDisplayName, sustainabilityRoleDescription, lTInfoAreaID) {}
        public static readonly SustainabilityRoleUnassigned Instance = new SustainabilityRoleUnassigned(3, @"Unassigned", @"Unassigned", @"", 2);
    }
}