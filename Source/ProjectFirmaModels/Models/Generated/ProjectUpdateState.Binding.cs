//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateState]
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
    public abstract partial class ProjectUpdateState : IHavePrimaryKey
    {
        public static readonly ProjectUpdateStateCreated Created = ProjectUpdateStateCreated.Instance;
        public static readonly ProjectUpdateStateSubmitted Submitted = ProjectUpdateStateSubmitted.Instance;
        public static readonly ProjectUpdateStateReturned Returned = ProjectUpdateStateReturned.Instance;
        public static readonly ProjectUpdateStateApproved Approved = ProjectUpdateStateApproved.Instance;

        public static readonly List<ProjectUpdateState> All;
        public static readonly ReadOnlyDictionary<int, ProjectUpdateState> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectUpdateState()
        {
            All = new List<ProjectUpdateState> { Created, Submitted, Returned, Approved };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectUpdateState>(All.ToDictionary(x => x.ProjectUpdateStateID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectUpdateState(int projectUpdateStateID, string projectUpdateStateName, string projectUpdateStateDisplayName)
        {
            ProjectUpdateStateID = projectUpdateStateID;
            ProjectUpdateStateName = projectUpdateStateName;
            ProjectUpdateStateDisplayName = projectUpdateStateDisplayName;
        }

        [Key]
        public int ProjectUpdateStateID { get; private set; }
        public string ProjectUpdateStateName { get; private set; }
        public string ProjectUpdateStateDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateStateID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectUpdateState other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectUpdateStateID == ProjectUpdateStateID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectUpdateState);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectUpdateStateID;
        }

        public static bool operator ==(ProjectUpdateState left, ProjectUpdateState right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectUpdateState left, ProjectUpdateState right)
        {
            return !Equals(left, right);
        }

        public ProjectUpdateStateEnum ToEnum { get { return (ProjectUpdateStateEnum)GetHashCode(); } }

        public static ProjectUpdateState ToType(int enumValue)
        {
            return ToType((ProjectUpdateStateEnum)enumValue);
        }

        public static ProjectUpdateState ToType(ProjectUpdateStateEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectUpdateStateEnum.Approved:
                    return Approved;
                case ProjectUpdateStateEnum.Created:
                    return Created;
                case ProjectUpdateStateEnum.Returned:
                    return Returned;
                case ProjectUpdateStateEnum.Submitted:
                    return Submitted;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectUpdateStateEnum
    {
        Created = 1,
        Submitted = 2,
        Returned = 3,
        Approved = 4
    }

    public partial class ProjectUpdateStateCreated : ProjectUpdateState
    {
        private ProjectUpdateStateCreated(int projectUpdateStateID, string projectUpdateStateName, string projectUpdateStateDisplayName) : base(projectUpdateStateID, projectUpdateStateName, projectUpdateStateDisplayName) {}
        public static readonly ProjectUpdateStateCreated Instance = new ProjectUpdateStateCreated(1, @"Created", @"Created");
    }

    public partial class ProjectUpdateStateSubmitted : ProjectUpdateState
    {
        private ProjectUpdateStateSubmitted(int projectUpdateStateID, string projectUpdateStateName, string projectUpdateStateDisplayName) : base(projectUpdateStateID, projectUpdateStateName, projectUpdateStateDisplayName) {}
        public static readonly ProjectUpdateStateSubmitted Instance = new ProjectUpdateStateSubmitted(2, @"Submitted", @"Submitted");
    }

    public partial class ProjectUpdateStateReturned : ProjectUpdateState
    {
        private ProjectUpdateStateReturned(int projectUpdateStateID, string projectUpdateStateName, string projectUpdateStateDisplayName) : base(projectUpdateStateID, projectUpdateStateName, projectUpdateStateDisplayName) {}
        public static readonly ProjectUpdateStateReturned Instance = new ProjectUpdateStateReturned(3, @"Returned", @"Returned");
    }

    public partial class ProjectUpdateStateApproved : ProjectUpdateState
    {
        private ProjectUpdateStateApproved(int projectUpdateStateID, string projectUpdateStateName, string projectUpdateStateDisplayName) : base(projectUpdateStateID, projectUpdateStateName, projectUpdateStateDisplayName) {}
        public static readonly ProjectUpdateStateApproved Instance = new ProjectUpdateStateApproved(4, @"Approved", @"Approved");
    }
}