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
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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
            this.EIPPerformanceMeasureActuals = new HashSet<EIPPerformanceMeasureActual>();
            this.EIPPerformanceMeasureExpecteds = new HashSet<EIPPerformanceMeasureExpected>();
            this.NotificationProjects = new HashSet<NotificationProject>();
            this.ProjectExemptReportingYears = new HashSet<ProjectExemptReportingYear>();
            this.ProjectExternalLinks = new HashSet<ProjectExternalLink>();
            this.ProjectFundingOrganizations = new HashSet<ProjectFundingOrganization>();
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectImages = new HashSet<ProjectImage>();
            this.ProjectImplementingOrganizations = new HashSet<ProjectImplementingOrganization>();
            this.ProjectLocalAndRegionalPlans = new HashSet<ProjectLocalAndRegionalPlan>();
            this.ProjectLocations = new HashSet<ProjectLocation>();
            this.ProjectLocationStagings = new HashSet<ProjectLocationStaging>();
            this.ProjectNotes = new HashSet<ProjectNote>();
            this.ProjectTags = new HashSet<ProjectTag>();
            this.ProjectThresholdCategories = new HashSet<ProjectThresholdCategory>();
            this.ProjectTransportationQuestions = new HashSet<ProjectTransportationQuestion>();
            this.ProjectUpdateBatches = new HashSet<ProjectUpdateBatch>();
            this.ProjectWatersheds = new HashSet<ProjectWatershed>();
            this.ProposedProjects = new HashSet<ProposedProject>();
            this.SnapshotProjects = new HashSet<SnapshotProject>();
            this.TransportationProjectBudgets = new HashSet<TransportationProjectBudget>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int projectID, int actionPriorityID, int projectStageID, short projectNumber, string projectName, string projectDescription, int? implementationStartYear, int? completionYear, string oldEipNumber, decimal? estimatedTotalCost, bool implementsMultipleProjects, decimal? securedFunding, DbGeometry projectLocationPoint, int? projectLocationAreaID, string eIPPerformanceMeasureActualYearsExemptionExplanation, bool isFeatured, int? transportationObjectiveID, string projectLocationNotes, bool onFederalTransportationImprovementProgramList, int? planningDesignStartYear, int projectLocationSimpleTypeID, decimal? estimatedAnnualOperatingCost, int fundingTypeID) : this()
        {
            this.ProjectID = projectID;
            this.ActionPriorityID = actionPriorityID;
            this.ProjectStageID = projectStageID;
            this.ProjectNumber = projectNumber;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.OldEipNumber = oldEipNumber;
            this.EstimatedTotalCost = estimatedTotalCost;
            this.ImplementsMultipleProjects = implementsMultipleProjects;
            this.SecuredFunding = securedFunding;
            this.ProjectLocationPoint = projectLocationPoint;
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.EIPPerformanceMeasureActualYearsExemptionExplanation = eIPPerformanceMeasureActualYearsExemptionExplanation;
            this.IsFeatured = isFeatured;
            this.TransportationObjectiveID = transportationObjectiveID;
            this.ProjectLocationNotes = projectLocationNotes;
            this.OnFederalTransportationImprovementProgramList = onFederalTransportationImprovementProgramList;
            this.PlanningDesignStartYear = planningDesignStartYear;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.EstimatedAnnualOperatingCost = estimatedAnnualOperatingCost;
            this.FundingTypeID = fundingTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int actionPriorityID, int projectStageID, short projectNumber, string projectName, string projectDescription, bool implementsMultipleProjects, bool isFeatured, bool onFederalTransportationImprovementProgramList, int projectLocationSimpleTypeID, int fundingTypeID) : this()
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
            this.OnFederalTransportationImprovementProgramList = onFederalTransportationImprovementProgramList;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.FundingTypeID = fundingTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Project(ActionPriority actionPriority, ProjectStage projectStage, short projectNumber, string projectName, string projectDescription, bool implementsMultipleProjects, bool isFeatured, bool onFederalTransportationImprovementProgramList, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType) : this()
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
            this.OnFederalTransportationImprovementProgramList = onFederalTransportationImprovementProgramList;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleType.ProjectLocationSimpleTypeID;
            this.FundingTypeID = fundingType.FundingTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Project CreateNewBlank(ActionPriority actionPriority, ProjectStage projectStage, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType)
        {
            return new Project(actionPriority, projectStage, default(short), default(string), default(string), default(bool), default(bool), default(bool), projectLocationSimpleType, fundingType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EIPPerformanceMeasureActuals.Any() || EIPPerformanceMeasureExpecteds.Any() || NotificationProjects.Any() || ProjectExemptReportingYears.Any() || ProjectExternalLinks.Any() || ProjectFundingOrganizations.Any() || ProjectFundingSourceExpenditures.Any() || ProjectImages.Any() || ProjectImplementingOrganizations.Any() || ProjectLocalAndRegionalPlans.Any() || ProjectLocations.Any() || ProjectLocationStagings.Any() || ProjectNotes.Any() || ProjectTags.Any() || ProjectThresholdCategories.Any() || ProjectTransportationQuestions.Any() || ProjectUpdateBatches.Any() || ProjectWatersheds.Any() || (ProposedProject != null) || SnapshotProjects.Any() || TransportationProjectBudgets.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Project).Name, typeof(EIPPerformanceMeasureActual).Name, typeof(EIPPerformanceMeasureExpected).Name, typeof(NotificationProject).Name, typeof(ProjectExemptReportingYear).Name, typeof(ProjectExternalLink).Name, typeof(ProjectFundingOrganization).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectImage).Name, typeof(ProjectImplementingOrganization).Name, typeof(ProjectLocalAndRegionalPlan).Name, typeof(ProjectLocation).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectNote).Name, typeof(ProjectTag).Name, typeof(ProjectThresholdCategory).Name, typeof(ProjectTransportationQuestion).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectWatershed).Name, typeof(ProposedProject).Name, typeof(SnapshotProject).Name, typeof(TransportationProjectBudget).Name};

        [Key]
        public int ProjectID { get; set; }
        public int ActionPriorityID { get; set; }
        public int ProjectStageID { get; set; }
        public short ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public string OldEipNumber { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public bool ImplementsMultipleProjects { get; set; }
        public decimal? SecuredFunding { get; set; }
        public DbGeometry ProjectLocationPoint { get; set; }
        public int? ProjectLocationAreaID { get; set; }
        public string EIPPerformanceMeasureActualYearsExemptionExplanation { get; set; }
        public bool IsFeatured { get; set; }
        public int? TransportationObjectiveID { get; set; }
        public string ProjectLocationNotes { get; set; }
        public bool OnFederalTransportationImprovementProgramList { get; set; }
        public int? PlanningDesignStartYear { get; set; }
        public int ProjectLocationSimpleTypeID { get; set; }
        public decimal? EstimatedAnnualOperatingCost { get; set; }
        public int FundingTypeID { get; set; }
        public int PrimaryKey { get { return ProjectID; } set { ProjectID = value; } }

        public virtual ICollection<EIPPerformanceMeasureActual> EIPPerformanceMeasureActuals { get; set; }
        public virtual ICollection<EIPPerformanceMeasureExpected> EIPPerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<NotificationProject> NotificationProjects { get; set; }
        public virtual ICollection<ProjectExemptReportingYear> ProjectExemptReportingYears { get; set; }
        public virtual ICollection<ProjectExternalLink> ProjectExternalLinks { get; set; }
        public virtual ICollection<ProjectFundingOrganization> ProjectFundingOrganizations { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectImplementingOrganization> ProjectImplementingOrganizations { get; set; }
        public virtual ICollection<ProjectLocalAndRegionalPlan> ProjectLocalAndRegionalPlans { get; set; }
        public virtual ICollection<ProjectLocation> ProjectLocations { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotes { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<ProjectThresholdCategory> ProjectThresholdCategories { get; set; }
        public virtual ICollection<ProjectTransportationQuestion> ProjectTransportationQuestions { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatches { get; set; }
        public virtual ICollection<ProjectWatershed> ProjectWatersheds { get; set; }
        protected virtual ICollection<ProposedProject> ProposedProjects { get; set; }
        public ProposedProject ProposedProject { get { return ProposedProjects.SingleOrDefault(); } set { ProposedProjects = new List<ProposedProject>{value};} }
        public virtual ICollection<SnapshotProject> SnapshotProjects { get; set; }
        public virtual ICollection<TransportationProjectBudget> TransportationProjectBudgets { get; set; }
        public virtual ActionPriority ActionPriority { get; set; }
        public ProjectStage ProjectStage { get { return ProjectStage.AllLookupDictionary[ProjectStageID]; } }
        public virtual ProjectLocationArea ProjectLocationArea { get; set; }
        public virtual TransportationObjective TransportationObjective { get; set; }
        public ProjectLocationSimpleType ProjectLocationSimpleType { get { return ProjectLocationSimpleType.AllLookupDictionary[ProjectLocationSimpleTypeID]; } }
        public FundingType FundingType { get { return FundingType.AllLookupDictionary[FundingTypeID]; } }

        public static class FieldLengths
        {
            public const int ProjectName = 140;
            public const int ProjectDescription = 4000;
            public const int OldEipNumber = 100;
            public const int EIPPerformanceMeasureActualYearsExemptionExplanation = 4000;
            public const int ProjectLocationNotes = 4000;
        }
    }
}