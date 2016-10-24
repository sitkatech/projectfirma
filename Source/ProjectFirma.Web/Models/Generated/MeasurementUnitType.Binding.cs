//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MeasurementUnitType]
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
    public abstract partial class MeasurementUnitType : IHavePrimaryKey
    {
        public static readonly MeasurementUnitTypeAcres Acres = MeasurementUnitTypeAcres.Instance;
        public static readonly MeasurementUnitTypeMiles Miles = MeasurementUnitTypeMiles.Instance;
        public static readonly MeasurementUnitTypeSquareFeet SquareFeet = MeasurementUnitTypeSquareFeet.Instance;
        public static readonly MeasurementUnitTypeLinearFeet LinearFeet = MeasurementUnitTypeLinearFeet.Instance;
        public static readonly MeasurementUnitTypeKilogram Kilogram = MeasurementUnitTypeKilogram.Instance;
        public static readonly MeasurementUnitTypeNumber Number = MeasurementUnitTypeNumber.Instance;
        public static readonly MeasurementUnitTypePounds Pounds = MeasurementUnitTypePounds.Instance;
        public static readonly MeasurementUnitTypeTons Tons = MeasurementUnitTypeTons.Instance;
        public static readonly MeasurementUnitTypeDollars Dollars = MeasurementUnitTypeDollars.Instance;
        public static readonly MeasurementUnitTypeParcels Parcels = MeasurementUnitTypeParcels.Instance;
        public static readonly MeasurementUnitTypePercent Percent = MeasurementUnitTypePercent.Instance;
        public static readonly MeasurementUnitTypeTherms Therms = MeasurementUnitTypeTherms.Instance;
        public static readonly MeasurementUnitTypePartsPerMillion PartsPerMillion = MeasurementUnitTypePartsPerMillion.Instance;
        public static readonly MeasurementUnitTypePartsPerBillion PartsPerBillion = MeasurementUnitTypePartsPerBillion.Instance;
        public static readonly MeasurementUnitTypeMilligamsPerLiter MilligamsPerLiter = MeasurementUnitTypeMilligamsPerLiter.Instance;
        public static readonly MeasurementUnitTypeNephlometricTurbidityUnit NephlometricTurbidityUnit = MeasurementUnitTypeNephlometricTurbidityUnit.Instance;
        public static readonly MeasurementUnitTypeMeters Meters = MeasurementUnitTypeMeters.Instance;
        public static readonly MeasurementUnitTypePeriphytonBiomassIndex PeriphytonBiomassIndex = MeasurementUnitTypePeriphytonBiomassIndex.Instance;

        public static readonly List<MeasurementUnitType> All;
        public static readonly ReadOnlyDictionary<int, MeasurementUnitType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static MeasurementUnitType()
        {
            All = new List<MeasurementUnitType> { Acres, Miles, SquareFeet, LinearFeet, Kilogram, Number, Pounds, Tons, Dollars, Parcels, Percent, Therms, PartsPerMillion, PartsPerBillion, MilligamsPerLiter, NephlometricTurbidityUnit, Meters, PeriphytonBiomassIndex };
            AllLookupDictionary = new ReadOnlyDictionary<int, MeasurementUnitType>(All.ToDictionary(x => x.MeasurementUnitTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected MeasurementUnitType(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName)
        {
            MeasurementUnitTypeID = measurementUnitTypeID;
            MeasurementUnitTypeName = measurementUnitTypeName;
            MeasurementUnitTypeDisplayName = measurementUnitTypeDisplayName;
            LegendDisplayName = legendDisplayName;
            SingularDisplayName = singularDisplayName;
        }

        [Key]
        public int MeasurementUnitTypeID { get; private set; }
        public string MeasurementUnitTypeName { get; private set; }
        public string MeasurementUnitTypeDisplayName { get; private set; }
        public string LegendDisplayName { get; private set; }
        public string SingularDisplayName { get; private set; }
        public int PrimaryKey { get { return MeasurementUnitTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(MeasurementUnitType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.MeasurementUnitTypeID == MeasurementUnitTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as MeasurementUnitType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return MeasurementUnitTypeID;
        }

        public static bool operator ==(MeasurementUnitType left, MeasurementUnitType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MeasurementUnitType left, MeasurementUnitType right)
        {
            return !Equals(left, right);
        }

        public MeasurementUnitTypeEnum ToEnum { get { return (MeasurementUnitTypeEnum)GetHashCode(); } }

        public static MeasurementUnitType ToType(int enumValue)
        {
            return ToType((MeasurementUnitTypeEnum)enumValue);
        }

        public static MeasurementUnitType ToType(MeasurementUnitTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case MeasurementUnitTypeEnum.Acres:
                    return Acres;
                case MeasurementUnitTypeEnum.Dollars:
                    return Dollars;
                case MeasurementUnitTypeEnum.Kilogram:
                    return Kilogram;
                case MeasurementUnitTypeEnum.LinearFeet:
                    return LinearFeet;
                case MeasurementUnitTypeEnum.Meters:
                    return Meters;
                case MeasurementUnitTypeEnum.Miles:
                    return Miles;
                case MeasurementUnitTypeEnum.MilligamsPerLiter:
                    return MilligamsPerLiter;
                case MeasurementUnitTypeEnum.NephlometricTurbidityUnit:
                    return NephlometricTurbidityUnit;
                case MeasurementUnitTypeEnum.Number:
                    return Number;
                case MeasurementUnitTypeEnum.Parcels:
                    return Parcels;
                case MeasurementUnitTypeEnum.PartsPerBillion:
                    return PartsPerBillion;
                case MeasurementUnitTypeEnum.PartsPerMillion:
                    return PartsPerMillion;
                case MeasurementUnitTypeEnum.Percent:
                    return Percent;
                case MeasurementUnitTypeEnum.PeriphytonBiomassIndex:
                    return PeriphytonBiomassIndex;
                case MeasurementUnitTypeEnum.Pounds:
                    return Pounds;
                case MeasurementUnitTypeEnum.SquareFeet:
                    return SquareFeet;
                case MeasurementUnitTypeEnum.Therms:
                    return Therms;
                case MeasurementUnitTypeEnum.Tons:
                    return Tons;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum MeasurementUnitTypeEnum
    {
        Acres = 1,
        Miles = 2,
        SquareFeet = 3,
        LinearFeet = 4,
        Kilogram = 5,
        Number = 6,
        Pounds = 7,
        Tons = 8,
        Dollars = 9,
        Parcels = 10,
        Percent = 11,
        Therms = 12,
        PartsPerMillion = 13,
        PartsPerBillion = 14,
        MilligamsPerLiter = 15,
        NephlometricTurbidityUnit = 16,
        Meters = 17,
        PeriphytonBiomassIndex = 18
    }

    public partial class MeasurementUnitTypeAcres : MeasurementUnitType
    {
        private MeasurementUnitTypeAcres(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeAcres Instance = new MeasurementUnitTypeAcres(1, @"Acres", @"acres", @"acres", @"Acre");
    }

    public partial class MeasurementUnitTypeMiles : MeasurementUnitType
    {
        private MeasurementUnitTypeMiles(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeMiles Instance = new MeasurementUnitTypeMiles(2, @"Miles", @"miles", @"miles", @"Mile");
    }

    public partial class MeasurementUnitTypeSquareFeet : MeasurementUnitType
    {
        private MeasurementUnitTypeSquareFeet(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeSquareFeet Instance = new MeasurementUnitTypeSquareFeet(3, @"SquareFeet", @"square feet", @"sq ft", @"Square Foot");
    }

    public partial class MeasurementUnitTypeLinearFeet : MeasurementUnitType
    {
        private MeasurementUnitTypeLinearFeet(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeLinearFeet Instance = new MeasurementUnitTypeLinearFeet(4, @"LinearFeet", @"linear feet", @"lf", @"Linear Foot");
    }

    public partial class MeasurementUnitTypeKilogram : MeasurementUnitType
    {
        private MeasurementUnitTypeKilogram(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeKilogram Instance = new MeasurementUnitTypeKilogram(5, @"Kilogram", @"kg", @"kg", @"Kilogram");
    }

    public partial class MeasurementUnitTypeNumber : MeasurementUnitType
    {
        private MeasurementUnitTypeNumber(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeNumber Instance = new MeasurementUnitTypeNumber(6, @"Number", @"number", null, @"Each Unit");
    }

    public partial class MeasurementUnitTypePounds : MeasurementUnitType
    {
        private MeasurementUnitTypePounds(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypePounds Instance = new MeasurementUnitTypePounds(7, @"Pounds", @"pounds", @"lbs", @"Pound");
    }

    public partial class MeasurementUnitTypeTons : MeasurementUnitType
    {
        private MeasurementUnitTypeTons(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeTons Instance = new MeasurementUnitTypeTons(8, @"Tons", @"tons", @"tons", @"Ton");
    }

    public partial class MeasurementUnitTypeDollars : MeasurementUnitType
    {
        private MeasurementUnitTypeDollars(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeDollars Instance = new MeasurementUnitTypeDollars(9, @"Dollars", @"dollars", null, @"Dollar");
    }

    public partial class MeasurementUnitTypeParcels : MeasurementUnitType
    {
        private MeasurementUnitTypeParcels(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeParcels Instance = new MeasurementUnitTypeParcels(10, @"Parcels", @"parcels", null, @"Parcel");
    }

    public partial class MeasurementUnitTypePercent : MeasurementUnitType
    {
        private MeasurementUnitTypePercent(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypePercent Instance = new MeasurementUnitTypePercent(11, @"Percent", @"%", @"%", @"%");
    }

    public partial class MeasurementUnitTypeTherms : MeasurementUnitType
    {
        private MeasurementUnitTypeTherms(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeTherms Instance = new MeasurementUnitTypeTherms(12, @"Therms", @"therms", @"therms", @"Therm");
    }

    public partial class MeasurementUnitTypePartsPerMillion : MeasurementUnitType
    {
        private MeasurementUnitTypePartsPerMillion(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypePartsPerMillion Instance = new MeasurementUnitTypePartsPerMillion(13, @"PartsPerMillion", @"ppm", @"ppm", @"Part Per Million");
    }

    public partial class MeasurementUnitTypePartsPerBillion : MeasurementUnitType
    {
        private MeasurementUnitTypePartsPerBillion(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypePartsPerBillion Instance = new MeasurementUnitTypePartsPerBillion(14, @"PartsPerBillion", @"ppb", @"ppb", @"Part Per Billion");
    }

    public partial class MeasurementUnitTypeMilligamsPerLiter : MeasurementUnitType
    {
        private MeasurementUnitTypeMilligamsPerLiter(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeMilligamsPerLiter Instance = new MeasurementUnitTypeMilligamsPerLiter(15, @"MilligamsPerLiter", @"mg/L", @"mg/L", @"Milligram Per Liter");
    }

    public partial class MeasurementUnitTypeNephlometricTurbidityUnit : MeasurementUnitType
    {
        private MeasurementUnitTypeNephlometricTurbidityUnit(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeNephlometricTurbidityUnit Instance = new MeasurementUnitTypeNephlometricTurbidityUnit(16, @"NephlometricTurbidityUnit", @"NTU", @"NTU", @"Nephlometric Turbidity Unit");
    }

    public partial class MeasurementUnitTypeMeters : MeasurementUnitType
    {
        private MeasurementUnitTypeMeters(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypeMeters Instance = new MeasurementUnitTypeMeters(17, @"Meters", @"meters", @"meters", @"Meter");
    }

    public partial class MeasurementUnitTypePeriphytonBiomassIndex : MeasurementUnitType
    {
        private MeasurementUnitTypePeriphytonBiomassIndex(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName) {}
        public static readonly MeasurementUnitTypePeriphytonBiomassIndex Instance = new MeasurementUnitTypePeriphytonBiomassIndex(18, @"PeriphytonBiomassIndex", @"PBI", @"PBI", @"Periphyton biomass index");
    }
}