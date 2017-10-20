using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartViewWindow
    {
        [JsonProperty(PropertyName = "min", NullValueHandling = NullValueHandling.Ignore)]
        public int MinValue { get; set; }
    }
}