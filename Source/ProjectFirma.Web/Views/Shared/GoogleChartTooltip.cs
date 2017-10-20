using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartTooltip
    {
        [JsonProperty(PropertyName = "isHtml")]
        public bool IsHtml { get; set; }

        public GoogleChartTooltip()
        {
        }

        public GoogleChartTooltip(bool isHtml)
        {
            IsHtml = isHtml;
        }
    }
}