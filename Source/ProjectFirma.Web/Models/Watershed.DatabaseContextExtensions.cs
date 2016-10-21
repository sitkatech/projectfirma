using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<Watershed> GetWatershedsWithGeospatialFeatures(this IQueryable<Watershed> watersheds)
        {
            return watersheds.Where(x => x.WatershedFeature != null).ToList();
        }
    }
}