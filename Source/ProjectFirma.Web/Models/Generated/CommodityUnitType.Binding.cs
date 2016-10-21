//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityUnitType]
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
    public abstract partial class CommodityUnitType : IHavePrimaryKey
    {
        public static readonly CommodityUnitTypeUnits Units = CommodityUnitTypeUnits.Instance;
        public static readonly CommodityUnitTypeSquareFootage SquareFootage = CommodityUnitTypeSquareFootage.Instance;

        public static readonly List<CommodityUnitType> All;
        public static readonly ReadOnlyDictionary<int, CommodityUnitType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static CommodityUnitType()
        {
            All = new List<CommodityUnitType> { Units, SquareFootage };
            AllLookupDictionary = new ReadOnlyDictionary<int, CommodityUnitType>(All.ToDictionary(x => x.CommodityUnitTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected CommodityUnitType(int commodityUnitTypeID, string commodityUnitTypeName, string commodityUnitTypeDisplayName, string commodityUnitTypeNameSingular)
        {
            CommodityUnitTypeID = commodityUnitTypeID;
            CommodityUnitTypeName = commodityUnitTypeName;
            CommodityUnitTypeDisplayName = commodityUnitTypeDisplayName;
            CommodityUnitTypeNameSingular = commodityUnitTypeNameSingular;
        }
        public List<Commodity> Commodities { get { return Commodity.All.Where(x => x.CommodityUnitTypeID == CommodityUnitTypeID).ToList(); } }
        [Key]
        public int CommodityUnitTypeID { get; private set; }
        public string CommodityUnitTypeName { get; private set; }
        public string CommodityUnitTypeDisplayName { get; private set; }
        public string CommodityUnitTypeNameSingular { get; private set; }
        public int PrimaryKey { get { return CommodityUnitTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(CommodityUnitType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.CommodityUnitTypeID == CommodityUnitTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as CommodityUnitType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return CommodityUnitTypeID;
        }

        public static bool operator ==(CommodityUnitType left, CommodityUnitType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CommodityUnitType left, CommodityUnitType right)
        {
            return !Equals(left, right);
        }

        public CommodityUnitTypeEnum ToEnum { get { return (CommodityUnitTypeEnum)GetHashCode(); } }

        public static CommodityUnitType ToType(int enumValue)
        {
            return ToType((CommodityUnitTypeEnum)enumValue);
        }

        public static CommodityUnitType ToType(CommodityUnitTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case CommodityUnitTypeEnum.SquareFootage:
                    return SquareFootage;
                case CommodityUnitTypeEnum.Units:
                    return Units;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum CommodityUnitTypeEnum
    {
        Units = 1,
        SquareFootage = 2
    }

    public partial class CommodityUnitTypeUnits : CommodityUnitType
    {
        private CommodityUnitTypeUnits(int commodityUnitTypeID, string commodityUnitTypeName, string commodityUnitTypeDisplayName, string commodityUnitTypeNameSingular) : base(commodityUnitTypeID, commodityUnitTypeName, commodityUnitTypeDisplayName, commodityUnitTypeNameSingular) {}
        public static readonly CommodityUnitTypeUnits Instance = new CommodityUnitTypeUnits(1, @"Units", @"units", @"unit");
    }

    public partial class CommodityUnitTypeSquareFootage : CommodityUnitType
    {
        private CommodityUnitTypeSquareFootage(int commodityUnitTypeID, string commodityUnitTypeName, string commodityUnitTypeDisplayName, string commodityUnitTypeNameSingular) : base(commodityUnitTypeID, commodityUnitTypeName, commodityUnitTypeDisplayName, commodityUnitTypeNameSingular) {}
        public static readonly CommodityUnitTypeSquareFootage Instance = new CommodityUnitTypeSquareFootage(2, @"SquareFootage", @"square footage", @"square foot");
    }
}