//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CostType GetCostType(this IQueryable<CostType> costTypes, int costTypeID)
        {
            var costType = costTypes.SingleOrDefault(x => x.CostTypeID == costTypeID);
            Check.RequireNotNullThrowNotFound(costType, "CostType", costTypeID);
            return costType;
        }

    }
}