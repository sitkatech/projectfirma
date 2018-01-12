//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCreateSection]
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
    public abstract partial class ProjectCreateSection : IHavePrimaryKey
    {
        public static readonly ProjectCreateSectionInstructions Instructions = ProjectCreateSectionInstructions.Instance;
        public static readonly ProjectCreateSectionProjectType ProjectType = ProjectCreateSectionProjectType.Instance;
        public static readonly ProjectCreateSectionBasics Basics = ProjectCreateSectionBasics.Instance;
        public static readonly ProjectCreateSectionLocationSimple LocationSimple = ProjectCreateSectionLocationSimple.Instance;
        public static readonly ProjectCreateSectionLocationDetailed LocationDetailed = ProjectCreateSectionLocationDetailed.Instance;
        public static readonly ProjectCreateSectionPerformanceMeasures PerformanceMeasures = ProjectCreateSectionPerformanceMeasures.Instance;
        public static readonly ProjectCreateSectionThresholdCategories ThresholdCategories = ProjectCreateSectionThresholdCategories.Instance;
        public static readonly ProjectCreateSectionTransportationAssessment TransportationAssessment = ProjectCreateSectionTransportationAssessment.Instance;
        public static readonly ProjectCreateSectionPhotos Photos = ProjectCreateSectionPhotos.Instance;
        public static readonly ProjectCreateSectionNotes Notes = ProjectCreateSectionNotes.Instance;
        public static readonly ProjectCreateSectionExpectedFunding ExpectedFunding = ProjectCreateSectionExpectedFunding.Instance;

        public static readonly List<ProjectCreateSection> All;
        public static readonly ReadOnlyDictionary<int, ProjectCreateSection> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCreateSection()
        {
            All = new List<ProjectCreateSection> { Instructions, ProjectType, Basics, LocationSimple, LocationDetailed, PerformanceMeasures, ThresholdCategories, TransportationAssessment, Photos, Notes, ExpectedFunding };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCreateSection>(All.ToDictionary(x => x.ProjectCreateSectionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCreateSection(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus)
        {
            ProjectCreateSectionID = projectCreateSectionID;
            ProjectCreateSectionName = projectCreateSectionName;
            ProjectCreateSectionDisplayName = projectCreateSectionDisplayName;
            SortOrder = sortOrder;
            HasCompletionStatus = hasCompletionStatus;
        }

        [Key]
        public int ProjectCreateSectionID { get; private set; }
        public string ProjectCreateSectionName { get; private set; }
        public string ProjectCreateSectionDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public bool HasCompletionStatus { get; private set; }
        public int PrimaryKey { get { return ProjectCreateSectionID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCreateSection other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCreateSectionID == ProjectCreateSectionID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCreateSection);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCreateSectionID;
        }

        public static bool operator ==(ProjectCreateSection left, ProjectCreateSection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCreateSection left, ProjectCreateSection right)
        {
            return !Equals(left, right);
        }

        public ProjectCreateSectionEnum ToEnum { get { return (ProjectCreateSectionEnum)GetHashCode(); } }

        public static ProjectCreateSection ToType(int enumValue)
        {
            return ToType((ProjectCreateSectionEnum)enumValue);
        }

        public static ProjectCreateSection ToType(ProjectCreateSectionEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCreateSectionEnum.Basics:
                    return Basics;
                case ProjectCreateSectionEnum.ExpectedFunding:
                    return ExpectedFunding;
                case ProjectCreateSectionEnum.Instructions:
                    return Instructions;
                case ProjectCreateSectionEnum.LocationDetailed:
                    return LocationDetailed;
                case ProjectCreateSectionEnum.LocationSimple:
                    return LocationSimple;
                case ProjectCreateSectionEnum.Notes:
                    return Notes;
                case ProjectCreateSectionEnum.PerformanceMeasures:
                    return PerformanceMeasures;
                case ProjectCreateSectionEnum.Photos:
                    return Photos;
                case ProjectCreateSectionEnum.ProjectType:
                    return ProjectType;
                case ProjectCreateSectionEnum.ThresholdCategories:
                    return ThresholdCategories;
                case ProjectCreateSectionEnum.TransportationAssessment:
                    return TransportationAssessment;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCreateSectionEnum
    {
        Instructions = 1,
        ProjectType = 2,
        Basics = 3,
        LocationSimple = 4,
        LocationDetailed = 5,
        PerformanceMeasures = 6,
        ThresholdCategories = 7,
        TransportationAssessment = 8,
        Photos = 9,
        Notes = 10,
        ExpectedFunding = 11
    }

    public partial class ProjectCreateSectionInstructions : ProjectCreateSection
    {
        private ProjectCreateSectionInstructions(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionInstructions Instance = new ProjectCreateSectionInstructions(1, @"Instructions", @"Instructions", 10, false);
    }

    public partial class ProjectCreateSectionProjectType : ProjectCreateSection
    {
        private ProjectCreateSectionProjectType(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionProjectType Instance = new ProjectCreateSectionProjectType(2, @"ProjectType", @"Project Type", 20, true);
    }

    public partial class ProjectCreateSectionBasics : ProjectCreateSection
    {
        private ProjectCreateSectionBasics(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionBasics Instance = new ProjectCreateSectionBasics(3, @"Basics", @"Basics", 30, true);
    }

    public partial class ProjectCreateSectionLocationSimple : ProjectCreateSection
    {
        private ProjectCreateSectionLocationSimple(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionLocationSimple Instance = new ProjectCreateSectionLocationSimple(4, @"LocationSimple", @"Location - Simple", 40, true);
    }

    public partial class ProjectCreateSectionLocationDetailed : ProjectCreateSection
    {
        private ProjectCreateSectionLocationDetailed(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionLocationDetailed Instance = new ProjectCreateSectionLocationDetailed(5, @"LocationDetailed", @"Location - Detailed", 50, true);
    }

    public partial class ProjectCreateSectionPerformanceMeasures : ProjectCreateSection
    {
        private ProjectCreateSectionPerformanceMeasures(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionPerformanceMeasures Instance = new ProjectCreateSectionPerformanceMeasures(6, @"PerformanceMeasures", @"Performance Measures", 60, true);
    }

    public partial class ProjectCreateSectionThresholdCategories : ProjectCreateSection
    {
        private ProjectCreateSectionThresholdCategories(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionThresholdCategories Instance = new ProjectCreateSectionThresholdCategories(7, @"ThresholdCategories", @"Threshold Categories", 70, true);
    }

    public partial class ProjectCreateSectionTransportationAssessment : ProjectCreateSection
    {
        private ProjectCreateSectionTransportationAssessment(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionTransportationAssessment Instance = new ProjectCreateSectionTransportationAssessment(8, @"TransportationAssessment", @"Transportation Assessment", 80, true);
    }

    public partial class ProjectCreateSectionPhotos : ProjectCreateSection
    {
        private ProjectCreateSectionPhotos(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionPhotos Instance = new ProjectCreateSectionPhotos(9, @"Photos", @"Photos", 90, false);
    }

    public partial class ProjectCreateSectionNotes : ProjectCreateSection
    {
        private ProjectCreateSectionNotes(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionNotes Instance = new ProjectCreateSectionNotes(10, @"Notes", @"Notes", 100, false);
    }

    public partial class ProjectCreateSectionExpectedFunding : ProjectCreateSection
    {
        private ProjectCreateSectionExpectedFunding(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectCreateSectionExpectedFunding Instance = new ProjectCreateSectionExpectedFunding(11, @"ExpectedFunding", @"Expected Funding", 55, false);
    }
}