namespace ProjectFirma.Web.Models
{
    public class IndicatorSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorSimple()
        {
        }

        public IndicatorSimple(Indicator indicator)
            : this()
        {
            IndicatorID = indicator.IndicatorID;
            DisplayName = indicator.IndicatorDisplayName;
        }

        public int IndicatorID { get; set; }
        public string DisplayName { get; set; }
    }
}