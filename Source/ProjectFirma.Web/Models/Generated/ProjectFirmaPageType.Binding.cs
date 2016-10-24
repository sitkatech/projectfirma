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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class ProjectFirmaPageType : IHavePrimaryKey
    {
        public static readonly ProjectFirmaPageTypeHomePage HomePage = ProjectFirmaPageTypeHomePage.Instance;
        public static readonly ProjectFirmaPageTypeAboutClackamasPartnership AboutClackamasPartnership = ProjectFirmaPageTypeAboutClackamasPartnership.Instance;
        public static readonly ProjectFirmaPageTypeMeetings Meetings = ProjectFirmaPageTypeMeetings.Instance;
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
        public static readonly ProjectFirmaPageTypeEIPHomeAdditionalInfo EIPHomeAdditionalInfo = ProjectFirmaPageTypeEIPHomeAdditionalInfo.Instance;
        public static readonly ProjectFirmaPageTypeFeaturedProjectList FeaturedProjectList = ProjectFirmaPageTypeFeaturedProjectList.Instance;
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
        public static readonly ProjectFirmaPageTypeManageUpdateNotifications ManageUpdateNotifications = ProjectFirmaPageTypeManageUpdateNotifications.Instance;
        public static readonly ProjectFirmaPageTypeProjectUpdateStatus ProjectUpdateStatus = ProjectFirmaPageTypeProjectUpdateStatus.Instance;
        public static readonly ProjectFirmaPageTypeSIDAboutIntro SIDAboutIntro = ProjectFirmaPageTypeSIDAboutIntro.Instance;
        public static readonly ProjectFirmaPageTypeSIDAboutContent SIDAboutContent = ProjectFirmaPageTypeSIDAboutContent.Instance;
        public static readonly ProjectFirmaPageTypeSIDAboutFAQ SIDAboutFAQ = ProjectFirmaPageTypeSIDAboutFAQ.Instance;
        public static readonly ProjectFirmaPageTypeSIDHome SIDHome = ProjectFirmaPageTypeSIDHome.Instance;
        public static readonly ProjectFirmaPageTypeLTInfoDataCenter LTInfoDataCenter = ProjectFirmaPageTypeLTInfoDataCenter.Instance;
        public static readonly ProjectFirmaPageTypeLTInfoAbout LTInfoAbout = ProjectFirmaPageTypeLTInfoAbout.Instance;
        public static readonly ProjectFirmaPageTypeThresholdsTaxonomy ThresholdsTaxonomy = ProjectFirmaPageTypeThresholdsTaxonomy.Instance;
        public static readonly ProjectFirmaPageTypeMonitoringProgramsList MonitoringProgramsList = ProjectFirmaPageTypeMonitoringProgramsList.Instance;

        public static readonly List<ProjectFirmaPageType> All;
        public static readonly ReadOnlyDictionary<int, ProjectFirmaPageType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectFirmaPageType()
        {
            All = new List<ProjectFirmaPageType> { HomePage, AboutClackamasPartnership, Meetings, FullProjectList, FiveYearProjectList, CompletedProjectList, EIPPerformanceMeasuresList, ThresholdsHome, ActionPrioritiesList, LocalAndRegionalPlansList, FocusAreasList, FundingSourcesList, OrganizationsList, ProgramsList, WatershedsList, MyProjects, PagesWithIntroTextList, InvestmentByFundingSector, SpendingBySectorByFocusAreaByProgram, EIPProjectMap, EIPResultsByProgram, EIPHomeAdditionalInfo, FeaturedProjectList, TransportationStrategiesList, TransportationObjectivesList, TransportationProjectList, TransportationCostParameterSet, TerminatedProjectList, FullProjectListSimple, EIPTaxonomy, TransportationTaxonomy, TagList, SpendingByEIPPerformanceMeasureByProject, ProposedProjects, MyOrganizationsProjects, ManageUpdateNotifications, ProjectUpdateStatus, SIDAboutIntro, SIDAboutContent, SIDAboutFAQ, SIDHome, LTInfoDataCenter, LTInfoAbout, ThresholdsTaxonomy, MonitoringProgramsList };
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
                case ProjectFirmaPageTypeEnum.AboutClackamasPartnership:
                    return AboutClackamasPartnership;
                case ProjectFirmaPageTypeEnum.ActionPrioritiesList:
                    return ActionPrioritiesList;
                case ProjectFirmaPageTypeEnum.CompletedProjectList:
                    return CompletedProjectList;
                case ProjectFirmaPageTypeEnum.EIPHomeAdditionalInfo:
                    return EIPHomeAdditionalInfo;
                case ProjectFirmaPageTypeEnum.EIPPerformanceMeasuresList:
                    return EIPPerformanceMeasuresList;
                case ProjectFirmaPageTypeEnum.EIPProjectMap:
                    return EIPProjectMap;
                case ProjectFirmaPageTypeEnum.EIPResultsByProgram:
                    return EIPResultsByProgram;
                case ProjectFirmaPageTypeEnum.EIPTaxonomy:
                    return EIPTaxonomy;
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
                case ProjectFirmaPageTypeEnum.HomePage:
                    return HomePage;
                case ProjectFirmaPageTypeEnum.InvestmentByFundingSector:
                    return InvestmentByFundingSector;
                case ProjectFirmaPageTypeEnum.LocalAndRegionalPlansList:
                    return LocalAndRegionalPlansList;
                case ProjectFirmaPageTypeEnum.LTInfoAbout:
                    return LTInfoAbout;
                case ProjectFirmaPageTypeEnum.LTInfoDataCenter:
                    return LTInfoDataCenter;
                case ProjectFirmaPageTypeEnum.ManageUpdateNotifications:
                    return ManageUpdateNotifications;
                case ProjectFirmaPageTypeEnum.Meetings:
                    return Meetings;
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
                case ProjectFirmaPageTypeEnum.ProgramsList:
                    return ProgramsList;
                case ProjectFirmaPageTypeEnum.ProjectUpdateStatus:
                    return ProjectUpdateStatus;
                case ProjectFirmaPageTypeEnum.ProposedProjects:
                    return ProposedProjects;
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
        HomePage = 1,
        AboutClackamasPartnership = 2,
        Meetings = 3,
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
        SIDAboutIntro = 43,
        SIDAboutContent = 44,
        SIDAboutFAQ = 45,
        SIDHome = 46,
        LTInfoDataCenter = 47,
        LTInfoAbout = 48,
        ThresholdsTaxonomy = 66,
        MonitoringProgramsList = 67
    }

    public partial class ProjectFirmaPageTypeHomePage : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeHomePage(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeHomePage Instance = new ProjectFirmaPageTypeHomePage(1, @"HomePage", @"Home Page", 1, 2);
    }

    public partial class ProjectFirmaPageTypeAboutClackamasPartnership : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeAboutClackamasPartnership(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeAboutClackamasPartnership Instance = new ProjectFirmaPageTypeAboutClackamasPartnership(2, @"AboutClackamasPartnership", @"About Clackamas Partnership", 1, 2);
    }

    public partial class ProjectFirmaPageTypeMeetings : ProjectFirmaPageType
    {
        private ProjectFirmaPageTypeMeetings(int projectFirmaPageTypeID, string projectFirmaPageTypeName, string projectFirmaPageTypeDisplayName, int primaryLTInfoAreaID, int projectFirmaPageRenderTypeID) : base(projectFirmaPageTypeID, projectFirmaPageTypeName, projectFirmaPageTypeDisplayName, primaryLTInfoAreaID, projectFirmaPageRenderTypeID) {}
        public static readonly ProjectFirmaPageTypeMeetings Instance = new ProjectFirmaPageTypeMeetings(3, @"Meetings", @"Meetings", 1, 2);
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