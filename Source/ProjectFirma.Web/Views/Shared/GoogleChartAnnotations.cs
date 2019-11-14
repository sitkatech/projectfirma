using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public GoogleChartAnnotations(JToken annotation)
        {
            Style = (string)annotation["style"];
        }
    }
}