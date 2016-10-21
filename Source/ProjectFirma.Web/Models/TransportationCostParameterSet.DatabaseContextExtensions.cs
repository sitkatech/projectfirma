using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TransportationCostParameterSet Latest(this IEnumerable<TransportationCostParameterSet> transportationCostParameterSets)
        {
            return transportationCostParameterSets.OrderByDescending(x => x.CreateDate).First();
        }
    }
}