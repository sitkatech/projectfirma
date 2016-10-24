//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluationManagementStatusType]
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
    public abstract partial class ThresholdEvaluationManagementStatusType : IHavePrimaryKey
    {
        public static readonly ThresholdEvaluationManagementStatusTypeImplemented Implemented = ThresholdEvaluationManagementStatusTypeImplemented.Instance;
        public static readonly ThresholdEvaluationManagementStatusTypePartiallyImplemented PartiallyImplemented = ThresholdEvaluationManagementStatusTypePartiallyImplemented.Instance;
        public static readonly ThresholdEvaluationManagementStatusTypeNotImplemented NotImplemented = ThresholdEvaluationManagementStatusTypeNotImplemented.Instance;

        public static readonly List<ThresholdEvaluationManagementStatusType> All;
        public static readonly ReadOnlyDictionary<int, ThresholdEvaluationManagementStatusType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ThresholdEvaluationManagementStatusType()
        {
            All = new List<ThresholdEvaluationManagementStatusType> { Implemented, PartiallyImplemented, NotImplemented };
            AllLookupDictionary = new ReadOnlyDictionary<int, ThresholdEvaluationManagementStatusType>(All.ToDictionary(x => x.ThresholdEvaluationManagementStatusTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ThresholdEvaluationManagementStatusType(int thresholdEvaluationManagementStatusTypeID, string thresholdEvaluationManagementStatusTypeName, string thresholdEvaluationManagementStatusTypeDisplayName, string thresholdEvaluationManagementStatusTypeAbbreviation, string thresholdEvaluationManagementStatusTypeDescription)
        {
            ThresholdEvaluationManagementStatusTypeID = thresholdEvaluationManagementStatusTypeID;
            ThresholdEvaluationManagementStatusTypeName = thresholdEvaluationManagementStatusTypeName;
            ThresholdEvaluationManagementStatusTypeDisplayName = thresholdEvaluationManagementStatusTypeDisplayName;
            ThresholdEvaluationManagementStatusTypeAbbreviation = thresholdEvaluationManagementStatusTypeAbbreviation;
            ThresholdEvaluationManagementStatusTypeDescription = thresholdEvaluationManagementStatusTypeDescription;
        }

        [Key]
        public int ThresholdEvaluationManagementStatusTypeID { get; private set; }
        public string ThresholdEvaluationManagementStatusTypeName { get; private set; }
        public string ThresholdEvaluationManagementStatusTypeDisplayName { get; private set; }
        public string ThresholdEvaluationManagementStatusTypeAbbreviation { get; private set; }
        public string ThresholdEvaluationManagementStatusTypeDescription { get; private set; }
        public int PrimaryKey { get { return ThresholdEvaluationManagementStatusTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ThresholdEvaluationManagementStatusType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ThresholdEvaluationManagementStatusTypeID == ThresholdEvaluationManagementStatusTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ThresholdEvaluationManagementStatusType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ThresholdEvaluationManagementStatusTypeID;
        }

        public static bool operator ==(ThresholdEvaluationManagementStatusType left, ThresholdEvaluationManagementStatusType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThresholdEvaluationManagementStatusType left, ThresholdEvaluationManagementStatusType right)
        {
            return !Equals(left, right);
        }

        public ThresholdEvaluationManagementStatusTypeEnum ToEnum { get { return (ThresholdEvaluationManagementStatusTypeEnum)GetHashCode(); } }

        public static ThresholdEvaluationManagementStatusType ToType(int enumValue)
        {
            return ToType((ThresholdEvaluationManagementStatusTypeEnum)enumValue);
        }

        public static ThresholdEvaluationManagementStatusType ToType(ThresholdEvaluationManagementStatusTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ThresholdEvaluationManagementStatusTypeEnum.Implemented:
                    return Implemented;
                case ThresholdEvaluationManagementStatusTypeEnum.NotImplemented:
                    return NotImplemented;
                case ThresholdEvaluationManagementStatusTypeEnum.PartiallyImplemented:
                    return PartiallyImplemented;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ThresholdEvaluationManagementStatusTypeEnum
    {
        Implemented = 1,
        PartiallyImplemented = 2,
        NotImplemented = 3
    }

    public partial class ThresholdEvaluationManagementStatusTypeImplemented : ThresholdEvaluationManagementStatusType
    {
        private ThresholdEvaluationManagementStatusTypeImplemented(int thresholdEvaluationManagementStatusTypeID, string thresholdEvaluationManagementStatusTypeName, string thresholdEvaluationManagementStatusTypeDisplayName, string thresholdEvaluationManagementStatusTypeAbbreviation, string thresholdEvaluationManagementStatusTypeDescription) : base(thresholdEvaluationManagementStatusTypeID, thresholdEvaluationManagementStatusTypeName, thresholdEvaluationManagementStatusTypeDisplayName, thresholdEvaluationManagementStatusTypeAbbreviation, thresholdEvaluationManagementStatusTypeDescription) {}
        public static readonly ThresholdEvaluationManagementStatusTypeImplemented Instance = new ThresholdEvaluationManagementStatusTypeImplemented(1, @"Implemented", @"Implemented", @"I", @"The Management Standard has been integrated into the Regional Plan as a policy and/or as an ordinance of regulation and is consistently applied to a project design or as a condition of project approval as a result of project review process.  Greater than three examples of programs or actions can be represented to support the Management Standard's implementation.  Adopted programs or actions support all aspects of the Management Standard's implementation, or address all major threats to implementation of the Management Standard.");
    }

    public partial class ThresholdEvaluationManagementStatusTypePartiallyImplemented : ThresholdEvaluationManagementStatusType
    {
        private ThresholdEvaluationManagementStatusTypePartiallyImplemented(int thresholdEvaluationManagementStatusTypeID, string thresholdEvaluationManagementStatusTypeName, string thresholdEvaluationManagementStatusTypeDisplayName, string thresholdEvaluationManagementStatusTypeAbbreviation, string thresholdEvaluationManagementStatusTypeDescription) : base(thresholdEvaluationManagementStatusTypeID, thresholdEvaluationManagementStatusTypeName, thresholdEvaluationManagementStatusTypeDisplayName, thresholdEvaluationManagementStatusTypeAbbreviation, thresholdEvaluationManagementStatusTypeDescription) {}
        public static readonly ThresholdEvaluationManagementStatusTypePartiallyImplemented Instance = new ThresholdEvaluationManagementStatusTypePartiallyImplemented(2, @"PartiallyImplemented", @"Partially Implemented", @"PI", @"The Management Standard has been integrated into the Regional Plan, but is not consistently applied during the course of the project review process.  No more than two examples of programs or actions can be identified to support the Management Standard's implementation and/or adopted programs or actions support some aspects of the Management Standard or address some major threats to implementation of the Management Standard.");
    }

    public partial class ThresholdEvaluationManagementStatusTypeNotImplemented : ThresholdEvaluationManagementStatusType
    {
        private ThresholdEvaluationManagementStatusTypeNotImplemented(int thresholdEvaluationManagementStatusTypeID, string thresholdEvaluationManagementStatusTypeName, string thresholdEvaluationManagementStatusTypeDisplayName, string thresholdEvaluationManagementStatusTypeAbbreviation, string thresholdEvaluationManagementStatusTypeDescription) : base(thresholdEvaluationManagementStatusTypeID, thresholdEvaluationManagementStatusTypeName, thresholdEvaluationManagementStatusTypeDisplayName, thresholdEvaluationManagementStatusTypeAbbreviation, thresholdEvaluationManagementStatusTypeDescription) {}
        public static readonly ThresholdEvaluationManagementStatusTypeNotImplemented Instance = new ThresholdEvaluationManagementStatusTypeNotImplemented(3, @"NotImplemented", @"Not Implemented", @"NI", @"The Management Standard has not been integrated into the Regional Plan and is not applied during the course of project review.  No examples of programs or actions can be identified to support implementation of the Management Standard.");
    }
}