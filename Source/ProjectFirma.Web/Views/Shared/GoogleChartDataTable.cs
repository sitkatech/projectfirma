using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartColumnDataType
    {
        public string ColumnDataType { get; private set; }

        private GoogleChartColumnDataType(string columnDataType)
        {
            ColumnDataType = columnDataType;
        }

        public override string ToString()
        {
            return ColumnDataType;
        }

        public static readonly GoogleChartColumnDataType String = new GoogleChartColumnDataType("string");
        public static readonly GoogleChartColumnDataType Number = new GoogleChartColumnDataType("number");
    }

    public class GoogleChartDataTable
    {
        [JsonProperty(PropertyName = "cols")]
        public List<GoogleChartColumn> GoogleChartColumns { get; set; }
        [JsonProperty(PropertyName = "rows")]
        public List<GoogleChartRowC> GoogleChartRowCs { get; set; }
        
        public GoogleChartDataTable(List<GoogleChartColumn> googleChartColumns, List<GoogleChartRowC> googleChartRowCs)
        {
            GoogleChartColumns = googleChartColumns;
            GoogleChartRowCs = googleChartRowCs;
        }
    }

    public class GoogleChartColumn
    {
        [JsonProperty(PropertyName = "id")]
        public string ColumnID { get; set; }
        [JsonProperty(PropertyName = "label")]
        public string ColumnLabel { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string ColumnDataType { get; set; }
        [JsonIgnore]
        public GoogleChartType ColumnDisplayType { get; set; }
        [JsonIgnore]
        public GoogleChartAxisType AxisType { get; set; }

        public GoogleChartColumn(string columnLabel, GoogleChartColumnDataType googleChartColumnDataType, GoogleChartType googleChartType)
            : this(columnLabel, columnLabel, googleChartColumnDataType.ColumnDataType, googleChartType, GoogleChartAxisType.Primary)
        {
        }

        public GoogleChartColumn(string columnID, string columnLabel, string columnDataType, GoogleChartType columnDisplayType, GoogleChartAxisType axisType)
        {
            ColumnID = columnID;
            ColumnLabel = columnLabel;
            ColumnDataType = columnDataType;
            ColumnDisplayType = columnDisplayType;
            AxisType = axisType;
        }
    }

    public class GoogleChartRowC
    {
        [JsonProperty(PropertyName = "c")]
        public List<GoogleChartRowV> GoogleChartRowVs;

        public GoogleChartRowC(List<GoogleChartRowV> googleChartRowVs)
        {
            GoogleChartRowVs = googleChartRowVs;
        }
    }

    public class GoogleChartRowV
    {
        [JsonProperty(PropertyName = "v")]
        public object Value;
        [JsonProperty(PropertyName = "f", NullValueHandling = NullValueHandling.Ignore)]
        public string Format;

        public GoogleChartRowV(object value, string format)
        {
            Value = value;
            Format = format;
        }

        public GoogleChartRowV(object value) : this (value, null)
        {
        }
    }
}