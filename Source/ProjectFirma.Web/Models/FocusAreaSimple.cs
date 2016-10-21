namespace ProjectFirma.Web.Models
{
    public class FocusAreaSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public FocusAreaSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FocusAreaSimple(int focusAreaID, byte focusAreaNumber, string focusAreaName, string focusAreaDescription, string focusAreaColor)
            : this()
        {
            FocusAreaID = focusAreaID;
            FocusAreaNumber = focusAreaNumber;
            FocusAreaName = focusAreaName;
            FocusAreaDescription = focusAreaDescription;
            FocusAreaColor = focusAreaColor;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public FocusAreaSimple(FocusArea focusArea)
            : this()
        {
            FocusAreaID = focusArea.FocusAreaID;
            FocusAreaNumber = focusArea.FocusAreaNumber;
            FocusAreaName = focusArea.FocusAreaName;
            FocusAreaDescription = focusArea.FocusAreaDescriptionHtmlString == null ? null : focusArea.FocusAreaDescriptionHtmlString.ToString();
            FocusAreaColor = focusArea.FocusAreaColor;
            DisplayName = focusArea.DisplayName;
        }

        public int FocusAreaID { get; set; }
        public byte FocusAreaNumber { get; set; }
        public string FocusAreaName { get; set; }
        public string FocusAreaDescription { get; set; }
        public string FocusAreaColor { get; set; }
        public string DisplayName { get; set; }
    }
}