//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLevel]
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
    public abstract partial class TaxonomyLevel : IHavePrimaryKey
    {
        public static readonly TaxonomyLevelLeaf Leaf = TaxonomyLevelLeaf.Instance;
        public static readonly TaxonomyLevelBranch Branch = TaxonomyLevelBranch.Instance;
        public static readonly TaxonomyLevelTrunk Trunk = TaxonomyLevelTrunk.Instance;

        public static readonly List<TaxonomyLevel> All;
        public static readonly ReadOnlyDictionary<int, TaxonomyLevel> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static TaxonomyLevel()
        {
            All = new List<TaxonomyLevel> { Leaf, Branch, Trunk };
            AllLookupDictionary = new ReadOnlyDictionary<int, TaxonomyLevel>(All.ToDictionary(x => x.TaxonomyLevelID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected TaxonomyLevel(int taxonomyLevelID, string taxonomyLevelName, string taxonomyLevelDisplayName)
        {
            TaxonomyLevelID = taxonomyLevelID;
            TaxonomyLevelName = taxonomyLevelName;
            TaxonomyLevelDisplayName = taxonomyLevelDisplayName;
        }

        [Key]
        public int TaxonomyLevelID { get; private set; }
        public string TaxonomyLevelName { get; private set; }
        public string TaxonomyLevelDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return TaxonomyLevelID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(TaxonomyLevel other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TaxonomyLevelID == TaxonomyLevelID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as TaxonomyLevel);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TaxonomyLevelID;
        }

        public static bool operator ==(TaxonomyLevel left, TaxonomyLevel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TaxonomyLevel left, TaxonomyLevel right)
        {
            return !Equals(left, right);
        }

        public TaxonomyLevelEnum ToEnum { get { return (TaxonomyLevelEnum)GetHashCode(); } }

        public static TaxonomyLevel ToType(int enumValue)
        {
            return ToType((TaxonomyLevelEnum)enumValue);
        }

        public static TaxonomyLevel ToType(TaxonomyLevelEnum enumValue)
        {
            switch (enumValue)
            {
                case TaxonomyLevelEnum.Branch:
                    return Branch;
                case TaxonomyLevelEnum.Leaf:
                    return Leaf;
                case TaxonomyLevelEnum.Trunk:
                    return Trunk;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TaxonomyLevelEnum
    {
        Leaf = 1,
        Branch = 2,
        Trunk = 3
    }

    public partial class TaxonomyLevelLeaf : TaxonomyLevel
    {
        private TaxonomyLevelLeaf(int taxonomyLevelID, string taxonomyLevelName, string taxonomyLevelDisplayName) : base(taxonomyLevelID, taxonomyLevelName, taxonomyLevelDisplayName) {}
        public static readonly TaxonomyLevelLeaf Instance = new TaxonomyLevelLeaf(1, @"Leaf", @"Leaf (1 level)");
    }

    public partial class TaxonomyLevelBranch : TaxonomyLevel
    {
        private TaxonomyLevelBranch(int taxonomyLevelID, string taxonomyLevelName, string taxonomyLevelDisplayName) : base(taxonomyLevelID, taxonomyLevelName, taxonomyLevelDisplayName) {}
        public static readonly TaxonomyLevelBranch Instance = new TaxonomyLevelBranch(2, @"Branch", @"Branch (2 levels)");
    }

    public partial class TaxonomyLevelTrunk : TaxonomyLevel
    {
        private TaxonomyLevelTrunk(int taxonomyLevelID, string taxonomyLevelName, string taxonomyLevelDisplayName) : base(taxonomyLevelID, taxonomyLevelName, taxonomyLevelDisplayName) {}
        public static readonly TaxonomyLevelTrunk Instance = new TaxonomyLevelTrunk(3, @"Trunk", @"Trunk (3 levels)");
    }
}