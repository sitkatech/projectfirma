//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationFilterType]
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
    public abstract partial class ProjectLocationFilterType : IHavePrimaryKey
    {
        public static readonly ProjectLocationFilterTypeTaxonomyTierThree TaxonomyTierThree = ProjectLocationFilterTypeTaxonomyTierThree.Instance;
        public static readonly ProjectLocationFilterTypeTaxonomyTierTwo TaxonomyTierTwo = ProjectLocationFilterTypeTaxonomyTierTwo.Instance;
        public static readonly ProjectLocationFilterTypeTaxonomyTierOne TaxonomyTierOne = ProjectLocationFilterTypeTaxonomyTierOne.Instance;
        public static readonly ProjectLocationFilterTypeThresholdCategory ThresholdCategory = ProjectLocationFilterTypeThresholdCategory.Instance;
        public static readonly ProjectLocationFilterTypeProjectStage ProjectStage = ProjectLocationFilterTypeProjectStage.Instance;
        public static readonly ProjectLocationFilterTypeImplementingOrganization ImplementingOrganization = ProjectLocationFilterTypeImplementingOrganization.Instance;
        public static readonly ProjectLocationFilterTypeFundingOrganization FundingOrganization = ProjectLocationFilterTypeFundingOrganization.Instance;

        public static readonly List<ProjectLocationFilterType> All;
        public static readonly ReadOnlyDictionary<int, ProjectLocationFilterType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectLocationFilterType()
        {
            All = new List<ProjectLocationFilterType> { TaxonomyTierThree, TaxonomyTierTwo, TaxonomyTierOne, ThresholdCategory, ProjectStage, ImplementingOrganization, FundingOrganization };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectLocationFilterType>(All.ToDictionary(x => x.ProjectLocationFilterTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectLocationFilterType(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup)
        {
            ProjectLocationFilterTypeID = projectLocationFilterTypeID;
            ProjectLocationFilterTypeName = projectLocationFilterTypeName;
            ProjectLocationFilterTypeNameWithIdentifier = projectLocationFilterTypeNameWithIdentifier;
            ProjectLocationFilterTypeDisplayName = projectLocationFilterTypeDisplayName;
            SortOrder = sortOrder;
            DisplayGroup = displayGroup;
        }

        [Key]
        public int ProjectLocationFilterTypeID { get; private set; }
        public string ProjectLocationFilterTypeName { get; private set; }
        public string ProjectLocationFilterTypeNameWithIdentifier { get; private set; }
        public string ProjectLocationFilterTypeDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public int DisplayGroup { get; private set; }
        public int PrimaryKey { get { return ProjectLocationFilterTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectLocationFilterType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectLocationFilterTypeID == ProjectLocationFilterTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectLocationFilterType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectLocationFilterTypeID;
        }

        public static bool operator ==(ProjectLocationFilterType left, ProjectLocationFilterType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectLocationFilterType left, ProjectLocationFilterType right)
        {
            return !Equals(left, right);
        }

        public ProjectLocationFilterTypeEnum ToEnum { get { return (ProjectLocationFilterTypeEnum)GetHashCode(); } }

        public static ProjectLocationFilterType ToType(int enumValue)
        {
            return ToType((ProjectLocationFilterTypeEnum)enumValue);
        }

        public static ProjectLocationFilterType ToType(ProjectLocationFilterTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectLocationFilterTypeEnum.FundingOrganization:
                    return FundingOrganization;
                case ProjectLocationFilterTypeEnum.ImplementingOrganization:
                    return ImplementingOrganization;
                case ProjectLocationFilterTypeEnum.ProjectStage:
                    return ProjectStage;
                case ProjectLocationFilterTypeEnum.TaxonomyTierOne:
                    return TaxonomyTierOne;
                case ProjectLocationFilterTypeEnum.TaxonomyTierThree:
                    return TaxonomyTierThree;
                case ProjectLocationFilterTypeEnum.TaxonomyTierTwo:
                    return TaxonomyTierTwo;
                case ProjectLocationFilterTypeEnum.ThresholdCategory:
                    return ThresholdCategory;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectLocationFilterTypeEnum
    {
        TaxonomyTierThree = 1,
        TaxonomyTierTwo = 2,
        TaxonomyTierOne = 3,
        ThresholdCategory = 4,
        ProjectStage = 5,
        ImplementingOrganization = 6,
        FundingOrganization = 7
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierThree : ProjectLocationFilterType
    {
        private ProjectLocationFilterTypeTaxonomyTierThree(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup) : base(projectLocationFilterTypeID, projectLocationFilterTypeName, projectLocationFilterTypeNameWithIdentifier, projectLocationFilterTypeDisplayName, sortOrder, displayGroup) {}
        public static readonly ProjectLocationFilterTypeTaxonomyTierThree Instance = new ProjectLocationFilterTypeTaxonomyTierThree(1, @"TaxonomyTierThree", @"TaxonomyTierThreeID", @"Focus Area", 10, 1);
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierTwo : ProjectLocationFilterType
    {
        private ProjectLocationFilterTypeTaxonomyTierTwo(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup) : base(projectLocationFilterTypeID, projectLocationFilterTypeName, projectLocationFilterTypeNameWithIdentifier, projectLocationFilterTypeDisplayName, sortOrder, displayGroup) {}
        public static readonly ProjectLocationFilterTypeTaxonomyTierTwo Instance = new ProjectLocationFilterTypeTaxonomyTierTwo(2, @"TaxonomyTierTwo", @"TaxonomyTierTwoID", @"TaxonomyTierTwo", 20, 1);
    }

    public partial class ProjectLocationFilterTypeTaxonomyTierOne : ProjectLocationFilterType
    {
        private ProjectLocationFilterTypeTaxonomyTierOne(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup) : base(projectLocationFilterTypeID, projectLocationFilterTypeName, projectLocationFilterTypeNameWithIdentifier, projectLocationFilterTypeDisplayName, sortOrder, displayGroup) {}
        public static readonly ProjectLocationFilterTypeTaxonomyTierOne Instance = new ProjectLocationFilterTypeTaxonomyTierOne(3, @"TaxonomyTierOne", @"TaxonomyTierOneID", @"Action Priority", 30, 1);
    }

    public partial class ProjectLocationFilterTypeThresholdCategory : ProjectLocationFilterType
    {
        private ProjectLocationFilterTypeThresholdCategory(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup) : base(projectLocationFilterTypeID, projectLocationFilterTypeName, projectLocationFilterTypeNameWithIdentifier, projectLocationFilterTypeDisplayName, sortOrder, displayGroup) {}
        public static readonly ProjectLocationFilterTypeThresholdCategory Instance = new ProjectLocationFilterTypeThresholdCategory(4, @"ThresholdCategory", @"ThresholdCategoryID", @"Threshold Category", 40, 3);
    }

    public partial class ProjectLocationFilterTypeProjectStage : ProjectLocationFilterType
    {
        private ProjectLocationFilterTypeProjectStage(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup) : base(projectLocationFilterTypeID, projectLocationFilterTypeName, projectLocationFilterTypeNameWithIdentifier, projectLocationFilterTypeDisplayName, sortOrder, displayGroup) {}
        public static readonly ProjectLocationFilterTypeProjectStage Instance = new ProjectLocationFilterTypeProjectStage(5, @"ProjectStage", @"ProjectStageID", @"Project Stage", 50, 3);
    }

    public partial class ProjectLocationFilterTypeImplementingOrganization : ProjectLocationFilterType
    {
        private ProjectLocationFilterTypeImplementingOrganization(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup) : base(projectLocationFilterTypeID, projectLocationFilterTypeName, projectLocationFilterTypeNameWithIdentifier, projectLocationFilterTypeDisplayName, sortOrder, displayGroup) {}
        public static readonly ProjectLocationFilterTypeImplementingOrganization Instance = new ProjectLocationFilterTypeImplementingOrganization(6, @"ImplementingOrganization", @"ImplementingOrganizationID", @"Implementing Organization", 60, 4);
    }

    public partial class ProjectLocationFilterTypeFundingOrganization : ProjectLocationFilterType
    {
        private ProjectLocationFilterTypeFundingOrganization(int projectLocationFilterTypeID, string projectLocationFilterTypeName, string projectLocationFilterTypeNameWithIdentifier, string projectLocationFilterTypeDisplayName, int sortOrder, int displayGroup) : base(projectLocationFilterTypeID, projectLocationFilterTypeName, projectLocationFilterTypeNameWithIdentifier, projectLocationFilterTypeDisplayName, sortOrder, displayGroup) {}
        public static readonly ProjectLocationFilterTypeFundingOrganization Instance = new ProjectLocationFilterTypeFundingOrganization(7, @"FundingOrganization", @"FundingOrganizationID", @"Funding Organization", 70, 4);
    }
}