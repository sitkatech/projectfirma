namespace ProjectFirma.Web.Models
{
    public class IndicatorRelationshipTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorRelationshipTypeSimple()
        {
        }

        public IndicatorRelationshipTypeSimple(IndicatorRelationshipType indicatorRelationshipType)
            : this()
        {
            IndicatorRelationshipTypeID = indicatorRelationshipType.IndicatorRelationshipTypeID;
            DisplayName = indicatorRelationshipType.IndicatorRelationshipTypeDisplayName;
        }

        public int IndicatorRelationshipTypeID { get; set; }
        public string DisplayName { get; set; }
    }
}