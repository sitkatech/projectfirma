namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartColumnDataType
    {
        public string ColumnDataType { get; }

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
        public static readonly GoogleChartColumnDataType Date = new GoogleChartColumnDataType("date");
        public static readonly GoogleChartColumnDataType DateTime = new GoogleChartColumnDataType("datetime");
        public static readonly GoogleChartColumnDataType TimeOfDay = new GoogleChartColumnDataType("timeofday");
    }
}
