using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class ConfigureAccomplishmentsDashboardViewData
    {
        public IEnumerable<AccomplishmentsDashboardFundingDisplayType> AccomplishmentsDashboardFundingDisplayTypes { get; set; }
        public IEnumerable<SelectListItem> RelationshipTypes { get; }

        public ConfigureAccomplishmentsDashboardViewData(IEnumerable<SelectListItem> relationshipTypes)
        {
            RelationshipTypes = relationshipTypes;
            AccomplishmentsDashboardFundingDisplayTypes = AccomplishmentsDashboardFundingDisplayType.All;
        }
    }
}
