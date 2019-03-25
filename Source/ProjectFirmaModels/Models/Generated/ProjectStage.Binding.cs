//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStage]
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
    public abstract partial class ProjectStage : IHavePrimaryKey
    {
        public static readonly ProjectStageProposal Proposal = ProjectStageProposal.Instance;
        public static readonly ProjectStagePlanningDesign PlanningDesign = ProjectStagePlanningDesign.Instance;
        public static readonly ProjectStageImplementation Implementation = ProjectStageImplementation.Instance;
        public static readonly ProjectStageCompleted Completed = ProjectStageCompleted.Instance;
        public static readonly ProjectStageTerminated Terminated = ProjectStageTerminated.Instance;
        public static readonly ProjectStageDeferred Deferred = ProjectStageDeferred.Instance;
        public static readonly ProjectStagePostImplementation PostImplementation = ProjectStagePostImplementation.Instance;

        public static readonly List<ProjectStage> All;
        public static readonly ReadOnlyDictionary<int, ProjectStage> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectStage()
        {
            All = new List<ProjectStage> { Proposal, PlanningDesign, Implementation, Completed, Terminated, Deferred, PostImplementation };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectStage>(All.ToDictionary(x => x.ProjectStageID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectStage(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor)
        {
            ProjectStageID = projectStageID;
            ProjectStageName = projectStageName;
            ProjectStageDisplayName = projectStageDisplayName;
            SortOrder = sortOrder;
            ProjectStageColor = projectStageColor;
        }

        [Key]
        public int ProjectStageID { get; private set; }
        public string ProjectStageName { get; private set; }
        public string ProjectStageDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public string ProjectStageColor { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectStageID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectStage other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectStageID == ProjectStageID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectStage);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectStageID;
        }

        public static bool operator ==(ProjectStage left, ProjectStage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectStage left, ProjectStage right)
        {
            return !Equals(left, right);
        }

        public ProjectStageEnum ToEnum { get { return (ProjectStageEnum)GetHashCode(); } }

        public static ProjectStage ToType(int enumValue)
        {
            return ToType((ProjectStageEnum)enumValue);
        }

        public static ProjectStage ToType(ProjectStageEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectStageEnum.Completed:
                    return Completed;
                case ProjectStageEnum.Deferred:
                    return Deferred;
                case ProjectStageEnum.Implementation:
                    return Implementation;
                case ProjectStageEnum.PlanningDesign:
                    return PlanningDesign;
                case ProjectStageEnum.PostImplementation:
                    return PostImplementation;
                case ProjectStageEnum.Proposal:
                    return Proposal;
                case ProjectStageEnum.Terminated:
                    return Terminated;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectStageEnum
    {
        Proposal = 1,
        PlanningDesign = 2,
        Implementation = 3,
        Completed = 4,
        Terminated = 5,
        Deferred = 6,
        PostImplementation = 8
    }

    public partial class ProjectStageProposal : ProjectStage
    {
        private ProjectStageProposal(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName, sortOrder, projectStageColor) {}
        public static readonly ProjectStageProposal Instance = new ProjectStageProposal(1, @"Proposal", @"Proposal", 5, @"#dbbdff");
    }

    public partial class ProjectStagePlanningDesign : ProjectStage
    {
        private ProjectStagePlanningDesign(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName, sortOrder, projectStageColor) {}
        public static readonly ProjectStagePlanningDesign Instance = new ProjectStagePlanningDesign(2, @"PlanningDesign", @"Planning/Design", 20, @"#80B2FF");
    }

    public partial class ProjectStageImplementation : ProjectStage
    {
        private ProjectStageImplementation(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName, sortOrder, projectStageColor) {}
        public static readonly ProjectStageImplementation Instance = new ProjectStageImplementation(3, @"Implementation", @"Implementation", 30, @"#1975FF");
    }

    public partial class ProjectStageCompleted : ProjectStage
    {
        private ProjectStageCompleted(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName, sortOrder, projectStageColor) {}
        public static readonly ProjectStageCompleted Instance = new ProjectStageCompleted(4, @"Completed", @"Completed", 50, @"#000066");
    }

    public partial class ProjectStageTerminated : ProjectStage
    {
        private ProjectStageTerminated(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName, sortOrder, projectStageColor) {}
        public static readonly ProjectStageTerminated Instance = new ProjectStageTerminated(5, @"Terminated", @"Terminated", 25, @"#D6D6D6");
    }

    public partial class ProjectStageDeferred : ProjectStage
    {
        private ProjectStageDeferred(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName, sortOrder, projectStageColor) {}
        public static readonly ProjectStageDeferred Instance = new ProjectStageDeferred(6, @"Deferred", @"Deferred", 10, @"#FFE6CC");
    }

    public partial class ProjectStagePostImplementation : ProjectStage
    {
        private ProjectStagePostImplementation(int projectStageID, string projectStageName, string projectStageDisplayName, int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName, sortOrder, projectStageColor) {}
        public static readonly ProjectStagePostImplementation Instance = new ProjectStagePostImplementation(8, @"PostImplementation", @"Post-Implementation", 40, @"#0047B2");
    }
}