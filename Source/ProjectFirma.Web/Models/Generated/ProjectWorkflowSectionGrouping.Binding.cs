//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectWorkflowSectionGrouping]
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
    public abstract partial class ProjectWorkflowSectionGrouping : IHavePrimaryKey
    {
        public static readonly ProjectWorkflowSectionGroupingOverview Overview = ProjectWorkflowSectionGroupingOverview.Instance;
        public static readonly ProjectWorkflowSectionGroupingLocation Location = ProjectWorkflowSectionGroupingLocation.Instance;
        public static readonly ProjectWorkflowSectionGroupingPerformanceMeasures PerformanceMeasures = ProjectWorkflowSectionGroupingPerformanceMeasures.Instance;
        public static readonly ProjectWorkflowSectionGroupingExpenditures Expenditures = ProjectWorkflowSectionGroupingExpenditures.Instance;
        public static readonly ProjectWorkflowSectionGroupingAdditionalData AdditionalData = ProjectWorkflowSectionGroupingAdditionalData.Instance;

        public static readonly List<ProjectWorkflowSectionGrouping> All;
        public static readonly ReadOnlyDictionary<int, ProjectWorkflowSectionGrouping> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectWorkflowSectionGrouping()
        {
            All = new List<ProjectWorkflowSectionGrouping> { Overview, Location, PerformanceMeasures, Expenditures, AdditionalData };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectWorkflowSectionGrouping>(All.ToDictionary(x => x.ProjectWorkflowSectionGroupingID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectWorkflowSectionGrouping(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder)
        {
            ProjectWorkflowSectionGroupingID = projectWorkflowSectionGroupingID;
            ProjectWorkflowSectionGroupingName = projectWorkflowSectionGroupingName;
            ProjectWorkflowSectionGroupingDisplayName = projectWorkflowSectionGroupingDisplayName;
            SortOrder = sortOrder;
        }
        public List<ProjectCreateSection> ProjectCreateSections { get { return ProjectCreateSection.All.Where(x => x.ProjectWorkflowSectionGroupingID == ProjectWorkflowSectionGroupingID).ToList(); } }
        public List<ProjectUpdateSection> ProjectUpdateSections { get { return ProjectUpdateSection.All.Where(x => x.ProjectWorkflowSectionGroupingID == ProjectWorkflowSectionGroupingID).ToList(); } }
        [Key]
        public int ProjectWorkflowSectionGroupingID { get; private set; }
        public string ProjectWorkflowSectionGroupingName { get; private set; }
        public string ProjectWorkflowSectionGroupingDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectWorkflowSectionGroupingID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectWorkflowSectionGrouping other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectWorkflowSectionGroupingID == ProjectWorkflowSectionGroupingID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectWorkflowSectionGrouping);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectWorkflowSectionGroupingID;
        }

        public static bool operator ==(ProjectWorkflowSectionGrouping left, ProjectWorkflowSectionGrouping right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectWorkflowSectionGrouping left, ProjectWorkflowSectionGrouping right)
        {
            return !Equals(left, right);
        }

        public ProjectWorkflowSectionGroupingEnum ToEnum { get { return (ProjectWorkflowSectionGroupingEnum)GetHashCode(); } }

        public static ProjectWorkflowSectionGrouping ToType(int enumValue)
        {
            return ToType((ProjectWorkflowSectionGroupingEnum)enumValue);
        }

        public static ProjectWorkflowSectionGrouping ToType(ProjectWorkflowSectionGroupingEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectWorkflowSectionGroupingEnum.AdditionalData:
                    return AdditionalData;
                case ProjectWorkflowSectionGroupingEnum.Expenditures:
                    return Expenditures;
                case ProjectWorkflowSectionGroupingEnum.Location:
                    return Location;
                case ProjectWorkflowSectionGroupingEnum.Overview:
                    return Overview;
                case ProjectWorkflowSectionGroupingEnum.PerformanceMeasures:
                    return PerformanceMeasures;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectWorkflowSectionGroupingEnum
    {
        Overview = 1,
        Location = 2,
        PerformanceMeasures = 3,
        Expenditures = 4,
        AdditionalData = 5
    }

    public partial class ProjectWorkflowSectionGroupingOverview : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingOverview(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingOverview Instance = new ProjectWorkflowSectionGroupingOverview(1, @"Overview", @"Overview", 10);
    }

    public partial class ProjectWorkflowSectionGroupingLocation : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingLocation(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingLocation Instance = new ProjectWorkflowSectionGroupingLocation(2, @"Location", @"Location", 20);
    }

    public partial class ProjectWorkflowSectionGroupingPerformanceMeasures : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingPerformanceMeasures(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingPerformanceMeasures Instance = new ProjectWorkflowSectionGroupingPerformanceMeasures(3, @"PerformanceMeasures", @"Performance Measures", 30);
    }

    public partial class ProjectWorkflowSectionGroupingExpenditures : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingExpenditures(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingExpenditures Instance = new ProjectWorkflowSectionGroupingExpenditures(4, @"Expenditures", @"Expenditures", 40);
    }

    public partial class ProjectWorkflowSectionGroupingAdditionalData : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingAdditionalData(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingAdditionalData Instance = new ProjectWorkflowSectionGroupingAdditionalData(5, @"AdditionalData", @"Additional Data", 50);
    }
}