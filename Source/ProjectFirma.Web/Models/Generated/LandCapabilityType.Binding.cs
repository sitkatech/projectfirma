//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LandCapabilityType]
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
    public abstract partial class LandCapabilityType : IHavePrimaryKey
    {
        public static readonly LandCapabilityTypeBaileyRating BaileyRating = LandCapabilityTypeBaileyRating.Instance;
        public static readonly LandCapabilityTypeIPESScore IPESScore = LandCapabilityTypeIPESScore.Instance;

        public static readonly List<LandCapabilityType> All;
        public static readonly ReadOnlyDictionary<int, LandCapabilityType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static LandCapabilityType()
        {
            All = new List<LandCapabilityType> { BaileyRating, IPESScore };
            AllLookupDictionary = new ReadOnlyDictionary<int, LandCapabilityType>(All.ToDictionary(x => x.LandCapabilityTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected LandCapabilityType(int landCapabilityTypeID, string landCapabilityTypeName, string landCapabilityTypeDisplayName)
        {
            LandCapabilityTypeID = landCapabilityTypeID;
            LandCapabilityTypeName = landCapabilityTypeName;
            LandCapabilityTypeDisplayName = landCapabilityTypeDisplayName;
        }

        [Key]
        public int LandCapabilityTypeID { get; private set; }
        public string LandCapabilityTypeName { get; private set; }
        public string LandCapabilityTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return LandCapabilityTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(LandCapabilityType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.LandCapabilityTypeID == LandCapabilityTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as LandCapabilityType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return LandCapabilityTypeID;
        }

        public static bool operator ==(LandCapabilityType left, LandCapabilityType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LandCapabilityType left, LandCapabilityType right)
        {
            return !Equals(left, right);
        }

        public LandCapabilityTypeEnum ToEnum { get { return (LandCapabilityTypeEnum)GetHashCode(); } }

        public static LandCapabilityType ToType(int enumValue)
        {
            return ToType((LandCapabilityTypeEnum)enumValue);
        }

        public static LandCapabilityType ToType(LandCapabilityTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case LandCapabilityTypeEnum.BaileyRating:
                    return BaileyRating;
                case LandCapabilityTypeEnum.IPESScore:
                    return IPESScore;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum LandCapabilityTypeEnum
    {
        BaileyRating = 1,
        IPESScore = 2
    }

    public partial class LandCapabilityTypeBaileyRating : LandCapabilityType
    {
        private LandCapabilityTypeBaileyRating(int landCapabilityTypeID, string landCapabilityTypeName, string landCapabilityTypeDisplayName) : base(landCapabilityTypeID, landCapabilityTypeName, landCapabilityTypeDisplayName) {}
        public static readonly LandCapabilityTypeBaileyRating Instance = new LandCapabilityTypeBaileyRating(1, @"Bailey Rating", @"Bailey Rating");
    }

    public partial class LandCapabilityTypeIPESScore : LandCapabilityType
    {
        private LandCapabilityTypeIPESScore(int landCapabilityTypeID, string landCapabilityTypeName, string landCapabilityTypeDisplayName) : base(landCapabilityTypeID, landCapabilityTypeName, landCapabilityTypeDisplayName) {}
        public static readonly LandCapabilityTypeIPESScore Instance = new LandCapabilityTypeIPESScore(2, @"IPES Score", @"IPES Score");
    }
}