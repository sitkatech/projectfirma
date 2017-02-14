//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Watershed]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Watershed GetWatershed(this IQueryable<Watershed> watersheds, int watershedID)
        {
            var watershed = watersheds.SingleOrDefault(x => x.WatershedID == watershedID);
            Check.RequireNotNullThrowNotFound(watershed, "Watershed", watershedID);
            return watershed;
        }

        public static void DeleteWatershed(this List<int> watershedIDList)
        {
            if(watershedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllWatersheds.RemoveRange(HttpRequestStorage.DatabaseEntities.Watersheds.Where(x => watershedIDList.Contains(x.WatershedID)));
            }
        }

        public static void DeleteWatershed(this ICollection<Watershed> watershedsToDelete)
        {
            if(watershedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllWatersheds.RemoveRange(watershedsToDelete);
            }
        }

        public static void DeleteWatershed(this int watershedID)
        {
            DeleteWatershed(new List<int> { watershedID });
        }

        public static void DeleteWatershed(this Watershed watershedToDelete)
        {
            DeleteWatershed(new List<Watershed> { watershedToDelete });
        }
    }
}