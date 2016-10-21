//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelLandCapabilityDeterminationType]
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
    public abstract partial class ParcelLandCapabilityDeterminationType : IHavePrimaryKey
    {
        public static readonly ParcelLandCapabilityDeterminationTypeEstimated Estimated = ParcelLandCapabilityDeterminationTypeEstimated.Instance;
        public static readonly ParcelLandCapabilityDeterminationTypeVerified Verified = ParcelLandCapabilityDeterminationTypeVerified.Instance;

        public static readonly List<ParcelLandCapabilityDeterminationType> All;
        public static readonly ReadOnlyDictionary<int, ParcelLandCapabilityDeterminationType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ParcelLandCapabilityDeterminationType()
        {
            All = new List<ParcelLandCapabilityDeterminationType> { Estimated, Verified };
            AllLookupDictionary = new ReadOnlyDictionary<int, ParcelLandCapabilityDeterminationType>(All.ToDictionary(x => x.ParcelLandCapabilityDeterminationTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ParcelLandCapabilityDeterminationType(int parcelLandCapabilityDeterminationTypeID, string parcelLandCapabilityDeterminationTypeName, string parcelLandCapabilityDeterminationTypeDisplayName)
        {
            ParcelLandCapabilityDeterminationTypeID = parcelLandCapabilityDeterminationTypeID;
            ParcelLandCapabilityDeterminationTypeName = parcelLandCapabilityDeterminationTypeName;
            ParcelLandCapabilityDeterminationTypeDisplayName = parcelLandCapabilityDeterminationTypeDisplayName;
        }

        [Key]
        public int ParcelLandCapabilityDeterminationTypeID { get; private set; }
        public string ParcelLandCapabilityDeterminationTypeName { get; private set; }
        public string ParcelLandCapabilityDeterminationTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return ParcelLandCapabilityDeterminationTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ParcelLandCapabilityDeterminationType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ParcelLandCapabilityDeterminationTypeID == ParcelLandCapabilityDeterminationTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ParcelLandCapabilityDeterminationType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ParcelLandCapabilityDeterminationTypeID;
        }

        public static bool operator ==(ParcelLandCapabilityDeterminationType left, ParcelLandCapabilityDeterminationType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ParcelLandCapabilityDeterminationType left, ParcelLandCapabilityDeterminationType right)
        {
            return !Equals(left, right);
        }

        public ParcelLandCapabilityDeterminationTypeEnum ToEnum { get { return (ParcelLandCapabilityDeterminationTypeEnum)GetHashCode(); } }

        public static ParcelLandCapabilityDeterminationType ToType(int enumValue)
        {
            return ToType((ParcelLandCapabilityDeterminationTypeEnum)enumValue);
        }

        public static ParcelLandCapabilityDeterminationType ToType(ParcelLandCapabilityDeterminationTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ParcelLandCapabilityDeterminationTypeEnum.Estimated:
                    return Estimated;
                case ParcelLandCapabilityDeterminationTypeEnum.Verified:
                    return Verified;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ParcelLandCapabilityDeterminationTypeEnum
    {
        Estimated = 1,
        Verified = 2
    }

    public partial class ParcelLandCapabilityDeterminationTypeEstimated : ParcelLandCapabilityDeterminationType
    {
        private ParcelLandCapabilityDeterminationTypeEstimated(int parcelLandCapabilityDeterminationTypeID, string parcelLandCapabilityDeterminationTypeName, string parcelLandCapabilityDeterminationTypeDisplayName) : base(parcelLandCapabilityDeterminationTypeID, parcelLandCapabilityDeterminationTypeName, parcelLandCapabilityDeterminationTypeDisplayName) {}
        public static readonly ParcelLandCapabilityDeterminationTypeEstimated Instance = new ParcelLandCapabilityDeterminationTypeEstimated(1, @"Estimated", @"Estimated");
    }

    public partial class ParcelLandCapabilityDeterminationTypeVerified : ParcelLandCapabilityDeterminationType
    {
        private ParcelLandCapabilityDeterminationTypeVerified(int parcelLandCapabilityDeterminationTypeID, string parcelLandCapabilityDeterminationTypeName, string parcelLandCapabilityDeterminationTypeDisplayName) : base(parcelLandCapabilityDeterminationTypeID, parcelLandCapabilityDeterminationTypeName, parcelLandCapabilityDeterminationTypeDisplayName) {}
        public static readonly ParcelLandCapabilityDeterminationTypeVerified Instance = new ParcelLandCapabilityDeterminationTypeVerified(2, @"Verified", @"Verified");
    }
}