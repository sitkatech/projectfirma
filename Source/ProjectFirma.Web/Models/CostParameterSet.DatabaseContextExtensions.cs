using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CostParameterSet Latest(this IEnumerable<CostParameterSet> costParameterSets)
        {
            var costParameterSet = costParameterSets.OrderByDescending(x => x.CreateDate).FirstOrDefault();
            return costParameterSet ?? new CostParameterSet(0, DateTime.Now.Year, DateTime.Now);
        }
    }
}