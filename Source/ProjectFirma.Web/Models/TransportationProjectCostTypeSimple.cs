namespace ProjectFirma.Web.Models
{
    public class TransportationProjectCostTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TransportationProjectCostTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationProjectCostTypeSimple(int transportationProjectCostTypeID, string transportationProjectCostTypeName, string transportationProjectCostTypeDisplayName, int sortOrder)
            : this()
        {
            this.TransportationProjectCostTypeID = transportationProjectCostTypeID;
            this.TransportationProjectCostTypeName = transportationProjectCostTypeName;
            this.TransportationProjectCostTypeDisplayName = transportationProjectCostTypeDisplayName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TransportationProjectCostTypeSimple(TransportationProjectCostType transportationProjectCostType)
            : this()
        {
            this.TransportationProjectCostTypeID = transportationProjectCostType.TransportationProjectCostTypeID;
            this.TransportationProjectCostTypeName = transportationProjectCostType.TransportationProjectCostTypeName;
            this.TransportationProjectCostTypeDisplayName = transportationProjectCostType.TransportationProjectCostTypeDisplayName;
            this.SortOrder = transportationProjectCostType.SortOrder;
        }

        public int TransportationProjectCostTypeID { get; set; }
        public string TransportationProjectCostTypeName { get; set; }
        public string TransportationProjectCostTypeDisplayName { get; set; }
        public int SortOrder { get; set; }
    }
}