//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdSectorType]
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
    public abstract partial class ThresholdSectorType : IHavePrimaryKey
    {
        public static readonly ThresholdSectorTypeFederal Federal = ThresholdSectorTypeFederal.Instance;
        public static readonly ThresholdSectorTypeCalifornia California = ThresholdSectorTypeCalifornia.Instance;
        public static readonly ThresholdSectorTypeNevada Nevada = ThresholdSectorTypeNevada.Instance;
        public static readonly ThresholdSectorTypeTRPA TRPA = ThresholdSectorTypeTRPA.Instance;

        public static readonly List<ThresholdSectorType> All;
        public static readonly ReadOnlyDictionary<int, ThresholdSectorType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ThresholdSectorType()
        {
            All = new List<ThresholdSectorType> { Federal, California, Nevada, TRPA };
            AllLookupDictionary = new ReadOnlyDictionary<int, ThresholdSectorType>(All.ToDictionary(x => x.ThresholdSectorTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ThresholdSectorType(int thresholdSectorTypeID, string thresholdSectorTypeName, string thresholdSectorTypeDisplayName)
        {
            ThresholdSectorTypeID = thresholdSectorTypeID;
            ThresholdSectorTypeName = thresholdSectorTypeName;
            ThresholdSectorTypeDisplayName = thresholdSectorTypeDisplayName;
        }

        [Key]
        public int ThresholdSectorTypeID { get; private set; }
        public string ThresholdSectorTypeName { get; private set; }
        public string ThresholdSectorTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return ThresholdSectorTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ThresholdSectorType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ThresholdSectorTypeID == ThresholdSectorTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ThresholdSectorType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ThresholdSectorTypeID;
        }

        public static bool operator ==(ThresholdSectorType left, ThresholdSectorType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThresholdSectorType left, ThresholdSectorType right)
        {
            return !Equals(left, right);
        }

        public ThresholdSectorTypeEnum ToEnum { get { return (ThresholdSectorTypeEnum)GetHashCode(); } }

        public static ThresholdSectorType ToType(int enumValue)
        {
            return ToType((ThresholdSectorTypeEnum)enumValue);
        }

        public static ThresholdSectorType ToType(ThresholdSectorTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ThresholdSectorTypeEnum.California:
                    return California;
                case ThresholdSectorTypeEnum.Federal:
                    return Federal;
                case ThresholdSectorTypeEnum.Nevada:
                    return Nevada;
                case ThresholdSectorTypeEnum.TRPA:
                    return TRPA;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ThresholdSectorTypeEnum
    {
        Federal = 1,
        California = 2,
        Nevada = 3,
        TRPA = 4
    }

    public partial class ThresholdSectorTypeFederal : ThresholdSectorType
    {
        private ThresholdSectorTypeFederal(int thresholdSectorTypeID, string thresholdSectorTypeName, string thresholdSectorTypeDisplayName) : base(thresholdSectorTypeID, thresholdSectorTypeName, thresholdSectorTypeDisplayName) {}
        public static readonly ThresholdSectorTypeFederal Instance = new ThresholdSectorTypeFederal(1, @"Federal", @"Federal");
    }

    public partial class ThresholdSectorTypeCalifornia : ThresholdSectorType
    {
        private ThresholdSectorTypeCalifornia(int thresholdSectorTypeID, string thresholdSectorTypeName, string thresholdSectorTypeDisplayName) : base(thresholdSectorTypeID, thresholdSectorTypeName, thresholdSectorTypeDisplayName) {}
        public static readonly ThresholdSectorTypeCalifornia Instance = new ThresholdSectorTypeCalifornia(2, @"California", @"California");
    }

    public partial class ThresholdSectorTypeNevada : ThresholdSectorType
    {
        private ThresholdSectorTypeNevada(int thresholdSectorTypeID, string thresholdSectorTypeName, string thresholdSectorTypeDisplayName) : base(thresholdSectorTypeID, thresholdSectorTypeName, thresholdSectorTypeDisplayName) {}
        public static readonly ThresholdSectorTypeNevada Instance = new ThresholdSectorTypeNevada(3, @"Nevada", @"Nevada");
    }

    public partial class ThresholdSectorTypeTRPA : ThresholdSectorType
    {
        private ThresholdSectorTypeTRPA(int thresholdSectorTypeID, string thresholdSectorTypeName, string thresholdSectorTypeDisplayName) : base(thresholdSectorTypeID, thresholdSectorTypeName, thresholdSectorTypeDisplayName) {}
        public static readonly ThresholdSectorTypeTRPA Instance = new ThresholdSectorTypeTRPA(4, @"TRPA", @"TRPA");
    }
}