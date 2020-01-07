//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationStatus]
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
    public abstract partial class EvaluationStatus : IHavePrimaryKey
    {
        public static readonly EvaluationStatusDraft Draft = EvaluationStatusDraft.Instance;
        public static readonly EvaluationStatusPlanned Planned = EvaluationStatusPlanned.Instance;
        public static readonly EvaluationStatusInProgress InProgress = EvaluationStatusInProgress.Instance;
        public static readonly EvaluationStatusCompleted Completed = EvaluationStatusCompleted.Instance;

        public static readonly List<EvaluationStatus> All;
        public static readonly ReadOnlyDictionary<int, EvaluationStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static EvaluationStatus()
        {
            All = new List<EvaluationStatus> { Draft, Planned, InProgress, Completed };
            AllLookupDictionary = new ReadOnlyDictionary<int, EvaluationStatus>(All.ToDictionary(x => x.EvaluationStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected EvaluationStatus(int evaluationStatusID, string evaluationStatusName, string evaluationStatusDisplayName)
        {
            EvaluationStatusID = evaluationStatusID;
            EvaluationStatusName = evaluationStatusName;
            EvaluationStatusDisplayName = evaluationStatusDisplayName;
        }

        [Key]
        public int EvaluationStatusID { get; private set; }
        public string EvaluationStatusName { get; private set; }
        public string EvaluationStatusDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(EvaluationStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.EvaluationStatusID == EvaluationStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as EvaluationStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return EvaluationStatusID;
        }

        public static bool operator ==(EvaluationStatus left, EvaluationStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EvaluationStatus left, EvaluationStatus right)
        {
            return !Equals(left, right);
        }

        public EvaluationStatusEnum ToEnum { get { return (EvaluationStatusEnum)GetHashCode(); } }

        public static EvaluationStatus ToType(int enumValue)
        {
            return ToType((EvaluationStatusEnum)enumValue);
        }

        public static EvaluationStatus ToType(EvaluationStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case EvaluationStatusEnum.Completed:
                    return Completed;
                case EvaluationStatusEnum.Draft:
                    return Draft;
                case EvaluationStatusEnum.InProgress:
                    return InProgress;
                case EvaluationStatusEnum.Planned:
                    return Planned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum EvaluationStatusEnum
    {
        Draft = 1,
        Planned = 2,
        InProgress = 3,
        Completed = 4
    }

    public partial class EvaluationStatusDraft : EvaluationStatus
    {
        private EvaluationStatusDraft(int evaluationStatusID, string evaluationStatusName, string evaluationStatusDisplayName) : base(evaluationStatusID, evaluationStatusName, evaluationStatusDisplayName) {}
        public static readonly EvaluationStatusDraft Instance = new EvaluationStatusDraft(1, @"Draft", @"Draft");
    }

    public partial class EvaluationStatusPlanned : EvaluationStatus
    {
        private EvaluationStatusPlanned(int evaluationStatusID, string evaluationStatusName, string evaluationStatusDisplayName) : base(evaluationStatusID, evaluationStatusName, evaluationStatusDisplayName) {}
        public static readonly EvaluationStatusPlanned Instance = new EvaluationStatusPlanned(2, @"Planned", @"Planned");
    }

    public partial class EvaluationStatusInProgress : EvaluationStatus
    {
        private EvaluationStatusInProgress(int evaluationStatusID, string evaluationStatusName, string evaluationStatusDisplayName) : base(evaluationStatusID, evaluationStatusName, evaluationStatusDisplayName) {}
        public static readonly EvaluationStatusInProgress Instance = new EvaluationStatusInProgress(3, @"InProgress", @"In Progress");
    }

    public partial class EvaluationStatusCompleted : EvaluationStatus
    {
        private EvaluationStatusCompleted(int evaluationStatusID, string evaluationStatusName, string evaluationStatusDisplayName) : base(evaluationStatusID, evaluationStatusName, evaluationStatusDisplayName) {}
        public static readonly EvaluationStatusCompleted Instance = new EvaluationStatusCompleted(4, @"Completed", @"Completed");
    }
}