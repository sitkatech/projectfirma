//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityPoolDisbursement]
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
        public static CommodityPoolDisbursement GetCommodityPoolDisbursement(this IQueryable<CommodityPoolDisbursement> commodityPoolDisbursements, int commodityPoolDisbursementID)
        {
            var commodityPoolDisbursement = commodityPoolDisbursements.SingleOrDefault(x => x.CommodityPoolDisbursementID == commodityPoolDisbursementID);
            Check.RequireNotNullThrowNotFound(commodityPoolDisbursement, "CommodityPoolDisbursement", commodityPoolDisbursementID);
            return commodityPoolDisbursement;
        }

        public static void DeleteCommodityPoolDisbursement(this IQueryable<CommodityPoolDisbursement> commodityPoolDisbursements, List<int> commodityPoolDisbursementIDList)
        {
            if(commodityPoolDisbursementIDList.Any())
            {
                commodityPoolDisbursements.Where(x => commodityPoolDisbursementIDList.Contains(x.CommodityPoolDisbursementID)).Delete();
            }
        }

        public static void DeleteCommodityPoolDisbursement(this IQueryable<CommodityPoolDisbursement> commodityPoolDisbursements, ICollection<CommodityPoolDisbursement> commodityPoolDisbursementsToDelete)
        {
            if(commodityPoolDisbursementsToDelete.Any())
            {
                var commodityPoolDisbursementIDList = commodityPoolDisbursementsToDelete.Select(x => x.CommodityPoolDisbursementID).ToList();
                commodityPoolDisbursements.Where(x => commodityPoolDisbursementIDList.Contains(x.CommodityPoolDisbursementID)).Delete();
            }
        }

        public static void DeleteCommodityPoolDisbursement(this IQueryable<CommodityPoolDisbursement> commodityPoolDisbursements, int commodityPoolDisbursementID)
        {
            DeleteCommodityPoolDisbursement(commodityPoolDisbursements, new List<int> { commodityPoolDisbursementID });
        }

        public static void DeleteCommodityPoolDisbursement(this IQueryable<CommodityPoolDisbursement> commodityPoolDisbursements, CommodityPoolDisbursement commodityPoolDisbursementToDelete)
        {
            DeleteCommodityPoolDisbursement(commodityPoolDisbursements, new List<CommodityPoolDisbursement> { commodityPoolDisbursementToDelete });
        }
    }
}