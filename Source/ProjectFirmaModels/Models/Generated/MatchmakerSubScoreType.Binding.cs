//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerSubScoreType]
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
    public abstract partial class MatchmakerSubScoreType : IHavePrimaryKey
    {
        public static readonly MatchmakerSubScoreTypeMatchmakerKeyword MatchmakerKeyword = MatchmakerSubScoreTypeMatchmakerKeyword.Instance;
        public static readonly MatchmakerSubScoreTypeAreaOfInterest AreaOfInterest = MatchmakerSubScoreTypeAreaOfInterest.Instance;
        public static readonly MatchmakerSubScoreTypeTaxonomySystem TaxonomySystem = MatchmakerSubScoreTypeTaxonomySystem.Instance;
        public static readonly MatchmakerSubScoreTypeClassification Classification = MatchmakerSubScoreTypeClassification.Instance;
        public static readonly MatchmakerSubScoreTypePerformanceMeasure PerformanceMeasure = MatchmakerSubScoreTypePerformanceMeasure.Instance;

        public static readonly List<MatchmakerSubScoreType> All;
        public static readonly ReadOnlyDictionary<int, MatchmakerSubScoreType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static MatchmakerSubScoreType()
        {
            All = new List<MatchmakerSubScoreType> { MatchmakerKeyword, AreaOfInterest, TaxonomySystem, Classification, PerformanceMeasure };
            AllLookupDictionary = new ReadOnlyDictionary<int, MatchmakerSubScoreType>(All.ToDictionary(x => x.MatchmakerSubScoreTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected MatchmakerSubScoreType(int matchmakerSubScoreTypeID, string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName)
        {
            MatchmakerSubScoreTypeID = matchmakerSubScoreTypeID;
            MatchmakerSubScoreTypeName = matchmakerSubScoreTypeName;
            MatchmakerSubScoreTypeDisplayName = matchmakerSubScoreTypeDisplayName;
        }

        [Key]
        public int MatchmakerSubScoreTypeID { get; private set; }
        public string MatchmakerSubScoreTypeName { get; private set; }
        public string MatchmakerSubScoreTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerSubScoreTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(MatchmakerSubScoreType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.MatchmakerSubScoreTypeID == MatchmakerSubScoreTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as MatchmakerSubScoreType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return MatchmakerSubScoreTypeID;
        }

        public static bool operator ==(MatchmakerSubScoreType left, MatchmakerSubScoreType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchmakerSubScoreType left, MatchmakerSubScoreType right)
        {
            return !Equals(left, right);
        }

        public MatchmakerSubScoreTypeEnum ToEnum { get { return (MatchmakerSubScoreTypeEnum)GetHashCode(); } }

        public static MatchmakerSubScoreType ToType(int enumValue)
        {
            return ToType((MatchmakerSubScoreTypeEnum)enumValue);
        }

        public static MatchmakerSubScoreType ToType(MatchmakerSubScoreTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case MatchmakerSubScoreTypeEnum.AreaOfInterest:
                    return AreaOfInterest;
                case MatchmakerSubScoreTypeEnum.Classification:
                    return Classification;
                case MatchmakerSubScoreTypeEnum.MatchmakerKeyword:
                    return MatchmakerKeyword;
                case MatchmakerSubScoreTypeEnum.PerformanceMeasure:
                    return PerformanceMeasure;
                case MatchmakerSubScoreTypeEnum.TaxonomySystem:
                    return TaxonomySystem;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum MatchmakerSubScoreTypeEnum
    {
        MatchmakerKeyword = 1,
        AreaOfInterest = 2,
        TaxonomySystem = 3,
        Classification = 4,
        PerformanceMeasure = 5
    }

    public partial class MatchmakerSubScoreTypeMatchmakerKeyword : MatchmakerSubScoreType
    {
        private MatchmakerSubScoreTypeMatchmakerKeyword(int matchmakerSubScoreTypeID, string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName) : base(matchmakerSubScoreTypeID, matchmakerSubScoreTypeName, matchmakerSubScoreTypeDisplayName) {}
        public static readonly MatchmakerSubScoreTypeMatchmakerKeyword Instance = new MatchmakerSubScoreTypeMatchmakerKeyword(1, @"MatchmakerKeyword", @"Keywords");
    }

    public partial class MatchmakerSubScoreTypeAreaOfInterest : MatchmakerSubScoreType
    {
        private MatchmakerSubScoreTypeAreaOfInterest(int matchmakerSubScoreTypeID, string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName) : base(matchmakerSubScoreTypeID, matchmakerSubScoreTypeName, matchmakerSubScoreTypeDisplayName) {}
        public static readonly MatchmakerSubScoreTypeAreaOfInterest Instance = new MatchmakerSubScoreTypeAreaOfInterest(2, @"AreaOfInterest", @"Area Of Interest");
    }

    public partial class MatchmakerSubScoreTypeTaxonomySystem : MatchmakerSubScoreType
    {
        private MatchmakerSubScoreTypeTaxonomySystem(int matchmakerSubScoreTypeID, string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName) : base(matchmakerSubScoreTypeID, matchmakerSubScoreTypeName, matchmakerSubScoreTypeDisplayName) {}
        public static readonly MatchmakerSubScoreTypeTaxonomySystem Instance = new MatchmakerSubScoreTypeTaxonomySystem(3, @"TaxonomySystem", @"Taxonomy System");
    }

    public partial class MatchmakerSubScoreTypeClassification : MatchmakerSubScoreType
    {
        private MatchmakerSubScoreTypeClassification(int matchmakerSubScoreTypeID, string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName) : base(matchmakerSubScoreTypeID, matchmakerSubScoreTypeName, matchmakerSubScoreTypeDisplayName) {}
        public static readonly MatchmakerSubScoreTypeClassification Instance = new MatchmakerSubScoreTypeClassification(4, @"Classification", @"Classification");
    }

    public partial class MatchmakerSubScoreTypePerformanceMeasure : MatchmakerSubScoreType
    {
        private MatchmakerSubScoreTypePerformanceMeasure(int matchmakerSubScoreTypeID, string matchmakerSubScoreTypeName, string matchmakerSubScoreTypeDisplayName) : base(matchmakerSubScoreTypeID, matchmakerSubScoreTypeName, matchmakerSubScoreTypeDisplayName) {}
        public static readonly MatchmakerSubScoreTypePerformanceMeasure Instance = new MatchmakerSubScoreTypePerformanceMeasure(5, @"PerformanceMeasure", @"Performance Measures");
    }
}