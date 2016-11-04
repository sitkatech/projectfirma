namespace LtInfo.Common.Views
{
    public class DhtmlxGridColumnFilterType
    {
        protected string FilterType { get; set; }

        public DhtmlxGridColumnFilterType(string filterType)
        {
            FilterType = filterType;
        }

        public static implicit operator string(DhtmlxGridColumnFilterType x)
        {
            return x.ToString();
        }

        public override string ToString()
        {
            return FilterType;
        }

        public static readonly DhtmlxGridColumnFilterType Text = new DhtmlxGridColumnFilterType("#text_filter");
        public static readonly DhtmlxGridColumnFilterType Html = new DhtmlxGridColumnFilterType("#html_filter");
        public static readonly DhtmlxGridColumnFilterType Numeric = new DhtmlxGridColumnFilterType("#numeric_filter");
        public static readonly DhtmlxGridColumnFilterType FormattedNumeric = new DhtmlxGridColumnFilterType("#formatted_numeric_filter");
        public static readonly DhtmlxGridColumnFilterType None = new DhtmlxGridColumnFilterType("&nbsp;");
        public static readonly DhtmlxGridColumnFilterType SelectFilterStrict = new DhtmlxGridColumnFilterType("#select_filter_strict");
        public static readonly DhtmlxGridColumnFilterType SelectFilterHtmlStrict = new DhtmlxGridColumnFilterType("#select_filter_html_strict");
    }
}