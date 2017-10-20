using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartErrorBars
    {
        [JsonProperty(PropertyName = "errorType")]
        public string ErrorType { get; set; }
        [JsonProperty(PropertyName = "magnitude")]
        public int Magnitude { get; set; }
    }
}