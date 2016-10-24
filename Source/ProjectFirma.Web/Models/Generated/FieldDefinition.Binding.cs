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
        public static readonly FieldDefinitionLocalAndRegionalPlanName LocalAndRegionalPlanName = FieldDefinitionLocalAndRegionalPlanName.Instance;
        public static readonly FieldDefinitionExpectedValue ExpectedValue = FieldDefinitionExpectedValue.Instance;
        public static readonly FieldDefinitionFocusArea FocusArea = FieldDefinitionFocusArea.Instance;
        public static readonly FieldDefinitionFocusAreaName FocusAreaName = FieldDefinitionFocusAreaName.Instance;
        public static readonly FieldDefinitionFunder Funder = FieldDefinitionFunder.Instance;
        public static readonly FieldDefinitionFundingSource FundingSource = FieldDefinitionFundingSource.Instance;
        public static readonly FieldDefinitionFundingSourceDescription FundingSourceDescription = FieldDefinitionFundingSourceDescription.Instance;
        public static readonly FieldDefinitionFundingSourceName FundingSourceName = FieldDefinitionFundingSourceName.Instance;
        public static readonly FieldDefinitionImplementer Implementer = FieldDefinitionImplementer.Instance;
        public static readonly FieldDefinitionLeadImplementer LeadImplementer = FieldDefinitionLeadImplementer.Instance;
        public static readonly FieldDefinitionOldEIPNumber OldEIPNumber = FieldDefinitionOldEIPNumber.Instance;
        public static readonly FieldDefinitionOrganization Organization = FieldDefinitionOrganization.Instance;
        public static readonly FieldDefinitionOrganizationAbbreviation OrganizationAbbreviation = FieldDefinitionOrganizationAbbreviation.Instance;
        public static readonly FieldDefinitionOrganizationName OrganizationName = FieldDefinitionOrganizationName.Instance;
        public static readonly FieldDefinitionPassword Password = FieldDefinitionPassword.Instance;
        public static readonly FieldDefinitionEIPPerformanceMeasure EIPPerformanceMeasure = FieldDefinitionEIPPerformanceMeasure.Instance;
        public static readonly FieldDefinitionIndicatorDefinition IndicatorDefinition = FieldDefinitionIndicatorDefinition.Instance;
        public static readonly FieldDefinitionIndicatorDisplayName IndicatorDisplayName = FieldDefinitionIndicatorDisplayName.Instance;
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
        public static readonly FieldDefinitionStage Stage = FieldDefinitionStage.Instance;
        public static readonly FieldDefinitionSubcategories Subcategories = FieldDefinitionSubcategories.Instance;
        public static readonly FieldDefinitionProjectIsAProgram ProjectIsAProgram = FieldDefinitionProjectIsAProgram.Instance;
        public static readonly FieldDefinitionThresholdCategoryName ThresholdCategoryName = FieldDefinitionThresholdCategoryName.Instance;
        public static readonly FieldDefinitionEstimatedTotalCost EstimatedTotalCost = FieldDefinitionEstimatedTotalCost.Instance;
        public static readonly FieldDefinitionUnfundedNeed UnfundedNeed = FieldDefinitionUnfundedNeed.Instance;
        public static readonly FieldDefinitionUsername Username = FieldDefinitionUsername.Instance;
        public static readonly FieldDefinitionWatershedName WatershedName = FieldDefinitionWatershedName.Instance;
        public static readonly FieldDefinitionProject Project = FieldDefinitionProject.Instance;
        public static readonly FieldDefinitionProjectNumber ProjectNumber = FieldDefinitionProjectNumber.Instance;
        public static readonly FieldDefinitionThresholdCategory ThresholdCategory = FieldDefinitionThresholdCategory.Instance;
        public static readonly FieldDefinitionLocalAndRegionalPlan LocalAndRegionalPlan = FieldDefinitionLocalAndRegionalPlan.Instance;
        public static readonly FieldDefinitionWatershed Watershed = FieldDefinitionWatershed.Instance;
        public static readonly FieldDefinitionSubcategory Subcategory = FieldDefinitionSubcategory.Instance;
        public static readonly FieldDefinitionSubcategoryOption SubcategoryOption = FieldDefinitionSubcategoryOption.Instance;
        public static readonly FieldDefinitionSubcategoryOptions SubcategoryOptions = FieldDefinitionSubcategoryOptions.Instance;
        public static readonly FieldDefinitionIsPrimaryProgram IsPrimaryProgram = FieldDefinitionIsPrimaryProgram.Instance;
        public static readonly FieldDefinitionIndicatorCriticalDefinitions IndicatorCriticalDefinitions = FieldDefinitionIndicatorCriticalDefinitions.Instance;
        public static readonly FieldDefinitionIndicatorAccountingPeriodAndScale IndicatorAccountingPeriodAndScale = FieldDefinitionIndicatorAccountingPeriodAndScale.Instance;
        public static readonly FieldDefinitionIndicatorProjectReporting IndicatorProjectReporting = FieldDefinitionIndicatorProjectReporting.Instance;
        public static readonly FieldDefinitionFundedAmount FundedAmount = FieldDefinitionFundedAmount.Instance;
        public static readonly FieldDefinitionProjectLocation ProjectLocation = FieldDefinitionProjectLocation.Instance;
        public static readonly FieldDefinitionIndicatorBackground IndicatorBackground = FieldDefinitionIndicatorBackground.Instance;
        public static readonly FieldDefinitionNumberOfReportedPMRecords NumberOfReportedPMRecords = FieldDefinitionNumberOfReportedPMRecords.Instance;
        public static readonly FieldDefinitionNumberOfReportedExpenditureRecords NumberOfReportedExpenditureRecords = FieldDefinitionNumberOfReportedExpenditureRecords.Instance;
        public static readonly FieldDefinitionProjectLocationState ProjectLocationState = FieldDefinitionProjectLocationState.Instance;
        public static readonly FieldDefinitionProjectLocationJurisdiction ProjectLocationJurisdiction = FieldDefinitionProjectLocationJurisdiction.Instance;
        public static readonly FieldDefinitionProjectLocationWatershed ProjectLocationWatershed = FieldDefinitionProjectLocationWatershed.Instance;
        public static readonly FieldDefinitionExcludeFromFactSheet ExcludeFromFactSheet = FieldDefinitionExcludeFromFactSheet.Instance;
        public static readonly FieldDefinitionTransportationStrategy TransportationStrategy = FieldDefinitionTransportationStrategy.Instance;
        public static readonly FieldDefinitionTransportationObjective TransportationObjective = FieldDefinitionTransportationObjective.Instance;
        public static readonly FieldDefinitionTransportationStrategyName TransportationStrategyName = FieldDefinitionTransportationStrategyName.Instance;
        public static readonly FieldDefinitionTransportationObjectiveName TransportationObjectiveName = FieldDefinitionTransportationObjectiveName.Instance;
        public static readonly FieldDefinitionProjectIsATransportationProject ProjectIsATransportationProject = FieldDefinitionProjectIsATransportationProject.Instance;
        public static readonly FieldDefinitionIsTransportationFundingSource IsTransportationFundingSource = FieldDefinitionIsTransportationFundingSource.Instance;
        public static readonly FieldDefinitionFundingType FundingType = FieldDefinitionFundingType.Instance;
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure ProjectCostInYearOfExpenditure = FieldDefinitionProjectCostInYearOfExpenditure.Instance;
        public static readonly FieldDefinitionTransportationGlobalInflationRate TransportationGlobalInflationRate = FieldDefinitionTransportationGlobalInflationRate.Instance;
        public static readonly FieldDefinitionReportingYear ReportingYear = FieldDefinitionReportingYear.Instance;
        public static readonly FieldDefinitionTagName TagName = FieldDefinitionTagName.Instance;
        public static readonly FieldDefinitionTagDescription TagDescription = FieldDefinitionTagDescription.Instance;
        public static readonly FieldDefinitionTags Tags = FieldDefinitionTags.Instance;
        public static readonly FieldDefinitionReportedExpenditure ReportedExpenditure = FieldDefinitionReportedExpenditure.Instance;
        public static readonly FieldDefinitionProposedProject ProposedProject = FieldDefinitionProposedProject.Instance;
        public static readonly FieldDefinitionProjectOnFTIPList ProjectOnFTIPList = FieldDefinitionProjectOnFTIPList.Instance;
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentUrl LocalAndRegionalPlanDocumentUrl = FieldDefinitionLocalAndRegionalPlanDocumentUrl.Instance;
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentLinkText LocalAndRegionalPlanDocumentLinkText = FieldDefinitionLocalAndRegionalPlanDocumentLinkText.Instance;
        public static readonly FieldDefinitionSpendingAssociatedWithPM SpendingAssociatedWithPM = FieldDefinitionSpendingAssociatedWithPM.Instance;
        public static readonly FieldDefinitionPlanningDesignStartYear PlanningDesignStartYear = FieldDefinitionPlanningDesignStartYear.Instance;
        public static readonly FieldDefinitionAssociatedPrograms AssociatedPrograms = FieldDefinitionAssociatedPrograms.Instance;
        public static readonly FieldDefinitionExternalLinks ExternalLinks = FieldDefinitionExternalLinks.Instance;
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost EstimatedAnnualOperatingCost = FieldDefinitionEstimatedAnnualOperatingCost.Instance;
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost CalculatedTotalRemainingOperatingCost = FieldDefinitionCalculatedTotalRemainingOperatingCost.Instance;
        public static readonly FieldDefinitionCurrentRTPYearForPVCalculations CurrentRTPYearForPVCalculations = FieldDefinitionCurrentRTPYearForPVCalculations.Instance;
        public static readonly FieldDefinitionLifecycleOperatingCost LifecycleOperatingCost = FieldDefinitionLifecycleOperatingCost.Instance;
        public static readonly FieldDefinitionIndicatorSystemName IndicatorSystemName = FieldDefinitionIndicatorSystemName.Instance;
        public static readonly FieldDefinitionIndicatorSimpleDescription IndicatorSimpleDescription = FieldDefinitionIndicatorSimpleDescription.Instance;
        public static readonly FieldDefinitionIndicatorPrimarySource IndicatorPrimarySource = FieldDefinitionIndicatorPrimarySource.Instance;
        public static readonly FieldDefinitionIndicatorType IndicatorType = FieldDefinitionIndicatorType.Instance;
        public static readonly FieldDefinitionChartTitle ChartTitle = FieldDefinitionChartTitle.Instance;
        public static readonly FieldDefinitionProposedProjectState ProposedProjectState = FieldDefinitionProposedProjectState.Instance;
        public static readonly FieldDefinitionUserLastName UserLastName = FieldDefinitionUserLastName.Instance;
        public static readonly FieldDefinitionUserFirstName UserFirstName = FieldDefinitionUserFirstName.Instance;
        public static readonly FieldDefinitionUserEmail UserEmail = FieldDefinitionUserEmail.Instance;
        public static readonly FieldDefinitionUserPhone UserPhone = FieldDefinitionUserPhone.Instance;
        public static readonly FieldDefinitionEIPRoleID EIPRoleID = FieldDefinitionEIPRoleID.Instance;
        public static readonly FieldDefinitionParcelTrackerRoleID ParcelTrackerRoleID = FieldDefinitionParcelTrackerRoleID.Instance;
        public static readonly FieldDefinitionSustainabilityRoleID SustainabilityRoleID = FieldDefinitionSustainabilityRoleID.Instance;
        public static readonly FieldDefinitionLTInfoRoleID LTInfoRoleID = FieldDefinitionLTInfoRoleID.Instance;
        public static readonly FieldDefinitionSiteArea SiteArea = FieldDefinitionSiteArea.Instance;
        public static readonly FieldDefinitionRoleName RoleName = FieldDefinitionRoleName.Instance;
        public static readonly FieldDefinitionRegion Region = FieldDefinitionRegion.Instance;
        public static readonly FieldDefinitionLatitude Latitude = FieldDefinitionLatitude.Instance;
        public static readonly FieldDefinitionLongitude Longitude = FieldDefinitionLongitude.Instance;
        public static readonly FieldDefinitionOrganizationUrl OrganizationUrl = FieldDefinitionOrganizationUrl.Instance;
        public static readonly FieldDefinitionThresholdReportingCategory ThresholdReportingCategory = FieldDefinitionThresholdReportingCategory.Instance;
        public static readonly FieldDefinitionApplicableStandard ApplicableStandard = FieldDefinitionApplicableStandard.Instance;
        public static readonly FieldDefinitionStandardNarrative StandardNarrative = FieldDefinitionStandardNarrative.Instance;
        public static readonly FieldDefinitionTRPAIndicator TRPAIndicator = FieldDefinitionTRPAIndicator.Instance;
        public static readonly FieldDefinitionThresholdEvaluationStatus ThresholdEvaluationStatus = FieldDefinitionThresholdEvaluationStatus.Instance;
        public static readonly FieldDefinitionThresholdEvaluationTrend ThresholdEvaluationTrend = FieldDefinitionThresholdEvaluationTrend.Instance;
        public static readonly FieldDefinitionThresholdEvaluationConfidence ThresholdEvaluationConfidence = FieldDefinitionThresholdEvaluationConfidence.Instance;
        public static readonly FieldDefinitionThresholdEvaluationStatusRationale ThresholdEvaluationStatusRationale = FieldDefinitionThresholdEvaluationStatusRationale.Instance;
        public static readonly FieldDefinitionThresholdEvaluationTrendRationale ThresholdEvaluationTrendRationale = FieldDefinitionThresholdEvaluationTrendRationale.Instance;
        public static readonly FieldDefinitionThresholdEvaluationConfidenceStatus ThresholdEvaluationConfidenceStatus = FieldDefinitionThresholdEvaluationConfidenceStatus.Instance;
        public static readonly FieldDefinitionThresholdEvaluationManagementStatus ThresholdEvaluationManagementStatus = FieldDefinitionThresholdEvaluationManagementStatus.Instance;
        public static readonly FieldDefinitionThresholdEvaluationProgramsAndActionsImplementedToImproveConditions ThresholdEvaluationProgramsAndActionsImplementedToImproveConditions = FieldDefinitionThresholdEvaluationProgramsAndActionsImplementedToImproveConditions.Instance;
        public static readonly FieldDefinitionThresholdRoleID ThresholdRoleID = FieldDefinitionThresholdRoleID.Instance;
        public static readonly FieldDefinitionThresholdEvaluationConfidenceTrend ThresholdEvaluationConfidenceTrend = FieldDefinitionThresholdEvaluationConfidenceTrend.Instance;
        public static readonly FieldDefinitionThresholdEvaluationConfidenceOverall ThresholdEvaluationConfidenceOverall = FieldDefinitionThresholdEvaluationConfidenceOverall.Instance;
        public static readonly FieldDefinitionThresholdEvaluationEffectivenessOfProgramsAndActions ThresholdEvaluationEffectivenessOfProgramsAndActions = FieldDefinitionThresholdEvaluationEffectivenessOfProgramsAndActions.Instance;
        public static readonly FieldDefinitionThresholdEvaluationInterimTarget ThresholdEvaluationInterimTarget = FieldDefinitionThresholdEvaluationInterimTarget.Instance;
        public static readonly FieldDefinitionThresholdEvaluationTargetAttainmentDate ThresholdEvaluationTargetAttainmentDate = FieldDefinitionThresholdEvaluationTargetAttainmentDate.Instance;
        public static readonly FieldDefinitionThresholdEvaluationAnalyticApproach ThresholdEvaluationAnalyticApproach = FieldDefinitionThresholdEvaluationAnalyticApproach.Instance;
        public static readonly FieldDefinitionThresholdEvaluationMonitoringApproach ThresholdEvaluationMonitoringApproach = FieldDefinitionThresholdEvaluationMonitoringApproach.Instance;
        public static readonly FieldDefinitionThresholdEvaluationModificationOfTheThresholdStandardOrIndicator ThresholdEvaluationModificationOfTheThresholdStandardOrIndicator = FieldDefinitionThresholdEvaluationModificationOfTheThresholdStandardOrIndicator.Instance;
        public static readonly FieldDefinitionThresholdEvaluationAttainOrMaintainThreshold ThresholdEvaluationAttainOrMaintainThreshold = FieldDefinitionThresholdEvaluationAttainOrMaintainThreshold.Instance;
        public static readonly FieldDefinitionThresholdEvaluationMonitoringAndAnalysis ThresholdEvaluationMonitoringAndAnalysis = FieldDefinitionThresholdEvaluationMonitoringAndAnalysis.Instance;
        public static readonly FieldDefinitionThresholdReportingCategoryNarrative ThresholdReportingCategoryNarrative = FieldDefinitionThresholdReportingCategoryNarrative.Instance;
        public static readonly FieldDefinitionChartCaption ChartCaption = FieldDefinitionChartCaption.Instance;
        public static readonly FieldDefinitionRelevance Relevance = FieldDefinitionRelevance.Instance;
        public static readonly FieldDefinitionHumanAndEnvironmentalDrivers HumanAndEnvironmentalDrivers = FieldDefinitionHumanAndEnvironmentalDrivers.Instance;
        public static readonly FieldDefinitionThresholdStandardType ThresholdStandardType = FieldDefinitionThresholdStandardType.Instance;
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
            All = new List<FieldDefinition> { ActionPriority, ActionPriorityName, LocalAndRegionalPlanName, ExpectedValue, FocusArea, FocusAreaName, Funder, FundingSource, FundingSourceDescription, FundingSourceName, Implementer, LeadImplementer, OldEIPNumber, Organization, OrganizationAbbreviation, OrganizationName, Password, EIPPerformanceMeasure, IndicatorDefinition, IndicatorDisplayName, MeasurementUnit, PhotoCaption, PhotoCredit, PhotoTiming, PrimaryContact, Program, ProgramName, CompletionYear, ProjectDescription, ProjectName, ProjectNote, ImplementationStartYear, ReportedValue, Sector, SecuredFunding, Stage, Subcategories, ProjectIsAProgram, ThresholdCategoryName, EstimatedTotalCost, UnfundedNeed, Username, WatershedName, Project, ProjectNumber, ThresholdCategory, LocalAndRegionalPlan, Watershed, Subcategory, SubcategoryOption, SubcategoryOptions, IsPrimaryProgram, IndicatorCriticalDefinitions, IndicatorAccountingPeriodAndScale, IndicatorProjectReporting, FundedAmount, ProjectLocation, IndicatorBackground, NumberOfReportedPMRecords, NumberOfReportedExpenditureRecords, ProjectLocationState, ProjectLocationJurisdiction, ProjectLocationWatershed, ExcludeFromFactSheet, TransportationStrategy, TransportationObjective, TransportationStrategyName, TransportationObjectiveName, ProjectIsATransportationProject, IsTransportationFundingSource, FundingType, ProjectCostInYearOfExpenditure, TransportationGlobalInflationRate, ReportingYear, TagName, TagDescription, Tags, ReportedExpenditure, ProposedProject, ProjectOnFTIPList, LocalAndRegionalPlanDocumentUrl, LocalAndRegionalPlanDocumentLinkText, SpendingAssociatedWithPM, PlanningDesignStartYear, AssociatedPrograms, ExternalLinks, EstimatedAnnualOperatingCost, CalculatedTotalRemainingOperatingCost, CurrentRTPYearForPVCalculations, LifecycleOperatingCost, IndicatorSystemName, IndicatorSimpleDescription, IndicatorPrimarySource, IndicatorType, ChartTitle, ProposedProjectState, UserLastName, UserFirstName, UserEmail, UserPhone, EIPRoleID, ParcelTrackerRoleID, SustainabilityRoleID, LTInfoRoleID, SiteArea, RoleName, Region, Latitude, Longitude, OrganizationUrl, ThresholdReportingCategory, ApplicableStandard, StandardNarrative, TRPAIndicator, ThresholdEvaluationStatus, ThresholdEvaluationTrend, ThresholdEvaluationConfidence, ThresholdEvaluationStatusRationale, ThresholdEvaluationTrendRationale, ThresholdEvaluationConfidenceStatus, ThresholdEvaluationManagementStatus, ThresholdEvaluationProgramsAndActionsImplementedToImproveConditions, ThresholdRoleID, ThresholdEvaluationConfidenceTrend, ThresholdEvaluationConfidenceOverall, ThresholdEvaluationEffectivenessOfProgramsAndActions, ThresholdEvaluationInterimTarget, ThresholdEvaluationTargetAttainmentDate, ThresholdEvaluationAnalyticApproach, ThresholdEvaluationMonitoringApproach, ThresholdEvaluationModificationOfTheThresholdStandardOrIndicator, ThresholdEvaluationAttainOrMaintainThreshold, ThresholdEvaluationMonitoringAndAnalysis, ThresholdReportingCategoryNarrative, ChartCaption, Relevance, HumanAndEnvironmentalDrivers, ThresholdStandardType, MonitoringProgram, MonitoringApproach, MonitoringProgramPartner, MonitoringProgramUrl, ThresholdCategoryDescription, ThresholdCategoryGoalStatement, ThresholdCategoryNarrative };
            AllLookupDictionary = new ReadOnlyDictionary<int, FieldDefinition>(All.ToDictionary(x => x.FieldDefinitionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FieldDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID)
        {
            FieldDefinitionID = fieldDefinitionID;
            FieldDefinitionName = fieldDefinitionName;
            FieldDefinitionDisplayName = fieldDefinitionDisplayName;
            PrimaryLTInfoAreaID = primaryLTInfoAreaID;
        }
        public LTInfoArea PrimaryLTInfoArea { get { return LTInfoArea.AllLookupDictionary[PrimaryLTInfoAreaID]; } }
        [Key]
        public int FieldDefinitionID { get; private set; }
        public string FieldDefinitionName { get; private set; }
        public string FieldDefinitionDisplayName { get; private set; }
        public int PrimaryLTInfoAreaID { get; private set; }
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
                case FieldDefinitionEnum.ApplicableStandard:
                    return ApplicableStandard;
                case FieldDefinitionEnum.AssociatedPrograms:
                    return AssociatedPrograms;
                case FieldDefinitionEnum.CalculatedTotalRemainingOperatingCost:
                    return CalculatedTotalRemainingOperatingCost;
                case FieldDefinitionEnum.ChartCaption:
                    return ChartCaption;
                case FieldDefinitionEnum.ChartTitle:
                    return ChartTitle;
                case FieldDefinitionEnum.CompletionYear:
                    return CompletionYear;
                case FieldDefinitionEnum.CurrentRTPYearForPVCalculations:
                    return CurrentRTPYearForPVCalculations;
                case FieldDefinitionEnum.EIPPerformanceMeasure:
                    return EIPPerformanceMeasure;
                case FieldDefinitionEnum.EIPRoleID:
                    return EIPRoleID;
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
                case FieldDefinitionEnum.HumanAndEnvironmentalDrivers:
                    return HumanAndEnvironmentalDrivers;
                case FieldDefinitionEnum.ImplementationStartYear:
                    return ImplementationStartYear;
                case FieldDefinitionEnum.Implementer:
                    return Implementer;
                case FieldDefinitionEnum.IndicatorAccountingPeriodAndScale:
                    return IndicatorAccountingPeriodAndScale;
                case FieldDefinitionEnum.IndicatorBackground:
                    return IndicatorBackground;
                case FieldDefinitionEnum.IndicatorCriticalDefinitions:
                    return IndicatorCriticalDefinitions;
                case FieldDefinitionEnum.IndicatorDefinition:
                    return IndicatorDefinition;
                case FieldDefinitionEnum.IndicatorDisplayName:
                    return IndicatorDisplayName;
                case FieldDefinitionEnum.IndicatorPrimarySource:
                    return IndicatorPrimarySource;
                case FieldDefinitionEnum.IndicatorProjectReporting:
                    return IndicatorProjectReporting;
                case FieldDefinitionEnum.IndicatorSimpleDescription:
                    return IndicatorSimpleDescription;
                case FieldDefinitionEnum.IndicatorSystemName:
                    return IndicatorSystemName;
                case FieldDefinitionEnum.IndicatorType:
                    return IndicatorType;
                case FieldDefinitionEnum.IsPrimaryProgram:
                    return IsPrimaryProgram;
                case FieldDefinitionEnum.IsTransportationFundingSource:
                    return IsTransportationFundingSource;
                case FieldDefinitionEnum.Latitude:
                    return Latitude;
                case FieldDefinitionEnum.LeadImplementer:
                    return LeadImplementer;
                case FieldDefinitionEnum.LifecycleOperatingCost:
                    return LifecycleOperatingCost;
                case FieldDefinitionEnum.LocalAndRegionalPlan:
                    return LocalAndRegionalPlan;
                case FieldDefinitionEnum.LocalAndRegionalPlanDocumentLinkText:
                    return LocalAndRegionalPlanDocumentLinkText;
                case FieldDefinitionEnum.LocalAndRegionalPlanDocumentUrl:
                    return LocalAndRegionalPlanDocumentUrl;
                case FieldDefinitionEnum.LocalAndRegionalPlanName:
                    return LocalAndRegionalPlanName;
                case FieldDefinitionEnum.Longitude:
                    return Longitude;
                case FieldDefinitionEnum.LTInfoRoleID:
                    return LTInfoRoleID;
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
                case FieldDefinitionEnum.NumberOfReportedExpenditureRecords:
                    return NumberOfReportedExpenditureRecords;
                case FieldDefinitionEnum.NumberOfReportedPMRecords:
                    return NumberOfReportedPMRecords;
                case FieldDefinitionEnum.OldEIPNumber:
                    return OldEIPNumber;
                case FieldDefinitionEnum.Organization:
                    return Organization;
                case FieldDefinitionEnum.OrganizationAbbreviation:
                    return OrganizationAbbreviation;
                case FieldDefinitionEnum.OrganizationName:
                    return OrganizationName;
                case FieldDefinitionEnum.OrganizationUrl:
                    return OrganizationUrl;
                case FieldDefinitionEnum.ParcelTrackerRoleID:
                    return ParcelTrackerRoleID;
                case FieldDefinitionEnum.Password:
                    return Password;
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
                case FieldDefinitionEnum.ProjectIsAProgram:
                    return ProjectIsAProgram;
                case FieldDefinitionEnum.ProjectIsATransportationProject:
                    return ProjectIsATransportationProject;
                case FieldDefinitionEnum.ProjectLocation:
                    return ProjectLocation;
                case FieldDefinitionEnum.ProjectLocationJurisdiction:
                    return ProjectLocationJurisdiction;
                case FieldDefinitionEnum.ProjectLocationState:
                    return ProjectLocationState;
                case FieldDefinitionEnum.ProjectLocationWatershed:
                    return ProjectLocationWatershed;
                case FieldDefinitionEnum.ProjectName:
                    return ProjectName;
                case FieldDefinitionEnum.ProjectNote:
                    return ProjectNote;
                case FieldDefinitionEnum.ProjectNumber:
                    return ProjectNumber;
                case FieldDefinitionEnum.ProjectOnFTIPList:
                    return ProjectOnFTIPList;
                case FieldDefinitionEnum.ProposedProject:
                    return ProposedProject;
                case FieldDefinitionEnum.ProposedProjectState:
                    return ProposedProjectState;
                case FieldDefinitionEnum.Region:
                    return Region;
                case FieldDefinitionEnum.Relevance:
                    return Relevance;
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
                case FieldDefinitionEnum.SiteArea:
                    return SiteArea;
                case FieldDefinitionEnum.SpendingAssociatedWithPM:
                    return SpendingAssociatedWithPM;
                case FieldDefinitionEnum.Stage:
                    return Stage;
                case FieldDefinitionEnum.StandardNarrative:
                    return StandardNarrative;
                case FieldDefinitionEnum.Subcategories:
                    return Subcategories;
                case FieldDefinitionEnum.Subcategory:
                    return Subcategory;
                case FieldDefinitionEnum.SubcategoryOption:
                    return SubcategoryOption;
                case FieldDefinitionEnum.SubcategoryOptions:
                    return SubcategoryOptions;
                case FieldDefinitionEnum.SustainabilityRoleID:
                    return SustainabilityRoleID;
                case FieldDefinitionEnum.TagDescription:
                    return TagDescription;
                case FieldDefinitionEnum.TagName:
                    return TagName;
                case FieldDefinitionEnum.Tags:
                    return Tags;
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
                case FieldDefinitionEnum.ThresholdEvaluationAnalyticApproach:
                    return ThresholdEvaluationAnalyticApproach;
                case FieldDefinitionEnum.ThresholdEvaluationAttainOrMaintainThreshold:
                    return ThresholdEvaluationAttainOrMaintainThreshold;
                case FieldDefinitionEnum.ThresholdEvaluationConfidence:
                    return ThresholdEvaluationConfidence;
                case FieldDefinitionEnum.ThresholdEvaluationConfidenceOverall:
                    return ThresholdEvaluationConfidenceOverall;
                case FieldDefinitionEnum.ThresholdEvaluationConfidenceStatus:
                    return ThresholdEvaluationConfidenceStatus;
                case FieldDefinitionEnum.ThresholdEvaluationConfidenceTrend:
                    return ThresholdEvaluationConfidenceTrend;
                case FieldDefinitionEnum.ThresholdEvaluationEffectivenessOfProgramsAndActions:
                    return ThresholdEvaluationEffectivenessOfProgramsAndActions;
                case FieldDefinitionEnum.ThresholdEvaluationInterimTarget:
                    return ThresholdEvaluationInterimTarget;
                case FieldDefinitionEnum.ThresholdEvaluationManagementStatus:
                    return ThresholdEvaluationManagementStatus;
                case FieldDefinitionEnum.ThresholdEvaluationModificationOfTheThresholdStandardOrIndicator:
                    return ThresholdEvaluationModificationOfTheThresholdStandardOrIndicator;
                case FieldDefinitionEnum.ThresholdEvaluationMonitoringAndAnalysis:
                    return ThresholdEvaluationMonitoringAndAnalysis;
                case FieldDefinitionEnum.ThresholdEvaluationMonitoringApproach:
                    return ThresholdEvaluationMonitoringApproach;
                case FieldDefinitionEnum.ThresholdEvaluationProgramsAndActionsImplementedToImproveConditions:
                    return ThresholdEvaluationProgramsAndActionsImplementedToImproveConditions;
                case FieldDefinitionEnum.ThresholdEvaluationStatus:
                    return ThresholdEvaluationStatus;
                case FieldDefinitionEnum.ThresholdEvaluationStatusRationale:
                    return ThresholdEvaluationStatusRationale;
                case FieldDefinitionEnum.ThresholdEvaluationTargetAttainmentDate:
                    return ThresholdEvaluationTargetAttainmentDate;
                case FieldDefinitionEnum.ThresholdEvaluationTrend:
                    return ThresholdEvaluationTrend;
                case FieldDefinitionEnum.ThresholdEvaluationTrendRationale:
                    return ThresholdEvaluationTrendRationale;
                case FieldDefinitionEnum.ThresholdReportingCategory:
                    return ThresholdReportingCategory;
                case FieldDefinitionEnum.ThresholdReportingCategoryNarrative:
                    return ThresholdReportingCategoryNarrative;
                case FieldDefinitionEnum.ThresholdRoleID:
                    return ThresholdRoleID;
                case FieldDefinitionEnum.ThresholdStandardType:
                    return ThresholdStandardType;
                case FieldDefinitionEnum.TransportationGlobalInflationRate:
                    return TransportationGlobalInflationRate;
                case FieldDefinitionEnum.TransportationObjective:
                    return TransportationObjective;
                case FieldDefinitionEnum.TransportationObjectiveName:
                    return TransportationObjectiveName;
                case FieldDefinitionEnum.TransportationStrategy:
                    return TransportationStrategy;
                case FieldDefinitionEnum.TransportationStrategyName:
                    return TransportationStrategyName;
                case FieldDefinitionEnum.TRPAIndicator:
                    return TRPAIndicator;
                case FieldDefinitionEnum.UnfundedNeed:
                    return UnfundedNeed;
                case FieldDefinitionEnum.UserEmail:
                    return UserEmail;
                case FieldDefinitionEnum.UserFirstName:
                    return UserFirstName;
                case FieldDefinitionEnum.UserLastName:
                    return UserLastName;
                case FieldDefinitionEnum.Username:
                    return Username;
                case FieldDefinitionEnum.UserPhone:
                    return UserPhone;
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
        LocalAndRegionalPlanName = 3,
        ExpectedValue = 4,
        FocusArea = 5,
        FocusAreaName = 6,
        Funder = 7,
        FundingSource = 8,
        FundingSourceDescription = 9,
        FundingSourceName = 10,
        Implementer = 11,
        LeadImplementer = 12,
        OldEIPNumber = 13,
        Organization = 14,
        OrganizationAbbreviation = 15,
        OrganizationName = 16,
        Password = 17,
        EIPPerformanceMeasure = 18,
        IndicatorDefinition = 19,
        IndicatorDisplayName = 20,
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
        Stage = 36,
        Subcategories = 37,
        ProjectIsAProgram = 38,
        ThresholdCategoryName = 39,
        EstimatedTotalCost = 40,
        UnfundedNeed = 41,
        Username = 42,
        WatershedName = 43,
        Project = 44,
        ProjectNumber = 45,
        ThresholdCategory = 46,
        LocalAndRegionalPlan = 47,
        Watershed = 48,
        Subcategory = 49,
        SubcategoryOption = 50,
        SubcategoryOptions = 51,
        IsPrimaryProgram = 52,
        IndicatorCriticalDefinitions = 53,
        IndicatorAccountingPeriodAndScale = 54,
        IndicatorProjectReporting = 55,
        FundedAmount = 56,
        ProjectLocation = 57,
        IndicatorBackground = 58,
        NumberOfReportedPMRecords = 59,
        NumberOfReportedExpenditureRecords = 60,
        ProjectLocationState = 61,
        ProjectLocationJurisdiction = 62,
        ProjectLocationWatershed = 63,
        ExcludeFromFactSheet = 64,
        TransportationStrategy = 65,
        TransportationObjective = 66,
        TransportationStrategyName = 67,
        TransportationObjectiveName = 68,
        ProjectIsATransportationProject = 69,
        IsTransportationFundingSource = 72,
        FundingType = 73,
        ProjectCostInYearOfExpenditure = 74,
        TransportationGlobalInflationRate = 75,
        ReportingYear = 76,
        TagName = 77,
        TagDescription = 78,
        Tags = 79,
        ReportedExpenditure = 80,
        ProposedProject = 81,
        ProjectOnFTIPList = 82,
        LocalAndRegionalPlanDocumentUrl = 83,
        LocalAndRegionalPlanDocumentLinkText = 84,
        SpendingAssociatedWithPM = 85,
        PlanningDesignStartYear = 86,
        AssociatedPrograms = 87,
        ExternalLinks = 88,
        EstimatedAnnualOperatingCost = 89,
        CalculatedTotalRemainingOperatingCost = 90,
        CurrentRTPYearForPVCalculations = 91,
        LifecycleOperatingCost = 92,
        IndicatorSystemName = 93,
        IndicatorSimpleDescription = 94,
        IndicatorPrimarySource = 95,
        IndicatorType = 96,
        ChartTitle = 97,
        ProposedProjectState = 98,
        UserLastName = 173,
        UserFirstName = 174,
        UserEmail = 175,
        UserPhone = 176,
        EIPRoleID = 177,
        ParcelTrackerRoleID = 178,
        SustainabilityRoleID = 179,
        LTInfoRoleID = 180,
        SiteArea = 181,
        RoleName = 182,
        Region = 184,
        Latitude = 185,
        Longitude = 186,
        OrganizationUrl = 188,
        ThresholdReportingCategory = 204,
        ApplicableStandard = 205,
        StandardNarrative = 206,
        TRPAIndicator = 207,
        ThresholdEvaluationStatus = 208,
        ThresholdEvaluationTrend = 209,
        ThresholdEvaluationConfidence = 210,
        ThresholdEvaluationStatusRationale = 211,
        ThresholdEvaluationTrendRationale = 212,
        ThresholdEvaluationConfidenceStatus = 213,
        ThresholdEvaluationManagementStatus = 214,
        ThresholdEvaluationProgramsAndActionsImplementedToImproveConditions = 215,
        ThresholdRoleID = 216,
        ThresholdEvaluationConfidenceTrend = 217,
        ThresholdEvaluationConfidenceOverall = 218,
        ThresholdEvaluationEffectivenessOfProgramsAndActions = 219,
        ThresholdEvaluationInterimTarget = 220,
        ThresholdEvaluationTargetAttainmentDate = 221,
        ThresholdEvaluationAnalyticApproach = 222,
        ThresholdEvaluationMonitoringApproach = 223,
        ThresholdEvaluationModificationOfTheThresholdStandardOrIndicator = 224,
        ThresholdEvaluationAttainOrMaintainThreshold = 225,
        ThresholdEvaluationMonitoringAndAnalysis = 226,
        ThresholdReportingCategoryNarrative = 227,
        ChartCaption = 228,
        Relevance = 233,
        HumanAndEnvironmentalDrivers = 234,
        ThresholdStandardType = 235,
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
        private FieldDefinitionActionPriority(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionActionPriority Instance = new FieldDefinitionActionPriority(1, @"ActionPriority", @"Action Priority", 1);
    }

    public partial class FieldDefinitionActionPriorityName : FieldDefinition
    {
        private FieldDefinitionActionPriorityName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionActionPriorityName Instance = new FieldDefinitionActionPriorityName(2, @"ActionPriorityName", @"Action Priority Name", 1);
    }

    public partial class FieldDefinitionLocalAndRegionalPlanName : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlanName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLocalAndRegionalPlanName Instance = new FieldDefinitionLocalAndRegionalPlanName(3, @"LocalAndRegionalPlanName", @"Local and Regional Plan Name", 1);
    }

    public partial class FieldDefinitionExpectedValue : FieldDefinition
    {
        private FieldDefinitionExpectedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionExpectedValue Instance = new FieldDefinitionExpectedValue(4, @"ExpectedValue", @"Expected Value", 1);
    }

    public partial class FieldDefinitionFocusArea : FieldDefinition
    {
        private FieldDefinitionFocusArea(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFocusArea Instance = new FieldDefinitionFocusArea(5, @"FocusArea", @"Focus Area", 1);
    }

    public partial class FieldDefinitionFocusAreaName : FieldDefinition
    {
        private FieldDefinitionFocusAreaName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFocusAreaName Instance = new FieldDefinitionFocusAreaName(6, @"FocusAreaName", @"Focus Area Name", 1);
    }

    public partial class FieldDefinitionFunder : FieldDefinition
    {
        private FieldDefinitionFunder(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFunder Instance = new FieldDefinitionFunder(7, @"Funder", @"Funder", 1);
    }

    public partial class FieldDefinitionFundingSource : FieldDefinition
    {
        private FieldDefinitionFundingSource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFundingSource Instance = new FieldDefinitionFundingSource(8, @"FundingSource", @"Funding Source", 1);
    }

    public partial class FieldDefinitionFundingSourceDescription : FieldDefinition
    {
        private FieldDefinitionFundingSourceDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFundingSourceDescription Instance = new FieldDefinitionFundingSourceDescription(9, @"FundingSourceDescription", @"Funding Source Description", 1);
    }

    public partial class FieldDefinitionFundingSourceName : FieldDefinition
    {
        private FieldDefinitionFundingSourceName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFundingSourceName Instance = new FieldDefinitionFundingSourceName(10, @"FundingSourceName", @"Funding Source Name", 1);
    }

    public partial class FieldDefinitionImplementer : FieldDefinition
    {
        private FieldDefinitionImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionImplementer Instance = new FieldDefinitionImplementer(11, @"Implementer", @"Implementer", 1);
    }

    public partial class FieldDefinitionLeadImplementer : FieldDefinition
    {
        private FieldDefinitionLeadImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLeadImplementer Instance = new FieldDefinitionLeadImplementer(12, @"LeadImplementer", @"Lead Implementer", 1);
    }

    public partial class FieldDefinitionOldEIPNumber : FieldDefinition
    {
        private FieldDefinitionOldEIPNumber(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionOldEIPNumber Instance = new FieldDefinitionOldEIPNumber(13, @"OldEIPNumber", @"Old EIP #", 1);
    }

    public partial class FieldDefinitionOrganization : FieldDefinition
    {
        private FieldDefinitionOrganization(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionOrganization Instance = new FieldDefinitionOrganization(14, @"Organization", @"Organization", 1);
    }

    public partial class FieldDefinitionOrganizationAbbreviation : FieldDefinition
    {
        private FieldDefinitionOrganizationAbbreviation(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionOrganizationAbbreviation Instance = new FieldDefinitionOrganizationAbbreviation(15, @"OrganizationAbbreviation", @"Abbreviation", 1);
    }

    public partial class FieldDefinitionOrganizationName : FieldDefinition
    {
        private FieldDefinitionOrganizationName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionOrganizationName Instance = new FieldDefinitionOrganizationName(16, @"OrganizationName", @"Organization Name", 1);
    }

    public partial class FieldDefinitionPassword : FieldDefinition
    {
        private FieldDefinitionPassword(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionPassword Instance = new FieldDefinitionPassword(17, @"Password", @"Password", 3);
    }

    public partial class FieldDefinitionEIPPerformanceMeasure : FieldDefinition
    {
        private FieldDefinitionEIPPerformanceMeasure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionEIPPerformanceMeasure Instance = new FieldDefinitionEIPPerformanceMeasure(18, @"EIPPerformanceMeasure", @"EIP Performance Measure", 1);
    }

    public partial class FieldDefinitionIndicatorDefinition : FieldDefinition
    {
        private FieldDefinitionIndicatorDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorDefinition Instance = new FieldDefinitionIndicatorDefinition(19, @"IndicatorDefinition", @"Indicator Definition", 3);
    }

    public partial class FieldDefinitionIndicatorDisplayName : FieldDefinition
    {
        private FieldDefinitionIndicatorDisplayName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorDisplayName Instance = new FieldDefinitionIndicatorDisplayName(20, @"IndicatorDisplayName", @"Indicator Name", 3);
    }

    public partial class FieldDefinitionMeasurementUnit : FieldDefinition
    {
        private FieldDefinitionMeasurementUnit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionMeasurementUnit Instance = new FieldDefinitionMeasurementUnit(21, @"MeasurementUnit", @"Measurement Unit", 3);
    }

    public partial class FieldDefinitionPhotoCaption : FieldDefinition
    {
        private FieldDefinitionPhotoCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionPhotoCaption Instance = new FieldDefinitionPhotoCaption(22, @"PhotoCaption", @"Photo Caption", 1);
    }

    public partial class FieldDefinitionPhotoCredit : FieldDefinition
    {
        private FieldDefinitionPhotoCredit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionPhotoCredit Instance = new FieldDefinitionPhotoCredit(23, @"PhotoCredit", @"Photo Credit", 1);
    }

    public partial class FieldDefinitionPhotoTiming : FieldDefinition
    {
        private FieldDefinitionPhotoTiming(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionPhotoTiming Instance = new FieldDefinitionPhotoTiming(24, @"PhotoTiming", @"Photo Timing", 1);
    }

    public partial class FieldDefinitionPrimaryContact : FieldDefinition
    {
        private FieldDefinitionPrimaryContact(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionPrimaryContact Instance = new FieldDefinitionPrimaryContact(25, @"PrimaryContact", @"Primary Contact", 1);
    }

    public partial class FieldDefinitionProgram : FieldDefinition
    {
        private FieldDefinitionProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProgram Instance = new FieldDefinitionProgram(26, @"Program", @"Program", 1);
    }

    public partial class FieldDefinitionProgramName : FieldDefinition
    {
        private FieldDefinitionProgramName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProgramName Instance = new FieldDefinitionProgramName(27, @"ProgramName", @"Program Name", 1);
    }

    public partial class FieldDefinitionCompletionYear : FieldDefinition
    {
        private FieldDefinitionCompletionYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionCompletionYear Instance = new FieldDefinitionCompletionYear(28, @"CompletionYear", @"Completion Year", 1);
    }

    public partial class FieldDefinitionProjectDescription : FieldDefinition
    {
        private FieldDefinitionProjectDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectDescription Instance = new FieldDefinitionProjectDescription(29, @"ProjectDescription", @"Project Description", 1);
    }

    public partial class FieldDefinitionProjectName : FieldDefinition
    {
        private FieldDefinitionProjectName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectName Instance = new FieldDefinitionProjectName(30, @"ProjectName", @"Project Name", 1);
    }

    public partial class FieldDefinitionProjectNote : FieldDefinition
    {
        private FieldDefinitionProjectNote(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectNote Instance = new FieldDefinitionProjectNote(31, @"ProjectNote", @"Project Note", 1);
    }

    public partial class FieldDefinitionImplementationStartYear : FieldDefinition
    {
        private FieldDefinitionImplementationStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionImplementationStartYear Instance = new FieldDefinitionImplementationStartYear(32, @"ImplementationStartYear", @"Implementation Start Year", 1);
    }

    public partial class FieldDefinitionReportedValue : FieldDefinition
    {
        private FieldDefinitionReportedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionReportedValue Instance = new FieldDefinitionReportedValue(33, @"ReportedValue", @"Reported Value", 1);
    }

    public partial class FieldDefinitionSector : FieldDefinition
    {
        private FieldDefinitionSector(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSector Instance = new FieldDefinitionSector(34, @"Sector", @"Sector", 1);
    }

    public partial class FieldDefinitionSecuredFunding : FieldDefinition
    {
        private FieldDefinitionSecuredFunding(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSecuredFunding Instance = new FieldDefinitionSecuredFunding(35, @"SecuredFunding", @"Secured Funding", 1);
    }

    public partial class FieldDefinitionStage : FieldDefinition
    {
        private FieldDefinitionStage(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionStage Instance = new FieldDefinitionStage(36, @"Stage", @"Stage", 1);
    }

    public partial class FieldDefinitionSubcategories : FieldDefinition
    {
        private FieldDefinitionSubcategories(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSubcategories Instance = new FieldDefinitionSubcategories(37, @"Subcategories", @"Subcategories", 1);
    }

    public partial class FieldDefinitionProjectIsAProgram : FieldDefinition
    {
        private FieldDefinitionProjectIsAProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectIsAProgram Instance = new FieldDefinitionProjectIsAProgram(38, @"ProjectIsAProgram", @"This project is a program that implements multiple projects", 1);
    }

    public partial class FieldDefinitionThresholdCategoryName : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdCategoryName Instance = new FieldDefinitionThresholdCategoryName(39, @"ThresholdCategoryName", @"Threshold Category Name", 1);
    }

    public partial class FieldDefinitionEstimatedTotalCost : FieldDefinition
    {
        private FieldDefinitionEstimatedTotalCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionEstimatedTotalCost Instance = new FieldDefinitionEstimatedTotalCost(40, @"EstimatedTotalCost", @"Estimated Total Cost", 1);
    }

    public partial class FieldDefinitionUnfundedNeed : FieldDefinition
    {
        private FieldDefinitionUnfundedNeed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionUnfundedNeed Instance = new FieldDefinitionUnfundedNeed(41, @"UnfundedNeed", @"Unfunded Need", 1);
    }

    public partial class FieldDefinitionUsername : FieldDefinition
    {
        private FieldDefinitionUsername(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionUsername Instance = new FieldDefinitionUsername(42, @"Username", @"User name", 3);
    }

    public partial class FieldDefinitionWatershedName : FieldDefinition
    {
        private FieldDefinitionWatershedName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionWatershedName Instance = new FieldDefinitionWatershedName(43, @"WatershedName", @"Watershed Name", 1);
    }

    public partial class FieldDefinitionProject : FieldDefinition
    {
        private FieldDefinitionProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProject Instance = new FieldDefinitionProject(44, @"Project", @"Project", 1);
    }

    public partial class FieldDefinitionProjectNumber : FieldDefinition
    {
        private FieldDefinitionProjectNumber(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectNumber Instance = new FieldDefinitionProjectNumber(45, @"ProjectNumber", @"Project #", 1);
    }

    public partial class FieldDefinitionThresholdCategory : FieldDefinition
    {
        private FieldDefinitionThresholdCategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdCategory Instance = new FieldDefinitionThresholdCategory(46, @"ThresholdCategory", @"Threshold Category", 1);
    }

    public partial class FieldDefinitionLocalAndRegionalPlan : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlan(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLocalAndRegionalPlan Instance = new FieldDefinitionLocalAndRegionalPlan(47, @"LocalAndRegionalPlan", @"Local and Regional Plan", 1);
    }

    public partial class FieldDefinitionWatershed : FieldDefinition
    {
        private FieldDefinitionWatershed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionWatershed Instance = new FieldDefinitionWatershed(48, @"Watershed", @"Watershed", 1);
    }

    public partial class FieldDefinitionSubcategory : FieldDefinition
    {
        private FieldDefinitionSubcategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSubcategory Instance = new FieldDefinitionSubcategory(49, @"Subcategory", @"Subcategory", 1);
    }

    public partial class FieldDefinitionSubcategoryOption : FieldDefinition
    {
        private FieldDefinitionSubcategoryOption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSubcategoryOption Instance = new FieldDefinitionSubcategoryOption(50, @"SubcategoryOption", @"Subcategory Option", 1);
    }

    public partial class FieldDefinitionSubcategoryOptions : FieldDefinition
    {
        private FieldDefinitionSubcategoryOptions(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSubcategoryOptions Instance = new FieldDefinitionSubcategoryOptions(51, @"SubcategoryOptions", @"Subcategory Options", 1);
    }

    public partial class FieldDefinitionIsPrimaryProgram : FieldDefinition
    {
        private FieldDefinitionIsPrimaryProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIsPrimaryProgram Instance = new FieldDefinitionIsPrimaryProgram(52, @"IsPrimaryProgram", @"Is Primary Program", 1);
    }

    public partial class FieldDefinitionIndicatorCriticalDefinitions : FieldDefinition
    {
        private FieldDefinitionIndicatorCriticalDefinitions(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorCriticalDefinitions Instance = new FieldDefinitionIndicatorCriticalDefinitions(53, @"IndicatorCriticalDefinitions", @"Critical Definitions", 3);
    }

    public partial class FieldDefinitionIndicatorAccountingPeriodAndScale : FieldDefinition
    {
        private FieldDefinitionIndicatorAccountingPeriodAndScale(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorAccountingPeriodAndScale Instance = new FieldDefinitionIndicatorAccountingPeriodAndScale(54, @"IndicatorAccountingPeriodAndScale", @"Accounting Period and Scale", 3);
    }

    public partial class FieldDefinitionIndicatorProjectReporting : FieldDefinition
    {
        private FieldDefinitionIndicatorProjectReporting(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorProjectReporting Instance = new FieldDefinitionIndicatorProjectReporting(55, @"IndicatorProjectReporting", @"Project Reporting", 3);
    }

    public partial class FieldDefinitionFundedAmount : FieldDefinition
    {
        private FieldDefinitionFundedAmount(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFundedAmount Instance = new FieldDefinitionFundedAmount(56, @"FundedAmount", @"Funded Amount", 1);
    }

    public partial class FieldDefinitionProjectLocation : FieldDefinition
    {
        private FieldDefinitionProjectLocation(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectLocation Instance = new FieldDefinitionProjectLocation(57, @"ProjectLocation", @"Project Location", 1);
    }

    public partial class FieldDefinitionIndicatorBackground : FieldDefinition
    {
        private FieldDefinitionIndicatorBackground(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorBackground Instance = new FieldDefinitionIndicatorBackground(58, @"IndicatorBackground", @"Background", 3);
    }

    public partial class FieldDefinitionNumberOfReportedPMRecords : FieldDefinition
    {
        private FieldDefinitionNumberOfReportedPMRecords(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionNumberOfReportedPMRecords Instance = new FieldDefinitionNumberOfReportedPMRecords(59, @"NumberOfReportedPMRecords", @"# of Reported PM Records", 1);
    }

    public partial class FieldDefinitionNumberOfReportedExpenditureRecords : FieldDefinition
    {
        private FieldDefinitionNumberOfReportedExpenditureRecords(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionNumberOfReportedExpenditureRecords Instance = new FieldDefinitionNumberOfReportedExpenditureRecords(60, @"NumberOfReportedExpenditureRecords", @"# of Reported Expenditure Records", 1);
    }

    public partial class FieldDefinitionProjectLocationState : FieldDefinition
    {
        private FieldDefinitionProjectLocationState(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectLocationState Instance = new FieldDefinitionProjectLocationState(61, @"ProjectLocationState", @"State (Geospatial)", 1);
    }

    public partial class FieldDefinitionProjectLocationJurisdiction : FieldDefinition
    {
        private FieldDefinitionProjectLocationJurisdiction(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectLocationJurisdiction Instance = new FieldDefinitionProjectLocationJurisdiction(62, @"ProjectLocationJurisdiction", @"Jurisdiction (Geospatial)", 1);
    }

    public partial class FieldDefinitionProjectLocationWatershed : FieldDefinition
    {
        private FieldDefinitionProjectLocationWatershed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectLocationWatershed Instance = new FieldDefinitionProjectLocationWatershed(63, @"ProjectLocationWatershed", @"Watershed (Geospatial)", 1);
    }

    public partial class FieldDefinitionExcludeFromFactSheet : FieldDefinition
    {
        private FieldDefinitionExcludeFromFactSheet(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionExcludeFromFactSheet Instance = new FieldDefinitionExcludeFromFactSheet(64, @"ExcludeFromFactSheet", @"Exclude from Fact Sheet", 1);
    }

    public partial class FieldDefinitionTransportationStrategy : FieldDefinition
    {
        private FieldDefinitionTransportationStrategy(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTransportationStrategy Instance = new FieldDefinitionTransportationStrategy(65, @"TransportationStrategy", @"Transportation Strategy", 1);
    }

    public partial class FieldDefinitionTransportationObjective : FieldDefinition
    {
        private FieldDefinitionTransportationObjective(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTransportationObjective Instance = new FieldDefinitionTransportationObjective(66, @"TransportationObjective", @"Transportation Objective", 1);
    }

    public partial class FieldDefinitionTransportationStrategyName : FieldDefinition
    {
        private FieldDefinitionTransportationStrategyName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTransportationStrategyName Instance = new FieldDefinitionTransportationStrategyName(67, @"TransportationStrategyName", @"Transportation Strategy Name", 1);
    }

    public partial class FieldDefinitionTransportationObjectiveName : FieldDefinition
    {
        private FieldDefinitionTransportationObjectiveName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTransportationObjectiveName Instance = new FieldDefinitionTransportationObjectiveName(68, @"TransportationObjectiveName", @"Transportation Objective Name", 1);
    }

    public partial class FieldDefinitionProjectIsATransportationProject : FieldDefinition
    {
        private FieldDefinitionProjectIsATransportationProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectIsATransportationProject Instance = new FieldDefinitionProjectIsATransportationProject(69, @"ProjectIsATransportationProject", @"This Project is a Transportation Project", 1);
    }

    public partial class FieldDefinitionIsTransportationFundingSource : FieldDefinition
    {
        private FieldDefinitionIsTransportationFundingSource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIsTransportationFundingSource Instance = new FieldDefinitionIsTransportationFundingSource(72, @"IsTransportationFundingSource", @"Transportation Funding Source", 1);
    }

    public partial class FieldDefinitionFundingType : FieldDefinition
    {
        private FieldDefinitionFundingType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionFundingType Instance = new FieldDefinitionFundingType(73, @"FundingType", @"Funding Type", 1);
    }

    public partial class FieldDefinitionProjectCostInYearOfExpenditure : FieldDefinition
    {
        private FieldDefinitionProjectCostInYearOfExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure Instance = new FieldDefinitionProjectCostInYearOfExpenditure(74, @"ProjectCostInYearOfExpenditure", @"Cost in Year of Expenditure", 1);
    }

    public partial class FieldDefinitionTransportationGlobalInflationRate : FieldDefinition
    {
        private FieldDefinitionTransportationGlobalInflationRate(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTransportationGlobalInflationRate Instance = new FieldDefinitionTransportationGlobalInflationRate(75, @"TransportationGlobalInflationRate", @"Global Inflation Rate", 1);
    }

    public partial class FieldDefinitionReportingYear : FieldDefinition
    {
        private FieldDefinitionReportingYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionReportingYear Instance = new FieldDefinitionReportingYear(76, @"ReportingYear", @"Reporting Year", 1);
    }

    public partial class FieldDefinitionTagName : FieldDefinition
    {
        private FieldDefinitionTagName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTagName Instance = new FieldDefinitionTagName(77, @"TagName", @"Tag Name", 1);
    }

    public partial class FieldDefinitionTagDescription : FieldDefinition
    {
        private FieldDefinitionTagDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTagDescription Instance = new FieldDefinitionTagDescription(78, @"TagDescription", @"Tag Description", 1);
    }

    public partial class FieldDefinitionTags : FieldDefinition
    {
        private FieldDefinitionTags(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTags Instance = new FieldDefinitionTags(79, @"Tags", @"Tags", 1);
    }

    public partial class FieldDefinitionReportedExpenditure : FieldDefinition
    {
        private FieldDefinitionReportedExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionReportedExpenditure Instance = new FieldDefinitionReportedExpenditure(80, @"ReportedExpenditure", @"Reported Expenditure", 1);
    }

    public partial class FieldDefinitionProposedProject : FieldDefinition
    {
        private FieldDefinitionProposedProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProposedProject Instance = new FieldDefinitionProposedProject(81, @"ProposedProject", @"Proposed Project", 1);
    }

    public partial class FieldDefinitionProjectOnFTIPList : FieldDefinition
    {
        private FieldDefinitionProjectOnFTIPList(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProjectOnFTIPList Instance = new FieldDefinitionProjectOnFTIPList(82, @"ProjectOnFTIPList", @"This project is on the Federal Transportation Improvement Program (FTIP) list", 1);
    }

    public partial class FieldDefinitionLocalAndRegionalPlanDocumentUrl : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlanDocumentUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentUrl Instance = new FieldDefinitionLocalAndRegionalPlanDocumentUrl(83, @"LocalAndRegionalPlanDocumentUrl", @"Local and Regional Plan Document URL", 1);
    }

    public partial class FieldDefinitionLocalAndRegionalPlanDocumentLinkText : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlanDocumentLinkText(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentLinkText Instance = new FieldDefinitionLocalAndRegionalPlanDocumentLinkText(84, @"LocalAndRegionalPlanDocumentLinkText", @"Local and Regional Plan Document Link Text", 1);
    }

    public partial class FieldDefinitionSpendingAssociatedWithPM : FieldDefinition
    {
        private FieldDefinitionSpendingAssociatedWithPM(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSpendingAssociatedWithPM Instance = new FieldDefinitionSpendingAssociatedWithPM(85, @"SpendingAssociatedWithPM", @"Spending Associated with PM", 1);
    }

    public partial class FieldDefinitionPlanningDesignStartYear : FieldDefinition
    {
        private FieldDefinitionPlanningDesignStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionPlanningDesignStartYear Instance = new FieldDefinitionPlanningDesignStartYear(86, @"PlanningDesignStartYear", @"Planning / Design Start Year", 1);
    }

    public partial class FieldDefinitionAssociatedPrograms : FieldDefinition
    {
        private FieldDefinitionAssociatedPrograms(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionAssociatedPrograms Instance = new FieldDefinitionAssociatedPrograms(87, @"AssociatedPrograms", @"Associated Programs", 3);
    }

    public partial class FieldDefinitionExternalLinks : FieldDefinition
    {
        private FieldDefinitionExternalLinks(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionExternalLinks Instance = new FieldDefinitionExternalLinks(88, @"ExternalLinks", @"External Links", 1);
    }

    public partial class FieldDefinitionEstimatedAnnualOperatingCost : FieldDefinition
    {
        private FieldDefinitionEstimatedAnnualOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost Instance = new FieldDefinitionEstimatedAnnualOperatingCost(89, @"EstimatedAnnualOperatingCost", @"Est. Annual Operating Cost", 1);
    }

    public partial class FieldDefinitionCalculatedTotalRemainingOperatingCost : FieldDefinition
    {
        private FieldDefinitionCalculatedTotalRemainingOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost Instance = new FieldDefinitionCalculatedTotalRemainingOperatingCost(90, @"CalculatedTotalRemainingOperatingCost", @"Remaining Operating Cost", 1);
    }

    public partial class FieldDefinitionCurrentRTPYearForPVCalculations : FieldDefinition
    {
        private FieldDefinitionCurrentRTPYearForPVCalculations(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionCurrentRTPYearForPVCalculations Instance = new FieldDefinitionCurrentRTPYearForPVCalculations(91, @"CurrentRTPYearForPVCalculations", @"Current RTP Year for PV Calculations", 1);
    }

    public partial class FieldDefinitionLifecycleOperatingCost : FieldDefinition
    {
        private FieldDefinitionLifecycleOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLifecycleOperatingCost Instance = new FieldDefinitionLifecycleOperatingCost(92, @"LifecycleOperatingCost", @"Lifecycle Operating Cost", 1);
    }

    public partial class FieldDefinitionIndicatorSystemName : FieldDefinition
    {
        private FieldDefinitionIndicatorSystemName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorSystemName Instance = new FieldDefinitionIndicatorSystemName(93, @"IndicatorSystemName", @"Indicator System Name", 3);
    }

    public partial class FieldDefinitionIndicatorSimpleDescription : FieldDefinition
    {
        private FieldDefinitionIndicatorSimpleDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorSimpleDescription Instance = new FieldDefinitionIndicatorSimpleDescription(94, @"IndicatorSimpleDescription", @"Indicator Simple Description", 3);
    }

    public partial class FieldDefinitionIndicatorPrimarySource : FieldDefinition
    {
        private FieldDefinitionIndicatorPrimarySource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorPrimarySource Instance = new FieldDefinitionIndicatorPrimarySource(95, @"IndicatorPrimarySource", @"Indicator Primary Source", 3);
    }

    public partial class FieldDefinitionIndicatorType : FieldDefinition
    {
        private FieldDefinitionIndicatorType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionIndicatorType Instance = new FieldDefinitionIndicatorType(96, @"IndicatorType", @"Indicator Type", 3);
    }

    public partial class FieldDefinitionChartTitle : FieldDefinition
    {
        private FieldDefinitionChartTitle(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionChartTitle Instance = new FieldDefinitionChartTitle(97, @"ChartTitle", @"Chart Title", 3);
    }

    public partial class FieldDefinitionProposedProjectState : FieldDefinition
    {
        private FieldDefinitionProposedProjectState(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionProposedProjectState Instance = new FieldDefinitionProposedProjectState(98, @"ProposedProjectState", @"Proposed Project State", 1);
    }

    public partial class FieldDefinitionUserLastName : FieldDefinition
    {
        private FieldDefinitionUserLastName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionUserLastName Instance = new FieldDefinitionUserLastName(173, @"UserLastName", @"User Last Name", 3);
    }

    public partial class FieldDefinitionUserFirstName : FieldDefinition
    {
        private FieldDefinitionUserFirstName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionUserFirstName Instance = new FieldDefinitionUserFirstName(174, @"UserFirstName", @"User First Name", 3);
    }

    public partial class FieldDefinitionUserEmail : FieldDefinition
    {
        private FieldDefinitionUserEmail(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionUserEmail Instance = new FieldDefinitionUserEmail(175, @"UserEmail", @"User Email", 3);
    }

    public partial class FieldDefinitionUserPhone : FieldDefinition
    {
        private FieldDefinitionUserPhone(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionUserPhone Instance = new FieldDefinitionUserPhone(176, @"UserPhone", @"Phone Number", 3);
    }

    public partial class FieldDefinitionEIPRoleID : FieldDefinition
    {
        private FieldDefinitionEIPRoleID(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionEIPRoleID Instance = new FieldDefinitionEIPRoleID(177, @"EIPRoleID", @"EIP Role", 3);
    }

    public partial class FieldDefinitionParcelTrackerRoleID : FieldDefinition
    {
        private FieldDefinitionParcelTrackerRoleID(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionParcelTrackerRoleID Instance = new FieldDefinitionParcelTrackerRoleID(178, @"ParcelTrackerRoleID", @"Parcel Tracker Role", 3);
    }

    public partial class FieldDefinitionSustainabilityRoleID : FieldDefinition
    {
        private FieldDefinitionSustainabilityRoleID(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSustainabilityRoleID Instance = new FieldDefinitionSustainabilityRoleID(179, @"SustainabilityRoleID", @"Sustainability Role", 3);
    }

    public partial class FieldDefinitionLTInfoRoleID : FieldDefinition
    {
        private FieldDefinitionLTInfoRoleID(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLTInfoRoleID Instance = new FieldDefinitionLTInfoRoleID(180, @"LTInfoRoleID", @"Lake Tahoe Info Role", 3);
    }

    public partial class FieldDefinitionSiteArea : FieldDefinition
    {
        private FieldDefinitionSiteArea(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionSiteArea Instance = new FieldDefinitionSiteArea(181, @"SiteArea", @"Site Area", 3);
    }

    public partial class FieldDefinitionRoleName : FieldDefinition
    {
        private FieldDefinitionRoleName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionRoleName Instance = new FieldDefinitionRoleName(182, @"RoleName", @"Role Name", 3);
    }

    public partial class FieldDefinitionRegion : FieldDefinition
    {
        private FieldDefinitionRegion(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionRegion Instance = new FieldDefinitionRegion(184, @"Region", @"Region (Geospatial)", 1);
    }

    public partial class FieldDefinitionLatitude : FieldDefinition
    {
        private FieldDefinitionLatitude(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLatitude Instance = new FieldDefinitionLatitude(185, @"Latitude", @"Latitude", 1);
    }

    public partial class FieldDefinitionLongitude : FieldDefinition
    {
        private FieldDefinitionLongitude(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionLongitude Instance = new FieldDefinitionLongitude(186, @"Longitude", @"Longitude", 1);
    }

    public partial class FieldDefinitionOrganizationUrl : FieldDefinition
    {
        private FieldDefinitionOrganizationUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionOrganizationUrl Instance = new FieldDefinitionOrganizationUrl(188, @"OrganizationUrl", @"Organization Home Page", 1);
    }

    public partial class FieldDefinitionThresholdReportingCategory : FieldDefinition
    {
        private FieldDefinitionThresholdReportingCategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdReportingCategory Instance = new FieldDefinitionThresholdReportingCategory(204, @"ThresholdReportingCategory", @"Threshold Reporting Category", 5);
    }

    public partial class FieldDefinitionApplicableStandard : FieldDefinition
    {
        private FieldDefinitionApplicableStandard(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionApplicableStandard Instance = new FieldDefinitionApplicableStandard(205, @"ApplicableStandard", @"Applicable Standard", 5);
    }

    public partial class FieldDefinitionStandardNarrative : FieldDefinition
    {
        private FieldDefinitionStandardNarrative(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionStandardNarrative Instance = new FieldDefinitionStandardNarrative(206, @"StandardNarrative", @"Standard Narrative", 5);
    }

    public partial class FieldDefinitionTRPAIndicator : FieldDefinition
    {
        private FieldDefinitionTRPAIndicator(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionTRPAIndicator Instance = new FieldDefinitionTRPAIndicator(207, @"TRPAIndicator", @"TRPA Indicator", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationStatus : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationStatus(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationStatus Instance = new FieldDefinitionThresholdEvaluationStatus(208, @"ThresholdEvaluationStatus", @"Threshold Evaluation Status", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationTrend : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationTrend(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationTrend Instance = new FieldDefinitionThresholdEvaluationTrend(209, @"ThresholdEvaluationTrend", @"Threshold Evaluation Trend", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationConfidence : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationConfidence(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationConfidence Instance = new FieldDefinitionThresholdEvaluationConfidence(210, @"ThresholdEvaluationConfidence", @"Threshold Evaluation Confidence", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationStatusRationale : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationStatusRationale(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationStatusRationale Instance = new FieldDefinitionThresholdEvaluationStatusRationale(211, @"ThresholdEvaluationStatusRationale", @"Threshold Evaluation Status Rationale", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationTrendRationale : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationTrendRationale(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationTrendRationale Instance = new FieldDefinitionThresholdEvaluationTrendRationale(212, @"ThresholdEvaluationTrendRationale", @"Threshold Evaluation Trend Rationale", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationConfidenceStatus : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationConfidenceStatus(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationConfidenceStatus Instance = new FieldDefinitionThresholdEvaluationConfidenceStatus(213, @"ThresholdEvaluationConfidenceStatus", @"Threshold Evaluation Confidence Status", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationManagementStatus : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationManagementStatus(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationManagementStatus Instance = new FieldDefinitionThresholdEvaluationManagementStatus(214, @"ThresholdEvaluationManagementStatus", @"Threshold Evaluation Management Status", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationProgramsAndActionsImplementedToImproveConditions : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationProgramsAndActionsImplementedToImproveConditions(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationProgramsAndActionsImplementedToImproveConditions Instance = new FieldDefinitionThresholdEvaluationProgramsAndActionsImplementedToImproveConditions(215, @"ThresholdEvaluationProgramsAndActionsImplementedToImproveConditions", @"Threshold Evaluation Programs and Actions Implemented to Improve Conditions", 5);
    }

    public partial class FieldDefinitionThresholdRoleID : FieldDefinition
    {
        private FieldDefinitionThresholdRoleID(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdRoleID Instance = new FieldDefinitionThresholdRoleID(216, @"ThresholdRoleID", @"Threshold Dashboard Role", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationConfidenceTrend : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationConfidenceTrend(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationConfidenceTrend Instance = new FieldDefinitionThresholdEvaluationConfidenceTrend(217, @"ThresholdEvaluationConfidenceTrend", @"Threshold Evaluation Confidence Trend", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationConfidenceOverall : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationConfidenceOverall(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationConfidenceOverall Instance = new FieldDefinitionThresholdEvaluationConfidenceOverall(218, @"ThresholdEvaluationConfidenceOverall", @"Threshold Evaluation Confidence Overall", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationEffectivenessOfProgramsAndActions : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationEffectivenessOfProgramsAndActions(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationEffectivenessOfProgramsAndActions Instance = new FieldDefinitionThresholdEvaluationEffectivenessOfProgramsAndActions(219, @"ThresholdEvaluationEffectivenessOfProgramsAndActions", @"Threshold Evaluation Effectiveness of Programs and Actions", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationInterimTarget : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationInterimTarget(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationInterimTarget Instance = new FieldDefinitionThresholdEvaluationInterimTarget(220, @"ThresholdEvaluationInterimTarget", @"Threshold Evaluation Interim Target", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationTargetAttainmentDate : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationTargetAttainmentDate(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationTargetAttainmentDate Instance = new FieldDefinitionThresholdEvaluationTargetAttainmentDate(221, @"ThresholdEvaluationTargetAttainmentDate", @"Threshold Evaluation Target Attainment Date", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationAnalyticApproach : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationAnalyticApproach(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationAnalyticApproach Instance = new FieldDefinitionThresholdEvaluationAnalyticApproach(222, @"ThresholdEvaluationAnalyticApproach", @"Threshold Evaluation Analytic Approach", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationMonitoringApproach : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationMonitoringApproach(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationMonitoringApproach Instance = new FieldDefinitionThresholdEvaluationMonitoringApproach(223, @"ThresholdEvaluationMonitoringApproach", @"Threshold Evaluation Monitoring Approach", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationModificationOfTheThresholdStandardOrIndicator : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationModificationOfTheThresholdStandardOrIndicator(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationModificationOfTheThresholdStandardOrIndicator Instance = new FieldDefinitionThresholdEvaluationModificationOfTheThresholdStandardOrIndicator(224, @"ThresholdEvaluationModificationOfTheThresholdStandardOrIndicator", @"Threshold Evaluation Modification of the Threshold Standard or Indicator", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationAttainOrMaintainThreshold : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationAttainOrMaintainThreshold(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationAttainOrMaintainThreshold Instance = new FieldDefinitionThresholdEvaluationAttainOrMaintainThreshold(225, @"ThresholdEvaluationAttainOrMaintainThreshold", @"Threshold Evaluation Attain or Maintain Threshold", 5);
    }

    public partial class FieldDefinitionThresholdEvaluationMonitoringAndAnalysis : FieldDefinition
    {
        private FieldDefinitionThresholdEvaluationMonitoringAndAnalysis(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdEvaluationMonitoringAndAnalysis Instance = new FieldDefinitionThresholdEvaluationMonitoringAndAnalysis(226, @"ThresholdEvaluationMonitoringAndAnalysis", @"Threshold Evaluation Monitoring and Analysis", 5);
    }

    public partial class FieldDefinitionThresholdReportingCategoryNarrative : FieldDefinition
    {
        private FieldDefinitionThresholdReportingCategoryNarrative(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdReportingCategoryNarrative Instance = new FieldDefinitionThresholdReportingCategoryNarrative(227, @"ThresholdReportingCategoryNarrative", @"Threshold Reporting Category Narrative", 5);
    }

    public partial class FieldDefinitionChartCaption : FieldDefinition
    {
        private FieldDefinitionChartCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionChartCaption Instance = new FieldDefinitionChartCaption(228, @"ChartCaption", @"Chart Caption", 3);
    }

    public partial class FieldDefinitionRelevance : FieldDefinition
    {
        private FieldDefinitionRelevance(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionRelevance Instance = new FieldDefinitionRelevance(233, @"Relevance", @"Relevance", 5);
    }

    public partial class FieldDefinitionHumanAndEnvironmentalDrivers : FieldDefinition
    {
        private FieldDefinitionHumanAndEnvironmentalDrivers(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionHumanAndEnvironmentalDrivers Instance = new FieldDefinitionHumanAndEnvironmentalDrivers(234, @"HumanAndEnvironmentalDrivers", @"Human and Environmental Drivers", 5);
    }

    public partial class FieldDefinitionThresholdStandardType : FieldDefinition
    {
        private FieldDefinitionThresholdStandardType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdStandardType Instance = new FieldDefinitionThresholdStandardType(235, @"ThresholdStandardType", @"Threshold Standard Type", 5);
    }

    public partial class FieldDefinitionMonitoringProgram : FieldDefinition
    {
        private FieldDefinitionMonitoringProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionMonitoringProgram Instance = new FieldDefinitionMonitoringProgram(236, @"MonitoringProgram", @"Monitoring Program", 5);
    }

    public partial class FieldDefinitionMonitoringApproach : FieldDefinition
    {
        private FieldDefinitionMonitoringApproach(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionMonitoringApproach Instance = new FieldDefinitionMonitoringApproach(237, @"MonitoringApproach", @"Monitoring Approach", 5);
    }

    public partial class FieldDefinitionMonitoringProgramPartner : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramPartner(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionMonitoringProgramPartner Instance = new FieldDefinitionMonitoringProgramPartner(238, @"MonitoringProgramPartner", @"Monitoring Program Partner", 5);
    }

    public partial class FieldDefinitionMonitoringProgramUrl : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionMonitoringProgramUrl Instance = new FieldDefinitionMonitoringProgramUrl(239, @"MonitoringProgramUrl", @"Monitoring Program Home Page", 5);
    }

    public partial class FieldDefinitionThresholdCategoryDescription : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdCategoryDescription Instance = new FieldDefinitionThresholdCategoryDescription(240, @"ThresholdCategoryDescription", @"Threshold Category Description", 5);
    }

    public partial class FieldDefinitionThresholdCategoryGoalStatement : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryGoalStatement(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdCategoryGoalStatement Instance = new FieldDefinitionThresholdCategoryGoalStatement(241, @"ThresholdCategoryGoalStatement", @"Threshold Category Goal Statement", 5);
    }

    public partial class FieldDefinitionThresholdCategoryNarrative : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryNarrative(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName, int primaryLTInfoAreaID) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName, primaryLTInfoAreaID) {}
        public static readonly FieldDefinitionThresholdCategoryNarrative Instance = new FieldDefinitionThresholdCategoryNarrative(242, @"ThresholdCategoryNarrative", @"Threshold Category Narrative", 5);
    }
}