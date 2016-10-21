//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgencyTransactionTypeCommodity]
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
        public static LeadAgencyTransactionTypeCommodity GetLeadAgencyTransactionTypeCommodity(this IQueryable<LeadAgencyTransactionTypeCommodity> leadAgencyTransactionTypeCommodities, int leadAgencyTransactionTypeCommodityID)
        {
            var leadAgencyTransactionTypeCommodity = leadAgencyTransactionTypeCommodities.SingleOrDefault(x => x.LeadAgencyTransactionTypeCommodityID == leadAgencyTransactionTypeCommodityID);
            Check.RequireNotNullThrowNotFound(leadAgencyTransactionTypeCommodity, "LeadAgencyTransactionTypeCommodity", leadAgencyTransactionTypeCommodityID);
            return leadAgencyTransactionTypeCommodity;
        }

        public static void DeleteLeadAgencyTransactionTypeCommodity(this IQueryable<LeadAgencyTransactionTypeCommodity> leadAgencyTransactionTypeCommodities, List<int> leadAgencyTransactionTypeCommodityIDList)
        {
            if(leadAgencyTransactionTypeCommodityIDList.Any())
            {
                leadAgencyTransactionTypeCommodities.Where(x => leadAgencyTransactionTypeCommodityIDList.Contains(x.LeadAgencyTransactionTypeCommodityID)).Delete();
            }
        }

        public static void DeleteLeadAgencyTransactionTypeCommodity(this IQueryable<LeadAgencyTransactionTypeCommodity> leadAgencyTransactionTypeCommodities, ICollection<LeadAgencyTransactionTypeCommodity> leadAgencyTransactionTypeCommoditiesToDelete)
        {
            if(leadAgencyTransactionTypeCommoditiesToDelete.Any())
            {
                var leadAgencyTransactionTypeCommodityIDList = leadAgencyTransactionTypeCommoditiesToDelete.Select(x => x.LeadAgencyTransactionTypeCommodityID).ToList();
                leadAgencyTransactionTypeCommodities.Where(x => leadAgencyTransactionTypeCommodityIDList.Contains(x.LeadAgencyTransactionTypeCommodityID)).Delete();
            }
        }

        public static void DeleteLeadAgencyTransactionTypeCommodity(this IQueryable<LeadAgencyTransactionTypeCommodity> leadAgencyTransactionTypeCommodities, int leadAgencyTransactionTypeCommodityID)
        {
            DeleteLeadAgencyTransactionTypeCommodity(leadAgencyTransactionTypeCommodities, new List<int> { leadAgencyTransactionTypeCommodityID });
        }

        public static void DeleteLeadAgencyTransactionTypeCommodity(this IQueryable<LeadAgencyTransactionTypeCommodity> leadAgencyTransactionTypeCommodities, LeadAgencyTransactionTypeCommodity leadAgencyTransactionTypeCommodityToDelete)
        {
            DeleteLeadAgencyTransactionTypeCommodity(leadAgencyTransactionTypeCommodities, new List<LeadAgencyTransactionTypeCommodity> { leadAgencyTransactionTypeCommodityToDelete });
        }
    }
}