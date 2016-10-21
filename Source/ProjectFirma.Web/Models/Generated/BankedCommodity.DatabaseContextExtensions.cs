//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[BankedCommodity]
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
        public static BankedCommodity GetBankedCommodity(this IQueryable<BankedCommodity> bankedCommodities, int bankedCommodityID)
        {
            var bankedCommodity = bankedCommodities.SingleOrDefault(x => x.BankedCommodityID == bankedCommodityID);
            Check.RequireNotNullThrowNotFound(bankedCommodity, "BankedCommodity", bankedCommodityID);
            return bankedCommodity;
        }

        public static void DeleteBankedCommodity(this IQueryable<BankedCommodity> bankedCommodities, List<int> bankedCommodityIDList)
        {
            if(bankedCommodityIDList.Any())
            {
                bankedCommodities.Where(x => bankedCommodityIDList.Contains(x.BankedCommodityID)).Delete();
            }
        }

        public static void DeleteBankedCommodity(this IQueryable<BankedCommodity> bankedCommodities, ICollection<BankedCommodity> bankedCommoditiesToDelete)
        {
            if(bankedCommoditiesToDelete.Any())
            {
                var bankedCommodityIDList = bankedCommoditiesToDelete.Select(x => x.BankedCommodityID).ToList();
                bankedCommodities.Where(x => bankedCommodityIDList.Contains(x.BankedCommodityID)).Delete();
            }
        }

        public static void DeleteBankedCommodity(this IQueryable<BankedCommodity> bankedCommodities, int bankedCommodityID)
        {
            DeleteBankedCommodity(bankedCommodities, new List<int> { bankedCommodityID });
        }

        public static void DeleteBankedCommodity(this IQueryable<BankedCommodity> bankedCommodities, BankedCommodity bankedCommodityToDelete)
        {
            DeleteBankedCommodity(bankedCommodities, new List<BankedCommodity> { bankedCommodityToDelete });
        }
    }
}