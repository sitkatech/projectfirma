//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaSystemAuthenticationType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class FirmaSystemAuthenticationType : IHavePrimaryKey
    {
        public static readonly FirmaSystemAuthenticationTypeKeystone Keystone = FirmaSystemAuthenticationTypeKeystone.Instance;
        public static readonly FirmaSystemAuthenticationTypeFirmaSelfAuth FirmaSelfAuth = FirmaSystemAuthenticationTypeFirmaSelfAuth.Instance;

        public static readonly List<FirmaSystemAuthenticationType> All;
        public static readonly ReadOnlyDictionary<int, FirmaSystemAuthenticationType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FirmaSystemAuthenticationType()
        {
            All = new List<FirmaSystemAuthenticationType> { Keystone, FirmaSelfAuth };
            AllLookupDictionary = new ReadOnlyDictionary<int, FirmaSystemAuthenticationType>(All.ToDictionary(x => x.FirmaSystemAuthenticationTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FirmaSystemAuthenticationType(int firmaSystemAuthenticationTypeID, string firmaSystemAuthenticationTypeName, string firmaSystemAuthenticationTypeDisplayName)
        {
            FirmaSystemAuthenticationTypeID = firmaSystemAuthenticationTypeID;
            FirmaSystemAuthenticationTypeName = firmaSystemAuthenticationTypeName;
            FirmaSystemAuthenticationTypeDisplayName = firmaSystemAuthenticationTypeDisplayName;
        }

        [Key]
        public int FirmaSystemAuthenticationTypeID { get; private set; }
        public string FirmaSystemAuthenticationTypeName { get; private set; }
        public string FirmaSystemAuthenticationTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaSystemAuthenticationTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FirmaSystemAuthenticationType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FirmaSystemAuthenticationTypeID == FirmaSystemAuthenticationTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FirmaSystemAuthenticationType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FirmaSystemAuthenticationTypeID;
        }

        public static bool operator ==(FirmaSystemAuthenticationType left, FirmaSystemAuthenticationType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirmaSystemAuthenticationType left, FirmaSystemAuthenticationType right)
        {
            return !Equals(left, right);
        }

        public FirmaSystemAuthenticationTypeEnum ToEnum { get { return (FirmaSystemAuthenticationTypeEnum)GetHashCode(); } }

        public static FirmaSystemAuthenticationType ToType(int enumValue)
        {
            return ToType((FirmaSystemAuthenticationTypeEnum)enumValue);
        }

        public static FirmaSystemAuthenticationType ToType(FirmaSystemAuthenticationTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FirmaSystemAuthenticationTypeEnum.FirmaSelfAuth:
                    return FirmaSelfAuth;
                case FirmaSystemAuthenticationTypeEnum.Keystone:
                    return Keystone;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FirmaSystemAuthenticationTypeEnum
    {
        Keystone = 1,
        FirmaSelfAuth = 2
    }

    public partial class FirmaSystemAuthenticationTypeKeystone : FirmaSystemAuthenticationType
    {
        private FirmaSystemAuthenticationTypeKeystone(int firmaSystemAuthenticationTypeID, string firmaSystemAuthenticationTypeName, string firmaSystemAuthenticationTypeDisplayName) : base(firmaSystemAuthenticationTypeID, firmaSystemAuthenticationTypeName, firmaSystemAuthenticationTypeDisplayName) {}
        public static readonly FirmaSystemAuthenticationTypeKeystone Instance = new FirmaSystemAuthenticationTypeKeystone(1, @"Keystone", @"Keystone");
    }

    public partial class FirmaSystemAuthenticationTypeFirmaSelfAuth : FirmaSystemAuthenticationType
    {
        private FirmaSystemAuthenticationTypeFirmaSelfAuth(int firmaSystemAuthenticationTypeID, string firmaSystemAuthenticationTypeName, string firmaSystemAuthenticationTypeDisplayName) : base(firmaSystemAuthenticationTypeID, firmaSystemAuthenticationTypeName, firmaSystemAuthenticationTypeDisplayName) {}
        public static readonly FirmaSystemAuthenticationTypeFirmaSelfAuth Instance = new FirmaSystemAuthenticationTypeFirmaSelfAuth(2, @"FirmaSelfAuth", @"Firma Self Authentication");
    }
}