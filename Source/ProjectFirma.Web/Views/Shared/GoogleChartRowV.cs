using System;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartRowVDate : GoogleChartRowV
    {
        [JsonProperty(PropertyName = "v")]
        public new DateTime Value { get; set; }

        public GoogleChartRowVDate(DateTime value, string format)
        {
            Value = value;
            Format = format;
        }

        public GoogleChartRowVDate(DateTime value) : this(value, null)
        {
        }
    }

    public class GoogleChartRowV
    {
        [JsonProperty(PropertyName = "v")]
        public object Value { get; set; }

        [JsonProperty(PropertyName = "f", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        /// <summary>
        /// Needed to deserialize json
        /// </summary>
        public GoogleChartRowV()
        {
        }

        public GoogleChartRowV(object value, string format)
        {
            Value = value;
            Format = format;
        }

        public GoogleChartRowV(object value) : this(value, null)
        {
        }
    }
}