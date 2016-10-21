//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransactionState]
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
    public abstract partial class TransactionState : IHavePrimaryKey
    {
        public static readonly TransactionStateDraft Draft = TransactionStateDraft.Instance;
        public static readonly TransactionStateProposed Proposed = TransactionStateProposed.Instance;
        public static readonly TransactionStateApproved Approved = TransactionStateApproved.Instance;
        public static readonly TransactionStateDeAllocated DeAllocated = TransactionStateDeAllocated.Instance;
        public static readonly TransactionStateWithdrawn Withdrawn = TransactionStateWithdrawn.Instance;

        public static readonly List<TransactionState> All;
        public static readonly ReadOnlyDictionary<int, TransactionState> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static TransactionState()
        {
            All = new List<TransactionState> { Draft, Proposed, Approved, DeAllocated, Withdrawn };
            AllLookupDictionary = new ReadOnlyDictionary<int, TransactionState>(All.ToDictionary(x => x.TransactionStateID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected TransactionState(int transactionStateID, string transactionStateName, string transactionStateDisplayName, int sortOrder)
        {
            TransactionStateID = transactionStateID;
            TransactionStateName = transactionStateName;
            TransactionStateDisplayName = transactionStateDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int TransactionStateID { get; private set; }
        public string TransactionStateName { get; private set; }
        public string TransactionStateDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public int PrimaryKey { get { return TransactionStateID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(TransactionState other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TransactionStateID == TransactionStateID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as TransactionState);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TransactionStateID;
        }

        public static bool operator ==(TransactionState left, TransactionState right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TransactionState left, TransactionState right)
        {
            return !Equals(left, right);
        }

        public TransactionStateEnum ToEnum { get { return (TransactionStateEnum)GetHashCode(); } }

        public static TransactionState ToType(int enumValue)
        {
            return ToType((TransactionStateEnum)enumValue);
        }

        public static TransactionState ToType(TransactionStateEnum enumValue)
        {
            switch (enumValue)
            {
                case TransactionStateEnum.Approved:
                    return Approved;
                case TransactionStateEnum.DeAllocated:
                    return DeAllocated;
                case TransactionStateEnum.Draft:
                    return Draft;
                case TransactionStateEnum.Proposed:
                    return Proposed;
                case TransactionStateEnum.Withdrawn:
                    return Withdrawn;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TransactionStateEnum
    {
        Draft = 1,
        Proposed = 2,
        Approved = 3,
        DeAllocated = 4,
        Withdrawn = 5
    }

    public partial class TransactionStateDraft : TransactionState
    {
        private TransactionStateDraft(int transactionStateID, string transactionStateName, string transactionStateDisplayName, int sortOrder) : base(transactionStateID, transactionStateName, transactionStateDisplayName, sortOrder) {}
        public static readonly TransactionStateDraft Instance = new TransactionStateDraft(1, @"Draft", @"Draft", 1);
    }

    public partial class TransactionStateProposed : TransactionState
    {
        private TransactionStateProposed(int transactionStateID, string transactionStateName, string transactionStateDisplayName, int sortOrder) : base(transactionStateID, transactionStateName, transactionStateDisplayName, sortOrder) {}
        public static readonly TransactionStateProposed Instance = new TransactionStateProposed(2, @"Proposed", @"Proposed", 2);
    }

    public partial class TransactionStateApproved : TransactionState
    {
        private TransactionStateApproved(int transactionStateID, string transactionStateName, string transactionStateDisplayName, int sortOrder) : base(transactionStateID, transactionStateName, transactionStateDisplayName, sortOrder) {}
        public static readonly TransactionStateApproved Instance = new TransactionStateApproved(3, @"Approved", @"Approved", 3);
    }

    public partial class TransactionStateDeAllocated : TransactionState
    {
        private TransactionStateDeAllocated(int transactionStateID, string transactionStateName, string transactionStateDisplayName, int sortOrder) : base(transactionStateID, transactionStateName, transactionStateDisplayName, sortOrder) {}
        public static readonly TransactionStateDeAllocated Instance = new TransactionStateDeAllocated(4, @"De-Allocated", @"De-Allocated", 4);
    }

    public partial class TransactionStateWithdrawn : TransactionState
    {
        private TransactionStateWithdrawn(int transactionStateID, string transactionStateName, string transactionStateDisplayName, int sortOrder) : base(transactionStateID, transactionStateName, transactionStateDisplayName, sortOrder) {}
        public static readonly TransactionStateWithdrawn Instance = new TransactionStateWithdrawn(5, @"Withdrawn", @"Withdrawn", 5);
    }
}