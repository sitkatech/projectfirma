//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Role]
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
    public abstract partial class Role : IHavePrimaryKey
    {
        public static readonly RoleAdmin Admin = RoleAdmin.Instance;
        public static readonly RoleNormal Normal = RoleNormal.Instance;
        public static readonly RoleUnassigned Unassigned = RoleUnassigned.Instance;
        public static readonly RoleSitkaAdmin SitkaAdmin = RoleSitkaAdmin.Instance;
        public static readonly RoleProjectSteward ProjectSteward = RoleProjectSteward.Instance;

        public static readonly List<Role> All;
        public static readonly ReadOnlyDictionary<int, Role> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static Role()
        {
            All = new List<Role> { Admin, Normal, Unassigned, SitkaAdmin, ProjectSteward };
            AllLookupDictionary = new ReadOnlyDictionary<int, Role>(All.ToDictionary(x => x.RoleID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected Role(int roleID, string roleName, string roleDisplayName, string roleDescription)
        {
            RoleID = roleID;
            RoleName = roleName;
            RoleDisplayName = roleDisplayName;
            RoleDescription = roleDescription;
        }

        [Key]
        public int RoleID { get; private set; }
        public string RoleName { get; private set; }
        public string RoleDisplayName { get; private set; }
        public string RoleDescription { get; private set; }
        public int PrimaryKey { get { return RoleID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(Role other)
        {
            if (other == null)
            {
                return false;
            }
            return other.RoleID == RoleID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as Role);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return RoleID;
        }

        public static bool operator ==(Role left, Role right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Role left, Role right)
        {
            return !Equals(left, right);
        }

        public RoleEnum ToEnum { get { return (RoleEnum)GetHashCode(); } }

        public static Role ToType(int enumValue)
        {
            return ToType((RoleEnum)enumValue);
        }

        public static Role ToType(RoleEnum enumValue)
        {
            switch (enumValue)
            {
                case RoleEnum.Admin:
                    return Admin;
                case RoleEnum.Normal:
                    return Normal;
                case RoleEnum.ProjectSteward:
                    return ProjectSteward;
                case RoleEnum.SitkaAdmin:
                    return SitkaAdmin;
                case RoleEnum.Unassigned:
                    return Unassigned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum RoleEnum
    {
        Admin = 1,
        Normal = 2,
        Unassigned = 7,
        SitkaAdmin = 8,
        ProjectSteward = 9
    }

    public partial class RoleAdmin : Role
    {
        private RoleAdmin(int roleID, string roleName, string roleDisplayName, string roleDescription) : base(roleID, roleName, roleDisplayName, roleDescription) {}
        public static readonly RoleAdmin Instance = new RoleAdmin(1, @"Admin", @"Administrator", @"");
    }

    public partial class RoleNormal : Role
    {
        private RoleNormal(int roleID, string roleName, string roleDisplayName, string roleDescription) : base(roleID, roleName, roleDisplayName, roleDescription) {}
        public static readonly RoleNormal Instance = new RoleNormal(2, @"Normal", @"Normal User", @"Users with this role can propose new EIP projects, update existing EIP projects where their organization is the Lead Implementer, and view almost every page within the EIP Tracker.");
    }

    public partial class RoleUnassigned : Role
    {
        private RoleUnassigned(int roleID, string roleName, string roleDisplayName, string roleDescription) : base(roleID, roleName, roleDisplayName, roleDescription) {}
        public static readonly RoleUnassigned Instance = new RoleUnassigned(7, @"Unassigned", @"Unassigned", @"");
    }

    public partial class RoleSitkaAdmin : Role
    {
        private RoleSitkaAdmin(int roleID, string roleName, string roleDisplayName, string roleDescription) : base(roleID, roleName, roleDisplayName, roleDescription) {}
        public static readonly RoleSitkaAdmin Instance = new RoleSitkaAdmin(8, @"SitkaAdmin", @"Sitka Administrator", @"");
    }

    public partial class RoleProjectSteward : Role
    {
        private RoleProjectSteward(int roleID, string roleName, string roleDisplayName, string roleDescription) : base(roleID, roleName, roleDisplayName, roleDescription) {}
        public static readonly RoleProjectSteward Instance = new RoleProjectSteward(9, @"ProjectSteward", @"Project Steward", @"Users with this role can approve Project Proposals, create new Projects, approve Project Updates, and create Funding Sources for their Organization.");
    }
}