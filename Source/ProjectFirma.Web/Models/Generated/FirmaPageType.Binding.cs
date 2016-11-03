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
        public static readonly FirmaPageTypeAbout About = FirmaPageTypeAbout.Instance;
        public static readonly FirmaPageTypeFirmaCustomPage1 FirmaCustomPage1 = FirmaPageTypeFirmaCustomPage1.Instance;
        public static readonly FirmaPageTypeFirmaCustomPage2 FirmaCustomPage2 = FirmaPageTypeFirmaCustomPage2.Instance;
        public static readonly FirmaPageTypeFirmaCustomPage3 FirmaCustomPage3 = FirmaPageTypeFirmaCustomPage3.Instance;
        public static readonly FirmaPageTypeFullProjectList FullProjectList = FirmaPageTypeFullProjectList.Instance;
        public static readonly FirmaPageTypeFiveYearProjectList FiveYearProjectList = FirmaPageTypeFiveYearProjectList.Instance;
        public static readonly FirmaPageTypeCompletedProjectList CompletedProjectList = FirmaPageTypeCompletedProjectList.Instance;
        public static readonly FirmaPageTypePerformanceMeasuresList PerformanceMeasuresList = FirmaPageTypePerformanceMeasuresList.Instance;
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
        public static readonly FirmaPageTypeProjectMap ProjectMap = FirmaPageTypeProjectMap.Instance;
        public static readonly FirmaPageTypeResultsByProgram ResultsByProgram = FirmaPageTypeResultsByProgram.Instance;
        public static readonly FirmaPageTypeHomeAdditionalInfo HomeAdditionalInfo = FirmaPageTypeHomeAdditionalInfo.Instance;
        public static readonly FirmaPageTypeFeaturedProjectList FeaturedProjectList = FirmaPageTypeFeaturedProjectList.Instance;
        public static readonly FirmaPageTypeCostParameterSet CostParameterSet = FirmaPageTypeCostParameterSet.Instance;
        public static readonly FirmaPageTypeTerminatedProjectList TerminatedProjectList = FirmaPageTypeTerminatedProjectList.Instance;
        public static readonly FirmaPageTypeFullProjectListSimple FullProjectListSimple = FirmaPageTypeFullProjectListSimple.Instance;
        public static readonly FirmaPageTypeTaxonomy Taxonomy = FirmaPageTypeTaxonomy.Instance;
        public static readonly FirmaPageTypeTagList TagList = FirmaPageTypeTagList.Instance;
        public static readonly FirmaPageTypeSpendingByPerformanceMeasureByProject SpendingByPerformanceMeasureByProject = FirmaPageTypeSpendingByPerformanceMeasureByProject.Instance;
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
            All = new List<FirmaPageType> { HomePage, About, FirmaCustomPage1, FirmaCustomPage2, FirmaCustomPage3, FullProjectList, FiveYearProjectList, CompletedProjectList, PerformanceMeasuresList, ActionPrioritiesList, LocalAndRegionalPlansList, FocusAreasList, FundingSourcesList, OrganizationsList, ProgramsList, WatershedsList, MyProjects, PagesWithIntroTextList, InvestmentByFundingSector, SpendingBySectorByFocusAreaByProgram, ProjectMap, ResultsByProgram, HomeAdditionalInfo, FeaturedProjectList, CostParameterSet, TerminatedProjectList, FullProjectListSimple, Taxonomy, TagList, SpendingByPerformanceMeasureByProject, ProposedProjects, MyOrganizationsProjects, ManageUpdateNotifications, ProjectUpdateStatus, ThresholdCategoriesList, MonitoringProgramsList };
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
                case FirmaPageTypeEnum.About:
                    return About;
                case FirmaPageTypeEnum.ActionPrioritiesList:
                    return ActionPrioritiesList;
                case FirmaPageTypeEnum.CompletedProjectList:
                    return CompletedProjectList;
                case FirmaPageTypeEnum.CostParameterSet:
                    return CostParameterSet;
                case FirmaPageTypeEnum.FeaturedProjectList:
                    return FeaturedProjectList;
                case FirmaPageTypeEnum.FirmaCustomPage1:
                    return FirmaCustomPage1;
                case FirmaPageTypeEnum.FirmaCustomPage2:
                    return FirmaCustomPage2;
                case FirmaPageTypeEnum.FirmaCustomPage3:
                    return FirmaCustomPage3;
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
                case FirmaPageTypeEnum.HomeAdditionalInfo:
                    return HomeAdditionalInfo;
                case FirmaPageTypeEnum.HomePage:
                    return HomePage;
                case FirmaPageTypeEnum.InvestmentByFundingSector:
                    return InvestmentByFundingSector;
                case FirmaPageTypeEnum.LocalAndRegionalPlansList:
                    return LocalAndRegionalPlansList;
                case FirmaPageTypeEnum.ManageUpdateNotifications:
                    return ManageUpdateNotifications;
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
                case FirmaPageTypeEnum.PerformanceMeasuresList:
                    return PerformanceMeasuresList;
                case FirmaPageTypeEnum.ProgramsList:
                    return ProgramsList;
                case FirmaPageTypeEnum.ProjectMap:
                    return ProjectMap;
                case FirmaPageTypeEnum.ProjectUpdateStatus:
                    return ProjectUpdateStatus;
                case FirmaPageTypeEnum.ProposedProjects:
                    return ProposedProjects;
                case FirmaPageTypeEnum.ResultsByProgram:
                    return ResultsByProgram;
                case FirmaPageTypeEnum.SpendingByPerformanceMeasureByProject:
                    return SpendingByPerformanceMeasureByProject;
                case FirmaPageTypeEnum.SpendingBySectorByFocusAreaByProgram:
                    return SpendingBySectorByFocusAreaByProgram;
                case FirmaPageTypeEnum.TagList:
                    return TagList;
                case FirmaPageTypeEnum.Taxonomy:
                    return Taxonomy;
                case FirmaPageTypeEnum.TerminatedProjectList:
                    return TerminatedProjectList;
                case FirmaPageTypeEnum.ThresholdCategoriesList:
                    return ThresholdCategoriesList;
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
        About = 2,
        FirmaCustomPage1 = 3,
        FirmaCustomPage2 = 4,
        FirmaCustomPage3 = 5,
        FullProjectList = 6,
        FiveYearProjectList = 7,
        CompletedProjectList = 8,
        PerformanceMeasuresList = 9,
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
        ProjectMap = 22,
        ResultsByProgram = 23,
        HomeAdditionalInfo = 25,
        FeaturedProjectList = 26,
        CostParameterSet = 31,
        TerminatedProjectList = 32,
        FullProjectListSimple = 33,
        Taxonomy = 34,
        TagList = 36,
        SpendingByPerformanceMeasureByProject = 37,
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

    public partial class FirmaPageTypeAbout : FirmaPageType
    {
        private FirmaPageTypeAbout(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeAbout Instance = new FirmaPageTypeAbout(2, @"About", @"About Clackamas Partnership", 2);
    }

    public partial class FirmaPageTypeFirmaCustomPage1 : FirmaPageType
    {
        private FirmaPageTypeFirmaCustomPage1(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFirmaCustomPage1 Instance = new FirmaPageTypeFirmaCustomPage1(3, @"FirmaCustomPage1", @"Meetings", 2);
    }

    public partial class FirmaPageTypeFirmaCustomPage2 : FirmaPageType
    {
        private FirmaPageTypeFirmaCustomPage2(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFirmaCustomPage2 Instance = new FirmaPageTypeFirmaCustomPage2(4, @"FirmaCustomPage2", @"Firma Custom Page 2", 2);
    }

    public partial class FirmaPageTypeFirmaCustomPage3 : FirmaPageType
    {
        private FirmaPageTypeFirmaCustomPage3(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFirmaCustomPage3 Instance = new FirmaPageTypeFirmaCustomPage3(5, @"FirmaCustomPage3", @"Firma Custom Page 3", 2);
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

    public partial class FirmaPageTypePerformanceMeasuresList : FirmaPageType
    {
        private FirmaPageTypePerformanceMeasuresList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypePerformanceMeasuresList Instance = new FirmaPageTypePerformanceMeasuresList(9, @"PerformanceMeasuresList", @"Performance Measures List", 1);
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
        public static readonly FirmaPageTypeInvestmentByFundingSector Instance = new FirmaPageTypeInvestmentByFundingSector(20, @"InvestmentByFundingSector", @"Investment by Funding Sector", 1);
    }

    public partial class FirmaPageTypeSpendingBySectorByFocusAreaByProgram : FirmaPageType
    {
        private FirmaPageTypeSpendingBySectorByFocusAreaByProgram(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeSpendingBySectorByFocusAreaByProgram Instance = new FirmaPageTypeSpendingBySectorByFocusAreaByProgram(21, @"SpendingBySectorByFocusAreaByProgram", @"Spending by Sector by Focus Area by Program", 1);
    }

    public partial class FirmaPageTypeProjectMap : FirmaPageType
    {
        private FirmaPageTypeProjectMap(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProjectMap Instance = new FirmaPageTypeProjectMap(22, @"ProjectMap", @"Project Map", 1);
    }

    public partial class FirmaPageTypeResultsByProgram : FirmaPageType
    {
        private FirmaPageTypeResultsByProgram(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeResultsByProgram Instance = new FirmaPageTypeResultsByProgram(23, @"ResultsByProgram", @"Results by Program", 1);
    }

    public partial class FirmaPageTypeHomeAdditionalInfo : FirmaPageType
    {
        private FirmaPageTypeHomeAdditionalInfo(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeHomeAdditionalInfo Instance = new FirmaPageTypeHomeAdditionalInfo(25, @"HomeAdditionalInfo", @"Home Page Additional Info", 2);
    }

    public partial class FirmaPageTypeFeaturedProjectList : FirmaPageType
    {
        private FirmaPageTypeFeaturedProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFeaturedProjectList Instance = new FirmaPageTypeFeaturedProjectList(26, @"FeaturedProjectList", @"Featured Project List", 1);
    }

    public partial class FirmaPageTypeCostParameterSet : FirmaPageType
    {
        private FirmaPageTypeCostParameterSet(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeCostParameterSet Instance = new FirmaPageTypeCostParameterSet(31, @"CostParameterSet", @"Cost Parameter Set", 1);
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

    public partial class FirmaPageTypeTaxonomy : FirmaPageType
    {
        private FirmaPageTypeTaxonomy(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTaxonomy Instance = new FirmaPageTypeTaxonomy(34, @"Taxonomy", @"Taxonomy", 1);
    }

    public partial class FirmaPageTypeTagList : FirmaPageType
    {
        private FirmaPageTypeTagList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTagList Instance = new FirmaPageTypeTagList(36, @"TagList", @"Tag List", 1);
    }

    public partial class FirmaPageTypeSpendingByPerformanceMeasureByProject : FirmaPageType
    {
        private FirmaPageTypeSpendingByPerformanceMeasureByProject(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeSpendingByPerformanceMeasureByProject Instance = new FirmaPageTypeSpendingByPerformanceMeasureByProject(37, @"SpendingByPerformanceMeasureByProject", @"Spending by Performance Measure by Project", 1);
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