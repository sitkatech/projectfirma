//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinition]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
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
        public static readonly FieldDefinitionFunder Funder = FieldDefinitionFunder.Instance;
        public static readonly FieldDefinitionFundingSource FundingSource = FieldDefinitionFundingSource.Instance;
        public static readonly FieldDefinitionImplementer Implementer = FieldDefinitionImplementer.Instance;
        public static readonly FieldDefinitionLeadImplementer LeadImplementer = FieldDefinitionLeadImplementer.Instance;
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
        public static readonly FieldDefinitionSector Sector = FieldDefinitionSector.Instance;
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
        public static readonly FieldDefinitionProposedProject ProposedProject = FieldDefinitionProposedProject.Instance;
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

        public static readonly List<FieldDefinition> All;
        public static readonly ReadOnlyDictionary<int, FieldDefinition> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FieldDefinition()
        {
            All = new List<FieldDefinition> { TaxonomyTierOne, ExpectedValue, TaxonomyTierThree, Funder, FundingSource, Implementer, LeadImplementer, Organization, Password, PerformanceMeasure, PerformanceMeasureType, MeasurementUnit, PhotoCaption, PhotoCredit, PhotoTiming, PrimaryContact, TaxonomyTierTwo, CompletionYear, ProjectDescription, ProjectName, ProjectNote, ImplementationStartYear, ReportedValue, Sector, SecuredFunding, ProjectStage, ClassificationName, EstimatedTotalCost, UnfundedNeed, Username, Project, Classification, Watershed, PerformanceMeasureSubcategory, PerformanceMeasureSubcategoryOption, IsPrimaryTaxonomyTierTwo, FundedAmount, ProjectLocation, ExcludeFromFactSheet, FundingType, ProjectCostInYearOfExpenditure, GlobalInflationRate, ReportingYear, TagName, TagDescription, ReportedExpenditure, ProposedProject, SpendingAssociatedWithPM, PlanningDesignStartYear, AssociatedTaxonomyTierTwos, ExternalLinks, EstimatedAnnualOperatingCost, CalculatedTotalRemainingOperatingCost, CurrentYearForPVCalculations, LifecycleOperatingCost, PerformanceMeasureChartTitle, RoleName, Region, PerformanceMeasureChartCaption, MonitoringProgram, MonitoringApproach, MonitoringProgramPartner, MonitoringProgramUrl, ClassificationDescription, ClassificationGoalStatement, ClassificationNarrative, TaxonomySystemName, TaxonomyTierOneDisplayNameForProject };
            AllLookupDictionary = new ReadOnlyDictionary<int, FieldDefinition>(All.ToDictionary(x => x.FieldDefinitionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FieldDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition)
        {
            FieldDefinitionID = fieldDefinitionID;
            FieldDefinitionName = fieldDefinitionName;
            FieldDefinitionDisplayName = fieldDefinitionDisplayName;
            DefaultDefinition = defaultDefinition;
        }

        [Key]
        public int FieldDefinitionID { get; private set; }
        public string FieldDefinitionName { get; private set; }
        public string FieldDefinitionDisplayName { get; private set; }
        public string DefaultDefinition { get; private set; }
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
                case FieldDefinitionEnum.Funder:
                    return Funder;
                case FieldDefinitionEnum.FundingSource:
                    return FundingSource;
                case FieldDefinitionEnum.FundingType:
                    return FundingType;
                case FieldDefinitionEnum.GlobalInflationRate:
                    return GlobalInflationRate;
                case FieldDefinitionEnum.ImplementationStartYear:
                    return ImplementationStartYear;
                case FieldDefinitionEnum.Implementer:
                    return Implementer;
                case FieldDefinitionEnum.IsPrimaryTaxonomyTierTwo:
                    return IsPrimaryTaxonomyTierTwo;
                case FieldDefinitionEnum.LeadImplementer:
                    return LeadImplementer;
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
                case FieldDefinitionEnum.ProjectStage:
                    return ProjectStage;
                case FieldDefinitionEnum.ProposedProject:
                    return ProposedProject;
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
                case FieldDefinitionEnum.Sector:
                    return Sector;
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
                case FieldDefinitionEnum.TaxonomyTierOneDisplayNameForProject:
                    return TaxonomyTierOneDisplayNameForProject;
                case FieldDefinitionEnum.TaxonomyTierOne:
                    return TaxonomyTierOne;
                case FieldDefinitionEnum.TaxonomyTierThree:
                    return TaxonomyTierThree;
                case FieldDefinitionEnum.TaxonomyTierTwo:
                    return TaxonomyTierTwo;
                case FieldDefinitionEnum.UnfundedNeed:
                    return UnfundedNeed;
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
        Funder = 7,
        FundingSource = 8,
        Implementer = 11,
        LeadImplementer = 12,
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
        Sector = 34,
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
        ProposedProject = 81,
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
        TaxonomyTierOneDisplayNameForProject = 244
    }

    public partial class FieldDefinitionTaxonomyTierOne : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierOne(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionTaxonomyTierOne Instance = new FieldDefinitionTaxonomyTierOne(1, @"TaxonomyTierOne", @"Taxonomy Tier One", null);
    }

    public partial class FieldDefinitionExpectedValue : FieldDefinition
    {
        private FieldDefinitionExpectedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionExpectedValue Instance = new FieldDefinitionExpectedValue(4, @"ExpectedValue", @"Expected Value", null);
    }

    public partial class FieldDefinitionTaxonomyTierThree : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierThree(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionTaxonomyTierThree Instance = new FieldDefinitionTaxonomyTierThree(5, @"TaxonomyTierThree", @"Taxonomy Tier Three", null);
    }

    public partial class FieldDefinitionFunder : FieldDefinition
    {
        private FieldDefinitionFunder(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionFunder Instance = new FieldDefinitionFunder(7, @"Funder", @"Funder", null);
    }

    public partial class FieldDefinitionFundingSource : FieldDefinition
    {
        private FieldDefinitionFundingSource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionFundingSource Instance = new FieldDefinitionFundingSource(8, @"FundingSource", @"Funding Source", null);
    }

    public partial class FieldDefinitionImplementer : FieldDefinition
    {
        private FieldDefinitionImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionImplementer Instance = new FieldDefinitionImplementer(11, @"Implementer", @"Implementer", null);
    }

    public partial class FieldDefinitionLeadImplementer : FieldDefinition
    {
        private FieldDefinitionLeadImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionLeadImplementer Instance = new FieldDefinitionLeadImplementer(12, @"LeadImplementer", @"Lead Implementer", null);
    }

    public partial class FieldDefinitionOrganization : FieldDefinition
    {
        private FieldDefinitionOrganization(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionOrganization Instance = new FieldDefinitionOrganization(14, @"Organization", @"Organization", null);
    }

    public partial class FieldDefinitionPassword : FieldDefinition
    {
        private FieldDefinitionPassword(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPassword Instance = new FieldDefinitionPassword(17, @"Password", @"Password", null);
    }

    public partial class FieldDefinitionPerformanceMeasure : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPerformanceMeasure Instance = new FieldDefinitionPerformanceMeasure(18, @"PerformanceMeasure", @"Performance Measure", null);
    }

    public partial class FieldDefinitionPerformanceMeasureType : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPerformanceMeasureType Instance = new FieldDefinitionPerformanceMeasureType(19, @"PerformanceMeasureType", @"Performance Measure Type", null);
    }

    public partial class FieldDefinitionMeasurementUnit : FieldDefinition
    {
        private FieldDefinitionMeasurementUnit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionMeasurementUnit Instance = new FieldDefinitionMeasurementUnit(21, @"MeasurementUnit", @"Measurement Unit", null);
    }

    public partial class FieldDefinitionPhotoCaption : FieldDefinition
    {
        private FieldDefinitionPhotoCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPhotoCaption Instance = new FieldDefinitionPhotoCaption(22, @"PhotoCaption", @"Photo Caption", null);
    }

    public partial class FieldDefinitionPhotoCredit : FieldDefinition
    {
        private FieldDefinitionPhotoCredit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPhotoCredit Instance = new FieldDefinitionPhotoCredit(23, @"PhotoCredit", @"Photo Credit", null);
    }

    public partial class FieldDefinitionPhotoTiming : FieldDefinition
    {
        private FieldDefinitionPhotoTiming(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPhotoTiming Instance = new FieldDefinitionPhotoTiming(24, @"PhotoTiming", @"Photo Timing", null);
    }

    public partial class FieldDefinitionPrimaryContact : FieldDefinition
    {
        private FieldDefinitionPrimaryContact(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPrimaryContact Instance = new FieldDefinitionPrimaryContact(25, @"PrimaryContact", @"Primary Contact", null);
    }

    public partial class FieldDefinitionTaxonomyTierTwo : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierTwo(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionTaxonomyTierTwo Instance = new FieldDefinitionTaxonomyTierTwo(26, @"TaxonomyTierTwo", @"Taxonomy Tier Two", null);
    }

    public partial class FieldDefinitionCompletionYear : FieldDefinition
    {
        private FieldDefinitionCompletionYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionCompletionYear Instance = new FieldDefinitionCompletionYear(28, @"CompletionYear", @"Completion Year", null);
    }

    public partial class FieldDefinitionProjectDescription : FieldDefinition
    {
        private FieldDefinitionProjectDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProjectDescription Instance = new FieldDefinitionProjectDescription(29, @"ProjectDescription", @"Project Description", null);
    }

    public partial class FieldDefinitionProjectName : FieldDefinition
    {
        private FieldDefinitionProjectName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProjectName Instance = new FieldDefinitionProjectName(30, @"ProjectName", @"Project Name", null);
    }

    public partial class FieldDefinitionProjectNote : FieldDefinition
    {
        private FieldDefinitionProjectNote(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProjectNote Instance = new FieldDefinitionProjectNote(31, @"ProjectNote", @"Project Note", null);
    }

    public partial class FieldDefinitionImplementationStartYear : FieldDefinition
    {
        private FieldDefinitionImplementationStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionImplementationStartYear Instance = new FieldDefinitionImplementationStartYear(32, @"ImplementationStartYear", @"Implementation Start Year", null);
    }

    public partial class FieldDefinitionReportedValue : FieldDefinition
    {
        private FieldDefinitionReportedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionReportedValue Instance = new FieldDefinitionReportedValue(33, @"ReportedValue", @"Reported Value", null);
    }

    public partial class FieldDefinitionSector : FieldDefinition
    {
        private FieldDefinitionSector(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionSector Instance = new FieldDefinitionSector(34, @"Sector", @"Sector", null);
    }

    public partial class FieldDefinitionSecuredFunding : FieldDefinition
    {
        private FieldDefinitionSecuredFunding(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionSecuredFunding Instance = new FieldDefinitionSecuredFunding(35, @"SecuredFunding", @"Secured Funding", null);
    }

    public partial class FieldDefinitionProjectStage : FieldDefinition
    {
        private FieldDefinitionProjectStage(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProjectStage Instance = new FieldDefinitionProjectStage(36, @"ProjectStage", @"Project Stage", null);
    }

    public partial class FieldDefinitionClassificationName : FieldDefinition
    {
        private FieldDefinitionClassificationName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionClassificationName Instance = new FieldDefinitionClassificationName(39, @"ClassificationName", @"Classification Name", null);
    }

    public partial class FieldDefinitionEstimatedTotalCost : FieldDefinition
    {
        private FieldDefinitionEstimatedTotalCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionEstimatedTotalCost Instance = new FieldDefinitionEstimatedTotalCost(40, @"EstimatedTotalCost", @"Estimated Total Cost", null);
    }

    public partial class FieldDefinitionUnfundedNeed : FieldDefinition
    {
        private FieldDefinitionUnfundedNeed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionUnfundedNeed Instance = new FieldDefinitionUnfundedNeed(41, @"UnfundedNeed", @"Unfunded Need", null);
    }

    public partial class FieldDefinitionUsername : FieldDefinition
    {
        private FieldDefinitionUsername(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionUsername Instance = new FieldDefinitionUsername(42, @"Username", @"User name", null);
    }

    public partial class FieldDefinitionProject : FieldDefinition
    {
        private FieldDefinitionProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProject Instance = new FieldDefinitionProject(44, @"Project", @"Project", null);
    }

    public partial class FieldDefinitionClassification : FieldDefinition
    {
        private FieldDefinitionClassification(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionClassification Instance = new FieldDefinitionClassification(46, @"Classification", @"Classification", null);
    }

    public partial class FieldDefinitionWatershed : FieldDefinition
    {
        private FieldDefinitionWatershed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionWatershed Instance = new FieldDefinitionWatershed(48, @"Watershed", @"Watershed", null);
    }

    public partial class FieldDefinitionPerformanceMeasureSubcategory : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureSubcategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPerformanceMeasureSubcategory Instance = new FieldDefinitionPerformanceMeasureSubcategory(49, @"PerformanceMeasureSubcategory", @"Performance Measure Subcategory", null);
    }

    public partial class FieldDefinitionPerformanceMeasureSubcategoryOption : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureSubcategoryOption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPerformanceMeasureSubcategoryOption Instance = new FieldDefinitionPerformanceMeasureSubcategoryOption(50, @"PerformanceMeasureSubcategoryOption", @"Performance Measure Subcategory Option", null);
    }

    public partial class FieldDefinitionIsPrimaryTaxonomyTierTwo : FieldDefinition
    {
        private FieldDefinitionIsPrimaryTaxonomyTierTwo(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionIsPrimaryTaxonomyTierTwo Instance = new FieldDefinitionIsPrimaryTaxonomyTierTwo(52, @"IsPrimaryTaxonomyTierTwo", @"Is Primary Taxonomy Tier Two", null);
    }

    public partial class FieldDefinitionFundedAmount : FieldDefinition
    {
        private FieldDefinitionFundedAmount(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionFundedAmount Instance = new FieldDefinitionFundedAmount(56, @"FundedAmount", @"Funded Amount", null);
    }

    public partial class FieldDefinitionProjectLocation : FieldDefinition
    {
        private FieldDefinitionProjectLocation(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProjectLocation Instance = new FieldDefinitionProjectLocation(57, @"ProjectLocation", @"Project Location", null);
    }

    public partial class FieldDefinitionExcludeFromFactSheet : FieldDefinition
    {
        private FieldDefinitionExcludeFromFactSheet(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionExcludeFromFactSheet Instance = new FieldDefinitionExcludeFromFactSheet(64, @"ExcludeFromFactSheet", @"Exclude from Fact Sheet", null);
    }

    public partial class FieldDefinitionFundingType : FieldDefinition
    {
        private FieldDefinitionFundingType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionFundingType Instance = new FieldDefinitionFundingType(73, @"FundingType", @"Funding Type", null);
    }

    public partial class FieldDefinitionProjectCostInYearOfExpenditure : FieldDefinition
    {
        private FieldDefinitionProjectCostInYearOfExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure Instance = new FieldDefinitionProjectCostInYearOfExpenditure(74, @"ProjectCostInYearOfExpenditure", @"Cost in Year of Expenditure", null);
    }

    public partial class FieldDefinitionGlobalInflationRate : FieldDefinition
    {
        private FieldDefinitionGlobalInflationRate(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionGlobalInflationRate Instance = new FieldDefinitionGlobalInflationRate(75, @"GlobalInflationRate", @"Global Inflation Rate", null);
    }

    public partial class FieldDefinitionReportingYear : FieldDefinition
    {
        private FieldDefinitionReportingYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionReportingYear Instance = new FieldDefinitionReportingYear(76, @"ReportingYear", @"Reporting Year", null);
    }

    public partial class FieldDefinitionTagName : FieldDefinition
    {
        private FieldDefinitionTagName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionTagName Instance = new FieldDefinitionTagName(77, @"TagName", @"Tag Name", null);
    }

    public partial class FieldDefinitionTagDescription : FieldDefinition
    {
        private FieldDefinitionTagDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionTagDescription Instance = new FieldDefinitionTagDescription(78, @"TagDescription", @"Tag Description", null);
    }

    public partial class FieldDefinitionReportedExpenditure : FieldDefinition
    {
        private FieldDefinitionReportedExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionReportedExpenditure Instance = new FieldDefinitionReportedExpenditure(80, @"ReportedExpenditure", @"Reported Expenditure", null);
    }

    public partial class FieldDefinitionProposedProject : FieldDefinition
    {
        private FieldDefinitionProposedProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionProposedProject Instance = new FieldDefinitionProposedProject(81, @"ProposedProject", @"Proposed Project", null);
    }

    public partial class FieldDefinitionSpendingAssociatedWithPM : FieldDefinition
    {
        private FieldDefinitionSpendingAssociatedWithPM(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionSpendingAssociatedWithPM Instance = new FieldDefinitionSpendingAssociatedWithPM(85, @"SpendingAssociatedWithPM", @"Spending Associated with PM", null);
    }

    public partial class FieldDefinitionPlanningDesignStartYear : FieldDefinition
    {
        private FieldDefinitionPlanningDesignStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPlanningDesignStartYear Instance = new FieldDefinitionPlanningDesignStartYear(86, @"PlanningDesignStartYear", @"Planning / Design Start Year", null);
    }

    public partial class FieldDefinitionAssociatedTaxonomyTierTwos : FieldDefinition
    {
        private FieldDefinitionAssociatedTaxonomyTierTwos(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionAssociatedTaxonomyTierTwos Instance = new FieldDefinitionAssociatedTaxonomyTierTwos(87, @"AssociatedTaxonomyTierTwos", @"Associated TaxonomyTierTwos", null);
    }

    public partial class FieldDefinitionExternalLinks : FieldDefinition
    {
        private FieldDefinitionExternalLinks(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionExternalLinks Instance = new FieldDefinitionExternalLinks(88, @"ExternalLinks", @"External Links", null);
    }

    public partial class FieldDefinitionEstimatedAnnualOperatingCost : FieldDefinition
    {
        private FieldDefinitionEstimatedAnnualOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost Instance = new FieldDefinitionEstimatedAnnualOperatingCost(89, @"EstimatedAnnualOperatingCost", @"Est. Annual Operating Cost", null);
    }

    public partial class FieldDefinitionCalculatedTotalRemainingOperatingCost : FieldDefinition
    {
        private FieldDefinitionCalculatedTotalRemainingOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost Instance = new FieldDefinitionCalculatedTotalRemainingOperatingCost(90, @"CalculatedTotalRemainingOperatingCost", @"Remaining Operating Cost", null);
    }

    public partial class FieldDefinitionCurrentYearForPVCalculations : FieldDefinition
    {
        private FieldDefinitionCurrentYearForPVCalculations(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionCurrentYearForPVCalculations Instance = new FieldDefinitionCurrentYearForPVCalculations(91, @"CurrentYearForPVCalculations", @"Current Year for PV Calculations", null);
    }

    public partial class FieldDefinitionLifecycleOperatingCost : FieldDefinition
    {
        private FieldDefinitionLifecycleOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionLifecycleOperatingCost Instance = new FieldDefinitionLifecycleOperatingCost(92, @"LifecycleOperatingCost", @"Lifecycle Operating Cost", null);
    }

    public partial class FieldDefinitionPerformanceMeasureChartTitle : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureChartTitle(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPerformanceMeasureChartTitle Instance = new FieldDefinitionPerformanceMeasureChartTitle(97, @"PerformanceMeasureChartTitle", @"Performance Measure Chart Title", null);
    }

    public partial class FieldDefinitionRoleName : FieldDefinition
    {
        private FieldDefinitionRoleName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionRoleName Instance = new FieldDefinitionRoleName(182, @"RoleName", @"Role Name", null);
    }

    public partial class FieldDefinitionRegion : FieldDefinition
    {
        private FieldDefinitionRegion(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionRegion Instance = new FieldDefinitionRegion(184, @"Region", @"Region (Geospatial, null),", null);
    }

    public partial class FieldDefinitionPerformanceMeasureChartCaption : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureChartCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionPerformanceMeasureChartCaption Instance = new FieldDefinitionPerformanceMeasureChartCaption(228, @"PerformanceMeasureChartCaption", @"Performance Measure Chart Caption", null);
    }

    public partial class FieldDefinitionMonitoringProgram : FieldDefinition
    {
        private FieldDefinitionMonitoringProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionMonitoringProgram Instance = new FieldDefinitionMonitoringProgram(236, @"MonitoringProgram", @"Monitoring Program", null);
    }

    public partial class FieldDefinitionMonitoringApproach : FieldDefinition
    {
        private FieldDefinitionMonitoringApproach(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionMonitoringApproach Instance = new FieldDefinitionMonitoringApproach(237, @"MonitoringApproach", @"Monitoring Approach", null);
    }

    public partial class FieldDefinitionMonitoringProgramPartner : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramPartner(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionMonitoringProgramPartner Instance = new FieldDefinitionMonitoringProgramPartner(238, @"MonitoringProgramPartner", @"Monitoring Program Partner", null);
    }

    public partial class FieldDefinitionMonitoringProgramUrl : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionMonitoringProgramUrl Instance = new FieldDefinitionMonitoringProgramUrl(239, @"MonitoringProgramUrl", @"Monitoring Program Home Page", null);
    }

    public partial class FieldDefinitionClassificationDescription : FieldDefinition
    {
        private FieldDefinitionClassificationDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionClassificationDescription Instance = new FieldDefinitionClassificationDescription(240, @"ClassificationDescription", @"Classification Description", null);
    }

    public partial class FieldDefinitionClassificationGoalStatement : FieldDefinition
    {
        private FieldDefinitionClassificationGoalStatement(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionClassificationGoalStatement Instance = new FieldDefinitionClassificationGoalStatement(241, @"ClassificationGoalStatement", @"Classification Goal Statement", null);
    }

    public partial class FieldDefinitionClassificationNarrative : FieldDefinition
    {
        private FieldDefinitionClassificationNarrative(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionClassificationNarrative Instance = new FieldDefinitionClassificationNarrative(242, @"ClassificationNarrative", @"Classification Narrative", null);
    }

    public partial class FieldDefinitionTaxonomySystemName : FieldDefinition
    {
        private FieldDefinitionTaxonomySystemName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionTaxonomySystemName Instance = new FieldDefinitionTaxonomySystemName(243, @"Taxonomy System Name", @"TaxonomySystemName", null);
    }

    public partial class FieldDefinitionTaxonomyTierOneDisplayNameForProject : FieldDefinition
    {
        private FieldDefinitionTaxonomyTierOneDisplayNameForProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, string defaultDefinition) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, defaultDefinition) {}
        public static readonly FieldDefinitionTaxonomyTierOneDisplayNameForProject Instance = new FieldDefinitionTaxonomyTierOneDisplayNameForProject(244, @"Taxonomy Tier One Display Name For Project", @"TaxonomyTierOneDisplayNameForProject", null);
    }
}