//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostParameterSet]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CostParameterSet GetCostParameterSet(this IQueryable<CostParameterSet> costParameterSets, int costParameterSetID)
        {
            var costParameterSet = costParameterSets.SingleOrDefault(x => x.CostParameterSetID == costParameterSetID);
            Check.RequireNotNullThrowNotFound(costParameterSet, "CostParameterSet", costParameterSetID);
            return costParameterSet;
        }

        public static void DeleteCostParameterSet(this IQueryable<CostParameterSet> costParameterSets, List<int> costParameterSetIDList)
        {
            if(costParameterSetIDList.Any())
            {
                costParameterSets.Where(x => costParameterSetIDList.Contains(x.CostParameterSetID)).Delete();
            }
        }

        public static void DeleteCostParameterSet(this IQueryable<CostParameterSet> costParameterSets, ICollection<CostParameterSet> costParameterSetsToDelete)
        {
            if(costParameterSetsToDelete.Any())
            {
                var costParameterSetIDList = costParameterSetsToDelete.Select(x => x.CostParameterSetID).ToList();
                costParameterSets.Where(x => costParameterSetIDList.Contains(x.CostParameterSetID)).Delete();
            }
        }

        public static void DeleteCostParameterSet(this IQueryable<CostParameterSet> costParameterSets, int costParameterSetID)
        {
            DeleteCostParameterSet(costParameterSets, new List<int> { costParameterSetID });
        }

        public static void DeleteCostParameterSet(this IQueryable<CostParameterSet> costParameterSets, CostParameterSet costParameterSetToDelete)
        {
            DeleteCostParameterSet(costParameterSets, new List<CostParameterSet> { costParameterSetToDelete });
        }
    }
}