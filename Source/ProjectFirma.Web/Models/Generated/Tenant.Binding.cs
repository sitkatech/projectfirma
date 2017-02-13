//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tenant]
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
    [Table("[dbo].[Tenant]")]
    public partial class Tenant : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Tenant()
        {
            this.AssessmentGoals = new HashSet<AssessmentGoal>();
            this.AssessmentQuestions = new HashSet<AssessmentQuestion>();
            this.AssessmentSubGoals = new HashSet<AssessmentSubGoal>();
            this.AuditLogs = new HashSet<AuditLog>();
            this.Classifications = new HashSet<Classification>();
            this.ClassificationPerformanceMeasures = new HashSet<ClassificationPerformanceMeasure>();
            this.CostParameterSets = new HashSet<CostParameterSet>();
            this.FieldDefinitionDatas = new HashSet<FieldDefinitionData>();
            this.FieldDefinitionImages = new HashSet<FieldDefinitionImage>();
            this.FileResources = new HashSet<FileResource>();
            this.FirmaPages = new HashSet<FirmaPage>();
            this.FirmaPageImages = new HashSet<FirmaPageImage>();
            this.FundingSources = new HashSet<FundingSource>();
            this.MappedRegions = new HashSet<MappedRegion>();
            this.MonitoringPrograms = new HashSet<MonitoringProgram>();
            this.MonitoringProgramDocuments = new HashSet<MonitoringProgramDocument>();
            this.MonitoringProgramPartners = new HashSet<MonitoringProgramPartner>();
            this.Notifications = new HashSet<Notification>();
            this.NotificationProjects = new HashSet<NotificationProject>();
            this.NotificationProposedProjects = new HashSet<NotificationProposedProject>();
            this.Organizations = new HashSet<Organization>();
            this.PerformanceMeasures = new HashSet<PerformanceMeasure>();
            this.PerformanceMeasureActuals = new HashSet<PerformanceMeasureActual>();
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.PerformanceMeasureActualUpdates = new HashSet<PerformanceMeasureActualUpdate>();
            this.PerformanceMeasureExpecteds = new HashSet<PerformanceMeasureExpected>();
            this.PerformanceMeasureExpectedProposeds = new HashSet<PerformanceMeasureExpectedProposed>();
            this.PerformanceMeasureExpectedSubcategoryOptions = new HashSet<PerformanceMeasureExpectedSubcategoryOption>();
            this.PerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<PerformanceMeasureExpectedSubcategoryOptionProposed>();
            this.PerformanceMeasureMonitoringPrograms = new HashSet<PerformanceMeasureMonitoringProgram>();
            this.PerformanceMeasureNotes = new HashSet<PerformanceMeasureNote>();
            this.PerformanceMeasureSubcategories = new HashSet<PerformanceMeasureSubcategory>();
            this.PerformanceMeasureSubcategoryOptions = new HashSet<PerformanceMeasureSubcategoryOption>();
            this.People = new HashSet<Person>();
            this.Projects = new HashSet<Project>();
            this.ProjectAssessmentQuestions = new HashSet<ProjectAssessmentQuestion>();
            this.ProjectBudgets = new HashSet<ProjectBudget>();
            this.ProjectBudgetUpdates = new HashSet<ProjectBudgetUpdate>();
            this.ProjectClassifications = new HashSet<ProjectClassification>();
            this.ProjectExemptReportingYears = new HashSet<ProjectExemptReportingYear>();
            this.ProjectExemptReportingYearUpdates = new HashSet<ProjectExemptReportingYearUpdate>();
            this.ProjectExternalLinks = new HashSet<ProjectExternalLink>();
            this.ProjectExternalLinkUpdates = new HashSet<ProjectExternalLinkUpdate>();
            this.ProjectFundingOrganizations = new HashSet<ProjectFundingOrganization>();
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectFundingSourceExpenditureUpdates = new HashSet<ProjectFundingSourceExpenditureUpdate>();
            this.ProjectImages = new HashSet<ProjectImage>();
            this.ProjectImageUpdates = new HashSet<ProjectImageUpdate>();
            this.ProjectImplementingOrganizations = new HashSet<ProjectImplementingOrganization>();
            this.ProjectLocations = new HashSet<ProjectLocation>();
            this.ProjectLocationAreas = new HashSet<ProjectLocationArea>();
            this.ProjectLocationAreaGroups = new HashSet<ProjectLocationAreaGroup>();
            this.ProjectLocationAreaStateProvinces = new HashSet<ProjectLocationAreaStateProvince>();
            this.ProjectLocationAreaWatersheds = new HashSet<ProjectLocationAreaWatershed>();
            this.ProjectLocationStagings = new HashSet<ProjectLocationStaging>();
            this.ProjectLocationStagingUpdates = new HashSet<ProjectLocationStagingUpdate>();
            this.ProjectLocationUpdates = new HashSet<ProjectLocationUpdate>();
            this.ProjectNotes = new HashSet<ProjectNote>();
            this.ProjectNoteUpdates = new HashSet<ProjectNoteUpdate>();
            this.ProjectTags = new HashSet<ProjectTag>();
            this.ProjectUpdates = new HashSet<ProjectUpdate>();
            this.ProjectUpdateBatches = new HashSet<ProjectUpdateBatch>();
            this.ProjectUpdateHistories = new HashSet<ProjectUpdateHistory>();
            this.ProjectWatersheds = new HashSet<ProjectWatershed>();
            this.ProposedProjects = new HashSet<ProposedProject>();
            this.ProposedProjectAssessmentQuestions = new HashSet<ProposedProjectAssessmentQuestion>();
            this.ProposedProjectClassifications = new HashSet<ProposedProjectClassification>();
            this.ProposedProjectImages = new HashSet<ProposedProjectImage>();
            this.ProposedProjectLocations = new HashSet<ProposedProjectLocation>();
            this.ProposedProjectLocationStagings = new HashSet<ProposedProjectLocationStaging>();
            this.ProposedProjectNotes = new HashSet<ProposedProjectNote>();
            this.Snapshots = new HashSet<Snapshot>();
            this.SnapshotPerformanceMeasures = new HashSet<SnapshotPerformanceMeasure>();
            this.SnapshotPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotPerformanceMeasureSubcategoryOption>();
            this.SnapshotProjects = new HashSet<SnapshotProject>();
            this.SnapshotSectorExpenditures = new HashSet<SnapshotSectorExpenditure>();
            this.SupportRequestLogs = new HashSet<SupportRequestLog>();
            this.Tags = new HashSet<Tag>();
            this.TaxonomyTierOnes = new HashSet<TaxonomyTierOne>();
            this.TaxonomyTierOneImages = new HashSet<TaxonomyTierOneImage>();
            this.TaxonomyTierThrees = new HashSet<TaxonomyTierThree>();
            this.TaxonomyTierThreeImages = new HashSet<TaxonomyTierThreeImage>();
            this.TaxonomyTierTwos = new HashSet<TaxonomyTierTwo>();
            this.TaxonomyTierTwoImages = new HashSet<TaxonomyTierTwoImage>();
            this.TaxonomyTierTwoPerformanceMeasures = new HashSet<TaxonomyTierTwoPerformanceMeasure>();
            this.Watersheds = new HashSet<Watershed>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Tenant(int tenantID, string tenantName, string tenantDomain) : this()
        {
            this.TenantID = tenantID;
            this.TenantName = tenantName;
            this.TenantDomain = tenantDomain;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Tenant(string tenantName, string tenantDomain) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TenantID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantName = tenantName;
            this.TenantDomain = tenantDomain;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Tenant CreateNewBlank()
        {
            return new Tenant(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AssessmentGoals.Any() || AssessmentQuestions.Any() || AssessmentSubGoals.Any() || AuditLogs.Any() || Classifications.Any() || ClassificationPerformanceMeasures.Any() || CostParameterSets.Any() || FieldDefinitionDatas.Any() || FieldDefinitionImages.Any() || FileResources.Any() || FirmaPages.Any() || FirmaPageImages.Any() || FundingSources.Any() || MappedRegions.Any() || MonitoringPrograms.Any() || MonitoringProgramDocuments.Any() || MonitoringProgramPartners.Any() || Notifications.Any() || NotificationProjects.Any() || NotificationProposedProjects.Any() || Organizations.Any() || PerformanceMeasures.Any() || PerformanceMeasureActuals.Any() || PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureActualUpdates.Any() || PerformanceMeasureExpecteds.Any() || PerformanceMeasureExpectedProposeds.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptionProposeds.Any() || PerformanceMeasureMonitoringPrograms.Any() || PerformanceMeasureNotes.Any() || PerformanceMeasureSubcategories.Any() || PerformanceMeasureSubcategoryOptions.Any() || People.Any() || Projects.Any() || ProjectAssessmentQuestions.Any() || ProjectBudgets.Any() || ProjectBudgetUpdates.Any() || ProjectClassifications.Any() || ProjectExemptReportingYears.Any() || ProjectExemptReportingYearUpdates.Any() || ProjectExternalLinks.Any() || ProjectExternalLinkUpdates.Any() || ProjectFundingOrganizations.Any() || ProjectFundingSourceExpenditures.Any() || ProjectFundingSourceExpenditureUpdates.Any() || ProjectImages.Any() || ProjectImageUpdates.Any() || ProjectImplementingOrganizations.Any() || ProjectLocations.Any() || ProjectLocationAreas.Any() || ProjectLocationAreaGroups.Any() || ProjectLocationAreaStateProvinces.Any() || ProjectLocationAreaWatersheds.Any() || ProjectLocationStagings.Any() || ProjectLocationStagingUpdates.Any() || ProjectLocationUpdates.Any() || ProjectNotes.Any() || ProjectNoteUpdates.Any() || ProjectTags.Any() || ProjectUpdates.Any() || ProjectUpdateBatches.Any() || ProjectUpdateHistories.Any() || ProjectWatersheds.Any() || ProposedProjects.Any() || ProposedProjectAssessmentQuestions.Any() || ProposedProjectClassifications.Any() || ProposedProjectImages.Any() || ProposedProjectLocations.Any() || ProposedProjectLocationStagings.Any() || ProposedProjectNotes.Any() || Snapshots.Any() || SnapshotPerformanceMeasures.Any() || SnapshotPerformanceMeasureSubcategoryOptions.Any() || SnapshotProjects.Any() || SnapshotSectorExpenditures.Any() || SupportRequestLogs.Any() || Tags.Any() || TaxonomyTierOnes.Any() || TaxonomyTierOneImages.Any() || TaxonomyTierThrees.Any() || TaxonomyTierThreeImages.Any() || TaxonomyTierTwos.Any() || TaxonomyTierTwoImages.Any() || TaxonomyTierTwoPerformanceMeasures.Any() || Watersheds.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Tenant).Name, typeof(AssessmentGoal).Name, typeof(AssessmentQuestion).Name, typeof(AssessmentSubGoal).Name, typeof(AuditLog).Name, typeof(Classification).Name, typeof(ClassificationPerformanceMeasure).Name, typeof(CostParameterSet).Name, typeof(FieldDefinitionData).Name, typeof(FieldDefinitionImage).Name, typeof(FileResource).Name, typeof(FirmaPage).Name, typeof(FirmaPageImage).Name, typeof(FundingSource).Name, typeof(MappedRegion).Name, typeof(MonitoringProgram).Name, typeof(MonitoringProgramDocument).Name, typeof(MonitoringProgramPartner).Name, typeof(Notification).Name, typeof(NotificationProject).Name, typeof(NotificationProposedProject).Name, typeof(Organization).Name, typeof(PerformanceMeasure).Name, typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureActualUpdate).Name, typeof(PerformanceMeasureExpected).Name, typeof(PerformanceMeasureExpectedProposed).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionProposed).Name, typeof(PerformanceMeasureMonitoringProgram).Name, typeof(PerformanceMeasureNote).Name, typeof(PerformanceMeasureSubcategory).Name, typeof(PerformanceMeasureSubcategoryOption).Name, typeof(Person).Name, typeof(Project).Name, typeof(ProjectAssessmentQuestion).Name, typeof(ProjectBudget).Name, typeof(ProjectBudgetUpdate).Name, typeof(ProjectClassification).Name, typeof(ProjectExemptReportingYear).Name, typeof(ProjectExemptReportingYearUpdate).Name, typeof(ProjectExternalLink).Name, typeof(ProjectExternalLinkUpdate).Name, typeof(ProjectFundingOrganization).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectFundingSourceExpenditureUpdate).Name, typeof(ProjectImage).Name, typeof(ProjectImageUpdate).Name, typeof(ProjectImplementingOrganization).Name, typeof(ProjectLocation).Name, typeof(ProjectLocationArea).Name, typeof(ProjectLocationAreaGroup).Name, typeof(ProjectLocationAreaStateProvince).Name, typeof(ProjectLocationAreaWatershed).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectLocationStagingUpdate).Name, typeof(ProjectLocationUpdate).Name, typeof(ProjectNote).Name, typeof(ProjectNoteUpdate).Name, typeof(ProjectTag).Name, typeof(ProjectUpdate).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectUpdateHistory).Name, typeof(ProjectWatershed).Name, typeof(ProposedProject).Name, typeof(ProposedProjectAssessmentQuestion).Name, typeof(ProposedProjectClassification).Name, typeof(ProposedProjectImage).Name, typeof(ProposedProjectLocation).Name, typeof(ProposedProjectLocationStaging).Name, typeof(ProposedProjectNote).Name, typeof(Snapshot).Name, typeof(SnapshotPerformanceMeasure).Name, typeof(SnapshotPerformanceMeasureSubcategoryOption).Name, typeof(SnapshotProject).Name, typeof(SnapshotSectorExpenditure).Name, typeof(SupportRequestLog).Name, typeof(Tag).Name, typeof(TaxonomyTierOne).Name, typeof(TaxonomyTierOneImage).Name, typeof(TaxonomyTierThree).Name, typeof(TaxonomyTierThreeImage).Name, typeof(TaxonomyTierTwo).Name, typeof(TaxonomyTierTwoImage).Name, typeof(TaxonomyTierTwoPerformanceMeasure).Name, typeof(Watershed).Name};

        [Key]
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public string TenantDomain { get; set; }
        public int PrimaryKey { get { return TenantID; } set { TenantID = value; } }

        public virtual ICollection<AssessmentGoal> AssessmentGoals { get; set; }
        public virtual ICollection<AssessmentQuestion> AssessmentQuestions { get; set; }
        public virtual ICollection<AssessmentSubGoal> AssessmentSubGoals { get; set; }
        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<Classification> Classifications { get; set; }
        public virtual ICollection<ClassificationPerformanceMeasure> ClassificationPerformanceMeasures { get; set; }
        public virtual ICollection<CostParameterSet> CostParameterSets { get; set; }
        public virtual ICollection<FieldDefinitionData> FieldDefinitionDatas { get; set; }
        public virtual ICollection<FieldDefinitionImage> FieldDefinitionImages { get; set; }
        public virtual ICollection<FileResource> FileResources { get; set; }
        public virtual ICollection<FirmaPage> FirmaPages { get; set; }
        public virtual ICollection<FirmaPageImage> FirmaPageImages { get; set; }
        public virtual ICollection<FundingSource> FundingSources { get; set; }
        public virtual ICollection<MappedRegion> MappedRegions { get; set; }
        public virtual ICollection<MonitoringProgram> MonitoringPrograms { get; set; }
        public virtual ICollection<MonitoringProgramDocument> MonitoringProgramDocuments { get; set; }
        public virtual ICollection<MonitoringProgramPartner> MonitoringProgramPartners { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<NotificationProject> NotificationProjects { get; set; }
        public virtual ICollection<NotificationProposedProject> NotificationProposedProjects { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<PerformanceMeasure> PerformanceMeasures { get; set; }
        public virtual ICollection<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureActualUpdate> PerformanceMeasureActualUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedProposed> PerformanceMeasureExpectedProposeds { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> PerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ICollection<PerformanceMeasureMonitoringProgram> PerformanceMeasureMonitoringPrograms { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotes { get; set; }
        public virtual ICollection<PerformanceMeasureSubcategory> PerformanceMeasureSubcategories { get; set; }
        public virtual ICollection<PerformanceMeasureSubcategoryOption> PerformanceMeasureSubcategoryOptions { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProjectAssessmentQuestion> ProjectAssessmentQuestions { get; set; }
        public virtual ICollection<ProjectBudget> ProjectBudgets { get; set; }
        public virtual ICollection<ProjectBudgetUpdate> ProjectBudgetUpdates { get; set; }
        public virtual ICollection<ProjectClassification> ProjectClassifications { get; set; }
        public virtual ICollection<ProjectExemptReportingYear> ProjectExemptReportingYears { get; set; }
        public virtual ICollection<ProjectExemptReportingYearUpdate> ProjectExemptReportingYearUpdates { get; set; }
        public virtual ICollection<ProjectExternalLink> ProjectExternalLinks { get; set; }
        public virtual ICollection<ProjectExternalLinkUpdate> ProjectExternalLinkUpdates { get; set; }
        public virtual ICollection<ProjectFundingOrganization> ProjectFundingOrganizations { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public virtual ICollection<ProjectImplementingOrganization> ProjectImplementingOrganizations { get; set; }
        public virtual ICollection<ProjectLocation> ProjectLocations { get; set; }
        public virtual ICollection<ProjectLocationArea> ProjectLocationAreas { get; set; }
        public virtual ICollection<ProjectLocationAreaGroup> ProjectLocationAreaGroups { get; set; }
        public virtual ICollection<ProjectLocationAreaStateProvince> ProjectLocationAreaStateProvinces { get; set; }
        public virtual ICollection<ProjectLocationAreaWatershed> ProjectLocationAreaWatersheds { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual ICollection<ProjectLocationUpdate> ProjectLocationUpdates { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotes { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdates { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<ProjectUpdate> ProjectUpdates { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatches { get; set; }
        public virtual ICollection<ProjectUpdateHistory> ProjectUpdateHistories { get; set; }
        public virtual ICollection<ProjectWatershed> ProjectWatersheds { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjects { get; set; }
        public virtual ICollection<ProposedProjectAssessmentQuestion> ProposedProjectAssessmentQuestions { get; set; }
        public virtual ICollection<ProposedProjectClassification> ProposedProjectClassifications { get; set; }
        public virtual ICollection<ProposedProjectImage> ProposedProjectImages { get; set; }
        public virtual ICollection<ProposedProjectLocation> ProposedProjectLocations { get; set; }
        public virtual ICollection<ProposedProjectLocationStaging> ProposedProjectLocationStagings { get; set; }
        public virtual ICollection<ProposedProjectNote> ProposedProjectNotes { get; set; }
        public virtual ICollection<Snapshot> Snapshots { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasure> SnapshotPerformanceMeasures { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasureSubcategoryOption> SnapshotPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual ICollection<SnapshotProject> SnapshotProjects { get; set; }
        public virtual ICollection<SnapshotSectorExpenditure> SnapshotSectorExpenditures { get; set; }
        public virtual ICollection<SupportRequestLog> SupportRequestLogs { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<TaxonomyTierOne> TaxonomyTierOnes { get; set; }
        public virtual ICollection<TaxonomyTierOneImage> TaxonomyTierOneImages { get; set; }
        public virtual ICollection<TaxonomyTierThree> TaxonomyTierThrees { get; set; }
        public virtual ICollection<TaxonomyTierThreeImage> TaxonomyTierThreeImages { get; set; }
        public virtual ICollection<TaxonomyTierTwo> TaxonomyTierTwos { get; set; }
        public virtual ICollection<TaxonomyTierTwoImage> TaxonomyTierTwoImages { get; set; }
        public virtual ICollection<TaxonomyTierTwoPerformanceMeasure> TaxonomyTierTwoPerformanceMeasures { get; set; }
        public virtual ICollection<Watershed> Watersheds { get; set; }

        public static class FieldLengths
        {
            public const int TenantName = 100;
            public const int TenantDomain = 100;
        }
    }
}