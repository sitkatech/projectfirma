//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectColorByType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class ProjectColorByType : IHavePrimaryKey
    {
        public static readonly ProjectColorByTypeFocusArea FocusArea = ProjectColorByTypeFocusArea.Instance;
        public static readonly ProjectColorByTypeProjectStage ProjectStage = ProjectColorByTypeProjectStage.Instance;

        public static readonly List<ProjectColorByType> All;
        public static readonly ReadOnlyDictionary<int, ProjectColorByType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectColorByType()
        {
            All = new List<ProjectColorByType> { FocusArea, ProjectStage };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectColorByType>(All.ToDictionary(x => x.ProjectColorByTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectColorByType(int projectColorByTypeID, string projectColorByTypeName, string projectColorByTypeNameWithIdentifier, string projectColorByTypeDisplayName, int sortOrder)
        {
            ProjectColorByTypeID = projectColorByTypeID;
            ProjectColorByTypeName = projectColorByTypeName;
            ProjectColorByTypeNameWithIdentifier = projectColorByTypeNameWithIdentifier;
            ProjectColorByTypeDisplayName = projectColorByTypeDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int ProjectColorByTypeID { get; private set; }
        public string ProjectColorByTypeName { get; private set; }
        public string ProjectColorByTypeNameWithIdentifier { get; private set; }
        public string ProjectColorByTypeDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public int PrimaryKey { get { return ProjectColorByTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectColorByType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectColorByTypeID == ProjectColorByTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectColorByType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectColorByTypeID;
        }

        public static bool operator ==(ProjectColorByType left, ProjectColorByType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectColorByType left, ProjectColorByType right)
        {
            return !Equals(left, right);
        }

        public ProjectColorByTypeEnum ToEnum { get { return (ProjectColorByTypeEnum)GetHashCode(); } }

        public static ProjectColorByType ToType(int enumValue)
        {
            return ToType((ProjectColorByTypeEnum)enumValue);
        }

        public static ProjectColorByType ToType(ProjectColorByTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectColorByTypeEnum.FocusArea:
                    return FocusArea;
                case ProjectColorByTypeEnum.ProjectStage:
                    return ProjectStage;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectColorByTypeEnum
    {
        FocusArea = 1,
        ProjectStage = 2
    }

    public partial class ProjectColorByTypeFocusArea : ProjectColorByType
    {
        private ProjectColorByTypeFocusArea(int projectColorByTypeID, string projectColorByTypeName, string projectColorByTypeNameWithIdentifier, string projectColorByTypeDisplayName, int sortOrder) : base(projectColorByTypeID, projectColorByTypeName, projectColorByTypeNameWithIdentifier, projectColorByTypeDisplayName, sortOrder) {}
        public static readonly ProjectColorByTypeFocusArea Instance = new ProjectColorByTypeFocusArea(1, @"FocusArea", @"FocusAreaID", @"Focus Area", 10);
    }

    public partial class ProjectColorByTypeProjectStage : ProjectColorByType
    {
        private ProjectColorByTypeProjectStage(int projectColorByTypeID, string projectColorByTypeName, string projectColorByTypeNameWithIdentifier, string projectColorByTypeDisplayName, int sortOrder) : base(projectColorByTypeID, projectColorByTypeName, projectColorByTypeNameWithIdentifier, projectColorByTypeDisplayName, sortOrder) {}
        public static readonly ProjectColorByTypeProjectStage Instance = new ProjectColorByTypeProjectStage(2, @"ProjectStage", @"ProjectStageID", @"Stage", 20);
    }
}