//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageRenderType]
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
    public abstract partial class FirmaPageRenderType : IHavePrimaryKey
    {
        public static readonly FirmaPageRenderTypeIntroductoryText IntroductoryText = FirmaPageRenderTypeIntroductoryText.Instance;
        public static readonly FirmaPageRenderTypePageContent PageContent = FirmaPageRenderTypePageContent.Instance;

        public static readonly List<FirmaPageRenderType> All;
        public static readonly ReadOnlyDictionary<int, FirmaPageRenderType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FirmaPageRenderType()
        {
            All = new List<FirmaPageRenderType> { IntroductoryText, PageContent };
            AllLookupDictionary = new ReadOnlyDictionary<int, FirmaPageRenderType>(All.ToDictionary(x => x.FirmaPageRenderTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FirmaPageRenderType(int firmaPageRenderTypeID, string firmaPageRenderTypeName, string firmaPageRenderTypeDisplayName)
        {
            FirmaPageRenderTypeID = firmaPageRenderTypeID;
            FirmaPageRenderTypeName = firmaPageRenderTypeName;
            FirmaPageRenderTypeDisplayName = firmaPageRenderTypeDisplayName;
        }

        [Key]
        public int FirmaPageRenderTypeID { get; private set; }
        public string FirmaPageRenderTypeName { get; private set; }
        public string FirmaPageRenderTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaPageRenderTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FirmaPageRenderType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FirmaPageRenderTypeID == FirmaPageRenderTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FirmaPageRenderType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FirmaPageRenderTypeID;
        }

        public static bool operator ==(FirmaPageRenderType left, FirmaPageRenderType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirmaPageRenderType left, FirmaPageRenderType right)
        {
            return !Equals(left, right);
        }

        public FirmaPageRenderTypeEnum ToEnum { get { return (FirmaPageRenderTypeEnum)GetHashCode(); } }

        public static FirmaPageRenderType ToType(int enumValue)
        {
            return ToType((FirmaPageRenderTypeEnum)enumValue);
        }

        public static FirmaPageRenderType ToType(FirmaPageRenderTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FirmaPageRenderTypeEnum.IntroductoryText:
                    return IntroductoryText;
                case FirmaPageRenderTypeEnum.PageContent:
                    return PageContent;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FirmaPageRenderTypeEnum
    {
        IntroductoryText = 1,
        PageContent = 2
    }

    public partial class FirmaPageRenderTypeIntroductoryText : FirmaPageRenderType
    {
        private FirmaPageRenderTypeIntroductoryText(int firmaPageRenderTypeID, string firmaPageRenderTypeName, string firmaPageRenderTypeDisplayName) : base(firmaPageRenderTypeID, firmaPageRenderTypeName, firmaPageRenderTypeDisplayName) {}
        public static readonly FirmaPageRenderTypeIntroductoryText Instance = new FirmaPageRenderTypeIntroductoryText(1, @"IntroductoryText", @"Introductory Text");
    }

    public partial class FirmaPageRenderTypePageContent : FirmaPageRenderType
    {
        private FirmaPageRenderTypePageContent(int firmaPageRenderTypeID, string firmaPageRenderTypeName, string firmaPageRenderTypeDisplayName) : base(firmaPageRenderTypeID, firmaPageRenderTypeName, firmaPageRenderTypeDisplayName) {}
        public static readonly FirmaPageRenderTypePageContent Instance = new FirmaPageRenderTypePageContent(2, @"PageContent", @"Page Content");
    }
}