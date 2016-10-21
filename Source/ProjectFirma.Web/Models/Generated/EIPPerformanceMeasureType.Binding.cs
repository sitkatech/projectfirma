//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public abstract partial class EIPPerformanceMeasureType : IHavePrimaryKey
    {
        public static readonly EIPPerformanceMeasureTypeNormal Normal = EIPPerformanceMeasureTypeNormal.Instance;
        public static readonly EIPPerformanceMeasureTypeTMDLRelevant TMDLRelevant = EIPPerformanceMeasureTypeTMDLRelevant.Instance;
        public static readonly EIPPerformanceMeasureTypeEIPPerformanceMeasure33 EIPPerformanceMeasure33 = EIPPerformanceMeasureTypeEIPPerformanceMeasure33.Instance;
        public static readonly EIPPerformanceMeasureTypeEIPPerformanceMeasure34 EIPPerformanceMeasure34 = EIPPerformanceMeasureTypeEIPPerformanceMeasure34.Instance;
        public static readonly EIPPerformanceMeasureTypeForProjectsFunctioningAsAProgram ForProjectsFunctioningAsAProgram = EIPPerformanceMeasureTypeForProjectsFunctioningAsAProgram.Instance;

        public static readonly List<EIPPerformanceMeasureType> All;
        public static readonly ReadOnlyDictionary<int, EIPPerformanceMeasureType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static EIPPerformanceMeasureType()
        {
            All = new List<EIPPerformanceMeasureType> { Normal, TMDLRelevant, EIPPerformanceMeasure33, EIPPerformanceMeasure34, ForProjectsFunctioningAsAProgram };
            AllLookupDictionary = new ReadOnlyDictionary<int, EIPPerformanceMeasureType>(All.ToDictionary(x => x.EIPPerformanceMeasureTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected EIPPerformanceMeasureType(int eIPPerformanceMeasureTypeID, string eIPPerformanceMeasureTypeName, string eIPPerformanceMeasureTypeDisplayName)
        {
            EIPPerformanceMeasureTypeID = eIPPerformanceMeasureTypeID;
            EIPPerformanceMeasureTypeName = eIPPerformanceMeasureTypeName;
            EIPPerformanceMeasureTypeDisplayName = eIPPerformanceMeasureTypeDisplayName;
        }

        [Key]
        public int EIPPerformanceMeasureTypeID { get; private set; }
        public string EIPPerformanceMeasureTypeName { get; private set; }
        public string EIPPerformanceMeasureTypeDisplayName { get; private set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(EIPPerformanceMeasureType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.EIPPerformanceMeasureTypeID == EIPPerformanceMeasureTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as EIPPerformanceMeasureType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return EIPPerformanceMeasureTypeID;
        }

        public static bool operator ==(EIPPerformanceMeasureType left, EIPPerformanceMeasureType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EIPPerformanceMeasureType left, EIPPerformanceMeasureType right)
        {
            return !Equals(left, right);
        }

        public EIPPerformanceMeasureTypeEnum ToEnum { get { return (EIPPerformanceMeasureTypeEnum)GetHashCode(); } }

        public static EIPPerformanceMeasureType ToType(int enumValue)
        {
            return ToType((EIPPerformanceMeasureTypeEnum)enumValue);
        }

        public static EIPPerformanceMeasureType ToType(EIPPerformanceMeasureTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case EIPPerformanceMeasureTypeEnum.EIPPerformanceMeasure33:
                    return EIPPerformanceMeasure33;
                case EIPPerformanceMeasureTypeEnum.EIPPerformanceMeasure34:
                    return EIPPerformanceMeasure34;
                case EIPPerformanceMeasureTypeEnum.ForProjectsFunctioningAsAProgram:
                    return ForProjectsFunctioningAsAProgram;
                case EIPPerformanceMeasureTypeEnum.Normal:
                    return Normal;
                case EIPPerformanceMeasureTypeEnum.TMDLRelevant:
                    return TMDLRelevant;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum EIPPerformanceMeasureTypeEnum
    {
        Normal = 1,
        TMDLRelevant = 2,
        EIPPerformanceMeasure33 = 3,
        EIPPerformanceMeasure34 = 4,
        ForProjectsFunctioningAsAProgram = 5
    }

    public partial class EIPPerformanceMeasureTypeNormal : EIPPerformanceMeasureType
    {
        private EIPPerformanceMeasureTypeNormal(int eIPPerformanceMeasureTypeID, string eIPPerformanceMeasureTypeName, string eIPPerformanceMeasureTypeDisplayName) : base(eIPPerformanceMeasureTypeID, eIPPerformanceMeasureTypeName, eIPPerformanceMeasureTypeDisplayName) {}
        public static readonly EIPPerformanceMeasureTypeNormal Instance = new EIPPerformanceMeasureTypeNormal(1, @"Normal", @"Normal");
    }

    public partial class EIPPerformanceMeasureTypeTMDLRelevant : EIPPerformanceMeasureType
    {
        private EIPPerformanceMeasureTypeTMDLRelevant(int eIPPerformanceMeasureTypeID, string eIPPerformanceMeasureTypeName, string eIPPerformanceMeasureTypeDisplayName) : base(eIPPerformanceMeasureTypeID, eIPPerformanceMeasureTypeName, eIPPerformanceMeasureTypeDisplayName) {}
        public static readonly EIPPerformanceMeasureTypeTMDLRelevant Instance = new EIPPerformanceMeasureTypeTMDLRelevant(2, @"TMDLRelevant", @"TMDL Relevant");
    }

    public partial class EIPPerformanceMeasureTypeEIPPerformanceMeasure33 : EIPPerformanceMeasureType
    {
        private EIPPerformanceMeasureTypeEIPPerformanceMeasure33(int eIPPerformanceMeasureTypeID, string eIPPerformanceMeasureTypeName, string eIPPerformanceMeasureTypeDisplayName) : base(eIPPerformanceMeasureTypeID, eIPPerformanceMeasureTypeName, eIPPerformanceMeasureTypeDisplayName) {}
        public static readonly EIPPerformanceMeasureTypeEIPPerformanceMeasure33 Instance = new EIPPerformanceMeasureTypeEIPPerformanceMeasure33(3, @"EIPPerformanceMeasure33", @"Performance Measure 33");
    }

    public partial class EIPPerformanceMeasureTypeEIPPerformanceMeasure34 : EIPPerformanceMeasureType
    {
        private EIPPerformanceMeasureTypeEIPPerformanceMeasure34(int eIPPerformanceMeasureTypeID, string eIPPerformanceMeasureTypeName, string eIPPerformanceMeasureTypeDisplayName) : base(eIPPerformanceMeasureTypeID, eIPPerformanceMeasureTypeName, eIPPerformanceMeasureTypeDisplayName) {}
        public static readonly EIPPerformanceMeasureTypeEIPPerformanceMeasure34 Instance = new EIPPerformanceMeasureTypeEIPPerformanceMeasure34(4, @"EIPPerformanceMeasure34", @"Performance Measure 34");
    }

    public partial class EIPPerformanceMeasureTypeForProjectsFunctioningAsAProgram : EIPPerformanceMeasureType
    {
        private EIPPerformanceMeasureTypeForProjectsFunctioningAsAProgram(int eIPPerformanceMeasureTypeID, string eIPPerformanceMeasureTypeName, string eIPPerformanceMeasureTypeDisplayName) : base(eIPPerformanceMeasureTypeID, eIPPerformanceMeasureTypeName, eIPPerformanceMeasureTypeDisplayName) {}
        public static readonly EIPPerformanceMeasureTypeForProjectsFunctioningAsAProgram Instance = new EIPPerformanceMeasureTypeForProjectsFunctioningAsAProgram(5, @"ForProjectsFunctioningAsAProgram", @"For Projects Functioning as a Program");
    }
}