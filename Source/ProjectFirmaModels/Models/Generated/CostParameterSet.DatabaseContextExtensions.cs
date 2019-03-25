//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostParameterSet]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CostParameterSet GetCostParameterSet(this IQueryable<CostParameterSet> costParameterSets, int costParameterSetID)
        {
            var costParameterSet = costParameterSets.SingleOrDefault(x => x.CostParameterSetID == costParameterSetID);
            Check.RequireNotNullThrowNotFound(costParameterSet, "CostParameterSet", costParameterSetID);
            return costParameterSet;
        }

    }
}