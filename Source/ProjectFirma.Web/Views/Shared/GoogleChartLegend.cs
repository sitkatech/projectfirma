using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartLegend
    {
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
        [JsonProperty(PropertyName = "maxLines", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxLines { get; set; }

        public void SetLegendPosition(GoogleChartLegendPosition? legendPosition)
        {
            switch (legendPosition)
            {
                case GoogleChartLegendPosition.Top:
                    Position = "top";
                    break;
                case GoogleChartLegendPosition.Bottom:
                    Position = "bottom";
                    break;
                case GoogleChartLegendPosition.Left:
                    Position = "left";
                    break;
                case GoogleChartLegendPosition.Right:
                    Position = "right";
                    break;
                case GoogleChartLegendPosition.None:
                    Position = "none";
                    break;
                default:
                    Position = null;
                    break;
            }
        }

        public static implicit operator string(GoogleChartLegend legend)
        {
            return legend.Position;
        }

        public static implicit operator GoogleChartLegend(string legend)
        {
            return new GoogleChartLegend { Position = legend };
        }
    }
}