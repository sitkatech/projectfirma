using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartAnnotations
    {
        [JsonProperty(PropertyName = "style")]
        public string Style { get; set; }
        public GoogleChartAnnotations()
        {
            Style = "line";
        }
    }
}