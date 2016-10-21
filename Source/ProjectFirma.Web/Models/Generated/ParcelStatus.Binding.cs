//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelStatus]
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
    public abstract partial class ParcelStatus : IHavePrimaryKey
    {
        public static readonly ParcelStatusActive Active = ParcelStatusActive.Instance;
        public static readonly ParcelStatusInactive Inactive = ParcelStatusInactive.Instance;
        public static readonly ParcelStatusPending Pending = ParcelStatusPending.Instance;
        public static readonly ParcelStatusNotInAccela NotInAccela = ParcelStatusNotInAccela.Instance;

        public static readonly List<ParcelStatus> All;
        public static readonly ReadOnlyDictionary<int, ParcelStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ParcelStatus()
        {
            All = new List<ParcelStatus> { Active, Inactive, Pending, NotInAccela };
            AllLookupDictionary = new ReadOnlyDictionary<int, ParcelStatus>(All.ToDictionary(x => x.ParcelStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ParcelStatus(int parcelStatusID, string parcelStatusName, string parcelStatusDisplayName)
        {
            ParcelStatusID = parcelStatusID;
            ParcelStatusName = parcelStatusName;
            ParcelStatusDisplayName = parcelStatusDisplayName;
        }

        [Key]
        public int ParcelStatusID { get; private set; }
        public string ParcelStatusName { get; private set; }
        public string ParcelStatusDisplayName { get; private set; }
        public int PrimaryKey { get { return ParcelStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ParcelStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ParcelStatusID == ParcelStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ParcelStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ParcelStatusID;
        }

        public static bool operator ==(ParcelStatus left, ParcelStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ParcelStatus left, ParcelStatus right)
        {
            return !Equals(left, right);
        }

        public ParcelStatusEnum ToEnum { get { return (ParcelStatusEnum)GetHashCode(); } }

        public static ParcelStatus ToType(int enumValue)
        {
            return ToType((ParcelStatusEnum)enumValue);
        }

        public static ParcelStatus ToType(ParcelStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case ParcelStatusEnum.Active:
                    return Active;
                case ParcelStatusEnum.Inactive:
                    return Inactive;
                case ParcelStatusEnum.NotInAccela:
                    return NotInAccela;
                case ParcelStatusEnum.Pending:
                    return Pending;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ParcelStatusEnum
    {
        Active = 1,
        Inactive = 2,
        Pending = 3,
        NotInAccela = 4
    }

    public partial class ParcelStatusActive : ParcelStatus
    {
        private ParcelStatusActive(int parcelStatusID, string parcelStatusName, string parcelStatusDisplayName) : base(parcelStatusID, parcelStatusName, parcelStatusDisplayName) {}
        public static readonly ParcelStatusActive Instance = new ParcelStatusActive(1, @"Active", @"Active");
    }

    public partial class ParcelStatusInactive : ParcelStatus
    {
        private ParcelStatusInactive(int parcelStatusID, string parcelStatusName, string parcelStatusDisplayName) : base(parcelStatusID, parcelStatusName, parcelStatusDisplayName) {}
        public static readonly ParcelStatusInactive Instance = new ParcelStatusInactive(2, @"Inactive", @"Inactive");
    }

    public partial class ParcelStatusPending : ParcelStatus
    {
        private ParcelStatusPending(int parcelStatusID, string parcelStatusName, string parcelStatusDisplayName) : base(parcelStatusID, parcelStatusName, parcelStatusDisplayName) {}
        public static readonly ParcelStatusPending Instance = new ParcelStatusPending(3, @"Pending", @"Pending");
    }

    public partial class ParcelStatusNotInAccela : ParcelStatus
    {
        private ParcelStatusNotInAccela(int parcelStatusID, string parcelStatusName, string parcelStatusDisplayName) : base(parcelStatusID, parcelStatusName, parcelStatusDisplayName) {}
        public static readonly ParcelStatusNotInAccela Instance = new ParcelStatusNotInAccela(4, @"NotInAccela", @"Not in Accela");
    }
}