//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeDataType]
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
    public abstract partial class ProjectCustomAttributeDataType : IHavePrimaryKey
    {
        public static readonly ProjectCustomAttributeDataTypeString String = ProjectCustomAttributeDataTypeString.Instance;
        public static readonly ProjectCustomAttributeDataTypeInteger Integer = ProjectCustomAttributeDataTypeInteger.Instance;
        public static readonly ProjectCustomAttributeDataTypeDecimal Decimal = ProjectCustomAttributeDataTypeDecimal.Instance;
        public static readonly ProjectCustomAttributeDataTypeDateTime DateTime = ProjectCustomAttributeDataTypeDateTime.Instance;
        public static readonly ProjectCustomAttributeDataTypePickFromList PickFromList = ProjectCustomAttributeDataTypePickFromList.Instance;
        public static readonly ProjectCustomAttributeDataTypeMultiSelect MultiSelect = ProjectCustomAttributeDataTypeMultiSelect.Instance;
        public static readonly ProjectCustomAttributeDataTypeBoolean Boolean = ProjectCustomAttributeDataTypeBoolean.Instance;
        public static readonly ProjectCustomAttributeDataTypeLongString LongString = ProjectCustomAttributeDataTypeLongString.Instance;

        public static readonly List<ProjectCustomAttributeDataType> All;
        public static readonly ReadOnlyDictionary<int, ProjectCustomAttributeDataType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCustomAttributeDataType()
        {
            All = new List<ProjectCustomAttributeDataType> { String, Integer, Decimal, DateTime, PickFromList, MultiSelect, Boolean, LongString };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCustomAttributeDataType>(All.ToDictionary(x => x.ProjectCustomAttributeDataTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCustomAttributeDataType(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName)
        {
            ProjectCustomAttributeDataTypeID = projectCustomAttributeDataTypeID;
            ProjectCustomAttributeDataTypeName = projectCustomAttributeDataTypeName;
            ProjectCustomAttributeDataTypeDisplayName = projectCustomAttributeDataTypeDisplayName;
        }

        [Key]
        public int ProjectCustomAttributeDataTypeID { get; private set; }
        public string ProjectCustomAttributeDataTypeName { get; private set; }
        public string ProjectCustomAttributeDataTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeDataTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCustomAttributeDataType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCustomAttributeDataTypeID == ProjectCustomAttributeDataTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCustomAttributeDataType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCustomAttributeDataTypeID;
        }

        public static bool operator ==(ProjectCustomAttributeDataType left, ProjectCustomAttributeDataType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCustomAttributeDataType left, ProjectCustomAttributeDataType right)
        {
            return !Equals(left, right);
        }

        public ProjectCustomAttributeDataTypeEnum ToEnum { get { return (ProjectCustomAttributeDataTypeEnum)GetHashCode(); } }

        public static ProjectCustomAttributeDataType ToType(int enumValue)
        {
            return ToType((ProjectCustomAttributeDataTypeEnum)enumValue);
        }

        public static ProjectCustomAttributeDataType ToType(ProjectCustomAttributeDataTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCustomAttributeDataTypeEnum.Boolean:
                    return Boolean;
                case ProjectCustomAttributeDataTypeEnum.DateTime:
                    return DateTime;
                case ProjectCustomAttributeDataTypeEnum.Decimal:
                    return Decimal;
                case ProjectCustomAttributeDataTypeEnum.Integer:
                    return Integer;
                case ProjectCustomAttributeDataTypeEnum.LongString:
                    return LongString;
                case ProjectCustomAttributeDataTypeEnum.MultiSelect:
                    return MultiSelect;
                case ProjectCustomAttributeDataTypeEnum.PickFromList:
                    return PickFromList;
                case ProjectCustomAttributeDataTypeEnum.String:
                    return String;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCustomAttributeDataTypeEnum
    {
        String = 1,
        Integer = 2,
        Decimal = 3,
        DateTime = 4,
        PickFromList = 5,
        MultiSelect = 6,
        Boolean = 7,
        LongString = 8
    }

    public partial class ProjectCustomAttributeDataTypeString : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypeString(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypeString Instance = new ProjectCustomAttributeDataTypeString(1, @"String", @"String");
    }

    public partial class ProjectCustomAttributeDataTypeInteger : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypeInteger(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypeInteger Instance = new ProjectCustomAttributeDataTypeInteger(2, @"Integer", @"Integer");
    }

    public partial class ProjectCustomAttributeDataTypeDecimal : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypeDecimal(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypeDecimal Instance = new ProjectCustomAttributeDataTypeDecimal(3, @"Decimal", @"Decimal");
    }

    public partial class ProjectCustomAttributeDataTypeDateTime : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypeDateTime(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypeDateTime Instance = new ProjectCustomAttributeDataTypeDateTime(4, @"DateTime", @"Date/Time");
    }

    public partial class ProjectCustomAttributeDataTypePickFromList : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypePickFromList(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypePickFromList Instance = new ProjectCustomAttributeDataTypePickFromList(5, @"PickFromList", @"Pick One from List");
    }

    public partial class ProjectCustomAttributeDataTypeMultiSelect : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypeMultiSelect(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypeMultiSelect Instance = new ProjectCustomAttributeDataTypeMultiSelect(6, @"MultiSelect", @"Select Many from List");
    }

    public partial class ProjectCustomAttributeDataTypeBoolean : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypeBoolean(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypeBoolean Instance = new ProjectCustomAttributeDataTypeBoolean(7, @"Boolean", @"True/False");
    }

    public partial class ProjectCustomAttributeDataTypeLongString : ProjectCustomAttributeDataType
    {
        private ProjectCustomAttributeDataTypeLongString(int projectCustomAttributeDataTypeID, string projectCustomAttributeDataTypeName, string projectCustomAttributeDataTypeDisplayName) : base(projectCustomAttributeDataTypeID, projectCustomAttributeDataTypeName, projectCustomAttributeDataTypeDisplayName) {}
        public static readonly ProjectCustomAttributeDataTypeLongString Instance = new ProjectCustomAttributeDataTypeLongString(8, @"LongString", @"Long String (Text Area)");
    }
}