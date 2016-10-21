using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class LocalAndRegionalPlans
    {
        public static List<LocalAndRegionalPlan> List()
        {
            return HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.ToList().OrderBy(ht => ht.DisplayName).ToList();
        }
    }
}