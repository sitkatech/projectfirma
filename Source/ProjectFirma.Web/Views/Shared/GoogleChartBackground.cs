using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartBackground
    {
        [JsonProperty(PropertyName = "fill")]
        public string Fill { get; set; }

        [JsonProperty(PropertyName = "stroke", NullValueHandling = NullValueHandling.Ignore)]
        public string Stroke { get; set; }

        [JsonProperty(PropertyName = "strokeWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int? StrokeWidth { get; set; }

        public GoogleChartBackground()
        {
        }

        public GoogleChartBackground(string fill)
        {
            Fill = fill;
        }
    }
}