//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImageTiming]
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
    public abstract partial class ProjectImageTiming : IHavePrimaryKey
    {
        public static readonly ProjectImageTimingAfter After = ProjectImageTimingAfter.Instance;
        public static readonly ProjectImageTimingBefore Before = ProjectImageTimingBefore.Instance;
        public static readonly ProjectImageTimingDuring During = ProjectImageTimingDuring.Instance;
        public static readonly ProjectImageTimingUnknown Unknown = ProjectImageTimingUnknown.Instance;

        public static readonly List<ProjectImageTiming> All;
        public static readonly ReadOnlyDictionary<int, ProjectImageTiming> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectImageTiming()
        {
            All = new List<ProjectImageTiming> { After, Before, During, Unknown };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectImageTiming>(All.ToDictionary(x => x.ProjectImageTimingID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectImageTiming(int projectImageTimingID, string projectImageTimingName, string projectImageTimingDisplayName, int sortOrder)
        {
            ProjectImageTimingID = projectImageTimingID;
            ProjectImageTimingName = projectImageTimingName;
            ProjectImageTimingDisplayName = projectImageTimingDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int ProjectImageTimingID { get; private set; }
        public string ProjectImageTimingName { get; private set; }
        public string ProjectImageTimingDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public int PrimaryKey { get { return ProjectImageTimingID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectImageTiming other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectImageTimingID == ProjectImageTimingID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectImageTiming);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectImageTimingID;
        }

        public static bool operator ==(ProjectImageTiming left, ProjectImageTiming right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectImageTiming left, ProjectImageTiming right)
        {
            return !Equals(left, right);
        }

        public ProjectImageTimingEnum ToEnum { get { return (ProjectImageTimingEnum)GetHashCode(); } }

        public static ProjectImageTiming ToType(int enumValue)
        {
            return ToType((ProjectImageTimingEnum)enumValue);
        }

        public static ProjectImageTiming ToType(ProjectImageTimingEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectImageTimingEnum.After:
                    return After;
                case ProjectImageTimingEnum.Before:
                    return Before;
                case ProjectImageTimingEnum.During:
                    return During;
                case ProjectImageTimingEnum.Unknown:
                    return Unknown;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectImageTimingEnum
    {
        After = 1,
        Before = 2,
        During = 3,
        Unknown = 4
    }

    public partial class ProjectImageTimingAfter : ProjectImageTiming
    {
        private ProjectImageTimingAfter(int projectImageTimingID, string projectImageTimingName, string projectImageTimingDisplayName, int sortOrder) : base(projectImageTimingID, projectImageTimingName, projectImageTimingDisplayName, sortOrder) {}
        public static readonly ProjectImageTimingAfter Instance = new ProjectImageTimingAfter(1, @"After", @"After", 30);
    }

    public partial class ProjectImageTimingBefore : ProjectImageTiming
    {
        private ProjectImageTimingBefore(int projectImageTimingID, string projectImageTimingName, string projectImageTimingDisplayName, int sortOrder) : base(projectImageTimingID, projectImageTimingName, projectImageTimingDisplayName, sortOrder) {}
        public static readonly ProjectImageTimingBefore Instance = new ProjectImageTimingBefore(2, @"Before", @"Before", 10);
    }

    public partial class ProjectImageTimingDuring : ProjectImageTiming
    {
        private ProjectImageTimingDuring(int projectImageTimingID, string projectImageTimingName, string projectImageTimingDisplayName, int sortOrder) : base(projectImageTimingID, projectImageTimingName, projectImageTimingDisplayName, sortOrder) {}
        public static readonly ProjectImageTimingDuring Instance = new ProjectImageTimingDuring(3, @"During", @"During", 20);
    }

    public partial class ProjectImageTimingUnknown : ProjectImageTiming
    {
        private ProjectImageTimingUnknown(int projectImageTimingID, string projectImageTimingName, string projectImageTimingDisplayName, int sortOrder) : base(projectImageTimingID, projectImageTimingName, projectImageTimingDisplayName, sortOrder) {}
        public static readonly ProjectImageTimingUnknown Instance = new ProjectImageTimingUnknown(4, @"Unknown", @"Unknown", 40);
    }
}