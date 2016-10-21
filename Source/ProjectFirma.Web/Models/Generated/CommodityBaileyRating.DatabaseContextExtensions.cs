//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityBaileyRating]
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
        public static CommodityBaileyRating GetCommodityBaileyRating(this IQueryable<CommodityBaileyRating> commodityBaileyRatings, int commodityBaileyRatingID)
        {
            var commodityBaileyRating = commodityBaileyRatings.SingleOrDefault(x => x.CommodityBaileyRatingID == commodityBaileyRatingID);
            Check.RequireNotNullThrowNotFound(commodityBaileyRating, "CommodityBaileyRating", commodityBaileyRatingID);
            return commodityBaileyRating;
        }

        public static void DeleteCommodityBaileyRating(this IQueryable<CommodityBaileyRating> commodityBaileyRatings, List<int> commodityBaileyRatingIDList)
        {
            if(commodityBaileyRatingIDList.Any())
            {
                commodityBaileyRatings.Where(x => commodityBaileyRatingIDList.Contains(x.CommodityBaileyRatingID)).Delete();
            }
        }

        public static void DeleteCommodityBaileyRating(this IQueryable<CommodityBaileyRating> commodityBaileyRatings, ICollection<CommodityBaileyRating> commodityBaileyRatingsToDelete)
        {
            if(commodityBaileyRatingsToDelete.Any())
            {
                var commodityBaileyRatingIDList = commodityBaileyRatingsToDelete.Select(x => x.CommodityBaileyRatingID).ToList();
                commodityBaileyRatings.Where(x => commodityBaileyRatingIDList.Contains(x.CommodityBaileyRatingID)).Delete();
            }
        }

        public static void DeleteCommodityBaileyRating(this IQueryable<CommodityBaileyRating> commodityBaileyRatings, int commodityBaileyRatingID)
        {
            DeleteCommodityBaileyRating(commodityBaileyRatings, new List<int> { commodityBaileyRatingID });
        }

        public static void DeleteCommodityBaileyRating(this IQueryable<CommodityBaileyRating> commodityBaileyRatings, CommodityBaileyRating commodityBaileyRatingToDelete)
        {
            DeleteCommodityBaileyRating(commodityBaileyRatings, new List<CommodityBaileyRating> { commodityBaileyRatingToDelete });
        }
    }
}