using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class ConfigureAccomplishmentsDashboardViewData
    {
        public IEnumerable<AccomplishmentsDashboardFundingDisplayType> AccomplishmentsDashboardFundingDisplayTypes { get; set; }

        public ConfigureAccomplishmentsDashboardViewData()
        {
            AccomplishmentsDashboardFundingDisplayTypes = AccomplishmentsDashboardFundingDisplayType.All;
        }
    }
}
