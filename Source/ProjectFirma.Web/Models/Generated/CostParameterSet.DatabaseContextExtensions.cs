//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostParameterSet]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteCostParameterSet(this List<int> costParameterSetIDList)
        {
            if(costParameterSetIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCostParameterSets.RemoveRange(HttpRequestStorage.DatabaseEntities.CostParameterSets.Where(x => costParameterSetIDList.Contains(x.CostParameterSetID)));
            }
        }

        public static void DeleteCostParameterSet(this ICollection<CostParameterSet> costParameterSetsToDelete)
        {
            if(costParameterSetsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCostParameterSets.RemoveRange(costParameterSetsToDelete);
            }
        }

        public static void DeleteCostParameterSet(this int costParameterSetID)
        {
            DeleteCostParameterSet(new List<int> { costParameterSetID });
        }

        public static void DeleteCostParameterSet(this CostParameterSet costParameterSetToDelete)
        {
            DeleteCostParameterSet(new List<CostParameterSet> { costParameterSetToDelete });
        }
    }
}