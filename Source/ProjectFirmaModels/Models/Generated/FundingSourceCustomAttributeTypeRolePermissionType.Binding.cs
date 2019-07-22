//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeTypeRolePermissionType]
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
    public abstract partial class FundingSourceCustomAttributeTypeRolePermissionType : IHavePrimaryKey
    {
        public static readonly FundingSourceCustomAttributeTypeRolePermissionTypeEdit Edit = FundingSourceCustomAttributeTypeRolePermissionTypeEdit.Instance;
        public static readonly FundingSourceCustomAttributeTypeRolePermissionTypeView View = FundingSourceCustomAttributeTypeRolePermissionTypeView.Instance;

        public static readonly List<FundingSourceCustomAttributeTypeRolePermissionType> All;
        public static readonly ReadOnlyDictionary<int, FundingSourceCustomAttributeTypeRolePermissionType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FundingSourceCustomAttributeTypeRolePermissionType()
        {
            All = new List<FundingSourceCustomAttributeTypeRolePermissionType> { Edit, View };
            AllLookupDictionary = new ReadOnlyDictionary<int, FundingSourceCustomAttributeTypeRolePermissionType>(All.ToDictionary(x => x.FundingSourceCustomAttributeTypeRolePermissionTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FundingSourceCustomAttributeTypeRolePermissionType(int fundingSourceCustomAttributeTypeRolePermissionTypeID, string fundingSourceCustomAttributeTypeRolePermissionTypeName)
        {
            FundingSourceCustomAttributeTypeRolePermissionTypeID = fundingSourceCustomAttributeTypeRolePermissionTypeID;
            FundingSourceCustomAttributeTypeRolePermissionTypeName = fundingSourceCustomAttributeTypeRolePermissionTypeName;
        }

        [Key]
        public int FundingSourceCustomAttributeTypeRolePermissionTypeID { get; private set; }
        public string FundingSourceCustomAttributeTypeRolePermissionTypeName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingSourceCustomAttributeTypeRolePermissionTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FundingSourceCustomAttributeTypeRolePermissionType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FundingSourceCustomAttributeTypeRolePermissionTypeID == FundingSourceCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FundingSourceCustomAttributeTypeRolePermissionType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FundingSourceCustomAttributeTypeRolePermissionTypeID;
        }

        public static bool operator ==(FundingSourceCustomAttributeTypeRolePermissionType left, FundingSourceCustomAttributeTypeRolePermissionType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FundingSourceCustomAttributeTypeRolePermissionType left, FundingSourceCustomAttributeTypeRolePermissionType right)
        {
            return !Equals(left, right);
        }

        public FundingSourceCustomAttributeTypeRolePermissionTypeEnum ToEnum { get { return (FundingSourceCustomAttributeTypeRolePermissionTypeEnum)GetHashCode(); } }

        public static FundingSourceCustomAttributeTypeRolePermissionType ToType(int enumValue)
        {
            return ToType((FundingSourceCustomAttributeTypeRolePermissionTypeEnum)enumValue);
        }

        public static FundingSourceCustomAttributeTypeRolePermissionType ToType(FundingSourceCustomAttributeTypeRolePermissionTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FundingSourceCustomAttributeTypeRolePermissionTypeEnum.Edit:
                    return Edit;
                case FundingSourceCustomAttributeTypeRolePermissionTypeEnum.View:
                    return View;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FundingSourceCustomAttributeTypeRolePermissionTypeEnum
    {
        Edit = 1,
        View = 2
    }

    public partial class FundingSourceCustomAttributeTypeRolePermissionTypeEdit : FundingSourceCustomAttributeTypeRolePermissionType
    {
        private FundingSourceCustomAttributeTypeRolePermissionTypeEdit(int fundingSourceCustomAttributeTypeRolePermissionTypeID, string fundingSourceCustomAttributeTypeRolePermissionTypeName) : base(fundingSourceCustomAttributeTypeRolePermissionTypeID, fundingSourceCustomAttributeTypeRolePermissionTypeName) {}
        public static readonly FundingSourceCustomAttributeTypeRolePermissionTypeEdit Instance = new FundingSourceCustomAttributeTypeRolePermissionTypeEdit(1, @"Edit");
    }

    public partial class FundingSourceCustomAttributeTypeRolePermissionTypeView : FundingSourceCustomAttributeTypeRolePermissionType
    {
        private FundingSourceCustomAttributeTypeRolePermissionTypeView(int fundingSourceCustomAttributeTypeRolePermissionTypeID, string fundingSourceCustomAttributeTypeRolePermissionTypeName) : base(fundingSourceCustomAttributeTypeRolePermissionTypeID, fundingSourceCustomAttributeTypeRolePermissionTypeName) {}
        public static readonly FundingSourceCustomAttributeTypeRolePermissionTypeView Instance = new FundingSourceCustomAttributeTypeRolePermissionTypeView(2, @"View");
    }
}