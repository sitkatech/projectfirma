//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdStandardType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class ThresholdStandardType : IHavePrimaryKey
    {
        public static readonly ThresholdStandardTypeNumeric Numeric = ThresholdStandardTypeNumeric.Instance;
        public static readonly ThresholdStandardTypeManagement Management = ThresholdStandardTypeManagement.Instance;
        public static readonly ThresholdStandardTypePolicyStatement PolicyStatement = ThresholdStandardTypePolicyStatement.Instance;
        public static readonly ThresholdStandardTypeManagementWithNumeric ManagementWithNumeric = ThresholdStandardTypeManagementWithNumeric.Instance;
        public static readonly ThresholdStandardTypeNonDegradation NonDegradation = ThresholdStandardTypeNonDegradation.Instance;

        public static readonly List<ThresholdStandardType> All;
        public static readonly ReadOnlyDictionary<int, ThresholdStandardType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ThresholdStandardType()
        {
            All = new List<ThresholdStandardType> { Numeric, Management, PolicyStatement, ManagementWithNumeric, NonDegradation };
            AllLookupDictionary = new ReadOnlyDictionary<int, ThresholdStandardType>(All.ToDictionary(x => x.ThresholdStandardTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ThresholdStandardType(int thresholdStandardTypeID, string thresholdStandardTypeName, string thresholdStandardTypeDisplayName)
        {
            ThresholdStandardTypeID = thresholdStandardTypeID;
            ThresholdStandardTypeName = thresholdStandardTypeName;
            ThresholdStandardTypeDisplayName = thresholdStandardTypeDisplayName;
        }

        [Key]
        public int ThresholdStandardTypeID { get; private set; }
        public string ThresholdStandardTypeName { get; private set; }
        public string ThresholdStandardTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return ThresholdStandardTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ThresholdStandardType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ThresholdStandardTypeID == ThresholdStandardTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ThresholdStandardType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ThresholdStandardTypeID;
        }

        public static bool operator ==(ThresholdStandardType left, ThresholdStandardType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThresholdStandardType left, ThresholdStandardType right)
        {
            return !Equals(left, right);
        }

        public ThresholdStandardTypeEnum ToEnum { get { return (ThresholdStandardTypeEnum)GetHashCode(); } }

        public static ThresholdStandardType ToType(int enumValue)
        {
            return ToType((ThresholdStandardTypeEnum)enumValue);
        }

        public static ThresholdStandardType ToType(ThresholdStandardTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ThresholdStandardTypeEnum.Management:
                    return Management;
                case ThresholdStandardTypeEnum.ManagementWithNumeric:
                    return ManagementWithNumeric;
                case ThresholdStandardTypeEnum.NonDegradation:
                    return NonDegradation;
                case ThresholdStandardTypeEnum.Numeric:
                    return Numeric;
                case ThresholdStandardTypeEnum.PolicyStatement:
                    return PolicyStatement;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ThresholdStandardTypeEnum
    {
        Numeric = 1,
        Management = 2,
        PolicyStatement = 3,
        ManagementWithNumeric = 4,
        NonDegradation = 5
    }

    public partial class ThresholdStandardTypeNumeric : ThresholdStandardType
    {
        private ThresholdStandardTypeNumeric(int thresholdStandardTypeID, string thresholdStandardTypeName, string thresholdStandardTypeDisplayName) : base(thresholdStandardTypeID, thresholdStandardTypeName, thresholdStandardTypeDisplayName) {}
        public static readonly ThresholdStandardTypeNumeric Instance = new ThresholdStandardTypeNumeric(1, @"Numeric", @"Numeric");
    }

    public partial class ThresholdStandardTypeManagement : ThresholdStandardType
    {
        private ThresholdStandardTypeManagement(int thresholdStandardTypeID, string thresholdStandardTypeName, string thresholdStandardTypeDisplayName) : base(thresholdStandardTypeID, thresholdStandardTypeName, thresholdStandardTypeDisplayName) {}
        public static readonly ThresholdStandardTypeManagement Instance = new ThresholdStandardTypeManagement(2, @"Management", @"Management");
    }

    public partial class ThresholdStandardTypePolicyStatement : ThresholdStandardType
    {
        private ThresholdStandardTypePolicyStatement(int thresholdStandardTypeID, string thresholdStandardTypeName, string thresholdStandardTypeDisplayName) : base(thresholdStandardTypeID, thresholdStandardTypeName, thresholdStandardTypeDisplayName) {}
        public static readonly ThresholdStandardTypePolicyStatement Instance = new ThresholdStandardTypePolicyStatement(3, @"PolicyStatement", @"Policy Statement");
    }

    public partial class ThresholdStandardTypeManagementWithNumeric : ThresholdStandardType
    {
        private ThresholdStandardTypeManagementWithNumeric(int thresholdStandardTypeID, string thresholdStandardTypeName, string thresholdStandardTypeDisplayName) : base(thresholdStandardTypeID, thresholdStandardTypeName, thresholdStandardTypeDisplayName) {}
        public static readonly ThresholdStandardTypeManagementWithNumeric Instance = new ThresholdStandardTypeManagementWithNumeric(4, @"ManagementWithNumeric", @"Management with Numeric");
    }

    public partial class ThresholdStandardTypeNonDegradation : ThresholdStandardType
    {
        private ThresholdStandardTypeNonDegradation(int thresholdStandardTypeID, string thresholdStandardTypeName, string thresholdStandardTypeDisplayName) : base(thresholdStandardTypeID, thresholdStandardTypeName, thresholdStandardTypeDisplayName) {}
        public static readonly ThresholdStandardTypeNonDegradation Instance = new ThresholdStandardTypeNonDegradation(5, @"NonDegradation", @"Non-Degradation");
    }
}