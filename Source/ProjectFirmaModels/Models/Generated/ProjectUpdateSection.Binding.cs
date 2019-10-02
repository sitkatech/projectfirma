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
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class ProjectUpdateSection : IHavePrimaryKey
    {
        public static readonly ProjectUpdateSectionBasics Basics = ProjectUpdateSectionBasics.Instance;
        public static readonly ProjectUpdateSectionLocationSimple LocationSimple = ProjectUpdateSectionLocationSimple.Instance;
        public static readonly ProjectUpdateSectionOrganizations Organizations = ProjectUpdateSectionOrganizations.Instance;
        public static readonly ProjectUpdateSectionLocationDetailed LocationDetailed = ProjectUpdateSectionLocationDetailed.Instance;
        public static readonly ProjectUpdateSectionReportedAccomplishments ReportedAccomplishments = ProjectUpdateSectionReportedAccomplishments.Instance;
        public static readonly ProjectUpdateSectionBudget Budget = ProjectUpdateSectionBudget.Instance;
        public static readonly ProjectUpdateSectionExpenditures Expenditures = ProjectUpdateSectionExpenditures.Instance;
        public static readonly ProjectUpdateSectionPhotos Photos = ProjectUpdateSectionPhotos.Instance;
        public static readonly ProjectUpdateSectionExternalLinks ExternalLinks = ProjectUpdateSectionExternalLinks.Instance;
        public static readonly ProjectUpdateSectionExpectedAccomplishments ExpectedAccomplishments = ProjectUpdateSectionExpectedAccomplishments.Instance;
        public static readonly ProjectUpdateSectionTechnicalAssistanceRequests TechnicalAssistanceRequests = ProjectUpdateSectionTechnicalAssistanceRequests.Instance;
        public static readonly ProjectUpdateSectionContacts Contacts = ProjectUpdateSectionContacts.Instance;
        public static readonly ProjectUpdateSectionAttachmentsAndNotes AttachmentsAndNotes = ProjectUpdateSectionAttachmentsAndNotes.Instance;
        public static readonly ProjectUpdateSectionCustomAttributes CustomAttributes = ProjectUpdateSectionCustomAttributes.Instance;

        public static readonly List<ProjectUpdateSection> All;
        public static readonly ReadOnlyDictionary<int, ProjectUpdateSection> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectUpdateSection()
        {
            All = new List<ProjectUpdateSection> { Basics, LocationSimple, Organizations, LocationDetailed, ReportedAccomplishments, Budget, Expenditures, Photos, ExternalLinks, ExpectedAccomplishments, TechnicalAssistanceRequests, Contacts, AttachmentsAndNotes, CustomAttributes };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectUpdateSection>(All.ToDictionary(x => x.ProjectUpdateSectionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectUpdateSection(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID)
        {
            ProjectUpdateSectionID = projectUpdateSectionID;
            ProjectUpdateSectionName = projectUpdateSectionName;
            ProjectUpdateSectionDisplayName = projectUpdateSectionDisplayName;
            SortOrder = sortOrder;
            HasCompletionStatus = hasCompletionStatus;
            ProjectWorkflowSectionGroupingID = projectWorkflowSectionGroupingID;
        }
        public ProjectWorkflowSectionGrouping ProjectWorkflowSectionGrouping { get { return ProjectWorkflowSectionGrouping.AllLookupDictionary[ProjectWorkflowSectionGroupingID]; } }
        [Key]
        public int ProjectUpdateSectionID { get; private set; }
        public string ProjectUpdateSectionName { get; private set; }
        public string ProjectUpdateSectionDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public bool HasCompletionStatus { get; private set; }
        public int ProjectWorkflowSectionGroupingID { get; private set; }
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
                case ProjectUpdateSectionEnum.AttachmentsAndNotes:
                    return AttachmentsAndNotes;
                case ProjectUpdateSectionEnum.Basics:
                    return Basics;
                case ProjectUpdateSectionEnum.Budget:
                    return Budget;
                case ProjectUpdateSectionEnum.Contacts:
                    return Contacts;
                case ProjectUpdateSectionEnum.CustomAttributes:
                    return CustomAttributes;
                case ProjectUpdateSectionEnum.ExpectedAccomplishments:
                    return ExpectedAccomplishments;
                case ProjectUpdateSectionEnum.Expenditures:
                    return Expenditures;
                case ProjectUpdateSectionEnum.ExternalLinks:
                    return ExternalLinks;
                case ProjectUpdateSectionEnum.LocationDetailed:
                    return LocationDetailed;
                case ProjectUpdateSectionEnum.LocationSimple:
                    return LocationSimple;
                case ProjectUpdateSectionEnum.Organizations:
                    return Organizations;
                case ProjectUpdateSectionEnum.Photos:
                    return Photos;
                case ProjectUpdateSectionEnum.ReportedAccomplishments:
                    return ReportedAccomplishments;
                case ProjectUpdateSectionEnum.TechnicalAssistanceRequests:
                    return TechnicalAssistanceRequests;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectUpdateSectionEnum
    {
        Basics = 2,
        LocationSimple = 3,
        Organizations = 4,
        LocationDetailed = 5,
        ReportedAccomplishments = 6,
        Budget = 7,
        Expenditures = 8,
        Photos = 9,
        ExternalLinks = 10,
        ExpectedAccomplishments = 12,
        TechnicalAssistanceRequests = 13,
        Contacts = 14,
        AttachmentsAndNotes = 15,
        CustomAttributes = 16
    }

    public partial class ProjectUpdateSectionBasics : ProjectUpdateSection
    {
        private ProjectUpdateSectionBasics(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionBasics Instance = new ProjectUpdateSectionBasics(2, @"Basics", @"Basics", 20, true, 1);
    }

    public partial class ProjectUpdateSectionLocationSimple : ProjectUpdateSection
    {
        private ProjectUpdateSectionLocationSimple(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionLocationSimple Instance = new ProjectUpdateSectionLocationSimple(3, @"LocationSimple", @"Simple Location", 30, true, 1);
    }

    public partial class ProjectUpdateSectionOrganizations : ProjectUpdateSection
    {
        private ProjectUpdateSectionOrganizations(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionOrganizations Instance = new ProjectUpdateSectionOrganizations(4, @"Organizations", @"Organizations", 40, true, 1);
    }

    public partial class ProjectUpdateSectionLocationDetailed : ProjectUpdateSection
    {
        private ProjectUpdateSectionLocationDetailed(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionLocationDetailed Instance = new ProjectUpdateSectionLocationDetailed(5, @"LocationDetailed", @"Detailed Location", 60, false, 2);
    }

    public partial class ProjectUpdateSectionReportedAccomplishments : ProjectUpdateSection
    {
        private ProjectUpdateSectionReportedAccomplishments(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionReportedAccomplishments Instance = new ProjectUpdateSectionReportedAccomplishments(6, @"ReportedAccomplishments", @"Reported Accomplishments", 80, true, 3);
    }

    public partial class ProjectUpdateSectionBudget : ProjectUpdateSection
    {
        private ProjectUpdateSectionBudget(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionBudget Instance = new ProjectUpdateSectionBudget(7, @"Budget", @"Budget", 90, false, 4);
    }

    public partial class ProjectUpdateSectionExpenditures : ProjectUpdateSection
    {
        private ProjectUpdateSectionExpenditures(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionExpenditures Instance = new ProjectUpdateSectionExpenditures(8, @"Expenditures", @"Expenditures", 100, true, 4);
    }

    public partial class ProjectUpdateSectionPhotos : ProjectUpdateSection
    {
        private ProjectUpdateSectionPhotos(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionPhotos Instance = new ProjectUpdateSectionPhotos(9, @"Photos", @"Photos", 120, false, 5);
    }

    public partial class ProjectUpdateSectionExternalLinks : ProjectUpdateSection
    {
        private ProjectUpdateSectionExternalLinks(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionExternalLinks Instance = new ProjectUpdateSectionExternalLinks(10, @"ExternalLinks", @"External Links", 135, false, 5);
    }

    public partial class ProjectUpdateSectionExpectedAccomplishments : ProjectUpdateSection
    {
        private ProjectUpdateSectionExpectedAccomplishments(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionExpectedAccomplishments Instance = new ProjectUpdateSectionExpectedAccomplishments(12, @"ExpectedAccomplishments", @"Expected Accomplishments", 70, true, 3);
    }

    public partial class ProjectUpdateSectionTechnicalAssistanceRequests : ProjectUpdateSection
    {
        private ProjectUpdateSectionTechnicalAssistanceRequests(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionTechnicalAssistanceRequests Instance = new ProjectUpdateSectionTechnicalAssistanceRequests(13, @"TechnicalAssistanceRequests", @"Technical Assistance Requests", 110, false, 5);
    }

    public partial class ProjectUpdateSectionContacts : ProjectUpdateSection
    {
        private ProjectUpdateSectionContacts(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionContacts Instance = new ProjectUpdateSectionContacts(14, @"Contacts", @"Contacts", 50, true, 1);
    }

    public partial class ProjectUpdateSectionAttachmentsAndNotes : ProjectUpdateSection
    {
        private ProjectUpdateSectionAttachmentsAndNotes(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionAttachmentsAndNotes Instance = new ProjectUpdateSectionAttachmentsAndNotes(15, @"AttachmentsAndNotes", @"Attachments and Notes", 130, false, 5);
    }

    public partial class ProjectUpdateSectionCustomAttributes : ProjectUpdateSection
    {
        private ProjectUpdateSectionCustomAttributes(int projectUpdateSectionID, string projectUpdateSectionName, string projectUpdateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectUpdateSectionID, projectUpdateSectionName, projectUpdateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectUpdateSectionCustomAttributes Instance = new ProjectUpdateSectionCustomAttributes(16, @"CustomAttributes", @"Custom Attributes", 25, true, 1);
    }
}