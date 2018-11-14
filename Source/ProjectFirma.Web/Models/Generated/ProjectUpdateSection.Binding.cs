//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateSection]
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
    public abstract partial class ProjectUpdateSection : IHavePrimaryKey
    {
        public static readonly ProjectUpdateSectionInstructions Instructions = ProjectUpdateSectionInstructions.Instance;
        public static readonly ProjectUpdateSectionBasics Basics = ProjectUpdateSectionBasics.Instance;
        public static readonly ProjectUpdateSectionLocationSimple LocationSimple = ProjectUpdateSectionLocationSimple.Instance;
        public static readonly ProjectUpdateSectionLocationDetailed LocationDetailed = ProjectUpdateSectionLocationDetailed.Instance;
        public static readonly ProjectUpdateSectionGeospatialAreas GeospatialAreas = ProjectUpdateSectionGeospatialAreas.Instance;
        public static readonly ProjectUpdateSectionPerformanceMeasures PerformanceMeasures = ProjectUpdateSectionPerformanceMeasures.Instance;
        public static readonly ProjectUpdateSectionExpectedFunding ExpectedFunding = ProjectUpdateSectionExpectedFunding.Instance;
        public static readonly ProjectUpdateSectionExpenditures Expenditures = ProjectUpdateSectionExpenditures.Instance;
        public static readonly ProjectUpdateSectionPhotos Photos = ProjectUpdateSectionPhotos.Instance;
        public static readonly ProjectUpdateSectionExternalLinks ExternalLinks = ProjectUpdateSectionExternalLinks.Instance;
        public static readonly ProjectUpdateSectionNotesAndDocuments NotesAndDocuments = ProjectUpdateSectionNotesAndDocuments.Instance;
        public static readonly ProjectUpdateSectionOrganizations Organizations = ProjectUpdateSectionOrganizations.Instance;

        public static readonly List<ProjectUpdateSection> All;
        public static readonly ReadOnlyDictionary<int, ProjectUpdateSection> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectUpdateSection()
        {
            All = new List<ProjectUpdateSection> { Instructions, Basics, LocationSimple, LocationDetailed, GeospatialAreas, PerformanceMeasures, ExpectedFunding, Expenditures, Photos, ExternalLinks, NotesAndDocuments, Organizations };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectUpdateSection>(All.ToDictionary(x => x.ProjectUpdateSectionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectUpdateSection(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus)
        {
            ProjectUpdateSectionID = projectUpdateSectionID;
            ProjectUpdateSectionName = projectUpdateSectionName;
            ProjectUpdateSectionDisplayName = projectUpdateSectionDisplayName;
            SortOrder = sortOrder;
            HasCompletionStatus = hasCompletionStatus;
        }

        [Key]
        public int ProjectUpdateSectionID { get; private set; }
        public string ProjectUpdateSectionName { get; private set; }
        public string ProjectUpdateSectionDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public bool HasCompletionStatus { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateSectionID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectUpdateSection other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectUpdateSectionID == ProjectUpdateSectionID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectUpdateSection);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectUpdateSectionID;
        }

        public static bool operator ==(ProjectUpdateSection left, ProjectUpdateSection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectUpdateSection left, ProjectUpdateSection right)
        {
            return !Equals(left, right);
        }

        public ProjectUpdateSectionEnum ToEnum { get { return (ProjectUpdateSectionEnum)GetHashCode(); } }

        public static ProjectUpdateSection ToType(int enumValue)
        {
            return ToType((ProjectUpdateSectionEnum)enumValue);
        }

        public static ProjectUpdateSection ToType(ProjectUpdateSectionEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectUpdateSectionEnum.Basics:
                    return Basics;
                case ProjectUpdateSectionEnum.ExpectedFunding:
                    return ExpectedFunding;
                case ProjectUpdateSectionEnum.Expenditures:
                    return Expenditures;
                case ProjectUpdateSectionEnum.ExternalLinks:
                    return ExternalLinks;
                case ProjectUpdateSectionEnum.GeospatialAreas:
                    return GeospatialAreas;
                case ProjectUpdateSectionEnum.Instructions:
                    return Instructions;
                case ProjectUpdateSectionEnum.LocationDetailed:
                    return LocationDetailed;
                case ProjectUpdateSectionEnum.LocationSimple:
                    return LocationSimple;
                case ProjectUpdateSectionEnum.NotesAndDocuments:
                    return NotesAndDocuments;
                case ProjectUpdateSectionEnum.Organizations:
                    return Organizations;
                case ProjectUpdateSectionEnum.PerformanceMeasures:
                    return PerformanceMeasures;
                case ProjectUpdateSectionEnum.Photos:
                    return Photos;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectUpdateSectionEnum
    {
        Instructions = 1,
        Basics = 2,
        LocationSimple = 3,
        LocationDetailed = 4,
        GeospatialAreas = 5,
        PerformanceMeasures = 6,
        ExpectedFunding = 7,
        Expenditures = 8,
        Photos = 9,
        ExternalLinks = 10,
        NotesAndDocuments = 11,
        Organizations = 12
    }

    public partial class ProjectUpdateSectionInstructions : ProjectUpdateSection
    {
        private ProjectUpdateSectionInstructions(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionInstructions Instance = new ProjectUpdateSectionInstructions(1, @"Instructions", @"Instructions", 10, false);
    }

    public partial class ProjectUpdateSectionBasics : ProjectUpdateSection
    {
        private ProjectUpdateSectionBasics(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionBasics Instance = new ProjectUpdateSectionBasics(2, @"Basics", @"Basics", 20, true);
    }

    public partial class ProjectUpdateSectionLocationSimple : ProjectUpdateSection
    {
        private ProjectUpdateSectionLocationSimple(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionLocationSimple Instance = new ProjectUpdateSectionLocationSimple(3, @"LocationSimple", @"Location - Simple", 30, true);
    }

    public partial class ProjectUpdateSectionLocationDetailed : ProjectUpdateSection
    {
        private ProjectUpdateSectionLocationDetailed(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionLocationDetailed Instance = new ProjectUpdateSectionLocationDetailed(4, @"LocationDetailed", @"Location - Detailed", 40, false);
    }

    public partial class ProjectUpdateSectionGeospatialAreas : ProjectUpdateSection
    {
        private ProjectUpdateSectionGeospatialAreas(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionGeospatialAreas Instance = new ProjectUpdateSectionGeospatialAreas(5, @"GeospatialAreas", @"GeospatialArea", 50, true);
    }

    public partial class ProjectUpdateSectionPerformanceMeasures : ProjectUpdateSection
    {
        private ProjectUpdateSectionPerformanceMeasures(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionPerformanceMeasures Instance = new ProjectUpdateSectionPerformanceMeasures(6, @"PerformanceMeasures", @"Performance Measures", 60, true);
    }

    public partial class ProjectUpdateSectionExpectedFunding : ProjectUpdateSection
    {
        private ProjectUpdateSectionExpectedFunding(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionExpectedFunding Instance = new ProjectUpdateSectionExpectedFunding(7, @"ExpectedFunding", @"Expected Funding", 70, false);
    }

    public partial class ProjectUpdateSectionExpenditures : ProjectUpdateSection
    {
        private ProjectUpdateSectionExpenditures(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionExpenditures Instance = new ProjectUpdateSectionExpenditures(8, @"Expenditures", @"Expenditures", 80, true);
    }

    public partial class ProjectUpdateSectionPhotos : ProjectUpdateSection
    {
        private ProjectUpdateSectionPhotos(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionPhotos Instance = new ProjectUpdateSectionPhotos(9, @"Photos", @"Photos", 100, false);
    }

    public partial class ProjectUpdateSectionExternalLinks : ProjectUpdateSection
    {
        private ProjectUpdateSectionExternalLinks(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionExternalLinks Instance = new ProjectUpdateSectionExternalLinks(10, @"ExternalLinks", @"External Links", 125, false);
    }

    public partial class ProjectUpdateSectionNotesAndDocuments : ProjectUpdateSection
    {
        private ProjectUpdateSectionNotesAndDocuments(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionNotesAndDocuments Instance = new ProjectUpdateSectionNotesAndDocuments(11, @"NotesAndDocuments", @"Documents and Notes", 120, false);
    }

    public partial class ProjectUpdateSectionOrganizations : ProjectUpdateSection
    {
        private ProjectUpdateSectionOrganizations(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus) {}
        public static readonly ProjectUpdateSectionOrganizations Instance = new ProjectUpdateSectionOrganizations(12, @"Organizations", @"Organizations", 55, true);
    }
}