namespace ProjectFirma.Web.Models
{
    public class SectorSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public SectorSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SectorSimple(int sectorID, string sectorName, string sectorDisplayName, string sectorAbbreviation, string legendColor)
            : this()
        {
            SectorID = sectorID;
            SectorName = sectorName;
            SectorDisplayName = sectorDisplayName;
            SectorAbbreviation = sectorAbbreviation;
            LegendColor = legendColor;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public SectorSimple(Sector sector)
            : this()
        {
            SectorID = sector.SectorID;
            SectorName = sector.SectorName;
            SectorDisplayName = sector.SectorDisplayName;
            SectorAbbreviation = sector.SectorAbbreviation;
            LegendColor = sector.LegendColor;
        }

        public int SectorID { get; set; }
        public string SectorName { get; set; }
        public string SectorDisplayName { get; set; }
        public string SectorAbbreviation { get; set; }
        public string LegendColor { get; set; }
    }
}