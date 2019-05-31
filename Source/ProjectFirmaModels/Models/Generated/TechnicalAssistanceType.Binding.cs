//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceType]
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
    public abstract partial class TechnicalAssistanceType : IHavePrimaryKey
    {
        public static readonly TechnicalAssistanceTypeCapacityBuilding CapacityBuilding = TechnicalAssistanceTypeCapacityBuilding.Instance;
        public static readonly TechnicalAssistanceTypeEducationOutreach EducationOutreach = TechnicalAssistanceTypeEducationOutreach.Instance;
        public static readonly TechnicalAssistanceTypeEngineering Engineering = TechnicalAssistanceTypeEngineering.Instance;
        public static readonly TechnicalAssistanceTypeOperations Operations = TechnicalAssistanceTypeOperations.Instance;
        public static readonly TechnicalAssistanceTypeTechnicalAssistance TechnicalAssistance = TechnicalAssistanceTypeTechnicalAssistance.Instance;

        public static readonly List<TechnicalAssistanceType> All;
        public static readonly ReadOnlyDictionary<int, TechnicalAssistanceType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static TechnicalAssistanceType()
        {
            All = new List<TechnicalAssistanceType> { CapacityBuilding, EducationOutreach, Engineering, Operations, TechnicalAssistance };
            AllLookupDictionary = new ReadOnlyDictionary<int, TechnicalAssistanceType>(All.ToDictionary(x => x.TechnicalAssistanceTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected TechnicalAssistanceType(int technicalAssistanceTypeID, string technicalAssistanceTypeName, string technicalAssistanceTypeDisplayName)
        {
            TechnicalAssistanceTypeID = technicalAssistanceTypeID;
            TechnicalAssistanceTypeName = technicalAssistanceTypeName;
            TechnicalAssistanceTypeDisplayName = technicalAssistanceTypeDisplayName;
        }

        [Key]
        public int TechnicalAssistanceTypeID { get; private set; }
        public string TechnicalAssistanceTypeName { get; private set; }
        public string TechnicalAssistanceTypeDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return TechnicalAssistanceTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(TechnicalAssistanceType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TechnicalAssistanceTypeID == TechnicalAssistanceTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as TechnicalAssistanceType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TechnicalAssistanceTypeID;
        }

        public static bool operator ==(TechnicalAssistanceType left, TechnicalAssistanceType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TechnicalAssistanceType left, TechnicalAssistanceType right)
        {
            return !Equals(left, right);
        }

        public TechnicalAssistanceTypeEnum ToEnum { get { return (TechnicalAssistanceTypeEnum)GetHashCode(); } }

        public static TechnicalAssistanceType ToType(int enumValue)
        {
            return ToType((TechnicalAssistanceTypeEnum)enumValue);
        }

        public static TechnicalAssistanceType ToType(TechnicalAssistanceTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case TechnicalAssistanceTypeEnum.CapacityBuilding:
                    return CapacityBuilding;
                case TechnicalAssistanceTypeEnum.EducationOutreach:
                    return EducationOutreach;
                case TechnicalAssistanceTypeEnum.Engineering:
                    return Engineering;
                case TechnicalAssistanceTypeEnum.Operations:
                    return Operations;
                case TechnicalAssistanceTypeEnum.TechnicalAssistance:
                    return TechnicalAssistance;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TechnicalAssistanceTypeEnum
    {
        CapacityBuilding = 1,
        EducationOutreach = 2,
        Engineering = 3,
        Operations = 4,
        TechnicalAssistance = 5
    }

    public partial class TechnicalAssistanceTypeCapacityBuilding : TechnicalAssistanceType
    {
        private TechnicalAssistanceTypeCapacityBuilding(int technicalAssistanceTypeID, string technicalAssistanceTypeName, string technicalAssistanceTypeDisplayName) : base(technicalAssistanceTypeID, technicalAssistanceTypeName, technicalAssistanceTypeDisplayName) {}
        public static readonly TechnicalAssistanceTypeCapacityBuilding Instance = new TechnicalAssistanceTypeCapacityBuilding(1, @"CapacityBuilding", @"Capacity Building");
    }

    public partial class TechnicalAssistanceTypeEducationOutreach : TechnicalAssistanceType
    {
        private TechnicalAssistanceTypeEducationOutreach(int technicalAssistanceTypeID, string technicalAssistanceTypeName, string technicalAssistanceTypeDisplayName) : base(technicalAssistanceTypeID, technicalAssistanceTypeName, technicalAssistanceTypeDisplayName) {}
        public static readonly TechnicalAssistanceTypeEducationOutreach Instance = new TechnicalAssistanceTypeEducationOutreach(2, @"EducationOutreach", @"Education/Outreach");
    }

    public partial class TechnicalAssistanceTypeEngineering : TechnicalAssistanceType
    {
        private TechnicalAssistanceTypeEngineering(int technicalAssistanceTypeID, string technicalAssistanceTypeName, string technicalAssistanceTypeDisplayName) : base(technicalAssistanceTypeID, technicalAssistanceTypeName, technicalAssistanceTypeDisplayName) {}
        public static readonly TechnicalAssistanceTypeEngineering Instance = new TechnicalAssistanceTypeEngineering(3, @"Engineering", @"Engineering");
    }

    public partial class TechnicalAssistanceTypeOperations : TechnicalAssistanceType
    {
        private TechnicalAssistanceTypeOperations(int technicalAssistanceTypeID, string technicalAssistanceTypeName, string technicalAssistanceTypeDisplayName) : base(technicalAssistanceTypeID, technicalAssistanceTypeName, technicalAssistanceTypeDisplayName) {}
        public static readonly TechnicalAssistanceTypeOperations Instance = new TechnicalAssistanceTypeOperations(4, @"Operations", @"Operations");
    }

    public partial class TechnicalAssistanceTypeTechnicalAssistance : TechnicalAssistanceType
    {
        private TechnicalAssistanceTypeTechnicalAssistance(int technicalAssistanceTypeID, string technicalAssistanceTypeName, string technicalAssistanceTypeDisplayName) : base(technicalAssistanceTypeID, technicalAssistanceTypeName, technicalAssistanceTypeDisplayName) {}
        public static readonly TechnicalAssistanceTypeTechnicalAssistance Instance = new TechnicalAssistanceTypeTechnicalAssistance(5, @"TechnicalAssistance", @"Technical Assistance");
    }
}