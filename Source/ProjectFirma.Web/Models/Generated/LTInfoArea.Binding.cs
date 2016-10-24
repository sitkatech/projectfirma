//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LTInfoArea]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class LTInfoArea : IHavePrimaryKey
    {
        public static readonly LTInfoAreaEIP EIP = LTInfoAreaEIP.Instance;
        public static readonly LTInfoAreaSustainability Sustainability = LTInfoAreaSustainability.Instance;
        public static readonly LTInfoAreaLTInfo LTInfo = LTInfoAreaLTInfo.Instance;
        public static readonly LTInfoAreaThreshold Threshold = LTInfoAreaThreshold.Instance;

        public static readonly List<LTInfoArea> All;
        public static readonly ReadOnlyDictionary<int, LTInfoArea> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static LTInfoArea()
        {
            All = new List<LTInfoArea> { EIP, Sustainability, LTInfo, Threshold };
            AllLookupDictionary = new ReadOnlyDictionary<int, LTInfoArea>(All.ToDictionary(x => x.LTInfoAreaID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected LTInfoArea(int lTInfoAreaID, string lTInfoAreaName, string lTInfoAreaDisplayName, int sortOrder)
        {
            LTInfoAreaID = lTInfoAreaID;
            LTInfoAreaName = lTInfoAreaName;
            LTInfoAreaDisplayName = lTInfoAreaDisplayName;
            SortOrder = sortOrder;
        }
        public List<EIPRole> EIPRoles { get { return EIPRole.All.Where(x => x.LTInfoAreaID == LTInfoAreaID).ToList(); } }
        public List<FieldDefinition> FieldDefinitionsWhereYouAreThePrimaryLTInfoArea { get { return FieldDefinition.All.Where(x => x.PrimaryLTInfoAreaID == LTInfoAreaID).ToList(); } }
        public List<LTInfoRole> LTInfoRoles { get { return LTInfoRole.All.Where(x => x.LTInfoAreaID == LTInfoAreaID).ToList(); } }
        public List<ProjectFirmaPageType> ProjectFirmaPageTypesWhereYouAreThePrimaryLTInfoArea { get { return ProjectFirmaPageType.All.Where(x => x.PrimaryLTInfoAreaID == LTInfoAreaID).ToList(); } }
        public List<SupportRequestType> SupportRequestTypes { get { return SupportRequestType.All.Where(x => x.LTInfoAreaID == LTInfoAreaID).ToList(); } }
        public List<SustainabilityRole> SustainabilityRoles { get { return SustainabilityRole.All.Where(x => x.LTInfoAreaID == LTInfoAreaID).ToList(); } }
        public List<ThresholdRole> ThresholdRoles { get { return ThresholdRole.All.Where(x => x.LTInfoAreaID == LTInfoAreaID).ToList(); } }
        [Key]
        public int LTInfoAreaID { get; private set; }
        public string LTInfoAreaName { get; private set; }
        public string LTInfoAreaDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public int PrimaryKey { get { return LTInfoAreaID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(LTInfoArea other)
        {
            if (other == null)
            {
                return false;
            }
            return other.LTInfoAreaID == LTInfoAreaID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as LTInfoArea);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return LTInfoAreaID;
        }

        public static bool operator ==(LTInfoArea left, LTInfoArea right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LTInfoArea left, LTInfoArea right)
        {
            return !Equals(left, right);
        }

        public LTInfoAreaEnum ToEnum { get { return (LTInfoAreaEnum)GetHashCode(); } }

        public static LTInfoArea ToType(int enumValue)
        {
            return ToType((LTInfoAreaEnum)enumValue);
        }

        public static LTInfoArea ToType(LTInfoAreaEnum enumValue)
        {
            switch (enumValue)
            {
                case LTInfoAreaEnum.EIP:
                    return EIP;
                case LTInfoAreaEnum.LTInfo:
                    return LTInfo;
                case LTInfoAreaEnum.Sustainability:
                    return Sustainability;
                case LTInfoAreaEnum.Threshold:
                    return Threshold;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum LTInfoAreaEnum
    {
        EIP = 1,
        Sustainability = 2,
        LTInfo = 3,
        Threshold = 5
    }

    public partial class LTInfoAreaEIP : LTInfoArea
    {
        private LTInfoAreaEIP(int lTInfoAreaID, string lTInfoAreaName, string lTInfoAreaDisplayName, int sortOrder) : base(lTInfoAreaID, lTInfoAreaName, lTInfoAreaDisplayName, sortOrder) {}
        public static readonly LTInfoAreaEIP Instance = new LTInfoAreaEIP(1, @"EIP", @"EIP Project Tracker", 20);
    }

    public partial class LTInfoAreaSustainability : LTInfoArea
    {
        private LTInfoAreaSustainability(int lTInfoAreaID, string lTInfoAreaName, string lTInfoAreaDisplayName, int sortOrder) : base(lTInfoAreaID, lTInfoAreaName, lTInfoAreaDisplayName, sortOrder) {}
        public static readonly LTInfoAreaSustainability Instance = new LTInfoAreaSustainability(2, @"Sustainability", @"Sustainability Dashboard", 30);
    }

    public partial class LTInfoAreaLTInfo : LTInfoArea
    {
        private LTInfoAreaLTInfo(int lTInfoAreaID, string lTInfoAreaName, string lTInfoAreaDisplayName, int sortOrder) : base(lTInfoAreaID, lTInfoAreaName, lTInfoAreaDisplayName, sortOrder) {}
        public static readonly LTInfoAreaLTInfo Instance = new LTInfoAreaLTInfo(3, @"LTInfo", @"Lake Tahoe Info", 10);
    }

    public partial class LTInfoAreaThreshold : LTInfoArea
    {
        private LTInfoAreaThreshold(int lTInfoAreaID, string lTInfoAreaName, string lTInfoAreaDisplayName, int sortOrder) : base(lTInfoAreaID, lTInfoAreaName, lTInfoAreaDisplayName, sortOrder) {}
        public static readonly LTInfoAreaThreshold Instance = new LTInfoAreaThreshold(5, @"Threshold", @"Threshold Dashboard", 50);
    }
}