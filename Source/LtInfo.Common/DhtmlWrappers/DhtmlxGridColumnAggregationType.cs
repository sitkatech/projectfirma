namespace LtInfo.Common.DhtmlWrappers
{
    public class DhtmlxGridColumnAggregationType
    {
        public readonly string ColumnAggregationType;

        private DhtmlxGridColumnAggregationType(string columnAggregationType)
        {
            ColumnAggregationType = columnAggregationType;
        }

        public override string ToString()
        {
            return ColumnAggregationType;
        }
        
        public static readonly DhtmlxGridColumnAggregationType Total = new DhtmlxGridColumnAggregationType("{#stat_total}");
        public static readonly DhtmlxGridColumnAggregationType Count = new DhtmlxGridColumnAggregationType("{#stat_count}");
        public static readonly DhtmlxGridColumnAggregationType Min = new DhtmlxGridColumnAggregationType("{#stat_min}");
        public static readonly DhtmlxGridColumnAggregationType Max = new DhtmlxGridColumnAggregationType("{#stat_max}");
        public static readonly DhtmlxGridColumnAggregationType Average = new DhtmlxGridColumnAggregationType("{#stat_average}");
    }
}