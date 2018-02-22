//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinition]
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
    public abstract partial class FieldDefinition : IHavePrimaryKey
    {
        public static readonly FieldDefinitionTaxonomyTierOne TaxonomyTierOne = FieldDefinitionTaxonomyTierOne.Instance;
        public static readonly FieldDefinitionExpectedValue ExpectedValue = FieldDefinitionExpectedValue.Instance;
        public static readonly FieldDefinitionTaxonomyTierThree TaxonomyTierThree = FieldDefinitionTaxonomyTierThree.Instance;
        public static readonly FieldDefinitionFundingSource FundingSource = FieldDefinitionFundingSource.Instance;
        public static readonly FieldDefinitionIsPrimaryContactOrganization IsPrimaryContactOrganization = FieldDefinitionIsPrimaryContactOrganization.Instance;
        public static readonly FieldDefinitionProjectsStewardOrganizationRelationshipToProject ProjectsStewardOrganizationRelationshipToProject = FieldDefinitionProjectsStewardOrganizationRelationshipToProject.Instance;
        public static readonly FieldDefinitionOrganization Organization = FieldDefinitionOrganization.Instance;
        public static readonly FieldDefinitionPassword Password = FieldDefinitionPassword.Instance;
        public static readonly FieldDefinitionPerformanceMeasure PerformanceMeasure = FieldDefinitionPerformanceMeasure.Instance;
        public static readonly FieldDefinitionPerformanceMeasureType PerformanceMeasureType = FieldDefinitionPerformanceMeasureType.Instance;
        public static readonly FieldDefinitionMeasurementUnit MeasurementUnit = FieldDefinitionMeasurementUnit.Instance;
        public static readonly FieldDefinitionPhotoCaption PhotoCaption = FieldDefinitionPhotoCaption.Instance;
        public static readonly FieldDefinitionPhotoCredit PhotoCredit = FieldDefinitionPhotoCredit.Instance;
        public static readonly FieldDefinitionPhotoTiming PhotoTiming = FieldDefinitionPhotoTiming.Instance;
        public static readonly FieldDefinitionPrimaryContact PrimaryContact = FieldDefinitionPrimaryContact.Instance;
        public static readonly FieldDefinitionTaxonomyTierTwo TaxonomyTierTwo = FieldDefinitionTaxonomyTierTwo.Instance;
        public static readonly FieldDefinitionCompletionYear CompletionYear = FieldDefinitionCompletionYear.Instance;
        public static readonly FieldDefinitionProjectDescription ProjectDescription = FieldDefinitionProjectDescription.Instance;
        public static readonly FieldDefinitionProjectName ProjectName = FieldDefinitionProjectName.Instance;
        public static readonly FieldDefinitionProjectNote ProjectNote = FieldDefinitionProjectNote.Instance;
        public static readonly FieldDefinitionImplementationStartYear ImplementationStartYear = FieldDefinitionImplementationStartYear.Instance;
        public static readonly FieldDefinitionReportedValue ReportedValue = FieldDefinitionReportedValue.Instance;
        public static readonly FieldDefinitionOrganizationType OrganizationType = FieldDefinitionOrganizationType.Instance;
        public static readonly FieldDefinitionSecuredFunding SecuredFunding = FieldDefinitionSecuredFunding.Instance;
        public static readonly FieldDefinitionProjectStage ProjectStage = FieldDefinitionProjectStage.Instance;
        public static readonly FieldDefinitionClassificationName ClassificationName = FieldDefinitionClassificationName.Instance;
        public static readonly FieldDefinitionEstimatedTotalCost EstimatedTotalCost = FieldDefinitionEstimatedTotalCost.Instance;
        public static readonly FieldDefinitionUnfundedNeed UnfundedNeed = FieldDefinitionUnfundedNeed.Instance;
        public static readonly FieldDefinitionUsername Username = FieldDefinitionUsername.Instance;
        public static readonly FieldDefinitionProject Project = FieldDefinitionProject.Instance;
        public static readonly FieldDefinitionClassification Classification = FieldDefinitionClassification.Instance;
        public static readonly FieldDefinitionWatershed Watershed = FieldDefinitionWatershed.Instance;
        public static readonly FieldDefinitionPerformanceMeasureSubcategory PerformanceMeasureSubcategory = FieldDefinitionPerformanceMeasureSubcategory.Instance;
        public static readonly FieldDefinitionPerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption = FieldDefinitionPerformanceMeasureSubcategoryOption.Instance;
        public static readonly FieldDefinitionIsPrimaryTaxonomyTierTwo IsPrimaryTaxonomyTierTwo = FieldDefinitionIsPrimaryTaxonomyTierTwo.Instance;
        public static readonly FieldDefinitionFundedAmount FundedAmount = FieldDefinitionFundedAmount.Instance;
        public static readonly FieldDefinitionProjectLocation ProjectLocation = FieldDefinitionProjectLocation.Instance;
        public static readonly FieldDefinitionExcludeFromFactSheet ExcludeFromFactSheet = FieldDefinitionExcludeFromFactSheet.Instance;
        public static readonly FieldDefinitionFundingType FundingType = FieldDefinitionFundingType.Instance;
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure ProjectCostInYearOfExpenditure = FieldDefinitionProjectCostInYearOfExpenditure.Instance;
        public static readonly FieldDefinitionGlobalInflationRate GlobalInflationRate = FieldDefinitionGlobalInflationRate.Instance;
        public static readonly FieldDefinitionReportingYear ReportingYear = FieldDefinitionReportingYear.Instance;
        public static readonly FieldDefinitionTagName TagName = FieldDefinitionTagName.Instance;
        public static readonly FieldDefinitionTagDescription TagDescription = FieldDefinitionTagDescription.Instance;
        public static readonly FieldDefinitionReportedExpenditure ReportedExpenditure = FieldDefinitionReportedExpenditure.Instance;
        public static readonly FieldDefinitionProposal Proposal = FieldDefinitionProposal.Instance;
        public static readonly FieldDefinitionSpendingAssociatedWithPM SpendingAssociatedWithPM = FieldDefinitionSpendingAssociatedWithPM.Instance;
        public static readonly FieldDefinitionPlanningDesignStartYear PlanningDesignStartYear = FieldDefinitionPlanningDesignStartYear.Instance;
        public static readonly FieldDefinitionAssociatedTaxonomyTierTwos AssociatedTaxonomyTierTwos = FieldDefinitionAssociatedTaxonomyTierTwos.Instance;
        public static readonly FieldDefinitionExternalLinks ExternalLinks = FieldDefinitionExternalLinks.Instance;
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost EstimatedAnnualOperatingCost = FieldDefinitionEstimatedAnnualOperatingCost.Instance;
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost CalculatedTotalRemainingOperatingCost = FieldDefinitionCalculatedTotalRemainingOperatingCost.Instance;
        public static readonly FieldDefinitionCurrentYearForPVCalculations CurrentYearForPVCalculations = FieldDefinitionCurrentYearForPVCalculations.Instance;
        public static readonly FieldDefinitionLifecycleOperatingCost LifecycleOperatingCost = FieldDefinitionLifecycleOperatingCost.Instance;
        public static readonly FieldDefinitionPerformanceMeasureChartTitle PerformanceMeasureChartTitle = FieldDefinitionPerformanceMeasureChartTitle.Instance;
        public static readonly FieldDefinitionRoleName RoleName = FieldDefinitionRoleName.Instance;
        public static readonly FieldDefinitionRegion Region = FieldDefinitionRegion.Instance;
        public static readonly FieldDefinitionPerformanceMeasureChartCaption PerformanceMeasureChartCaption = FieldDefinitionPerformanceMeasureChartCaption.Instance;
        public static readonly FieldDefinitionMonitoringProgram MonitoringProgram = FieldDefinitionMonitoringProgram.Instance;
        public static readonly FieldDefinitionMonitoringApproach MonitoringApproach = FieldDefinitionMonitoringApproach.Instance;
        public static readonly FieldDefinitionMonitoringProgramPartner MonitoringProgramPartner = FieldDefinitionMonitoringProgramPartner.Instance;
        public static readonly FieldDefinitionMonitoringProgramUrl MonitoringProgramUrl = FieldDefinitionMonitoringProgramUrl.Instance;
        public static readonly FieldDefinitionClassificationDescription ClassificationDescription = FieldDefinitionClassificationDescription.Instance;
        public static readonly FieldDefinitionClassificationGoalStatement ClassificationGoalStatement = FieldDefinitionClassificationGoalStatement.Instance;
        public static readonly FieldDefinitionClassificationNarrative ClassificationNarrative = FieldDefinitionClassificationNarrative.Instance;
        public static readonly FieldDefinitionTaxonomySystemName TaxonomySystemName = FieldDefinitionTaxonomySystemName.Instance;
        public static readonly FieldDefinitionTaxonomyTierOneDisplayNameForProject TaxonomyTierOneDisplayNameForProject = FieldDefinitionTaxonomyTierOneDisplayNameForProject.Instance;
        public static readonly FieldDefinitionProjectRelationshipType ProjectRelationshipType = FieldDefinitionProjectRelationshipType.Instance;
        public static readonly FieldDefinitionProjectSteward ProjectSteward = FieldDefinitionProjectSteward.Instance;
        public static readonly FieldDefinitionChartLastUpdatedDate ChartLastUpdatedDate = FieldDefinitionChartLastUpdatedDate.Instance;
        public static readonly FieldDefinitionUnsecuredFunding UnsecuredFunding = FieldDefinitionUnsecuredFunding.Instance;
        public static readonly FieldDefinitionProjectStewardOrganizationDisplayName ProjectStewardOrganizationDisplayName = FieldDefinitionProjectStewardOrganizationDisplayName.Instance;
        public static readonly FieldDefinitionClassificationSystem ClassificationSystem = FieldDefinitionClassificationSystem.Instance;
        public static readonly FieldDefinitionClassificationSystemName ClassificationSystemName = FieldDefinitionClassificationSystemName.Instance;

        public static readonly List<FieldDefinition> All;
        public static readonly ReadOnlyDictionary<int, FieldDefinition> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FieldDefinition()
        {
            All = new List<FieldDefinition> { TaxonomyTierOne, ExpectedValue, TaxonomyTierThree, FundingSource, IsPrimaryContactOrganization, ProjectsStewardOrganizationRelationshipToProject, Organization, Password, PerformanceMeasure, PerformanceMeasureType, MeasurementUnit, PhotoCaption, PhotoCredit, PhotoTiming, PrimaryContact, TaxonomyTierTwo, CompletionYear, ProjectDescription, ProjectName, ProjectNote, ImplementationStartYear, ReportedValue, OrganizationType, SecuredFunding, ProjectStage, ClassificationName, EstimatedTotalCost, UnfundedNeed, Username, Project, Classification, Watershed, PerformanceMeasureSubcategory, PerformanceMeasureSubcategoryOption, IsPrimaryTaxonomyTierTwo, FundedAmount, ProjectLocation, ExcludeFromFactSheet, FundingType, ProjectCostInYearOfExpenditure, GlobalInflationRate, ReportingYear, TagName, TagDescription, ReportedExpenditure, Proposal, SpendingAssociatedWithPM, PlanningDesignStartYear, AssociatedTaxonomyTierTwos, ExternalLinks, EstimatedAnnualOperatingCost, CalculatedTotalRemainingOperatingCost, CurrentYearForPVCalculations, LifecycleOperatingCost, PerformanceMeasureChartTitle, RoleName, Region, PerformanceMeasureChartCaption, MonitoringProgram, MonitoringApproach, MonitoringProgramPartner, MonitoringProgramUrl, ClassificationDescription, ClassificationGoalStatement, ClassificationNarrative, TaxonomySystemName, TaxonomyTierOneDisplayNameForProject, ProjectRelationshipType, ProjectSteward, ChartLastUpdatedDate, UnsecuredFunding, ProjectStewardOrganizationDisplayName, ClassificationSystem, ClassificationSystemName };
            AllLookupDictionary = new ReadOnlyDictionary<int, FieldDefinition>(All.ToDictionary(x => x.FieldDefinitionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FieldDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel)
        {
            FieldDefinitionID = fieldDefinitionID;
            FieldDefinitionName = fieldDefinitionName;
            FieldDefinitionDisplayName = fieldDefinitionDisplayName;
            DefaultDefinition = defaultDefinition;
            CanCustomizeLabel = canCustomizeLabel;
        }

        [Key]
        public int FieldDefinitionID { get; private set; }
        public string FieldDefinitionName { get; private set; }
        public string FieldDefinitionDisplayName { get; private set; }
        public string DefaultDefinition { get; set; }
        [NotMapped]
        public HtmlString DefaultDefinitionHtmlString
        { 
            get { return DefaultDefinition == null ? null : new HtmlString(DefaultDefinition); }
            set { DefaultDefinition = value?.ToString(); }
        }
        public bool CanCustomizeLabel { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FieldDefinitionID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FieldDefinition other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FieldDefinitionID == FieldDefinitionID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FieldDefinition);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FieldDefinitionID;
        }

        public static bool operator ==(FieldDefinition left, FieldDefinition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FieldDefinition left, FieldDefinition right)
        {
            return !Equals(left, right);
        }

        public FieldDefinitionEnum ToEnum { get { return (FieldDefinitionEnum)GetHashCode(); } }

        public static FieldDefinition ToType(int enumValue)
        {
            return ToType((FieldDefinitionEnum)enumValue);
        }

        public static FieldDefinition ToType(FieldDefinitionEnum enumValue)
        {
            switch (enumValue)
            {
                case FieldDefinitionEnum.AssociatedTaxonomyTierTwos:
                    return AssociatedTaxonomyTierTwos;
                case FieldDefinitionEnum.CalculatedTotalRemainingOperatingCost:
                    return CalculatedTotalRemainingOperatingCost;
                case FieldDefinitionEnum.ChartLastUpdatedDate:
                    return ChartLastUpdatedDate;
                case FieldDefinitionEnum.Classification:
                    return Classification;
                case FieldDefinitionEnum.ClassificationDescription:
                    return ClassificationDescription;
                case FieldDefinitionEnum.ClassificationGoalStatement:
                    return ClassificationGoalStatement;
                case FieldDefinitionEnum.ClassificationName:
                    return ClassificationName;
                case FieldDefinitionEnum.ClassificationNarrative:
                    return ClassificationNarrative;
                case FieldDefinitionEnum.ClassificationSystem:
                    return ClassificationSystem;
                case FieldDefinitionEnum.ClassificationSystemName:
                    return ClassificationSystemName;
                case FieldDefinitionEnum.CompletionYear:
                    return CompletionYear;
                case FieldDefinitionEnum.CurrentYearForPVCalculations:
                    return CurrentYearForPVCalculations;
                case FieldDefinitionEnum.EstimatedAnnualOperatingCost:
                    return EstimatedAnnualOperatingCost;
                case FieldDefinitionEnum.EstimatedTotalCost:
                    return EstimatedTotalCost;
                case FieldDefinitionEnum.ExcludeFromFactSheet:
                    return ExcludeFromFactSheet;
                case FieldDefinitionEnum.ExpectedValue:
                    return ExpectedValue;
                case FieldDefinitionEnum.ExternalLinks:
                    return ExternalLinks;
                case FieldDefinitionEnum.FundedAmount:
                    return FundedAmount;
                case FieldDefinitionEnum.FundingSource:
                    return FundingSource;
                case FieldDefinitionEnum.FundingType:
                    return FundingType;
                case FieldDefinitionEnum.GlobalInflationRate:
                    return GlobalInflationRate;
                case FieldDefinitionEnum.ImplementationStartYear:
                    return ImplementationStartYear;
                case FieldDefinitionEnum.IsPrimaryContactOrganization:
                    return IsPrimaryContactOrganization;
                case FieldDefinitionEnum.IsPrimaryTaxonomyTierTwo:
                    return IsPrimaryTaxonomyTierTwo;
                case FieldDefinitionEnum.LifecycleOperatingCost:
                    return LifecycleOperatingCost;
                case FieldDefinitionEnum.MeasurementUnit:
                    return MeasurementUnit;
                case FieldDefinitionEnum.MonitoringApproach:
                    return MonitoringApproach;
                case FieldDefinitionEnum.MonitoringProgram:
                    return MonitoringProgram;
                case FieldDefinitionEnum.MonitoringProgramPartner:
                    return MonitoringProgramPartner;
                case FieldDefinitionEnum.MonitoringProgramUrl:
                    return MonitoringProgramUrl;
                case FieldDefinitionEnum.Organization:
                    return Organization;
                case FieldDefinitionEnum.OrganizationType:
                    return OrganizationType;
                case FieldDefinitionEnum.Password:
                    return Password;
                case FieldDefinitionEnum.PerformanceMeasure:
                    return PerformanceMeasure;
                case FieldDefinitionEnum.PerformanceMeasureChartCaption:
                    return PerformanceMeasureChartCaption;
                case FieldDefinitionEnum.PerformanceMeasureChartTitle:
                    return PerformanceMeasureChartTitle;
                case FieldDefinitionEnum.PerformanceMeasureSubcategory:
                    return PerformanceMeasureSubcategory;
                case FieldDefinitionEnum.PerformanceMeasureSubcategoryOption:
                    return PerformanceMeasureSubcategoryOption;
                case FieldDefinitionEnum.PerformanceMeasureType:
                    return PerformanceMeasureType;
                case FieldDefinitionEnum.PhotoCaption:
                    return PhotoCaption;
                case FieldDefinitionEnum.PhotoCredit:
                    return PhotoCredit;
                case FieldDefinitionEnum.PhotoTiming:
                    return PhotoTiming;
                case FieldDefinitionEnum.PlanningDesignStartYear:
                    return PlanningDesignStartYear;
                case FieldDefinitionEnum.PrimaryContact:
                    return PrimaryContact;
                case FieldDefinitionEnum.Project:
                    return Project;
                case FieldDefinitionEnum.ProjectCostInYearOfExpenditure:
                    return ProjectCostInYearOfExpenditure;
                case FieldDefinitionEnum.ProjectDescription:
                    return ProjectDescription;
                case FieldDefinitionEnum.ProjectLocation:
                    return ProjectLocation;
                case FieldDefinitionEnum.ProjectName:
                    return ProjectName;
                case FieldDefinitionEnum.ProjectNote:
                    return ProjectNote;
                case FieldDefinitionEnum.ProjectRelationshipType:
                    return ProjectRelationshipType;
                case FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject:
                    return ProjectsStewardOrganizationRelationshipToProject;
                case FieldDefinitionEnum.ProjectStage:
                    return ProjectStage;
                case FieldDefinitionEnum.ProjectSteward:
                    return ProjectSteward;
                case FieldDefinitionEnum.ProjectStewardOrganizationDisplayName:
                    return ProjectStewardOrganizationDisplayName;
                case FieldDefinitionEnum.Proposal:
                    return Proposal;
                case FieldDefinitionEnum.Region:
                    return Region;
                case FieldDefinitionEnum.ReportedExpenditure:
                    return ReportedExpenditure;
                case FieldDefinitionEnum.ReportedValue:
                    return ReportedValue;
                case FieldDefinitionEnum.ReportingYear:
                    return ReportingYear;
                case FieldDefinitionEnum.RoleName:
                    return RoleName;
                case FieldDefinitionEnum.SecuredFunding:
                    return SecuredFunding;
                case FieldDefinitionEnum.SpendingAssociatedWithPM:
                    return SpendingAssociatedWithPM;
                case FieldDefinitionEnum.TagDescription:
                    return TagDescription;
                case FieldDefinitionEnum.TagName:
                    return TagName;
                case FieldDefinitionEnum.TaxonomySystemName:
                    return TaxonomySystemName;
                case FieldDefinitionEnum.TaxonomyTierOne:
                    return TaxonomyTierOne;
                case FieldDefinitionEnum.TaxonomyTierOneDisplayNameForProject:
                    return TaxonomyTierOneDisplayNameForProject;
                case FieldDefinitionEnum.TaxonomyTierThree:
                    return TaxonomyTierThree;
                case FieldDefinitionEnum.TaxonomyTierTwo:
                    return TaxonomyTierTwo;
                case FieldDefinitionEnum.UnfundedNeed:
                    return UnfundedNeed;
                case FieldDefinitionEnum.UnsecuredFunding:
                    return UnsecuredFunding;
                case FieldDefinitionEnum.Username:
                    return Username;
                case FieldDefinitionEnum.Watershed:
                    return Watershed;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FieldDefinitionEnum
    {
        TaxonomyTierOne = 1,
        ExpectedValue = 4,
        TaxonomyTierThree = 5,
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
        PrimaryContact = 25,
        TaxonomyTierTwo = 26,
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
        UnfundedNeed = 41,
        Username = 42,
        Project = 44,
        Classification = 46,
        Watershed = 48,
        PerformanceMeasureSubcategory = 49,
        PerformanceMeasureSubcategoryOption = 50,
        IsPrimaryTaxonomyTierTwo = 52,
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
        AssociatedTaxonomyTierTwos = 87,
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
        TaxonomyTierOneDisplayNameForProject = 244,
        ProjectRelationshipType = 245,
        ProjectSteward = 246,
        ChartLastUpdatedDate = 247,
        UnsecuredFunding = 248,
        ProjectStewardOrganizationDisplayName = 249,
        ClassificationSystem = 250,
        ClassificationSystemName = 251
    }

    public partial class FieldDefinitionTaxonomyTierOne : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierOne(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionTaxonomyTierOne Instance = new FieldDefinitionTaxonomyTierOne(1, @"TaxonomyTierOne", @"Taxonomy Tier One", @"<p>The highest level record in the hierarchical project taxonomy system.</p>", true);
    }

    public partial class FieldDefinitionExpectedValue : FieldDefinition
    {
        private FieldDefinitionExpectedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionExpectedValue Instance = new FieldDefinitionExpectedValue(4, @"ExpectedValue", @"Expected Value", @"<p>The estimated cumulative Performance Measure value that the project or program is projected to achieve after implementation.</p>", true);
    }

    public partial class FieldDefinitionTaxonomyTierThree : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierThree(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionTaxonomyTierThree Instance = new FieldDefinitionTaxonomyTierThree(5, @"TaxonomyTierThree", @"Taxonomy Tier Three", @"<p>The lowest level record in the hierarchical project taxonomy system.</p>", true);
    }

    public partial class FieldDefinitionFundingSource : FieldDefinition
    {
        private FieldDefinitionFundingSource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionFundingSource Instance = new FieldDefinitionFundingSource(8, @"FundingSource", @"Funding Source", @"<p>The institution, fund, legislation or bond from which funds for the project were provided.</p>", true);
    }

    public partial class FieldDefinitionIsPrimaryContactOrganization : FieldDefinition
    {
        private FieldDefinitionIsPrimaryContactOrganization(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionIsPrimaryContactOrganization Instance = new FieldDefinitionIsPrimaryContactOrganization(12, @"IsPrimaryContactOrganization", @"Is Primary Contact Organization", @"<p>The entity with primary responsibility for organizing, planning, and executing implementation activities for a project or program. This is usually the lead implementer.</p>", true);
    }

    public partial class FieldDefinitionProjectsStewardOrganizationRelationshipToProject : FieldDefinition
    {
        private FieldDefinitionProjectsStewardOrganizationRelationshipToProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectsStewardOrganizationRelationshipToProject Instance = new FieldDefinitionProjectsStewardOrganizationRelationshipToProject(13, @"ProjectsStewardOrganizationRelationshipToProject", @"Projects Steward Organization Relationship To Project", @"<p>The relationship between a stewarding organization and a project.</p>", true);
    }

    public partial class FieldDefinitionOrganization : FieldDefinition
    {
        private FieldDefinitionOrganization(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionOrganization Instance = new FieldDefinitionOrganization(14, @"Organization", @"Organization", @"<p>A partner entity that is directly involved with implementation or funding a project.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionPassword : FieldDefinition
    {
        private FieldDefinitionPassword(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPassword Instance = new FieldDefinitionPassword(17, @"Password", @"Password", @"<p>Password required to log into the ProjectFirma tool in order to access and edit project and program information.</p>", false);
    }

    public partial class FieldDefinitionPerformanceMeasure : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPerformanceMeasure Instance = new FieldDefinitionPerformanceMeasure(18, @"PerformanceMeasure", @"Performance Measure", @"<p>A consistent and targeted method to track actions taken through completed projects to improve the environment. Also known as &quot;Indicators.&quot;&nbsp;</p>", true);
    }

    public partial class FieldDefinitionPerformanceMeasureType : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPerformanceMeasureType Instance = new FieldDefinitionPerformanceMeasureType(19, @"PerformanceMeasureType", @"Performance Measure Type", @"<p>The type of a Performance Measure - either an Action or Outcome.</p>", true);
    }

    public partial class FieldDefinitionMeasurementUnit : FieldDefinition
    {
        private FieldDefinitionMeasurementUnit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionMeasurementUnit Instance = new FieldDefinitionMeasurementUnit(21, @"MeasurementUnit", @"Measurement Unit", @"<p>The unit of measure used by an Indicator (aka&nbsp;Performance Measure) to track the extent of implementation.</p>", true);
    }

    public partial class FieldDefinitionPhotoCaption : FieldDefinition
    {
        private FieldDefinitionPhotoCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPhotoCaption Instance = new FieldDefinitionPhotoCaption(22, @"PhotoCaption", @"Photo Caption", @"<p>A concise yet descriptive explanation of an uploaded photo. Photo captions are displayed in the lower right-hand corner of the image as it appears on the webpage.</p>", true);
    }

    public partial class FieldDefinitionPhotoCredit : FieldDefinition
    {
        private FieldDefinitionPhotoCredit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPhotoCredit Instance = new FieldDefinitionPhotoCredit(23, @"PhotoCredit", @"Photo Credit", @"<p>If needed, credit is given to the photographer or owner of an image on the website. Photo credits are displayed in the lower right-hand corner of the image as it appears on the webpage.</p>", true);
    }

    public partial class FieldDefinitionPhotoTiming : FieldDefinition
    {
        private FieldDefinitionPhotoTiming(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPhotoTiming Instance = new FieldDefinitionPhotoTiming(24, @"PhotoTiming", @"Photo Timing", @"<p>The phase in a project timeline during which the photograph was taken. Photo timing can be before, during or after project implementation.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionPrimaryContact : FieldDefinition
    {
        private FieldDefinitionPrimaryContact(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPrimaryContact Instance = new FieldDefinitionPrimaryContact(25, @"PrimaryContact", @"Primary Contact", @"<p>An individual at the listed organization responsible for reporting accomplishments and expenditures achieved by the project or program, and who should be contacted when there are questions related to any project associated to the organization.</p>", true);
    }

    public partial class FieldDefinitionTaxonomyTierTwo : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierTwo(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionTaxonomyTierTwo Instance = new FieldDefinitionTaxonomyTierTwo(26, @"TaxonomyTierTwo", @"Taxonomy Tier Two", @"<p>The second level record in the hierarchical project taxonomy system.</p>", true);
    }

    public partial class FieldDefinitionCompletionYear : FieldDefinition
    {
        private FieldDefinitionCompletionYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionCompletionYear Instance = new FieldDefinitionCompletionYear(28, @"CompletionYear", @"Completion Year", @"<p>The year implementation of the project was completed or is anticipated to be completed. Projects are considered &quot;complete&quot; when all activities have been performed, including post-implementation activities such as monitoring vegetation establishment, and all&nbsp;reporting requirements have been satisfied. &nbsp;For more detailed information, see the definition for &quot;Stage&quot;.</p>", true);
    }

    public partial class FieldDefinitionProjectDescription : FieldDefinition
    {
        private FieldDefinitionProjectDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectDescription Instance = new FieldDefinitionProjectDescription(29, @"ProjectDescription", @"Project Description", @"<p>A concise/brief description for the project that includes the following: general locations of project, project area size, purpose and need of the project, and expected goals. &nbsp;Please not that project descriptions will be capped at 100 words.</p>", true);
    }

    public partial class FieldDefinitionProjectName : FieldDefinition
    {
        private FieldDefinitionProjectName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectName Instance = new FieldDefinitionProjectName(30, @"ProjectName", @"Project Name", @"<p>The name of a project or program given by the organization responsible for reporting. Project names should generally include a reference to 1) the location of the project, 2) the primary implementation activity, and 3) the project phase (if a multi-phase project).</p>", true);
    }

    public partial class FieldDefinitionProjectNote : FieldDefinition
    {
        private FieldDefinitionProjectNote(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectNote Instance = new FieldDefinitionProjectNote(31, @"ProjectNote", @"Project Note", @"<p>Any important information about a project that would be useful to staff or project implementers.</p>", true);
    }

    public partial class FieldDefinitionImplementationStartYear : FieldDefinition
    {
        private FieldDefinitionImplementationStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionImplementationStartYear Instance = new FieldDefinitionImplementationStartYear(32, @"ImplementationStartYear", @"Implementation Start Year", @"<p>The year during which project construction or program implementation was started or is expected to be started. Contrast with &quot;Planning / Design Start Year.&quot; For more detailed information on implementation stages, see the definition for &quot;Stage&quot;.</p>", true);
    }

    public partial class FieldDefinitionReportedValue : FieldDefinition
    {
        private FieldDefinitionReportedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionReportedValue Instance = new FieldDefinitionReportedValue(33, @"ReportedValue", @"Reported Value", @"<p>The accomplishments achieved by a project after the accomplishments are realized. Accomplishments can be realized and reported throughout implementation and not only after the entire project is completed.</p>", true);
    }

    public partial class FieldDefinitionOrganizationType : FieldDefinition
    {
        private FieldDefinitionOrganizationType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionOrganizationType Instance = new FieldDefinitionOrganizationType(34, @"OrganizationType", @"Organization Type", @"<p>A categorization of an organization, e.g. Local, State, Federal or Private.</p>", true);
    }

    public partial class FieldDefinitionSecuredFunding : FieldDefinition
    {
        private FieldDefinitionSecuredFunding(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionSecuredFunding Instance = new FieldDefinitionSecuredFunding(35, @"SecuredFunding", @"Secured Funding", @"<p>Funding that has been acquired for a project but may not have necessarily been expended.</p>", true);
    }

    public partial class FieldDefinitionProjectStage : FieldDefinition
    {
        private FieldDefinitionProjectStage(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectStage Instance = new FieldDefinitionProjectStage(36, @"ProjectStage", @"Project Stage", @"<p>Where a project exists in the project life cycle - Planning/Design, Implementation, Complete, Terminated, etc.</p>", true);
    }

    public partial class FieldDefinitionClassificationName : FieldDefinition
    {
        private FieldDefinitionClassificationName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionClassificationName Instance = new FieldDefinitionClassificationName(39, @"ClassificationName", @"Classification Name", @"<p>The name of the grouping in this classification system.</p>", true);
    }

    public partial class FieldDefinitionEstimatedTotalCost : FieldDefinition
    {
        private FieldDefinitionEstimatedTotalCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionEstimatedTotalCost Instance = new FieldDefinitionEstimatedTotalCost(40, @"EstimatedTotalCost", @"Estimated Total Cost", @"<p>The total estimated cost to complete all stages of project implementation.</p>", true);
    }

    public partial class FieldDefinitionUnfundedNeed : FieldDefinition
    {
        private FieldDefinitionUnfundedNeed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionUnfundedNeed Instance = new FieldDefinitionUnfundedNeed(41, @"UnfundedNeed", @"Unfunded Need", @"<p>The difference between the Total Cost and Secured Funding for a project or program.</p>", true);
    }

    public partial class FieldDefinitionUsername : FieldDefinition
    {
        private FieldDefinitionUsername(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionUsername Instance = new FieldDefinitionUsername(42, @"Username", @"User name", @"<p>Password required to log into the system&nbsp;order to access and edit project and program information that is not allowed by public users.</p>", true);
    }

    public partial class FieldDefinitionProject : FieldDefinition
    {
        private FieldDefinitionProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProject Instance = new FieldDefinitionProject(44, @"Project", @"Project", @"<p>The core entity that ProjectFirma tracks - A collection of activities, with Performance Measures and Expenditures, that contribute to meeting program goals.</p>", false);
    }

    public partial class FieldDefinitionClassification : FieldDefinition
    {
        private FieldDefinitionClassification(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionClassification Instance = new FieldDefinitionClassification(46, @"Classification", @"Classification", @"<p>One of the groupings in a logical system used to group projects according to overarching program themes or goals.</p>", false);
    }

    public partial class FieldDefinitionWatershed : FieldDefinition
    {
        private FieldDefinitionWatershed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionWatershed Instance = new FieldDefinitionWatershed(48, @"Watershed", @"Watershed", @"<p>The watershed where the project or program is located.</p>", true);
    }

    public partial class FieldDefinitionPerformanceMeasureSubcategory : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureSubcategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPerformanceMeasureSubcategory Instance = new FieldDefinitionPerformanceMeasureSubcategory(49, @"PerformanceMeasureSubcategory", @"Performance Measure Subcategory", @"<p>The Performance Measure subcategory or subcategories that are relevant to the project. Subcategories are dimensions of a Performance Measure that are used to report performance measure accomplishments at a more granular level.</p>", true);
    }

    public partial class FieldDefinitionPerformanceMeasureSubcategoryOption : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureSubcategoryOption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPerformanceMeasureSubcategoryOption Instance = new FieldDefinitionPerformanceMeasureSubcategoryOption(50, @"PerformanceMeasureSubcategoryOption", @"Performance Measure Subcategory Option", @"<p>The selected attribute of a Performance Measure subcategory.</p>", true);
    }

    public partial class FieldDefinitionIsPrimaryTaxonomyTierTwo : FieldDefinition
    {
        private FieldDefinitionIsPrimaryTaxonomyTierTwo(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionIsPrimaryTaxonomyTierTwo Instance = new FieldDefinitionIsPrimaryTaxonomyTierTwo(52, @"IsPrimaryTaxonomyTierTwo", @"Is Primary Taxonomy Tier Two", @"<p>If this box is checked, this is the primary area associated with a specific Performance Measure. The performance measure may also apply to other areas but this has been identified as the primary area for this performance measure.</p>", true);
    }

    public partial class FieldDefinitionFundedAmount : FieldDefinition
    {
        private FieldDefinitionFundedAmount(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionFundedAmount Instance = new FieldDefinitionFundedAmount(56, @"FundedAmount", @"Funded Amount", @"<p>The amount of funding, by funding source, expended on a project for a specific year. To see the total amount of funding expended on a project, click on the specific project.</p>", true);
    }

    public partial class FieldDefinitionProjectLocation : FieldDefinition
    {
        private FieldDefinitionProjectLocation(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectLocation Instance = new FieldDefinitionProjectLocation(57, @"ProjectLocation", @"Project Location", @"<p>The location where the project was/is being implemented. Project locations can be set by picking a location description from a list or by plotting a point on the map. Project location information is used for summarizing project&nbsp;accomplishments by geospatial categories such as State, County, or Watershed.</p>", true);
    }

    public partial class FieldDefinitionExcludeFromFactSheet : FieldDefinition
    {
        private FieldDefinitionExcludeFromFactSheet(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionExcludeFromFactSheet Instance = new FieldDefinitionExcludeFromFactSheet(64, @"ExcludeFromFactSheet", @"Exclude from Fact Sheet", @"<p>Flags a photo so that it is not included in the photos shown on the project&#39;s Fact Sheet. Some projects have tons of photos -- use this checkbox to control which photos are included.</p>", true);
    }

    public partial class FieldDefinitionFundingType : FieldDefinition
    {
        private FieldDefinitionFundingType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionFundingType Instance = new FieldDefinitionFundingType(73, @"FundingType", @"Funding Type", @"<p>Field shows whether project is a capital (Capital) versus operations and maintenance (Operations and Maintenance) project.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionProjectCostInYearOfExpenditure : FieldDefinition
    {
        private FieldDefinitionProjectCostInYearOfExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure Instance = new FieldDefinitionProjectCostInYearOfExpenditure(74, @"ProjectCostInYearOfExpenditure", @"Cost in Year of Expenditure", @"<p>This is the expected cost of the project in the year that it will be constructed, taking into account inflation.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionGlobalInflationRate : FieldDefinition
    {
        private FieldDefinitionGlobalInflationRate(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionGlobalInflationRate Instance = new FieldDefinitionGlobalInflationRate(75, @"GlobalInflationRate", @"Global Inflation Rate", @"<p>Annual rate of inflation expected for project costs.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionReportingYear : FieldDefinition
    {
        private FieldDefinitionReportingYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionReportingYear Instance = new FieldDefinitionReportingYear(76, @"ReportingYear", @"Reporting Year", @"<p>The current year used for reporting purposes, which is defined as the previous calendar year until after November 1st of the present calendar year.</p>", true);
    }

    public partial class FieldDefinitionTagName : FieldDefinition
    {
        private FieldDefinitionTagName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionTagName Instance = new FieldDefinitionTagName(77, @"TagName", @"Tag Name", @"<p>A word or phrase for the tag. Keep it short, and if possible avoid spaces (use dashes or underscores) for cleaner URLs. Don&#39;t add tags for things already captured (e.g. the program under which the project lives).</p>", true);
    }

    public partial class FieldDefinitionTagDescription : FieldDefinition
    {
        private FieldDefinitionTagDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionTagDescription Instance = new FieldDefinitionTagDescription(78, @"TagDescription", @"Tag Description", @"<p>A description of what this tag will be used for. Ideally the description should include the name of the user that created it, and an expected timeframe for use of this tag, if known.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionReportedExpenditure : FieldDefinition
    {
        private FieldDefinitionReportedExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionReportedExpenditure Instance = new FieldDefinitionReportedExpenditure(80, @"ReportedExpenditure", @"Reported Expenditure", @"<p>An expenditure, tied to a Funding Source, as reported by the project implementer.</p>", true);
    }

    public partial class FieldDefinitionProposal : FieldDefinition
    {
        private FieldDefinitionProposal(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProposal Instance = new FieldDefinitionProposal(81, @"Proposal", @"Proposal", @"<p>A project suggested by an program partner that will be reviewed for inclusion in the program. The system administrators are responsible for reviewing, and if appropriate, approving proposals.</p>", true);
    }

    public partial class FieldDefinitionSpendingAssociatedWithPM : FieldDefinition
    {
        private FieldDefinitionSpendingAssociatedWithPM(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionSpendingAssociatedWithPM Instance = new FieldDefinitionSpendingAssociatedWithPM(85, @"SpendingAssociatedWithPM", @"Spending Associated with PM", @"<p>The estimated spending allotted to the Performance Measure.</p>", true);
    }

    public partial class FieldDefinitionPlanningDesignStartYear : FieldDefinition
    {
        private FieldDefinitionPlanningDesignStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPlanningDesignStartYear Instance = new FieldDefinitionPlanningDesignStartYear(86, @"PlanningDesignStartYear", @"Planning / Design Start Year", @"<p>The year during which project planning and design began. All projects should have a Planning / Design Start Year and it may not be a year in the future. Contrast with &quot;Implementation Start Year.&quot; For more detailed information, see the definition for &quot;Stage&quot;.</p>", true);
    }

    public partial class FieldDefinitionAssociatedTaxonomyTierTwos : FieldDefinition
    {
        private FieldDefinitionAssociatedTaxonomyTierTwos(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionAssociatedTaxonomyTierTwos Instance = new FieldDefinitionAssociatedTaxonomyTierTwos(87, @"AssociatedTaxonomyTierTwos", @"Associated Taxonomy Tier Twos", @"<p>External&nbsp;programs that are related to the content you are reviewing. You may wish to look up these programs to learn more.</p>", true);
    }

    public partial class FieldDefinitionExternalLinks : FieldDefinition
    {
        private FieldDefinitionExternalLinks(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionExternalLinks Instance = new FieldDefinitionExternalLinks(88, @"ExternalLinks", @"External Links", @"<p>Links to external web pages where you might find additional information.</p>", true);
    }

    public partial class FieldDefinitionEstimatedAnnualOperatingCost : FieldDefinition
    {
        private FieldDefinitionEstimatedAnnualOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost Instance = new FieldDefinitionEstimatedAnnualOperatingCost(89, @"EstimatedAnnualOperatingCost", @"Est. Annual Operating Cost", @"<p>This is the estimated cost of one year of operation in present-year dollars (present-year is set by the tool administrators). This field is only available to operations and maintenance projects.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionCalculatedTotalRemainingOperatingCost : FieldDefinition
    {
        private FieldDefinitionCalculatedTotalRemainingOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost Instance = new FieldDefinitionCalculatedTotalRemainingOperatingCost(90, @"CalculatedTotalRemainingOperatingCost", @"Remaining Operating Cost", @"<p>This field uses the transportation annual inflation factor (set by the administrators) to inflate the &quot;Estimated Annual Operating Cost&quot; to a cost-in-year-of-expenditure dollars for each year that the project will be in operation, then sums the costs across all years of operation. This field is only calculated for transportation operations and maintenance projects.&nbsp;</p>", true);
    }

    public partial class FieldDefinitionCurrentYearForPVCalculations : FieldDefinition
    {
        private FieldDefinitionCurrentYearForPVCalculations(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionCurrentYearForPVCalculations Instance = new FieldDefinitionCurrentYearForPVCalculations(91, @"CurrentYearForPVCalculations", @"Current Year for PV Calculations", @"<p>The year to use as the starting point for inflation calculations.</p>", true);
    }

    public partial class FieldDefinitionLifecycleOperatingCost : FieldDefinition
    {
        private FieldDefinitionLifecycleOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionLifecycleOperatingCost Instance = new FieldDefinitionLifecycleOperatingCost(92, @"LifecycleOperatingCost", @"Lifecycle Operating Cost", @"<p>Sum of the annual operating cost from the Implementation Start Year to Completion Year. Not inflation adjusted.</p>", true);
    }

    public partial class FieldDefinitionPerformanceMeasureChartTitle : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureChartTitle(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPerformanceMeasureChartTitle Instance = new FieldDefinitionPerformanceMeasureChartTitle(97, @"PerformanceMeasureChartTitle", @"Performance Measure Chart Title", @"<p>A short title for the Indicator (aka Performance Measure) used for charts throughout ProjectFirma.</p>", true);
    }

    public partial class FieldDefinitionRoleName : FieldDefinition
    {
        private FieldDefinitionRoleName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionRoleName Instance = new FieldDefinitionRoleName(182, @"RoleName", @"Role Name", @"<p>The name or title describing&nbsp;function or set of permissions that can be assigned to a user.</p>", true);
    }

    public partial class FieldDefinitionRegion : FieldDefinition
    {
        private FieldDefinitionRegion(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionRegion Instance = new FieldDefinitionRegion(184, @"Region", @"Region (Geospatial)", @"<p>The region in which a project is located.</p>", true);
    }

    public partial class FieldDefinitionPerformanceMeasureChartCaption : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureChartCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionPerformanceMeasureChartCaption Instance = new FieldDefinitionPerformanceMeasureChartCaption(228, @"PerformanceMeasureChartCaption", @"Performance Measure Chart Caption", @"<p>The caption which will appear on Performance Measure charts throughout the system.</p>", true);
    }

    public partial class FieldDefinitionMonitoringProgram : FieldDefinition
    {
        private FieldDefinitionMonitoringProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionMonitoringProgram Instance = new FieldDefinitionMonitoringProgram(236, @"MonitoringProgram", @"Monitoring Program", @"<p>A on-going activity to collect environmental monitoring data</p>", true);
    }

    public partial class FieldDefinitionMonitoringApproach : FieldDefinition
    {
        private FieldDefinitionMonitoringApproach(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionMonitoringApproach Instance = new FieldDefinitionMonitoringApproach(237, @"MonitoringApproach", @"Monitoring Approach", @"<p>Monitoring Approach &ndash; provides a general description of the sampling design used to carry out the monitoring. Included is a description of the spatial distribution of sampling, sampling frequency, lab procedures, and references to data sources, monitoring plans, and protocols used to guide monitoring.</p>", true);
    }

    public partial class FieldDefinitionMonitoringProgramPartner : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramPartner(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionMonitoringProgramPartner Instance = new FieldDefinitionMonitoringProgramPartner(238, @"MonitoringProgramPartner", @"Monitoring Program Partner", @"<p>Monitoring Partners &ndash; provides a list of agencies and entities that fund, collect and analyze monitoring data.</p>", true);
    }

    public partial class FieldDefinitionMonitoringProgramUrl : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionMonitoringProgramUrl Instance = new FieldDefinitionMonitoringProgramUrl(239, @"MonitoringProgramUrl", @"Monitoring Program Home Page", @"<p>The external homepage of a related monitoring program</p>", true);
    }

    public partial class FieldDefinitionClassificationDescription : FieldDefinition
    {
        private FieldDefinitionClassificationDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionClassificationDescription Instance = new FieldDefinitionClassificationDescription(240, @"ClassificationDescription", @"Classification Description", @"<p>The long-form description of the entries in the project classification system.-</p>", true);
    }

    public partial class FieldDefinitionClassificationGoalStatement : FieldDefinition
    {
        private FieldDefinitionClassificationGoalStatement(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionClassificationGoalStatement Instance = new FieldDefinitionClassificationGoalStatement(241, @"ClassificationGoalStatement", @"Classification Goal Statement", @"<p>The goal of this classification system record.-</p>", true);
    }

    public partial class FieldDefinitionClassificationNarrative : FieldDefinition
    {
        private FieldDefinitionClassificationNarrative(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionClassificationNarrative Instance = new FieldDefinitionClassificationNarrative(242, @"ClassificationNarrative", @"Classification Narrative", @"<p>Descriptive text describing the criteria for including a project in this classification system..-</p>", true);
    }

    public partial class FieldDefinitionTaxonomySystemName : FieldDefinition
    {
        private FieldDefinitionTaxonomySystemName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionTaxonomySystemName Instance = new FieldDefinitionTaxonomySystemName(243, @"TaxonomySystemName", @"Taxonomy System Name", @"<p>The customized name for the hierarchical project taxonomy system.<p>", true);
    }

    public partial class FieldDefinitionTaxonomyTierOneDisplayNameForProject : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierOneDisplayNameForProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionTaxonomyTierOneDisplayNameForProject Instance = new FieldDefinitionTaxonomyTierOneDisplayNameForProject(244, @"TaxonomyTierOneDisplayNameForProject", @"Taxonomy Tier One Display Name For Project", @"<p>A custom label describing how a Project relates to it's highest Taxonomy tier..</p>", true);
    }

    public partial class FieldDefinitionProjectRelationshipType : FieldDefinition
    {
        private FieldDefinitionProjectRelationshipType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectRelationshipType Instance = new FieldDefinitionProjectRelationshipType(245, @"ProjectRelationshipType", @"Project Relationship Type", @"<p>A categorization of a relationship between an organization and a project, e.g. Funder, Implementer.</p>", true);
    }

    public partial class FieldDefinitionProjectSteward : FieldDefinition
    {
        private FieldDefinitionProjectSteward(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectSteward Instance = new FieldDefinitionProjectSteward(246, @"ProjectSteward", @"Project Steward", @"<p>A person who can approve Project Proposals, create new Projects, approve Project Updates, and create Funding Sources for their Organization.</p>", true);
    }

    public partial class FieldDefinitionChartLastUpdatedDate : FieldDefinition
    {
        private FieldDefinitionChartLastUpdatedDate(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionChartLastUpdatedDate Instance = new FieldDefinitionChartLastUpdatedDate(247, @"Chart Last Updated Date", @"ChartLastUpdatedDate", @"<p>The date this chart was last updated with current information.</p>", true);
    }

    public partial class FieldDefinitionUnsecuredFunding : FieldDefinition
    {
        private FieldDefinitionUnsecuredFunding(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionUnsecuredFunding Instance = new FieldDefinitionUnsecuredFunding(248, @"UnsecuredFunding", @"Unsecured Funding", @"<p>Funding that has been identified for a project but has not been acquired such as planned grant applications.</p>", true);
    }

    public partial class FieldDefinitionProjectStewardOrganizationDisplayName : FieldDefinition
    {
        private FieldDefinitionProjectStewardOrganizationDisplayName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionProjectStewardOrganizationDisplayName Instance = new FieldDefinitionProjectStewardOrganizationDisplayName(249, @"ProjectStewardOrganizationDisplayName", @"Project Steward Organization Display Name", @"<p>Label for Organization types that can steward projects.</p>", true);
    }

    public partial class FieldDefinitionClassificationSystem : FieldDefinition
    {
        private FieldDefinitionClassificationSystem(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionClassificationSystem Instance = new FieldDefinitionClassificationSystem(250, @"ClassificationSystem", @"Classification System", @"<p>The type of logical system used to group projects according to overarching program themes or goals.</p>", false);
    }

    public partial class FieldDefinitionClassificationSystemName : FieldDefinition
    {
        private FieldDefinitionClassificationSystemName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition, bool canCustomizeLabel) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition, canCustomizeLabel) {}
        public static readonly FieldDefinitionClassificationSystemName Instance = new FieldDefinitionClassificationSystemName(251, @"ClassificationSystemName", @"Classification System Name", @"<p>The name of the logical grouping used to bin projects.</p>", false);
    }
}