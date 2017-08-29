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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class FundingType : IHavePrimaryKey
    {
        public static readonly FundingTypeCapital Capital = FundingTypeCapital.Instance;
        public static readonly FundingTypeOperationsAndMaintenance OperationsAndMaintenance = FundingTypeOperationsAndMaintenance.Instance;

        public static readonly List<FundingType> All;
        public static readonly ReadOnlyDictionary<int, FundingType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FundingType()
        {
            All = new List<FundingType> { Capital, OperationsAndMaintenance };
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
                case FundingTypeEnum.Capital:
                    return Capital;
                case FundingTypeEnum.OperationsAndMaintenance:
                    return OperationsAndMaintenance;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FundingTypeEnum
    {
        Capital = 1,
        OperationsAndMaintenance = 2
    }

    public partial class FundingTypeCapital : FundingType
    {
        private FundingTypeCapital(int fundingTypeID, string fundingTypeName, string fundingTypeDisplayName) : base(fundingTypeID, fundingTypeName, fundingTypeDisplayName) {}
        public static readonly FundingTypeCapital Instance = new FundingTypeCapital(1, @"Capital", @"Capital");
    }

    public partial class FundingTypeOperationsAndMaintenance : FundingType
    {
        private FundingTypeOperationsAndMaintenance(int fundingTypeID, string fundingTypeName, string fundingTypeDisplayName) : base(fundingTypeID, fundingTypeName, fundingTypeDisplayName) {}
        public static readonly FundingTypeOperationsAndMaintenance Instance = new FundingTypeOperationsAndMaintenance(2, @"OperationsAndMaintenance", @"Operations and Maintenance");
    }
}