using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class FundingSources
    {
        public static List<FundingSource> List()
        {
            return HttpRequestStorage.DatabaseEntities.FundingSources.ToList().OrderBy(ht => ht.FundingSourceName).ToList();
        }
    }
}