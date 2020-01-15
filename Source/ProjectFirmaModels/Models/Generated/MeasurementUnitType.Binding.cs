//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MeasurementUnitType]
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
        public static readonly MeasurementUnitTypeAcreFeet AcreFeet = MeasurementUnitTypeAcreFeet.Instance;
        public static readonly MeasurementUnitTypeGallon Gallon = MeasurementUnitTypeGallon.Instance;
        public static readonly MeasurementUnitTypeCubicYards CubicYards = MeasurementUnitTypeCubicYards.Instance;
        public static readonly MeasurementUnitTypeMetricTons MetricTons = MeasurementUnitTypeMetricTons.Instance;
        public static readonly MeasurementUnitTypeHours Hours = MeasurementUnitTypeHours.Instance;
        public static readonly MeasurementUnitTypeCount Count = MeasurementUnitTypeCount.Instance;
        public static readonly MeasurementUnitTypeFeet Feet = MeasurementUnitTypeFeet.Instance;
        public static readonly MeasurementUnitTypeInches Inches = MeasurementUnitTypeInches.Instance;
        public static readonly MeasurementUnitTypeInchesPerHour InchesPerHour = MeasurementUnitTypeInchesPerHour.Instance;
        public static readonly MeasurementUnitTypeSeconds Seconds = MeasurementUnitTypeSeconds.Instance;
        public static readonly MeasurementUnitTypePerSquareKilometer PerSquareKilometer = MeasurementUnitTypePerSquareKilometer.Instance;
        public static readonly MeasurementUnitTypeCubicFoot_Second CubicFoot_Second = MeasurementUnitTypeCubicFoot_Second.Instance;
        public static readonly MeasurementUnitTypeHectare Hectare = MeasurementUnitTypeHectare.Instance;
        public static readonly MeasurementUnitTypeKilometer Kilometer = MeasurementUnitTypeKilometer.Instance;
        public static readonly MeasurementUnitTypeChemicalConcentrationWetWeight ChemicalConcentrationWetWeight = MeasurementUnitTypeChemicalConcentrationWetWeight.Instance;
        public static readonly MeasurementUnitTypeChemicalConcentrationLipidWeight ChemicalConcentrationLipidWeight = MeasurementUnitTypeChemicalConcentrationLipidWeight.Instance;
        public static readonly MeasurementUnitTypeCanopyBulkDensity CanopyBulkDensity = MeasurementUnitTypeCanopyBulkDensity.Instance;
        public static readonly MeasurementUnitTypeLinearStreamMiles LinearStreamMiles = MeasurementUnitTypeLinearStreamMiles.Instance;
        public static readonly MeasurementUnitTypeCelsius Celsius = MeasurementUnitTypeCelsius.Instance;
        public static readonly MeasurementUnitTypePerSquareMeter PerSquareMeter = MeasurementUnitTypePerSquareMeter.Instance;

        public static readonly List<MeasurementUnitType> All;
        public static readonly ReadOnlyDictionary<int, MeasurementUnitType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static MeasurementUnitType()
        {
            All = new List<MeasurementUnitType> { Acres, Miles, SquareFeet, LinearFeet, Kilogram, Number, Pounds, Tons, Dollars, Parcels, Percent, Therms, PartsPerMillion, PartsPerBillion, MilligamsPerLiter, NephlometricTurbidityUnit, Meters, PeriphytonBiomassIndex, AcreFeet, Gallon, CubicYards, MetricTons, Hours, Count, Feet, Inches, InchesPerHour, Seconds, PerSquareKilometer, CubicFoot_Second, Hectare, Kilometer, ChemicalConcentrationWetWeight, ChemicalConcentrationLipidWeight, CanopyBulkDensity, LinearStreamMiles, Celsius, PerSquareMeter };
            AllLookupDictionary = new ReadOnlyDictionary<int, MeasurementUnitType>(All.ToDictionary(x => x.MeasurementUnitTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected MeasurementUnitType(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits)
        {
            MeasurementUnitTypeID = measurementUnitTypeID;
            MeasurementUnitTypeName = measurementUnitTypeName;
            MeasurementUnitTypeDisplayName = measurementUnitTypeDisplayName;
            LegendDisplayName = legendDisplayName;
            SingularDisplayName = singularDisplayName;
            NumberOfSignificantDigits = numberOfSignificantDigits;
        }

        [Key]
        public int MeasurementUnitTypeID { get; private set; }
        public string MeasurementUnitTypeName { get; private set; }
        public string MeasurementUnitTypeDisplayName { get; private set; }
        public string LegendDisplayName { get; private set; }
        public string SingularDisplayName { get; private set; }
        public int NumberOfSignificantDigits { get; private set; }
        [NotMapped]
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
                case MeasurementUnitTypeEnum.AcreFeet:
                    return AcreFeet;
                case MeasurementUnitTypeEnum.Acres:
                    return Acres;
                case MeasurementUnitTypeEnum.CanopyBulkDensity:
                    return CanopyBulkDensity;
                case MeasurementUnitTypeEnum.Celsius:
                    return Celsius;
                case MeasurementUnitTypeEnum.ChemicalConcentrationLipidWeight:
                    return ChemicalConcentrationLipidWeight;
                case MeasurementUnitTypeEnum.ChemicalConcentrationWetWeight:
                    return ChemicalConcentrationWetWeight;
                case MeasurementUnitTypeEnum.Count:
                    return Count;
                case MeasurementUnitTypeEnum.CubicFoot_Second:
                    return CubicFoot_Second;
                case MeasurementUnitTypeEnum.CubicYards:
                    return CubicYards;
                case MeasurementUnitTypeEnum.Dollars:
                    return Dollars;
                case MeasurementUnitTypeEnum.Feet:
                    return Feet;
                case MeasurementUnitTypeEnum.Gallon:
                    return Gallon;
                case MeasurementUnitTypeEnum.Hectare:
                    return Hectare;
                case MeasurementUnitTypeEnum.Hours:
                    return Hours;
                case MeasurementUnitTypeEnum.Inches:
                    return Inches;
                case MeasurementUnitTypeEnum.InchesPerHour:
                    return InchesPerHour;
                case MeasurementUnitTypeEnum.Kilogram:
                    return Kilogram;
                case MeasurementUnitTypeEnum.Kilometer:
                    return Kilometer;
                case MeasurementUnitTypeEnum.LinearFeet:
                    return LinearFeet;
                case MeasurementUnitTypeEnum.LinearStreamMiles:
                    return LinearStreamMiles;
                case MeasurementUnitTypeEnum.Meters:
                    return Meters;
                case MeasurementUnitTypeEnum.MetricTons:
                    return MetricTons;
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
                case MeasurementUnitTypeEnum.PerSquareKilometer:
                    return PerSquareKilometer;
                case MeasurementUnitTypeEnum.PerSquareMeter:
                    return PerSquareMeter;
                case MeasurementUnitTypeEnum.Pounds:
                    return Pounds;
                case MeasurementUnitTypeEnum.Seconds:
                    return Seconds;
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
        PeriphytonBiomassIndex = 18,
        AcreFeet = 19,
        Gallon = 20,
        CubicYards = 21,
        MetricTons = 22,
        Hours = 23,
        Count = 24,
        Feet = 25,
        Inches = 26,
        InchesPerHour = 27,
        Seconds = 28,
        PerSquareKilometer = 29,
        CubicFoot_Second = 30,
        Hectare = 31,
        Kilometer = 32,
        ChemicalConcentrationWetWeight = 33,
        ChemicalConcentrationLipidWeight = 34,
        CanopyBulkDensity = 35,
        LinearStreamMiles = 36,
        Celsius = 37,
        PerSquareMeter = 38
    }

    public partial class MeasurementUnitTypeAcres : MeasurementUnitType
    {
        private MeasurementUnitTypeAcres(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeAcres Instance = new MeasurementUnitTypeAcres(1, @"Acres", @"Acre (acres)", @"acres", @"Acre", 2);
    }

    public partial class MeasurementUnitTypeMiles : MeasurementUnitType
    {
        private MeasurementUnitTypeMiles(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeMiles Instance = new MeasurementUnitTypeMiles(2, @"Miles", @"Mile (miles)", @"miles", @"Mile", 2);
    }

    public partial class MeasurementUnitTypeSquareFeet : MeasurementUnitType
    {
        private MeasurementUnitTypeSquareFeet(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeSquareFeet Instance = new MeasurementUnitTypeSquareFeet(3, @"SquareFeet", @"Square Foot (sq ft)", @"sq ft", @"Square Foot", 2);
    }

    public partial class MeasurementUnitTypeLinearFeet : MeasurementUnitType
    {
        private MeasurementUnitTypeLinearFeet(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeLinearFeet Instance = new MeasurementUnitTypeLinearFeet(4, @"LinearFeet", @"Linear Foot (lf)", @"lf", @"Linear Foot", 2);
    }

    public partial class MeasurementUnitTypeKilogram : MeasurementUnitType
    {
        private MeasurementUnitTypeKilogram(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeKilogram Instance = new MeasurementUnitTypeKilogram(5, @"Kilogram", @"Kilogram (kg)", @"kg", @"Kilogram", 2);
    }

    public partial class MeasurementUnitTypeNumber : MeasurementUnitType
    {
        private MeasurementUnitTypeNumber(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeNumber Instance = new MeasurementUnitTypeNumber(6, @"Number", @"Each Unit (number)", @"number", @"Each Unit", 0);
    }

    public partial class MeasurementUnitTypePounds : MeasurementUnitType
    {
        private MeasurementUnitTypePounds(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypePounds Instance = new MeasurementUnitTypePounds(7, @"Pounds", @"Pounds (lbs)", @"lbs", @"Pound", 2);
    }

    public partial class MeasurementUnitTypeTons : MeasurementUnitType
    {
        private MeasurementUnitTypeTons(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeTons Instance = new MeasurementUnitTypeTons(8, @"Tons", @"Ton (tons)", @"tons", @"Ton", 2);
    }

    public partial class MeasurementUnitTypeDollars : MeasurementUnitType
    {
        private MeasurementUnitTypeDollars(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeDollars Instance = new MeasurementUnitTypeDollars(9, @"Dollars", @"Dollar ($)", @"$", @"Dollar", 0);
    }

    public partial class MeasurementUnitTypeParcels : MeasurementUnitType
    {
        private MeasurementUnitTypeParcels(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeParcels Instance = new MeasurementUnitTypeParcels(10, @"Parcels", @"Parcel (parcels)", @"parcels", @"Parcel", 0);
    }

    public partial class MeasurementUnitTypePercent : MeasurementUnitType
    {
        private MeasurementUnitTypePercent(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypePercent Instance = new MeasurementUnitTypePercent(11, @"Percent", @"Percent (%)", @"%", @"Percent", 0);
    }

    public partial class MeasurementUnitTypeTherms : MeasurementUnitType
    {
        private MeasurementUnitTypeTherms(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeTherms Instance = new MeasurementUnitTypeTherms(12, @"Therms", @"Therm (therms)", @"therms", @"Therm", 2);
    }

    public partial class MeasurementUnitTypePartsPerMillion : MeasurementUnitType
    {
        private MeasurementUnitTypePartsPerMillion(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypePartsPerMillion Instance = new MeasurementUnitTypePartsPerMillion(13, @"PartsPerMillion", @"Part Per Million (ppm)", @"ppm", @"Part Per Million", 3);
    }

    public partial class MeasurementUnitTypePartsPerBillion : MeasurementUnitType
    {
        private MeasurementUnitTypePartsPerBillion(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypePartsPerBillion Instance = new MeasurementUnitTypePartsPerBillion(14, @"PartsPerBillion", @"Part Per Billion (ppb)", @"ppb", @"Part Per Billion", 3);
    }

    public partial class MeasurementUnitTypeMilligamsPerLiter : MeasurementUnitType
    {
        private MeasurementUnitTypeMilligamsPerLiter(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeMilligamsPerLiter Instance = new MeasurementUnitTypeMilligamsPerLiter(15, @"MilligamsPerLiter", @"Milligram Per Liter (mg/L)", @"mg/L", @"Milligram Per Liter", 2);
    }

    public partial class MeasurementUnitTypeNephlometricTurbidityUnit : MeasurementUnitType
    {
        private MeasurementUnitTypeNephlometricTurbidityUnit(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeNephlometricTurbidityUnit Instance = new MeasurementUnitTypeNephlometricTurbidityUnit(16, @"NephlometricTurbidityUnit", @"Nephlometric Turbidity Unit (ntu)", @"ntu", @"Nephlometric Turbidity Unit", 1);
    }

    public partial class MeasurementUnitTypeMeters : MeasurementUnitType
    {
        private MeasurementUnitTypeMeters(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeMeters Instance = new MeasurementUnitTypeMeters(17, @"Meters", @"Meter (m)", @"m", @"Meter", 1);
    }

    public partial class MeasurementUnitTypePeriphytonBiomassIndex : MeasurementUnitType
    {
        private MeasurementUnitTypePeriphytonBiomassIndex(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypePeriphytonBiomassIndex Instance = new MeasurementUnitTypePeriphytonBiomassIndex(18, @"PeriphytonBiomassIndex", @"Periphyton Biomass Index (pbi)", @"pbi", @"Periphyton biomass index", 0);
    }

    public partial class MeasurementUnitTypeAcreFeet : MeasurementUnitType
    {
        private MeasurementUnitTypeAcreFeet(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeAcreFeet Instance = new MeasurementUnitTypeAcreFeet(19, @"AcreFeet", @"Acre-Foot (acre-feet)", @"acre-ft", @"Acre-Foot", 0);
    }

    public partial class MeasurementUnitTypeGallon : MeasurementUnitType
    {
        private MeasurementUnitTypeGallon(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeGallon Instance = new MeasurementUnitTypeGallon(20, @"Gallon", @"Gallon (gallons)", @"gallons", @"Gallon", 0);
    }

    public partial class MeasurementUnitTypeCubicYards : MeasurementUnitType
    {
        private MeasurementUnitTypeCubicYards(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeCubicYards Instance = new MeasurementUnitTypeCubicYards(21, @"CubicYards", @"Cubic Yard (cubic yards)", @"cubic yards", @"Cubic Yard", 0);
    }

    public partial class MeasurementUnitTypeMetricTons : MeasurementUnitType
    {
        private MeasurementUnitTypeMetricTons(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeMetricTons Instance = new MeasurementUnitTypeMetricTons(22, @"MetricTons", @"Metric Ton (metric tons)", @"metric tons", @"Metric Ton", 0);
    }

    public partial class MeasurementUnitTypeHours : MeasurementUnitType
    {
        private MeasurementUnitTypeHours(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeHours Instance = new MeasurementUnitTypeHours(23, @"Hours", @"Hour (hours)", @"hours", @"Hour", 0);
    }

    public partial class MeasurementUnitTypeCount : MeasurementUnitType
    {
        private MeasurementUnitTypeCount(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeCount Instance = new MeasurementUnitTypeCount(24, @"Count", @"Each Unit (count)", @"count", @"Each Unit", 0);
    }

    public partial class MeasurementUnitTypeFeet : MeasurementUnitType
    {
        private MeasurementUnitTypeFeet(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeFeet Instance = new MeasurementUnitTypeFeet(25, @"Feet", @"Foot (ft)", @"ft", @"Foot", 2);
    }

    public partial class MeasurementUnitTypeInches : MeasurementUnitType
    {
        private MeasurementUnitTypeInches(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeInches Instance = new MeasurementUnitTypeInches(26, @"Inches", @"Inch (in)", @"in", @"inch", 2);
    }

    public partial class MeasurementUnitTypeInchesPerHour : MeasurementUnitType
    {
        private MeasurementUnitTypeInchesPerHour(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeInchesPerHour Instance = new MeasurementUnitTypeInchesPerHour(27, @"InchesPerHour", @"Inches Per Hour (in/hr)", @"in/hr", @"Inches Per Hour", 2);
    }

    public partial class MeasurementUnitTypeSeconds : MeasurementUnitType
    {
        private MeasurementUnitTypeSeconds(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeSeconds Instance = new MeasurementUnitTypeSeconds(28, @"Seconds", @"Second (s)", @"s", @"Second", 0);
    }

    public partial class MeasurementUnitTypePerSquareKilometer : MeasurementUnitType
    {
        private MeasurementUnitTypePerSquareKilometer(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypePerSquareKilometer Instance = new MeasurementUnitTypePerSquareKilometer(29, @"PerSquareKilometer", @"Per Square Kilometer (per sq km)", @"per sq km", @"Per Square Kilometer", 1);
    }

    public partial class MeasurementUnitTypeCubicFoot_Second : MeasurementUnitType
    {
        private MeasurementUnitTypeCubicFoot_Second(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeCubicFoot_Second Instance = new MeasurementUnitTypeCubicFoot_Second(30, @"Cubic Foot / Second", @"Cubic Foot / Second (cfs)", @"cfs", @"Cubic Foot / Second", 2);
    }

    public partial class MeasurementUnitTypeHectare : MeasurementUnitType
    {
        private MeasurementUnitTypeHectare(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeHectare Instance = new MeasurementUnitTypeHectare(31, @"Hectare", @"Hectare (ha)", @"ha", @"Hectare", 0);
    }

    public partial class MeasurementUnitTypeKilometer : MeasurementUnitType
    {
        private MeasurementUnitTypeKilometer(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeKilometer Instance = new MeasurementUnitTypeKilometer(32, @"Kilometer", @"Kilometer (km)", @"km", @"Kilometer", 1);
    }

    public partial class MeasurementUnitTypeChemicalConcentrationWetWeight : MeasurementUnitType
    {
        private MeasurementUnitTypeChemicalConcentrationWetWeight(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeChemicalConcentrationWetWeight Instance = new MeasurementUnitTypeChemicalConcentrationWetWeight(33, @"ChemicalConcentrationWetWeight", @"Chemical Concentration Wet Weight (ng/g wet weight)", @"ng/g wet weight", @"Chemical Concentration Wet Weight", 1);
    }

    public partial class MeasurementUnitTypeChemicalConcentrationLipidWeight : MeasurementUnitType
    {
        private MeasurementUnitTypeChemicalConcentrationLipidWeight(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeChemicalConcentrationLipidWeight Instance = new MeasurementUnitTypeChemicalConcentrationLipidWeight(34, @"ChemicalConcentrationLipidWeight", @"Chemical Concentration Lipid Weight (ng/g lipid weight)", @"ng/g lipid weight", @"Chemical Concentration Lipid Weight", 1);
    }

    public partial class MeasurementUnitTypeCanopyBulkDensity : MeasurementUnitType
    {
        private MeasurementUnitTypeCanopyBulkDensity(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeCanopyBulkDensity Instance = new MeasurementUnitTypeCanopyBulkDensity(35, @"CanopyBulkDensity", @"Canopy Bulk Density (kg/m^3)", @"kg/m^3", @"Canopy Bulk Density", 2);
    }

    public partial class MeasurementUnitTypeLinearStreamMiles : MeasurementUnitType
    {
        private MeasurementUnitTypeLinearStreamMiles(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeLinearStreamMiles Instance = new MeasurementUnitTypeLinearStreamMiles(36, @"LinearStreamMiles", @"Linear Stream Miles", @"linear stream miles", @"Linear Stream Mile", 2);
    }

    public partial class MeasurementUnitTypeCelsius : MeasurementUnitType
    {
        private MeasurementUnitTypeCelsius(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypeCelsius Instance = new MeasurementUnitTypeCelsius(37, @"Celsius", @"Celsius (C)", @"C", @"Celsius", 2);
    }

    public partial class MeasurementUnitTypePerSquareMeter : MeasurementUnitType
    {
        private MeasurementUnitTypePerSquareMeter(int measurementUnitTypeID, string measurementUnitTypeName, string measurementUnitTypeDisplayName, string legendDisplayName, string singularDisplayName, int numberOfSignificantDigits) : base(measurementUnitTypeID, measurementUnitTypeName, measurementUnitTypeDisplayName, legendDisplayName, singularDisplayName, numberOfSignificantDigits) {}
        public static readonly MeasurementUnitTypePerSquareMeter Instance = new MeasurementUnitTypePerSquareMeter(38, @"PerSquareMeter", @"Per Square Meter (per sq m)", @"per sq m", @"Per Square Meter", 2);
    }
}