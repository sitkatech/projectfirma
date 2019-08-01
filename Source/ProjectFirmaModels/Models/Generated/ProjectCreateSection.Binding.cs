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
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class ProjectCreateSection : IHavePrimaryKey
    {
        public static readonly ProjectCreateSectionBasics Basics = ProjectCreateSectionBasics.Instance;
        public static readonly ProjectCreateSectionLocationSimple LocationSimple = ProjectCreateSectionLocationSimple.Instance;
        public static readonly ProjectCreateSectionOrganizations Organizations = ProjectCreateSectionOrganizations.Instance;
        public static readonly ProjectCreateSectionLocationDetailed LocationDetailed = ProjectCreateSectionLocationDetailed.Instance;
        public static readonly ProjectCreateSectionExpectedAccomplishments ExpectedAccomplishments = ProjectCreateSectionExpectedAccomplishments.Instance;
        public static readonly ProjectCreateSectionReportedAccomplishments ReportedAccomplishments = ProjectCreateSectionReportedAccomplishments.Instance;
        public static readonly ProjectCreateSectionBudget Budget = ProjectCreateSectionBudget.Instance;
        public static readonly ProjectCreateSectionReportedExpenditures ReportedExpenditures = ProjectCreateSectionReportedExpenditures.Instance;
        public static readonly ProjectCreateSectionClassifications Classifications = ProjectCreateSectionClassifications.Instance;
        public static readonly ProjectCreateSectionAssessment Assessment = ProjectCreateSectionAssessment.Instance;
        public static readonly ProjectCreateSectionPhotos Photos = ProjectCreateSectionPhotos.Instance;
        public static readonly ProjectCreateSectionNotesAndDocuments NotesAndDocuments = ProjectCreateSectionNotesAndDocuments.Instance;
        public static readonly ProjectCreateSectionContacts Contacts = ProjectCreateSectionContacts.Instance;

        public static readonly List<ProjectCreateSection> All;
        public static readonly ReadOnlyDictionary<int, ProjectCreateSection> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCreateSection()
        {
            All = new List<ProjectCreateSection> { Basics, LocationSimple, Organizations, LocationDetailed, ExpectedAccomplishments, ReportedAccomplishments, Budget, ReportedExpenditures, Classifications, Assessment, Photos, NotesAndDocuments, Contacts };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCreateSection>(All.ToDictionary(x => x.ProjectCreateSectionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCreateSection(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID)
        {
            ProjectCreateSectionID = projectCreateSectionID;
            ProjectCreateSectionName = projectCreateSectionName;
            ProjectCreateSectionDisplayName = projectCreateSectionDisplayName;
            SortOrder = sortOrder;
            HasCompletionStatus = hasCompletionStatus;
            ProjectWorkflowSectionGroupingID = projectWorkflowSectionGroupingID;
        }
        public ProjectWorkflowSectionGrouping ProjectWorkflowSectionGrouping { get { return ProjectWorkflowSectionGrouping.AllLookupDictionary[ProjectWorkflowSectionGroupingID]; } }
        [Key]
        public int ProjectCreateSectionID { get; private set; }
        public string ProjectCreateSectionName { get; private set; }
        public string ProjectCreateSectionDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public bool HasCompletionStatus { get; private set; }
        public int ProjectWorkflowSectionGroupingID { get; private set; }
        [NotMapped]
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
                case ProjectCreateSectionEnum.Assessment:
                    return Assessment;
                case ProjectCreateSectionEnum.Basics:
                    return Basics;
                case ProjectCreateSectionEnum.Budget:
                    return Budget;
                case ProjectCreateSectionEnum.Classifications:
                    return Classifications;
                case ProjectCreateSectionEnum.Contacts:
                    return Contacts;
                case ProjectCreateSectionEnum.ExpectedAccomplishments:
                    return ExpectedAccomplishments;
                case ProjectCreateSectionEnum.LocationDetailed:
                    return LocationDetailed;
                case ProjectCreateSectionEnum.LocationSimple:
                    return LocationSimple;
                case ProjectCreateSectionEnum.NotesAndDocuments:
                    return NotesAndDocuments;
                case ProjectCreateSectionEnum.Organizations:
                    return Organizations;
                case ProjectCreateSectionEnum.Photos:
                    return Photos;
                case ProjectCreateSectionEnum.ReportedAccomplishments:
                    return ReportedAccomplishments;
                case ProjectCreateSectionEnum.ReportedExpenditures:
                    return ReportedExpenditures;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCreateSectionEnum
    {
        Basics = 2,
        LocationSimple = 3,
        Organizations = 4,
        LocationDetailed = 5,
        ExpectedAccomplishments = 6,
        ReportedAccomplishments = 7,
        Budget = 8,
        ReportedExpenditures = 9,
        Classifications = 11,
        Assessment = 12,
        Photos = 13,
        NotesAndDocuments = 14,
        Contacts = 15
    }

    public partial class ProjectCreateSectionBasics : ProjectCreateSection
    {
        private ProjectCreateSectionBasics(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionBasics Instance = new ProjectCreateSectionBasics(2, @"Basics", @"Basics", 20, true, 1);
    }

    public partial class ProjectCreateSectionLocationSimple : ProjectCreateSection
    {
        private ProjectCreateSectionLocationSimple(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionLocationSimple Instance = new ProjectCreateSectionLocationSimple(3, @"LocationSimple", @"Simple Location", 30, true, 1);
    }

    public partial class ProjectCreateSectionOrganizations : ProjectCreateSection
    {
        private ProjectCreateSectionOrganizations(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionOrganizations Instance = new ProjectCreateSectionOrganizations(4, @"Organizations", @"Organizations", 40, true, 1);
    }

    public partial class ProjectCreateSectionLocationDetailed : ProjectCreateSection
    {
        private ProjectCreateSectionLocationDetailed(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionLocationDetailed Instance = new ProjectCreateSectionLocationDetailed(5, @"LocationDetailed", @"Detailed Location", 50, false, 2);
    }

    public partial class ProjectCreateSectionExpectedAccomplishments : ProjectCreateSection
    {
        private ProjectCreateSectionExpectedAccomplishments(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionExpectedAccomplishments Instance = new ProjectCreateSectionExpectedAccomplishments(6, @"ExpectedAccomplishments", @"Expected Accomplishments", 60, false, 3);
    }

    public partial class ProjectCreateSectionReportedAccomplishments : ProjectCreateSection
    {
        private ProjectCreateSectionReportedAccomplishments(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionReportedAccomplishments Instance = new ProjectCreateSectionReportedAccomplishments(7, @"ReportedAccomplishments", @"Reported Accomplishments", 70, true, 3);
    }

    public partial class ProjectCreateSectionBudget : ProjectCreateSection
    {
        private ProjectCreateSectionBudget(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionBudget Instance = new ProjectCreateSectionBudget(8, @"Budget", @"Budget", 80, false, 4);
    }

    public partial class ProjectCreateSectionReportedExpenditures : ProjectCreateSection
    {
        private ProjectCreateSectionReportedExpenditures(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionReportedExpenditures Instance = new ProjectCreateSectionReportedExpenditures(9, @"ReportedExpenditures", @"Reported Expenditures", 90, true, 4);
    }

    public partial class ProjectCreateSectionClassifications : ProjectCreateSection
    {
        private ProjectCreateSectionClassifications(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionClassifications Instance = new ProjectCreateSectionClassifications(11, @"Classifications", @"Classifications", 110, true, 5);
    }

    public partial class ProjectCreateSectionAssessment : ProjectCreateSection
    {
        private ProjectCreateSectionAssessment(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionAssessment Instance = new ProjectCreateSectionAssessment(12, @"Assessment", @"Asssessment", 120, true, 5);
    }

    public partial class ProjectCreateSectionPhotos : ProjectCreateSection
    {
        private ProjectCreateSectionPhotos(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionPhotos Instance = new ProjectCreateSectionPhotos(13, @"Photos", @"Photos", 130, false, 5);
    }

    public partial class ProjectCreateSectionNotesAndDocuments : ProjectCreateSection
    {
        private ProjectCreateSectionNotesAndDocuments(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionNotesAndDocuments Instance = new ProjectCreateSectionNotesAndDocuments(14, @"NotesAndDocuments", @"Documents and Notes", 140, false, 5);
    }

    public partial class ProjectCreateSectionContacts : ProjectCreateSection
    {
        private ProjectCreateSectionContacts(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionContacts Instance = new ProjectCreateSectionContacts(15, @"Contacts", @"Contacts", 45, true, 1);
    }
}