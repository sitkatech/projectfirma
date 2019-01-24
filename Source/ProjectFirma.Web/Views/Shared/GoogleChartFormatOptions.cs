using System;
using ProjectFirmaModels.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartFormatOptions
    {
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }
        [JsonProperty(PropertyName = "prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }
        [JsonProperty(PropertyName = "suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }

        public GoogleChartFormatOptions(MeasurementUnitTypeEnum? measurementUnitTypeEnum)
        {
            switch (measurementUnitTypeEnum)
            {
                case MeasurementUnitTypeEnum.Dollars:
                    Prefix = "$";
                    break;
                case MeasurementUnitTypeEnum.Percent:
                    Suffix = "%";
                    break;
                case MeasurementUnitTypeEnum.Acres:
                case MeasurementUnitTypeEnum.Miles:
                case MeasurementUnitTypeEnum.SquareFeet:
                case MeasurementUnitTypeEnum.LinearFeet:
                case MeasurementUnitTypeEnum.Kilogram:
                case MeasurementUnitTypeEnum.Number:
                case MeasurementUnitTypeEnum.Pounds:
                case MeasurementUnitTypeEnum.Tons:
                case MeasurementUnitTypeEnum.Parcels:
                case MeasurementUnitTypeEnum.Therms:
                case MeasurementUnitTypeEnum.PartsPerMillion:
                case MeasurementUnitTypeEnum.PartsPerBillion:
                case MeasurementUnitTypeEnum.MilligamsPerLiter:
                case MeasurementUnitTypeEnum.NephlometricTurbidityUnit:
                case MeasurementUnitTypeEnum.Meters:
                case MeasurementUnitTypeEnum.PeriphytonBiomassIndex:
                case MeasurementUnitTypeEnum.AcreFeet:
                case MeasurementUnitTypeEnum.Gallon:
                case MeasurementUnitTypeEnum.CubicYards:
                case null:
                    Source = "inline";
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(measurementUnitTypeEnum), measurementUnitTypeEnum, null);
            }
        }
    }
}