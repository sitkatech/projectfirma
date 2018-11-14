//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialArea]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialArea GetGeospatialArea(this IQueryable<GeospatialArea> geospatialAreas, int geospatialAreaID)
        {
            var geospatialArea = geospatialAreas.SingleOrDefault(x => x.GeospatialAreaID == geospatialAreaID);
            Check.RequireNotNullThrowNotFound(geospatialArea, "GeospatialArea", geospatialAreaID);
            return geospatialArea;
        }

        public static void DeleteGeospatialArea(this List<int> geospatialAreaIDList)
        {
            if(geospatialAreaIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllGeospatialAreas.RemoveRange(HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => geospatialAreaIDList.Contains(x.GeospatialAreaID)));
            }
        }

        public static void DeleteGeospatialArea(this ICollection<GeospatialArea> geospatialAreasToDelete)
        {
            if(geospatialAreasToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllGeospatialAreas.RemoveRange(geospatialAreasToDelete);
            }
        }

        public static void DeleteGeospatialArea(this int geospatialAreaID)
        {
            DeleteGeospatialArea(new List<int> { geospatialAreaID });
        }

        public static void DeleteGeospatialArea(this GeospatialArea geospatialAreaToDelete)
        {
            DeleteGeospatialArea(new List<GeospatialArea> { geospatialAreaToDelete });
        }
    }
}