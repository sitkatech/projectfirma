//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityConvertedToCommodity]
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
        public static CommodityConvertedToCommodity GetCommodityConvertedToCommodity(this IQueryable<CommodityConvertedToCommodity> commodityConvertedToCommodities, int commodityConvertedToCommodityID)
        {
            var commodityConvertedToCommodity = commodityConvertedToCommodities.SingleOrDefault(x => x.CommodityConvertedToCommodityID == commodityConvertedToCommodityID);
            Check.RequireNotNullThrowNotFound(commodityConvertedToCommodity, "CommodityConvertedToCommodity", commodityConvertedToCommodityID);
            return commodityConvertedToCommodity;
        }

        public static void DeleteCommodityConvertedToCommodity(this IQueryable<CommodityConvertedToCommodity> commodityConvertedToCommodities, List<int> commodityConvertedToCommodityIDList)
        {
            if(commodityConvertedToCommodityIDList.Any())
            {
                commodityConvertedToCommodities.Where(x => commodityConvertedToCommodityIDList.Contains(x.CommodityConvertedToCommodityID)).Delete();
            }
        }

        public static void DeleteCommodityConvertedToCommodity(this IQueryable<CommodityConvertedToCommodity> commodityConvertedToCommodities, ICollection<CommodityConvertedToCommodity> commodityConvertedToCommoditiesToDelete)
        {
            if(commodityConvertedToCommoditiesToDelete.Any())
            {
                var commodityConvertedToCommodityIDList = commodityConvertedToCommoditiesToDelete.Select(x => x.CommodityConvertedToCommodityID).ToList();
                commodityConvertedToCommodities.Where(x => commodityConvertedToCommodityIDList.Contains(x.CommodityConvertedToCommodityID)).Delete();
            }
        }

        public static void DeleteCommodityConvertedToCommodity(this IQueryable<CommodityConvertedToCommodity> commodityConvertedToCommodities, int commodityConvertedToCommodityID)
        {
            DeleteCommodityConvertedToCommodity(commodityConvertedToCommodities, new List<int> { commodityConvertedToCommodityID });
        }

        public static void DeleteCommodityConvertedToCommodity(this IQueryable<CommodityConvertedToCommodity> commodityConvertedToCommodities, CommodityConvertedToCommodity commodityConvertedToCommodityToDelete)
        {
            DeleteCommodityConvertedToCommodity(commodityConvertedToCommodities, new List<CommodityConvertedToCommodity> { commodityConvertedToCommodityToDelete });
        }
    }
}