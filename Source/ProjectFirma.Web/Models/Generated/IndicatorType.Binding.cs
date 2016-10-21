//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorType]
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
    public abstract partial class IndicatorType : IHavePrimaryKey
    {
        public static readonly IndicatorTypeAction Action = IndicatorTypeAction.Instance;
        public static readonly IndicatorTypeOutcome Outcome = IndicatorTypeOutcome.Instance;
        public static readonly IndicatorTypeIntermediateResult IntermediateResult = IndicatorTypeIntermediateResult.Instance;

        public static readonly List<IndicatorType> All;
        public static readonly ReadOnlyDictionary<int, IndicatorType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static IndicatorType()
        {
            All = new List<IndicatorType> { Action, Outcome, IntermediateResult };
            AllLookupDictionary = new ReadOnlyDictionary<int, IndicatorType>(All.ToDictionary(x => x.IndicatorTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected IndicatorType(int indicatorTypeID, string indicatorTypeName, string indicatorTypeDisplayName)
        {
            IndicatorTypeID = indicatorTypeID;
            IndicatorTypeName = indicatorTypeName;
            IndicatorTypeDisplayName = indicatorTypeDisplayName;
        }

        [Key]
        public int IndicatorTypeID { get; private set; }
        public string IndicatorTypeName { get; private set; }
        public string IndicatorTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return IndicatorTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(IndicatorType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.IndicatorTypeID == IndicatorTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as IndicatorType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return IndicatorTypeID;
        }

        public static bool operator ==(IndicatorType left, IndicatorType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IndicatorType left, IndicatorType right)
        {
            return !Equals(left, right);
        }

        public IndicatorTypeEnum ToEnum { get { return (IndicatorTypeEnum)GetHashCode(); } }

        public static IndicatorType ToType(int enumValue)
        {
            return ToType((IndicatorTypeEnum)enumValue);
        }

        public static IndicatorType ToType(IndicatorTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case IndicatorTypeEnum.Action:
                    return Action;
                case IndicatorTypeEnum.IntermediateResult:
                    return IntermediateResult;
                case IndicatorTypeEnum.Outcome:
                    return Outcome;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum IndicatorTypeEnum
    {
        Action = 1,
        Outcome = 2,
        IntermediateResult = 3
    }

    public partial class IndicatorTypeAction : IndicatorType
    {
        private IndicatorTypeAction(int indicatorTypeID, string indicatorTypeName, string indicatorTypeDisplayName) : base(indicatorTypeID, indicatorTypeName, indicatorTypeDisplayName) {}
        public static readonly IndicatorTypeAction Instance = new IndicatorTypeAction(1, @"Action", @"Action");
    }

    public partial class IndicatorTypeOutcome : IndicatorType
    {
        private IndicatorTypeOutcome(int indicatorTypeID, string indicatorTypeName, string indicatorTypeDisplayName) : base(indicatorTypeID, indicatorTypeName, indicatorTypeDisplayName) {}
        public static readonly IndicatorTypeOutcome Instance = new IndicatorTypeOutcome(2, @"Outcome", @"Outcome");
    }

    public partial class IndicatorTypeIntermediateResult : IndicatorType
    {
        private IndicatorTypeIntermediateResult(int indicatorTypeID, string indicatorTypeName, string indicatorTypeDisplayName) : base(indicatorTypeID, indicatorTypeName, indicatorTypeDisplayName) {}
        public static readonly IndicatorTypeIntermediateResult Instance = new IndicatorTypeIntermediateResult(3, @"IntermediateResult", @"Intermediate Result");
    }
}