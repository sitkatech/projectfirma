namespace ProjectFirma.Web.Models
{
    public class WatershedSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public WatershedSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WatershedSimple(int watershedID, string watershedName)
            : this()
        {
            WatershedID = watershedID;
            WatershedName = watershedName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public WatershedSimple(Watershed watershed)
            : this()
        {
            WatershedID = watershed.WatershedID;
            WatershedName = watershed.WatershedName;
        }

        public int WatershedID { get; set; }
        public string WatershedName { get; set; }
        public string DisplayName
        {
            get { return WatershedName; }
        }
    }
}