using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.TransportationObjective
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> TransportationStrategies;
        public readonly string TransportationStrategyDisplayName;
        public readonly bool HasProjects;
        public readonly IEnumerable<SelectListItem> FundingTypes;
        public readonly string FundingTypeDisplayName;

        public EditViewData(IEnumerable<SelectListItem> transportationStrategies,
            string transportationStrategyDisplayName,
            IEnumerable<SelectListItem> fundingTypes,
            string fundingTypeDisplayName,
            bool hasProjects)
        {
            TransportationStrategies = transportationStrategies;
            TransportationStrategyDisplayName = transportationStrategyDisplayName;
            FundingTypes = fundingTypes;
            FundingTypeDisplayName = fundingTypeDisplayName;
            HasProjects = hasProjects;
        }
    }
}