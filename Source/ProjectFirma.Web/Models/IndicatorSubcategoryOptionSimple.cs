namespace ProjectFirma.Web.Models
{
    public class IndicatorSubcategoryOptionSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorSubcategoryOptionSimple(int indicatorSubcategoryOptionID, int indicatorSubcategoryID, string indicatorSubcategoryOptionName, int? sortOrder, string shortName)
            : this()
        {
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
            IndicatorSubcategoryOptionName = indicatorSubcategoryOptionName;
            SortOrder = sortOrder;
            ShortName = shortName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public IndicatorSubcategoryOptionSimple(IndicatorSubcategoryOption indicatorSubcategoryOption)
            : this()
        {
            IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            IndicatorSubcategoryID = indicatorSubcategoryOption.IndicatorSubcategoryID;
            IndicatorSubcategoryOptionName = indicatorSubcategoryOption.IndicatorSubcategoryOptionName;
            SortOrder = indicatorSubcategoryOption.SortOrder;
            ShortName = indicatorSubcategoryOption.ShortName;
        }

        public int IndicatorSubcategoryOptionID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public string IndicatorSubcategoryOptionName { get; set; }
        public int? SortOrder { get; set; }
        public string ShortName { get; set; }
    }
}