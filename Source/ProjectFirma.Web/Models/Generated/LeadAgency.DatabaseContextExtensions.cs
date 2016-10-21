//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgency]
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
        public static LeadAgency GetLeadAgency(this IQueryable<LeadAgency> leadAgencies, int leadAgencyID)
        {
            var leadAgency = leadAgencies.SingleOrDefault(x => x.LeadAgencyID == leadAgencyID);
            Check.RequireNotNullThrowNotFound(leadAgency, "LeadAgency", leadAgencyID);
            return leadAgency;
        }

        public static void DeleteLeadAgency(this IQueryable<LeadAgency> leadAgencies, List<int> leadAgencyIDList)
        {
            if(leadAgencyIDList.Any())
            {
                leadAgencies.Where(x => leadAgencyIDList.Contains(x.LeadAgencyID)).Delete();
            }
        }

        public static void DeleteLeadAgency(this IQueryable<LeadAgency> leadAgencies, ICollection<LeadAgency> leadAgenciesToDelete)
        {
            if(leadAgenciesToDelete.Any())
            {
                var leadAgencyIDList = leadAgenciesToDelete.Select(x => x.LeadAgencyID).ToList();
                leadAgencies.Where(x => leadAgencyIDList.Contains(x.LeadAgencyID)).Delete();
            }
        }

        public static void DeleteLeadAgency(this IQueryable<LeadAgency> leadAgencies, int leadAgencyID)
        {
            DeleteLeadAgency(leadAgencies, new List<int> { leadAgencyID });
        }

        public static void DeleteLeadAgency(this IQueryable<LeadAgency> leadAgencies, LeadAgency leadAgencyToDelete)
        {
            DeleteLeadAgency(leadAgencies, new List<LeadAgency> { leadAgencyToDelete });
        }
    }
}