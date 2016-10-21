using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdCategories
    {
        public static List<ThresholdCategory> List()
        {
            return HttpRequestStorage.DatabaseEntities.ThresholdCategories.ToList().OrderBy(ht => ht.DisplayName).ToList();
        }
    }
}