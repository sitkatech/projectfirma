//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TownCenterType]
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
    public abstract partial class TownCenterType : IHavePrimaryKey
    {
        public static readonly TownCenterTypeTownCenterDistrict TownCenterDistrict = TownCenterTypeTownCenterDistrict.Instance;
        public static readonly TownCenterTypeHighDensityTouristDistrict HighDensityTouristDistrict = TownCenterTypeHighDensityTouristDistrict.Instance;
        public static readonly TownCenterTypeRegionalOverlayDistrict RegionalOverlayDistrict = TownCenterTypeRegionalOverlayDistrict.Instance;
        public static readonly TownCenterTypeCasinoCoreDistrict CasinoCoreDistrict = TownCenterTypeCasinoCoreDistrict.Instance;

        public static readonly List<TownCenterType> All;
        public static readonly ReadOnlyDictionary<int, TownCenterType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static TownCenterType()
        {
            All = new List<TownCenterType> { TownCenterDistrict, HighDensityTouristDistrict, RegionalOverlayDistrict, CasinoCoreDistrict };
            AllLookupDictionary = new ReadOnlyDictionary<int, TownCenterType>(All.ToDictionary(x => x.TownCenterTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected TownCenterType(int townCenterTypeID, string townCenterTypeName, string townCenterTypeDisplayName)
        {
            TownCenterTypeID = townCenterTypeID;
            TownCenterTypeName = townCenterTypeName;
            TownCenterTypeDisplayName = townCenterTypeDisplayName;
        }

        [Key]
        public int TownCenterTypeID { get; private set; }
        public string TownCenterTypeName { get; private set; }
        public string TownCenterTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return TownCenterTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(TownCenterType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TownCenterTypeID == TownCenterTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as TownCenterType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TownCenterTypeID;
        }

        public static bool operator ==(TownCenterType left, TownCenterType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TownCenterType left, TownCenterType right)
        {
            return !Equals(left, right);
        }

        public TownCenterTypeEnum ToEnum { get { return (TownCenterTypeEnum)GetHashCode(); } }

        public static TownCenterType ToType(int enumValue)
        {
            return ToType((TownCenterTypeEnum)enumValue);
        }

        public static TownCenterType ToType(TownCenterTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case TownCenterTypeEnum.CasinoCoreDistrict:
                    return CasinoCoreDistrict;
                case TownCenterTypeEnum.HighDensityTouristDistrict:
                    return HighDensityTouristDistrict;
                case TownCenterTypeEnum.RegionalOverlayDistrict:
                    return RegionalOverlayDistrict;
                case TownCenterTypeEnum.TownCenterDistrict:
                    return TownCenterDistrict;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TownCenterTypeEnum
    {
        TownCenterDistrict = 1,
        HighDensityTouristDistrict = 2,
        RegionalOverlayDistrict = 3,
        CasinoCoreDistrict = 4
    }

    public partial class TownCenterTypeTownCenterDistrict : TownCenterType
    {
        private TownCenterTypeTownCenterDistrict(int townCenterTypeID, string townCenterTypeName, string townCenterTypeDisplayName) : base(townCenterTypeID, townCenterTypeName, townCenterTypeDisplayName) {}
        public static readonly TownCenterTypeTownCenterDistrict Instance = new TownCenterTypeTownCenterDistrict(1, @"Town Center District", @"Town Center District");
    }

    public partial class TownCenterTypeHighDensityTouristDistrict : TownCenterType
    {
        private TownCenterTypeHighDensityTouristDistrict(int townCenterTypeID, string townCenterTypeName, string townCenterTypeDisplayName) : base(townCenterTypeID, townCenterTypeName, townCenterTypeDisplayName) {}
        public static readonly TownCenterTypeHighDensityTouristDistrict Instance = new TownCenterTypeHighDensityTouristDistrict(2, @"High Density Tourist District", @"High Density Tourist District");
    }

    public partial class TownCenterTypeRegionalOverlayDistrict : TownCenterType
    {
        private TownCenterTypeRegionalOverlayDistrict(int townCenterTypeID, string townCenterTypeName, string townCenterTypeDisplayName) : base(townCenterTypeID, townCenterTypeName, townCenterTypeDisplayName) {}
        public static readonly TownCenterTypeRegionalOverlayDistrict Instance = new TownCenterTypeRegionalOverlayDistrict(3, @"Regional Overlay District", @"Regional Overlay District");
    }

    public partial class TownCenterTypeCasinoCoreDistrict : TownCenterType
    {
        private TownCenterTypeCasinoCoreDistrict(int townCenterTypeID, string townCenterTypeName, string townCenterTypeDisplayName) : base(townCenterTypeID, townCenterTypeName, townCenterTypeDisplayName) {}
        public static readonly TownCenterTypeCasinoCoreDistrict Instance = new TownCenterTypeCasinoCoreDistrict(4, @"Casino Core District", @"Casino Core District");
    }
}