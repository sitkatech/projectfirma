//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluationStatusType]
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
    public abstract partial class ThresholdEvaluationStatusType : IHavePrimaryKey
    {
        public static readonly ThresholdEvaluationStatusTypeConsiderablyBetter ConsiderablyBetter = ThresholdEvaluationStatusTypeConsiderablyBetter.Instance;
        public static readonly ThresholdEvaluationStatusTypeAtOrSomewhatBetter AtOrSomewhatBetter = ThresholdEvaluationStatusTypeAtOrSomewhatBetter.Instance;
        public static readonly ThresholdEvaluationStatusTypeSomewhatWorse SomewhatWorse = ThresholdEvaluationStatusTypeSomewhatWorse.Instance;
        public static readonly ThresholdEvaluationStatusTypeConsiderablyWorse ConsiderablyWorse = ThresholdEvaluationStatusTypeConsiderablyWorse.Instance;
        public static readonly ThresholdEvaluationStatusTypeInsufficientData InsufficientData = ThresholdEvaluationStatusTypeInsufficientData.Instance;

        public static readonly List<ThresholdEvaluationStatusType> All;
        public static readonly ReadOnlyDictionary<int, ThresholdEvaluationStatusType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ThresholdEvaluationStatusType()
        {
            All = new List<ThresholdEvaluationStatusType> { ConsiderablyBetter, AtOrSomewhatBetter, SomewhatWorse, ConsiderablyWorse, InsufficientData };
            AllLookupDictionary = new ReadOnlyDictionary<int, ThresholdEvaluationStatusType>(All.ToDictionary(x => x.ThresholdEvaluationStatusTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ThresholdEvaluationStatusType(int thresholdEvaluationStatusTypeID, string thresholdEvaluationStatusTypeName, string thresholdEvaluationStatusTypeDisplayName)
        {
            ThresholdEvaluationStatusTypeID = thresholdEvaluationStatusTypeID;
            ThresholdEvaluationStatusTypeName = thresholdEvaluationStatusTypeName;
            ThresholdEvaluationStatusTypeDisplayName = thresholdEvaluationStatusTypeDisplayName;
        }

        [Key]
        public int ThresholdEvaluationStatusTypeID { get; private set; }
        public string ThresholdEvaluationStatusTypeName { get; private set; }
        public string ThresholdEvaluationStatusTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return ThresholdEvaluationStatusTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ThresholdEvaluationStatusType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ThresholdEvaluationStatusTypeID == ThresholdEvaluationStatusTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ThresholdEvaluationStatusType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ThresholdEvaluationStatusTypeID;
        }

        public static bool operator ==(ThresholdEvaluationStatusType left, ThresholdEvaluationStatusType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThresholdEvaluationStatusType left, ThresholdEvaluationStatusType right)
        {
            return !Equals(left, right);
        }

        public ThresholdEvaluationStatusTypeEnum ToEnum { get { return (ThresholdEvaluationStatusTypeEnum)GetHashCode(); } }

        public static ThresholdEvaluationStatusType ToType(int enumValue)
        {
            return ToType((ThresholdEvaluationStatusTypeEnum)enumValue);
        }

        public static ThresholdEvaluationStatusType ToType(ThresholdEvaluationStatusTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ThresholdEvaluationStatusTypeEnum.AtOrSomewhatBetter:
                    return AtOrSomewhatBetter;
                case ThresholdEvaluationStatusTypeEnum.ConsiderablyBetter:
                    return ConsiderablyBetter;
                case ThresholdEvaluationStatusTypeEnum.ConsiderablyWorse:
                    return ConsiderablyWorse;
                case ThresholdEvaluationStatusTypeEnum.InsufficientData:
                    return InsufficientData;
                case ThresholdEvaluationStatusTypeEnum.SomewhatWorse:
                    return SomewhatWorse;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ThresholdEvaluationStatusTypeEnum
    {
        ConsiderablyBetter = 1,
        AtOrSomewhatBetter = 2,
        SomewhatWorse = 3,
        ConsiderablyWorse = 4,
        InsufficientData = 5
    }

    public partial class ThresholdEvaluationStatusTypeConsiderablyBetter : ThresholdEvaluationStatusType
    {
        private ThresholdEvaluationStatusTypeConsiderablyBetter(int thresholdEvaluationStatusTypeID, string thresholdEvaluationStatusTypeName, string thresholdEvaluationStatusTypeDisplayName) : base(thresholdEvaluationStatusTypeID, thresholdEvaluationStatusTypeName, thresholdEvaluationStatusTypeDisplayName) {}
        public static readonly ThresholdEvaluationStatusTypeConsiderablyBetter Instance = new ThresholdEvaluationStatusTypeConsiderablyBetter(1, @"ConsiderablyBetter", @"Considerably Better Than Target");
    }

    public partial class ThresholdEvaluationStatusTypeAtOrSomewhatBetter : ThresholdEvaluationStatusType
    {
        private ThresholdEvaluationStatusTypeAtOrSomewhatBetter(int thresholdEvaluationStatusTypeID, string thresholdEvaluationStatusTypeName, string thresholdEvaluationStatusTypeDisplayName) : base(thresholdEvaluationStatusTypeID, thresholdEvaluationStatusTypeName, thresholdEvaluationStatusTypeDisplayName) {}
        public static readonly ThresholdEvaluationStatusTypeAtOrSomewhatBetter Instance = new ThresholdEvaluationStatusTypeAtOrSomewhatBetter(2, @"AtOrSomewhatBetter", @"At or Somewhat Better Than Target");
    }

    public partial class ThresholdEvaluationStatusTypeSomewhatWorse : ThresholdEvaluationStatusType
    {
        private ThresholdEvaluationStatusTypeSomewhatWorse(int thresholdEvaluationStatusTypeID, string thresholdEvaluationStatusTypeName, string thresholdEvaluationStatusTypeDisplayName) : base(thresholdEvaluationStatusTypeID, thresholdEvaluationStatusTypeName, thresholdEvaluationStatusTypeDisplayName) {}
        public static readonly ThresholdEvaluationStatusTypeSomewhatWorse Instance = new ThresholdEvaluationStatusTypeSomewhatWorse(3, @"SomewhatWorse", @"Somewhat Worse Than Target");
    }

    public partial class ThresholdEvaluationStatusTypeConsiderablyWorse : ThresholdEvaluationStatusType
    {
        private ThresholdEvaluationStatusTypeConsiderablyWorse(int thresholdEvaluationStatusTypeID, string thresholdEvaluationStatusTypeName, string thresholdEvaluationStatusTypeDisplayName) : base(thresholdEvaluationStatusTypeID, thresholdEvaluationStatusTypeName, thresholdEvaluationStatusTypeDisplayName) {}
        public static readonly ThresholdEvaluationStatusTypeConsiderablyWorse Instance = new ThresholdEvaluationStatusTypeConsiderablyWorse(4, @"ConsiderablyWorse", @"Considerably Worse Than Target");
    }

    public partial class ThresholdEvaluationStatusTypeInsufficientData : ThresholdEvaluationStatusType
    {
        private ThresholdEvaluationStatusTypeInsufficientData(int thresholdEvaluationStatusTypeID, string thresholdEvaluationStatusTypeName, string thresholdEvaluationStatusTypeDisplayName) : base(thresholdEvaluationStatusTypeID, thresholdEvaluationStatusTypeName, thresholdEvaluationStatusTypeDisplayName) {}
        public static readonly ThresholdEvaluationStatusTypeInsufficientData Instance = new ThresholdEvaluationStatusTypeInsufficientData(5, @"InsufficientData", @"Insufficient Data to Determine Status or No Target Established");
    }
}