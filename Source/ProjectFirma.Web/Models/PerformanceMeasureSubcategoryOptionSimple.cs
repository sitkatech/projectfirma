namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSubcategoryOptionSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureSubcategoryOptionSimple(int performanceMeasureSubcategoryOptionID, int performanceMeasureSubcategoryID, string performanceMeasureSubcategoryOptionName, int? sortOrder, string shortName)
            : this()
        {
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOptionName;
            SortOrder = sortOrder;
            ShortName = shortName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureSubcategoryOptionSimple(PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption)
            : this()
        {
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryID;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
            SortOrder = performanceMeasureSubcategoryOption.SortOrder;
            ShortName = performanceMeasureSubcategoryOption.ShortName;
        }

        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        public string PerformanceMeasureSubcategoryOptionName { get; set; }
        public int? SortOrder { get; set; }
        public string ShortName { get; set; }
    }
}