using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GooglePieChartSlice
    {
        [JsonIgnore]
        public int SortOrder { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
        [JsonProperty(PropertyName = "textStyle")]
        public GoogleChartTextStyle TextStyle { get; set; }
        [JsonIgnore]
        public string Label { get; set; }
        [JsonProperty(PropertyName = "ValueKey")]
        public double Value { get; set; }

        //For Deserialization
        public GooglePieChartSlice()
        {
        }

        public GooglePieChartSlice(string label, double value, int sortOrder, string color)
        {
            Label = label;
            Value = value;
            SortOrder = sortOrder;
            Color = color;
        }

        public GooglePieChartSlice(string label, double value, int sortOrder, string color, GoogleChartTextStyle textStyle)
        {
            Label = label;
            Value = value;
            SortOrder = sortOrder;
            Color = color;
            TextStyle = textStyle;
        }
    }
}