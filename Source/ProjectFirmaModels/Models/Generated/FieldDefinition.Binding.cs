//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinition]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    [Table("[dbo].[FieldDefinition]")]
    public partial class FieldDefinition : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FieldDefinition()
        {
            this.FieldDefinitionDatas = new HashSet<FieldDefinitionData>();
            this.FieldDefinitionDefaults = new HashSet<FieldDefinitionDefault>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : this()
        {
            this.FieldDefinitionID = fieldDefinitionID;
            this.FieldDefinitionName = fieldDefinitionName;
            this.FieldDefinitionDisplayName = fieldDefinitionDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinition(string fieldDefinitionName, string fieldDefinitionDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FieldDefinitionName = fieldDefinitionName;
            this.FieldDefinitionDisplayName = fieldDefinitionDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FieldDefinition CreateNewBlank()
        {
            return new FieldDefinition(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FieldDefinitionDatas.Any() || (FieldDefinitionDefault != null);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FieldDefinition).Name, typeof(FieldDefinitionData).Name, typeof(FieldDefinitionDefault).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.FieldDefinitions.Remove(this);
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

            foreach(var x in FieldDefinitionDatas.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FieldDefinitionDefaults.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FieldDefinitionID { get; set; }
        public string FieldDefinitionName { get; set; }
        public string FieldDefinitionDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FieldDefinitionID; } set { FieldDefinitionID = value; } }

        public virtual ICollection<FieldDefinitionData> FieldDefinitionDatas { get; set; }
        public virtual ICollection<FieldDefinitionDefault> FieldDefinitionDefaults { get; set; }
        [NotMapped]
        public FieldDefinitionDefault FieldDefinitionDefault { get { return FieldDefinitionDefaults.SingleOrDefault(); } set { FieldDefinitionDefaults = new List<FieldDefinitionDefault>{value};} }

        public static class FieldLengths
        {
            public const int FieldDefinitionName = 300;
            public const int FieldDefinitionDisplayName = 300;
        }
    }

    
    public enum FieldDefinitionEnum
    {
        TaxonomyLeaf = 1,
        ExpectedValue = 4,
        TaxonomyTrunk = 5,
        FundingSource = 8,
        IsPrimaryContactOrganization = 12,
        ProjectsStewardOrganizationRelationshipToProject = 13,
        Organization = 14,
        Password = 17,
        PerformanceMeasure = 18,
        PerformanceMeasureType = 19,
        MeasurementUnit = 21,
        PhotoCaption = 22,
        PhotoCredit = 23,
        PhotoTiming = 24,
        OrganizationPrimaryContact = 25,
        TaxonomyBranch = 26,
        CompletionYear = 28,
        ProjectDescription = 29,
        ProjectName = 30,
        ProjectNote = 31,
        ImplementationStartYear = 32,
        ReportedValue = 33,
        OrganizationType = 34,
        SecuredFunding = 35,
        ProjectStage = 36,
        ClassificationName = 39,
        EstimatedTotalCost = 40,
        NoFundingSourceIdentified = 41,
        Username = 42,
        Project = 44,
        Classification = 46,
        PerformanceMeasureSubcategory = 49,
        PerformanceMeasureSubcategoryOption = 50,
        FundedAmount = 56,
        ProjectLocation = 57,
        IncludeInFactSheet = 64,
        FundingType = 73,
        ProjectCostInYearOfExpenditure = 74,
        GlobalInflationRate = 75,
        ReportingYear = 76,
        TagName = 77,
        TagDescription = 78,
        ReportedExpenditure = 80,
        Proposal = 81,
        SpendingAssociatedWithPM = 85,
        PlanningDesignStartYear = 86,
        AssociatedTaxonomyBranches = 87,
        ExternalLinks = 88,
        EstimatedAnnualOperatingCost = 89,
        CalculatedTotalRemainingOperatingCost = 90,
        CurrentYearForPVCalculations = 91,
        LifecycleOperatingCost = 92,
        PerformanceMeasureChartTitle = 97,
        RoleName = 182,
        Region = 184,
        PerformanceMeasureChartCaption = 228,
        MonitoringProgram = 236,
        MonitoringApproach = 237,
        MonitoringProgramPartner = 238,
        MonitoringProgramUrl = 239,
        ClassificationDescription = 240,
        ClassificationGoalStatement = 241,
        ClassificationNarrative = 242,
        TaxonomySystemName = 243,
        TaxonomyLeafDisplayNameForProject = 244,
        ProjectOrganizationRelationshipType = 245,
        ProjectSteward = 246,
        TargetedFunding = 248,
        ProjectStewardOrganizationDisplayName = 249,
        ClassificationSystem = 250,
        ClassificationSystemName = 251,
        ProjectPrimaryContact = 252,
        TaxonomyTrunkDescription = 254,
        TaxonomyBranchDescription = 255,
        TaxonomyLeafDescription = 256,
        ShowProposalsToThePublic = 257,
        ShowLeadImplementerLogoOnFactSheet = 258,
        ProjectCustomAttribute = 259,
        ProjectCustomAttributeDataType = 260,
        ReportingPeriodKickOffDate = 261,
        ProjectUpdateReminderInterval = 262,
        ReportingPeriodCloseOutDate = 263,
        PerformanceMeasureIsSummable = 264,
        FundingSourceAmount = 265,
        NormalUser = 266,
        ProjectStewardshipArea = 267,
        ProjectInternalNote = 268,
        SecondaryProjectTaxonomyLeaf = 269,
        ProjectPrimaryContactEmail = 270,
        ProjectCustomAttributeTypeEditableBy = 271,
        ProjectCustomAttributeTypeViewableBy = 272,
        OrganizationTypeAbbreviation = 273,
        LegendColor = 274,
        ShowOnProjectMaps = 275,
        IsDefaultOrganizationType = 276,
        IsFundingType = 277,
        SignificantDigits = 278,
        TenantShortDisplayName = 279,
        ToolDisplayName = 280,
        TenantSquareLogo = 281,
        FundingSourceCustomAttribute = 282,
        FundingSourceCustomAttributeDataType = 283,
        FundingSourceCustomAttributeTypeEditableBy = 284,
        FundingSourceCustomAttributeTypeViewableBy = 285,
        ContactType = 286,
        ContactTypeAbbreviation = 287,
        IsDefaultContactType = 288,
        ProjectContactRelationshipType = 289,
        CostType = 290,
        AttachmentType = 291,
        ProjectID = 292,
        ExcludeTargetedFundingOrganizations = 293,
        ProjectCustomAttributeGroup = 294,
        ProjectLastUpdated = 295,
        NumberOfProjectsWithExpendedFunds = 296,
        TotalExpenditures = 297,
        NumberOfProjectsWithSecuredFunds = 298,
        TotalProjectSecuredFunds = 299,
        TotalProjectTargetedFunds = 300,
        PerformanceMeasureCanBeChartedCumulatively = 301,
        Status = 302,
        StatusUpdate = 303,
        StatusHistory = 304,
        UpdateHistory = 305,
        StatusLegend = 306,
        StatusUpdateCreatedBy = 307,
        StatusUpdateDate = 308,
        StatusComments = 309,
        GeospatialArea = 310,
        ArcGISFileGeodatabase = 311,
        KMLFile = 312,
        ExternalReferenceLayer = 313,
        ExternalMapLayerDisplayName = 314,
        ExternalMapLayerUrl = 315,
        ExternalMapLayerDescription = 316,
        ExternalMapLayerFeatureNameField = 317,
        ExternalMapLayerDisplayOnAllMaps = 318,
        GeospatialAreaTypeOnByDefaultOnProjectMap = 319,
        ExternalMapLayerIsActive = 320,
        ExternalMapLayerIsATiledMapService = 321,
        FinalStatusUpdateStatus = 322,
        IsFinalStatusUpdate = 323,
        StatusLessonsLearned = 324,
        Evaluation = 325,
        EvaluationCriteria = 326,
        EvaluationCriteriaValue = 327,
        EvaluationPortfolio = 328,
        ProjectEvaluation = 329,
        EvaluationName = 330,
        EvaluationDefinition = 331,
        EvaluationStatus = 332,
        EvaluationStartDate = 333,
        EvaluationEndDate = 334,
        EvaluationVisibility = 335,
        EvaluationCriteriaName = 336,
        EvaluationCriteriaDefinition = 337,
        EnableProjectEvaluations = 338,
        UseProjectTimeline = 339,
        ProjectCategory = 340,
        EnableProjectCategory = 341,
        EnableReports = 342,
        ReportTitle = 343,
        ReportDescription = 344,
        ReportFile = 345,
        ReportModel = 346,
        SelectedReportTemplate = 347,
        FactSheetCustomText = 348,
        FactSheetLogo = 349,
        IsContactRelationshipTypeRequired = 350,
        IsOrganizationRelationshipTypeRequired = 351,
        SyncWithKeystoneOnSave = 352,
        DocumentLibraryName = 353,
        KMZFile = 354,
        DocumentLibrary = 355,
        DocumentLibraryDocumentViewableBy = 356,
        CustomPageViewableBy = 357,
        EnableMatchmaker = 358,
        GeospatialAreaMapLayerDisplayAsReferenceLayer = 359,
        MatchScore = 360,
        OrganizationCash = 361,
        OrganizationInKindServices = 362,
        OrganizationCommercialServices = 363,
        AreaOfInterest = 364,
        MatchmakerKeyword = 365,
        OrganizationKeystoneGuid = 366,
        ContactRelationshipTypeAcceptsMultipleValues = 367,
        OrganizationTypeLayerOnByDefault = 368,
        GeospatialAreaTypeOnByDefaultOnOtherMaps = 369,
        ProjectLocationIsPrivate = 370,
        CanContactTypeManageProject = 371,
        TrackAccomplishments = 372,
        ShowExpectedPerformanceMeasuresOnFactSheet = 373,
        Solicitation = 374,
        EnableSolicitations = 375,
        OtherPartners = 376,
        PerformanceMeasureGroup = 377,
        TrainingVideoUploadDate = 378,
        TrainingVideoUrl = 379,
        SetTargetsByGeospatialArea = 380,
        QuickAccessAttachment = 381,
        AboutMenu = 382,
        ProjectsMenu = 383,
        ProgramInfoMenu = 384,
        ResultsMenu = 385,
        ReportsMenu = 386,
        EnableSimpleAccomplishmentsDashboard = 387,
        TrainingVideoViewableBy = 388
    }
}