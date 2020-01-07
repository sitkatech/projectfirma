//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureTargetValueType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class PerformanceMeasureTargetValueType : IHavePrimaryKey
    {
        public static readonly PerformanceMeasureTargetValueTypeNoTarget NoTarget = PerformanceMeasureTargetValueTypeNoTarget.Instance;
        public static readonly PerformanceMeasureTargetValueTypeFixedTarget FixedTarget = PerformanceMeasureTargetValueTypeFixedTarget.Instance;
        public static readonly PerformanceMeasureTargetValueTypeTargetPerYear TargetPerYear = PerformanceMeasureTargetValueTypeTargetPerYear.Instance;

        public static readonly List<PerformanceMeasureTargetValueType> All;
        public static readonly ReadOnlyDictionary<int, PerformanceMeasureTargetValueType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static PerformanceMeasureTargetValueType()
        {
            All = new List<PerformanceMeasureTargetValueType> { NoTarget, FixedTarget, TargetPerYear };
            AllLookupDictionary = new ReadOnlyDictionary<int, PerformanceMeasureTargetValueType>(All.ToDictionary(x => x.PerformanceMeasureTargetValueTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected PerformanceMeasureTargetValueType(int performanceMeasureTargetValueTypeID, string performanceMeasureTargetValueTypeName, string performanceMeasureTargetValueTypeDisplayName)
        {
            PerformanceMeasureTargetValueTypeID = performanceMeasureTargetValueTypeID;
            PerformanceMeasureTargetValueTypeName = performanceMeasureTargetValueTypeName;
            PerformanceMeasureTargetValueTypeDisplayName = performanceMeasureTargetValueTypeDisplayName;
        }

        [Key]
        public int PerformanceMeasureTargetValueTypeID { get; private set; }
        public string PerformanceMeasureTargetValueTypeName { get; private set; }
        public string PerformanceMeasureTargetValueTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureTargetValueTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(PerformanceMeasureTargetValueType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.PerformanceMeasureTargetValueTypeID == PerformanceMeasureTargetValueTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as PerformanceMeasureTargetValueType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return PerformanceMeasureTargetValueTypeID;
        }

        public static bool operator ==(PerformanceMeasureTargetValueType left, PerformanceMeasureTargetValueType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PerformanceMeasureTargetValueType left, PerformanceMeasureTargetValueType right)
        {
            return !Equals(left, right);
        }

        public PerformanceMeasureTargetValueTypeEnum ToEnum { get { return (PerformanceMeasureTargetValueTypeEnum)GetHashCode(); } }

        public static PerformanceMeasureTargetValueType ToType(int enumValue)
        {
            return ToType((PerformanceMeasureTargetValueTypeEnum)enumValue);
        }

        public static PerformanceMeasureTargetValueType ToType(PerformanceMeasureTargetValueTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case PerformanceMeasureTargetValueTypeEnum.FixedTarget:
                    return FixedTarget;
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    return NoTarget;
                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    return TargetPerYear;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum PerformanceMeasureTargetValueTypeEnum
    {
        NoTarget = 1,
        FixedTarget = 2,
        TargetPerYear = 3
    }

    public partial class PerformanceMeasureTargetValueTypeNoTarget : PerformanceMeasureTargetValueType
    {
        private PerformanceMeasureTargetValueTypeNoTarget(int performanceMeasureTargetValueTypeID, string performanceMeasureTargetValueTypeName, string performanceMeasureTargetValueTypeDisplayName) : base(performanceMeasureTargetValueTypeID, performanceMeasureTargetValueTypeName, performanceMeasureTargetValueTypeDisplayName) {}
        public static readonly PerformanceMeasureTargetValueTypeNoTarget Instance = new PerformanceMeasureTargetValueTypeNoTarget(1, @"NoTarget", @"No Target");
    }

    public partial class PerformanceMeasureTargetValueTypeFixedTarget : PerformanceMeasureTargetValueType
    {
        private PerformanceMeasureTargetValueTypeFixedTarget(int performanceMeasureTargetValueTypeID, string performanceMeasureTargetValueTypeName, string performanceMeasureTargetValueTypeDisplayName) : base(performanceMeasureTargetValueTypeID, performanceMeasureTargetValueTypeName, performanceMeasureTargetValueTypeDisplayName) {}
        public static readonly PerformanceMeasureTargetValueTypeFixedTarget Instance = new PerformanceMeasureTargetValueTypeFixedTarget(2, @"FixedTarget", @"Fixed Target");
    }

    public partial class PerformanceMeasureTargetValueTypeTargetPerYear : PerformanceMeasureTargetValueType
    {
        private PerformanceMeasureTargetValueTypeTargetPerYear(int performanceMeasureTargetValueTypeID, string performanceMeasureTargetValueTypeName, string performanceMeasureTargetValueTypeDisplayName) : base(performanceMeasureTargetValueTypeID, performanceMeasureTargetValueTypeName, performanceMeasureTargetValueTypeDisplayName) {}
        public static readonly PerformanceMeasureTargetValueTypeTargetPerYear Instance = new PerformanceMeasureTargetValueTypeTargetPerYear(3, @"TargetPerYear", @"Target per Year");
    }
}