//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MappedRegion]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static MappedRegion GetMappedRegion(this IQueryable<MappedRegion> mappedRegions, int mappedRegionID)
        {
            var mappedRegion = mappedRegions.SingleOrDefault(x => x.MappedRegionID == mappedRegionID);
            Check.RequireNotNullThrowNotFound(mappedRegion, "MappedRegion", mappedRegionID);
            return mappedRegion;
        }

        public static void DeleteMappedRegion(this List<int> mappedRegionIDList)
        {
            if(mappedRegionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMappedRegions.RemoveRange(HttpRequestStorage.DatabaseEntities.MappedRegions.Where(x => mappedRegionIDList.Contains(x.MappedRegionID)));
            }
        }

        public static void DeleteMappedRegion(this ICollection<MappedRegion> mappedRegionsToDelete)
        {
            if(mappedRegionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMappedRegions.RemoveRange(mappedRegionsToDelete);
            }
        }

        public static void DeleteMappedRegion(this int mappedRegionID)
        {
            DeleteMappedRegion(new List<int> { mappedRegionID });
        }

        public static void DeleteMappedRegion(this MappedRegion mappedRegionToDelete)
        {
            DeleteMappedRegion(new List<MappedRegion> { mappedRegionToDelete });
        }
    }
}