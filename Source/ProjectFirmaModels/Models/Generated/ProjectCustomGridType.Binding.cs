//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomGridType]
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
    public abstract partial class ProjectCustomGridType : IHavePrimaryKey
    {
        public static readonly ProjectCustomGridTypeDefault Default = ProjectCustomGridTypeDefault.Instance;
        public static readonly ProjectCustomGridTypeFull Full = ProjectCustomGridTypeFull.Instance;

        public static readonly List<ProjectCustomGridType> All;
        public static readonly ReadOnlyDictionary<int, ProjectCustomGridType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCustomGridType()
        {
            All = new List<ProjectCustomGridType> { Default, Full };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCustomGridType>(All.ToDictionary(x => x.ProjectCustomGridTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCustomGridType(int projectCustomGridTypeID, string projectCustomGridTypeName, string projectCustomGridTypeDisplayName)
        {
            ProjectCustomGridTypeID = projectCustomGridTypeID;
            ProjectCustomGridTypeName = projectCustomGridTypeName;
            ProjectCustomGridTypeDisplayName = projectCustomGridTypeDisplayName;
        }

        [Key]
        public int ProjectCustomGridTypeID { get; private set; }
        public string ProjectCustomGridTypeName { get; private set; }
        public string ProjectCustomGridTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomGridTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCustomGridType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCustomGridTypeID == ProjectCustomGridTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCustomGridType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCustomGridTypeID;
        }

        public static bool operator ==(ProjectCustomGridType left, ProjectCustomGridType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCustomGridType left, ProjectCustomGridType right)
        {
            return !Equals(left, right);
        }

        public ProjectCustomGridTypeEnum ToEnum { get { return (ProjectCustomGridTypeEnum)GetHashCode(); } }

        public static ProjectCustomGridType ToType(int enumValue)
        {
            return ToType((ProjectCustomGridTypeEnum)enumValue);
        }

        public static ProjectCustomGridType ToType(ProjectCustomGridTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCustomGridTypeEnum.Default:
                    return Default;
                case ProjectCustomGridTypeEnum.Full:
                    return Full;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCustomGridTypeEnum
    {
        Default = 1,
        Full = 2
    }

    public partial class ProjectCustomGridTypeDefault : ProjectCustomGridType
    {
        private ProjectCustomGridTypeDefault(int projectCustomGridTypeID, string projectCustomGridTypeName, string projectCustomGridTypeDisplayName) : base(projectCustomGridTypeID, projectCustomGridTypeName, projectCustomGridTypeDisplayName) {}
        public static readonly ProjectCustomGridTypeDefault Instance = new ProjectCustomGridTypeDefault(1, @"Default", @"Default");
    }

    public partial class ProjectCustomGridTypeFull : ProjectCustomGridType
    {
        private ProjectCustomGridTypeFull(int projectCustomGridTypeID, string projectCustomGridTypeName, string projectCustomGridTypeDisplayName) : base(projectCustomGridTypeID, projectCustomGridTypeName, projectCustomGridTypeDisplayName) {}
        public static readonly ProjectCustomGridTypeFull Instance = new ProjectCustomGridTypeFull(2, @"Full", @"Full");
    }
}