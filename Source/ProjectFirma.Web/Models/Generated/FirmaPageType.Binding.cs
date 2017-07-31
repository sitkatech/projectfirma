//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageType]
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
    public abstract partial class FirmaPageType : IHavePrimaryKey
    {
        public static readonly FirmaPageTypeHomePage HomePage = FirmaPageTypeHomePage.Instance;
        public static readonly FirmaPageTypeAbout About = FirmaPageTypeAbout.Instance;
        public static readonly FirmaPageTypeMeetingsandDocuments MeetingsandDocuments = FirmaPageTypeMeetingsandDocuments.Instance;
        public static readonly FirmaPageTypeDemoScript DemoScript = FirmaPageTypeDemoScript.Instance;
        public static readonly FirmaPageTypeInternalSetupNotes InternalSetupNotes = FirmaPageTypeInternalSetupNotes.Instance;
        public static readonly FirmaPageTypeFullProjectList FullProjectList = FirmaPageTypeFullProjectList.Instance;
        public static readonly FirmaPageTypePerformanceMeasuresList PerformanceMeasuresList = FirmaPageTypePerformanceMeasuresList.Instance;
        public static readonly FirmaPageTypeTaxonomyTierOneList TaxonomyTierOneList = FirmaPageTypeTaxonomyTierOneList.Instance;
        public static readonly FirmaPageTypeTaxonomyTierTwoList TaxonomyTierTwoList = FirmaPageTypeTaxonomyTierTwoList.Instance;
        public static readonly FirmaPageTypeTaxonomyTierThreeList TaxonomyTierThreeList = FirmaPageTypeTaxonomyTierThreeList.Instance;
        public static readonly FirmaPageTypeFundingSourcesList FundingSourcesList = FirmaPageTypeFundingSourcesList.Instance;
        public static readonly FirmaPageTypeOrganizationsList OrganizationsList = FirmaPageTypeOrganizationsList.Instance;
        public static readonly FirmaPageTypeWatershedsList WatershedsList = FirmaPageTypeWatershedsList.Instance;
        public static readonly FirmaPageTypeMyProjects MyProjects = FirmaPageTypeMyProjects.Instance;
        public static readonly FirmaPageTypeInvestmentByOrganizationType InvestmentByOrganizationType = FirmaPageTypeInvestmentByOrganizationType.Instance;
        public static readonly FirmaPageTypeSpendingByOrganizationTypeByTaxonomyTier SpendingByOrganizationTypeByTaxonomyTier = FirmaPageTypeSpendingByOrganizationTypeByTaxonomyTier.Instance;
        public static readonly FirmaPageTypeProjectMap ProjectMap = FirmaPageTypeProjectMap.Instance;
        public static readonly FirmaPageTypeResultsByTaxonomyTierTwo ResultsByTaxonomyTierTwo = FirmaPageTypeResultsByTaxonomyTierTwo.Instance;
        public static readonly FirmaPageTypeHomeMapInfo HomeMapInfo = FirmaPageTypeHomeMapInfo.Instance;
        public static readonly FirmaPageTypeHomeAdditionalInfo HomeAdditionalInfo = FirmaPageTypeHomeAdditionalInfo.Instance;
        public static readonly FirmaPageTypeFeaturedProjectList FeaturedProjectList = FirmaPageTypeFeaturedProjectList.Instance;
        public static readonly FirmaPageTypeCostParameterSet CostParameterSet = FirmaPageTypeCostParameterSet.Instance;
        public static readonly FirmaPageTypeFullProjectListSimple FullProjectListSimple = FirmaPageTypeFullProjectListSimple.Instance;
        public static readonly FirmaPageTypeTaxonomy Taxonomy = FirmaPageTypeTaxonomy.Instance;
        public static readonly FirmaPageTypeTagList TagList = FirmaPageTypeTagList.Instance;
        public static readonly FirmaPageTypeSpendingByPerformanceMeasureByProject SpendingByPerformanceMeasureByProject = FirmaPageTypeSpendingByPerformanceMeasureByProject.Instance;
        public static readonly FirmaPageTypeProposedProjects ProposedProjects = FirmaPageTypeProposedProjects.Instance;
        public static readonly FirmaPageTypeMyOrganizationsProjects MyOrganizationsProjects = FirmaPageTypeMyOrganizationsProjects.Instance;
        public static readonly FirmaPageTypeManageUpdateNotifications ManageUpdateNotifications = FirmaPageTypeManageUpdateNotifications.Instance;
        public static readonly FirmaPageTypeProjectUpdateStatus ProjectUpdateStatus = FirmaPageTypeProjectUpdateStatus.Instance;
        public static readonly FirmaPageTypeClassificationsList ClassificationsList = FirmaPageTypeClassificationsList.Instance;
        public static readonly FirmaPageTypeMonitoringProgramsList MonitoringProgramsList = FirmaPageTypeMonitoringProgramsList.Instance;
        public static readonly FirmaPageTypeProposeProjectInstructions ProposeProjectInstructions = FirmaPageTypeProposeProjectInstructions.Instance;

        public static readonly List<FirmaPageType> All;
        public static readonly ReadOnlyDictionary<int, FirmaPageType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FirmaPageType()
        {
            All = new List<FirmaPageType> { HomePage, About, MeetingsandDocuments, DemoScript, InternalSetupNotes, FullProjectList, PerformanceMeasuresList, TaxonomyTierOneList, TaxonomyTierTwoList, TaxonomyTierThreeList, FundingSourcesList, OrganizationsList, WatershedsList, MyProjects, InvestmentByOrganizationType, SpendingByOrganizationTypeByTaxonomyTier, ProjectMap, ResultsByTaxonomyTierTwo, HomeMapInfo, HomeAdditionalInfo, FeaturedProjectList, CostParameterSet, FullProjectListSimple, Taxonomy, TagList, SpendingByPerformanceMeasureByProject, ProposedProjects, MyOrganizationsProjects, ManageUpdateNotifications, ProjectUpdateStatus, ClassificationsList, MonitoringProgramsList, ProposeProjectInstructions };
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
                case FirmaPageTypeEnum.ClassificationsList:
                    return ClassificationsList;
                case FirmaPageTypeEnum.CostParameterSet:
                    return CostParameterSet;
                case FirmaPageTypeEnum.DemoScript:
                    return DemoScript;
                case FirmaPageTypeEnum.FeaturedProjectList:
                    return FeaturedProjectList;
                case FirmaPageTypeEnum.FullProjectList:
                    return FullProjectList;
                case FirmaPageTypeEnum.FullProjectListSimple:
                    return FullProjectListSimple;
                case FirmaPageTypeEnum.FundingSourcesList:
                    return FundingSourcesList;
                case FirmaPageTypeEnum.HomeAdditionalInfo:
                    return HomeAdditionalInfo;
                case FirmaPageTypeEnum.HomeMapInfo:
                    return HomeMapInfo;
                case FirmaPageTypeEnum.HomePage:
                    return HomePage;
                case FirmaPageTypeEnum.InternalSetupNotes:
                    return InternalSetupNotes;
                case FirmaPageTypeEnum.InvestmentByOrganizationType:
                    return InvestmentByOrganizationType;
                case FirmaPageTypeEnum.ManageUpdateNotifications:
                    return ManageUpdateNotifications;
                case FirmaPageTypeEnum.MeetingsandDocuments:
                    return MeetingsandDocuments;
                case FirmaPageTypeEnum.MonitoringProgramsList:
                    return MonitoringProgramsList;
                case FirmaPageTypeEnum.MyOrganizationsProjects:
                    return MyOrganizationsProjects;
                case FirmaPageTypeEnum.MyProjects:
                    return MyProjects;
                case FirmaPageTypeEnum.OrganizationsList:
                    return OrganizationsList;
                case FirmaPageTypeEnum.PerformanceMeasuresList:
                    return PerformanceMeasuresList;
                case FirmaPageTypeEnum.ProjectMap:
                    return ProjectMap;
                case FirmaPageTypeEnum.ProjectUpdateStatus:
                    return ProjectUpdateStatus;
                case FirmaPageTypeEnum.ProposedProjects:
                    return ProposedProjects;
                case FirmaPageTypeEnum.ProposeProjectInstructions:
                    return ProposeProjectInstructions;
                case FirmaPageTypeEnum.ResultsByTaxonomyTierTwo:
                    return ResultsByTaxonomyTierTwo;
                case FirmaPageTypeEnum.SpendingByOrganizationTypeByTaxonomyTier:
                    return SpendingByOrganizationTypeByTaxonomyTier;
                case FirmaPageTypeEnum.SpendingByPerformanceMeasureByProject:
                    return SpendingByPerformanceMeasureByProject;
                case FirmaPageTypeEnum.TagList:
                    return TagList;
                case FirmaPageTypeEnum.Taxonomy:
                    return Taxonomy;
                case FirmaPageTypeEnum.TaxonomyTierOneList:
                    return TaxonomyTierOneList;
                case FirmaPageTypeEnum.TaxonomyTierThreeList:
                    return TaxonomyTierThreeList;
                case FirmaPageTypeEnum.TaxonomyTierTwoList:
                    return TaxonomyTierTwoList;
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
        MeetingsandDocuments = 3,
        DemoScript = 4,
        InternalSetupNotes = 5,
        FullProjectList = 6,
        PerformanceMeasuresList = 9,
        TaxonomyTierOneList = 11,
        TaxonomyTierTwoList = 13,
        TaxonomyTierThreeList = 14,
        FundingSourcesList = 15,
        OrganizationsList = 16,
        WatershedsList = 17,
        MyProjects = 18,
        InvestmentByOrganizationType = 20,
        SpendingByOrganizationTypeByTaxonomyTier = 21,
        ProjectMap = 22,
        ResultsByTaxonomyTierTwo = 23,
        HomeMapInfo = 24,
        HomeAdditionalInfo = 25,
        FeaturedProjectList = 26,
        CostParameterSet = 31,
        FullProjectListSimple = 33,
        Taxonomy = 34,
        TagList = 36,
        SpendingByPerformanceMeasureByProject = 37,
        ProposedProjects = 38,
        MyOrganizationsProjects = 39,
        ManageUpdateNotifications = 41,
        ProjectUpdateStatus = 42,
        ClassificationsList = 43,
        MonitoringProgramsList = 44,
        ProposeProjectInstructions = 45
    }

    public partial class FirmaPageTypeHomePage : FirmaPageType
    {
        private FirmaPageTypeHomePage(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeHomePage Instance = new FirmaPageTypeHomePage(1, @"HomePage", @"Home Page", 2);
    }

    public partial class FirmaPageTypeAbout : FirmaPageType
    {
        private FirmaPageTypeAbout(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeAbout Instance = new FirmaPageTypeAbout(2, @"About", @"About", 2);
    }

    public partial class FirmaPageTypeMeetingsandDocuments : FirmaPageType
    {
        private FirmaPageTypeMeetingsandDocuments(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeMeetingsandDocuments Instance = new FirmaPageTypeMeetingsandDocuments(3, @"Meetings and Documents", @"Meetings and Documents", 2);
    }

    public partial class FirmaPageTypeDemoScript : FirmaPageType
    {
        private FirmaPageTypeDemoScript(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeDemoScript Instance = new FirmaPageTypeDemoScript(4, @"DemoScript", @"Demo Script", 2);
    }

    public partial class FirmaPageTypeInternalSetupNotes : FirmaPageType
    {
        private FirmaPageTypeInternalSetupNotes(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeInternalSetupNotes Instance = new FirmaPageTypeInternalSetupNotes(5, @"InternalSetupNotes", @"Internal Setup Notes", 2);
    }

    public partial class FirmaPageTypeFullProjectList : FirmaPageType
    {
        private FirmaPageTypeFullProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullProjectList Instance = new FirmaPageTypeFullProjectList(6, @"FullProjectList", @"Full Project List", 1);
    }

    public partial class FirmaPageTypePerformanceMeasuresList : FirmaPageType
    {
        private FirmaPageTypePerformanceMeasuresList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypePerformanceMeasuresList Instance = new FirmaPageTypePerformanceMeasuresList(9, @"PerformanceMeasuresList", @"Performance Measures List", 1);
    }

    public partial class FirmaPageTypeTaxonomyTierOneList : FirmaPageType
    {
        private FirmaPageTypeTaxonomyTierOneList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTaxonomyTierOneList Instance = new FirmaPageTypeTaxonomyTierOneList(11, @"TaxonomyTierOneList", @"Taxonomy Tier One List", 1);
    }

    public partial class FirmaPageTypeTaxonomyTierTwoList : FirmaPageType
    {
        private FirmaPageTypeTaxonomyTierTwoList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTaxonomyTierTwoList Instance = new FirmaPageTypeTaxonomyTierTwoList(13, @"TaxonomyTierTwoList", @"Taxonomy Tier Two List", 1);
    }

    public partial class FirmaPageTypeTaxonomyTierThreeList : FirmaPageType
    {
        private FirmaPageTypeTaxonomyTierThreeList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTaxonomyTierThreeList Instance = new FirmaPageTypeTaxonomyTierThreeList(14, @"TaxonomyTierThreeList", @"Taxonomy Tier Three List", 1);
    }

    public partial class FirmaPageTypeFundingSourcesList : FirmaPageType
    {
        private FirmaPageTypeFundingSourcesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFundingSourcesList Instance = new FirmaPageTypeFundingSourcesList(15, @"FundingSourcesList", @"Funding Sources List", 1);
    }

    public partial class FirmaPageTypeOrganizationsList : FirmaPageType
    {
        private FirmaPageTypeOrganizationsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeOrganizationsList Instance = new FirmaPageTypeOrganizationsList(16, @"OrganizationsList", @"Organizations List", 1);
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

    public partial class FirmaPageTypeInvestmentByOrganizationType : FirmaPageType
    {
        private FirmaPageTypeInvestmentByOrganizationType(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeInvestmentByOrganizationType Instance = new FirmaPageTypeInvestmentByOrganizationType(20, @"InvestmentByOrganizationType", @"Investment by Organization Type", 1);
    }

    public partial class FirmaPageTypeSpendingByOrganizationTypeByTaxonomyTier : FirmaPageType
    {
        private FirmaPageTypeSpendingByOrganizationTypeByTaxonomyTier(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeSpendingByOrganizationTypeByTaxonomyTier Instance = new FirmaPageTypeSpendingByOrganizationTypeByTaxonomyTier(21, @"SpendingByOrganizationTypeByTaxonomyTier", @"Spending by Organization Type by Taxonomy Tier", 1);
    }

    public partial class FirmaPageTypeProjectMap : FirmaPageType
    {
        private FirmaPageTypeProjectMap(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProjectMap Instance = new FirmaPageTypeProjectMap(22, @"ProjectMap", @"Project Map", 1);
    }

    public partial class FirmaPageTypeResultsByTaxonomyTierTwo : FirmaPageType
    {
        private FirmaPageTypeResultsByTaxonomyTierTwo(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeResultsByTaxonomyTierTwo Instance = new FirmaPageTypeResultsByTaxonomyTierTwo(23, @"ResultsByTaxonomyTierTwo", @"Results by Taxonomy Tier Two", 1);
    }

    public partial class FirmaPageTypeHomeMapInfo : FirmaPageType
    {
        private FirmaPageTypeHomeMapInfo(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeHomeMapInfo Instance = new FirmaPageTypeHomeMapInfo(24, @"HomeMapInfo", @"Home Page Map Info", 2);
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

    public partial class FirmaPageTypeClassificationsList : FirmaPageType
    {
        private FirmaPageTypeClassificationsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeClassificationsList Instance = new FirmaPageTypeClassificationsList(43, @"ClassificationsList", @"Classifications List", 1);
    }

    public partial class FirmaPageTypeMonitoringProgramsList : FirmaPageType
    {
        private FirmaPageTypeMonitoringProgramsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeMonitoringProgramsList Instance = new FirmaPageTypeMonitoringProgramsList(44, @"MonitoringProgramsList", @"Monitoring Programs", 1);
    }

    public partial class FirmaPageTypeProposeProjectInstructions : FirmaPageType
    {
        private FirmaPageTypeProposeProjectInstructions(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProposeProjectInstructions Instance = new FirmaPageTypeProposeProjectInstructions(45, @"ProposeProjectInstructions", @"Propose Project Instructions", 2);
    }
}