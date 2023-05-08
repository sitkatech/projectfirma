using System;
using System.Collections.Generic;
using ProjectFirmaModels.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProjectFirma.Web.Views.Shared
{
    public class GooglePieChartConfiguration : GoogleChartConfiguration
    {
        [JsonProperty(PropertyName = "slices")]
        public List<GooglePieChartSlice> Slices { get; set; }
        [JsonProperty(PropertyName = "pieSliceTextStyle")]
        public GoogleChartTextStyle PieSliceTextStyle { get; set; }
        [JsonProperty(PropertyName = "pieSliceText")]
        public string PieSliceText { get; set; }
        [JsonProperty(PropertyName = "pieHole")]
        public double PieHole { get; set; }

        public GooglePieChartConfiguration(string chartTitle,
            MeasurementUnitTypeEnum measurementUnitTypeEnum,
            List<GooglePieChartSlice> googlePieChartSlices,
            GoogleChartType googleChartType,
            GoogleChartDataTable googleChartDataTable) : this(chartTitle, measurementUnitTypeEnum, googlePieChartSlices, googleChartType, googleChartDataTable, new GoogleChartTextStyle("black"), new GoogleChartConfigurationArea(10, 10))
        {
        }

        public GooglePieChartConfiguration(string chartTitle,
            MeasurementUnitTypeEnum measurementUnitTypeEnum,
            List<GooglePieChartSlice> googlePieChartSlices,
            GoogleChartType googleChartType,
            GoogleChartDataTable googleChartDataTable,
            GoogleChartTextStyle googleChartTextStyle,
            GoogleChartConfigurationArea googleChartConfigurationArea) : base(chartTitle,
            true,
            googleChartType,
            googleChartDataTable,
            new GoogleChartAxis("Year", null, null),
            new List<GoogleChartAxis> {new GoogleChartAxis(null, measurementUnitTypeEnum, null)})
        {
            PieSliceTextStyle = googleChartTextStyle;
            ChartArea = googleChartConfigurationArea;
            Slices = googlePieChartSlices;
        }

        public GooglePieChartConfiguration()
        {
        }

        public class ConfigurationConverter : CustomCreationConverter<GoogleChartConfiguration>
        {
            public override GoogleChartConfiguration Create(Type objectType)
            {
                return new GooglePieChartConfiguration();
            }
        }
    }
}