//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomGridColumn]
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
    public abstract partial class ProjectCustomGridColumn : IHavePrimaryKey
    {
        public static readonly ProjectCustomGridColumnPerformanceMeasureCount PerformanceMeasureCount = ProjectCustomGridColumnPerformanceMeasureCount.Instance;
        public static readonly ProjectCustomGridColumnGeospatialAreaName GeospatialAreaName = ProjectCustomGridColumnGeospatialAreaName.Instance;
        public static readonly ProjectCustomGridColumnCustomAttribute CustomAttribute = ProjectCustomGridColumnCustomAttribute.Instance;

        public static readonly List<ProjectCustomGridColumn> All;
        public static readonly ReadOnlyDictionary<int, ProjectCustomGridColumn> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCustomGridColumn()
        {
            All = new List<ProjectCustomGridColumn> { PerformanceMeasureCount, GeospatialAreaName, CustomAttribute };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCustomGridColumn>(All.ToDictionary(x => x.ProjectCustomGridColumnID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCustomGridColumn(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName)
        {
            ProjectCustomGridColumnID = projectCustomGridColumnID;
            ProjectCustomGridColumnName = projectCustomGridColumnName;
            ProjectCustomGridColumnDisplayName = projectCustomGridColumnDisplayName;
        }

        [Key]
        public int ProjectCustomGridColumnID { get; private set; }
        public string ProjectCustomGridColumnName { get; private set; }
        public string ProjectCustomGridColumnDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomGridColumnID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCustomGridColumn other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCustomGridColumnID == ProjectCustomGridColumnID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCustomGridColumn);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCustomGridColumnID;
        }

        public static bool operator ==(ProjectCustomGridColumn left, ProjectCustomGridColumn right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCustomGridColumn left, ProjectCustomGridColumn right)
        {
            return !Equals(left, right);
        }

        public ProjectCustomGridColumnEnum ToEnum { get { return (ProjectCustomGridColumnEnum)GetHashCode(); } }

        public static ProjectCustomGridColumn ToType(int enumValue)
        {
            return ToType((ProjectCustomGridColumnEnum)enumValue);
        }

        public static ProjectCustomGridColumn ToType(ProjectCustomGridColumnEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCustomGridColumnEnum.CustomAttribute:
                    return CustomAttribute;
                case ProjectCustomGridColumnEnum.GeospatialAreaName:
                    return GeospatialAreaName;
                case ProjectCustomGridColumnEnum.PerformanceMeasureCount:
                    return PerformanceMeasureCount;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCustomGridColumnEnum
    {
        PerformanceMeasureCount = 1,
        GeospatialAreaName = 2,
        CustomAttribute = 3
    }

    public partial class ProjectCustomGridColumnPerformanceMeasureCount : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnPerformanceMeasureCount(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName) {}
        public static readonly ProjectCustomGridColumnPerformanceMeasureCount Instance = new ProjectCustomGridColumnPerformanceMeasureCount(1, @"PerformanceMeasureCount", @"Performance Measure Count");
    }

    public partial class ProjectCustomGridColumnGeospatialAreaName : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnGeospatialAreaName(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName) {}
        public static readonly ProjectCustomGridColumnGeospatialAreaName Instance = new ProjectCustomGridColumnGeospatialAreaName(2, @"GeospatialAreaName", @"Geospatial Area Name");
    }

    public partial class ProjectCustomGridColumnCustomAttribute : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnCustomAttribute(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName) {}
        public static readonly ProjectCustomGridColumnCustomAttribute Instance = new ProjectCustomGridColumnCustomAttribute(3, @"CustomAttribute", @"Custom Attribute");
    }
}