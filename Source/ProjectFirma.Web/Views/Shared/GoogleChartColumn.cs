using ProjectFirmaModels.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartColumn
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnID { get; set; }

        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnLabel { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnDataType { get; set; }

        [JsonIgnore]
        public GoogleChartSeries GoogleChartSeries { get; set; }

        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnDataRole { get; set; }

        [JsonProperty(PropertyName = "sourceColumn", NullValueHandling = NullValueHandling.Ignore)]
        public int? SourceColumn { get; set; }

        [JsonProperty(PropertyName = "p")]
        public GoogleChartProperty ColumnProperty { get; set; }

        /// <summary>
        /// Needed to deserialize json
        /// </summary>
        public GoogleChartColumn()
        {
        }

        public GoogleChartColumn(string columnLabel, GoogleChartColumnDataType googleChartColumnDataType)
            : this(columnLabel, columnLabel, googleChartColumnDataType.ColumnDataType, null, null, null)
        {
        }

        public GoogleChartColumn(string columnLabel, GoogleChartColumnDataType googleChartColumnDataType, GoogleChartType googleChartType)
            : this(columnLabel, columnLabel, googleChartColumnDataType.ColumnDataType, new GoogleChartSeries(googleChartType, GoogleChartAxisType.Primary), null, null)
        {
        }

        /// <summary>
        /// This is used by the IndicatorSubcategory path
        /// </summary>
        /// <param name="columnID"></param>
        /// <param name="columnLabel"></param>
        /// <param name="columnDataType"></param>
        public GoogleChartColumn(string columnID, string columnLabel, string columnDataType) 
            : this(columnID, columnLabel, columnDataType, null, null, null)
        {
        }

        public GoogleChartColumn(string columnDataType, string columnDataRole)
            : this(null, null, columnDataType, null, columnDataRole, null)
        {
        }

        public GoogleChartColumn(string columnDataType, string columnDataRole, GoogleChartProperty columnProperty)
            : this(null, null, columnDataType, null, columnDataRole, columnProperty)
        {            
        }

        public GoogleChartColumn(string columnID, string columnLabel, string columnDataType, GoogleChartSeries googleChartSeries)
            : this(columnID, columnLabel, columnDataType, googleChartSeries, null, null)
        {
        }

        public GoogleChartColumn(string columnID, string columnLabel, string columnDataType, GoogleChartSeries googleChartSeries, string columnDataRole, GoogleChartProperty columnProperty)
        {
            ColumnID = columnID;
            ColumnLabel = columnLabel;
            ColumnDataType = columnDataType;
            GoogleChartSeries = googleChartSeries;
            ColumnDataRole = columnDataRole;
            ColumnProperty = columnProperty;
        }
    }

    public class GoogleChartProperty
    {
        [JsonProperty(PropertyName = "html")]
        public bool Html { get; set; }

        public GoogleChartProperty()
        {
            Html = true;
        }
    }
}