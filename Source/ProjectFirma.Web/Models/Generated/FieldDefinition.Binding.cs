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
        public static readonly FieldDefinitionActionPriority ActionPriority = FieldDefinitionActionPriority.Instance;
        public static readonly FieldDefinitionActionPriorityName ActionPriorityName = FieldDefinitionActionPriorityName.Instance;
        public static readonly FieldDefinitionExpectedValue ExpectedValue = FieldDefinitionExpectedValue.Instance;
        public static readonly FieldDefinitionFocusArea FocusArea = FieldDefinitionFocusArea.Instance;
        public static readonly FieldDefinitionFocusAreaName FocusAreaName = FieldDefinitionFocusAreaName.Instance;
        public static readonly FieldDefinitionFunder Funder = FieldDefinitionFunder.Instance;
        public static readonly FieldDefinitionFundingSource FundingSource = FieldDefinitionFundingSource.Instance;
        public static readonly FieldDefinitionFundingSourceDescription FundingSourceDescription = FieldDefinitionFundingSourceDescription.Instance;
        public static readonly FieldDefinitionFundingSourceName FundingSourceName = FieldDefinitionFundingSourceName.Instance;
        public static readonly FieldDefinitionImplementer Implementer = FieldDefinitionImplementer.Instance;
        public static readonly FieldDefinitionLeadImplementer LeadImplementer = FieldDefinitionLeadImplementer.Instance;
        public static readonly FieldDefinitionOrganization Organization = FieldDefinitionOrganization.Instance;
        public static readonly FieldDefinitionPassword Password = FieldDefinitionPassword.Instance;
        public static readonly FieldDefinitionPerformanceMeasure PerformanceMeasure = FieldDefinitionPerformanceMeasure.Instance;
        public static readonly FieldDefinitionMeasurementUnit MeasurementUnit = FieldDefinitionMeasurementUnit.Instance;
        public static readonly FieldDefinitionPhotoCaption PhotoCaption = FieldDefinitionPhotoCaption.Instance;
        public static readonly FieldDefinitionPhotoCredit PhotoCredit = FieldDefinitionPhotoCredit.Instance;
        public static readonly FieldDefinitionPhotoTiming PhotoTiming = FieldDefinitionPhotoTiming.Instance;
        public static readonly FieldDefinitionPrimaryContact PrimaryContact = FieldDefinitionPrimaryContact.Instance;
        public static readonly FieldDefinitionProgram Program = FieldDefinitionProgram.Instance;
        public static readonly FieldDefinitionProgramName ProgramName = FieldDefinitionProgramName.Instance;
        public static readonly FieldDefinitionCompletionYear CompletionYear = FieldDefinitionCompletionYear.Instance;
        public static readonly FieldDefinitionProjectDescription ProjectDescription = FieldDefinitionProjectDescription.Instance;
        public static readonly FieldDefinitionProjectName ProjectName = FieldDefinitionProjectName.Instance;
        public static readonly FieldDefinitionProjectNote ProjectNote = FieldDefinitionProjectNote.Instance;
        public static readonly FieldDefinitionImplementationStartYear ImplementationStartYear = FieldDefinitionImplementationStartYear.Instance;
        public static readonly FieldDefinitionReportedValue ReportedValue = FieldDefinitionReportedValue.Instance;
        public static readonly FieldDefinitionSector Sector = FieldDefinitionSector.Instance;
        public static readonly FieldDefinitionSecuredFunding SecuredFunding = FieldDefinitionSecuredFunding.Instance;
        public static readonly FieldDefinitionProjectStage ProjectStage = FieldDefinitionProjectStage.Instance;
        public static readonly FieldDefinitionThresholdCategoryName ThresholdCategoryName = FieldDefinitionThresholdCategoryName.Instance;
        public static readonly FieldDefinitionEstimatedTotalCost EstimatedTotalCost = FieldDefinitionEstimatedTotalCost.Instance;
        public static readonly FieldDefinitionUnfundedNeed UnfundedNeed = FieldDefinitionUnfundedNeed.Instance;
        public static readonly FieldDefinitionUsername Username = FieldDefinitionUsername.Instance;
        public static readonly FieldDefinitionWatershedName WatershedName = FieldDefinitionWatershedName.Instance;
        public static readonly FieldDefinitionProject Project = FieldDefinitionProject.Instance;
        public static readonly FieldDefinitionThresholdCategory ThresholdCategory = FieldDefinitionThresholdCategory.Instance;
        public static readonly FieldDefinitionWatershed Watershed = FieldDefinitionWatershed.Instance;
        public static readonly FieldDefinitionPerformanceMeasureSubcategory PerformanceMeasureSubcategory = FieldDefinitionPerformanceMeasureSubcategory.Instance;
        public static readonly FieldDefinitionPerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption = FieldDefinitionPerformanceMeasureSubcategoryOption.Instance;
        public static readonly FieldDefinitionIsPrimaryProgram IsPrimaryProgram = FieldDefinitionIsPrimaryProgram.Instance;
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
        public static readonly FieldDefinitionAssociatedPrograms AssociatedPrograms = FieldDefinitionAssociatedPrograms.Instance;
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
        public static readonly FieldDefinitionThresholdCategoryDescription ThresholdCategoryDescription = FieldDefinitionThresholdCategoryDescription.Instance;
        public static readonly FieldDefinitionThresholdCategoryGoalStatement ThresholdCategoryGoalStatement = FieldDefinitionThresholdCategoryGoalStatement.Instance;
        public static readonly FieldDefinitionThresholdCategoryNarrative ThresholdCategoryNarrative = FieldDefinitionThresholdCategoryNarrative.Instance;

        public static readonly List<FieldDefinition> All;
        public static readonly ReadOnlyDictionary<int, FieldDefinition> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FieldDefinition()
        {
            All = new List<FieldDefinition> { ActionPriority, ActionPriorityName, ExpectedValue, FocusArea, FocusAreaName, Funder, FundingSource, FundingSourceDescription, FundingSourceName, Implementer, LeadImplementer, Organization, Password, PerformanceMeasure, MeasurementUnit, PhotoCaption, PhotoCredit, PhotoTiming, PrimaryContact, Program, ProgramName, CompletionYear, ProjectDescription, ProjectName, ProjectNote, ImplementationStartYear, ReportedValue, Sector, SecuredFunding, ProjectStage, ThresholdCategoryName, EstimatedTotalCost, UnfundedNeed, Username, WatershedName, Project, ThresholdCategory, Watershed, PerformanceMeasureSubcategory, PerformanceMeasureSubcategoryOption, IsPrimaryProgram, FundedAmount, ProjectLocation, ExcludeFromFactSheet, FundingType, ProjectCostInYearOfExpenditure, GlobalInflationRate, ReportingYear, TagName, TagDescription, ReportedExpenditure, ProposedProject, SpendingAssociatedWithPM, PlanningDesignStartYear, AssociatedPrograms, ExternalLinks, EstimatedAnnualOperatingCost, CalculatedTotalRemainingOperatingCost, CurrentYearForPVCalculations, LifecycleOperatingCost, PerformanceMeasureChartTitle, RoleName, Region, PerformanceMeasureChartCaption, MonitoringProgram, MonitoringApproach, MonitoringProgramPartner, MonitoringProgramUrl, ThresholdCategoryDescription, ThresholdCategoryGoalStatement, ThresholdCategoryNarrative };
            AllLookupDictionary = new ReadOnlyDictionary<int, FieldDefinition>(All.ToDictionary(x => x.FieldDefinitionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FieldDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName)
        {
            FieldDefinitionID = fieldDefinitionID;
            FieldDefinitionName = fieldDefinitionName;
            FieldDefinitionDisplayName = fieldDefinitionDisplayName;
        }

        [Key]
        public int FieldDefinitionID { get; private set; }
        public string FieldDefinitionName { get; private set; }
        public string FieldDefinitionDisplayName { get; private set; }
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
                case FieldDefinitionEnum.ActionPriority:
                    return ActionPriority;
                case FieldDefinitionEnum.ActionPriorityName:
                    return ActionPriorityName;
                case FieldDefinitionEnum.AssociatedPrograms:
                    return AssociatedPrograms;
                case FieldDefinitionEnum.CalculatedTotalRemainingOperatingCost:
                    return CalculatedTotalRemainingOperatingCost;
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
                case FieldDefinitionEnum.FocusArea:
                    return FocusArea;
                case FieldDefinitionEnum.FocusAreaName:
                    return FocusAreaName;
                case FieldDefinitionEnum.FundedAmount:
                    return FundedAmount;
                case FieldDefinitionEnum.Funder:
                    return Funder;
                case FieldDefinitionEnum.FundingSource:
                    return FundingSource;
                case FieldDefinitionEnum.FundingSourceDescription:
                    return FundingSourceDescription;
                case FieldDefinitionEnum.FundingSourceName:
                    return FundingSourceName;
                case FieldDefinitionEnum.FundingType:
                    return FundingType;
                case FieldDefinitionEnum.GlobalInflationRate:
                    return GlobalInflationRate;
                case FieldDefinitionEnum.ImplementationStartYear:
                    return ImplementationStartYear;
                case FieldDefinitionEnum.Implementer:
                    return Implementer;
                case FieldDefinitionEnum.IsPrimaryProgram:
                    return IsPrimaryProgram;
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
                case FieldDefinitionEnum.Program:
                    return Program;
                case FieldDefinitionEnum.ProgramName:
                    return ProgramName;
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
                case FieldDefinitionEnum.ThresholdCategory:
                    return ThresholdCategory;
                case FieldDefinitionEnum.ThresholdCategoryDescription:
                    return ThresholdCategoryDescription;
                case FieldDefinitionEnum.ThresholdCategoryGoalStatement:
                    return ThresholdCategoryGoalStatement;
                case FieldDefinitionEnum.ThresholdCategoryName:
                    return ThresholdCategoryName;
                case FieldDefinitionEnum.ThresholdCategoryNarrative:
                    return ThresholdCategoryNarrative;
                case FieldDefinitionEnum.UnfundedNeed:
                    return UnfundedNeed;
                case FieldDefinitionEnum.Username:
                    return Username;
                case FieldDefinitionEnum.Watershed:
                    return Watershed;
                case FieldDefinitionEnum.WatershedName:
                    return WatershedName;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FieldDefinitionEnum
    {
        ActionPriority = 1,
        ActionPriorityName = 2,
        ExpectedValue = 4,
        FocusArea = 5,
        FocusAreaName = 6,
        Funder = 7,
        FundingSource = 8,
        FundingSourceDescription = 9,
        FundingSourceName = 10,
        Implementer = 11,
        LeadImplementer = 12,
        Organization = 14,
        Password = 17,
        PerformanceMeasure = 18,
        MeasurementUnit = 21,
        PhotoCaption = 22,
        PhotoCredit = 23,
        PhotoTiming = 24,
        PrimaryContact = 25,
        Program = 26,
        ProgramName = 27,
        CompletionYear = 28,
        ProjectDescription = 29,
        ProjectName = 30,
        ProjectNote = 31,
        ImplementationStartYear = 32,
        ReportedValue = 33,
        Sector = 34,
        SecuredFunding = 35,
        ProjectStage = 36,
        ThresholdCategoryName = 39,
        EstimatedTotalCost = 40,
        UnfundedNeed = 41,
        Username = 42,
        WatershedName = 43,
        Project = 44,
        ThresholdCategory = 46,
        Watershed = 48,
        PerformanceMeasureSubcategory = 49,
        PerformanceMeasureSubcategoryOption = 50,
        IsPrimaryProgram = 52,
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
        AssociatedPrograms = 87,
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
        ThresholdCategoryDescription = 240,
        ThresholdCategoryGoalStatement = 241,
        ThresholdCategoryNarrative = 242
    }

    public partial class FieldDefinitionActionPriority : FieldDefinition
    {
        private FieldDefinitionActionPriority(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionActionPriority Instance = new FieldDefinitionActionPriority(1, @"ActionPriority", @"Action Priority");
    }

    public partial class FieldDefinitionActionPriorityName : FieldDefinition
    {
        private FieldDefinitionActionPriorityName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionActionPriorityName Instance = new FieldDefinitionActionPriorityName(2, @"ActionPriorityName", @"Action Priority Name");
    }

    public partial class FieldDefinitionExpectedValue : FieldDefinition
    {
        private FieldDefinitionExpectedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionExpectedValue Instance = new FieldDefinitionExpectedValue(4, @"ExpectedValue", @"Expected Value");
    }

    public partial class FieldDefinitionFocusArea : FieldDefinition
    {
        private FieldDefinitionFocusArea(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFocusArea Instance = new FieldDefinitionFocusArea(5, @"FocusArea", @"Focus Area");
    }

    public partial class FieldDefinitionFocusAreaName : FieldDefinition
    {
        private FieldDefinitionFocusAreaName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFocusAreaName Instance = new FieldDefinitionFocusAreaName(6, @"FocusAreaName", @"Focus Area Name");
    }

    public partial class FieldDefinitionFunder : FieldDefinition
    {
        private FieldDefinitionFunder(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFunder Instance = new FieldDefinitionFunder(7, @"Funder", @"Funder");
    }

    public partial class FieldDefinitionFundingSource : FieldDefinition
    {
        private FieldDefinitionFundingSource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingSource Instance = new FieldDefinitionFundingSource(8, @"FundingSource", @"Funding Source");
    }

    public partial class FieldDefinitionFundingSourceDescription : FieldDefinition
    {
        private FieldDefinitionFundingSourceDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingSourceDescription Instance = new FieldDefinitionFundingSourceDescription(9, @"FundingSourceDescription", @"Funding Source Description");
    }

    public partial class FieldDefinitionFundingSourceName : FieldDefinition
    {
        private FieldDefinitionFundingSourceName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingSourceName Instance = new FieldDefinitionFundingSourceName(10, @"FundingSourceName", @"Funding Source Name");
    }

    public partial class FieldDefinitionImplementer : FieldDefinition
    {
        private FieldDefinitionImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionImplementer Instance = new FieldDefinitionImplementer(11, @"Implementer", @"Implementer");
    }

    public partial class FieldDefinitionLeadImplementer : FieldDefinition
    {
        private FieldDefinitionLeadImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLeadImplementer Instance = new FieldDefinitionLeadImplementer(12, @"LeadImplementer", @"Lead Implementer");
    }

    public partial class FieldDefinitionOrganization : FieldDefinition
    {
        private FieldDefinitionOrganization(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionOrganization Instance = new FieldDefinitionOrganization(14, @"Organization", @"Organization");
    }

    public partial class FieldDefinitionPassword : FieldDefinition
    {
        private FieldDefinitionPassword(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPassword Instance = new FieldDefinitionPassword(17, @"Password", @"Password");
    }

    public partial class FieldDefinitionPerformanceMeasure : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPerformanceMeasure Instance = new FieldDefinitionPerformanceMeasure(18, @"PerformanceMeasure", @"Performance Measure");
    }

    public partial class FieldDefinitionMeasurementUnit : FieldDefinition
    {
        private FieldDefinitionMeasurementUnit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMeasurementUnit Instance = new FieldDefinitionMeasurementUnit(21, @"MeasurementUnit", @"Measurement Unit");
    }

    public partial class FieldDefinitionPhotoCaption : FieldDefinition
    {
        private FieldDefinitionPhotoCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPhotoCaption Instance = new FieldDefinitionPhotoCaption(22, @"PhotoCaption", @"Photo Caption");
    }

    public partial class FieldDefinitionPhotoCredit : FieldDefinition
    {
        private FieldDefinitionPhotoCredit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPhotoCredit Instance = new FieldDefinitionPhotoCredit(23, @"PhotoCredit", @"Photo Credit");
    }

    public partial class FieldDefinitionPhotoTiming : FieldDefinition
    {
        private FieldDefinitionPhotoTiming(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPhotoTiming Instance = new FieldDefinitionPhotoTiming(24, @"PhotoTiming", @"Photo Timing");
    }

    public partial class FieldDefinitionPrimaryContact : FieldDefinition
    {
        private FieldDefinitionPrimaryContact(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPrimaryContact Instance = new FieldDefinitionPrimaryContact(25, @"PrimaryContact", @"Primary Contact");
    }

    public partial class FieldDefinitionProgram : FieldDefinition
    {
        private FieldDefinitionProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProgram Instance = new FieldDefinitionProgram(26, @"Program", @"Program");
    }

    public partial class FieldDefinitionProgramName : FieldDefinition
    {
        private FieldDefinitionProgramName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProgramName Instance = new FieldDefinitionProgramName(27, @"ProgramName", @"Program Name");
    }

    public partial class FieldDefinitionCompletionYear : FieldDefinition
    {
        private FieldDefinitionCompletionYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionCompletionYear Instance = new FieldDefinitionCompletionYear(28, @"CompletionYear", @"Completion Year");
    }

    public partial class FieldDefinitionProjectDescription : FieldDefinition
    {
        private FieldDefinitionProjectDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectDescription Instance = new FieldDefinitionProjectDescription(29, @"ProjectDescription", @"Project Description");
    }

    public partial class FieldDefinitionProjectName : FieldDefinition
    {
        private FieldDefinitionProjectName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectName Instance = new FieldDefinitionProjectName(30, @"ProjectName", @"Project Name");
    }

    public partial class FieldDefinitionProjectNote : FieldDefinition
    {
        private FieldDefinitionProjectNote(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectNote Instance = new FieldDefinitionProjectNote(31, @"ProjectNote", @"Project Note");
    }

    public partial class FieldDefinitionImplementationStartYear : FieldDefinition
    {
        private FieldDefinitionImplementationStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionImplementationStartYear Instance = new FieldDefinitionImplementationStartYear(32, @"ImplementationStartYear", @"Implementation Start Year");
    }

    public partial class FieldDefinitionReportedValue : FieldDefinition
    {
        private FieldDefinitionReportedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionReportedValue Instance = new FieldDefinitionReportedValue(33, @"ReportedValue", @"Reported Value");
    }

    public partial class FieldDefinitionSector : FieldDefinition
    {
        private FieldDefinitionSector(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSector Instance = new FieldDefinitionSector(34, @"Sector", @"Sector");
    }

    public partial class FieldDefinitionSecuredFunding : FieldDefinition
    {
        private FieldDefinitionSecuredFunding(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSecuredFunding Instance = new FieldDefinitionSecuredFunding(35, @"SecuredFunding", @"Secured Funding");
    }

    public partial class FieldDefinitionProjectStage : FieldDefinition
    {
        private FieldDefinitionProjectStage(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectStage Instance = new FieldDefinitionProjectStage(36, @"ProjectStage", @"Project Stage");
    }

    public partial class FieldDefinitionThresholdCategoryName : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryName Instance = new FieldDefinitionThresholdCategoryName(39, @"ThresholdCategoryName", @"Threshold Category Name");
    }

    public partial class FieldDefinitionEstimatedTotalCost : FieldDefinition
    {
        private FieldDefinitionEstimatedTotalCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionEstimatedTotalCost Instance = new FieldDefinitionEstimatedTotalCost(40, @"EstimatedTotalCost", @"Estimated Total Cost");
    }

    public partial class FieldDefinitionUnfundedNeed : FieldDefinition
    {
        private FieldDefinitionUnfundedNeed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUnfundedNeed Instance = new FieldDefinitionUnfundedNeed(41, @"UnfundedNeed", @"Unfunded Need");
    }

    public partial class FieldDefinitionUsername : FieldDefinition
    {
        private FieldDefinitionUsername(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUsername Instance = new FieldDefinitionUsername(42, @"Username", @"User name");
    }

    public partial class FieldDefinitionWatershedName : FieldDefinition
    {
        private FieldDefinitionWatershedName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionWatershedName Instance = new FieldDefinitionWatershedName(43, @"WatershedName", @"Watershed Name");
    }

    public partial class FieldDefinitionProject : FieldDefinition
    {
        private FieldDefinitionProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProject Instance = new FieldDefinitionProject(44, @"Project", @"Project");
    }

    public partial class FieldDefinitionThresholdCategory : FieldDefinition
    {
        private FieldDefinitionThresholdCategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategory Instance = new FieldDefinitionThresholdCategory(46, @"ThresholdCategory", @"Threshold Category");
    }

    public partial class FieldDefinitionWatershed : FieldDefinition
    {
        private FieldDefinitionWatershed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionWatershed Instance = new FieldDefinitionWatershed(48, @"Watershed", @"Watershed");
    }

    public partial class FieldDefinitionPerformanceMeasureSubcategory : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureSubcategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPerformanceMeasureSubcategory Instance = new FieldDefinitionPerformanceMeasureSubcategory(49, @"PerformanceMeasureSubcategory", @"Performance Measure Subcategory");
    }

    public partial class FieldDefinitionPerformanceMeasureSubcategoryOption : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureSubcategoryOption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPerformanceMeasureSubcategoryOption Instance = new FieldDefinitionPerformanceMeasureSubcategoryOption(50, @"PerformanceMeasureSubcategoryOption", @"Performance Measure Subcategory Option");
    }

    public partial class FieldDefinitionIsPrimaryProgram : FieldDefinition
    {
        private FieldDefinitionIsPrimaryProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIsPrimaryProgram Instance = new FieldDefinitionIsPrimaryProgram(52, @"IsPrimaryProgram", @"Is Primary Program");
    }

    public partial class FieldDefinitionFundedAmount : FieldDefinition
    {
        private FieldDefinitionFundedAmount(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundedAmount Instance = new FieldDefinitionFundedAmount(56, @"FundedAmount", @"Funded Amount");
    }

    public partial class FieldDefinitionProjectLocation : FieldDefinition
    {
        private FieldDefinitionProjectLocation(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectLocation Instance = new FieldDefinitionProjectLocation(57, @"ProjectLocation", @"Project Location");
    }

    public partial class FieldDefinitionExcludeFromFactSheet : FieldDefinition
    {
        private FieldDefinitionExcludeFromFactSheet(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionExcludeFromFactSheet Instance = new FieldDefinitionExcludeFromFactSheet(64, @"ExcludeFromFactSheet", @"Exclude from Fact Sheet");
    }

    public partial class FieldDefinitionFundingType : FieldDefinition
    {
        private FieldDefinitionFundingType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingType Instance = new FieldDefinitionFundingType(73, @"FundingType", @"Funding Type");
    }

    public partial class FieldDefinitionProjectCostInYearOfExpenditure : FieldDefinition
    {
        private FieldDefinitionProjectCostInYearOfExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure Instance = new FieldDefinitionProjectCostInYearOfExpenditure(74, @"ProjectCostInYearOfExpenditure", @"Cost in Year of Expenditure");
    }

    public partial class FieldDefinitionGlobalInflationRate : FieldDefinition
    {
        private FieldDefinitionGlobalInflationRate(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionGlobalInflationRate Instance = new FieldDefinitionGlobalInflationRate(75, @"GlobalInflationRate", @"Global Inflation Rate");
    }

    public partial class FieldDefinitionReportingYear : FieldDefinition
    {
        private FieldDefinitionReportingYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionReportingYear Instance = new FieldDefinitionReportingYear(76, @"ReportingYear", @"Reporting Year");
    }

    public partial class FieldDefinitionTagName : FieldDefinition
    {
        private FieldDefinitionTagName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTagName Instance = new FieldDefinitionTagName(77, @"TagName", @"Tag Name");
    }

    public partial class FieldDefinitionTagDescription : FieldDefinition
    {
        private FieldDefinitionTagDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTagDescription Instance = new FieldDefinitionTagDescription(78, @"TagDescription", @"Tag Description");
    }

    public partial class FieldDefinitionReportedExpenditure : FieldDefinition
    {
        private FieldDefinitionReportedExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionReportedExpenditure Instance = new FieldDefinitionReportedExpenditure(80, @"ReportedExpenditure", @"Reported Expenditure");
    }

    public partial class FieldDefinitionProposedProject : FieldDefinition
    {
        private FieldDefinitionProposedProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProposedProject Instance = new FieldDefinitionProposedProject(81, @"ProposedProject", @"Proposed Project");
    }

    public partial class FieldDefinitionSpendingAssociatedWithPM : FieldDefinition
    {
        private FieldDefinitionSpendingAssociatedWithPM(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSpendingAssociatedWithPM Instance = new FieldDefinitionSpendingAssociatedWithPM(85, @"SpendingAssociatedWithPM", @"Spending Associated with PM");
    }

    public partial class FieldDefinitionPlanningDesignStartYear : FieldDefinition
    {
        private FieldDefinitionPlanningDesignStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPlanningDesignStartYear Instance = new FieldDefinitionPlanningDesignStartYear(86, @"PlanningDesignStartYear", @"Planning / Design Start Year");
    }

    public partial class FieldDefinitionAssociatedPrograms : FieldDefinition
    {
        private FieldDefinitionAssociatedPrograms(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionAssociatedPrograms Instance = new FieldDefinitionAssociatedPrograms(87, @"AssociatedPrograms", @"Associated Programs");
    }

    public partial class FieldDefinitionExternalLinks : FieldDefinition
    {
        private FieldDefinitionExternalLinks(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionExternalLinks Instance = new FieldDefinitionExternalLinks(88, @"ExternalLinks", @"External Links");
    }

    public partial class FieldDefinitionEstimatedAnnualOperatingCost : FieldDefinition
    {
        private FieldDefinitionEstimatedAnnualOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost Instance = new FieldDefinitionEstimatedAnnualOperatingCost(89, @"EstimatedAnnualOperatingCost", @"Est. Annual Operating Cost");
    }

    public partial class FieldDefinitionCalculatedTotalRemainingOperatingCost : FieldDefinition
    {
        private FieldDefinitionCalculatedTotalRemainingOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost Instance = new FieldDefinitionCalculatedTotalRemainingOperatingCost(90, @"CalculatedTotalRemainingOperatingCost", @"Remaining Operating Cost");
    }

    public partial class FieldDefinitionCurrentYearForPVCalculations : FieldDefinition
    {
        private FieldDefinitionCurrentYearForPVCalculations(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionCurrentYearForPVCalculations Instance = new FieldDefinitionCurrentYearForPVCalculations(91, @"CurrentYearForPVCalculations", @"Current Year for PV Calculations");
    }

    public partial class FieldDefinitionLifecycleOperatingCost : FieldDefinition
    {
        private FieldDefinitionLifecycleOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLifecycleOperatingCost Instance = new FieldDefinitionLifecycleOperatingCost(92, @"LifecycleOperatingCost", @"Lifecycle Operating Cost");
    }

    public partial class FieldDefinitionPerformanceMeasureChartTitle : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureChartTitle(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPerformanceMeasureChartTitle Instance = new FieldDefinitionPerformanceMeasureChartTitle(97, @"PerformanceMeasureChartTitle", @"Performance Measure Chart Title");
    }

    public partial class FieldDefinitionRoleName : FieldDefinition
    {
        private FieldDefinitionRoleName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionRoleName Instance = new FieldDefinitionRoleName(182, @"RoleName", @"Role Name");
    }

    public partial class FieldDefinitionRegion : FieldDefinition
    {
        private FieldDefinitionRegion(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionRegion Instance = new FieldDefinitionRegion(184, @"Region", @"Region (Geospatial),");
    }

    public partial class FieldDefinitionPerformanceMeasureChartCaption : FieldDefinition
    {
        private FieldDefinitionPerformanceMeasureChartCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPerformanceMeasureChartCaption Instance = new FieldDefinitionPerformanceMeasureChartCaption(228, @"PerformanceMeasureChartCaption", @"Chart Caption");
    }

    public partial class FieldDefinitionMonitoringProgram : FieldDefinition
    {
        private FieldDefinitionMonitoringProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringProgram Instance = new FieldDefinitionMonitoringProgram(236, @"MonitoringProgram", @"Monitoring Program");
    }

    public partial class FieldDefinitionMonitoringApproach : FieldDefinition
    {
        private FieldDefinitionMonitoringApproach(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringApproach Instance = new FieldDefinitionMonitoringApproach(237, @"MonitoringApproach", @"Monitoring Approach");
    }

    public partial class FieldDefinitionMonitoringProgramPartner : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramPartner(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringProgramPartner Instance = new FieldDefinitionMonitoringProgramPartner(238, @"MonitoringProgramPartner", @"Monitoring Program Partner");
    }

    public partial class FieldDefinitionMonitoringProgramUrl : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringProgramUrl Instance = new FieldDefinitionMonitoringProgramUrl(239, @"MonitoringProgramUrl", @"Monitoring Program Home Page");
    }

    public partial class FieldDefinitionThresholdCategoryDescription : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryDescription Instance = new FieldDefinitionThresholdCategoryDescription(240, @"ThresholdCategoryDescription", @"Threshold Category Description");
    }

    public partial class FieldDefinitionThresholdCategoryGoalStatement : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryGoalStatement(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryGoalStatement Instance = new FieldDefinitionThresholdCategoryGoalStatement(241, @"ThresholdCategoryGoalStatement", @"Threshold Category Goal Statement");
    }

    public partial class FieldDefinitionThresholdCategoryNarrative : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryNarrative(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryNarrative Instance = new FieldDefinitionThresholdCategoryNarrative(242, @"ThresholdCategoryNarrative", @"Threshold Category Narrative");
    }
}