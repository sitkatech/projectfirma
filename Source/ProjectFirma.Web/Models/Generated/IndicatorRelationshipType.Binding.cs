//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorRelationshipType]
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
    public abstract partial class IndicatorRelationshipType : IHavePrimaryKey
    {
        public static readonly IndicatorRelationshipTypeTertiary Tertiary = IndicatorRelationshipTypeTertiary.Instance;
        public static readonly IndicatorRelationshipTypeSecondary Secondary = IndicatorRelationshipTypeSecondary.Instance;
        public static readonly IndicatorRelationshipTypePrimary Primary = IndicatorRelationshipTypePrimary.Instance;

        public static readonly List<IndicatorRelationshipType> All;
        public static readonly ReadOnlyDictionary<int, IndicatorRelationshipType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static IndicatorRelationshipType()
        {
            All = new List<IndicatorRelationshipType> { Tertiary, Secondary, Primary };
            AllLookupDictionary = new ReadOnlyDictionary<int, IndicatorRelationshipType>(All.ToDictionary(x => x.IndicatorRelationshipTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected IndicatorRelationshipType(int indicatorRelationshipTypeID, string indicatorRelationshipTypeName, string indicatorRelationshipTypeDisplayName)
        {
            IndicatorRelationshipTypeID = indicatorRelationshipTypeID;
            IndicatorRelationshipTypeName = indicatorRelationshipTypeName;
            IndicatorRelationshipTypeDisplayName = indicatorRelationshipTypeDisplayName;
        }

        [Key]
        public int IndicatorRelationshipTypeID { get; private set; }
        public string IndicatorRelationshipTypeName { get; private set; }
        public string IndicatorRelationshipTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return IndicatorRelationshipTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(IndicatorRelationshipType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.IndicatorRelationshipTypeID == IndicatorRelationshipTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as IndicatorRelationshipType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return IndicatorRelationshipTypeID;
        }

        public static bool operator ==(IndicatorRelationshipType left, IndicatorRelationshipType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IndicatorRelationshipType left, IndicatorRelationshipType right)
        {
            return !Equals(left, right);
        }

        public IndicatorRelationshipTypeEnum ToEnum { get { return (IndicatorRelationshipTypeEnum)GetHashCode(); } }

        public static IndicatorRelationshipType ToType(int enumValue)
        {
            return ToType((IndicatorRelationshipTypeEnum)enumValue);
        }

        public static IndicatorRelationshipType ToType(IndicatorRelationshipTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case IndicatorRelationshipTypeEnum.Primary:
                    return Primary;
                case IndicatorRelationshipTypeEnum.Secondary:
                    return Secondary;
                case IndicatorRelationshipTypeEnum.Tertiary:
                    return Tertiary;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum IndicatorRelationshipTypeEnum
    {
        Tertiary = 1,
        Secondary = 2,
        Primary = 3
    }

    public partial class IndicatorRelationshipTypeTertiary : IndicatorRelationshipType
    {
        private IndicatorRelationshipTypeTertiary(int indicatorRelationshipTypeID, string indicatorRelationshipTypeName, string indicatorRelationshipTypeDisplayName) : base(indicatorRelationshipTypeID, indicatorRelationshipTypeName, indicatorRelationshipTypeDisplayName) {}
        public static readonly IndicatorRelationshipTypeTertiary Instance = new IndicatorRelationshipTypeTertiary(1, @"Tertiary", @"Tertiary");
    }

    public partial class IndicatorRelationshipTypeSecondary : IndicatorRelationshipType
    {
        private IndicatorRelationshipTypeSecondary(int indicatorRelationshipTypeID, string indicatorRelationshipTypeName, string indicatorRelationshipTypeDisplayName) : base(indicatorRelationshipTypeID, indicatorRelationshipTypeName, indicatorRelationshipTypeDisplayName) {}
        public static readonly IndicatorRelationshipTypeSecondary Instance = new IndicatorRelationshipTypeSecondary(2, @"Secondary", @"Secondary");
    }

    public partial class IndicatorRelationshipTypePrimary : IndicatorRelationshipType
    {
        private IndicatorRelationshipTypePrimary(int indicatorRelationshipTypeID, string indicatorRelationshipTypeName, string indicatorRelationshipTypeDisplayName) : base(indicatorRelationshipTypeID, indicatorRelationshipTypeName, indicatorRelationshipTypeDisplayName) {}
        public static readonly IndicatorRelationshipTypePrimary Instance = new IndicatorRelationshipTypePrimary(3, @"Primary", @"Primary");
    }
}