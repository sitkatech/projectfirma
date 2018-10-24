//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStewardshipAreaType]
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
    public abstract partial class ProjectStewardshipAreaType : IHavePrimaryKey
    {
        public static readonly ProjectStewardshipAreaTypeProjectStewardingOrganizations ProjectStewardingOrganizations = ProjectStewardshipAreaTypeProjectStewardingOrganizations.Instance;
        public static readonly ProjectStewardshipAreaTypeTaxonomyBranches TaxonomyBranches = ProjectStewardshipAreaTypeTaxonomyBranches.Instance;

        public static readonly List<ProjectStewardshipAreaType> All;
        public static readonly ReadOnlyDictionary<int, ProjectStewardshipAreaType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectStewardshipAreaType()
        {
            All = new List<ProjectStewardshipAreaType> { ProjectStewardingOrganizations, TaxonomyBranches };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectStewardshipAreaType>(All.ToDictionary(x => x.ProjectStewardshipAreaTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectStewardshipAreaType(int projectStewardshipAreaTypeID, string projectStewardshipAreaTypeName, string projectStewardshipAreaTypeDisplayName)
        {
            ProjectStewardshipAreaTypeID = projectStewardshipAreaTypeID;
            ProjectStewardshipAreaTypeName = projectStewardshipAreaTypeName;
            ProjectStewardshipAreaTypeDisplayName = projectStewardshipAreaTypeDisplayName;
        }

        [Key]
        public int ProjectStewardshipAreaTypeID { get; private set; }
        public string ProjectStewardshipAreaTypeName { get; private set; }
        public string ProjectStewardshipAreaTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectStewardshipAreaTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectStewardshipAreaType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectStewardshipAreaTypeID == ProjectStewardshipAreaTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectStewardshipAreaType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectStewardshipAreaTypeID;
        }

        public static bool operator ==(ProjectStewardshipAreaType left, ProjectStewardshipAreaType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectStewardshipAreaType left, ProjectStewardshipAreaType right)
        {
            return !Equals(left, right);
        }

        public ProjectStewardshipAreaTypeEnum ToEnum { get { return (ProjectStewardshipAreaTypeEnum)GetHashCode(); } }

        public static ProjectStewardshipAreaType ToType(int enumValue)
        {
            return ToType((ProjectStewardshipAreaTypeEnum)enumValue);
        }

        public static ProjectStewardshipAreaType ToType(ProjectStewardshipAreaTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectStewardshipAreaTypeEnum.ProjectStewardingOrganizations:
                    return ProjectStewardingOrganizations;
                case ProjectStewardshipAreaTypeEnum.TaxonomyBranches:
                    return TaxonomyBranches;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectStewardshipAreaTypeEnum
    {
        ProjectStewardingOrganizations = 1,
        TaxonomyBranches = 2
    }

    public partial class ProjectStewardshipAreaTypeProjectStewardingOrganizations : ProjectStewardshipAreaType
    {
        private ProjectStewardshipAreaTypeProjectStewardingOrganizations(int projectStewardshipAreaTypeID, string projectStewardshipAreaTypeName, string projectStewardshipAreaTypeDisplayName) : base(projectStewardshipAreaTypeID, projectStewardshipAreaTypeName, projectStewardshipAreaTypeDisplayName) {}
        public static readonly ProjectStewardshipAreaTypeProjectStewardingOrganizations Instance = new ProjectStewardshipAreaTypeProjectStewardingOrganizations(1, @"ProjectStewardingOrganizations", @"Project Stewarding Organizations");
    }

    public partial class ProjectStewardshipAreaTypeTaxonomyBranches : ProjectStewardshipAreaType
    {
        private ProjectStewardshipAreaTypeTaxonomyBranches(int projectStewardshipAreaTypeID, string projectStewardshipAreaTypeName, string projectStewardshipAreaTypeDisplayName) : base(projectStewardshipAreaTypeID, projectStewardshipAreaTypeName, projectStewardshipAreaTypeDisplayName) {}
        public static readonly ProjectStewardshipAreaTypeTaxonomyBranches Instance = new ProjectStewardshipAreaTypeTaxonomyBranches(2, @"TaxonomyBranches", @"Taxonomy Branches");
    }
}