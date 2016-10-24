//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPRole]
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
    public abstract partial class EIPRole : IHavePrimaryKey
    {
        public static readonly EIPRoleAdmin Admin = EIPRoleAdmin.Instance;
        public static readonly EIPRoleNormal Normal = EIPRoleNormal.Instance;
        public static readonly EIPRoleReadOnlyAdmin ReadOnlyAdmin = EIPRoleReadOnlyAdmin.Instance;
        public static readonly EIPRoleReadOnlyNormal ReadOnlyNormal = EIPRoleReadOnlyNormal.Instance;
        public static readonly EIPRoleApprover Approver = EIPRoleApprover.Instance;
        public static readonly EIPRoleTMPOManager TMPOManager = EIPRoleTMPOManager.Instance;
        public static readonly EIPRoleUnassigned Unassigned = EIPRoleUnassigned.Instance;
        public static readonly EIPRoleSitkaAdmin SitkaAdmin = EIPRoleSitkaAdmin.Instance;

        public static readonly List<EIPRole> All;
        public static readonly ReadOnlyDictionary<int, EIPRole> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static EIPRole()
        {
            All = new List<EIPRole> { Admin, Normal, ReadOnlyAdmin, ReadOnlyNormal, Approver, TMPOManager, Unassigned, SitkaAdmin };
            AllLookupDictionary = new ReadOnlyDictionary<int, EIPRole>(All.ToDictionary(x => x.EIPRoleID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected EIPRole(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription)
        {
            EIPRoleID = eIPRoleID;
            EIPRoleName = eIPRoleName;
            EIPRoleDisplayName = eIPRoleDisplayName;
            EIPRoleDescription = eIPRoleDescription;
        }

        [Key]
        public int EIPRoleID { get; private set; }
        public string EIPRoleName { get; private set; }
        public string EIPRoleDisplayName { get; private set; }
        public string EIPRoleDescription { get; private set; }
        public int PrimaryKey { get { return EIPRoleID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(EIPRole other)
        {
            if (other == null)
            {
                return false;
            }
            return other.EIPRoleID == EIPRoleID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as EIPRole);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return EIPRoleID;
        }

        public static bool operator ==(EIPRole left, EIPRole right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EIPRole left, EIPRole right)
        {
            return !Equals(left, right);
        }

        public EIPRoleEnum ToEnum { get { return (EIPRoleEnum)GetHashCode(); } }

        public static EIPRole ToType(int enumValue)
        {
            return ToType((EIPRoleEnum)enumValue);
        }

        public static EIPRole ToType(EIPRoleEnum enumValue)
        {
            switch (enumValue)
            {
                case EIPRoleEnum.Admin:
                    return Admin;
                case EIPRoleEnum.Approver:
                    return Approver;
                case EIPRoleEnum.Normal:
                    return Normal;
                case EIPRoleEnum.ReadOnlyAdmin:
                    return ReadOnlyAdmin;
                case EIPRoleEnum.ReadOnlyNormal:
                    return ReadOnlyNormal;
                case EIPRoleEnum.SitkaAdmin:
                    return SitkaAdmin;
                case EIPRoleEnum.TMPOManager:
                    return TMPOManager;
                case EIPRoleEnum.Unassigned:
                    return Unassigned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum EIPRoleEnum
    {
        Admin = 1,
        Normal = 2,
        ReadOnlyAdmin = 3,
        ReadOnlyNormal = 4,
        Approver = 5,
        TMPOManager = 6,
        Unassigned = 7,
        SitkaAdmin = 8
    }

    public partial class EIPRoleAdmin : EIPRole
    {
        private EIPRoleAdmin(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleAdmin Instance = new EIPRoleAdmin(1, @"Admin", @"Administrator", @"");
    }

    public partial class EIPRoleNormal : EIPRole
    {
        private EIPRoleNormal(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleNormal Instance = new EIPRoleNormal(2, @"Normal", @"Normal User", @"Users with this role can propose new EIP projects, update existing EIP projects where their organization is the Lead Implementer, and view almost every page within the EIP Tracker.");
    }

    public partial class EIPRoleReadOnlyAdmin : EIPRole
    {
        private EIPRoleReadOnlyAdmin(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleReadOnlyAdmin Instance = new EIPRoleReadOnlyAdmin(3, @"ReadOnlyAdmin", @"Read-only Administrator User", @"");
    }

    public partial class EIPRoleReadOnlyNormal : EIPRole
    {
        private EIPRoleReadOnlyNormal(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleReadOnlyNormal Instance = new EIPRoleReadOnlyNormal(4, @"ReadOnlyNormal", @"Read-only Normal User", @"");
    }

    public partial class EIPRoleApprover : EIPRole
    {
        private EIPRoleApprover(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleApprover Instance = new EIPRoleApprover(5, @"Approver", @"Approver", @"");
    }

    public partial class EIPRoleTMPOManager : EIPRole
    {
        private EIPRoleTMPOManager(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleTMPOManager Instance = new EIPRoleTMPOManager(6, @"TMPOManager", @"TMPO Manager", @"");
    }

    public partial class EIPRoleUnassigned : EIPRole
    {
        private EIPRoleUnassigned(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleUnassigned Instance = new EIPRoleUnassigned(7, @"Unassigned", @"Unassigned", @"");
    }

    public partial class EIPRoleSitkaAdmin : EIPRole
    {
        private EIPRoleSitkaAdmin(int eIPRoleID, string eIPRoleName, string eIPRoleDisplayName, string eIPRoleDescription) : base(eIPRoleID, eIPRoleName, eIPRoleDisplayName, eIPRoleDescription) {}
        public static readonly EIPRoleSitkaAdmin Instance = new EIPRoleSitkaAdmin(8, @"SitkaAdmin", @"Sitka Administrator", @"");
    }
}