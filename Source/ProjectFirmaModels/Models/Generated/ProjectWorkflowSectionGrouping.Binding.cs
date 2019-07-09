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
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class ProjectWorkflowSectionGrouping : IHavePrimaryKey
    {
        public static readonly ProjectWorkflowSectionGroupingOverview Overview = ProjectWorkflowSectionGroupingOverview.Instance;
        public static readonly ProjectWorkflowSectionGroupingSpatialInformation SpatialInformation = ProjectWorkflowSectionGroupingSpatialInformation.Instance;
        public static readonly ProjectWorkflowSectionGroupingAccomplishments Accomplishments = ProjectWorkflowSectionGroupingAccomplishments.Instance;
        public static readonly ProjectWorkflowSectionGroupingFinancials Financials = ProjectWorkflowSectionGroupingFinancials.Instance;
        public static readonly ProjectWorkflowSectionGroupingAdditionalData AdditionalData = ProjectWorkflowSectionGroupingAdditionalData.Instance;

        public static readonly List<ProjectWorkflowSectionGrouping> All;
        public static readonly ReadOnlyDictionary<int, ProjectWorkflowSectionGrouping> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectWorkflowSectionGrouping()
        {
            All = new List<ProjectWorkflowSectionGrouping> { Overview, SpatialInformation, Accomplishments, Financials, AdditionalData };
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
                case ProjectWorkflowSectionGroupingEnum.Accomplishments:
                    return Accomplishments;
                case ProjectWorkflowSectionGroupingEnum.AdditionalData:
                    return AdditionalData;
                case ProjectWorkflowSectionGroupingEnum.Financials:
                    return Financials;
                case ProjectWorkflowSectionGroupingEnum.Overview:
                    return Overview;
                case ProjectWorkflowSectionGroupingEnum.SpatialInformation:
                    return SpatialInformation;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectWorkflowSectionGroupingEnum
    {
        Overview = 1,
        SpatialInformation = 2,
        Accomplishments = 3,
        Financials = 4,
        AdditionalData = 5
    }

    public partial class ProjectWorkflowSectionGroupingOverview : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingOverview(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingOverview Instance = new ProjectWorkflowSectionGroupingOverview(1, @"Overview", @"Overview", 10);
    }

    public partial class ProjectWorkflowSectionGroupingSpatialInformation : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingSpatialInformation(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingSpatialInformation Instance = new ProjectWorkflowSectionGroupingSpatialInformation(2, @"SpatialInformation", @"Spatial Information", 20);
    }

    public partial class ProjectWorkflowSectionGroupingAccomplishments : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingAccomplishments(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingAccomplishments Instance = new ProjectWorkflowSectionGroupingAccomplishments(3, @"Accomplishments", @"Accomplishments", 30);
    }

    public partial class ProjectWorkflowSectionGroupingFinancials : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingFinancials(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingFinancials Instance = new ProjectWorkflowSectionGroupingFinancials(4, @"Financials", @"Financials", 40);
    }

    public partial class ProjectWorkflowSectionGroupingAdditionalData : ProjectWorkflowSectionGrouping
    {
        private ProjectWorkflowSectionGroupingAdditionalData(int projectWorkflowSectionGroupingID, string projectWorkflowSectionGroupingName, string projectWorkflowSectionGroupingDisplayName, int sortOrder) : base(projectWorkflowSectionGroupingID, projectWorkflowSectionGroupingName, projectWorkflowSectionGroupingDisplayName, sortOrder) {}
        public static readonly ProjectWorkflowSectionGroupingAdditionalData Instance = new ProjectWorkflowSectionGroupingAdditionalData(5, @"AdditionalData", @"Additional Data", 50);
    }
}