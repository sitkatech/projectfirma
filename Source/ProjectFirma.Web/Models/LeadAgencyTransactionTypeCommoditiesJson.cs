using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencyTransactionTypeCommoditiesJson : ToadJson
    {
        public readonly List<LeadAgencyJson> LeadAgencies;

        public LeadAgencyTransactionTypeCommoditiesJson(List<LeadAgencyJson> leadAgencies)
        {
            LeadAgencies = leadAgencies.OrderBy(x => x.LeadAgencyName).ToList();
        }
    }
}