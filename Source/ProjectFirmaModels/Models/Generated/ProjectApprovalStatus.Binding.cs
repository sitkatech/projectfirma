//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectApprovalStatus]
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
    public abstract partial class ProjectApprovalStatus : IHavePrimaryKey
    {
        public static readonly ProjectApprovalStatusDraft Draft = ProjectApprovalStatusDraft.Instance;
        public static readonly ProjectApprovalStatusPendingApproval PendingApproval = ProjectApprovalStatusPendingApproval.Instance;
        public static readonly ProjectApprovalStatusApproved Approved = ProjectApprovalStatusApproved.Instance;
        public static readonly ProjectApprovalStatusRejected Rejected = ProjectApprovalStatusRejected.Instance;
        public static readonly ProjectApprovalStatusReturned Returned = ProjectApprovalStatusReturned.Instance;

        public static readonly List<ProjectApprovalStatus> All;
        public static readonly ReadOnlyDictionary<int, ProjectApprovalStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectApprovalStatus()
        {
            All = new List<ProjectApprovalStatus> { Draft, PendingApproval, Approved, Rejected, Returned };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectApprovalStatus>(All.ToDictionary(x => x.ProjectApprovalStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectApprovalStatus(int projectApprovalStatusID, string projectApprovalStatusName, string projectApprovalStatusDisplayName)
        {
            ProjectApprovalStatusID = projectApprovalStatusID;
            ProjectApprovalStatusName = projectApprovalStatusName;
            ProjectApprovalStatusDisplayName = projectApprovalStatusDisplayName;
        }

        [Key]
        public int ProjectApprovalStatusID { get; private set; }
        public string ProjectApprovalStatusName { get; private set; }
        public string ProjectApprovalStatusDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectApprovalStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectApprovalStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectApprovalStatusID == ProjectApprovalStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectApprovalStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectApprovalStatusID;
        }

        public static bool operator ==(ProjectApprovalStatus left, ProjectApprovalStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectApprovalStatus left, ProjectApprovalStatus right)
        {
            return !Equals(left, right);
        }

        public ProjectApprovalStatusEnum ToEnum { get { return (ProjectApprovalStatusEnum)GetHashCode(); } }

        public static ProjectApprovalStatus ToType(int enumValue)
        {
            return ToType((ProjectApprovalStatusEnum)enumValue);
        }

        public static ProjectApprovalStatus ToType(ProjectApprovalStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectApprovalStatusEnum.Approved:
                    return Approved;
                case ProjectApprovalStatusEnum.Draft:
                    return Draft;
                case ProjectApprovalStatusEnum.PendingApproval:
                    return PendingApproval;
                case ProjectApprovalStatusEnum.Rejected:
                    return Rejected;
                case ProjectApprovalStatusEnum.Returned:
                    return Returned;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectApprovalStatusEnum
    {
        Draft = 1,
        PendingApproval = 2,
        Approved = 3,
        Rejected = 4,
        Returned = 5
    }

    public partial class ProjectApprovalStatusDraft : ProjectApprovalStatus
    {
        private ProjectApprovalStatusDraft(int projectApprovalStatusID, string projectApprovalStatusName, string projectApprovalStatusDisplayName) : base(projectApprovalStatusID, projectApprovalStatusName, projectApprovalStatusDisplayName) {}
        public static readonly ProjectApprovalStatusDraft Instance = new ProjectApprovalStatusDraft(1, @"Draft", @"Draft");
    }

    public partial class ProjectApprovalStatusPendingApproval : ProjectApprovalStatus
    {
        private ProjectApprovalStatusPendingApproval(int projectApprovalStatusID, string projectApprovalStatusName, string projectApprovalStatusDisplayName) : base(projectApprovalStatusID, projectApprovalStatusName, projectApprovalStatusDisplayName) {}
        public static readonly ProjectApprovalStatusPendingApproval Instance = new ProjectApprovalStatusPendingApproval(2, @"PendingApproval", @"Pending Approval");
    }

    public partial class ProjectApprovalStatusApproved : ProjectApprovalStatus
    {
        private ProjectApprovalStatusApproved(int projectApprovalStatusID, string projectApprovalStatusName, string projectApprovalStatusDisplayName) : base(projectApprovalStatusID, projectApprovalStatusName, projectApprovalStatusDisplayName) {}
        public static readonly ProjectApprovalStatusApproved Instance = new ProjectApprovalStatusApproved(3, @"Approved", @"Approved and Archived");
    }

    public partial class ProjectApprovalStatusRejected : ProjectApprovalStatus
    {
        private ProjectApprovalStatusRejected(int projectApprovalStatusID, string projectApprovalStatusName, string projectApprovalStatusDisplayName) : base(projectApprovalStatusID, projectApprovalStatusName, projectApprovalStatusDisplayName) {}
        public static readonly ProjectApprovalStatusRejected Instance = new ProjectApprovalStatusRejected(4, @"Rejected", @"Rejected");
    }

    public partial class ProjectApprovalStatusReturned : ProjectApprovalStatus
    {
        private ProjectApprovalStatusReturned(int projectApprovalStatusID, string projectApprovalStatusName, string projectApprovalStatusDisplayName) : base(projectApprovalStatusID, projectApprovalStatusName, projectApprovalStatusDisplayName) {}
        public static readonly ProjectApprovalStatusReturned Instance = new ProjectApprovalStatusReturned(5, @"Returned", @"Returned");
    }
}