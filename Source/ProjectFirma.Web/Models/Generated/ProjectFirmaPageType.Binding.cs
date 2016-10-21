//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFirmaPageType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public abstract partial class ProjectFirmaPageType : IHavePrimaryKey
    {
        public static readonly ProjectFirmaPageTypeEIPTrackerNarrative EIPTrackerNarrative = ProjectFirmaPageTypeEIPTrackerNarrative.Instance;
        public static readonly ProjectFirmaPageTypeEIPOverview EIPOverview = ProjectFirmaPageTypeEIPOverview.Instance;
        public static readonly ProjectFirmaPageTypeHistoryOfTheEIP HistoryOfTheEIP = ProjectFirmaPageTypeHistoryOfTheEIP.Instance;
        public static readonly ProjectFirmaPageTypeEIPPartners EIPPartners = ProjectFirmaPageTypeEIPPartners.Instance;
        public static readonly ProjectFirmaPageTypeEIPFaq EIPFaq = ProjectFirmaPageTypeEIPFaq.Instance;
        public static readonly ProjectFirmaPageTypeFullProjectList FullProjectList = ProjectFirmaPageTypeFullProjectList.Instance;
        public static readonly ProjectFirmaPageTypeFiveYearProjectList FiveYearProjectList = ProjectFirmaPageTypeFiveYearProjectList.Instance;
        public static readonly ProjectFirmaPageTypeCompletedProjectList CompletedProjectList = ProjectFirmaPageTypeCompletedProjectList.Instance;
        public static readonly ProjectFirmaPageTypeEIPPerformanceMeasuresList EIPPerformanceMeasuresList = ProjectFirmaPageTypeEIPPerformanceMeasuresList.Instance;
        public static readonly ProjectFirmaPageTypeThresholdsHome ThresholdsHome = ProjectFirmaPageTypeThresholdsHome.Instance;
        public static readonly ProjectFirmaPageTypeActionPrioritiesList ActionPrioritiesList = ProjectFirmaPageTypeActionPrioritiesList.Instance;
        public static readonly ProjectFirmaPageTypeLocalAndRegionalPlansList LocalAndRegionalPlansList = ProjectFirmaPageTypeLocalAndRegionalPlansList.Instance;
        public static readonly ProjectFirmaPageTypeFocusAreasList FocusAreasList = ProjectFirmaPageTypeFocusAreasList.Instance;
        public static readonly ProjectFirmaPageTypeFundingSourcesList FundingSourcesList = ProjectFirmaPageTypeFundingSourcesList.Instance;
        public static readonly ProjectFirmaPageTypeOrganizationsList OrganizationsList = ProjectFirmaPageTypeOrganizationsList.Instance;
        public static readonly ProjectFirmaPageTypeProgramsList ProgramsList = ProjectFirmaPageTypeProgramsList.Instance;
        public static readonly ProjectFirmaPageTypeWatershedsList WatershedsList = ProjectFirmaPageTypeWatershedsList.Instance;
        public static readonly ProjectFirmaPageTypeMyProjects MyProjects = ProjectFirmaPageTypeMyProjects.Instance;
        public static readonly ProjectFirmaPageTypePagesWithIntroTextList PagesWithIntroTextList = ProjectFirmaPageTypePagesWithIntroTextList.Instance;
        public static readonly ProjectFirmaPageTypeInvestmentByFundingSector InvestmentByFundingSector = ProjectFirmaPageTypeInvestmentByFundingSector.Instance;
        public static readonly ProjectFirmaPageTypeSpendingBySectorByFocusAreaByProgram SpendingBySectorByFocusAreaByProgram = ProjectFirmaPageTypeSpendingBySectorByFocusAreaByProgram.Instance;
        public static readonly ProjectFirmaPageTypeEIPProjectMap EIPProjectMap = ProjectFirmaPageTypeEIPProjectMap.Instance;
        public static readonly ProjectFirmaPageTypeEIPResultsByProgram EIPResultsByProgram = ProjectFirmaPageTypeEIPResultsByProgram.Instance;
        public static readonly ProjectFirmaPageTypeThisTool ThisTool = ProjectFirmaPageTypeThisTool.Instance;
        public static readonly ProjectFirmaPageTypeEIPHomeAdditionalInfo EIPHomeAdditionalInfo = ProjectFirmaPageTypeEIPHomeAdditionalInfo.Instance;
        public static readonly ProjectFirmaPageTypeFeaturedProjectList FeaturedProjectList = ProjectFirmaPageTypeFeaturedProjectList.Instance;
        public static readonly ProjectFirmaPageTypeDemoScript DemoScript = ProjectFirmaPageTypeDemoScript.Instance;
        public static readonly ProjectFirmaPageTypeTransportationStrategiesList TransportationStrategiesList = ProjectFirmaPageTypeTransportationStrategiesList.Instance;
        public static readonly ProjectFirmaPageTypeTransportationObjectivesList TransportationObjectivesList = ProjectFirmaPageTypeTransportationObjectivesList.Instance;
        public static readonly ProjectFirmaPageTypeTransportationProjectList TransportationProjectList = ProjectFirmaPageTypeTransportationProjectList.Instance;
        public static readonly ProjectFirmaPageTypeTransportationCostParameterSet TransportationCostParameterSet = ProjectFirmaPageTypeTransportationCostParameterSet.Instance;
        public static readonly ProjectFirmaPageTypeTerminatedProjectList TerminatedProjectList = ProjectFirmaPageTypeTerminatedProjectList.Instance;
        public static readonly ProjectFirmaPageTypeFullProjectListSimple FullProjectListSimple = ProjectFirmaPageTypeFullProjectListSimple.Instance;
        public static readonly ProjectFirmaPageTypeEIPTaxonomy EIPTaxonomy = ProjectFirmaPageTypeEIPTaxonomy.Instance;
        public static readonly ProjectFirmaPageTypeTransportationTaxonomy TransportationTaxonomy = ProjectFirmaPageTypeTransportationTaxonomy.Instance;
        public static readonly ProjectFirmaPageTypeTagList TagList = ProjectFirmaPageTypeTagList.Instance;
        public static readonly ProjectFirmaPageTypeSpendingByEIPPerformanceMeasureByProject SpendingByEIPPerformanceMeasureByProject = ProjectFirmaPageTypeSpendingByEIPPerformanceMeasureByProject.Instance;
        public static readonly ProjectFirmaPageTypeProposedProjects ProposedProjects = ProjectFirmaPageTypeProposedProjects.Instance;
        public static readonly ProjectFirmaPageTypeMyOrganizationsProjects MyOrganizationsProjects = ProjectFirmaPageTypeMyOrganizationsProjects.Instance;
        public static readonly ProjectFirmaPageTypeAnnualApprovalProcess AnnualApprovalProcess = ProjectFirmaPageTypeAnnualApprovalProcess.Instance;
        public static readonly ProjectFirmaPageTypeManageUpdateNotifications ManageUpdateNotifications = ProjectFirmaPageTypeManageUpdateNotifications.Instance;
        public static readonly ProjectFirmaPageTypeProjectUpdateStatus ProjectUpdateStatus = ProjectFirmaPageTypeProjectUpdateStatus.Instance;
        public static readonly ProjectFirmaPageTypeSIDAboutIntro SIDAboutIntro = ProjectFirmaPageTypeSIDAboutIntro.Instance;
        public static readonly ProjectFirmaPageTypeSIDAboutContent SIDAboutContent = ProjectFirmaPageTypeSIDAboutContent.Instance;
        public static readonly ProjectFirmaPageTypeSIDAboutFAQ SIDAboutFAQ = ProjectFirmaPageTypeSIDAboutFAQ.Instance;
        public static readonly ProjectFirmaPageTypeSIDHome SIDHome = ProjectFirmaPageTypeSIDHome.Instance;
        public static readonly ProjectFirmaPageTypeLTInfoDataCenter LTInfoDataCenter = ProjectFirmaPageTypeLTInfoDataCenter.Instance;
        public static readonly ProjectFirmaPageTypeLTInfoAbout LTInfoAbout = ProjectFirmaPageTypeLTInfoAbout.Instance;
        public static readonly ProjectFirmaPageTypeParcelTrackerNarrative ParcelTrackerNarrative = ProjectFirmaPageTypeParcelTrackerNarrative.Instance;
        public static readonly ProjectFirmaPageTypeCommodityTransactionsList CommodityTransactionsList = ProjectFirmaPageTypeCommodityTransactionsList.Instance;
        public static readonly ProjectFirmaPageTypePoolsList PoolsList = ProjectFirmaPageTypePoolsList.Instance;
        public static readonly ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByTransactionType LeadAgencyResponsibilityMatrixByTransactionType = ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByTransactionType.Instance;
        public static readonly ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByCommodity LeadAgencyResponsibilityMatrixByCommodity = ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByCommodity.Instance;
        public static readonly ProjectFirmaPageTypeParcelTownDistanceReport ParcelTownDistanceReport = ProjectFirmaPageTypeParcelTownDistanceReport.Instance;
        public static readonly ProjectFirmaPageTypeParcelsList ParcelsList = ProjectFirmaPageTypeParcelsList.Instance;
        public static readonly ProjectFirmaPageTypeParcelsByLandCapability ParcelsByLandCapability = ProjectFirmaPageTypeParcelsByLandCapability.Instance;
        public static readonly ProjectFirmaPageTypeLeadAgenciesList LeadAgenciesList = ProjectFirmaPageTypeLeadAgenciesList.Instance;
        public static readonly ProjectFirmaPageTypeAccelaCAPRecordsList AccelaCAPRecordsList = ProjectFirmaPageTypeAccelaCAPRecordsList.Instance;
        public static readonly ProjectFirmaPageTypeResidentialAllocationsList ResidentialAllocationsList = ProjectFirmaPageTypeResidentialAllocationsList.Instance;
        public static readonly ProjectFirmaPageTypeBankedCommoditiesList BankedCommoditiesList = ProjectFirmaPageTypeBankedCommoditiesList.Instance;
        public static readonly ProjectFirmaPageTypeParcelTrackerAbout ParcelTrackerAbout = ProjectFirmaPageTypeParcelTrackerAbout.Instance;
        public static readonly ProjectFirmaPageTypeParcelManagementGuidance ParcelManagementGuidance = ProjectFirmaPageTypeParcelManagementGuidance.Instance;
        public static readonly ProjectFirmaPageTypeParcelsByCommodity ParcelsByCommodity = ProjectFirmaPageTypeParcelsByCommodity.Instance;
        public static readonly ProjectFirmaPageTypeAllParcelsList AllParcelsList = ProjectFirmaPageTypeAllParcelsList.Instance;
        public static readonly ProjectFirmaPageTypeThresholdsTaxonomy ThresholdsTaxonomy = ProjectFirmaPageTypeThresholdsTaxonomy.Instance;
        public static readonly ProjectFirmaPageTypeMonitoringProgramsList MonitoringProgramsList = ProjectFirmaPageTypeMonitoringProgramsList.Instance;

        public static readonly List<ProjectFirmaPageType> All;
        public static readonly ReadOnlyDictionary<int, ProjectFirmaPageType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectFirmaPageType()
        {
            All = new List<ProjectFirmaPageType> { EIPTrackerNarrative, EIPOverview, HistoryOfTheEIP, EIPPartners, EIPFaq, FullProjectList, FiveYearProjectList, CompletedProjectList, EIPPerformanceMeasuresList, ThresholdsHome, ActionPrioritiesList, LocalAndRegionalPlansList, FocusAreasList, FundingSourcesList, OrganizationsList, ProgramsList, WatershedsList, MyProjects, PagesWithIntroTextList, InvestmentByFundingSector, SpendingBySectorByFocusAreaByProgram, EIPProjectMap, EIPResultsByProgram, ThisTool, EIPHomeAdditionalInfo, FeaturedProjectList, DemoScript, TransportationStrategiesList, TransportationObjectivesList, TransportationProjectList, TransportationCostParameterSet, TerminatedProjectList, FullProjectListSimple, EIPTaxonomy, TransportationTaxonomy, TagList, SpendingByEIPPerformanceMeasureByProject, ProposedProjects, MyOrganizationsProjects, AnnualApprovalProcess, ManageUpdateNotifications, ProjectUpdateStatus, SIDAboutIntro, SIDAboutContent, SIDAboutFAQ, SIDHome, LTInfoDataCenter, LTInfoAbout, ParcelTrackerNarrative, CommodityTransactionsList, PoolsList, LeadAgencyResponsibilityMatrixByTransactionType, LeadAgencyResponsibilityMatrixByCommodity, ParcelTownDistanceReport, ParcelsList, ParcelsByLandCapability, LeadAgenciesList, AccelaCAPRecordsList, ResidentialAllocationsList, BankedCommoditiesList, ParcelTrackerAbout, ParcelManagementGuidance, ParcelsByCommodity, AllParcelsList, ThresholdsTaxonomy, MonitoringProgramsList };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectFirmaPageType>(All.ToDictionary(x => x.ProjectFirmaPageTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectFirmaPageType(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID)
        {
            ProjectFirmaPageTypeID = projectFirmaPageTypeID;
            ProjectFirmaPageTypeName = projectFirmaPageTypeName;
            ProjectFirmaPageTypeDisplayName = projectFirmaPageTypeDisplayName;
            PrimaryLTInfoAreaID = primaryLTInfoAreaID;
            ProjectFirmaPageRenderTypeID = projectFirmaPageRenderTypeID;
        }
        public LTInfoArea PrimaryLTInfoArea { get { return LTInfoArea.AllLookupDictionary[PrimaryLTInfoAreaID]; } }
        public ProjectFirmaPageRenderType ProjectFirmaPageRenderType { get { return ProjectFirmaPageRenderType.AllLookupDictionary[ProjectFirmaPageRenderTypeID]; } }
        [Key]
        public int ProjectFirmaPageTypeID { get; private set; }
        public string ProjectFirmaPageTypeName { get; private set; }
        public string ProjectFirmaPageTypeDisplayName { get; private set; }
        public int PrimaryLTInfoAreaID { get; private set; }
        public int ProjectFirmaPageRenderTypeID { get; private set; }
        public int PrimaryKey { get { return ProjectFirmaPageTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectFirmaPageType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectFirmaPageTypeID == ProjectFirmaPageTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectFirmaPageType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectFirmaPageTypeID;
        }

        public static bool operator ==(ProjectFirmaPageType left, ProjectFirmaPageType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectFirmaPageType left, ProjectFirmaPageType right)
        {
            return !Equals(left, right);
        }

        public ProjectFirmaPageTypeEnum ToEnum { get { return (ProjectFirmaPageTypeEnum)GetHashCode(); } }

        public static ProjectFirmaPageType ToType(int enumValue)
        {
            return ToType((ProjectFirmaPageTypeEnum)enumValue);
        }

        public static ProjectFirmaPageType ToType(ProjectFirmaPageTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectFirmaPageTypeEnum.AccelaCAPRecordsList:
                    return AccelaCAPRecordsList;
                case ProjectFirmaPageTypeEnum.ActionPrioritiesList:
                    return ActionPrioritiesList;
                case ProjectFirmaPageTypeEnum.AllParcelsList:
                    return AllParcelsList;
                case ProjectFirmaPageTypeEnum.AnnualApprovalProcess:
                    return AnnualApprovalProcess;
                case ProjectFirmaPageTypeEnum.BankedCommoditiesList:
                    return BankedCommoditiesList;
                case ProjectFirmaPageTypeEnum.CommodityTransactionsList:
                    return CommodityTransactionsList;
                case ProjectFirmaPageTypeEnum.CompletedProjectList:
                    return CompletedProjectList;
                case ProjectFirmaPageTypeEnum.DemoScript:
                    return DemoScript;
                case ProjectFirmaPageTypeEnum.EIPFaq:
                    return EIPFaq;
                case ProjectFirmaPageTypeEnum.EIPHomeAdditionalInfo:
                    return EIPHomeAdditionalInfo;
                case ProjectFirmaPageTypeEnum.EIPOverview:
                    return EIPOverview;
                case ProjectFirmaPageTypeEnum.EIPPartners:
                    return EIPPartners;
                case ProjectFirmaPageTypeEnum.EIPPerformanceMeasuresList:
                    return EIPPerformanceMeasuresList;
                case ProjectFirmaPageTypeEnum.EIPProjectMap:
                    return EIPProjectMap;
                case ProjectFirmaPageTypeEnum.EIPResultsByProgram:
                    return EIPResultsByProgram;
                case ProjectFirmaPageTypeEnum.EIPTaxonomy:
                    return EIPTaxonomy;
                case ProjectFirmaPageTypeEnum.EIPTrackerNarrative:
                    return EIPTrackerNarrative;
                case ProjectFirmaPageTypeEnum.FeaturedProjectList:
                    return FeaturedProjectList;
                case ProjectFirmaPageTypeEnum.FiveYearProjectList:
                    return FiveYearProjectList;
                case ProjectFirmaPageTypeEnum.FocusAreasList:
                    return FocusAreasList;
                case ProjectFirmaPageTypeEnum.FullProjectList:
                    return FullProjectList;
                case ProjectFirmaPageTypeEnum.FullProjectListSimple:
                    return FullProjectListSimple;
                case ProjectFirmaPageTypeEnum.FundingSourcesList:
                    return FundingSourcesList;
                case ProjectFirmaPageTypeEnum.HistoryOfTheEIP:
                    return HistoryOfTheEIP;
                case ProjectFirmaPageTypeEnum.InvestmentByFundingSector:
                    return InvestmentByFundingSector;
                case ProjectFirmaPageTypeEnum.LeadAgenciesList:
                    return LeadAgenciesList;
                case ProjectFirmaPageTypeEnum.LeadAgencyResponsibilityMatrixByCommodity:
                    return LeadAgencyResponsibilityMatrixByCommodity;
                case ProjectFirmaPageTypeEnum.LeadAgencyResponsibilityMatrixByTransactionType:
                    return LeadAgencyResponsibilityMatrixByTransactionType;
                case ProjectFirmaPageTypeEnum.LocalAndRegionalPlansList:
                    return LocalAndRegionalPlansList;
                case ProjectFirmaPageTypeEnum.LTInfoAbout:
                    return LTInfoAbout;
                case ProjectFirmaPageTypeEnum.LTInfoDataCenter:
                    return LTInfoDataCenter;
                case ProjectFirmaPageTypeEnum.ManageUpdateNotifications:
                    return ManageUpdateNotifications;
                case ProjectFirmaPageTypeEnum.MonitoringProgramsList:
                    return MonitoringProgramsList;
                case ProjectFirmaPageTypeEnum.MyOrganizationsProjects:
                    return MyOrganizationsProjects;
                case ProjectFirmaPageTypeEnum.MyProjects:
                    return MyProjects;
                case ProjectFirmaPageTypeEnum.OrganizationsList:
                    return OrganizationsList;
                case ProjectFirmaPageTypeEnum.PagesWithIntroTextList:
                    return PagesWithIntroTextList;
                case ProjectFirmaPageTypeEnum.ParcelManagementGuidance:
                    return ParcelManagementGuidance;
                case ProjectFirmaPageTypeEnum.ParcelsByCommodity:
                    return ParcelsByCommodity;
                case ProjectFirmaPageTypeEnum.ParcelsByLandCapability:
                    return ParcelsByLandCapability;
                case ProjectFirmaPageTypeEnum.ParcelsList:
                    return ParcelsList;
                case ProjectFirmaPageTypeEnum.ParcelTownDistanceReport:
                    return ParcelTownDistanceReport;
                case ProjectFirmaPageTypeEnum.ParcelTrackerAbout:
                    return ParcelTrackerAbout;
                case ProjectFirmaPageTypeEnum.ParcelTrackerNarrative:
                    return ParcelTrackerNarrative;
                case ProjectFirmaPageTypeEnum.PoolsList:
                    return PoolsList;
                case ProjectFirmaPageTypeEnum.ProgramsList:
                    return ProgramsList;
                case ProjectFirmaPageTypeEnum.ProjectUpdateStatus:
                    return ProjectUpdateStatus;
                case ProjectFirmaPageTypeEnum.ProposedProjects:
                    return ProposedProjects;
                case ProjectFirmaPageTypeEnum.ResidentialAllocationsList:
                    return ResidentialAllocationsList;
                case ProjectFirmaPageTypeEnum.SIDAboutContent:
                    return SIDAboutContent;
                case ProjectFirmaPageTypeEnum.SIDAboutFAQ:
                    return SIDAboutFAQ;
                case ProjectFirmaPageTypeEnum.SIDAboutIntro:
                    return SIDAboutIntro;
                case ProjectFirmaPageTypeEnum.SIDHome:
                    return SIDHome;
                case ProjectFirmaPageTypeEnum.SpendingByEIPPerformanceMeasureByProject:
                    return SpendingByEIPPerformanceMeasureByProject;
                case ProjectFirmaPageTypeEnum.SpendingBySectorByFocusAreaByProgram:
                    return SpendingBySectorByFocusAreaByProgram;
                case ProjectFirmaPageTypeEnum.TagList:
                    return TagList;
                case ProjectFirmaPageTypeEnum.TerminatedProjectList:
                    return TerminatedProjectList;
                case ProjectFirmaPageTypeEnum.ThisTool:
                    return ThisTool;
                case ProjectFirmaPageTypeEnum.ThresholdsHome:
                    return ThresholdsHome;
                case ProjectFirmaPageTypeEnum.ThresholdsTaxonomy:
                    return ThresholdsTaxonomy;
                case ProjectFirmaPageTypeEnum.TransportationCostParameterSet:
                    return TransportationCostParameterSet;
                case ProjectFirmaPageTypeEnum.TransportationObjectivesList:
                    return TransportationObjectivesList;
                case ProjectFirmaPageTypeEnum.TransportationProjectList:
                    return TransportationProjectList;
                case ProjectFirmaPageTypeEnum.TransportationStrategiesList:
                    return TransportationStrategiesList;
                case ProjectFirmaPageTypeEnum.TransportationTaxonomy:
                    return TransportationTaxonomy;
                case ProjectFirmaPageTypeEnum.WatershedsList:
                    return WatershedsList;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectFirmaPageTypeEnum
    {
        EIPTrackerNarrative = 1,
        EIPOverview = 2,
        HistoryOfTheEIP = 3,
        EIPPartners = 4,
        EIPFaq = 5,
        FullProjectList = 6,
        FiveYearProjectList = 7,
        CompletedProjectList = 8,
        EIPPerformanceMeasuresList = 9,
        ThresholdsHome = 10,
        ActionPrioritiesList = 11,
        LocalAndRegionalPlansList = 12,
        FocusAreasList = 13,
        FundingSourcesList = 14,
        OrganizationsList = 15,
        ProgramsList = 16,
        WatershedsList = 17,
        MyProjects = 18,
        PagesWithIntroTextList = 19,
        InvestmentByFundingSector = 20,
        SpendingBySectorByFocusAreaByProgram = 21,
        EIPProjectMap = 22,
        EIPResultsByProgram = 23,
        ThisTool = 24,
        EIPHomeAdditionalInfo = 25,
        FeaturedProjectList = 26,
        DemoScript = 27,
        TransportationStrategiesList = 28,
        TransportationObjectivesList = 29,
        TransportationProjectList = 30,
        TransportationCostParameterSet = 31,
        TerminatedProjectList = 32,
        FullProjectListSimple = 33,
        EIPTaxonomy = 34,
        TransportationTaxonomy = 35,
        TagList = 36,
        SpendingByEIPPerformanceMeasureByProject = 37,
        ProposedProjects = 38,
        MyOrganizationsProjects = 39,
        AnnualApprovalProcess = 40,
        ManageUpdateNotifications = 41,
        ProjectUpdateStatus = 42,
        SIDAboutIntro = 43,
        SIDAboutContent = 44,
        SIDAboutFAQ = 45,
        SIDHome = 46,
        LTInfoDataCenter = 47,
        LTInfoAbout = 48,
        ParcelTrackerNarrative = 49,
        CommodityTransactionsList = 50,
        PoolsList = 51,
        LeadAgencyResponsibilityMatrixByTransactionType = 52,
        LeadAgencyResponsibilityMatrixByCommodity = 53,
        ParcelTownDistanceReport = 54,
        ParcelsList = 56,
        ParcelsByLandCapability = 57,
        LeadAgenciesList = 58,
        AccelaCAPRecordsList = 59,
        ResidentialAllocationsList = 60,
        BankedCommoditiesList = 61,
        ParcelTrackerAbout = 62,
        ParcelManagementGuidance = 63,
        ParcelsByCommodity = 64,
        AllParcelsList = 65,
        ThresholdsTaxonomy = 66,
        MonitoringProgramsList = 67
    }

    public partial class ProjectFirmaPageTypeEIPTrackerNarrative : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPTrackerNarrative(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPTrackerNarrative Instance = new ProjectFirmaPageTypeEIPTrackerNarrative(1, @"EIPTrackerNarrative", @"EIP Tracker Home Page Narrative", 1, 2);
    }

    public partial class ProjectFirmaPageTypeEIPOverview : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPOverview(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPOverview Instance = new ProjectFirmaPageTypeEIPOverview(2, @"EIPOverview", @"EIP Overview", 1, 2);
    }

    public partial class ProjectFirmaPageTypeHistoryOfTheEIP : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeHistoryOfTheEIP(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeHistoryOfTheEIP Instance = new ProjectFirmaPageTypeHistoryOfTheEIP(3, @"HistoryOfTheEIP", @"History of the EIP", 1, 2);
    }

    public partial class ProjectFirmaPageTypeEIPPartners : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPPartners(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPPartners Instance = new ProjectFirmaPageTypeEIPPartners(4, @"EIPPartners", @"EIP Partners", 1, 2);
    }

    public partial class ProjectFirmaPageTypeEIPFaq : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPFaq(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPFaq Instance = new ProjectFirmaPageTypeEIPFaq(5, @"EIPFaq", @"EIP FAQ", 1, 2);
    }

    public partial class ProjectFirmaPageTypeFullProjectList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeFullProjectList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeFullProjectList Instance = new ProjectFirmaPageTypeFullProjectList(6, @"FullProjectList", @"Full Project List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeFiveYearProjectList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeFiveYearProjectList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeFiveYearProjectList Instance = new ProjectFirmaPageTypeFiveYearProjectList(7, @"FiveYearProjectList", @"5 Year Project List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeCompletedProjectList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeCompletedProjectList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeCompletedProjectList Instance = new ProjectFirmaPageTypeCompletedProjectList(8, @"CompletedProjectList", @"Completed Project List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeEIPPerformanceMeasuresList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPPerformanceMeasuresList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPPerformanceMeasuresList Instance = new ProjectFirmaPageTypeEIPPerformanceMeasuresList(9, @"EIPPerformanceMeasuresList", @"EIP Performance Measures List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeThresholdsHome : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeThresholdsHome(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeThresholdsHome Instance = new ProjectFirmaPageTypeThresholdsHome(10, @"ThresholdsHome", @"Thresholds Home Page Introduction", 5, 1);
    }

    public partial class ProjectFirmaPageTypeActionPrioritiesList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeActionPrioritiesList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeActionPrioritiesList Instance = new ProjectFirmaPageTypeActionPrioritiesList(11, @"ActionPrioritiesList", @"Action Priorities List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeLocalAndRegionalPlansList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeLocalAndRegionalPlansList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeLocalAndRegionalPlansList Instance = new ProjectFirmaPageTypeLocalAndRegionalPlansList(12, @"LocalAndRegionalPlansList", @"Local and Regional Plans List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeFocusAreasList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeFocusAreasList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeFocusAreasList Instance = new ProjectFirmaPageTypeFocusAreasList(13, @"FocusAreasList", @"Focus Areas List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeFundingSourcesList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeFundingSourcesList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeFundingSourcesList Instance = new ProjectFirmaPageTypeFundingSourcesList(14, @"FundingSourcesList", @"Funding Sources List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeOrganizationsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeOrganizationsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeOrganizationsList Instance = new ProjectFirmaPageTypeOrganizationsList(15, @"OrganizationsList", @"Organizations List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeProgramsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeProgramsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeProgramsList Instance = new ProjectFirmaPageTypeProgramsList(16, @"ProgramsList", @"Programs List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeWatershedsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeWatershedsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeWatershedsList Instance = new ProjectFirmaPageTypeWatershedsList(17, @"WatershedsList", @"Watersheds List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeMyProjects : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeMyProjects(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeMyProjects Instance = new ProjectFirmaPageTypeMyProjects(18, @"MyProjects", @"My Projects", 1, 1);
    }

    public partial class ProjectFirmaPageTypePagesWithIntroTextList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypePagesWithIntroTextList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypePagesWithIntroTextList Instance = new ProjectFirmaPageTypePagesWithIntroTextList(19, @"PagesWithIntroTextList", @"Manage Introductory Text for Pages", 1, 1);
    }

    public partial class ProjectFirmaPageTypeInvestmentByFundingSector : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeInvestmentByFundingSector(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeInvestmentByFundingSector Instance = new ProjectFirmaPageTypeInvestmentByFundingSector(20, @"InvestmentByFundingSector", @"EIP Investment by Funding Sector", 1, 1);
    }

    public partial class ProjectFirmaPageTypeSpendingBySectorByFocusAreaByProgram : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeSpendingBySectorByFocusAreaByProgram(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeSpendingBySectorByFocusAreaByProgram Instance = new ProjectFirmaPageTypeSpendingBySectorByFocusAreaByProgram(21, @"SpendingBySectorByFocusAreaByProgram", @"Spending by Sector by Focus Area by Program", 1, 1);
    }

    public partial class ProjectFirmaPageTypeEIPProjectMap : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPProjectMap(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPProjectMap Instance = new ProjectFirmaPageTypeEIPProjectMap(22, @"EIPProjectMap", @"EIP Project Map", 1, 1);
    }

    public partial class ProjectFirmaPageTypeEIPResultsByProgram : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPResultsByProgram(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPResultsByProgram Instance = new ProjectFirmaPageTypeEIPResultsByProgram(23, @"EIPResultsByProgram", @"EIP Results by Program", 1, 1);
    }

    public partial class ProjectFirmaPageTypeThisTool : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeThisTool(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeThisTool Instance = new ProjectFirmaPageTypeThisTool(24, @"ThisTool", @"This Tool", 1, 2);
    }

    public partial class ProjectFirmaPageTypeEIPHomeAdditionalInfo : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPHomeAdditionalInfo(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPHomeAdditionalInfo Instance = new ProjectFirmaPageTypeEIPHomeAdditionalInfo(25, @"EIPHomeAdditionalInfo", @"EIP Tracker Home Page Additional Info", 1, 2);
    }

    public partial class ProjectFirmaPageTypeFeaturedProjectList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeFeaturedProjectList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeFeaturedProjectList Instance = new ProjectFirmaPageTypeFeaturedProjectList(26, @"FeaturedProjectList", @"Featured Project List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeDemoScript : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeDemoScript(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeDemoScript Instance = new ProjectFirmaPageTypeDemoScript(27, @"DemoScript", @"Demo Script", 1, 2);
    }

    public partial class ProjectFirmaPageTypeTransportationStrategiesList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeTransportationStrategiesList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeTransportationStrategiesList Instance = new ProjectFirmaPageTypeTransportationStrategiesList(28, @"TransportationStrategiesList", @"Transportation Strategies List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeTransportationObjectivesList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeTransportationObjectivesList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeTransportationObjectivesList Instance = new ProjectFirmaPageTypeTransportationObjectivesList(29, @"TransportationObjectivesList", @"Transportation Objectives List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeTransportationProjectList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeTransportationProjectList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeTransportationProjectList Instance = new ProjectFirmaPageTypeTransportationProjectList(30, @"TransportationProjectList", @"Transportation Project List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeTransportationCostParameterSet : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeTransportationCostParameterSet(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeTransportationCostParameterSet Instance = new ProjectFirmaPageTypeTransportationCostParameterSet(31, @"TransportationCostParameterSet", @"Transportation Cost Parameter Set", 1, 1);
    }

    public partial class ProjectFirmaPageTypeTerminatedProjectList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeTerminatedProjectList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeTerminatedProjectList Instance = new ProjectFirmaPageTypeTerminatedProjectList(32, @"TerminatedProjectList", @"Terminated Project List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeFullProjectListSimple : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeFullProjectListSimple(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeFullProjectListSimple Instance = new ProjectFirmaPageTypeFullProjectListSimple(33, @"FullProjectListSimple", @"Full Project List (Simple)", 1, 1);
    }

    public partial class ProjectFirmaPageTypeEIPTaxonomy : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeEIPTaxonomy(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeEIPTaxonomy Instance = new ProjectFirmaPageTypeEIPTaxonomy(34, @"EIPTaxonomy", @"EIP Taxonomy", 1, 1);
    }

    public partial class ProjectFirmaPageTypeTransportationTaxonomy : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeTransportationTaxonomy(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeTransportationTaxonomy Instance = new ProjectFirmaPageTypeTransportationTaxonomy(35, @"TransportationTaxonomy", @"Transportation Strategies and Objectives", 1, 1);
    }

    public partial class ProjectFirmaPageTypeTagList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeTagList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeTagList Instance = new ProjectFirmaPageTypeTagList(36, @"TagList", @"Tag List", 1, 1);
    }

    public partial class ProjectFirmaPageTypeSpendingByEIPPerformanceMeasureByProject : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeSpendingByEIPPerformanceMeasureByProject(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeSpendingByEIPPerformanceMeasureByProject Instance = new ProjectFirmaPageTypeSpendingByEIPPerformanceMeasureByProject(37, @"SpendingByEIPPerformanceMeasureByProject", @"Spending by Performance Measure by Project", 1, 1);
    }

    public partial class ProjectFirmaPageTypeProposedProjects : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeProposedProjects(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeProposedProjects Instance = new ProjectFirmaPageTypeProposedProjects(38, @"ProposedProjects", @"Proposed Projects", 1, 1);
    }

    public partial class ProjectFirmaPageTypeMyOrganizationsProjects : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeMyOrganizationsProjects(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeMyOrganizationsProjects Instance = new ProjectFirmaPageTypeMyOrganizationsProjects(39, @"MyOrganizationsProjects", @"My Organization's Projects", 1, 1);
    }

    public partial class ProjectFirmaPageTypeAnnualApprovalProcess : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeAnnualApprovalProcess(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeAnnualApprovalProcess Instance = new ProjectFirmaPageTypeAnnualApprovalProcess(40, @"AnnualApprovalProcess", @"Annual Update Approval Process", 1, 2);
    }

    public partial class ProjectFirmaPageTypeManageUpdateNotifications : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeManageUpdateNotifications(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeManageUpdateNotifications Instance = new ProjectFirmaPageTypeManageUpdateNotifications(41, @"ManageUpdateNotifications", @"Manage Project Update Notifications", 1, 1);
    }

    public partial class ProjectFirmaPageTypeProjectUpdateStatus : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeProjectUpdateStatus(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeProjectUpdateStatus Instance = new ProjectFirmaPageTypeProjectUpdateStatus(42, @"ProjectUpdateStatus", @"Annual Project Update Status Report", 1, 1);
    }

    public partial class ProjectFirmaPageTypeSIDAboutIntro : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeSIDAboutIntro(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeSIDAboutIntro Instance = new ProjectFirmaPageTypeSIDAboutIntro(43, @"SIDAboutIntro", @"About Sustainability Dashboard - Page Introduction", 2, 2);
    }

    public partial class ProjectFirmaPageTypeSIDAboutContent : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeSIDAboutContent(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeSIDAboutContent Instance = new ProjectFirmaPageTypeSIDAboutContent(44, @"SIDAboutContent", @"About Sustainability Dashboard - Page Content", 2, 2);
    }

    public partial class ProjectFirmaPageTypeSIDAboutFAQ : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeSIDAboutFAQ(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeSIDAboutFAQ Instance = new ProjectFirmaPageTypeSIDAboutFAQ(45, @"SIDAboutFAQ", @"About Sustainability Dashboard - FAQ", 2, 2);
    }

    public partial class ProjectFirmaPageTypeSIDHome : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeSIDHome(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeSIDHome Instance = new ProjectFirmaPageTypeSIDHome(46, @"SIDHome", @"Sustainability Dashboard Home Page Introduction", 2, 2);
    }

    public partial class ProjectFirmaPageTypeLTInfoDataCenter : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeLTInfoDataCenter(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeLTInfoDataCenter Instance = new ProjectFirmaPageTypeLTInfoDataCenter(47, @"LTInfoDataCenter", @"Lake Tahoe Info Data Center", 3, 1);
    }

    public partial class ProjectFirmaPageTypeLTInfoAbout : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeLTInfoAbout(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeLTInfoAbout Instance = new ProjectFirmaPageTypeLTInfoAbout(48, @"LTInfoAbout", @"About Lake Tahoe Info", 3, 2);
    }

    public partial class ProjectFirmaPageTypeParcelTrackerNarrative : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeParcelTrackerNarrative(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeParcelTrackerNarrative Instance = new ProjectFirmaPageTypeParcelTrackerNarrative(49, @"ParcelTrackerNarrative", @"Parcel Tracker Home Page Narrative", 4, 1);
    }

    public partial class ProjectFirmaPageTypeCommodityTransactionsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeCommodityTransactionsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeCommodityTransactionsList Instance = new ProjectFirmaPageTypeCommodityTransactionsList(50, @"CommodityTransactionsList", @"Commodity Transactions List", 4, 1);
    }

    public partial class ProjectFirmaPageTypePoolsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypePoolsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypePoolsList Instance = new ProjectFirmaPageTypePoolsList(51, @"PoolsList", @"Pools List", 4, 1);
    }

    public partial class ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByTransactionType : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByTransactionType(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByTransactionType Instance = new ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByTransactionType(52, @"LeadAgencyResponsibilityMatrixByTransactionType", @"Lead Agency Responsibility Matrix for Reporting Transactions - By Transaction Type", 4, 1);
    }

    public partial class ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByCommodity : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByCommodity(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByCommodity Instance = new ProjectFirmaPageTypeLeadAgencyResponsibilityMatrixByCommodity(53, @"LeadAgencyResponsibilityMatrixByCommodity", @"Lead Agency Responsibility Matrix for Reporting Transactions - By Commodity", 4, 1);
    }

    public partial class ProjectFirmaPageTypeParcelTownDistanceReport : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeParcelTownDistanceReport(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeParcelTownDistanceReport Instance = new ProjectFirmaPageTypeParcelTownDistanceReport(54, @"ParcelTownDistanceReport", @"Parcel Town Distance Report", 4, 1);
    }

    public partial class ProjectFirmaPageTypeParcelsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeParcelsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeParcelsList Instance = new ProjectFirmaPageTypeParcelsList(56, @"ParcelsList", @"Parcels List", 4, 1);
    }

    public partial class ProjectFirmaPageTypeParcelsByLandCapability : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeParcelsByLandCapability(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeParcelsByLandCapability Instance = new ProjectFirmaPageTypeParcelsByLandCapability(57, @"ParcelsByLandCapability", @"Parcels by Land Capability", 4, 1);
    }

    public partial class ProjectFirmaPageTypeLeadAgenciesList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeLeadAgenciesList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeLeadAgenciesList Instance = new ProjectFirmaPageTypeLeadAgenciesList(58, @"LeadAgenciesList", @"Lead Agencies List", 4, 1);
    }

    public partial class ProjectFirmaPageTypeAccelaCAPRecordsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeAccelaCAPRecordsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeAccelaCAPRecordsList Instance = new ProjectFirmaPageTypeAccelaCAPRecordsList(59, @"AccelaCAPRecordsList", @"Accela CAP Records List", 4, 1);
    }

    public partial class ProjectFirmaPageTypeResidentialAllocationsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeResidentialAllocationsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeResidentialAllocationsList Instance = new ProjectFirmaPageTypeResidentialAllocationsList(60, @"ResidentialAllocationsList", @"Residential Allocations List", 4, 1);
    }

    public partial class ProjectFirmaPageTypeBankedCommoditiesList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeBankedCommoditiesList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeBankedCommoditiesList Instance = new ProjectFirmaPageTypeBankedCommoditiesList(61, @"BankedCommoditiesList", @"Banked Commodities List", 4, 1);
    }

    public partial class ProjectFirmaPageTypeParcelTrackerAbout : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeParcelTrackerAbout(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeParcelTrackerAbout Instance = new ProjectFirmaPageTypeParcelTrackerAbout(62, @"ParcelTrackerAbout", @"About Parcel Tracker", 4, 2);
    }

    public partial class ProjectFirmaPageTypeParcelManagementGuidance : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeParcelManagementGuidance(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeParcelManagementGuidance Instance = new ProjectFirmaPageTypeParcelManagementGuidance(63, @"ParcelManagementGuidance", @"Guidance for Managing/Updating Parcels", 4, 2);
    }

    public partial class ProjectFirmaPageTypeParcelsByCommodity : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeParcelsByCommodity(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeParcelsByCommodity Instance = new ProjectFirmaPageTypeParcelsByCommodity(64, @"ParcelsByCommodity", @"Parcels by Current Commodity Inventory", 4, 1);
    }

    public partial class ProjectFirmaPageTypeAllParcelsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeAllParcelsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeAllParcelsList Instance = new ProjectFirmaPageTypeAllParcelsList(65, @"AllParcelsList", @"All Parcels", 4, 1);
    }

    public partial class ProjectFirmaPageTypeThresholdsTaxonomy : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeThresholdsTaxonomy(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeThresholdsTaxonomy Instance = new ProjectFirmaPageTypeThresholdsTaxonomy(66, @"ThresholdsTaxonomy", @"Threshold Categories", 5, 1);
    }

    public partial class ProjectFirmaPageTypeMonitoringProgramsList : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeMonitoringProgramsList(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeMonitoringProgramsList Instance = new ProjectFirmaPageTypeMonitoringProgramsList(67, @"MonitoringProgramsList", @"Monitoring Programs", 5, 1);
    }
}