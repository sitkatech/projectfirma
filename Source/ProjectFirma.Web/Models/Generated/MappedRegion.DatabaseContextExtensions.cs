//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MappedRegion]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteMappedRegion(this IQueryable<MappedRegion> mappedRegions, List<int> mappedRegionIDList)
        {
            if(mappedRegionIDList.Any())
            {
                mappedRegions.Where(x => mappedRegionIDList.Contains(x.MappedRegionID)).Delete();
            }
        }

        public static void DeleteMappedRegion(this IQueryable<MappedRegion> mappedRegions, ICollection<MappedRegion> mappedRegionsToDelete)
        {
            if(mappedRegionsToDelete.Any())
            {
                var mappedRegionIDList = mappedRegionsToDelete.Select(x => x.MappedRegionID).ToList();
                mappedRegions.Where(x => mappedRegionIDList.Contains(x.MappedRegionID)).Delete();
            }
        }

        public static void DeleteMappedRegion(this IQueryable<MappedRegion> mappedRegions, int mappedRegionID)
        {
            DeleteMappedRegion(mappedRegions, new List<int> { mappedRegionID });
        }

        public static void DeleteMappedRegion(this IQueryable<MappedRegion> mappedRegions, MappedRegion mappedRegionToDelete)
        {
            DeleteMappedRegion(mappedRegions, new List<MappedRegion> { mappedRegionToDelete });
        }
    }
}