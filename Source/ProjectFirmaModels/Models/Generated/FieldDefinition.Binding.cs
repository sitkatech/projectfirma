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
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : this()
        {
            this.FieldDefinitionID = fieldDefinitionID;
            this.FieldDefinitionName = fieldDefinitionName;
            this.FieldDefinitionDisplayName = fieldDefinitionDisplayName;
            this.DefaultDefinition = defaultDefinition;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FieldDefinition(string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FieldDefinitionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FieldDefinitionName = fieldDefinitionName;
            this.FieldDefinitionDisplayName = fieldDefinitionDisplayName;
            this.DefaultDefinition = defaultDefinition;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FieldDefinition CreateNewBlank()
        {
            return new FieldDefinition(default(string), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FieldDefinitionDatas.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FieldDefinition).Name, typeof(FieldDefinitionData).Name};


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
        }

        [Key]
        public int FieldDefinitionID { get; set; }
        public string FieldDefinitionName { get; set; }
        public string FieldDefinitionDisplayName { get; set; }
        public string DefaultDefinition { get; set; }
        [NotMapped]
        public HtmlString DefaultDefinitionHtmlString
        { 
            get { return DefaultDefinition == null ? null : new HtmlString(DefaultDefinition); }
            set { DefaultDefinition = value?.ToString(); }
        }
        [NotMapped]
        public int PrimaryKey { get { return FieldDefinitionID; } set { FieldDefinitionID = value; } }

        public virtual ICollection<FieldDefinitionData> FieldDefinitionDatas { get; set; }

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
        ExcludeFromFactSheet = 64,
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
        ProjectRelationshipType = 245,
        ProjectSteward = 246,
        TargetedFunding = 248,
        ProjectStewardOrganizationDisplayName = 249,
        ClassificationSystem = 250,
        ClassificationSystemName = 251,
        ProjectPrimaryContact = 252,
        CustomPageDisplayType = 253,
        TaxonomyTrunkDescription = 254,
        TaxonomyBranchDescription = 255,
        TaxonomyLeafDescription = 256,
        ShowProposalsToThePublic = 257,
        ShowLeadImplementerLogoOnFactSheet = 258,
        ProjectCustomAttribute = 259,
        ProjectCustomAttributeDataType = 260,
        ProjectUpdateKickOffDate = 261,
        ProjectUpdateReminderInterval = 262,
        ProjectUpdateCloseOutDate = 263,
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
        FundingSourceCustomAttributeTypeViewableBy = 285
    }
}