//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgencyRightOfWayCoverage]
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
        public static LeadAgencyRightOfWayCoverage GetLeadAgencyRightOfWayCoverage(this IQueryable<LeadAgencyRightOfWayCoverage> leadAgencyRightOfWayCoverages, int leadAgencyRightOfWayCoverageID)
        {
            var leadAgencyRightOfWayCoverage = leadAgencyRightOfWayCoverages.SingleOrDefault(x => x.LeadAgencyRightOfWayCoverageID == leadAgencyRightOfWayCoverageID);
            Check.RequireNotNullThrowNotFound(leadAgencyRightOfWayCoverage, "LeadAgencyRightOfWayCoverage", leadAgencyRightOfWayCoverageID);
            return leadAgencyRightOfWayCoverage;
        }

        public static void DeleteLeadAgencyRightOfWayCoverage(this IQueryable<LeadAgencyRightOfWayCoverage> leadAgencyRightOfWayCoverages, List<int> leadAgencyRightOfWayCoverageIDList)
        {
            if(leadAgencyRightOfWayCoverageIDList.Any())
            {
                leadAgencyRightOfWayCoverages.Where(x => leadAgencyRightOfWayCoverageIDList.Contains(x.LeadAgencyRightOfWayCoverageID)).Delete();
            }
        }

        public static void DeleteLeadAgencyRightOfWayCoverage(this IQueryable<LeadAgencyRightOfWayCoverage> leadAgencyRightOfWayCoverages, ICollection<LeadAgencyRightOfWayCoverage> leadAgencyRightOfWayCoveragesToDelete)
        {
            if(leadAgencyRightOfWayCoveragesToDelete.Any())
            {
                var leadAgencyRightOfWayCoverageIDList = leadAgencyRightOfWayCoveragesToDelete.Select(x => x.LeadAgencyRightOfWayCoverageID).ToList();
                leadAgencyRightOfWayCoverages.Where(x => leadAgencyRightOfWayCoverageIDList.Contains(x.LeadAgencyRightOfWayCoverageID)).Delete();
            }
        }

        public static void DeleteLeadAgencyRightOfWayCoverage(this IQueryable<LeadAgencyRightOfWayCoverage> leadAgencyRightOfWayCoverages, int leadAgencyRightOfWayCoverageID)
        {
            DeleteLeadAgencyRightOfWayCoverage(leadAgencyRightOfWayCoverages, new List<int> { leadAgencyRightOfWayCoverageID });
        }

        public static void DeleteLeadAgencyRightOfWayCoverage(this IQueryable<LeadAgencyRightOfWayCoverage> leadAgencyRightOfWayCoverages, LeadAgencyRightOfWayCoverage leadAgencyRightOfWayCoverageToDelete)
        {
            DeleteLeadAgencyRightOfWayCoverage(leadAgencyRightOfWayCoverages, new List<LeadAgencyRightOfWayCoverage> { leadAgencyRightOfWayCoverageToDelete });
        }
    }
}