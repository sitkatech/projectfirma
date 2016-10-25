//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageType]
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
    public abstract partial class FirmaPageType : IHavePrimaryKey
    {
        public static readonly FirmaPageTypeHomePage HomePage = FirmaPageTypeHomePage.Instance;
        public static readonly FirmaPageTypeAboutClackamasPartnership AboutClackamasPartnership = FirmaPageTypeAboutClackamasPartnership.Instance;
        public static readonly FirmaPageTypeMeetings Meetings = FirmaPageTypeMeetings.Instance;
        public static readonly FirmaPageTypeFullProjectList FullProjectList = FirmaPageTypeFullProjectList.Instance;
        public static readonly FirmaPageTypeFiveYearProjectList FiveYearProjectList = FirmaPageTypeFiveYearProjectList.Instance;
        public static readonly FirmaPageTypeCompletedProjectList CompletedProjectList = FirmaPageTypeCompletedProjectList.Instance;
        public static readonly FirmaPageTypeEIPPerformanceMeasuresList EIPPerformanceMeasuresList = FirmaPageTypeEIPPerformanceMeasuresList.Instance;
        public static readonly FirmaPageTypeActionPrioritiesList ActionPrioritiesList = FirmaPageTypeActionPrioritiesList.Instance;
        public static readonly FirmaPageTypeLocalAndRegionalPlansList LocalAndRegionalPlansList = FirmaPageTypeLocalAndRegionalPlansList.Instance;
        public static readonly FirmaPageTypeFocusAreasList FocusAreasList = FirmaPageTypeFocusAreasList.Instance;
        public static readonly FirmaPageTypeFundingSourcesList FundingSourcesList = FirmaPageTypeFundingSourcesList.Instance;
        public static readonly FirmaPageTypeOrganizationsList OrganizationsList = FirmaPageTypeOrganizationsList.Instance;
        public static readonly FirmaPageTypeProgramsList ProgramsList = FirmaPageTypeProgramsList.Instance;
        public static readonly FirmaPageTypeWatershedsList WatershedsList = FirmaPageTypeWatershedsList.Instance;
        public static readonly FirmaPageTypeMyProjects MyProjects = FirmaPageTypeMyProjects.Instance;
        public static readonly FirmaPageTypePagesWithIntroTextList PagesWithIntroTextList = FirmaPageTypePagesWithIntroTextList.Instance;
        public static readonly FirmaPageTypeInvestmentByFundingSector InvestmentByFundingSector = FirmaPageTypeInvestmentByFundingSector.Instance;
        public static readonly FirmaPageTypeSpendingBySectorByFocusAreaByProgram SpendingBySectorByFocusAreaByProgram = FirmaPageTypeSpendingBySectorByFocusAreaByProgram.Instance;
        public static readonly FirmaPageTypeEIPProjectMap EIPProjectMap = FirmaPageTypeEIPProjectMap.Instance;
        public static readonly FirmaPageTypeEIPResultsByProgram EIPResultsByProgram = FirmaPageTypeEIPResultsByProgram.Instance;
        public static readonly FirmaPageTypeEIPHomeAdditionalInfo EIPHomeAdditionalInfo = FirmaPageTypeEIPHomeAdditionalInfo.Instance;
        public static readonly FirmaPageTypeFeaturedProjectList FeaturedProjectList = FirmaPageTypeFeaturedProjectList.Instance;
        public static readonly FirmaPageTypeTransportationStrategiesList TransportationStrategiesList = FirmaPageTypeTransportationStrategiesList.Instance;
        public static readonly FirmaPageTypeTransportationObjectivesList TransportationObjectivesList = FirmaPageTypeTransportationObjectivesList.Instance;
        public static readonly FirmaPageTypeTransportationProjectList TransportationProjectList = FirmaPageTypeTransportationProjectList.Instance;
        public static readonly FirmaPageTypeTransportationCostParameterSet TransportationCostParameterSet = FirmaPageTypeTransportationCostParameterSet.Instance;
        public static readonly FirmaPageTypeTerminatedProjectList TerminatedProjectList = FirmaPageTypeTerminatedProjectList.Instance;
        public static readonly FirmaPageTypeFullProjectListSimple FullProjectListSimple = FirmaPageTypeFullProjectListSimple.Instance;
        public static readonly FirmaPageTypeEIPTaxonomy EIPTaxonomy = FirmaPageTypeEIPTaxonomy.Instance;
        public static readonly FirmaPageTypeTransportationTaxonomy TransportationTaxonomy = FirmaPageTypeTransportationTaxonomy.Instance;
        public static readonly FirmaPageTypeTagList TagList = FirmaPageTypeTagList.Instance;
        public static readonly FirmaPageTypeSpendingByEIPPerformanceMeasureByProject SpendingByEIPPerformanceMeasureByProject = FirmaPageTypeSpendingByEIPPerformanceMeasureByProject.Instance;
        public static readonly FirmaPageTypeProposedProjects ProposedProjects = FirmaPageTypeProposedProjects.Instance;
        public static readonly FirmaPageTypeMyOrganizationsProjects MyOrganizationsProjects = FirmaPageTypeMyOrganizationsProjects.Instance;
        public static readonly FirmaPageTypeManageUpdateNotifications ManageUpdateNotifications = FirmaPageTypeManageUpdateNotifications.Instance;
        public static readonly FirmaPageTypeProjectUpdateStatus ProjectUpdateStatus = FirmaPageTypeProjectUpdateStatus.Instance;
        public static readonly FirmaPageTypeThresholdCategoriesList ThresholdCategoriesList = FirmaPageTypeThresholdCategoriesList.Instance;
        public static readonly FirmaPageTypeMonitoringProgramsList MonitoringProgramsList = FirmaPageTypeMonitoringProgramsList.Instance;

        public static readonly List<FirmaPageType> All;
        public static readonly ReadOnlyDictionary<int, FirmaPageType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FirmaPageType()
        {
            All = new List<FirmaPageType> { HomePage, AboutClackamasPartnership, Meetings, FullProjectList, FiveYearProjectList, CompletedProjectList, EIPPerformanceMeasuresList, ActionPrioritiesList, LocalAndRegionalPlansList, FocusAreasList, FundingSourcesList, OrganizationsList, ProgramsList, WatershedsList, MyProjects, PagesWithIntroTextList, InvestmentByFundingSector, SpendingBySectorByFocusAreaByProgram, EIPProjectMap, EIPResultsByProgram, EIPHomeAdditionalInfo, FeaturedProjectList, TransportationStrategiesList, TransportationObjectivesList, TransportationProjectList, TransportationCostParameterSet, TerminatedProjectList, FullProjectListSimple, EIPTaxonomy, TransportationTaxonomy, TagList, SpendingByEIPPerformanceMeasureByProject, ProposedProjects, MyOrganizationsProjects, ManageUpdateNotifications, ProjectUpdateStatus, ThresholdCategoriesList, MonitoringProgramsList };
            AllLookupDictionary = new ReadOnlyDictionary<int, FirmaPageType>(All.ToDictionary(x => x.FirmaPageTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FirmaPageType(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID)
        {
            FirmaPageTypeID = firmaPageTypeID;
            FirmaPageTypeName = firmaPageTypeName;
            FirmaPageTypeDisplayName = firmaPageTypeDisplayName;
            FirmaPageRenderTypeID = firmaPageRenderTypeID;
        }
        public FirmaPageRenderType FirmaPageRenderType { get { return FirmaPageRenderType.AllLookupDictionary[FirmaPageRenderTypeID]; } }
        [Key]
        public int FirmaPageTypeID { get; private set; }
        public string FirmaPageTypeName { get; private set; }
        public string FirmaPageTypeDisplayName { get; private set; }
        public int FirmaPageRenderTypeID { get; private set; }
        public int PrimaryKey { get { return FirmaPageTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FirmaPageType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FirmaPageTypeID == FirmaPageTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FirmaPageType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FirmaPageTypeID;
        }

        public static bool operator ==(FirmaPageType left, FirmaPageType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirmaPageType left, FirmaPageType right)
        {
            return !Equals(left, right);
        }

        public FirmaPageTypeEnum ToEnum { get { return (FirmaPageTypeEnum)GetHashCode(); } }

        public static FirmaPageType ToType(int enumValue)
        {
            return ToType((FirmaPageTypeEnum)enumValue);
        }

        public static FirmaPageType ToType(FirmaPageTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FirmaPageTypeEnum.AboutClackamasPartnership:
                    return AboutClackamasPartnership;
                case FirmaPageTypeEnum.ActionPrioritiesList:
                    return ActionPrioritiesList;
                case FirmaPageTypeEnum.CompletedProjectList:
                    return CompletedProjectList;
                case FirmaPageTypeEnum.EIPHomeAdditionalInfo:
                    return EIPHomeAdditionalInfo;
                case FirmaPageTypeEnum.EIPPerformanceMeasuresList:
                    return EIPPerformanceMeasuresList;
                case FirmaPageTypeEnum.EIPProjectMap:
                    return EIPProjectMap;
                case FirmaPageTypeEnum.EIPResultsByProgram:
                    return EIPResultsByProgram;
                case FirmaPageTypeEnum.EIPTaxonomy:
                    return EIPTaxonomy;
                case FirmaPageTypeEnum.FeaturedProjectList:
                    return FeaturedProjectList;
                case FirmaPageTypeEnum.FiveYearProjectList:
                    return FiveYearProjectList;
                case FirmaPageTypeEnum.FocusAreasList:
                    return FocusAreasList;
                case FirmaPageTypeEnum.FullProjectList:
                    return FullProjectList;
                case FirmaPageTypeEnum.FullProjectListSimple:
                    return FullProjectListSimple;
                case FirmaPageTypeEnum.FundingSourcesList:
                    return FundingSourcesList;
                case FirmaPageTypeEnum.HomePage:
                    return HomePage;
                case FirmaPageTypeEnum.InvestmentByFundingSector:
                    return InvestmentByFundingSector;
                case FirmaPageTypeEnum.LocalAndRegionalPlansList:
                    return LocalAndRegionalPlansList;
                case FirmaPageTypeEnum.ManageUpdateNotifications:
                    return ManageUpdateNotifications;
                case FirmaPageTypeEnum.Meetings:
                    return Meetings;
                case FirmaPageTypeEnum.MonitoringProgramsList:
                    return MonitoringProgramsList;
                case FirmaPageTypeEnum.MyOrganizationsProjects:
                    return MyOrganizationsProjects;
                case FirmaPageTypeEnum.MyProjects:
                    return MyProjects;
                case FirmaPageTypeEnum.OrganizationsList:
                    return OrganizationsList;
                case FirmaPageTypeEnum.PagesWithIntroTextList:
                    return PagesWithIntroTextList;
                case FirmaPageTypeEnum.ProgramsList:
                    return ProgramsList;
                case FirmaPageTypeEnum.ProjectUpdateStatus:
                    return ProjectUpdateStatus;
                case FirmaPageTypeEnum.ProposedProjects:
                    return ProposedProjects;
                case FirmaPageTypeEnum.SpendingByEIPPerformanceMeasureByProject:
                    return SpendingByEIPPerformanceMeasureByProject;
                case FirmaPageTypeEnum.SpendingBySectorByFocusAreaByProgram:
                    return SpendingBySectorByFocusAreaByProgram;
                case FirmaPageTypeEnum.TagList:
                    return TagList;
                case FirmaPageTypeEnum.TerminatedProjectList:
                    return TerminatedProjectList;
                case FirmaPageTypeEnum.ThresholdCategoriesList:
                    return ThresholdCategoriesList;
                case FirmaPageTypeEnum.TransportationCostParameterSet:
                    return TransportationCostParameterSet;
                case FirmaPageTypeEnum.TransportationObjectivesList:
                    return TransportationObjectivesList;
                case FirmaPageTypeEnum.TransportationProjectList:
                    return TransportationProjectList;
                case FirmaPageTypeEnum.TransportationStrategiesList:
                    return TransportationStrategiesList;
                case FirmaPageTypeEnum.TransportationTaxonomy:
                    return TransportationTaxonomy;
                case FirmaPageTypeEnum.WatershedsList:
                    return WatershedsList;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FirmaPageTypeEnum
    {
        HomePage = 1,
        AboutClackamasPartnership = 2,
        Meetings = 3,
        FullProjectList = 6,
        FiveYearProjectList = 7,
        CompletedProjectList = 8,
        EIPPerformanceMeasuresList = 9,
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
        EIPHomeAdditionalInfo = 25,
        FeaturedProjectList = 26,
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
        ManageUpdateNotifications = 41,
        ProjectUpdateStatus = 42,
        ThresholdCategoriesList = 66,
        MonitoringProgramsList = 67
    }

    public partial class FirmaPageTypeHomePage : FirmaPageType
    {
        private FirmaPageTypeHomePage(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeHomePage Instance = new FirmaPageTypeHomePage(1, @"HomePage", @"Home Page", 2);
    }

    public partial class FirmaPageTypeAboutClackamasPartnership : FirmaPageType
    {
        private FirmaPageTypeAboutClackamasPartnership(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeAboutClackamasPartnership Instance = new FirmaPageTypeAboutClackamasPartnership(2, @"AboutClackamasPartnership", @"About Clackamas Partnership", 2);
    }

    public partial class FirmaPageTypeMeetings : FirmaPageType
    {
        private FirmaPageTypeMeetings(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeMeetings Instance = new FirmaPageTypeMeetings(3, @"Meetings", @"Meetings", 2);
    }

    public partial class FirmaPageTypeFullProjectList : FirmaPageType
    {
        private FirmaPageTypeFullProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullProjectList Instance = new FirmaPageTypeFullProjectList(6, @"FullProjectList", @"Full Project List", 1);
    }

    public partial class FirmaPageTypeFiveYearProjectList : FirmaPageType
    {
        private FirmaPageTypeFiveYearProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFiveYearProjectList Instance = new FirmaPageTypeFiveYearProjectList(7, @"FiveYearProjectList", @"5 Year Project List", 1);
    }

    public partial class FirmaPageTypeCompletedProjectList : FirmaPageType
    {
        private FirmaPageTypeCompletedProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeCompletedProjectList Instance = new FirmaPageTypeCompletedProjectList(8, @"CompletedProjectList", @"Completed Project List", 1);
    }

    public partial class FirmaPageTypeEIPPerformanceMeasuresList : FirmaPageType
    {
        private FirmaPageTypeEIPPerformanceMeasuresList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeEIPPerformanceMeasuresList Instance = new FirmaPageTypeEIPPerformanceMeasuresList(9, @"EIPPerformanceMeasuresList", @"EIP Performance Measures List", 1);
    }

    public partial class FirmaPageTypeActionPrioritiesList : FirmaPageType
    {
        private FirmaPageTypeActionPrioritiesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeActionPrioritiesList Instance = new FirmaPageTypeActionPrioritiesList(11, @"ActionPrioritiesList", @"Action Priorities List", 1);
    }

    public partial class FirmaPageTypeLocalAndRegionalPlansList : FirmaPageType
    {
        private FirmaPageTypeLocalAndRegionalPlansList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeLocalAndRegionalPlansList Instance = new FirmaPageTypeLocalAndRegionalPlansList(12, @"LocalAndRegionalPlansList", @"Local and Regional Plans List", 1);
    }

    public partial class FirmaPageTypeFocusAreasList : FirmaPageType
    {
        private FirmaPageTypeFocusAreasList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFocusAreasList Instance = new FirmaPageTypeFocusAreasList(13, @"FocusAreasList", @"Focus Areas List", 1);
    }

    public partial class FirmaPageTypeFundingSourcesList : FirmaPageType
    {
        private FirmaPageTypeFundingSourcesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFundingSourcesList Instance = new FirmaPageTypeFundingSourcesList(14, @"FundingSourcesList", @"Funding Sources List", 1);
    }

    public partial class FirmaPageTypeOrganizationsList : FirmaPageType
    {
        private FirmaPageTypeOrganizationsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeOrganizationsList Instance = new FirmaPageTypeOrganizationsList(15, @"OrganizationsList", @"Organizations List", 1);
    }

    public partial class FirmaPageTypeProgramsList : FirmaPageType
    {
        private FirmaPageTypeProgramsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProgramsList Instance = new FirmaPageTypeProgramsList(16, @"ProgramsList", @"Programs List", 1);
    }

    public partial class FirmaPageTypeWatershedsList : FirmaPageType
    {
        private FirmaPageTypeWatershedsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeWatershedsList Instance = new FirmaPageTypeWatershedsList(17, @"WatershedsList", @"Watersheds List", 1);
    }

    public partial class FirmaPageTypeMyProjects : FirmaPageType
    {
        private FirmaPageTypeMyProjects(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeMyProjects Instance = new FirmaPageTypeMyProjects(18, @"MyProjects", @"My Projects", 1);
    }

    public partial class FirmaPageTypePagesWithIntroTextList : FirmaPageType
    {
        private FirmaPageTypePagesWithIntroTextList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypePagesWithIntroTextList Instance = new FirmaPageTypePagesWithIntroTextList(19, @"PagesWithIntroTextList", @"Manage Introductory Text for Pages", 1);
    }

    public partial class FirmaPageTypeInvestmentByFundingSector : FirmaPageType
    {
        private FirmaPageTypeInvestmentByFundingSector(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeInvestmentByFundingSector Instance = new FirmaPageTypeInvestmentByFundingSector(20, @"InvestmentByFundingSector", @"EIP Investment by Funding Sector", 1);
    }

    public partial class FirmaPageTypeSpendingBySectorByFocusAreaByProgram : FirmaPageType
    {
        private FirmaPageTypeSpendingBySectorByFocusAreaByProgram(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeSpendingBySectorByFocusAreaByProgram Instance = new FirmaPageTypeSpendingBySectorByFocusAreaByProgram(21, @"SpendingBySectorByFocusAreaByProgram", @"Spending by Sector by Focus Area by Program", 1);
    }

    public partial class FirmaPageTypeEIPProjectMap : FirmaPageType
    {
        private FirmaPageTypeEIPProjectMap(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeEIPProjectMap Instance = new FirmaPageTypeEIPProjectMap(22, @"EIPProjectMap", @"EIP Project Map", 1);
    }

    public partial class FirmaPageTypeEIPResultsByProgram : FirmaPageType
    {
        private FirmaPageTypeEIPResultsByProgram(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeEIPResultsByProgram Instance = new FirmaPageTypeEIPResultsByProgram(23, @"EIPResultsByProgram", @"EIP Results by Program", 1);
    }

    public partial class FirmaPageTypeEIPHomeAdditionalInfo : FirmaPageType
    {
        private FirmaPageTypeEIPHomeAdditionalInfo(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeEIPHomeAdditionalInfo Instance = new FirmaPageTypeEIPHomeAdditionalInfo(25, @"EIPHomeAdditionalInfo", @"EIP Tracker Home Page Additional Info", 2);
    }

    public partial class FirmaPageTypeFeaturedProjectList : FirmaPageType
    {
        private FirmaPageTypeFeaturedProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFeaturedProjectList Instance = new FirmaPageTypeFeaturedProjectList(26, @"FeaturedProjectList", @"Featured Project List", 1);
    }

    public partial class FirmaPageTypeTransportationStrategiesList : FirmaPageType
    {
        private FirmaPageTypeTransportationStrategiesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTransportationStrategiesList Instance = new FirmaPageTypeTransportationStrategiesList(28, @"TransportationStrategiesList", @"Transportation Strategies List", 1);
    }

    public partial class FirmaPageTypeTransportationObjectivesList : FirmaPageType
    {
        private FirmaPageTypeTransportationObjectivesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTransportationObjectivesList Instance = new FirmaPageTypeTransportationObjectivesList(29, @"TransportationObjectivesList", @"Transportation Objectives List", 1);
    }

    public partial class FirmaPageTypeTransportationProjectList : FirmaPageType
    {
        private FirmaPageTypeTransportationProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTransportationProjectList Instance = new FirmaPageTypeTransportationProjectList(30, @"TransportationProjectList", @"Transportation Project List", 1);
    }

    public partial class FirmaPageTypeTransportationCostParameterSet : FirmaPageType
    {
        private FirmaPageTypeTransportationCostParameterSet(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTransportationCostParameterSet Instance = new FirmaPageTypeTransportationCostParameterSet(31, @"TransportationCostParameterSet", @"Transportation Cost Parameter Set", 1);
    }

    public partial class FirmaPageTypeTerminatedProjectList : FirmaPageType
    {
        private FirmaPageTypeTerminatedProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTerminatedProjectList Instance = new FirmaPageTypeTerminatedProjectList(32, @"TerminatedProjectList", @"Terminated Project List", 1);
    }

    public partial class FirmaPageTypeFullProjectListSimple : FirmaPageType
    {
        private FirmaPageTypeFullProjectListSimple(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullProjectListSimple Instance = new FirmaPageTypeFullProjectListSimple(33, @"FullProjectListSimple", @"Full Project List (Simple)", 1);
    }

    public partial class FirmaPageTypeEIPTaxonomy : FirmaPageType
    {
        private FirmaPageTypeEIPTaxonomy(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeEIPTaxonomy Instance = new FirmaPageTypeEIPTaxonomy(34, @"EIPTaxonomy", @"EIP Taxonomy", 1);
    }

    public partial class FirmaPageTypeTransportationTaxonomy : FirmaPageType
    {
        private FirmaPageTypeTransportationTaxonomy(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTransportationTaxonomy Instance = new FirmaPageTypeTransportationTaxonomy(35, @"TransportationTaxonomy", @"Transportation Strategies and Objectives", 1);
    }

    public partial class FirmaPageTypeTagList : FirmaPageType
    {
        private FirmaPageTypeTagList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTagList Instance = new FirmaPageTypeTagList(36, @"TagList", @"Tag List", 1);
    }

    public partial class FirmaPageTypeSpendingByEIPPerformanceMeasureByProject : FirmaPageType
    {
        private FirmaPageTypeSpendingByEIPPerformanceMeasureByProject(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeSpendingByEIPPerformanceMeasureByProject Instance = new FirmaPageTypeSpendingByEIPPerformanceMeasureByProject(37, @"SpendingByEIPPerformanceMeasureByProject", @"Spending by Performance Measure by Project", 1);
    }

    public partial class FirmaPageTypeProposedProjects : FirmaPageType
    {
        private FirmaPageTypeProposedProjects(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProposedProjects Instance = new FirmaPageTypeProposedProjects(38, @"ProposedProjects", @"Proposed Projects", 1);
    }

    public partial class FirmaPageTypeMyOrganizationsProjects : FirmaPageType
    {
        private FirmaPageTypeMyOrganizationsProjects(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeMyOrganizationsProjects Instance = new FirmaPageTypeMyOrganizationsProjects(39, @"MyOrganizationsProjects", @"My Organization's Projects", 1);
    }

    public partial class FirmaPageTypeManageUpdateNotifications : FirmaPageType
    {
        private FirmaPageTypeManageUpdateNotifications(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeManageUpdateNotifications Instance = new FirmaPageTypeManageUpdateNotifications(41, @"ManageUpdateNotifications", @"Manage Project Update Notifications", 1);
    }

    public partial class FirmaPageTypeProjectUpdateStatus : FirmaPageType
    {
        private FirmaPageTypeProjectUpdateStatus(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProjectUpdateStatus Instance = new FirmaPageTypeProjectUpdateStatus(42, @"ProjectUpdateStatus", @"Annual Project Update Status Report", 1);
    }

    public partial class FirmaPageTypeThresholdCategoriesList : FirmaPageType
    {
        private FirmaPageTypeThresholdCategoriesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeThresholdCategoriesList Instance = new FirmaPageTypeThresholdCategoriesList(66, @"ThresholdCategoriesList", @"Threshold Categories List", 1);
    }

    public partial class FirmaPageTypeMonitoringProgramsList : FirmaPageType
    {
        private FirmaPageTypeMonitoringProgramsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeMonitoringProgramsList Instance = new FirmaPageTypeMonitoringProgramsList(67, @"MonitoringProgramsList", @"Monitoring Programs", 1);
    }
}