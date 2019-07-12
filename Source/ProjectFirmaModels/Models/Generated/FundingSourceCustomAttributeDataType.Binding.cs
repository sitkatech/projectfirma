//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeDataType]
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
    public abstract partial class FundingSourceCustomAttributeDataType : IHavePrimaryKey
    {
        public static readonly FundingSourceCustomAttributeDataTypeString String = FundingSourceCustomAttributeDataTypeString.Instance;
        public static readonly FundingSourceCustomAttributeDataTypeInteger Integer = FundingSourceCustomAttributeDataTypeInteger.Instance;
        public static readonly FundingSourceCustomAttributeDataTypeDecimal Decimal = FundingSourceCustomAttributeDataTypeDecimal.Instance;
        public static readonly FundingSourceCustomAttributeDataTypeDateTime DateTime = FundingSourceCustomAttributeDataTypeDateTime.Instance;
        public static readonly FundingSourceCustomAttributeDataTypePickFromList PickFromList = FundingSourceCustomAttributeDataTypePickFromList.Instance;
        public static readonly FundingSourceCustomAttributeDataTypeMultiSelect MultiSelect = FundingSourceCustomAttributeDataTypeMultiSelect.Instance;

        public static readonly List<FundingSourceCustomAttributeDataType> All;
        public static readonly ReadOnlyDictionary<int, FundingSourceCustomAttributeDataType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FundingSourceCustomAttributeDataType()
        {
            All = new List<FundingSourceCustomAttributeDataType> { String, Integer, Decimal, DateTime, PickFromList, MultiSelect };
            AllLookupDictionary = new ReadOnlyDictionary<int, FundingSourceCustomAttributeDataType>(All.ToDictionary(x => x.FundingSourceCustomAttributeDataTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FundingSourceCustomAttributeDataType(int fundingSourceCustomAttributeDataTypeID, string fundingSourceCustomAttributeDataTypeName, string fundingSourceCustomAttributeDataTypeDisplayName)
        {
            FundingSourceCustomAttributeDataTypeID = fundingSourceCustomAttributeDataTypeID;
            FundingSourceCustomAttributeDataTypeName = fundingSourceCustomAttributeDataTypeName;
            FundingSourceCustomAttributeDataTypeDisplayName = fundingSourceCustomAttributeDataTypeDisplayName;
        }

        [Key]
        public int FundingSourceCustomAttributeDataTypeID { get; private set; }
        public string FundingSourceCustomAttributeDataTypeName { get; private set; }
        public string FundingSourceCustomAttributeDataTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingSourceCustomAttributeDataTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FundingSourceCustomAttributeDataType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FundingSourceCustomAttributeDataTypeID == FundingSourceCustomAttributeDataTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FundingSourceCustomAttributeDataType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FundingSourceCustomAttributeDataTypeID;
        }

        public static bool operator ==(FundingSourceCustomAttributeDataType left, FundingSourceCustomAttributeDataType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FundingSourceCustomAttributeDataType left, FundingSourceCustomAttributeDataType right)
        {
            return !Equals(left, right);
        }

        public FundingSourceCustomAttributeDataTypeEnum ToEnum { get { return (FundingSourceCustomAttributeDataTypeEnum)GetHashCode(); } }

        public static FundingSourceCustomAttributeDataType ToType(int enumValue)
        {
            return ToType((FundingSourceCustomAttributeDataTypeEnum)enumValue);
        }

        public static FundingSourceCustomAttributeDataType ToType(FundingSourceCustomAttributeDataTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FundingSourceCustomAttributeDataTypeEnum.DateTime:
                    return DateTime;
                case FundingSourceCustomAttributeDataTypeEnum.Decimal:
                    return Decimal;
                case FundingSourceCustomAttributeDataTypeEnum.Integer:
                    return Integer;
                case FundingSourceCustomAttributeDataTypeEnum.MultiSelect:
                    return MultiSelect;
                case FundingSourceCustomAttributeDataTypeEnum.PickFromList:
                    return PickFromList;
                case FundingSourceCustomAttributeDataTypeEnum.String:
                    return String;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FundingSourceCustomAttributeDataTypeEnum
    {
        String = 1,
        Integer = 2,
        Decimal = 3,
        DateTime = 4,
        PickFromList = 5,
        MultiSelect = 6
    }

    public partial class FundingSourceCustomAttributeDataTypeString : FundingSourceCustomAttributeDataType
    {
        private FundingSourceCustomAttributeDataTypeString(int fundingSourceCustomAttributeDataTypeID, string fundingSourceCustomAttributeDataTypeName, string fundingSourceCustomAttributeDataTypeDisplayName) : base(fundingSourceCustomAttributeDataTypeID, fundingSourceCustomAttributeDataTypeName, fundingSourceCustomAttributeDataTypeDisplayName) {}
        public static readonly FundingSourceCustomAttributeDataTypeString Instance = new FundingSourceCustomAttributeDataTypeString(1, @"String", @"String");
    }

    public partial class FundingSourceCustomAttributeDataTypeInteger : FundingSourceCustomAttributeDataType
    {
        private FundingSourceCustomAttributeDataTypeInteger(int fundingSourceCustomAttributeDataTypeID, string fundingSourceCustomAttributeDataTypeName, string fundingSourceCustomAttributeDataTypeDisplayName) : base(fundingSourceCustomAttributeDataTypeID, fundingSourceCustomAttributeDataTypeName, fundingSourceCustomAttributeDataTypeDisplayName) {}
        public static readonly FundingSourceCustomAttributeDataTypeInteger Instance = new FundingSourceCustomAttributeDataTypeInteger(2, @"Integer", @"Integer");
    }

    public partial class FundingSourceCustomAttributeDataTypeDecimal : FundingSourceCustomAttributeDataType
    {
        private FundingSourceCustomAttributeDataTypeDecimal(int fundingSourceCustomAttributeDataTypeID, string fundingSourceCustomAttributeDataTypeName, string fundingSourceCustomAttributeDataTypeDisplayName) : base(fundingSourceCustomAttributeDataTypeID, fundingSourceCustomAttributeDataTypeName, fundingSourceCustomAttributeDataTypeDisplayName) {}
        public static readonly FundingSourceCustomAttributeDataTypeDecimal Instance = new FundingSourceCustomAttributeDataTypeDecimal(3, @"Decimal", @"Decimal");
    }

    public partial class FundingSourceCustomAttributeDataTypeDateTime : FundingSourceCustomAttributeDataType
    {
        private FundingSourceCustomAttributeDataTypeDateTime(int fundingSourceCustomAttributeDataTypeID, string fundingSourceCustomAttributeDataTypeName, string fundingSourceCustomAttributeDataTypeDisplayName) : base(fundingSourceCustomAttributeDataTypeID, fundingSourceCustomAttributeDataTypeName, fundingSourceCustomAttributeDataTypeDisplayName) {}
        public static readonly FundingSourceCustomAttributeDataTypeDateTime Instance = new FundingSourceCustomAttributeDataTypeDateTime(4, @"DateTime", @"Date/Time");
    }

    public partial class FundingSourceCustomAttributeDataTypePickFromList : FundingSourceCustomAttributeDataType
    {
        private FundingSourceCustomAttributeDataTypePickFromList(int fundingSourceCustomAttributeDataTypeID, string fundingSourceCustomAttributeDataTypeName, string fundingSourceCustomAttributeDataTypeDisplayName) : base(fundingSourceCustomAttributeDataTypeID, fundingSourceCustomAttributeDataTypeName, fundingSourceCustomAttributeDataTypeDisplayName) {}
        public static readonly FundingSourceCustomAttributeDataTypePickFromList Instance = new FundingSourceCustomAttributeDataTypePickFromList(5, @"PickFromList", @"Pick One from List");
    }

    public partial class FundingSourceCustomAttributeDataTypeMultiSelect : FundingSourceCustomAttributeDataType
    {
        private FundingSourceCustomAttributeDataTypeMultiSelect(int fundingSourceCustomAttributeDataTypeID, string fundingSourceCustomAttributeDataTypeName, string fundingSourceCustomAttributeDataTypeDisplayName) : base(fundingSourceCustomAttributeDataTypeID, fundingSourceCustomAttributeDataTypeName, fundingSourceCustomAttributeDataTypeDisplayName) {}
        public static readonly FundingSourceCustomAttributeDataTypeMultiSelect Instance = new FundingSourceCustomAttributeDataTypeMultiSelect(6, @"MultiSelect", @"Select Many from List");
    }
}