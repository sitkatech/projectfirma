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
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[Project] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Project]")]
    public partial class Project : IHavePrimaryKey, IHaveATenantID
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
            this.ProjectAttachments = new HashSet<ProjectAttachment>();
            this.ProjectClassifications = new HashSet<ProjectClassification>();
            this.ProjectContacts = new HashSet<ProjectContact>();
            this.ProjectCustomAttributes = new HashSet<ProjectCustomAttribute>();
            this.ProjectDocuments = new HashSet<ProjectDocument>();
            this.ProjectExemptReportingYears = new HashSet<ProjectExemptReportingYear>();
            this.ProjectExternalLinks = new HashSet<ProjectExternalLink>();
            this.ProjectFundingSourceBudgets = new HashSet<ProjectFundingSourceBudget>();
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectGeospatialAreas = new HashSet<ProjectGeospatialArea>();
            this.ProjectGeospatialAreaTypeNotes = new HashSet<ProjectGeospatialAreaTypeNote>();
            this.ProjectImages = new HashSet<ProjectImage>();
            this.ProjectInternalNotes = new HashSet<ProjectInternalNote>();
            this.ProjectLocations = new HashSet<ProjectLocation>();
            this.ProjectLocationStagings = new HashSet<ProjectLocationStaging>();
            this.ProjectNoFundingSourceIdentifieds = new HashSet<ProjectNoFundingSourceIdentified>();
            this.ProjectNotes = new HashSet<ProjectNote>();
            this.ProjectOrganizations = new HashSet<ProjectOrganization>();
            this.ProjectRelevantCostTypes = new HashSet<ProjectRelevantCostType>();
            this.ProjectTags = new HashSet<ProjectTag>();
            this.ProjectUpdateBatches = new HashSet<ProjectUpdateBatch>();
            this.SecondaryProjectTaxonomyLeafs = new HashSet<SecondaryProjectTaxonomyLeaf>();
            this.TechnicalAssistanceRequests = new HashSet<TechnicalAssistanceRequest>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int projectID, int taxonomyLeafID, int projectStageID, string projectName, string projectDescription, int? implementationStartYear, int? completionYear, decimal? estimatedTotalCostDeprecated, DbGeometry projectLocationPoint, string performanceMeasureActualYearsExemptionExplanation, bool isFeatured, string projectLocationNotes, int? planningDesignStartYear, int projectLocationSimpleTypeID, decimal? estimatedAnnualOperatingCostDeprecated, int? fundingTypeID, int? primaryContactPersonID, int projectApprovalStatusID, int? proposingPersonID, DateTime? proposingDate, string performanceMeasureNotes, DateTime? submissionDate, DateTime? approvalDate, int? reviewedByPersonID, DbGeometry defaultBoundingBox, string noExpendituresToReportExplanation, decimal? noFundingSourceIdentifiedYet, string expectedFundingUpdateNote) : this()
        {
            this.ProjectID = projectID;
            this.TaxonomyLeafID = taxonomyLeafID;
            this.ProjectStageID = projectStageID;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.EstimatedTotalCostDeprecated = estimatedTotalCostDeprecated;
            this.ProjectLocationPoint = projectLocationPoint;
            this.PerformanceMeasureActualYearsExemptionExplanation = performanceMeasureActualYearsExemptionExplanation;
            this.IsFeatured = isFeatured;
            this.ProjectLocationNotes = projectLocationNotes;
            this.PlanningDesignStartYear = planningDesignStartYear;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.EstimatedAnnualOperatingCostDeprecated = estimatedAnnualOperatingCostDeprecated;
            this.FundingTypeID = fundingTypeID;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.ProjectApprovalStatusID = projectApprovalStatusID;
            this.ProposingPersonID = proposingPersonID;
            this.ProposingDate = proposingDate;
            this.PerformanceMeasureNotes = performanceMeasureNotes;
            this.SubmissionDate = submissionDate;
            this.ApprovalDate = approvalDate;
            this.ReviewedByPersonID = reviewedByPersonID;
            this.DefaultBoundingBox = defaultBoundingBox;
            this.NoExpendituresToReportExplanation = noExpendituresToReportExplanation;
            this.NoFundingSourceIdentifiedYet = noFundingSourceIdentifiedYet;
            this.ExpectedFundingUpdateNote = expectedFundingUpdateNote;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int taxonomyLeafID, int projectStageID, string projectName, string projectDescription, bool isFeatured, int projectLocationSimpleTypeID, int projectApprovalStatusID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyLeafID = taxonomyLeafID;
            this.ProjectStageID = projectStageID;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.IsFeatured = isFeatured;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.ProjectApprovalStatusID = projectApprovalStatusID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Project(TaxonomyLeaf taxonomyLeaf, ProjectStage projectStage, string projectName, string projectDescription, bool isFeatured, ProjectLocationSimpleType projectLocationSimpleType, ProjectApprovalStatus projectApprovalStatus) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyLeafID = taxonomyLeaf.TaxonomyLeafID;
            this.TaxonomyLeaf = taxonomyLeaf;
            taxonomyLeaf.Projects.Add(this);
            this.ProjectStageID = projectStage.ProjectStageID;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.IsFeatured = isFeatured;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleType.ProjectLocationSimpleTypeID;
            this.ProjectApprovalStatusID = projectApprovalStatus.ProjectApprovalStatusID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Project CreateNewBlank(TaxonomyLeaf taxonomyLeaf, ProjectStage projectStage, ProjectLocationSimpleType projectLocationSimpleType, ProjectApprovalStatus projectApprovalStatus)
        {
            return new Project(taxonomyLeaf, projectStage, default(string), default(string), default(bool), projectLocationSimpleType, projectApprovalStatus);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return NotificationProjects.Any() || PerformanceMeasureActuals.Any() || PerformanceMeasureExpecteds.Any() || ProjectAssessmentQuestions.Any() || ProjectAttachments.Any() || ProjectClassifications.Any() || ProjectContacts.Any() || ProjectCustomAttributes.Any() || ProjectDocuments.Any() || ProjectExemptReportingYears.Any() || ProjectExternalLinks.Any() || ProjectFundingSourceBudgets.Any() || ProjectFundingSourceExpenditures.Any() || ProjectGeospatialAreas.Any() || ProjectGeospatialAreaTypeNotes.Any() || ProjectImages.Any() || ProjectInternalNotes.Any() || ProjectLocations.Any() || ProjectLocationStagings.Any() || ProjectNoFundingSourceIdentifieds.Any() || ProjectNotes.Any() || ProjectOrganizations.Any() || ProjectRelevantCostTypes.Any() || ProjectTags.Any() || ProjectUpdateBatches.Any() || SecondaryProjectTaxonomyLeafs.Any() || TechnicalAssistanceRequests.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Project).Name, typeof(NotificationProject).Name, typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureExpected).Name, typeof(ProjectAssessmentQuestion).Name, typeof(ProjectAttachment).Name, typeof(ProjectClassification).Name, typeof(ProjectContact).Name, typeof(ProjectCustomAttribute).Name, typeof(ProjectDocument).Name, typeof(ProjectExemptReportingYear).Name, typeof(ProjectExternalLink).Name, typeof(ProjectFundingSourceBudget).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectGeospatialArea).Name, typeof(ProjectGeospatialAreaTypeNote).Name, typeof(ProjectImage).Name, typeof(ProjectInternalNote).Name, typeof(ProjectLocation).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectNoFundingSourceIdentified).Name, typeof(ProjectNote).Name, typeof(ProjectOrganization).Name, typeof(ProjectRelevantCostType).Name, typeof(ProjectTag).Name, typeof(ProjectUpdateBatch).Name, typeof(SecondaryProjectTaxonomyLeaf).Name, typeof(TechnicalAssistanceRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjects.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in NotificationProjects.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureActuals.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpecteds.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectAssessmentQuestions.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectAttachments.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectClassifications.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectContacts.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectCustomAttributes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectDocuments.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectExemptReportingYears.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectExternalLinks.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceBudgets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceExpenditures.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreas.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreaTypeNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectInternalNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectLocations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectLocationStagings.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNoFundingSourceIdentifieds.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectOrganizations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectRelevantCostTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectTags.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdateBatches.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in SecondaryProjectTaxonomyLeafs.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TechnicalAssistanceRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectID { get; set; }
        public int TenantID { get; set; }
        public int TaxonomyLeafID { get; set; }
        public int ProjectStageID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public decimal? EstimatedTotalCostDeprecated { get; set; }
        public DbGeometry ProjectLocationPoint { get; set; }
        public string PerformanceMeasureActualYearsExemptionExplanation { get; set; }
        public bool IsFeatured { get; set; }
        public string ProjectLocationNotes { get; set; }
        public int? PlanningDesignStartYear { get; set; }
        public int ProjectLocationSimpleTypeID { get; set; }
        public decimal? EstimatedAnnualOperatingCostDeprecated { get; set; }
        public int? FundingTypeID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public int ProjectApprovalStatusID { get; set; }
        public int? ProposingPersonID { get; set; }
        public DateTime? ProposingDate { get; set; }
        public string PerformanceMeasureNotes { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ReviewedByPersonID { get; set; }
        public DbGeometry DefaultBoundingBox { get; set; }
        public string NoExpendituresToReportExplanation { get; set; }
        public decimal? NoFundingSourceIdentifiedYet { get; set; }
        public string ExpectedFundingUpdateNote { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectID; } set { ProjectID = value; } }

        public virtual ICollection<NotificationProject> NotificationProjects { get; set; }
        public virtual ICollection<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual ICollection<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<ProjectAssessmentQuestion> ProjectAssessmentQuestions { get; set; }
        public virtual ICollection<ProjectAttachment> ProjectAttachments { get; set; }
        public virtual ICollection<ProjectClassification> ProjectClassifications { get; set; }
        public virtual ICollection<ProjectContact> ProjectContacts { get; set; }
        public virtual ICollection<ProjectCustomAttribute> ProjectCustomAttributes { get; set; }
        public virtual ICollection<ProjectDocument> ProjectDocuments { get; set; }
        public virtual ICollection<ProjectExemptReportingYear> ProjectExemptReportingYears { get; set; }
        public virtual ICollection<ProjectExternalLink> ProjectExternalLinks { get; set; }
        public virtual ICollection<ProjectFundingSourceBudget> ProjectFundingSourceBudgets { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectGeospatialArea> ProjectGeospatialAreas { get; set; }
        public virtual ICollection<ProjectGeospatialAreaTypeNote> ProjectGeospatialAreaTypeNotes { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectInternalNote> ProjectInternalNotes { get; set; }
        public virtual ICollection<ProjectLocation> ProjectLocations { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectNoFundingSourceIdentified> ProjectNoFundingSourceIdentifieds { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotes { get; set; }
        public virtual ICollection<ProjectOrganization> ProjectOrganizations { get; set; }
        public virtual ICollection<ProjectRelevantCostType> ProjectRelevantCostTypes { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatches { get; set; }
        public virtual ICollection<SecondaryProjectTaxonomyLeaf> SecondaryProjectTaxonomyLeafs { get; set; }
        public virtual ICollection<TechnicalAssistanceRequest> TechnicalAssistanceRequests { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyLeaf TaxonomyLeaf { get; set; }
        public ProjectStage ProjectStage { get { return ProjectStage.AllLookupDictionary[ProjectStageID]; } }
        public ProjectLocationSimpleType ProjectLocationSimpleType { get { return ProjectLocationSimpleType.AllLookupDictionary[ProjectLocationSimpleTypeID]; } }
        public FundingType FundingType { get { return FundingTypeID.HasValue ? FundingType.AllLookupDictionary[FundingTypeID.Value] : null; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual Person ProposingPerson { get; set; }
        public virtual Person ReviewedByPerson { get; set; }
        public ProjectApprovalStatus ProjectApprovalStatus { get { return ProjectApprovalStatus.AllLookupDictionary[ProjectApprovalStatusID]; } }

        public static class FieldLengths
        {
            public const int ProjectName = 140;
            public const int ProjectDescription = 4000;
            public const int PerformanceMeasureActualYearsExemptionExplanation = 4000;
            public const int ProjectLocationNotes = 4000;
            public const int PerformanceMeasureNotes = 500;
            public const int ExpectedFundingUpdateNote = 500;
        }
    }
}