//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectType]
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
    public abstract partial class ProjectType : IHavePrimaryKey
    {
        public static readonly ProjectTypeNormal Normal = ProjectTypeNormal.Instance;
        public static readonly ProjectTypeAdministrative Administrative = ProjectTypeAdministrative.Instance;

        public static readonly List<ProjectType> All;
        public static readonly ReadOnlyDictionary<int, ProjectType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectType()
        {
            All = new List<ProjectType> { Normal, Administrative };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectType>(All.ToDictionary(x => x.ProjectTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectType(int projectTypeID, string projectTypeName, string projectTypeDisplayName)
        {
            ProjectTypeID = projectTypeID;
            ProjectTypeName = projectTypeName;
            ProjectTypeDisplayName = projectTypeDisplayName;
        }

        [Key]
        public int ProjectTypeID { get; private set; }
        public string ProjectTypeName { get; private set; }
        public string ProjectTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectTypeID == ProjectTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectTypeID;
        }

        public static bool operator ==(ProjectType left, ProjectType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectType left, ProjectType right)
        {
            return !Equals(left, right);
        }

        public ProjectTypeEnum ToEnum { get { return (ProjectTypeEnum)GetHashCode(); } }

        public static ProjectType ToType(int enumValue)
        {
            return ToType((ProjectTypeEnum)enumValue);
        }

        public static ProjectType ToType(ProjectTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectTypeEnum.Administrative:
                    return Administrative;
                case ProjectTypeEnum.Normal:
                    return Normal;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectTypeEnum
    {
        Normal = 1,
        Administrative = 2
    }

    public partial class ProjectTypeNormal : ProjectType
    {
        private ProjectTypeNormal(int projectTypeID, string projectTypeName, string projectTypeDisplayName) : base(projectTypeID, projectTypeName, projectTypeDisplayName) {}
        public static readonly ProjectTypeNormal Instance = new ProjectTypeNormal(1, @"Normal", @"Normal");
    }

    public partial class ProjectTypeAdministrative : ProjectType
    {
        private ProjectTypeAdministrative(int projectTypeID, string projectTypeName, string projectTypeDisplayName) : base(projectTypeID, projectTypeName, projectTypeDisplayName) {}
        public static readonly ProjectTypeAdministrative Instance = new ProjectTypeAdministrative(2, @"Administrative", @"Administrative");
    }
}