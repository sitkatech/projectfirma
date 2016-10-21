//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TownCenter]
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
        public static TownCenter GetTownCenter(this IQueryable<TownCenter> townCenters, int townCenterID)
        {
            var townCenter = townCenters.SingleOrDefault(x => x.TownCenterID == townCenterID);
            Check.RequireNotNullThrowNotFound(townCenter, "TownCenter", townCenterID);
            return townCenter;
        }

        public static void DeleteTownCenter(this IQueryable<TownCenter> townCenters, List<int> townCenterIDList)
        {
            if(townCenterIDList.Any())
            {
                townCenters.Where(x => townCenterIDList.Contains(x.TownCenterID)).Delete();
            }
        }

        public static void DeleteTownCenter(this IQueryable<TownCenter> townCenters, ICollection<TownCenter> townCentersToDelete)
        {
            if(townCentersToDelete.Any())
            {
                var townCenterIDList = townCentersToDelete.Select(x => x.TownCenterID).ToList();
                townCenters.Where(x => townCenterIDList.Contains(x.TownCenterID)).Delete();
            }
        }

        public static void DeleteTownCenter(this IQueryable<TownCenter> townCenters, int townCenterID)
        {
            DeleteTownCenter(townCenters, new List<int> { townCenterID });
        }

        public static void DeleteTownCenter(this IQueryable<TownCenter> townCenters, TownCenter townCenterToDelete)
        {
            DeleteTownCenter(townCenters, new List<TownCenter> { townCenterToDelete });
        }
    }
}