//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AuditLogEventType]
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
    public abstract partial class AuditLogEventType : IHavePrimaryKey
    {
        public static readonly AuditLogEventTypeAdded Added = AuditLogEventTypeAdded.Instance;
        public static readonly AuditLogEventTypeDeleted Deleted = AuditLogEventTypeDeleted.Instance;
        public static readonly AuditLogEventTypeModified Modified = AuditLogEventTypeModified.Instance;

        public static readonly List<AuditLogEventType> All;
        public static readonly ReadOnlyDictionary<int, AuditLogEventType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static AuditLogEventType()
        {
            All = new List<AuditLogEventType> { Added, Deleted, Modified };
            AllLookupDictionary = new ReadOnlyDictionary<int, AuditLogEventType>(All.ToDictionary(x => x.AuditLogEventTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected AuditLogEventType(int auditLogEventTypeID, string auditLogEventTypeName, string auditLogEventTypeDisplayName)
        {
            AuditLogEventTypeID = auditLogEventTypeID;
            AuditLogEventTypeName = auditLogEventTypeName;
            AuditLogEventTypeDisplayName = auditLogEventTypeDisplayName;
        }

        [Key]
        public int AuditLogEventTypeID { get; private set; }
        public string AuditLogEventTypeName { get; private set; }
        public string AuditLogEventTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return AuditLogEventTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(AuditLogEventType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.AuditLogEventTypeID == AuditLogEventTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as AuditLogEventType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return AuditLogEventTypeID;
        }

        public static bool operator ==(AuditLogEventType left, AuditLogEventType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AuditLogEventType left, AuditLogEventType right)
        {
            return !Equals(left, right);
        }

        public AuditLogEventTypeEnum ToEnum { get { return (AuditLogEventTypeEnum)GetHashCode(); } }

        public static AuditLogEventType ToType(int enumValue)
        {
            return ToType((AuditLogEventTypeEnum)enumValue);
        }

        public static AuditLogEventType ToType(AuditLogEventTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case AuditLogEventTypeEnum.Added:
                    return Added;
                case AuditLogEventTypeEnum.Deleted:
                    return Deleted;
                case AuditLogEventTypeEnum.Modified:
                    return Modified;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum AuditLogEventTypeEnum
    {
        Added = 1,
        Deleted = 2,
        Modified = 3
    }

    public partial class AuditLogEventTypeAdded : AuditLogEventType
    {
        private AuditLogEventTypeAdded(int auditLogEventTypeID, string auditLogEventTypeName, string auditLogEventTypeDisplayName) : base(auditLogEventTypeID, auditLogEventTypeName, auditLogEventTypeDisplayName) {}
        public static readonly AuditLogEventTypeAdded Instance = new AuditLogEventTypeAdded(1, @"Added", @"Added");
    }

    public partial class AuditLogEventTypeDeleted : AuditLogEventType
    {
        private AuditLogEventTypeDeleted(int auditLogEventTypeID, string auditLogEventTypeName, string auditLogEventTypeDisplayName) : base(auditLogEventTypeID, auditLogEventTypeName, auditLogEventTypeDisplayName) {}
        public static readonly AuditLogEventTypeDeleted Instance = new AuditLogEventTypeDeleted(2, @"Deleted", @"Deleted");
    }

    public partial class AuditLogEventTypeModified : AuditLogEventType
    {
        private AuditLogEventTypeModified(int auditLogEventTypeID, string auditLogEventTypeName, string auditLogEventTypeDisplayName) : base(auditLogEventTypeID, auditLogEventTypeName, auditLogEventTypeDisplayName) {}
        public static readonly AuditLogEventTypeModified Instance = new AuditLogEventTypeModified(3, @"Modified", @"Modified");
    }
}