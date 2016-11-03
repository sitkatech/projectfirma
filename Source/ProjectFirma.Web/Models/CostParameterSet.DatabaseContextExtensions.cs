using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CostParameterSet Latest(this IEnumerable<CostParameterSet> CostParameterSets)
        {
            return CostParameterSets.OrderByDescending(x => x.CreateDate).First();
        }
    }
}