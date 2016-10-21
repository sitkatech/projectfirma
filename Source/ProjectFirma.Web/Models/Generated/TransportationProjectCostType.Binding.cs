//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationProjectCostType]
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
    public abstract partial class TransportationProjectCostType : IHavePrimaryKey
    {
        public static readonly TransportationProjectCostTypePreliminaryEngineering PreliminaryEngineering = TransportationProjectCostTypePreliminaryEngineering.Instance;
        public static readonly TransportationProjectCostTypeRightOfWay RightOfWay = TransportationProjectCostTypeRightOfWay.Instance;
        public static readonly TransportationProjectCostTypeConstruction Construction = TransportationProjectCostTypeConstruction.Instance;

        public static readonly List<TransportationProjectCostType> All;
        public static readonly ReadOnlyDictionary<int, TransportationProjectCostType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static TransportationProjectCostType()
        {
            All = new List<TransportationProjectCostType> { PreliminaryEngineering, RightOfWay, Construction };
            AllLookupDictionary = new ReadOnlyDictionary<int, TransportationProjectCostType>(All.ToDictionary(x => x.TransportationProjectCostTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected TransportationProjectCostType(int transportationProjectCostTypeID, string transportationProjectCostTypeName, string transportationProjectCostTypeDisplayName, int sortOrder)
        {
            TransportationProjectCostTypeID = transportationProjectCostTypeID;
            TransportationProjectCostTypeName = transportationProjectCostTypeName;
            TransportationProjectCostTypeDisplayName = transportationProjectCostTypeDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int TransportationProjectCostTypeID { get; private set; }
        public string TransportationProjectCostTypeName { get; private set; }
        public string TransportationProjectCostTypeDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public int PrimaryKey { get { return TransportationProjectCostTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(TransportationProjectCostType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.TransportationProjectCostTypeID == TransportationProjectCostTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as TransportationProjectCostType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return TransportationProjectCostTypeID;
        }

        public static bool operator ==(TransportationProjectCostType left, TransportationProjectCostType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TransportationProjectCostType left, TransportationProjectCostType right)
        {
            return !Equals(left, right);
        }

        public TransportationProjectCostTypeEnum ToEnum { get { return (TransportationProjectCostTypeEnum)GetHashCode(); } }

        public static TransportationProjectCostType ToType(int enumValue)
        {
            return ToType((TransportationProjectCostTypeEnum)enumValue);
        }

        public static TransportationProjectCostType ToType(TransportationProjectCostTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case TransportationProjectCostTypeEnum.Construction:
                    return Construction;
                case TransportationProjectCostTypeEnum.PreliminaryEngineering:
                    return PreliminaryEngineering;
                case TransportationProjectCostTypeEnum.RightOfWay:
                    return RightOfWay;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum TransportationProjectCostTypeEnum
    {
        PreliminaryEngineering = 1,
        RightOfWay = 2,
        Construction = 3
    }

    public partial class TransportationProjectCostTypePreliminaryEngineering : TransportationProjectCostType
    {
        private TransportationProjectCostTypePreliminaryEngineering(int transportationProjectCostTypeID, string transportationProjectCostTypeName, string transportationProjectCostTypeDisplayName, int sortOrder) : base(transportationProjectCostTypeID, transportationProjectCostTypeName, transportationProjectCostTypeDisplayName, sortOrder) {}
        public static readonly TransportationProjectCostTypePreliminaryEngineering Instance = new TransportationProjectCostTypePreliminaryEngineering(1, @"PreliminaryEngineering", @"Preliminary Engineering", 10);
    }

    public partial class TransportationProjectCostTypeRightOfWay : TransportationProjectCostType
    {
        private TransportationProjectCostTypeRightOfWay(int transportationProjectCostTypeID, string transportationProjectCostTypeName, string transportationProjectCostTypeDisplayName, int sortOrder) : base(transportationProjectCostTypeID, transportationProjectCostTypeName, transportationProjectCostTypeDisplayName, sortOrder) {}
        public static readonly TransportationProjectCostTypeRightOfWay Instance = new TransportationProjectCostTypeRightOfWay(2, @"RightOfWay", @"Right of Way (aka Land Acquisition)", 20);
    }

    public partial class TransportationProjectCostTypeConstruction : TransportationProjectCostType
    {
        private TransportationProjectCostTypeConstruction(int transportationProjectCostTypeID, string transportationProjectCostTypeName, string transportationProjectCostTypeDisplayName, int sortOrder) : base(transportationProjectCostTypeID, transportationProjectCostTypeName, transportationProjectCostTypeDisplayName, sortOrder) {}
        public static readonly TransportationProjectCostTypeConstruction Instance = new TransportationProjectCostTypeConstruction(3, @"Construction", @"Construction", 30);
    }
}