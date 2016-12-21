//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Project]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[Project]")]
    public partial class Project : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Project()
        {
            this.NotificationProjects = new HashSet<NotificationProject>();
            this.PerformanceMeasureActuals = new HashSet<PerformanceMeasureActual>();
            this.PerformanceMeasureExpecteds = new HashSet<PerformanceMeasureExpected>();
            this.ProjectAssessmentQuestions = new HashSet<ProjectAssessmentQuestion>();
            this.ProjectBudgets = new HashSet<ProjectBudget>();
            this.ProjectExemptReportingYears = new HashSet<ProjectExemptReportingYear>();
            this.ProjectExternalLinks = new HashSet<ProjectExternalLink>();
            this.ProjectFundingOrganizations = new HashSet<ProjectFundingOrganization>();
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectImages = new HashSet<ProjectImage>();
            this.ProjectImplementingOrganizations = new HashSet<ProjectImplementingOrganization>();
            this.ProjectLocations = new HashSet<ProjectLocation>();
            this.ProjectLocationStagings = new HashSet<ProjectLocationStaging>();
            this.ProjectNotes = new HashSet<ProjectNote>();
            this.ProjectTags = new HashSet<ProjectTag>();
            this.ProjectThresholdCategories = new HashSet<ProjectThresholdCategory>();
            this.ProjectUpdateBatches = new HashSet<ProjectUpdateBatch>();
            this.ProjectWatersheds = new HashSet<ProjectWatershed>();
            this.ProposedProjects = new HashSet<ProposedProject>();
            this.SnapshotProjects = new HashSet<SnapshotProject>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int projectID, int actionPriorityID, int projectStageID, short projectNumber, string projectName, string projectDescription, int? implementationStartYear, int? completionYear, decimal? estimatedTotalCost, bool implementsMultipleProjects, decimal? securedFunding, DbGeometry projectLocationPoint, int? projectLocationAreaID, string performanceMeasureActualYearsExemptionExplanation, bool isFeatured, string projectLocationNotes, int? planningDesignStartYear, int projectLocationSimpleTypeID, decimal? estimatedAnnualOperatingCost, int fundingTypeID) : this()
        {
            this.ProjectID = projectID;
            this.ActionPriorityID = actionPriorityID;
            this.ProjectStageID = projectStageID;
            this.ProjectNumber = projectNumber;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.EstimatedTotalCost = estimatedTotalCost;
            this.ImplementsMultipleProjects = implementsMultipleProjects;
            this.SecuredFunding = securedFunding;
            this.ProjectLocationPoint = projectLocationPoint;
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.PerformanceMeasureActualYearsExemptionExplanation = performanceMeasureActualYearsExemptionExplanation;
            this.IsFeatured = isFeatured;
            this.ProjectLocationNotes = projectLocationNotes;
            this.PlanningDesignStartYear = planningDesignStartYear;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.EstimatedAnnualOperatingCost = estimatedAnnualOperatingCost;
            this.FundingTypeID = fundingTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int actionPriorityID, int projectStageID, short projectNumber, string projectName, string projectDescription, bool implementsMultipleProjects, bool isFeatured, int projectLocationSimpleTypeID, int fundingTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ActionPriorityID = actionPriorityID;
            this.ProjectStageID = projectStageID;
            this.ProjectNumber = projectNumber;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ImplementsMultipleProjects = implementsMultipleProjects;
            this.IsFeatured = isFeatured;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.FundingTypeID = fundingTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Project(ActionPriority actionPriority, ProjectStage projectStage, short projectNumber, string projectName, string projectDescription, bool implementsMultipleProjects, bool isFeatured, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ActionPriorityID = actionPriority.ActionPriorityID;
            this.ActionPriority = actionPriority;
            actionPriority.Projects.Add(this);
            this.ProjectStageID = projectStage.ProjectStageID;
            this.ProjectNumber = projectNumber;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ImplementsMultipleProjects = implementsMultipleProjects;
            this.IsFeatured = isFeatured;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleType.ProjectLocationSimpleTypeID;
            this.FundingTypeID = fundingType.FundingTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Project CreateNewBlank(ActionPriority actionPriority, ProjectStage projectStage, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType)
        {
            return new Project(actionPriority, projectStage, default(short), default(string), default(string), default(bool), default(bool), projectLocationSimpleType, fundingType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return NotificationProjects.Any() || PerformanceMeasureActuals.Any() || PerformanceMeasureExpecteds.Any() || ProjectAssessmentQuestions.Any() || ProjectBudgets.Any() || ProjectExemptReportingYears.Any() || ProjectExternalLinks.Any() || ProjectFundingOrganizations.Any() || ProjectFundingSourceExpenditures.Any() || ProjectImages.Any() || ProjectImplementingOrganizations.Any() || ProjectLocations.Any() || ProjectLocationStagings.Any() || ProjectNotes.Any() || ProjectTags.Any() || ProjectThresholdCategories.Any() || ProjectUpdateBatches.Any() || ProjectWatersheds.Any() || (ProposedProject != null) || SnapshotProjects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Project).Name, typeof(NotificationProject).Name, typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureExpected).Name, typeof(ProjectAssessmentQuestion).Name, typeof(ProjectBudget).Name, typeof(ProjectExemptReportingYear).Name, typeof(ProjectExternalLink).Name, typeof(ProjectFundingOrganization).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectImage).Name, typeof(ProjectImplementingOrganization).Name, typeof(ProjectLocation).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectNote).Name, typeof(ProjectTag).Name, typeof(ProjectThresholdCategory).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectWatershed).Name, typeof(ProposedProject).Name, typeof(SnapshotProject).Name};

        [Key]
        public int ProjectID { get; set; }
        public int ActionPriorityID { get; set; }
        public int ProjectStageID { get; set; }
        public short ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public bool ImplementsMultipleProjects { get; set; }
        public decimal? SecuredFunding { get; set; }
        public DbGeometry ProjectLocationPoint { get; set; }
        public int? ProjectLocationAreaID { get; set; }
        public string PerformanceMeasureActualYearsExemptionExplanation { get; set; }
        public bool IsFeatured { get; set; }
        public string ProjectLocationNotes { get; set; }
        public int? PlanningDesignStartYear { get; set; }
        public int ProjectLocationSimpleTypeID { get; set; }
        public decimal? EstimatedAnnualOperatingCost { get; set; }
        public int FundingTypeID { get; set; }
        public int PrimaryKey { get { return ProjectID; } set { ProjectID = value; } }

        public virtual ICollection<NotificationProject> NotificationProjects { get; set; }
        public virtual ICollection<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual ICollection<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<ProjectAssessmentQuestion> ProjectAssessmentQuestions { get; set; }
        public virtual ICollection<ProjectBudget> ProjectBudgets { get; set; }
        public virtual ICollection<ProjectExemptReportingYear> ProjectExemptReportingYears { get; set; }
        public virtual ICollection<ProjectExternalLink> ProjectExternalLinks { get; set; }
        public virtual ICollection<ProjectFundingOrganization> ProjectFundingOrganizations { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectImplementingOrganization> ProjectImplementingOrganizations { get; set; }
        public virtual ICollection<ProjectLocation> ProjectLocations { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotes { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<ProjectThresholdCategory> ProjectThresholdCategories { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatches { get; set; }
        public virtual ICollection<ProjectWatershed> ProjectWatersheds { get; set; }
        protected virtual ICollection<ProposedProject> ProposedProjects { get; set; }
        public ProposedProject ProposedProject { get { return ProposedProjects.SingleOrDefault(); } set { ProposedProjects = new List<ProposedProject>{value};} }
        public virtual ICollection<SnapshotProject> SnapshotProjects { get; set; }
        public virtual ActionPriority ActionPriority { get; set; }
        public ProjectStage ProjectStage { get { return ProjectStage.AllLookupDictionary[ProjectStageID]; } }
        public virtual ProjectLocationArea ProjectLocationArea { get; set; }
        public ProjectLocationSimpleType ProjectLocationSimpleType { get { return ProjectLocationSimpleType.AllLookupDictionary[ProjectLocationSimpleTypeID]; } }
        public FundingType FundingType { get { return FundingType.AllLookupDictionary[FundingTypeID]; } }

        public static class FieldLengths
        {
            public const int ProjectName = 140;
            public const int ProjectDescription = 4000;
            public const int PerformanceMeasureActualYearsExemptionExplanation = 4000;
            public const int ProjectLocationNotes = 4000;
        }
    }
}