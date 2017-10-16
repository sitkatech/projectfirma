using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartDomainAxis
    {
        [JsonProperty(PropertyName = "direction")]
        public int Direction { get; set; }

        public void SetToReversed()
        {
            Direction = -1;
        }

        public void SetToNormal()
        {
            Direction = 1;
        }
    }
}