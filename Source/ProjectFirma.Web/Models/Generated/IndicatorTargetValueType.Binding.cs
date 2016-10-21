//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorTargetValueType]
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
    public abstract partial class IndicatorTargetValueType : IHavePrimaryKey
    {
        public static readonly IndicatorTargetValueTypeNoTarget NoTarget = IndicatorTargetValueTypeNoTarget.Instance;
        public static readonly IndicatorTargetValueTypeOverallTarget OverallTarget = IndicatorTargetValueTypeOverallTarget.Instance;
        public static readonly IndicatorTargetValueTypeTargetPerReportingPeriod TargetPerReportingPeriod = IndicatorTargetValueTypeTargetPerReportingPeriod.Instance;

        public static readonly List<IndicatorTargetValueType> All;
        public static readonly ReadOnlyDictionary<int, IndicatorTargetValueType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static IndicatorTargetValueType()
        {
            All = new List<IndicatorTargetValueType> { NoTarget, OverallTarget, TargetPerReportingPeriod };
            AllLookupDictionary = new ReadOnlyDictionary<int, IndicatorTargetValueType>(All.ToDictionary(x => x.IndicatorTargetValueTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected IndicatorTargetValueType(int indicatorTargetValueTypeID, string indicatorTargetValueTypeName, string indicatorTargetValueTypeDisplayName)
        {
            IndicatorTargetValueTypeID = indicatorTargetValueTypeID;
            IndicatorTargetValueTypeName = indicatorTargetValueTypeName;
            IndicatorTargetValueTypeDisplayName = indicatorTargetValueTypeDisplayName;
        }

        [Key]
        public int IndicatorTargetValueTypeID { get; private set; }
        public string IndicatorTargetValueTypeName { get; private set; }
        public string IndicatorTargetValueTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return IndicatorTargetValueTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(IndicatorTargetValueType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.IndicatorTargetValueTypeID == IndicatorTargetValueTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as IndicatorTargetValueType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return IndicatorTargetValueTypeID;
        }

        public static bool operator ==(IndicatorTargetValueType left, IndicatorTargetValueType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IndicatorTargetValueType left, IndicatorTargetValueType right)
        {
            return !Equals(left, right);
        }

        public IndicatorTargetValueTypeEnum ToEnum { get { return (IndicatorTargetValueTypeEnum)GetHashCode(); } }

        public static IndicatorTargetValueType ToType(int enumValue)
        {
            return ToType((IndicatorTargetValueTypeEnum)enumValue);
        }

        public static IndicatorTargetValueType ToType(IndicatorTargetValueTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case IndicatorTargetValueTypeEnum.NoTarget:
                    return NoTarget;
                case IndicatorTargetValueTypeEnum.OverallTarget:
                    return OverallTarget;
                case IndicatorTargetValueTypeEnum.TargetPerReportingPeriod:
                    return TargetPerReportingPeriod;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum IndicatorTargetValueTypeEnum
    {
        NoTarget = 1,
        OverallTarget = 2,
        TargetPerReportingPeriod = 3
    }

    public partial class IndicatorTargetValueTypeNoTarget : IndicatorTargetValueType
    {
        private IndicatorTargetValueTypeNoTarget(int indicatorTargetValueTypeID, string indicatorTargetValueTypeName, string indicatorTargetValueTypeDisplayName) : base(indicatorTargetValueTypeID, indicatorTargetValueTypeName, indicatorTargetValueTypeDisplayName) {}
        public static readonly IndicatorTargetValueTypeNoTarget Instance = new IndicatorTargetValueTypeNoTarget(1, @"NoTarget", @"No Target");
    }

    public partial class IndicatorTargetValueTypeOverallTarget : IndicatorTargetValueType
    {
        private IndicatorTargetValueTypeOverallTarget(int indicatorTargetValueTypeID, string indicatorTargetValueTypeName, string indicatorTargetValueTypeDisplayName) : base(indicatorTargetValueTypeID, indicatorTargetValueTypeName, indicatorTargetValueTypeDisplayName) {}
        public static readonly IndicatorTargetValueTypeOverallTarget Instance = new IndicatorTargetValueTypeOverallTarget(2, @"OverallTarget", @"Overall Target");
    }

    public partial class IndicatorTargetValueTypeTargetPerReportingPeriod : IndicatorTargetValueType
    {
        private IndicatorTargetValueTypeTargetPerReportingPeriod(int indicatorTargetValueTypeID, string indicatorTargetValueTypeName, string indicatorTargetValueTypeDisplayName) : base(indicatorTargetValueTypeID, indicatorTargetValueTypeName, indicatorTargetValueTypeDisplayName) {}
        public static readonly IndicatorTargetValueTypeTargetPerReportingPeriod Instance = new IndicatorTargetValueTypeTargetPerReportingPeriod(3, @"TargetPerReportingPeriod", @"Target per Reporting Period");
    }
}