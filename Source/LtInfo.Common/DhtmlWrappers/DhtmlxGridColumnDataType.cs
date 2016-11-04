namespace LtInfo.Common.DhtmlWrappers
{
    public class DhtmlxGridColumnDataType
    {
        public string ColumnDataType { get; private set; }

        private DhtmlxGridColumnDataType(string columnDataType)
        {
            ColumnDataType = columnDataType;
        }

        public override string ToString()
        {
            return ColumnDataType;
        }

        public static readonly DhtmlxGridColumnDataType Checkbox = new DhtmlxGridColumnDataType("ch");
        public static readonly DhtmlxGridColumnDataType ReadOnlyText = new DhtmlxGridColumnDataType("rotxt");
        public static readonly DhtmlxGridColumnDataType ReadOnlyHtmlText = new DhtmlxGridColumnDataType("ro");
        public static readonly DhtmlxGridColumnDataType ReadOnlyNumber = new DhtmlxGridColumnDataType("ron");
    }
}