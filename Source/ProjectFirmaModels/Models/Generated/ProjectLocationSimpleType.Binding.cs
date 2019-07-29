//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationSimpleType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class ProjectLocationSimpleType : IHavePrimaryKey
    {
        public static readonly ProjectLocationSimpleTypePointOnMap PointOnMap = ProjectLocationSimpleTypePointOnMap.Instance;
        public static readonly ProjectLocationSimpleTypeLatLngInput LatLngInput = ProjectLocationSimpleTypeLatLngInput.Instance;
        public static readonly ProjectLocationSimpleTypeNone None = ProjectLocationSimpleTypeNone.Instance;

        public static readonly List<ProjectLocationSimpleType> All;
        public static readonly ReadOnlyDictionary<int, ProjectLocationSimpleType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectLocationSimpleType()
        {
            All = new List<ProjectLocationSimpleType> { PointOnMap, LatLngInput, None };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectLocationSimpleType>(All.ToDictionary(x => x.ProjectLocationSimpleTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectLocationSimpleType(int projectLocationSimpleTypeID, string projectLocationSimpleTypeName, string displayInstructions, int displayOrder)
        {
            ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            ProjectLocationSimpleTypeName = projectLocationSimpleTypeName;
            DisplayInstructions = displayInstructions;
            DisplayOrder = displayOrder;
        }

        [Key]
        public int ProjectLocationSimpleTypeID { get; private set; }
        public string ProjectLocationSimpleTypeName { get; private set; }
        public string DisplayInstructions { get; private set; }
        public int DisplayOrder { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectLocationSimpleTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectLocationSimpleType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectLocationSimpleTypeID == ProjectLocationSimpleTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectLocationSimpleType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectLocationSimpleTypeID;
        }

        public static bool operator ==(ProjectLocationSimpleType left, ProjectLocationSimpleType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectLocationSimpleType left, ProjectLocationSimpleType right)
        {
            return !Equals(left, right);
        }

        public ProjectLocationSimpleTypeEnum ToEnum { get { return (ProjectLocationSimpleTypeEnum)GetHashCode(); } }

        public static ProjectLocationSimpleType ToType(int enumValue)
        {
            return ToType((ProjectLocationSimpleTypeEnum)enumValue);
        }

        public static ProjectLocationSimpleType ToType(ProjectLocationSimpleTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectLocationSimpleTypeEnum.LatLngInput:
                    return LatLngInput;
                case ProjectLocationSimpleTypeEnum.None:
                    return None;
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                    return PointOnMap;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectLocationSimpleTypeEnum
    {
        PointOnMap = 1,
        LatLngInput = 2,
        None = 3
    }

    public partial class ProjectLocationSimpleTypePointOnMap : ProjectLocationSimpleType
    {
        private ProjectLocationSimpleTypePointOnMap(int projectLocationSimpleTypeID, string projectLocationSimpleTypeName, string displayInstructions, int displayOrder) : base(projectLocationSimpleTypeID, projectLocationSimpleTypeName, displayInstructions, displayOrder) {}
        public static readonly ProjectLocationSimpleTypePointOnMap Instance = new ProjectLocationSimpleTypePointOnMap(1, @"PointOnMap", @"Plot a point on the map", 1);
    }

    public partial class ProjectLocationSimpleTypeLatLngInput : ProjectLocationSimpleType
    {
        private ProjectLocationSimpleTypeLatLngInput(int projectLocationSimpleTypeID, string projectLocationSimpleTypeName, string displayInstructions, int displayOrder) : base(projectLocationSimpleTypeID, projectLocationSimpleTypeName, displayInstructions, displayOrder) {}
        public static readonly ProjectLocationSimpleTypeLatLngInput Instance = new ProjectLocationSimpleTypeLatLngInput(2, @"LatLngInput", @"Enter lat/lng coordinates (DD)", 2);
    }

    public partial class ProjectLocationSimpleTypeNone : ProjectLocationSimpleType
    {
        private ProjectLocationSimpleTypeNone(int projectLocationSimpleTypeID, string projectLocationSimpleTypeName, string displayInstructions, int displayOrder) : base(projectLocationSimpleTypeID, projectLocationSimpleTypeName, displayInstructions, displayOrder) {}
        public static readonly ProjectLocationSimpleTypeNone Instance = new ProjectLocationSimpleTypeNone(3, @"None", @"No location", 3);
    }
}