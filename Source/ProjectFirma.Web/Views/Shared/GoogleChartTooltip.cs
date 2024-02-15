using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartTooltip
    {
        [JsonProperty(PropertyName = "isHtml")]
        public bool IsHtml { get; set; }

        //showColorCode
        [JsonProperty(PropertyName = "showColorCode")]
        public bool ShowColorCode { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public GoogleChartTooltip()
        {
        }

        public GoogleChartTooltip(bool isHtml)
        {
            IsHtml = isHtml;
        }
    }
}