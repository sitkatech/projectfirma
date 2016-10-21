using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<Jurisdiction> GetJurisdictionsWithGeospatialFeatures(this IQueryable<Jurisdiction> jurisdictions)
        {
            return jurisdictions.Where(x => x.JurisdictionFeature != null).ToList();
        }
    }
}