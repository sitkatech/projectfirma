//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeTypeRolePermissionType]
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
    public abstract partial class ProjectCustomAttributeTypeRolePermissionType : IHavePrimaryKey
    {
        public static readonly ProjectCustomAttributeTypeRolePermissionTypeEdit Edit = ProjectCustomAttributeTypeRolePermissionTypeEdit.Instance;
        public static readonly ProjectCustomAttributeTypeRolePermissionTypeView View = ProjectCustomAttributeTypeRolePermissionTypeView.Instance;

        public static readonly List<ProjectCustomAttributeTypeRolePermissionType> All;
        public static readonly ReadOnlyDictionary<int, ProjectCustomAttributeTypeRolePermissionType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCustomAttributeTypeRolePermissionType()
        {
            All = new List<ProjectCustomAttributeTypeRolePermissionType> { Edit, View };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCustomAttributeTypeRolePermissionType>(All.ToDictionary(x => x.ProjectCustomAttributeTypeRolePermissionTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCustomAttributeTypeRolePermissionType(int projectCustomAttributeTypeRolePermissionTypeID, string projectCustomAttributeTypeRolePermissionTypeName)
        {
            ProjectCustomAttributeTypeRolePermissionTypeID = projectCustomAttributeTypeRolePermissionTypeID;
            ProjectCustomAttributeTypeRolePermissionTypeName = projectCustomAttributeTypeRolePermissionTypeName;
        }

        [Key]
        public int ProjectCustomAttributeTypeRolePermissionTypeID { get; private set; }
        public string ProjectCustomAttributeTypeRolePermissionTypeName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeTypeRolePermissionTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCustomAttributeTypeRolePermissionType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCustomAttributeTypeRolePermissionTypeID == ProjectCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCustomAttributeTypeRolePermissionType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCustomAttributeTypeRolePermissionTypeID;
        }

        public static bool operator ==(ProjectCustomAttributeTypeRolePermissionType left, ProjectCustomAttributeTypeRolePermissionType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCustomAttributeTypeRolePermissionType left, ProjectCustomAttributeTypeRolePermissionType right)
        {
            return !Equals(left, right);
        }

        public ProjectCustomAttributeTypeRolePermissionTypeEnum ToEnum { get { return (ProjectCustomAttributeTypeRolePermissionTypeEnum)GetHashCode(); } }

        public static ProjectCustomAttributeTypeRolePermissionType ToType(int enumValue)
        {
            return ToType((ProjectCustomAttributeTypeRolePermissionTypeEnum)enumValue);
        }

        public static ProjectCustomAttributeTypeRolePermissionType ToType(ProjectCustomAttributeTypeRolePermissionTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCustomAttributeTypeRolePermissionTypeEnum.Edit:
                    return Edit;
                case ProjectCustomAttributeTypeRolePermissionTypeEnum.View:
                    return View;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCustomAttributeTypeRolePermissionTypeEnum
    {
        Edit = 1,
        View = 2
    }

    public partial class ProjectCustomAttributeTypeRolePermissionTypeEdit : ProjectCustomAttributeTypeRolePermissionType
    {
        private ProjectCustomAttributeTypeRolePermissionTypeEdit(int projectCustomAttributeTypeRolePermissionTypeID, string projectCustomAttributeTypeRolePermissionTypeName) : base(projectCustomAttributeTypeRolePermissionTypeID, projectCustomAttributeTypeRolePermissionTypeName) {}
        public static readonly ProjectCustomAttributeTypeRolePermissionTypeEdit Instance = new ProjectCustomAttributeTypeRolePermissionTypeEdit(1, @"Edit");
    }

    public partial class ProjectCustomAttributeTypeRolePermissionTypeView : ProjectCustomAttributeTypeRolePermissionType
    {
        private ProjectCustomAttributeTypeRolePermissionTypeView(int projectCustomAttributeTypeRolePermissionTypeID, string projectCustomAttributeTypeRolePermissionTypeName) : base(projectCustomAttributeTypeRolePermissionTypeID, projectCustomAttributeTypeRolePermissionTypeName) {}
        public static readonly ProjectCustomAttributeTypeRolePermissionTypeView Instance = new ProjectCustomAttributeTypeRolePermissionTypeView(2, @"View");
    }
}