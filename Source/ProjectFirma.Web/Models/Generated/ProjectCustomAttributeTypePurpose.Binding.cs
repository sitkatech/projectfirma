//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeTypePurpose]
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
    public abstract partial class ProjectCustomAttributeTypePurpose : IHavePrimaryKey
    {
        public static readonly ProjectCustomAttributeTypePurposePerformanceAndModelingAttributes PerformanceAndModelingAttributes = ProjectCustomAttributeTypePurposePerformanceAndModelingAttributes.Instance;
        public static readonly ProjectCustomAttributeTypePurposeOtherDesignAttributes OtherDesignAttributes = ProjectCustomAttributeTypePurposeOtherDesignAttributes.Instance;
        public static readonly ProjectCustomAttributeTypePurposeMaintenance Maintenance = ProjectCustomAttributeTypePurposeMaintenance.Instance;

        public static readonly List<ProjectCustomAttributeTypePurpose> All;
        public static readonly ReadOnlyDictionary<int, ProjectCustomAttributeTypePurpose> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCustomAttributeTypePurpose()
        {
            All = new List<ProjectCustomAttributeTypePurpose> { PerformanceAndModelingAttributes, OtherDesignAttributes, Maintenance };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCustomAttributeTypePurpose>(All.ToDictionary(x => x.ProjectCustomAttributeTypePurposeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCustomAttributeTypePurpose(int projectCustomAttributeTypePurposeID, string projectCustomAttributeTypePurposeName, string projectCustomAttributeTypePurposeDisplayName)
        {
            ProjectCustomAttributeTypePurposeID = projectCustomAttributeTypePurposeID;
            ProjectCustomAttributeTypePurposeName = projectCustomAttributeTypePurposeName;
            ProjectCustomAttributeTypePurposeDisplayName = projectCustomAttributeTypePurposeDisplayName;
        }

        [Key]
        public int ProjectCustomAttributeTypePurposeID { get; private set; }
        public string ProjectCustomAttributeTypePurposeName { get; private set; }
        public string ProjectCustomAttributeTypePurposeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeTypePurposeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCustomAttributeTypePurpose other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCustomAttributeTypePurposeID == ProjectCustomAttributeTypePurposeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCustomAttributeTypePurpose);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCustomAttributeTypePurposeID;
        }

        public static bool operator ==(ProjectCustomAttributeTypePurpose left, ProjectCustomAttributeTypePurpose right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCustomAttributeTypePurpose left, ProjectCustomAttributeTypePurpose right)
        {
            return !Equals(left, right);
        }

        public ProjectCustomAttributeTypePurposeEnum ToEnum { get { return (ProjectCustomAttributeTypePurposeEnum)GetHashCode(); } }

        public static ProjectCustomAttributeTypePurpose ToType(int enumValue)
        {
            return ToType((ProjectCustomAttributeTypePurposeEnum)enumValue);
        }

        public static ProjectCustomAttributeTypePurpose ToType(ProjectCustomAttributeTypePurposeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCustomAttributeTypePurposeEnum.Maintenance:
                    return Maintenance;
                case ProjectCustomAttributeTypePurposeEnum.OtherDesignAttributes:
                    return OtherDesignAttributes;
                case ProjectCustomAttributeTypePurposeEnum.PerformanceAndModelingAttributes:
                    return PerformanceAndModelingAttributes;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCustomAttributeTypePurposeEnum
    {
        PerformanceAndModelingAttributes = 1,
        OtherDesignAttributes = 2,
        Maintenance = 3
    }

    public partial class ProjectCustomAttributeTypePurposePerformanceAndModelingAttributes : ProjectCustomAttributeTypePurpose
    {
        private ProjectCustomAttributeTypePurposePerformanceAndModelingAttributes(int projectCustomAttributeTypePurposeID, string projectCustomAttributeTypePurposeName, string projectCustomAttributeTypePurposeDisplayName) : base(projectCustomAttributeTypePurposeID, projectCustomAttributeTypePurposeName, projectCustomAttributeTypePurposeDisplayName) {}
        public static readonly ProjectCustomAttributeTypePurposePerformanceAndModelingAttributes Instance = new ProjectCustomAttributeTypePurposePerformanceAndModelingAttributes(1, @"PerformanceAndModelingAttributes", @"Performance / Modeling Attributes");
    }

    public partial class ProjectCustomAttributeTypePurposeOtherDesignAttributes : ProjectCustomAttributeTypePurpose
    {
        private ProjectCustomAttributeTypePurposeOtherDesignAttributes(int projectCustomAttributeTypePurposeID, string projectCustomAttributeTypePurposeName, string projectCustomAttributeTypePurposeDisplayName) : base(projectCustomAttributeTypePurposeID, projectCustomAttributeTypePurposeName, projectCustomAttributeTypePurposeDisplayName) {}
        public static readonly ProjectCustomAttributeTypePurposeOtherDesignAttributes Instance = new ProjectCustomAttributeTypePurposeOtherDesignAttributes(2, @"OtherDesignAttributes", @"Other Design Attributes");
    }

    public partial class ProjectCustomAttributeTypePurposeMaintenance : ProjectCustomAttributeTypePurpose
    {
        private ProjectCustomAttributeTypePurposeMaintenance(int projectCustomAttributeTypePurposeID, string projectCustomAttributeTypePurposeName, string projectCustomAttributeTypePurposeDisplayName) : base(projectCustomAttributeTypePurposeID, projectCustomAttributeTypePurposeName, projectCustomAttributeTypePurposeDisplayName) {}
        public static readonly ProjectCustomAttributeTypePurposeMaintenance Instance = new ProjectCustomAttributeTypePurposeMaintenance(3, @"Maintenance", @"Maintenance Attributes");
    }
}