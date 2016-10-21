//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LocalAndRegionalPlan]
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
        public static LocalAndRegionalPlan GetLocalAndRegionalPlan(this IQueryable<LocalAndRegionalPlan> localAndRegionalPlans, int localAndRegionalPlanID)
        {
            var localAndRegionalPlan = localAndRegionalPlans.SingleOrDefault(x => x.LocalAndRegionalPlanID == localAndRegionalPlanID);
            Check.RequireNotNullThrowNotFound(localAndRegionalPlan, "LocalAndRegionalPlan", localAndRegionalPlanID);
            return localAndRegionalPlan;
        }

        public static void DeleteLocalAndRegionalPlan(this IQueryable<LocalAndRegionalPlan> localAndRegionalPlans, List<int> localAndRegionalPlanIDList)
        {
            if(localAndRegionalPlanIDList.Any())
            {
                localAndRegionalPlans.Where(x => localAndRegionalPlanIDList.Contains(x.LocalAndRegionalPlanID)).Delete();
            }
        }

        public static void DeleteLocalAndRegionalPlan(this IQueryable<LocalAndRegionalPlan> localAndRegionalPlans, ICollection<LocalAndRegionalPlan> localAndRegionalPlansToDelete)
        {
            if(localAndRegionalPlansToDelete.Any())
            {
                var localAndRegionalPlanIDList = localAndRegionalPlansToDelete.Select(x => x.LocalAndRegionalPlanID).ToList();
                localAndRegionalPlans.Where(x => localAndRegionalPlanIDList.Contains(x.LocalAndRegionalPlanID)).Delete();
            }
        }

        public static void DeleteLocalAndRegionalPlan(this IQueryable<LocalAndRegionalPlan> localAndRegionalPlans, int localAndRegionalPlanID)
        {
            DeleteLocalAndRegionalPlan(localAndRegionalPlans, new List<int> { localAndRegionalPlanID });
        }

        public static void DeleteLocalAndRegionalPlan(this IQueryable<LocalAndRegionalPlan> localAndRegionalPlans, LocalAndRegionalPlan localAndRegionalPlanToDelete)
        {
            DeleteLocalAndRegionalPlan(localAndRegionalPlans, new List<LocalAndRegionalPlan> { localAndRegionalPlanToDelete });
        }
    }
}