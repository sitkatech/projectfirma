//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingType]
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
    public abstract partial class ProjectExemptReportingType : IHavePrimaryKey
    {
        public static readonly ProjectExemptReportingTypePerformanceMeasures PerformanceMeasures = ProjectExemptReportingTypePerformanceMeasures.Instance;

        public static readonly List<ProjectExemptReportingType> All;
        public static readonly ReadOnlyDictionary<int, ProjectExemptReportingType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectExemptReportingType()
        {
            All = new List<ProjectExemptReportingType> { PerformanceMeasures };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectExemptReportingType>(All.ToDictionary(x => x.ProjectExemptReportingTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectExemptReportingType(int projectExemptReportingTypeID, string projectExemptReportingTypeName, string projectExemptReportingTypeDisplayName)
        {
            ProjectExemptReportingTypeID = projectExemptReportingTypeID;
            ProjectExemptReportingTypeName = projectExemptReportingTypeName;
            ProjectExemptReportingTypeDisplayName = projectExemptReportingTypeDisplayName;
        }

        [Key]
        public int ProjectExemptReportingTypeID { get; private set; }
        public string ProjectExemptReportingTypeName { get; private set; }
        public string ProjectExemptReportingTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectExemptReportingTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectExemptReportingType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectExemptReportingTypeID == ProjectExemptReportingTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectExemptReportingType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectExemptReportingTypeID;
        }

        public static bool operator ==(ProjectExemptReportingType left, ProjectExemptReportingType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectExemptReportingType left, ProjectExemptReportingType right)
        {
            return !Equals(left, right);
        }

        public ProjectExemptReportingTypeEnum ToEnum { get { return (ProjectExemptReportingTypeEnum)GetHashCode(); } }

        public static ProjectExemptReportingType ToType(int enumValue)
        {
            return ToType((ProjectExemptReportingTypeEnum)enumValue);
        }

        public static ProjectExemptReportingType ToType(ProjectExemptReportingTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectExemptReportingTypeEnum.PerformanceMeasures:
                    return PerformanceMeasures;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectExemptReportingTypeEnum
    {
        PerformanceMeasures = 1
    }

    public partial class ProjectExemptReportingTypePerformanceMeasures : ProjectExemptReportingType
    {
        private ProjectExemptReportingTypePerformanceMeasures(int projectExemptReportingTypeID, string projectExemptReportingTypeName, string projectExemptReportingTypeDisplayName) : base(projectExemptReportingTypeID, projectExemptReportingTypeName, projectExemptReportingTypeDisplayName) {}
        public static readonly ProjectExemptReportingTypePerformanceMeasures Instance = new ProjectExemptReportingTypePerformanceMeasures(1, @"PerformanceMeasures", @"Performance Measures");
    }
}