//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageDisplayType]
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
    public abstract partial class CustomPageDisplayType : IHavePrimaryKey
    {
        public static readonly CustomPageDisplayTypeDisabled Disabled = CustomPageDisplayTypeDisabled.Instance;
        public static readonly CustomPageDisplayTypePublic Public = CustomPageDisplayTypePublic.Instance;
        public static readonly CustomPageDisplayTypeProtected Protected = CustomPageDisplayTypeProtected.Instance;

        public static readonly List<CustomPageDisplayType> All;
        public static readonly ReadOnlyDictionary<int, CustomPageDisplayType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static CustomPageDisplayType()
        {
            All = new List<CustomPageDisplayType> { Disabled, Public, Protected };
            AllLookupDictionary = new ReadOnlyDictionary<int, CustomPageDisplayType>(All.ToDictionary(x => x.CustomPageDisplayTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected CustomPageDisplayType(int customPageDisplayTypeID, string customPageDisplayTypeName, string customPageDisplayTypeDisplayName, string customPageDisplayTypeDescription)
        {
            CustomPageDisplayTypeID = customPageDisplayTypeID;
            CustomPageDisplayTypeName = customPageDisplayTypeName;
            CustomPageDisplayTypeDisplayName = customPageDisplayTypeDisplayName;
            CustomPageDisplayTypeDescription = customPageDisplayTypeDescription;
        }

        [Key]
        public int CustomPageDisplayTypeID { get; private set; }
        public string CustomPageDisplayTypeName { get; private set; }
        public string CustomPageDisplayTypeDisplayName { get; private set; }
        public string CustomPageDisplayTypeDescription { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return CustomPageDisplayTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(CustomPageDisplayType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.CustomPageDisplayTypeID == CustomPageDisplayTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as CustomPageDisplayType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return CustomPageDisplayTypeID;
        }

        public static bool operator ==(CustomPageDisplayType left, CustomPageDisplayType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomPageDisplayType left, CustomPageDisplayType right)
        {
            return !Equals(left, right);
        }

        public CustomPageDisplayTypeEnum ToEnum { get { return (CustomPageDisplayTypeEnum)GetHashCode(); } }

        public static CustomPageDisplayType ToType(int enumValue)
        {
            return ToType((CustomPageDisplayTypeEnum)enumValue);
        }

        public static CustomPageDisplayType ToType(CustomPageDisplayTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case CustomPageDisplayTypeEnum.Disabled:
                    return Disabled;
                case CustomPageDisplayTypeEnum.Protected:
                    return Protected;
                case CustomPageDisplayTypeEnum.Public:
                    return Public;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum CustomPageDisplayTypeEnum
    {
        Disabled = 1,
        Public = 2,
        Protected = 3
    }

    public partial class CustomPageDisplayTypeDisabled : CustomPageDisplayType
    {
        private CustomPageDisplayTypeDisabled(int customPageDisplayTypeID, string customPageDisplayTypeName, string customPageDisplayTypeDisplayName, string customPageDisplayTypeDescription) : base(customPageDisplayTypeID, customPageDisplayTypeName, customPageDisplayTypeDisplayName, customPageDisplayTypeDescription) {}
        public static readonly CustomPageDisplayTypeDisabled Instance = new CustomPageDisplayTypeDisabled(1, @"Disabled", @"Disabled", @"Not visible to any users");
    }

    public partial class CustomPageDisplayTypePublic : CustomPageDisplayType
    {
        private CustomPageDisplayTypePublic(int customPageDisplayTypeID, string customPageDisplayTypeName, string customPageDisplayTypeDisplayName, string customPageDisplayTypeDescription) : base(customPageDisplayTypeID, customPageDisplayTypeName, customPageDisplayTypeDisplayName, customPageDisplayTypeDescription) {}
        public static readonly CustomPageDisplayTypePublic Instance = new CustomPageDisplayTypePublic(2, @"Public", @"Public", @"Visible to all users");
    }

    public partial class CustomPageDisplayTypeProtected : CustomPageDisplayType
    {
        private CustomPageDisplayTypeProtected(int customPageDisplayTypeID, string customPageDisplayTypeName, string customPageDisplayTypeDisplayName, string customPageDisplayTypeDescription) : base(customPageDisplayTypeID, customPageDisplayTypeName, customPageDisplayTypeDisplayName, customPageDisplayTypeDescription) {}
        public static readonly CustomPageDisplayTypeProtected Instance = new CustomPageDisplayTypeProtected(3, @"Protected", @"Protected", @"Visible to logged in users only");
    }
}