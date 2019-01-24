//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCostType]
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
    public abstract partial class ProjectCostType : IHavePrimaryKey
    {
        public static readonly ProjectCostTypePreliminaryEngineering PreliminaryEngineering = ProjectCostTypePreliminaryEngineering.Instance;
        public static readonly ProjectCostTypeRightOfWay RightOfWay = ProjectCostTypeRightOfWay.Instance;
        public static readonly ProjectCostTypeConstruction Construction = ProjectCostTypeConstruction.Instance;

        public static readonly List<ProjectCostType> All;
        public static readonly ReadOnlyDictionary<int, ProjectCostType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCostType()
        {
            All = new List<ProjectCostType> { PreliminaryEngineering, RightOfWay, Construction };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCostType>(All.ToDictionary(x => x.ProjectCostTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCostType(int projectCostTypeID, string projectCostTypeName, string projectCostTypeDisplayName, int sortOrder)
        {
            ProjectCostTypeID = projectCostTypeID;
            ProjectCostTypeName = projectCostTypeName;
            ProjectCostTypeDisplayName = projectCostTypeDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int ProjectCostTypeID { get; private set; }
        public string ProjectCostTypeName { get; private set; }
        public string ProjectCostTypeDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCostTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCostType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCostTypeID == ProjectCostTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCostType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCostTypeID;
        }

        public static bool operator ==(ProjectCostType left, ProjectCostType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCostType left, ProjectCostType right)
        {
            return !Equals(left, right);
        }

        public ProjectCostTypeEnum ToEnum { get { return (ProjectCostTypeEnum)GetHashCode(); } }

        public static ProjectCostType ToType(int enumValue)
        {
            return ToType((ProjectCostTypeEnum)enumValue);
        }

        public static ProjectCostType ToType(ProjectCostTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCostTypeEnum.Construction:
                    return Construction;
                case ProjectCostTypeEnum.PreliminaryEngineering:
                    return PreliminaryEngineering;
                case ProjectCostTypeEnum.RightOfWay:
                    return RightOfWay;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCostTypeEnum
    {
        PreliminaryEngineering = 1,
        RightOfWay = 2,
        Construction = 3
    }

    public partial class ProjectCostTypePreliminaryEngineering : ProjectCostType
    {
        private ProjectCostTypePreliminaryEngineering(int projectCostTypeID, string projectCostTypeName, string projectCostTypeDisplayName, int sortOrder) : base(projectCostTypeID, projectCostTypeName, projectCostTypeDisplayName, sortOrder) {}
        public static readonly ProjectCostTypePreliminaryEngineering Instance = new ProjectCostTypePreliminaryEngineering(1, @"PreliminaryEngineering", @"Preliminary Engineering", 10);
    }

    public partial class ProjectCostTypeRightOfWay : ProjectCostType
    {
        private ProjectCostTypeRightOfWay(int projectCostTypeID, string projectCostTypeName, string projectCostTypeDisplayName, int sortOrder) : base(projectCostTypeID, projectCostTypeName, projectCostTypeDisplayName, sortOrder) {}
        public static readonly ProjectCostTypeRightOfWay Instance = new ProjectCostTypeRightOfWay(2, @"RightOfWay", @"Right of Way (aka Land Acquisition)", 20);
    }

    public partial class ProjectCostTypeConstruction : ProjectCostType
    {
        private ProjectCostTypeConstruction(int projectCostTypeID, string projectCostTypeName, string projectCostTypeDisplayName, int sortOrder) : base(projectCostTypeID, projectCostTypeName, projectCostTypeDisplayName, sortOrder) {}
        public static readonly ProjectCostTypeConstruction Instance = new ProjectCostTypeConstruction(3, @"Construction", @"Construction", 30);
    }
}