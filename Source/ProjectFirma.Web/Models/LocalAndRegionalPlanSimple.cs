namespace ProjectFirma.Web.Models
{
    public class LocalAndRegionalPlanSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public LocalAndRegionalPlanSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LocalAndRegionalPlanSimple(int localAndRegionalPlanID, string localAndRegionalPlanName, string planDocumentUrl, string planDocumentLinkText, bool isTransportationPlan)
            : this()
        {
            LocalAndRegionalPlanID = localAndRegionalPlanID;
            LocalAndRegionalPlanName = localAndRegionalPlanName;
            PlanDocumentUrl = planDocumentUrl;
            PlanDocumentLinkText = planDocumentLinkText;
            IsTransportationPlan = isTransportationPlan;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public LocalAndRegionalPlanSimple(LocalAndRegionalPlan localAndRegionalPlan)
            : this()
        {
            LocalAndRegionalPlanID = localAndRegionalPlan.LocalAndRegionalPlanID;
            LocalAndRegionalPlanName = localAndRegionalPlan.LocalAndRegionalPlanName;
            PlanDocumentUrl = localAndRegionalPlan.PlanDocumentUrl;
            PlanDocumentLinkText = localAndRegionalPlan.PlanDocumentLinkText;
            IsTransportationPlan = localAndRegionalPlan.IsTransportationPlan;
        }

        public int LocalAndRegionalPlanID { get; set; }
        public string LocalAndRegionalPlanName { get; set; }
        public string PlanDocumentUrl { get; set; }
        public string PlanDocumentLinkText { get; set; }
        public bool IsTransportationPlan { get; set; }
        public string DisplayName
        {
            get { return LocalAndRegionalPlanName; }
        }
    }
}