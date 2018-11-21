//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaType GetGeospatialAreaType(this IQueryable<GeospatialAreaType> geospatialAreaTypes, int geospatialAreaTypeID)
        {
            var geospatialAreaType = geospatialAreaTypes.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaTypeID);
            Check.RequireNotNullThrowNotFound(geospatialAreaType, "GeospatialAreaType", geospatialAreaTypeID);
            return geospatialAreaType;
        }

        public static void DeleteGeospatialAreaType(this List<int> geospatialAreaTypeIDList)
        {
            if(geospatialAreaTypeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllGeospatialAreaTypes.RemoveRange(HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.Where(x => geospatialAreaTypeIDList.Contains(x.GeospatialAreaTypeID)));
            }
        }

        public static void DeleteGeospatialAreaType(this ICollection<GeospatialAreaType> geospatialAreaTypesToDelete)
        {
            if(geospatialAreaTypesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllGeospatialAreaTypes.RemoveRange(geospatialAreaTypesToDelete);
            }
        }

        public static void DeleteGeospatialAreaType(this int geospatialAreaTypeID)
        {
            DeleteGeospatialAreaType(new List<int> { geospatialAreaTypeID });
        }

        public static void DeleteGeospatialAreaType(this GeospatialAreaType geospatialAreaTypeToDelete)
        {
            DeleteGeospatialAreaType(new List<GeospatialAreaType> { geospatialAreaTypeToDelete });
        }
    }
}