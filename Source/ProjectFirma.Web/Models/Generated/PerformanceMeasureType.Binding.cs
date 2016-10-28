//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureType]
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
    public abstract partial class PerformanceMeasureType : IHavePrimaryKey
    {
        public static readonly PerformanceMeasureTypeNormal Normal = PerformanceMeasureTypeNormal.Instance;
        public static readonly PerformanceMeasureTypeTMDLRelevant TMDLRelevant = PerformanceMeasureTypeTMDLRelevant.Instance;
        public static readonly PerformanceMeasureTypePerformanceMeasure33 PerformanceMeasure33 = PerformanceMeasureTypePerformanceMeasure33.Instance;
        public static readonly PerformanceMeasureTypePerformanceMeasure34 PerformanceMeasure34 = PerformanceMeasureTypePerformanceMeasure34.Instance;
        public static readonly PerformanceMeasureTypeForProjectsFunctioningAsAProgram ForProjectsFunctioningAsAProgram = PerformanceMeasureTypeForProjectsFunctioningAsAProgram.Instance;

        public static readonly List<PerformanceMeasureType> All;
        public static readonly ReadOnlyDictionary<int, PerformanceMeasureType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static PerformanceMeasureType()
        {
            All = new List<PerformanceMeasureType> { Normal, TMDLRelevant, PerformanceMeasure33, PerformanceMeasure34, ForProjectsFunctioningAsAProgram };
            AllLookupDictionary = new ReadOnlyDictionary<int, PerformanceMeasureType>(All.ToDictionary(x => x.PerformanceMeasureTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected PerformanceMeasureType(int performanceMeasureTypeID, string performanceMeasureTypeName, string performanceMeasureTypeDisplayName)
        {
            PerformanceMeasureTypeID = performanceMeasureTypeID;
            PerformanceMeasureTypeName = performanceMeasureTypeName;
            PerformanceMeasureTypeDisplayName = performanceMeasureTypeDisplayName;
        }

        [Key]
        public int PerformanceMeasureTypeID { get; private set; }
        public string PerformanceMeasureTypeName { get; private set; }
        public string PerformanceMeasureTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return PerformanceMeasureTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(PerformanceMeasureType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.PerformanceMeasureTypeID == PerformanceMeasureTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as PerformanceMeasureType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return PerformanceMeasureTypeID;
        }

        public static bool operator ==(PerformanceMeasureType left, PerformanceMeasureType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PerformanceMeasureType left, PerformanceMeasureType right)
        {
            return !Equals(left, right);
        }

        public PerformanceMeasureTypeEnum ToEnum { get { return (PerformanceMeasureTypeEnum)GetHashCode(); } }

        public static PerformanceMeasureType ToType(int enumValue)
        {
            return ToType((PerformanceMeasureTypeEnum)enumValue);
        }

        public static PerformanceMeasureType ToType(PerformanceMeasureTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case PerformanceMeasureTypeEnum.ForProjectsFunctioningAsAProgram:
                    return ForProjectsFunctioningAsAProgram;
                case PerformanceMeasureTypeEnum.Normal:
                    return Normal;
                case PerformanceMeasureTypeEnum.PerformanceMeasure33:
                    return PerformanceMeasure33;
                case PerformanceMeasureTypeEnum.PerformanceMeasure34:
                    return PerformanceMeasure34;
                case PerformanceMeasureTypeEnum.TMDLRelevant:
                    return TMDLRelevant;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum PerformanceMeasureTypeEnum
    {
        Normal = 1,
        TMDLRelevant = 2,
        PerformanceMeasure33 = 3,
        PerformanceMeasure34 = 4,
        ForProjectsFunctioningAsAProgram = 5
    }

    public partial class PerformanceMeasureTypeNormal : PerformanceMeasureType
    {
        private PerformanceMeasureTypeNormal(int performanceMeasureTypeID, string performanceMeasureTypeName, string performanceMeasureTypeDisplayName) : base(performanceMeasureTypeID, performanceMeasureTypeName, performanceMeasureTypeDisplayName) {}
        public static readonly PerformanceMeasureTypeNormal Instance = new PerformanceMeasureTypeNormal(1, @"Normal", @"Normal");
    }

    public partial class PerformanceMeasureTypeTMDLRelevant : PerformanceMeasureType
    {
        private PerformanceMeasureTypeTMDLRelevant(int performanceMeasureTypeID, string performanceMeasureTypeName, string performanceMeasureTypeDisplayName) : base(performanceMeasureTypeID, performanceMeasureTypeName, performanceMeasureTypeDisplayName) {}
        public static readonly PerformanceMeasureTypeTMDLRelevant Instance = new PerformanceMeasureTypeTMDLRelevant(2, @"TMDLRelevant", @"TMDL Relevant");
    }

    public partial class PerformanceMeasureTypePerformanceMeasure33 : PerformanceMeasureType
    {
        private PerformanceMeasureTypePerformanceMeasure33(int performanceMeasureTypeID, string performanceMeasureTypeName, string performanceMeasureTypeDisplayName) : base(performanceMeasureTypeID, performanceMeasureTypeName, performanceMeasureTypeDisplayName) {}
        public static readonly PerformanceMeasureTypePerformanceMeasure33 Instance = new PerformanceMeasureTypePerformanceMeasure33(3, @"PerformanceMeasure33", @"Performance Measure 33");
    }

    public partial class PerformanceMeasureTypePerformanceMeasure34 : PerformanceMeasureType
    {
        private PerformanceMeasureTypePerformanceMeasure34(int performanceMeasureTypeID, string performanceMeasureTypeName, string performanceMeasureTypeDisplayName) : base(performanceMeasureTypeID, performanceMeasureTypeName, performanceMeasureTypeDisplayName) {}
        public static readonly PerformanceMeasureTypePerformanceMeasure34 Instance = new PerformanceMeasureTypePerformanceMeasure34(4, @"PerformanceMeasure34", @"Performance Measure 34");
    }

    public partial class PerformanceMeasureTypeForProjectsFunctioningAsAProgram : PerformanceMeasureType
    {
        private PerformanceMeasureTypeForProjectsFunctioningAsAProgram(int performanceMeasureTypeID, string performanceMeasureTypeName, string performanceMeasureTypeDisplayName) : base(performanceMeasureTypeID, performanceMeasureTypeName, performanceMeasureTypeDisplayName) {}
        public static readonly PerformanceMeasureTypeForProjectsFunctioningAsAProgram Instance = new PerformanceMeasureTypeForProjectsFunctioningAsAProgram(5, @"ForProjectsFunctioningAsAProgram", @"For Projects Functioning as a Program");
    }
}