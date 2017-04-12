//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectState]
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
    public abstract partial class ProposedProjectState : IHavePrimaryKey
    {
        public static readonly ProposedProjectStateDraft Draft = ProposedProjectStateDraft.Instance;
        public static readonly ProposedProjectStateSubmitted Submitted = ProposedProjectStateSubmitted.Instance;
        public static readonly ProposedProjectStateApproved Approved = ProposedProjectStateApproved.Instance;
        public static readonly ProposedProjectStateRejected Rejected = ProposedProjectStateRejected.Instance;

        public static readonly List<ProposedProjectState> All;
        public static readonly ReadOnlyDictionary<int, ProposedProjectState> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProposedProjectState()
        {
            All = new List<ProposedProjectState> { Draft, Submitted, Approved, Rejected };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProposedProjectState>(All.ToDictionary(x => x.ProposedProjectStateID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProposedProjectState(int proposedProjectStateID, string proposedProjectStateName, string proposedProjectStateDisplayName)
        {
            ProposedProjectStateID = proposedProjectStateID;
            ProposedProjectStateName = proposedProjectStateName;
            ProposedProjectStateDisplayName = proposedProjectStateDisplayName;
        }

        [Key]
        public int ProposedProjectStateID { get; private set; }
        public string ProposedProjectStateName { get; private set; }
        public string ProposedProjectStateDisplayName { get; private set; }
        public int PrimaryKey { get { return ProposedProjectStateID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProposedProjectState other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProposedProjectStateID == ProposedProjectStateID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProposedProjectState);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProposedProjectStateID;
        }

        public static bool operator ==(ProposedProjectState left, ProposedProjectState right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProposedProjectState left, ProposedProjectState right)
        {
            return !Equals(left, right);
        }

        public ProposedProjectStateEnum ToEnum { get { return (ProposedProjectStateEnum)GetHashCode(); } }

        public static ProposedProjectState ToType(int enumValue)
        {
            return ToType((ProposedProjectStateEnum)enumValue);
        }

        public static ProposedProjectState ToType(ProposedProjectStateEnum enumValue)
        {
            switch (enumValue)
            {
                case ProposedProjectStateEnum.Approved:
                    return Approved;
                case ProposedProjectStateEnum.Draft:
                    return Draft;
                case ProposedProjectStateEnum.Rejected:
                    return Rejected;
                case ProposedProjectStateEnum.Submitted:
                    return Submitted;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProposedProjectStateEnum
    {
        Draft = 1,
        Submitted = 2,
        Approved = 3,
        Rejected = 4
    }

    public partial class ProposedProjectStateDraft : ProposedProjectState
    {
        private ProposedProjectStateDraft(int proposedProjectStateID, string proposedProjectStateName, string proposedProjectStateDisplayName) : base(proposedProjectStateID, proposedProjectStateName, proposedProjectStateDisplayName) {}
        public static readonly ProposedProjectStateDraft Instance = new ProposedProjectStateDraft(1, @"Draft", @"Draft");
    }

    public partial class ProposedProjectStateSubmitted : ProposedProjectState
    {
        private ProposedProjectStateSubmitted(int proposedProjectStateID, string proposedProjectStateName, string proposedProjectStateDisplayName) : base(proposedProjectStateID, proposedProjectStateName, proposedProjectStateDisplayName) {}
        public static readonly ProposedProjectStateSubmitted Instance = new ProposedProjectStateSubmitted(2, @"Submitted", @"Submitted");
    }

    public partial class ProposedProjectStateApproved : ProposedProjectState
    {
        private ProposedProjectStateApproved(int proposedProjectStateID, string proposedProjectStateName, string proposedProjectStateDisplayName) : base(proposedProjectStateID, proposedProjectStateName, proposedProjectStateDisplayName) {}
        public static readonly ProposedProjectStateApproved Instance = new ProposedProjectStateApproved(3, @"Approved", @"Approved and Archived");
    }

    public partial class ProposedProjectStateRejected : ProposedProjectState
    {
        private ProposedProjectStateRejected(int proposedProjectStateID, string proposedProjectStateName, string proposedProjectStateDisplayName) : base(proposedProjectStateID, proposedProjectStateName, proposedProjectStateDisplayName) {}
        public static readonly ProposedProjectStateRejected Instance = new ProposedProjectStateRejected(4, @"Rejected", @"Rejected");
    }
}