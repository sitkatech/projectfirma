namespace LtInfo.Common.DhtmlWrappers
{
    public class DhtmlxGridColumnFormatType
    {
        public readonly string ColumnFormatType;

        public DhtmlxGridColumnFormatType(string columnFormatType)
        {
            ColumnFormatType = columnFormatType;
        }

        public static readonly DhtmlxGridColumnFormatType Decimal = new DhtmlxGridColumnFormatType("decimalSitka");
        public static readonly DhtmlxGridColumnFormatType Integer = new DhtmlxGridColumnFormatType("integerSitka");
        public static readonly DhtmlxGridColumnFormatType Currency = new DhtmlxGridColumnFormatType("currencySitka");
        public static readonly DhtmlxGridColumnFormatType Percent = new DhtmlxGridColumnFormatType("percentSitka");
        public static readonly DhtmlxGridColumnFormatType None = new DhtmlxGridColumnFormatType("noneSitka");
        public static readonly DhtmlxGridColumnFormatType DateTime = new DhtmlxGridColumnFormatType("dateTimeSitka");
        public static readonly DhtmlxGridColumnFormatType Date = new DhtmlxGridColumnFormatType("dateSitka");
        public static readonly DhtmlxGridColumnFormatType LatLong = new DhtmlxGridColumnFormatType("latLongSitka");
    }
}