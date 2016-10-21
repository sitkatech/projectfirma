//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluationTrendType]
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
    public abstract partial class ThresholdEvaluationTrendType : IHavePrimaryKey
    {
        public static readonly ThresholdEvaluationTrendTypeRapidImprovement RapidImprovement = ThresholdEvaluationTrendTypeRapidImprovement.Instance;
        public static readonly ThresholdEvaluationTrendTypeModerateImprovement ModerateImprovement = ThresholdEvaluationTrendTypeModerateImprovement.Instance;
        public static readonly ThresholdEvaluationTrendTypeLittleOrNoChange LittleOrNoChange = ThresholdEvaluationTrendTypeLittleOrNoChange.Instance;
        public static readonly ThresholdEvaluationTrendTypeModerateDecline ModerateDecline = ThresholdEvaluationTrendTypeModerateDecline.Instance;
        public static readonly ThresholdEvaluationTrendTypeRapidDecline RapidDecline = ThresholdEvaluationTrendTypeRapidDecline.Instance;
        public static readonly ThresholdEvaluationTrendTypeInsufficientData InsufficientData = ThresholdEvaluationTrendTypeInsufficientData.Instance;

        public static readonly List<ThresholdEvaluationTrendType> All;
        public static readonly ReadOnlyDictionary<int, ThresholdEvaluationTrendType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ThresholdEvaluationTrendType()
        {
            All = new List<ThresholdEvaluationTrendType> { RapidImprovement, ModerateImprovement, LittleOrNoChange, ModerateDecline, RapidDecline, InsufficientData };
            AllLookupDictionary = new ReadOnlyDictionary<int, ThresholdEvaluationTrendType>(All.ToDictionary(x => x.ThresholdEvaluationTrendTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ThresholdEvaluationTrendType(int thresholdEvaluationTrendTypeID, string thresholdEvaluationTrendTypeName, string thresholdEvaluationTrendTypeDisplayName)
        {
            ThresholdEvaluationTrendTypeID = thresholdEvaluationTrendTypeID;
            ThresholdEvaluationTrendTypeName = thresholdEvaluationTrendTypeName;
            ThresholdEvaluationTrendTypeDisplayName = thresholdEvaluationTrendTypeDisplayName;
        }

        [Key]
        public int ThresholdEvaluationTrendTypeID { get; private set; }
        public string ThresholdEvaluationTrendTypeName { get; private set; }
        public string ThresholdEvaluationTrendTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return ThresholdEvaluationTrendTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ThresholdEvaluationTrendType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ThresholdEvaluationTrendTypeID == ThresholdEvaluationTrendTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ThresholdEvaluationTrendType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ThresholdEvaluationTrendTypeID;
        }

        public static bool operator ==(ThresholdEvaluationTrendType left, ThresholdEvaluationTrendType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThresholdEvaluationTrendType left, ThresholdEvaluationTrendType right)
        {
            return !Equals(left, right);
        }

        public ThresholdEvaluationTrendTypeEnum ToEnum { get { return (ThresholdEvaluationTrendTypeEnum)GetHashCode(); } }

        public static ThresholdEvaluationTrendType ToType(int enumValue)
        {
            return ToType((ThresholdEvaluationTrendTypeEnum)enumValue);
        }

        public static ThresholdEvaluationTrendType ToType(ThresholdEvaluationTrendTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ThresholdEvaluationTrendTypeEnum.InsufficientData:
                    return InsufficientData;
                case ThresholdEvaluationTrendTypeEnum.LittleOrNoChange:
                    return LittleOrNoChange;
                case ThresholdEvaluationTrendTypeEnum.ModerateDecline:
                    return ModerateDecline;
                case ThresholdEvaluationTrendTypeEnum.ModerateImprovement:
                    return ModerateImprovement;
                case ThresholdEvaluationTrendTypeEnum.RapidDecline:
                    return RapidDecline;
                case ThresholdEvaluationTrendTypeEnum.RapidImprovement:
                    return RapidImprovement;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ThresholdEvaluationTrendTypeEnum
    {
        RapidImprovement = 1,
        ModerateImprovement = 2,
        LittleOrNoChange = 3,
        ModerateDecline = 4,
        RapidDecline = 5,
        InsufficientData = 6
    }

    public partial class ThresholdEvaluationTrendTypeRapidImprovement : ThresholdEvaluationTrendType
    {
        private ThresholdEvaluationTrendTypeRapidImprovement(int thresholdEvaluationTrendTypeID, string thresholdEvaluationTrendTypeName, string thresholdEvaluationTrendTypeDisplayName) : base(thresholdEvaluationTrendTypeID, thresholdEvaluationTrendTypeName, thresholdEvaluationTrendTypeDisplayName) {}
        public static readonly ThresholdEvaluationTrendTypeRapidImprovement Instance = new ThresholdEvaluationTrendTypeRapidImprovement(1, @"RapidImprovement", @"Rapid Improvement");
    }

    public partial class ThresholdEvaluationTrendTypeModerateImprovement : ThresholdEvaluationTrendType
    {
        private ThresholdEvaluationTrendTypeModerateImprovement(int thresholdEvaluationTrendTypeID, string thresholdEvaluationTrendTypeName, string thresholdEvaluationTrendTypeDisplayName) : base(thresholdEvaluationTrendTypeID, thresholdEvaluationTrendTypeName, thresholdEvaluationTrendTypeDisplayName) {}
        public static readonly ThresholdEvaluationTrendTypeModerateImprovement Instance = new ThresholdEvaluationTrendTypeModerateImprovement(2, @"ModerateImprovement", @"Moderate Improvement");
    }

    public partial class ThresholdEvaluationTrendTypeLittleOrNoChange : ThresholdEvaluationTrendType
    {
        private ThresholdEvaluationTrendTypeLittleOrNoChange(int thresholdEvaluationTrendTypeID, string thresholdEvaluationTrendTypeName, string thresholdEvaluationTrendTypeDisplayName) : base(thresholdEvaluationTrendTypeID, thresholdEvaluationTrendTypeName, thresholdEvaluationTrendTypeDisplayName) {}
        public static readonly ThresholdEvaluationTrendTypeLittleOrNoChange Instance = new ThresholdEvaluationTrendTypeLittleOrNoChange(3, @"LittleOrNoChange", @"Little or No Change");
    }

    public partial class ThresholdEvaluationTrendTypeModerateDecline : ThresholdEvaluationTrendType
    {
        private ThresholdEvaluationTrendTypeModerateDecline(int thresholdEvaluationTrendTypeID, string thresholdEvaluationTrendTypeName, string thresholdEvaluationTrendTypeDisplayName) : base(thresholdEvaluationTrendTypeID, thresholdEvaluationTrendTypeName, thresholdEvaluationTrendTypeDisplayName) {}
        public static readonly ThresholdEvaluationTrendTypeModerateDecline Instance = new ThresholdEvaluationTrendTypeModerateDecline(4, @"ModerateDecline", @"Moderate Decline");
    }

    public partial class ThresholdEvaluationTrendTypeRapidDecline : ThresholdEvaluationTrendType
    {
        private ThresholdEvaluationTrendTypeRapidDecline(int thresholdEvaluationTrendTypeID, string thresholdEvaluationTrendTypeName, string thresholdEvaluationTrendTypeDisplayName) : base(thresholdEvaluationTrendTypeID, thresholdEvaluationTrendTypeName, thresholdEvaluationTrendTypeDisplayName) {}
        public static readonly ThresholdEvaluationTrendTypeRapidDecline Instance = new ThresholdEvaluationTrendTypeRapidDecline(5, @"RapidDecline", @"Rapid Decline");
    }

    public partial class ThresholdEvaluationTrendTypeInsufficientData : ThresholdEvaluationTrendType
    {
        private ThresholdEvaluationTrendTypeInsufficientData(int thresholdEvaluationTrendTypeID, string thresholdEvaluationTrendTypeName, string thresholdEvaluationTrendTypeDisplayName) : base(thresholdEvaluationTrendTypeID, thresholdEvaluationTrendTypeName, thresholdEvaluationTrendTypeDisplayName) {}
        public static readonly ThresholdEvaluationTrendTypeInsufficientData Instance = new ThresholdEvaluationTrendTypeInsufficientData(6, @"InsufficientData", @"Insufficient Data to Determine Trend");
    }
}