//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Ownership]
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
    public abstract partial class Ownership : IHavePrimaryKey
    {
        public static readonly OwnershipPrivate Private = OwnershipPrivate.Instance;
        public static readonly OwnershipPublic Public = OwnershipPublic.Instance;

        public static readonly List<Ownership> All;
        public static readonly ReadOnlyDictionary<int, Ownership> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static Ownership()
        {
            All = new List<Ownership> { Private, Public };
            AllLookupDictionary = new ReadOnlyDictionary<int, Ownership>(All.ToDictionary(x => x.OwnershipID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected Ownership(int ownershipID, string ownershipName, string ownershipDisplayName)
        {
            OwnershipID = ownershipID;
            OwnershipName = ownershipName;
            OwnershipDisplayName = ownershipDisplayName;
        }

        [Key]
        public int OwnershipID { get; private set; }
        public string OwnershipName { get; private set; }
        public string OwnershipDisplayName { get; private set; }
        public int PrimaryKey { get { return OwnershipID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(Ownership other)
        {
            if (other == null)
            {
                return false;
            }
            return other.OwnershipID == OwnershipID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as Ownership);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return OwnershipID;
        }

        public static bool operator ==(Ownership left, Ownership right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Ownership left, Ownership right)
        {
            return !Equals(left, right);
        }

        public OwnershipEnum ToEnum { get { return (OwnershipEnum)GetHashCode(); } }

        public static Ownership ToType(int enumValue)
        {
            return ToType((OwnershipEnum)enumValue);
        }

        public static Ownership ToType(OwnershipEnum enumValue)
        {
            switch (enumValue)
            {
                case OwnershipEnum.Private:
                    return Private;
                case OwnershipEnum.Public:
                    return Public;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum OwnershipEnum
    {
        Private = 1,
        Public = 2
    }

    public partial class OwnershipPrivate : Ownership
    {
        private OwnershipPrivate(int ownershipID, string ownershipName, string ownershipDisplayName) : base(ownershipID, ownershipName, ownershipDisplayName) {}
        public static readonly OwnershipPrivate Instance = new OwnershipPrivate(1, @"Private", @"Private");
    }

    public partial class OwnershipPublic : Ownership
    {
        private OwnershipPublic(int ownershipID, string ownershipName, string ownershipDisplayName) : base(ownershipID, ownershipName, ownershipDisplayName) {}
        public static readonly OwnershipPublic Instance = new OwnershipPublic(2, @"Public", @"Public");
    }
}