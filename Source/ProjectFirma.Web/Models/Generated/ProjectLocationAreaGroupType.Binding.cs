//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaGroupType]
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
    public abstract partial class ProjectLocationAreaGroupType : IHavePrimaryKey
    {
        public static readonly ProjectLocationAreaGroupTypeMappedRegion MappedRegion = ProjectLocationAreaGroupTypeMappedRegion.Instance;
        public static readonly ProjectLocationAreaGroupTypeState State = ProjectLocationAreaGroupTypeState.Instance;
        public static readonly ProjectLocationAreaGroupTypeJurisdiction Jurisdiction = ProjectLocationAreaGroupTypeJurisdiction.Instance;
        public static readonly ProjectLocationAreaGroupTypeWatershed Watershed = ProjectLocationAreaGroupTypeWatershed.Instance;

        public static readonly List<ProjectLocationAreaGroupType> All;
        public static readonly ReadOnlyDictionary<int, ProjectLocationAreaGroupType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectLocationAreaGroupType()
        {
            All = new List<ProjectLocationAreaGroupType> { MappedRegion, State, Jurisdiction, Watershed };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectLocationAreaGroupType>(All.ToDictionary(x => x.ProjectLocationAreaGroupTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectLocationAreaGroupType(int projectLocationAreaGroupTypeID, string projectLocationAreaGroupTypeName, string projectLocationAreaGroupTypeDisplayName, int displayOrder)
        {
            ProjectLocationAreaGroupTypeID = projectLocationAreaGroupTypeID;
            ProjectLocationAreaGroupTypeName = projectLocationAreaGroupTypeName;
            ProjectLocationAreaGroupTypeDisplayName = projectLocationAreaGroupTypeDisplayName;
            DisplayOrder = displayOrder;
        }

        [Key]
        public int ProjectLocationAreaGroupTypeID { get; private set; }
        public string ProjectLocationAreaGroupTypeName { get; private set; }
        public string ProjectLocationAreaGroupTypeDisplayName { get; private set; }
        public int DisplayOrder { get; private set; }
        public int PrimaryKey { get { return ProjectLocationAreaGroupTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectLocationAreaGroupType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectLocationAreaGroupTypeID == ProjectLocationAreaGroupTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectLocationAreaGroupType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectLocationAreaGroupTypeID;
        }

        public static bool operator ==(ProjectLocationAreaGroupType left, ProjectLocationAreaGroupType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectLocationAreaGroupType left, ProjectLocationAreaGroupType right)
        {
            return !Equals(left, right);
        }

        public ProjectLocationAreaGroupTypeEnum ToEnum { get { return (ProjectLocationAreaGroupTypeEnum)GetHashCode(); } }

        public static ProjectLocationAreaGroupType ToType(int enumValue)
        {
            return ToType((ProjectLocationAreaGroupTypeEnum)enumValue);
        }

        public static ProjectLocationAreaGroupType ToType(ProjectLocationAreaGroupTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectLocationAreaGroupTypeEnum.Jurisdiction:
                    return Jurisdiction;
                case ProjectLocationAreaGroupTypeEnum.MappedRegion:
                    return MappedRegion;
                case ProjectLocationAreaGroupTypeEnum.State:
                    return State;
                case ProjectLocationAreaGroupTypeEnum.Watershed:
                    return Watershed;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectLocationAreaGroupTypeEnum
    {
        MappedRegion = 1,
        State = 2,
        Jurisdiction = 3,
        Watershed = 4
    }

    public partial class ProjectLocationAreaGroupTypeMappedRegion : ProjectLocationAreaGroupType
    {
        private ProjectLocationAreaGroupTypeMappedRegion(int projectLocationAreaGroupTypeID, string projectLocationAreaGroupTypeName, string projectLocationAreaGroupTypeDisplayName, int displayOrder) : base(projectLocationAreaGroupTypeID, projectLocationAreaGroupTypeName, projectLocationAreaGroupTypeDisplayName, displayOrder) {}
        public static readonly ProjectLocationAreaGroupTypeMappedRegion Instance = new ProjectLocationAreaGroupTypeMappedRegion(1, @"MappedRegion", @"Region", 1);
    }

    public partial class ProjectLocationAreaGroupTypeState : ProjectLocationAreaGroupType
    {
        private ProjectLocationAreaGroupTypeState(int projectLocationAreaGroupTypeID, string projectLocationAreaGroupTypeName, string projectLocationAreaGroupTypeDisplayName, int displayOrder) : base(projectLocationAreaGroupTypeID, projectLocationAreaGroupTypeName, projectLocationAreaGroupTypeDisplayName, displayOrder) {}
        public static readonly ProjectLocationAreaGroupTypeState Instance = new ProjectLocationAreaGroupTypeState(2, @"State", @"State", 2);
    }

    public partial class ProjectLocationAreaGroupTypeJurisdiction : ProjectLocationAreaGroupType
    {
        private ProjectLocationAreaGroupTypeJurisdiction(int projectLocationAreaGroupTypeID, string projectLocationAreaGroupTypeName, string projectLocationAreaGroupTypeDisplayName, int displayOrder) : base(projectLocationAreaGroupTypeID, projectLocationAreaGroupTypeName, projectLocationAreaGroupTypeDisplayName, displayOrder) {}
        public static readonly ProjectLocationAreaGroupTypeJurisdiction Instance = new ProjectLocationAreaGroupTypeJurisdiction(3, @"Jurisdiction", @"Jurisdiction", 3);
    }

    public partial class ProjectLocationAreaGroupTypeWatershed : ProjectLocationAreaGroupType
    {
        private ProjectLocationAreaGroupTypeWatershed(int projectLocationAreaGroupTypeID, string projectLocationAreaGroupTypeName, string projectLocationAreaGroupTypeDisplayName, int displayOrder) : base(projectLocationAreaGroupTypeID, projectLocationAreaGroupTypeName, projectLocationAreaGroupTypeDisplayName, displayOrder) {}
        public static readonly ProjectLocationAreaGroupTypeWatershed Instance = new ProjectLocationAreaGroupTypeWatershed(4, @"Watershed", @"Watershed", 4);
    }
}