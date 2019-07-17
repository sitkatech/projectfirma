//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingType]
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
    public abstract partial class FundingType : IHavePrimaryKey
    {
        public static readonly FundingTypeBudgetVariesByYear BudgetVariesByYear = FundingTypeBudgetVariesByYear.Instance;
        public static readonly FundingTypeBudgetSameEachYear BudgetSameEachYear = FundingTypeBudgetSameEachYear.Instance;

        public static readonly List<FundingType> All;
        public static readonly ReadOnlyDictionary<int, FundingType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FundingType()
        {
            All = new List<FundingType> { BudgetVariesByYear, BudgetSameEachYear };
            AllLookupDictionary = new ReadOnlyDictionary<int, FundingType>(All.ToDictionary(x => x.FundingTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FundingType(int fundingTypeID, string fundingTypeName, string fundingTypeDisplayName)
        {
            FundingTypeID = fundingTypeID;
            FundingTypeName = fundingTypeName;
            FundingTypeDisplayName = fundingTypeDisplayName;
        }

        [Key]
        public int FundingTypeID { get; private set; }
        public string FundingTypeName { get; private set; }
        public string FundingTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FundingType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FundingTypeID == FundingTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FundingType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FundingTypeID;
        }

        public static bool operator ==(FundingType left, FundingType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FundingType left, FundingType right)
        {
            return !Equals(left, right);
        }

        public FundingTypeEnum ToEnum { get { return (FundingTypeEnum)GetHashCode(); } }

        public static FundingType ToType(int enumValue)
        {
            return ToType((FundingTypeEnum)enumValue);
        }

        public static FundingType ToType(FundingTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FundingTypeEnum.BudgetSameEachYear:
                    return BudgetSameEachYear;
                case FundingTypeEnum.BudgetVariesByYear:
                    return BudgetVariesByYear;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FundingTypeEnum
    {
        BudgetVariesByYear = 1,
        BudgetSameEachYear = 2
    }

    public partial class FundingTypeBudgetVariesByYear : FundingType
    {
        private FundingTypeBudgetVariesByYear(int fundingTypeID, string fundingTypeName, string fundingTypeDisplayName) : base(fundingTypeID, fundingTypeName, fundingTypeDisplayName) {}
        public static readonly FundingTypeBudgetVariesByYear Instance = new FundingTypeBudgetVariesByYear(1, @"BudgetVariesByYear", @"Budget varies by year, or it's a one-year project");
    }

    public partial class FundingTypeBudgetSameEachYear : FundingType
    {
        private FundingTypeBudgetSameEachYear(int fundingTypeID, string fundingTypeName, string fundingTypeDisplayName) : base(fundingTypeID, fundingTypeName, fundingTypeDisplayName) {}
        public static readonly FundingTypeBudgetSameEachYear Instance = new FundingTypeBudgetSameEachYear(2, @"BudgetSameEachYear", @"Budget is the same each year (e.g. annual maintenance)");
    }
}