//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluationConfidenceType]
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
    public abstract partial class ThresholdEvaluationConfidenceType : IHavePrimaryKey
    {
        public static readonly ThresholdEvaluationConfidenceTypeHigh High = ThresholdEvaluationConfidenceTypeHigh.Instance;
        public static readonly ThresholdEvaluationConfidenceTypeModerate Moderate = ThresholdEvaluationConfidenceTypeModerate.Instance;
        public static readonly ThresholdEvaluationConfidenceTypeLow Low = ThresholdEvaluationConfidenceTypeLow.Instance;

        public static readonly List<ThresholdEvaluationConfidenceType> All;
        public static readonly ReadOnlyDictionary<int, ThresholdEvaluationConfidenceType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ThresholdEvaluationConfidenceType()
        {
            All = new List<ThresholdEvaluationConfidenceType> { High, Moderate, Low };
            AllLookupDictionary = new ReadOnlyDictionary<int, ThresholdEvaluationConfidenceType>(All.ToDictionary(x => x.ThresholdEvaluationConfidenceTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ThresholdEvaluationConfidenceType(int thresholdEvaluationConfidenceTypeID, string thresholdEvaluationConfidenceTypeName, string thresholdEvaluationConfidenceTypeDisplayName)
        {
            ThresholdEvaluationConfidenceTypeID = thresholdEvaluationConfidenceTypeID;
            ThresholdEvaluationConfidenceTypeName = thresholdEvaluationConfidenceTypeName;
            ThresholdEvaluationConfidenceTypeDisplayName = thresholdEvaluationConfidenceTypeDisplayName;
        }

        [Key]
        public int ThresholdEvaluationConfidenceTypeID { get; private set; }
        public string ThresholdEvaluationConfidenceTypeName { get; private set; }
        public string ThresholdEvaluationConfidenceTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return ThresholdEvaluationConfidenceTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ThresholdEvaluationConfidenceType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ThresholdEvaluationConfidenceTypeID == ThresholdEvaluationConfidenceTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ThresholdEvaluationConfidenceType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ThresholdEvaluationConfidenceTypeID;
        }

        public static bool operator ==(ThresholdEvaluationConfidenceType left, ThresholdEvaluationConfidenceType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThresholdEvaluationConfidenceType left, ThresholdEvaluationConfidenceType right)
        {
            return !Equals(left, right);
        }

        public ThresholdEvaluationConfidenceTypeEnum ToEnum { get { return (ThresholdEvaluationConfidenceTypeEnum)GetHashCode(); } }

        public static ThresholdEvaluationConfidenceType ToType(int enumValue)
        {
            return ToType((ThresholdEvaluationConfidenceTypeEnum)enumValue);
        }

        public static ThresholdEvaluationConfidenceType ToType(ThresholdEvaluationConfidenceTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ThresholdEvaluationConfidenceTypeEnum.High:
                    return High;
                case ThresholdEvaluationConfidenceTypeEnum.Low:
                    return Low;
                case ThresholdEvaluationConfidenceTypeEnum.Moderate:
                    return Moderate;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ThresholdEvaluationConfidenceTypeEnum
    {
        High = 1,
        Moderate = 2,
        Low = 3
    }

    public partial class ThresholdEvaluationConfidenceTypeHigh : ThresholdEvaluationConfidenceType
    {
        private ThresholdEvaluationConfidenceTypeHigh(int thresholdEvaluationConfidenceTypeID, string thresholdEvaluationConfidenceTypeName, string thresholdEvaluationConfidenceTypeDisplayName) : base(thresholdEvaluationConfidenceTypeID, thresholdEvaluationConfidenceTypeName, thresholdEvaluationConfidenceTypeDisplayName) {}
        public static readonly ThresholdEvaluationConfidenceTypeHigh Instance = new ThresholdEvaluationConfidenceTypeHigh(1, @"High", @"High");
    }

    public partial class ThresholdEvaluationConfidenceTypeModerate : ThresholdEvaluationConfidenceType
    {
        private ThresholdEvaluationConfidenceTypeModerate(int thresholdEvaluationConfidenceTypeID, string thresholdEvaluationConfidenceTypeName, string thresholdEvaluationConfidenceTypeDisplayName) : base(thresholdEvaluationConfidenceTypeID, thresholdEvaluationConfidenceTypeName, thresholdEvaluationConfidenceTypeDisplayName) {}
        public static readonly ThresholdEvaluationConfidenceTypeModerate Instance = new ThresholdEvaluationConfidenceTypeModerate(2, @"Moderate", @"Moderate");
    }

    public partial class ThresholdEvaluationConfidenceTypeLow : ThresholdEvaluationConfidenceType
    {
        private ThresholdEvaluationConfidenceTypeLow(int thresholdEvaluationConfidenceTypeID, string thresholdEvaluationConfidenceTypeName, string thresholdEvaluationConfidenceTypeDisplayName) : base(thresholdEvaluationConfidenceTypeID, thresholdEvaluationConfidenceTypeName, thresholdEvaluationConfidenceTypeDisplayName) {}
        public static readonly ThresholdEvaluationConfidenceTypeLow Instance = new ThresholdEvaluationConfidenceTypeLow(3, @"Low", @"Low");
    }
}