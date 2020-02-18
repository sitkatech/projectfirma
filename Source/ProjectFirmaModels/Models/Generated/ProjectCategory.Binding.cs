//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCategory]
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
    public abstract partial class ProjectCategory : IHavePrimaryKey
    {
        public static readonly ProjectCategoryNormal Normal = ProjectCategoryNormal.Instance;
        public static readonly ProjectCategoryAdministrative Administrative = ProjectCategoryAdministrative.Instance;

        public static readonly List<ProjectCategory> All;
        public static readonly ReadOnlyDictionary<int, ProjectCategory> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCategory()
        {
            All = new List<ProjectCategory> { Normal, Administrative };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCategory>(All.ToDictionary(x => x.ProjectCategoryID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCategory(int projectCategoryID, string projectCategoryName, string projectCategoryDisplayName)
        {
            ProjectCategoryID = projectCategoryID;
            ProjectCategoryName = projectCategoryName;
            ProjectCategoryDisplayName = projectCategoryDisplayName;
        }

        [Key]
        public int ProjectCategoryID { get; private set; }
        public string ProjectCategoryName { get; private set; }
        public string ProjectCategoryDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCategoryID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCategory other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCategoryID == ProjectCategoryID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCategory);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCategoryID;
        }

        public static bool operator ==(ProjectCategory left, ProjectCategory right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCategory left, ProjectCategory right)
        {
            return !Equals(left, right);
        }

        public ProjectCategoryEnum ToEnum { get { return (ProjectCategoryEnum)GetHashCode(); } }

        public static ProjectCategory ToType(int enumValue)
        {
            return ToType((ProjectCategoryEnum)enumValue);
        }

        public static ProjectCategory ToType(ProjectCategoryEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCategoryEnum.Administrative:
                    return Administrative;
                case ProjectCategoryEnum.Normal:
                    return Normal;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCategoryEnum
    {
        Normal = 1,
        Administrative = 2
    }

    public partial class ProjectCategoryNormal : ProjectCategory
    {
        private ProjectCategoryNormal(int projectCategoryID, string projectCategoryName, string projectCategoryDisplayName) : base(projectCategoryID, projectCategoryName, projectCategoryDisplayName) {}
        public static readonly ProjectCategoryNormal Instance = new ProjectCategoryNormal(1, @"Normal", @"Normal");
    }

    public partial class ProjectCategoryAdministrative : ProjectCategory
    {
        private ProjectCategoryAdministrative(int projectCategoryID, string projectCategoryName, string projectCategoryDisplayName) : base(projectCategoryID, projectCategoryName, projectCategoryDisplayName) {}
        public static readonly ProjectCategoryAdministrative Instance = new ProjectCategoryAdministrative(2, @"Administrative", @"Administrative");
    }
}