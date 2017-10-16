using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartConfigurationArea
    {
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public object Width { get; set; }

        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public object Height { get; set; }

        [JsonProperty(PropertyName = "left", NullValueHandling = NullValueHandling.Ignore)]
        public int? Left { get; set; }

        [JsonProperty(PropertyName = "top", NullValueHandling = NullValueHandling.Ignore)]
        public int? Top { get; set; }

        [JsonProperty(PropertyName = "backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartBackground BackgroundColor { get; set; }

        public GoogleChartConfigurationArea()
        {
        }

        public GoogleChartConfigurationArea(int left, int top)
        {
            Left = left;
            Top = top;
            Width = "100%";
            Height = "100%";
        }

        public GoogleChartConfigurationArea(int width, int height, int left, int top)
        {
            Width = width;
            Height = height;
            Left = left;
            Top = top;
        }
    }
}