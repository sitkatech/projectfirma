//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotProjectType]
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
    public abstract partial class SnapshotProjectType : IHavePrimaryKey
    {
        public static readonly SnapshotProjectTypeAdded Added = SnapshotProjectTypeAdded.Instance;
        public static readonly SnapshotProjectTypeUpdated Updated = SnapshotProjectTypeUpdated.Instance;

        public static readonly List<SnapshotProjectType> All;
        public static readonly ReadOnlyDictionary<int, SnapshotProjectType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static SnapshotProjectType()
        {
            All = new List<SnapshotProjectType> { Added, Updated };
            AllLookupDictionary = new ReadOnlyDictionary<int, SnapshotProjectType>(All.ToDictionary(x => x.SnapshotProjectTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected SnapshotProjectType(int snapshotProjectTypeID, string snapshotProjectTypeName, string snapshotProjectTypeDisplayName)
        {
            SnapshotProjectTypeID = snapshotProjectTypeID;
            SnapshotProjectTypeName = snapshotProjectTypeName;
            SnapshotProjectTypeDisplayName = snapshotProjectTypeDisplayName;
        }

        [Key]
        public int SnapshotProjectTypeID { get; private set; }
        public string SnapshotProjectTypeName { get; private set; }
        public string SnapshotProjectTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return SnapshotProjectTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(SnapshotProjectType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.SnapshotProjectTypeID == SnapshotProjectTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as SnapshotProjectType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return SnapshotProjectTypeID;
        }

        public static bool operator ==(SnapshotProjectType left, SnapshotProjectType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SnapshotProjectType left, SnapshotProjectType right)
        {
            return !Equals(left, right);
        }

        public SnapshotProjectTypeEnum ToEnum { get { return (SnapshotProjectTypeEnum)GetHashCode(); } }

        public static SnapshotProjectType ToType(int enumValue)
        {
            return ToType((SnapshotProjectTypeEnum)enumValue);
        }

        public static SnapshotProjectType ToType(SnapshotProjectTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case SnapshotProjectTypeEnum.Added:
                    return Added;
                case SnapshotProjectTypeEnum.Updated:
                    return Updated;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum SnapshotProjectTypeEnum
    {
        Added = 1,
        Updated = 2
    }

    public partial class SnapshotProjectTypeAdded : SnapshotProjectType
    {
        private SnapshotProjectTypeAdded(int snapshotProjectTypeID, string snapshotProjectTypeName, string snapshotProjectTypeDisplayName) : base(snapshotProjectTypeID, snapshotProjectTypeName, snapshotProjectTypeDisplayName) {}
        public static readonly SnapshotProjectTypeAdded Instance = new SnapshotProjectTypeAdded(1, @"Added", @"Added");
    }

    public partial class SnapshotProjectTypeUpdated : SnapshotProjectType
    {
        private SnapshotProjectTypeUpdated(int snapshotProjectTypeID, string snapshotProjectTypeName, string snapshotProjectTypeDisplayName) : base(snapshotProjectTypeID, snapshotProjectTypeName, snapshotProjectTypeDisplayName) {}
        public static readonly SnapshotProjectTypeUpdated Instance = new SnapshotProjectTypeUpdated(2, @"Updated", @"Updated");
    }
}