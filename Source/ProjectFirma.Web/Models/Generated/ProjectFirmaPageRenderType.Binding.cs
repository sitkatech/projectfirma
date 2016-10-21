//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFirmaPageRenderType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public abstract partial class ProjectFirmaPageRenderType : IHavePrimaryKey
    {
        public static readonly ProjectFirmaPageRenderTypeIntroductoryText IntroductoryText = ProjectFirmaPageRenderTypeIntroductoryText.Instance;
        public static readonly ProjectFirmaPageRenderTypePageContent PageContent = ProjectFirmaPageRenderTypePageContent.Instance;

        public static readonly List<ProjectFirmaPageRenderType> All;
        public static readonly ReadOnlyDictionary<int, ProjectFirmaPageRenderType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectFirmaPageRenderType()
        {
            All = new List<ProjectFirmaPageRenderType> { IntroductoryText, PageContent };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectFirmaPageRenderType>(All.ToDictionary(x => x.ProjectFirmaPageRenderTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectFirmaPageRenderType(int projectFirmaPageRenderTypeID, string projectFirmaPageRenderTypeName, string projectFirmaPageRenderTypeDisplayName)
        {
            ProjectFirmaPageRenderTypeID = projectFirmaPageRenderTypeID;
            ProjectFirmaPageRenderTypeName = projectFirmaPageRenderTypeName;
            ProjectFirmaPageRenderTypeDisplayName = projectFirmaPageRenderTypeDisplayName;
        }
        public List<ProjectFirmaPageType> ProjectFirmaPageTypes { get { return ProjectFirmaPageType.All.Where(x => x.ProjectFirmaPageRenderTypeID == ProjectFirmaPageRenderTypeID).ToList(); } }
        [Key]
        public int ProjectFirmaPageRenderTypeID { get; private set; }
        public string ProjectFirmaPageRenderTypeName { get; private set; }
        public string ProjectFirmaPageRenderTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return ProjectFirmaPageRenderTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectFirmaPageRenderType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectFirmaPageRenderTypeID == ProjectFirmaPageRenderTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectFirmaPageRenderType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectFirmaPageRenderTypeID;
        }

        public static bool operator ==(ProjectFirmaPageRenderType left, ProjectFirmaPageRenderType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectFirmaPageRenderType left, ProjectFirmaPageRenderType right)
        {
            return !Equals(left, right);
        }

        public ProjectFirmaPageRenderTypeEnum ToEnum { get { return (ProjectFirmaPageRenderTypeEnum)GetHashCode(); } }

        public static ProjectFirmaPageRenderType ToType(int enumValue)
        {
            return ToType((ProjectFirmaPageRenderTypeEnum)enumValue);
        }

        public static ProjectFirmaPageRenderType ToType(ProjectFirmaPageRenderTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectFirmaPageRenderTypeEnum.IntroductoryText:
                    return IntroductoryText;
                case ProjectFirmaPageRenderTypeEnum.PageContent:
                    return PageContent;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectFirmaPageRenderTypeEnum
    {
        IntroductoryText = 1,
        PageContent = 2
    }

    public partial class ProjectFirmaPageRenderTypeIntroductoryText : ProjectFirmaPageRenderType
    {
        private ProjectFirmaPageRenderTypeIntroductoryText(int projectFirmaPageRenderTypeID, string projectFirmaPageRenderTypeName, string projectFirmaPageRenderTypeDisplayName) : base(projectFirmaPageRenderTypeID, projectFirmaPageRenderTypeName, projectFirmaPageRenderTypeDisplayName) {}
        public static readonly ProjectFirmaPageRenderTypeIntroductoryText Instance = new ProjectFirmaPageRenderTypeIntroductoryText(1, @"IntroductoryText", @"Introductory Text");
    }

    public partial class ProjectFirmaPageRenderTypePageContent : ProjectFirmaPageRenderType
    {
        private ProjectFirmaPageRenderTypePageContent(int projectFirmaPageRenderTypeID, string projectFirmaPageRenderTypeName, string projectFirmaPageRenderTypeDisplayName) : base(projectFirmaPageRenderTypeID, projectFirmaPageRenderTypeName, projectFirmaPageRenderTypeDisplayName) {}
        public static readonly ProjectFirmaPageRenderTypePageContent Instance = new ProjectFirmaPageRenderTypePageContent(2, @"PageContent", @"Page Content");
    }
}