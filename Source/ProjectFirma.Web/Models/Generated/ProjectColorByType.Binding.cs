//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectColorByType]
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
    public abstract partial class ProjectColorByType : IHavePrimaryKey
    {
        public static readonly ProjectColorByTypeTaxonomyTrunk TaxonomyTrunk = ProjectColorByTypeTaxonomyTrunk.Instance;
        public static readonly ProjectColorByTypeProjectStage ProjectStage = ProjectColorByTypeProjectStage.Instance;
        public static readonly ProjectColorByTypeTaxonomyTierTwo TaxonomyTierTwo = ProjectColorByTypeTaxonomyTierTwo.Instance;

        public static readonly List<ProjectColorByType> All;
        public static readonly ReadOnlyDictionary<int, ProjectColorByType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectColorByType()
        {
            All = new List<ProjectColorByType> { TaxonomyTrunk, ProjectStage, TaxonomyTierTwo };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectColorByType>(All.ToDictionary(x => x.ProjectColorByTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectColorByType(int projectColorByTypeID, string projectColorByTypeName, string projectColorByTypeNameWithIdentifier, string projectColorByTypeDisplayName, int sortOrder)
        {
            ProjectColorByTypeID = projectColorByTypeID;
            ProjectColorByTypeName = projectColorByTypeName;
            ProjectColorByTypeNameWithIdentifier = projectColorByTypeNameWithIdentifier;
            ProjectColorByTypeDisplayName = projectColorByTypeDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int ProjectColorByTypeID { get; private set; }
        public string ProjectColorByTypeName { get; private set; }
        public string ProjectColorByTypeNameWithIdentifier { get; private set; }
        public string ProjectColorByTypeDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectColorByTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectColorByType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectColorByTypeID == ProjectColorByTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectColorByType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectColorByTypeID;
        }

        public static bool operator ==(ProjectColorByType left, ProjectColorByType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectColorByType left, ProjectColorByType right)
        {
            return !Equals(left, right);
        }

        public ProjectColorByTypeEnum ToEnum { get { return (ProjectColorByTypeEnum)GetHashCode(); } }

        public static ProjectColorByType ToType(int enumValue)
        {
            return ToType((ProjectColorByTypeEnum)enumValue);
        }

        public static ProjectColorByType ToType(ProjectColorByTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectColorByTypeEnum.ProjectStage:
                    return ProjectStage;
                case ProjectColorByTypeEnum.TaxonomyTierTwo:
                    return TaxonomyTierTwo;
                case ProjectColorByTypeEnum.TaxonomyTrunk:
                    return TaxonomyTrunk;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectColorByTypeEnum
    {
        TaxonomyTrunk = 1,
        ProjectStage = 2,
        TaxonomyTierTwo = 3
    }

    public partial class ProjectColorByTypeTaxonomyTrunk : ProjectColorByType
    {
        private ProjectColorByTypeTaxonomyTrunk(int projectColorByTypeID, string projectColorByTypeName, string projectColorByTypeNameWithIdentifier, string projectColorByTypeDisplayName, int sortOrder) : base(projectColorByTypeID, projectColorByTypeName, projectColorByTypeNameWithIdentifier, projectColorByTypeDisplayName, sortOrder) {}
        public static readonly ProjectColorByTypeTaxonomyTrunk Instance = new ProjectColorByTypeTaxonomyTrunk(1, @"TaxonomyTrunk", @"TaxonomyTrunkID", @"Taxonomy Trunk", 10);
    }

    public partial class ProjectColorByTypeProjectStage : ProjectColorByType
    {
        private ProjectColorByTypeProjectStage(int projectColorByTypeID, string projectColorByTypeName, string projectColorByTypeNameWithIdentifier, string projectColorByTypeDisplayName, int sortOrder) : base(projectColorByTypeID, projectColorByTypeName, projectColorByTypeNameWithIdentifier, projectColorByTypeDisplayName, sortOrder) {}
        public static readonly ProjectColorByTypeProjectStage Instance = new ProjectColorByTypeProjectStage(2, @"ProjectStage", @"ProjectStageID", @"Stage", 20);
    }

    public partial class ProjectColorByTypeTaxonomyTierTwo : ProjectColorByType
    {
        private ProjectColorByTypeTaxonomyTierTwo(int projectColorByTypeID, string projectColorByTypeName, string projectColorByTypeNameWithIdentifier, string projectColorByTypeDisplayName, int sortOrder) : base(projectColorByTypeID, projectColorByTypeName, projectColorByTypeNameWithIdentifier, projectColorByTypeDisplayName, sortOrder) {}
        public static readonly ProjectColorByTypeTaxonomyTierTwo Instance = new ProjectColorByTypeTaxonomyTierTwo(3, @"TaxonomyTierTwo", @"TaxonomyTierTwoID", @"Taxonomy Tier Two", 11);
    }
}