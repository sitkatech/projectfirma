//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgencyTransactionTypeCommodityLogChangeType]
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
    public abstract partial class LeadAgencyTransactionTypeCommodityLogChangeType : IHavePrimaryKey
    {
        public static readonly LeadAgencyTransactionTypeCommodityLogChangeTypeAdded Added = LeadAgencyTransactionTypeCommodityLogChangeTypeAdded.Instance;
        public static readonly LeadAgencyTransactionTypeCommodityLogChangeTypeRemoved Removed = LeadAgencyTransactionTypeCommodityLogChangeTypeRemoved.Instance;

        public static readonly List<LeadAgencyTransactionTypeCommodityLogChangeType> All;
        public static readonly ReadOnlyDictionary<int, LeadAgencyTransactionTypeCommodityLogChangeType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static LeadAgencyTransactionTypeCommodityLogChangeType()
        {
            All = new List<LeadAgencyTransactionTypeCommodityLogChangeType> { Added, Removed };
            AllLookupDictionary = new ReadOnlyDictionary<int, LeadAgencyTransactionTypeCommodityLogChangeType>(All.ToDictionary(x => x.LeadAgencyTransactionTypeCommodityLogChangeTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected LeadAgencyTransactionTypeCommodityLogChangeType(int leadAgencyTransactionTypeCommodityLogChangeTypeID, string leadAgencyTransactionTypeCommodityLogChangeTypeName, string leadAgencyTransactionTypeCommodityLogChangeTypeDisplayName)
        {
            LeadAgencyTransactionTypeCommodityLogChangeTypeID = leadAgencyTransactionTypeCommodityLogChangeTypeID;
            LeadAgencyTransactionTypeCommodityLogChangeTypeName = leadAgencyTransactionTypeCommodityLogChangeTypeName;
            LeadAgencyTransactionTypeCommodityLogChangeTypeDisplayName = leadAgencyTransactionTypeCommodityLogChangeTypeDisplayName;
        }

        [Key]
        public int LeadAgencyTransactionTypeCommodityLogChangeTypeID { get; private set; }
        public string LeadAgencyTransactionTypeCommodityLogChangeTypeName { get; private set; }
        public string LeadAgencyTransactionTypeCommodityLogChangeTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return LeadAgencyTransactionTypeCommodityLogChangeTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(LeadAgencyTransactionTypeCommodityLogChangeType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.LeadAgencyTransactionTypeCommodityLogChangeTypeID == LeadAgencyTransactionTypeCommodityLogChangeTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as LeadAgencyTransactionTypeCommodityLogChangeType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return LeadAgencyTransactionTypeCommodityLogChangeTypeID;
        }

        public static bool operator ==(LeadAgencyTransactionTypeCommodityLogChangeType left, LeadAgencyTransactionTypeCommodityLogChangeType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LeadAgencyTransactionTypeCommodityLogChangeType left, LeadAgencyTransactionTypeCommodityLogChangeType right)
        {
            return !Equals(left, right);
        }

        public LeadAgencyTransactionTypeCommodityLogChangeTypeEnum ToEnum { get { return (LeadAgencyTransactionTypeCommodityLogChangeTypeEnum)GetHashCode(); } }

        public static LeadAgencyTransactionTypeCommodityLogChangeType ToType(int enumValue)
        {
            return ToType((LeadAgencyTransactionTypeCommodityLogChangeTypeEnum)enumValue);
        }

        public static LeadAgencyTransactionTypeCommodityLogChangeType ToType(LeadAgencyTransactionTypeCommodityLogChangeTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case LeadAgencyTransactionTypeCommodityLogChangeTypeEnum.Added:
                    return Added;
                case LeadAgencyTransactionTypeCommodityLogChangeTypeEnum.Removed:
                    return Removed;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum LeadAgencyTransactionTypeCommodityLogChangeTypeEnum
    {
        Added = 1,
        Removed = 2
    }

    public partial class LeadAgencyTransactionTypeCommodityLogChangeTypeAdded : LeadAgencyTransactionTypeCommodityLogChangeType
    {
        private LeadAgencyTransactionTypeCommodityLogChangeTypeAdded(int leadAgencyTransactionTypeCommodityLogChangeTypeID, string leadAgencyTransactionTypeCommodityLogChangeTypeName, string leadAgencyTransactionTypeCommodityLogChangeTypeDisplayName) : base(leadAgencyTransactionTypeCommodityLogChangeTypeID, leadAgencyTransactionTypeCommodityLogChangeTypeName, leadAgencyTransactionTypeCommodityLogChangeTypeDisplayName) {}
        public static readonly LeadAgencyTransactionTypeCommodityLogChangeTypeAdded Instance = new LeadAgencyTransactionTypeCommodityLogChangeTypeAdded(1, @"Added", @"Added");
    }

    public partial class LeadAgencyTransactionTypeCommodityLogChangeTypeRemoved : LeadAgencyTransactionTypeCommodityLogChangeType
    {
        private LeadAgencyTransactionTypeCommodityLogChangeTypeRemoved(int leadAgencyTransactionTypeCommodityLogChangeTypeID, string leadAgencyTransactionTypeCommodityLogChangeTypeName, string leadAgencyTransactionTypeCommodityLogChangeTypeDisplayName) : base(leadAgencyTransactionTypeCommodityLogChangeTypeID, leadAgencyTransactionTypeCommodityLogChangeTypeName, leadAgencyTransactionTypeCommodityLogChangeTypeDisplayName) {}
        public static readonly LeadAgencyTransactionTypeCommodityLogChangeTypeRemoved Instance = new LeadAgencyTransactionTypeCommodityLogChangeTypeRemoved(2, @"Removed", @"Removed");
    }
}