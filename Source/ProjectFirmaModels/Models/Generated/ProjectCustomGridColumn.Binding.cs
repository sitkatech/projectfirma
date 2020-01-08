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
        public static readonly ProjectCustomGridColumnProjectName ProjectName = ProjectCustomGridColumnProjectName.Instance;
        public static readonly ProjectCustomGridColumnPrimaryContactOrganization PrimaryContactOrganization = ProjectCustomGridColumnPrimaryContactOrganization.Instance;
        public static readonly ProjectCustomGridColumnProjectStage ProjectStage = ProjectCustomGridColumnProjectStage.Instance;
        public static readonly ProjectCustomGridColumnNumberOfReportedPerformanceMeasures NumberOfReportedPerformanceMeasures = ProjectCustomGridColumnNumberOfReportedPerformanceMeasures.Instance;
        public static readonly ProjectCustomGridColumnProjectsStewardOrganizationRelationshipToProject ProjectsStewardOrganizationRelationshipToProject = ProjectCustomGridColumnProjectsStewardOrganizationRelationshipToProject.Instance;
        public static readonly ProjectCustomGridColumnProjectPrimaryContact ProjectPrimaryContact = ProjectCustomGridColumnProjectPrimaryContact.Instance;
        public static readonly ProjectCustomGridColumnProjectPrimaryContactEmail ProjectPrimaryContactEmail = ProjectCustomGridColumnProjectPrimaryContactEmail.Instance;
        public static readonly ProjectCustomGridColumnPlanningDesignStartYear PlanningDesignStartYear = ProjectCustomGridColumnPlanningDesignStartYear.Instance;
        public static readonly ProjectCustomGridColumnImplementationStartYear ImplementationStartYear = ProjectCustomGridColumnImplementationStartYear.Instance;
        public static readonly ProjectCustomGridColumnCompletionYear CompletionYear = ProjectCustomGridColumnCompletionYear.Instance;
        public static readonly ProjectCustomGridColumnPrimaryTaxonomyLeaf PrimaryTaxonomyLeaf = ProjectCustomGridColumnPrimaryTaxonomyLeaf.Instance;
        public static readonly ProjectCustomGridColumnSecondaryTaxonomyLeaf SecondaryTaxonomyLeaf = ProjectCustomGridColumnSecondaryTaxonomyLeaf.Instance;
        public static readonly ProjectCustomGridColumnNumberOfReportedExpenditures NumberOfReportedExpenditures = ProjectCustomGridColumnNumberOfReportedExpenditures.Instance;
        public static readonly ProjectCustomGridColumnFundingType FundingType = ProjectCustomGridColumnFundingType.Instance;
        public static readonly ProjectCustomGridColumnEstimatedTotalCost EstimatedTotalCost = ProjectCustomGridColumnEstimatedTotalCost.Instance;
        public static readonly ProjectCustomGridColumnSecuredFunding SecuredFunding = ProjectCustomGridColumnSecuredFunding.Instance;
        public static readonly ProjectCustomGridColumnTargetedFunding TargetedFunding = ProjectCustomGridColumnTargetedFunding.Instance;
        public static readonly ProjectCustomGridColumnNoFundingSourceIdentified NoFundingSourceIdentified = ProjectCustomGridColumnNoFundingSourceIdentified.Instance;
        public static readonly ProjectCustomGridColumnProjectDescription ProjectDescription = ProjectCustomGridColumnProjectDescription.Instance;
        public static readonly ProjectCustomGridColumnNumberOfPhotos NumberOfPhotos = ProjectCustomGridColumnNumberOfPhotos.Instance;
        public static readonly ProjectCustomGridColumnGeospatialAreaName GeospatialAreaName = ProjectCustomGridColumnGeospatialAreaName.Instance;
        public static readonly ProjectCustomGridColumnCustomAttribute CustomAttribute = ProjectCustomGridColumnCustomAttribute.Instance;
        public static readonly ProjectCustomGridColumnProjectID ProjectID = ProjectCustomGridColumnProjectID.Instance;
        public static readonly ProjectCustomGridColumnProjectLastUpdated ProjectLastUpdated = ProjectCustomGridColumnProjectLastUpdated.Instance;
        public static readonly ProjectCustomGridColumnProjectStatus ProjectStatus = ProjectCustomGridColumnProjectStatus.Instance;
        public static readonly ProjectCustomGridColumnFinalStatusUpdateStatus FinalStatusUpdateStatus = ProjectCustomGridColumnFinalStatusUpdateStatus.Instance;

        public static readonly List<ProjectCustomGridColumn> All;
        public static readonly ReadOnlyDictionary<int, ProjectCustomGridColumn> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCustomGridColumn()
        {
            All = new List<ProjectCustomGridColumn> { ProjectName, PrimaryContactOrganization, ProjectStage, NumberOfReportedPerformanceMeasures, ProjectsStewardOrganizationRelationshipToProject, ProjectPrimaryContact, ProjectPrimaryContactEmail, PlanningDesignStartYear, ImplementationStartYear, CompletionYear, PrimaryTaxonomyLeaf, SecondaryTaxonomyLeaf, NumberOfReportedExpenditures, FundingType, EstimatedTotalCost, SecuredFunding, TargetedFunding, NoFundingSourceIdentified, ProjectDescription, NumberOfPhotos, GeospatialAreaName, CustomAttribute, ProjectID, ProjectLastUpdated, ProjectStatus, FinalStatusUpdateStatus };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCustomGridColumn>(All.ToDictionary(x => x.ProjectCustomGridColumnID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCustomGridColumn(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional)
        {
            ProjectCustomGridColumnID = projectCustomGridColumnID;
            ProjectCustomGridColumnName = projectCustomGridColumnName;
            ProjectCustomGridColumnDisplayName = projectCustomGridColumnDisplayName;
            IsOptional = isOptional;
        }

        [Key]
        public int ProjectCustomGridColumnID { get; private set; }
        public string ProjectCustomGridColumnName { get; private set; }
        public string ProjectCustomGridColumnDisplayName { get; private set; }
        public bool IsOptional { get; private set; }
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
                case ProjectCustomGridColumnEnum.CompletionYear:
                    return CompletionYear;
                case ProjectCustomGridColumnEnum.CustomAttribute:
                    return CustomAttribute;
                case ProjectCustomGridColumnEnum.EstimatedTotalCost:
                    return EstimatedTotalCost;
                case ProjectCustomGridColumnEnum.FinalStatusUpdateStatus:
                    return FinalStatusUpdateStatus;
                case ProjectCustomGridColumnEnum.FundingType:
                    return FundingType;
                case ProjectCustomGridColumnEnum.GeospatialAreaName:
                    return GeospatialAreaName;
                case ProjectCustomGridColumnEnum.ImplementationStartYear:
                    return ImplementationStartYear;
                case ProjectCustomGridColumnEnum.NoFundingSourceIdentified:
                    return NoFundingSourceIdentified;
                case ProjectCustomGridColumnEnum.NumberOfPhotos:
                    return NumberOfPhotos;
                case ProjectCustomGridColumnEnum.NumberOfReportedExpenditures:
                    return NumberOfReportedExpenditures;
                case ProjectCustomGridColumnEnum.NumberOfReportedPerformanceMeasures:
                    return NumberOfReportedPerformanceMeasures;
                case ProjectCustomGridColumnEnum.PlanningDesignStartYear:
                    return PlanningDesignStartYear;
                case ProjectCustomGridColumnEnum.PrimaryContactOrganization:
                    return PrimaryContactOrganization;
                case ProjectCustomGridColumnEnum.PrimaryTaxonomyLeaf:
                    return PrimaryTaxonomyLeaf;
                case ProjectCustomGridColumnEnum.ProjectDescription:
                    return ProjectDescription;
                case ProjectCustomGridColumnEnum.ProjectID:
                    return ProjectID;
                case ProjectCustomGridColumnEnum.ProjectLastUpdated:
                    return ProjectLastUpdated;
                case ProjectCustomGridColumnEnum.ProjectName:
                    return ProjectName;
                case ProjectCustomGridColumnEnum.ProjectPrimaryContact:
                    return ProjectPrimaryContact;
                case ProjectCustomGridColumnEnum.ProjectPrimaryContactEmail:
                    return ProjectPrimaryContactEmail;
                case ProjectCustomGridColumnEnum.ProjectsStewardOrganizationRelationshipToProject:
                    return ProjectsStewardOrganizationRelationshipToProject;
                case ProjectCustomGridColumnEnum.ProjectStage:
                    return ProjectStage;
                case ProjectCustomGridColumnEnum.ProjectStatus:
                    return ProjectStatus;
                case ProjectCustomGridColumnEnum.SecondaryTaxonomyLeaf:
                    return SecondaryTaxonomyLeaf;
                case ProjectCustomGridColumnEnum.SecuredFunding:
                    return SecuredFunding;
                case ProjectCustomGridColumnEnum.TargetedFunding:
                    return TargetedFunding;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCustomGridColumnEnum
    {
        ProjectName = 1,
        PrimaryContactOrganization = 2,
        ProjectStage = 3,
        NumberOfReportedPerformanceMeasures = 4,
        ProjectsStewardOrganizationRelationshipToProject = 5,
        ProjectPrimaryContact = 6,
        ProjectPrimaryContactEmail = 7,
        PlanningDesignStartYear = 8,
        ImplementationStartYear = 9,
        CompletionYear = 10,
        PrimaryTaxonomyLeaf = 11,
        SecondaryTaxonomyLeaf = 12,
        NumberOfReportedExpenditures = 13,
        FundingType = 14,
        EstimatedTotalCost = 15,
        SecuredFunding = 16,
        TargetedFunding = 17,
        NoFundingSourceIdentified = 18,
        ProjectDescription = 19,
        NumberOfPhotos = 20,
        GeospatialAreaName = 21,
        CustomAttribute = 22,
        ProjectID = 23,
        ProjectLastUpdated = 24,
        ProjectStatus = 25,
        FinalStatusUpdateStatus = 26
    }

    public partial class ProjectCustomGridColumnProjectName : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectName(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectName Instance = new ProjectCustomGridColumnProjectName(1, @"ProjectName", @"Project Name", false);
    }

    public partial class ProjectCustomGridColumnPrimaryContactOrganization : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnPrimaryContactOrganization(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnPrimaryContactOrganization Instance = new ProjectCustomGridColumnPrimaryContactOrganization(2, @"PrimaryContactOrganization", @"Primary Contact Organization", false);
    }

    public partial class ProjectCustomGridColumnProjectStage : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectStage(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectStage Instance = new ProjectCustomGridColumnProjectStage(3, @"ProjectStage", @"Project Stage", false);
    }

    public partial class ProjectCustomGridColumnNumberOfReportedPerformanceMeasures : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnNumberOfReportedPerformanceMeasures(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnNumberOfReportedPerformanceMeasures Instance = new ProjectCustomGridColumnNumberOfReportedPerformanceMeasures(4, @"NumberOfReportedPerformanceMeasures", @"Number of Reported Performance Measures", true);
    }

    public partial class ProjectCustomGridColumnProjectsStewardOrganizationRelationshipToProject : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectsStewardOrganizationRelationshipToProject(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectsStewardOrganizationRelationshipToProject Instance = new ProjectCustomGridColumnProjectsStewardOrganizationRelationshipToProject(5, @"ProjectsStewardOrganizationRelationshipToProject", @"Projects Steward Organization Relationship To Project", true);
    }

    public partial class ProjectCustomGridColumnProjectPrimaryContact : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectPrimaryContact(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectPrimaryContact Instance = new ProjectCustomGridColumnProjectPrimaryContact(6, @"ProjectPrimaryContact", @"Project Primary Contact", true);
    }

    public partial class ProjectCustomGridColumnProjectPrimaryContactEmail : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectPrimaryContactEmail(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectPrimaryContactEmail Instance = new ProjectCustomGridColumnProjectPrimaryContactEmail(7, @"ProjectPrimaryContactEmail", @"Project Primary Contact Email", true);
    }

    public partial class ProjectCustomGridColumnPlanningDesignStartYear : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnPlanningDesignStartYear(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnPlanningDesignStartYear Instance = new ProjectCustomGridColumnPlanningDesignStartYear(8, @"PlanningDesignStartYear", @"Planning Design Start Year", true);
    }

    public partial class ProjectCustomGridColumnImplementationStartYear : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnImplementationStartYear(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnImplementationStartYear Instance = new ProjectCustomGridColumnImplementationStartYear(9, @"ImplementationStartYear", @"Implementation Start Year", true);
    }

    public partial class ProjectCustomGridColumnCompletionYear : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnCompletionYear(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnCompletionYear Instance = new ProjectCustomGridColumnCompletionYear(10, @"CompletionYear", @"Completion Year", true);
    }

    public partial class ProjectCustomGridColumnPrimaryTaxonomyLeaf : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnPrimaryTaxonomyLeaf(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnPrimaryTaxonomyLeaf Instance = new ProjectCustomGridColumnPrimaryTaxonomyLeaf(11, @"PrimaryTaxonomyLeaf", @"Primary Taxonomy Leaf", true);
    }

    public partial class ProjectCustomGridColumnSecondaryTaxonomyLeaf : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnSecondaryTaxonomyLeaf(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnSecondaryTaxonomyLeaf Instance = new ProjectCustomGridColumnSecondaryTaxonomyLeaf(12, @"SecondaryTaxonomyLeaf", @"Secondary Taxonomy Leaf", true);
    }

    public partial class ProjectCustomGridColumnNumberOfReportedExpenditures : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnNumberOfReportedExpenditures(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnNumberOfReportedExpenditures Instance = new ProjectCustomGridColumnNumberOfReportedExpenditures(13, @"NumberOfReportedExpenditures", @"Number of Reported Expenditures", true);
    }

    public partial class ProjectCustomGridColumnFundingType : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnFundingType(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnFundingType Instance = new ProjectCustomGridColumnFundingType(14, @"FundingType", @"Funding Type", true);
    }

    public partial class ProjectCustomGridColumnEstimatedTotalCost : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnEstimatedTotalCost(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnEstimatedTotalCost Instance = new ProjectCustomGridColumnEstimatedTotalCost(15, @"EstimatedTotalCost", @"Estimated Total Cost", true);
    }

    public partial class ProjectCustomGridColumnSecuredFunding : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnSecuredFunding(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnSecuredFunding Instance = new ProjectCustomGridColumnSecuredFunding(16, @"SecuredFunding", @"Secured Funding", true);
    }

    public partial class ProjectCustomGridColumnTargetedFunding : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnTargetedFunding(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnTargetedFunding Instance = new ProjectCustomGridColumnTargetedFunding(17, @"TargetedFunding", @"Targeted Funding", true);
    }

    public partial class ProjectCustomGridColumnNoFundingSourceIdentified : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnNoFundingSourceIdentified(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnNoFundingSourceIdentified Instance = new ProjectCustomGridColumnNoFundingSourceIdentified(18, @"NoFundingSourceIdentified", @"No Funding Source Identified", true);
    }

    public partial class ProjectCustomGridColumnProjectDescription : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectDescription(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectDescription Instance = new ProjectCustomGridColumnProjectDescription(19, @"ProjectDescription", @"Project Description", true);
    }

    public partial class ProjectCustomGridColumnNumberOfPhotos : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnNumberOfPhotos(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnNumberOfPhotos Instance = new ProjectCustomGridColumnNumberOfPhotos(20, @"NumberOfPhotos", @"Number of Photos", true);
    }

    public partial class ProjectCustomGridColumnGeospatialAreaName : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnGeospatialAreaName(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnGeospatialAreaName Instance = new ProjectCustomGridColumnGeospatialAreaName(21, @"GeospatialAreaName", @"Geospatial Area Name", true);
    }

    public partial class ProjectCustomGridColumnCustomAttribute : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnCustomAttribute(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnCustomAttribute Instance = new ProjectCustomGridColumnCustomAttribute(22, @"CustomAttribute", @"Custom Attribute", true);
    }

    public partial class ProjectCustomGridColumnProjectID : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectID(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectID Instance = new ProjectCustomGridColumnProjectID(23, @"ProjectID", @"ProjectID", true);
    }

    public partial class ProjectCustomGridColumnProjectLastUpdated : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectLastUpdated(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectLastUpdated Instance = new ProjectCustomGridColumnProjectLastUpdated(24, @"ProjectLastUpdated", @"Last Updated", true);
    }

    public partial class ProjectCustomGridColumnProjectStatus : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnProjectStatus(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnProjectStatus Instance = new ProjectCustomGridColumnProjectStatus(25, @"ProjectStatus", @"Status", true);
    }

    public partial class ProjectCustomGridColumnFinalStatusUpdateStatus : ProjectCustomGridColumn
    {
        private ProjectCustomGridColumnFinalStatusUpdateStatus(int projectCustomGridColumnID, string projectCustomGridColumnName, string projectCustomGridColumnDisplayName, bool isOptional) : base(projectCustomGridColumnID, projectCustomGridColumnName, projectCustomGridColumnDisplayName, isOptional) {}
        public static readonly ProjectCustomGridColumnFinalStatusUpdateStatus Instance = new ProjectCustomGridColumnFinalStatusUpdateStatus(26, @"FinalStatusUpdateStatus", @"Final Status Update", true);
    }
}