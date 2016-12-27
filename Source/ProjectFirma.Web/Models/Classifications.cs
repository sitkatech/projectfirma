using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class Classifications
    {
        public static List<Classification> List()
        {
            return HttpRequestStorage.DatabaseEntities.Classifications.ToList().OrderBy(ht => ht.DisplayName).ToList();
        }
    }
}