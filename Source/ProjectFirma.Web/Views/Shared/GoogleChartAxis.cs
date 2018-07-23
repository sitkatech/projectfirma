using ProjectFirma.Web.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartAxis
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "titleTextStyle")]
        public GoogleChartTextStyle TitleTextStyle { get; set; }

        [JsonProperty(PropertyName = "textStyle")]
        public GoogleChartTextStyle TextStyle { get; set; }

        [JsonProperty(PropertyName = "useFormatFromData")]
        public bool UseFormatFromData { get; set; }

        [JsonProperty(PropertyName = "formatOptions", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartFormatOptions FormatOptions { get; set; }

        [JsonProperty(PropertyName = "viewWindow", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartViewWindow ViewWindow { get; set; }

        [JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonProperty(PropertyName = "gridlines", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartGridlinesOptions Gridlines { get; set; }

        public GoogleChartAxis(string title, MeasurementUnitTypeEnum? measurementUnitTypeEnum, GoogleChartAxisLabelFormat? googleChartAxisLabelFormat)
        {
            Title = title;
            TitleTextStyle = new GoogleChartTextStyle();
            UseFormatFromData = true;
            Format = googleChartAxisLabelFormat.ToString().ToLower();
            FormatOptions = new GoogleChartFormatOptions(measurementUnitTypeEnum);
            ViewWindow = null;
        }
    }
}
