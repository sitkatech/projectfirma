//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStatus]
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
    public abstract partial class ProjectStatus : IHavePrimaryKey
    {
        public static readonly ProjectStatusGreen Green = ProjectStatusGreen.Instance;
        public static readonly ProjectStatusYellow Yellow = ProjectStatusYellow.Instance;
        public static readonly ProjectStatusRed Red = ProjectStatusRed.Instance;
        public static readonly ProjectStatusOnHold OnHold = ProjectStatusOnHold.Instance;

        public static readonly List<ProjectStatus> All;
        public static readonly ReadOnlyDictionary<int, ProjectStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectStatus()
        {
            All = new List<ProjectStatus> { Green, Yellow, Red, OnHold };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectStatus>(All.ToDictionary(x => x.ProjectStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectStatus(int projectStatusID, string projectStatusName, string projectStatusDisplayName, int projectStatusSortOrder, string projectStatusColor)
        {
            ProjectStatusID = projectStatusID;
            ProjectStatusName = projectStatusName;
            ProjectStatusDisplayName = projectStatusDisplayName;
            ProjectStatusSortOrder = projectStatusSortOrder;
            ProjectStatusColor = projectStatusColor;
        }

        [Key]
        public int ProjectStatusID { get; private set; }
        public string ProjectStatusName { get; private set; }
        public string ProjectStatusDisplayName { get; private set; }
        public int ProjectStatusSortOrder { get; private set; }
        public string ProjectStatusColor { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectStatusID == ProjectStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectStatusID;
        }

        public static bool operator ==(ProjectStatus left, ProjectStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectStatus left, ProjectStatus right)
        {
            return !Equals(left, right);
        }

        public ProjectStatusEnum ToEnum { get { return (ProjectStatusEnum)GetHashCode(); } }

        public static ProjectStatus ToType(int enumValue)
        {
            return ToType((ProjectStatusEnum)enumValue);
        }

        public static ProjectStatus ToType(ProjectStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectStatusEnum.Green:
                    return Green;
                case ProjectStatusEnum.OnHold:
                    return OnHold;
                case ProjectStatusEnum.Red:
                    return Red;
                case ProjectStatusEnum.Yellow:
                    return Yellow;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectStatusEnum
    {
        Green = 1,
        Yellow = 2,
        Red = 3,
        OnHold = 4
    }

    public partial class ProjectStatusGreen : ProjectStatus
    {
        private ProjectStatusGreen(int projectStatusID, string projectStatusName, string projectStatusDisplayName, int projectStatusSortOrder, string projectStatusColor) : base(projectStatusID, projectStatusName, projectStatusDisplayName, projectStatusSortOrder, projectStatusColor) {}
        public static readonly ProjectStatusGreen Instance = new ProjectStatusGreen(1, @"Green", @"Green", 5, @"#04AF70");
    }

    public partial class ProjectStatusYellow : ProjectStatus
    {
        private ProjectStatusYellow(int projectStatusID, string projectStatusName, string projectStatusDisplayName, int projectStatusSortOrder, string projectStatusColor) : base(projectStatusID, projectStatusName, projectStatusDisplayName, projectStatusSortOrder, projectStatusColor) {}
        public static readonly ProjectStatusYellow Instance = new ProjectStatusYellow(2, @"Yellow", @"Yellow", 20, @"#D0B001");
    }

    public partial class ProjectStatusRed : ProjectStatus
    {
        private ProjectStatusRed(int projectStatusID, string projectStatusName, string projectStatusDisplayName, int projectStatusSortOrder, string projectStatusColor) : base(projectStatusID, projectStatusName, projectStatusDisplayName, projectStatusSortOrder, projectStatusColor) {}
        public static readonly ProjectStatusRed Instance = new ProjectStatusRed(3, @"Red", @"Red", 30, @"#FF0000");
    }

    public partial class ProjectStatusOnHold : ProjectStatus
    {
        private ProjectStatusOnHold(int projectStatusID, string projectStatusName, string projectStatusDisplayName, int projectStatusSortOrder, string projectStatusColor) : base(projectStatusID, projectStatusName, projectStatusDisplayName, projectStatusSortOrder, projectStatusColor) {}
        public static readonly ProjectStatusOnHold Instance = new ProjectStatusOnHold(4, @"OnHold", @"On Hold", 50, @"#800080");
    }
}