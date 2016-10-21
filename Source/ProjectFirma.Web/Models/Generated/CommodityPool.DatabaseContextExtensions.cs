//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityPool]
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
        public static CommodityPool GetCommodityPool(this IQueryable<CommodityPool> commodityPools, int commodityPoolID)
        {
            var commodityPool = commodityPools.SingleOrDefault(x => x.CommodityPoolID == commodityPoolID);
            Check.RequireNotNullThrowNotFound(commodityPool, "CommodityPool", commodityPoolID);
            return commodityPool;
        }

        public static void DeleteCommodityPool(this IQueryable<CommodityPool> commodityPools, List<int> commodityPoolIDList)
        {
            if(commodityPoolIDList.Any())
            {
                commodityPools.Where(x => commodityPoolIDList.Contains(x.CommodityPoolID)).Delete();
            }
        }

        public static void DeleteCommodityPool(this IQueryable<CommodityPool> commodityPools, ICollection<CommodityPool> commodityPoolsToDelete)
        {
            if(commodityPoolsToDelete.Any())
            {
                var commodityPoolIDList = commodityPoolsToDelete.Select(x => x.CommodityPoolID).ToList();
                commodityPools.Where(x => commodityPoolIDList.Contains(x.CommodityPoolID)).Delete();
            }
        }

        public static void DeleteCommodityPool(this IQueryable<CommodityPool> commodityPools, int commodityPoolID)
        {
            DeleteCommodityPool(commodityPools, new List<int> { commodityPoolID });
        }

        public static void DeleteCommodityPool(this IQueryable<CommodityPool> commodityPools, CommodityPool commodityPoolToDelete)
        {
            DeleteCommodityPool(commodityPools, new List<CommodityPool> { commodityPoolToDelete });
        }
    }
}