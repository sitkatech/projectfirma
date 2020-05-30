//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AccomplishmentsDashboardFundingDisplayType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class AccomplishmentsDashboardFundingDisplayType : IHavePrimaryKey
    {
        public static readonly AccomplishmentsDashboardFundingDisplayTypeAllFundingReceived AllFundingReceived = AccomplishmentsDashboardFundingDisplayTypeAllFundingReceived.Instance;
        public static readonly AccomplishmentsDashboardFundingDisplayTypeOnlyFundingProvided OnlyFundingProvided = AccomplishmentsDashboardFundingDisplayTypeOnlyFundingProvided.Instance;

        public static readonly List<AccomplishmentsDashboardFundingDisplayType> All;
        public static readonly ReadOnlyDictionary<int, AccomplishmentsDashboardFundingDisplayType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static AccomplishmentsDashboardFundingDisplayType()
        {
            All = new List<AccomplishmentsDashboardFundingDisplayType> { AllFundingReceived, OnlyFundingProvided };
            AllLookupDictionary = new ReadOnlyDictionary<int, AccomplishmentsDashboardFundingDisplayType>(All.ToDictionary(x => x.AccomplishmentsDashboardFundingDisplayTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected AccomplishmentsDashboardFundingDisplayType(int accomplishmentsDashboardFundingDisplayTypeID, string accomplishmentsDashboardFundingDisplayTypeName, string accomplishmentsDashboardFundingDisplayTypeDisplayName, int sortOrder)
        {
            AccomplishmentsDashboardFundingDisplayTypeID = accomplishmentsDashboardFundingDisplayTypeID;
            AccomplishmentsDashboardFundingDisplayTypeName = accomplishmentsDashboardFundingDisplayTypeName;
            AccomplishmentsDashboardFundingDisplayTypeDisplayName = accomplishmentsDashboardFundingDisplayTypeDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int AccomplishmentsDashboardFundingDisplayTypeID { get; private set; }
        public string AccomplishmentsDashboardFundingDisplayTypeName { get; private set; }
        public string AccomplishmentsDashboardFundingDisplayTypeDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return AccomplishmentsDashboardFundingDisplayTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(AccomplishmentsDashboardFundingDisplayType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.AccomplishmentsDashboardFundingDisplayTypeID == AccomplishmentsDashboardFundingDisplayTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as AccomplishmentsDashboardFundingDisplayType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return AccomplishmentsDashboardFundingDisplayTypeID;
        }

        public static bool operator ==(AccomplishmentsDashboardFundingDisplayType left, AccomplishmentsDashboardFundingDisplayType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccomplishmentsDashboardFundingDisplayType left, AccomplishmentsDashboardFundingDisplayType right)
        {
            return !Equals(left, right);
        }

        public AccomplishmentsDashboardFundingDisplayTypeEnum ToEnum { get { return (AccomplishmentsDashboardFundingDisplayTypeEnum)GetHashCode(); } }

        public static AccomplishmentsDashboardFundingDisplayType ToType(int enumValue)
        {
            return ToType((AccomplishmentsDashboardFundingDisplayTypeEnum)enumValue);
        }

        public static AccomplishmentsDashboardFundingDisplayType ToType(AccomplishmentsDashboardFundingDisplayTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case AccomplishmentsDashboardFundingDisplayTypeEnum.AllFundingReceived:
                    return AllFundingReceived;
                case AccomplishmentsDashboardFundingDisplayTypeEnum.OnlyFundingProvided:
                    return OnlyFundingProvided;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum AccomplishmentsDashboardFundingDisplayTypeEnum
    {
        AllFundingReceived = 1,
        OnlyFundingProvided = 2
    }

    public partial class AccomplishmentsDashboardFundingDisplayTypeAllFundingReceived : AccomplishmentsDashboardFundingDisplayType
    {
        private AccomplishmentsDashboardFundingDisplayTypeAllFundingReceived(int accomplishmentsDashboardFundingDisplayTypeID, string accomplishmentsDashboardFundingDisplayTypeName, string accomplishmentsDashboardFundingDisplayTypeDisplayName, int sortOrder) : base(accomplishmentsDashboardFundingDisplayTypeID, accomplishmentsDashboardFundingDisplayTypeName, accomplishmentsDashboardFundingDisplayTypeDisplayName, sortOrder) {}
        public static readonly AccomplishmentsDashboardFundingDisplayTypeAllFundingReceived Instance = new AccomplishmentsDashboardFundingDisplayTypeAllFundingReceived(1, @"AllFundingReceived", @"All Funding Received By An Organization", 10);
    }

    public partial class AccomplishmentsDashboardFundingDisplayTypeOnlyFundingProvided : AccomplishmentsDashboardFundingDisplayType
    {
        private AccomplishmentsDashboardFundingDisplayTypeOnlyFundingProvided(int accomplishmentsDashboardFundingDisplayTypeID, string accomplishmentsDashboardFundingDisplayTypeName, string accomplishmentsDashboardFundingDisplayTypeDisplayName, int sortOrder) : base(accomplishmentsDashboardFundingDisplayTypeID, accomplishmentsDashboardFundingDisplayTypeName, accomplishmentsDashboardFundingDisplayTypeDisplayName, sortOrder) {}
        public static readonly AccomplishmentsDashboardFundingDisplayTypeOnlyFundingProvided Instance = new AccomplishmentsDashboardFundingDisplayTypeOnlyFundingProvided(2, @"OnlyFundingProvided", @"Only Funding Provided By An Organization", 20);
    }
}