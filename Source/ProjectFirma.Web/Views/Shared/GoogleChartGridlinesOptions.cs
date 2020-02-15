using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartGridlinesOptions
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        public GoogleChartGridlinesOptions()
        {
        }

        public GoogleChartGridlinesOptions(int count, string color)
        {
            Count = count;
            Color = color;
        }
    }
}
