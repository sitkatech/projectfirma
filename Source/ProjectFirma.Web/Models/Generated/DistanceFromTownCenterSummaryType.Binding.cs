//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DistanceFromTownCenterSummaryType]
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
    public abstract partial class DistanceFromTownCenterSummaryType : IHavePrimaryKey
    {
        public static readonly DistanceFromTownCenterSummaryTypeInsideTownCenter InsideTownCenter = DistanceFromTownCenterSummaryTypeInsideTownCenter.Instance;
        public static readonly DistanceFromTownCenterSummaryTypeWithinQuarterMileOfTownCenterBoundary WithinQuarterMileOfTownCenterBoundary = DistanceFromTownCenterSummaryTypeWithinQuarterMileOfTownCenterBoundary.Instance;
        public static readonly DistanceFromTownCenterSummaryTypeOutsideTownCenter OutsideTownCenter = DistanceFromTownCenterSummaryTypeOutsideTownCenter.Instance;
        public static readonly DistanceFromTownCenterSummaryTypeUnknown Unknown = DistanceFromTownCenterSummaryTypeUnknown.Instance;

        public static readonly List<DistanceFromTownCenterSummaryType> All;
        public static readonly ReadOnlyDictionary<int, DistanceFromTownCenterSummaryType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static DistanceFromTownCenterSummaryType()
        {
            All = new List<DistanceFromTownCenterSummaryType> { InsideTownCenter, WithinQuarterMileOfTownCenterBoundary, OutsideTownCenter, Unknown };
            AllLookupDictionary = new ReadOnlyDictionary<int, DistanceFromTownCenterSummaryType>(All.ToDictionary(x => x.DistanceFromTownCenterSummaryTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected DistanceFromTownCenterSummaryType(int distanceFromTownCenterSummaryTypeID, string distanceFromTownCenterSummaryTypeName, string distanceFromTownCenterSummaryTypeDisplayName)
        {
            DistanceFromTownCenterSummaryTypeID = distanceFromTownCenterSummaryTypeID;
            DistanceFromTownCenterSummaryTypeName = distanceFromTownCenterSummaryTypeName;
            DistanceFromTownCenterSummaryTypeDisplayName = distanceFromTownCenterSummaryTypeDisplayName;
        }

        [Key]
        public int DistanceFromTownCenterSummaryTypeID { get; private set; }
        public string DistanceFromTownCenterSummaryTypeName { get; private set; }
        public string DistanceFromTownCenterSummaryTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return DistanceFromTownCenterSummaryTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(DistanceFromTownCenterSummaryType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.DistanceFromTownCenterSummaryTypeID == DistanceFromTownCenterSummaryTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as DistanceFromTownCenterSummaryType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return DistanceFromTownCenterSummaryTypeID;
        }

        public static bool operator ==(DistanceFromTownCenterSummaryType left, DistanceFromTownCenterSummaryType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DistanceFromTownCenterSummaryType left, DistanceFromTownCenterSummaryType right)
        {
            return !Equals(left, right);
        }

        public DistanceFromTownCenterSummaryTypeEnum ToEnum { get { return (DistanceFromTownCenterSummaryTypeEnum)GetHashCode(); } }

        public static DistanceFromTownCenterSummaryType ToType(int enumValue)
        {
            return ToType((DistanceFromTownCenterSummaryTypeEnum)enumValue);
        }

        public static DistanceFromTownCenterSummaryType ToType(DistanceFromTownCenterSummaryTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case DistanceFromTownCenterSummaryTypeEnum.InsideTownCenter:
                    return InsideTownCenter;
                case DistanceFromTownCenterSummaryTypeEnum.OutsideTownCenter:
                    return OutsideTownCenter;
                case DistanceFromTownCenterSummaryTypeEnum.Unknown:
                    return Unknown;
                case DistanceFromTownCenterSummaryTypeEnum.WithinQuarterMileOfTownCenterBoundary:
                    return WithinQuarterMileOfTownCenterBoundary;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum DistanceFromTownCenterSummaryTypeEnum
    {
        InsideTownCenter = 1,
        WithinQuarterMileOfTownCenterBoundary = 2,
        OutsideTownCenter = 3,
        Unknown = 4
    }

    public partial class DistanceFromTownCenterSummaryTypeInsideTownCenter : DistanceFromTownCenterSummaryType
    {
        private DistanceFromTownCenterSummaryTypeInsideTownCenter(int distanceFromTownCenterSummaryTypeID, string distanceFromTownCenterSummaryTypeName, string distanceFromTownCenterSummaryTypeDisplayName) : base(distanceFromTownCenterSummaryTypeID, distanceFromTownCenterSummaryTypeName, distanceFromTownCenterSummaryTypeDisplayName) {}
        public static readonly DistanceFromTownCenterSummaryTypeInsideTownCenter Instance = new DistanceFromTownCenterSummaryTypeInsideTownCenter(1, @"InsideTownCenter", @"Inside Town Center");
    }

    public partial class DistanceFromTownCenterSummaryTypeWithinQuarterMileOfTownCenterBoundary : DistanceFromTownCenterSummaryType
    {
        private DistanceFromTownCenterSummaryTypeWithinQuarterMileOfTownCenterBoundary(int distanceFromTownCenterSummaryTypeID, string distanceFromTownCenterSummaryTypeName, string distanceFromTownCenterSummaryTypeDisplayName) : base(distanceFromTownCenterSummaryTypeID, distanceFromTownCenterSummaryTypeName, distanceFromTownCenterSummaryTypeDisplayName) {}
        public static readonly DistanceFromTownCenterSummaryTypeWithinQuarterMileOfTownCenterBoundary Instance = new DistanceFromTownCenterSummaryTypeWithinQuarterMileOfTownCenterBoundary(2, @"WithinQuarterMileOfTownCenterBoundary", @"Within quarter mile of Town Center Boundary");
    }

    public partial class DistanceFromTownCenterSummaryTypeOutsideTownCenter : DistanceFromTownCenterSummaryType
    {
        private DistanceFromTownCenterSummaryTypeOutsideTownCenter(int distanceFromTownCenterSummaryTypeID, string distanceFromTownCenterSummaryTypeName, string distanceFromTownCenterSummaryTypeDisplayName) : base(distanceFromTownCenterSummaryTypeID, distanceFromTownCenterSummaryTypeName, distanceFromTownCenterSummaryTypeDisplayName) {}
        public static readonly DistanceFromTownCenterSummaryTypeOutsideTownCenter Instance = new DistanceFromTownCenterSummaryTypeOutsideTownCenter(3, @"OutsideTownCenter", @"Outside Town Center");
    }

    public partial class DistanceFromTownCenterSummaryTypeUnknown : DistanceFromTownCenterSummaryType
    {
        private DistanceFromTownCenterSummaryTypeUnknown(int distanceFromTownCenterSummaryTypeID, string distanceFromTownCenterSummaryTypeName, string distanceFromTownCenterSummaryTypeDisplayName) : base(distanceFromTownCenterSummaryTypeID, distanceFromTownCenterSummaryTypeName, distanceFromTownCenterSummaryTypeDisplayName) {}
        public static readonly DistanceFromTownCenterSummaryTypeUnknown Instance = new DistanceFromTownCenterSummaryTypeUnknown(4, @"Unknown", @"Unknown");
    }
}