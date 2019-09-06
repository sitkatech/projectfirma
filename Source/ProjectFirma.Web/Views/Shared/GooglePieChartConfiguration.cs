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

        public GooglePieChartConfiguration(string chartTitle,
            MeasurementUnitTypeEnum measurementUnitTypeEnum,
            List<GooglePieChartSlice> googlePieChartSlices,
            GoogleChartType googleChartType,
            GoogleChartDataTable googleChartDataTable) : base(chartTitle,
            true,
            googleChartType,
            googleChartDataTable,
            new GoogleChartAxis("Year", null, null),
            new List<GoogleChartAxis> {new GoogleChartAxis(null, measurementUnitTypeEnum, null)})
        {
            PieSliceTextStyle = new GoogleChartTextStyle("black");
            ChartArea = new GoogleChartConfigurationArea(10, 10);
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