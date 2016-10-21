//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelCommodityBaileyRatingConfirmationStatus]
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
    public abstract partial class ParcelCommodityBaileyRatingConfirmationStatus : IHavePrimaryKey
    {
        public static readonly ParcelCommodityBaileyRatingConfirmationStatusConfirmedComplete ConfirmedComplete = ParcelCommodityBaileyRatingConfirmationStatusConfirmedComplete.Instance;
        public static readonly ParcelCommodityBaileyRatingConfirmationStatusConfirmedIncomplete ConfirmedIncomplete = ParcelCommodityBaileyRatingConfirmationStatusConfirmedIncomplete.Instance;
        public static readonly ParcelCommodityBaileyRatingConfirmationStatusUnconfirmedInventory UnconfirmedInventory = ParcelCommodityBaileyRatingConfirmationStatusUnconfirmedInventory.Instance;

        public static readonly List<ParcelCommodityBaileyRatingConfirmationStatus> All;
        public static readonly ReadOnlyDictionary<int, ParcelCommodityBaileyRatingConfirmationStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ParcelCommodityBaileyRatingConfirmationStatus()
        {
            All = new List<ParcelCommodityBaileyRatingConfirmationStatus> { ConfirmedComplete, ConfirmedIncomplete, UnconfirmedInventory };
            AllLookupDictionary = new ReadOnlyDictionary<int, ParcelCommodityBaileyRatingConfirmationStatus>(All.ToDictionary(x => x.ParcelCommodityBaileyRatingConfirmationStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ParcelCommodityBaileyRatingConfirmationStatus(int parcelCommodityBaileyRatingConfirmationStatusID, string parcelCommodityBaileyRatingConfirmationStatusName, string displayName)
        {
            ParcelCommodityBaileyRatingConfirmationStatusID = parcelCommodityBaileyRatingConfirmationStatusID;
            ParcelCommodityBaileyRatingConfirmationStatusName = parcelCommodityBaileyRatingConfirmationStatusName;
            DisplayName = displayName;
        }

        [Key]
        public int ParcelCommodityBaileyRatingConfirmationStatusID { get; private set; }
        public string ParcelCommodityBaileyRatingConfirmationStatusName { get; private set; }
        public string DisplayName { get; private set; }
        public int PrimaryKey { get { return ParcelCommodityBaileyRatingConfirmationStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ParcelCommodityBaileyRatingConfirmationStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ParcelCommodityBaileyRatingConfirmationStatusID == ParcelCommodityBaileyRatingConfirmationStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ParcelCommodityBaileyRatingConfirmationStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ParcelCommodityBaileyRatingConfirmationStatusID;
        }

        public static bool operator ==(ParcelCommodityBaileyRatingConfirmationStatus left, ParcelCommodityBaileyRatingConfirmationStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ParcelCommodityBaileyRatingConfirmationStatus left, ParcelCommodityBaileyRatingConfirmationStatus right)
        {
            return !Equals(left, right);
        }

        public ParcelCommodityBaileyRatingConfirmationStatusEnum ToEnum { get { return (ParcelCommodityBaileyRatingConfirmationStatusEnum)GetHashCode(); } }

        public static ParcelCommodityBaileyRatingConfirmationStatus ToType(int enumValue)
        {
            return ToType((ParcelCommodityBaileyRatingConfirmationStatusEnum)enumValue);
        }

        public static ParcelCommodityBaileyRatingConfirmationStatus ToType(ParcelCommodityBaileyRatingConfirmationStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case ParcelCommodityBaileyRatingConfirmationStatusEnum.ConfirmedComplete:
                    return ConfirmedComplete;
                case ParcelCommodityBaileyRatingConfirmationStatusEnum.ConfirmedIncomplete:
                    return ConfirmedIncomplete;
                case ParcelCommodityBaileyRatingConfirmationStatusEnum.UnconfirmedInventory:
                    return UnconfirmedInventory;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ParcelCommodityBaileyRatingConfirmationStatusEnum
    {
        ConfirmedComplete = 1,
        ConfirmedIncomplete = 2,
        UnconfirmedInventory = 3
    }

    public partial class ParcelCommodityBaileyRatingConfirmationStatusConfirmedComplete : ParcelCommodityBaileyRatingConfirmationStatus
    {
        private ParcelCommodityBaileyRatingConfirmationStatusConfirmedComplete(int parcelCommodityBaileyRatingConfirmationStatusID, string parcelCommodityBaileyRatingConfirmationStatusName, string displayName) : base(parcelCommodityBaileyRatingConfirmationStatusID, parcelCommodityBaileyRatingConfirmationStatusName, displayName) {}
        public static readonly ParcelCommodityBaileyRatingConfirmationStatusConfirmedComplete Instance = new ParcelCommodityBaileyRatingConfirmationStatusConfirmedComplete(1, @"ConfirmedComplete", @"Complete");
    }

    public partial class ParcelCommodityBaileyRatingConfirmationStatusConfirmedIncomplete : ParcelCommodityBaileyRatingConfirmationStatus
    {
        private ParcelCommodityBaileyRatingConfirmationStatusConfirmedIncomplete(int parcelCommodityBaileyRatingConfirmationStatusID, string parcelCommodityBaileyRatingConfirmationStatusName, string displayName) : base(parcelCommodityBaileyRatingConfirmationStatusID, parcelCommodityBaileyRatingConfirmationStatusName, displayName) {}
        public static readonly ParcelCommodityBaileyRatingConfirmationStatusConfirmedIncomplete Instance = new ParcelCommodityBaileyRatingConfirmationStatusConfirmedIncomplete(2, @"ConfirmedIncomplete", @"Incomplete");
    }

    public partial class ParcelCommodityBaileyRatingConfirmationStatusUnconfirmedInventory : ParcelCommodityBaileyRatingConfirmationStatus
    {
        private ParcelCommodityBaileyRatingConfirmationStatusUnconfirmedInventory(int parcelCommodityBaileyRatingConfirmationStatusID, string parcelCommodityBaileyRatingConfirmationStatusName, string displayName) : base(parcelCommodityBaileyRatingConfirmationStatusID, parcelCommodityBaileyRatingConfirmationStatusName, displayName) {}
        public static readonly ParcelCommodityBaileyRatingConfirmationStatusUnconfirmedInventory Instance = new ParcelCommodityBaileyRatingConfirmationStatusUnconfirmedInventory(3, @"UnconfirmedInventory", @"Unconfirmed");
    }
}